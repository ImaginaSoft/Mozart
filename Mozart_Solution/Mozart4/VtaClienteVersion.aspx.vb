Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing
Partial Class VtaClienteVersion
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objCliente As New cmpNegocio.clsCliente
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")

            Viewstate("TipoCliente") = objCliente.TipoCliente(Viewstate("CodCliente"))
            If Viewstate("TipoCliente") = "A" Then  'Agencia
                txtFchInicial.Text = objRutina.fechaddmmyyyy(-30)
                txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
                dgVersion.Columns(4).Visible = False
                dgVersion.Columns(11).Visible = False
            Else
                cmdBuscar.Visible = False
                dgVersion.Columns(5).Visible = False
                dgVersion.Columns(6).Visible = False
                dgVersion.Columns(9).Visible = False
            End If
            CargaVersion()
        End If
    End Sub
    Private Sub CargaVersion()
        Dim ds As New DataSet
		ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionCodCliente_S", New SqlParameter("@CodCliente", ViewState("CodCliente")))
		dgVersion.DataSource = ds.Tables(0)
        dgVersion.DataBind()

        lblMsg.Text = CStr(dgVersion.Items.Count) + " Version(es)"
    End Sub

    Private Sub dgVersion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgVersion.SelectedIndexChanged
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & CInt(dgVersion.Items(dgVersion.SelectedIndex).Cells(1).Text) & _
        "&NroPropuesta=" & CInt(dgVersion.Items(dgVersion.SelectedIndex).Cells(2).Text) & _
        "&NroVersion=" & CInt(dgVersion.Items(dgVersion.SelectedIndex).Cells(3).Text))
    End Sub

    Private Sub dgVersion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVersion.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(14).Text.Trim = "S" Then
                e.Item.ForeColor = Color.DimGray
            End If

            If e.Item.Cells(13).Text.Trim = "A" Then
                e.Item.ForeColor = Color.DarkGray
            Else
                e.Item.Cells(8).ForeColor = Color.Blue
            End If
        End If
    End Sub

End Class
