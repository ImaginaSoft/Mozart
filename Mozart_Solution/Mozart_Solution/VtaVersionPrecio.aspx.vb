Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionPrecio
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wTotalSum As Double = 0
    Dim wTotalPrecio As Double = 0


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("DesVersion") = Request.Params("DesVersion")
            Viewstate("StsVersiona") = Request.Params("StsVersion")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Precios de la Versión N° " & Viewstate("NroVersion")
            CargaResumen()
            CargaPrecio()
            CargaServicios()

            If Viewstate("FlagEdita") = "N" Then
                cmdModif.Visible = False
                cmdGrabar.Visible = False
                lblMsg.Text = "La Version es modelo antiguo, no se puede modificar precios"
            Else
                If Viewstate("StsVersion") = "V" Then
                    cmdModif.Visible = False
                    cmdGrabar.Visible = False
                    lblMsg.Text = "La Version fue aprobado, está pendiente de facturar"
                Else
                    If Viewstate("FlagPublica") = "S" Then
                        cmdModif.Visible = False
                        cmdGrabar.Visible = False
                        lblMsg.Text = "La Version está publicada, no se puede modificar los precios"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CargaResumen()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionPrecioResumen_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Resumen")
        'dgResumen.DataKeyField = "KeyReg"
        dgResumen.DataSource = ds.Tables("Resumen")
        dgResumen.DataBind()
    End Sub

    Private Sub CargaPrecio()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionPrecioxTipo_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Resumen2")
        dgPrecio.DataSource = ds.Tables("Resumen2")
        dgPrecio.DataBind()
    End Sub

    Private Sub CargaServicios()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionPrecio_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Servicio")
        'dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()
    End Sub

    Private Sub dgResumen_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgResumen.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(5).Text = "O" Then
                e.Item.Cells(1).Text = ""
                'e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(5).Text = String.Format("{0:###,###,###.00}", wTotalSum)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Sub ComputeSumP(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalPrecio += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(3).Text = String.Format("{0:###,###,###.00}", wTotalPrecio)
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wCheck As Boolean = False
        Dim wNroDia, wNroOrden, wNroServicio, wCodTipoAcomodacion As Integer
        Dim wCodTipoPasajero, wCodSubTipo As String

        Dim wRangoTarifa, wCantSolicita, wCantPersonas As Integer

        If IsNumeric(txtRangoTarifa.Text.Trim) Then
            wRangoTarifa = txtRangoTarifa.Text
        Else
            wRangoTarifa = 0
        End If
        If IsNumeric(txtCantSolicita.Text.Trim) Then
            wCantSolicita = txtCantSolicita.Text
        Else
            wCantSolicita = 0
        End If
        If IsNumeric(txtCantPersonas.Text.Trim) Then
            wCantPersonas = txtCantPersonas.Text
        Else
            wCantPersonas = 0
        End If

        Dim wFlagRangoTarifa As String = "N"
        Dim wFlagCantSolicita As String = "N"
        Dim wFlagCantPersonas As String = "N"

        If chbRangoTarifa.Checked Then
            wFlagRangoTarifa = "S"
        End If
        If chbCantSolicita.Checked Then
            wFlagCantSolicita = "S"
        End If
        If chbCantPersonas.Checked Then
            wFlagCantPersonas = "S"
        End If



        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                wCheck = True

                wNroDia = Mid(dgServicio.DataKeys(index).Value, 1, 2)
                wNroOrden = Mid(dgServicio.DataKeys(index).Value, 3, 2)
                wNroServicio = Mid(dgServicio.DataKeys(index).Value, 5, 6)
                wCodTipoAcomodacion = Mid(dgServicio.DataKeys(index).Value, 11, 3)
                wCodTipoPasajero = Mid(dgServicio.DataKeys(index).Value, 14, 1)
                wCodSubTipo = Mid(dgServicio.DataKeys(index).Value, 15, 1)

                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "VTA_VersionCotiza_U"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""

                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
                cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = ViewState("NroPropuesta")
                cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = ViewState("NroVersion")
                cd.Parameters.Add("@NroDia", SqlDbType.TinyInt).Value = wNroDia
                cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = wNroOrden
                cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = wNroServicio
                cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = wCodTipoAcomodacion
                cd.Parameters.Add("@CodTipoPasajero", SqlDbType.Char, 1).Value = wCodTipoPasajero
                cd.Parameters.Add("@CodSubTipo", SqlDbType.Char, 1).Value = wCodSubTipo
                cd.Parameters.Add("@RangoTarifa", SqlDbType.SmallInt).Value = wRangoTarifa
                cd.Parameters.Add("@CantSolicita", SqlDbType.SmallInt).Value = wCantSolicita
                cd.Parameters.Add("@CantPersonas", SqlDbType.SmallInt).Value = wCantPersonas
                cd.Parameters.Add("@FlagRangoTarifa", SqlDbType.Char, 1).Value = wFlagRangoTarifa
                cd.Parameters.Add("@FlagCantSolicita", SqlDbType.Char, 1).Value = wFlagCantSolicita
                cd.Parameters.Add("@FlagCantPersonas", SqlDbType.Char, 1).Value = wFlagCantPersonas
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblMsg.Text = cd.Parameters("@MsgTrans").Value
                Catch ex1 As System.Data.SqlClient.SqlException
                    lblMsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblMsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()
                If Trim(lblMsg.Text) <> "OK" Then
                    Return
                End If
            End If
        Next

        If wCheck Then
            Response.Redirect("VtaVersionPrecio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion") & _
            "&DesVersion=" & Viewstate("DesVersion"))
        End If
    End Sub


    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaVersionServicio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub cmdModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModif.Click
        Response.Redirect("VtaVersionPrecioManual.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                "&NroVersion=" & Viewstate("NroVersion") & _
                "&DesPropuesta=" & Viewstate("DesPropuesta"))
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Protected Sub dgServicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicio.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgServicio.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgServicio.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next

        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"



    End Sub

    Protected Sub dgServicio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgServicio.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If (e.Row.Cells(17).Text.Length = 0 Or e.Row.Cells(17).Text.Trim = "&nbsp;") And e.Row.Cells(19).Text.Trim = "S" Then
                e.Row.ForeColor = Color.Red
            ElseIf e.Row.Cells(18).Text = "H" Then
                e.Row.ForeColor = Color.DarkBlue
            End If
        End If

    End Sub

End Class
