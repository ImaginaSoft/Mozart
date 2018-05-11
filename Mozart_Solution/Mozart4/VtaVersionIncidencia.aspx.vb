Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionIncidencia
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim dimpinc As Double

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Incidencia Versión N° " & ViewState("NroVersion")

            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionServicioEspeci_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()


        '        If Viewstate("FlagEdita") = "N" Then
        '       cmdGrabar.Visible = False
        '      dgServicio.Columns(0).Visible = False
        '     lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar los Servicios"
        '    lblMsg.CssClass = "msg"
        '   Return
        '  Else
        lblMsg.CssClass = "Msg"
        lblMsg.Text = CStr(nReg) + " Servicio(s)"
        ' End If

    End Sub

    Private Sub CargaProveedor(ByVal pNroServicio As Integer)

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_VersionIncidenciaCompensa_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = pNroServicio
        Dim ds As New DataSet
        da.Fill(ds, "Proveedor")
        ddlProveedor.DataSource = ds.Tables("Proveedor")
        ddlProveedor.DataBind()

        Try
            ddlProveedor.Items.FindByValue(lblCodProveedorCompensa.Text).Selected = True
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        lblMsg.CssClass = "Error"
        If lblNroDia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar el servicio"
            Return
        End If
        If txtImpIncidencia.Text.Trim.Length = 0 Then
            txtImpIncidencia.Text = "0"
        End If

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionIncidencia_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = lblNroDia.Text
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = lblNroOrden.Text
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = lblNroServicio.Text
        cd.Parameters.Add("@DesIncidencia", SqlDbType.VarChar, 100).Value = txtEspeci.Text.Trim
        cd.Parameters.Add("@SolIncidencia", SqlDbType.VarChar, 100).Value = txtSolIncidencia.Text.Trim()
        cd.Parameters.Add("@CodProveedorCompensa", SqlDbType.Int).Value = ddlProveedor.SelectedValue
        cd.Parameters.Add("@ImpIncidencia", SqlDbType.Money).Value = txtImpIncidencia.Text.Trim()
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            lblNroDia.Text = ""
            lblNroOrden.Text = ""
            lblNroServicio.Text = ""
            lblCodProveedorCompensa.Text = ""
            lblCodCiudad.Text = ""

            lblNomProveedor.Text = ""
            lblNomCiudad.Text = ""
            lblDesProveedor.Text = ""
            txtEspeci.Text = ""
            txtSolIncidencia.Text = ""
            txtImpIncidencia.Text = ""
            ddlProveedor.Items.Clear()

            CargaData()
        End If
    End Sub


    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged

        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        lblNroServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text
        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text
        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text

        If dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text.Trim = "&nbsp;" Then
            txtEspeci.Text = ""
        Else
            txtEspeci.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text.Trim
        End If


        If dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text.Trim = "&nbsp;" Then
            txtSolIncidencia.Text = ""
        Else
            txtSolIncidencia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text.Trim
        End If

        lblCodProveedorCompensa.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(13).Text.Trim
        dimpinc = dgServicio.Items(dgServicio.SelectedIndex).Cells(14).Text.Trim
        If dimpinc > 0 Then
            txtImpIncidencia.Text = String.Format("{0:###,###,###,###.00}", dimpinc)
        Else
            txtImpIncidencia.Text = ""
        End If

        CargaProveedor(lblNroServicio.Text)
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & ViewState("NroPedido") & _
        "&NroPropuesta=" & ViewState("NroPropuesta") & _
        "&NroVersion=" & ViewState("NroVersion"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(9).Text.Trim = "OK" Or e.Item.Cells(9).Text.Trim = "CO" Then
                e.Item.Cells(9).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
                'e.Item.Cells(5).ForeColor = Color.Red
                e.Item.Cells(8).ForeColor = Color.Red
                e.Item.Cells(9).ForeColor = Color.Red
            End If
        End If

    End Sub

End Class
