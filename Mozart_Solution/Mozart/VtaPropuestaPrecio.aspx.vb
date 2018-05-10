Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class VtaPropuestaPrecio
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
            Viewstate("DesPropuesta") = Request.Params("DesPropuesta")
            Viewstate("StsPropuesta") = Request.Params("StsPropuesta")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Precios de la Propuesta N° " & Viewstate("NroPropuesta")
            lblPropuesta.Text = Viewstate("DesPropuesta")
            CargaResumen()
            CargaPrecio()
            CargaServicios()

            If Viewstate("FlagEdita") = "N" Or Viewstate("StsPropuesta") = "V" Or Viewstate("FlagPublica") = "S" Then
                cmdModif.Visible = False
                cmdGrabar.Visible = False
                If Viewstate("FlagEdita") = "N" Then
                    lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar precios"
                ElseIf Viewstate("StsPropuesta") = "V" Then
                    lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar precios"
                ElseIf Viewstate("FlagPublica") = "S" Then
                    lblMsg.Text = "La Propuesta está publicada, no se puede modificar los precios"
                End If
            End If
        End If
    End Sub

    Private Sub CargaResumen()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaPrecioResumen_S", arParms)
        dgResumen.DataSource = ds
        dgResumen.DataBind()
    End Sub

    Private Sub CargaPrecio()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaPrecioxTipo_S", arParms)
        dgPrecio.DataSource = ds
        dgPrecio.DataBind()
    End Sub

    Private Sub CargaServicios()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaPrecio_S", arParms)
        'dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds
        dgServicio.DataBind()
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
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
                cd.CommandText = "VTA_PropuestaCotiza_U"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
                cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = ViewState("NroPropuesta")
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
                If lblMsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next

        If wCheck Then
            Response.Redirect("VtaPropuestaPrecio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&DesPropuesta=" & Viewstate("DesPropuesta"))
        End If
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaPropuestaServicio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub cmdModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModif.Click
        Response.Redirect("VtaPropuestaPrecioManual.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&DesPropuesta=" & Viewstate("DesPropuesta") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta"))
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
            If (e.Row.Cells(17).Text.Trim.Length = 0 Or e.Row.Cells(17).Text.Trim = "&nbsp;") And e.Row.Cells(19).Text.Trim = "S" Then
                e.Row.ForeColor = Color.Red
            ElseIf e.Row.Cells(18).Text = "H" Then
                e.Row.ForeColor = Color.DarkBlue
            End If
        End If
    End Sub
End Class
