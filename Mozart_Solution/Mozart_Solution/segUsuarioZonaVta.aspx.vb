Imports cmpTabla
Imports cmpSeguridad
Imports System.Data

Partial Class segUsuarioZonaVta
    Inherits System.Web.UI.Page
    Dim objUsuarioZonaVta As New clsUsuarioZonaVta

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("CodUsuario") = Request.Params("CodUsuario")
            lblNomUsuario.Text = Request.Params("NomUsuario")
            CargaZonaVta()
            CargaDatos()
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim objZonaVta As New clsZonaVta
        Dim ds As New DataSet
        ds = objZonaVta.Cargar
        dllZonaVta.DataSource = ds
        dllZonaVta.DataBind()
    End Sub

    Private Sub CargaDatos()
        Dim objZonaVta As New clsZonaVta
        dgTabla.DataSource = objZonaVta.Cargar(Viewstate("CodUsuario"))
        dgTabla.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If dllZonaVta.Items.Count = 0 Then
            lblMsg.Text = "Zona de venta es obligatorio"
            Return
        End If
        objUsuarioZonaVta.CodUsuario = viewstate("CodUsuario")
        objUsuarioZonaVta.CodZonaVta = dllZonaVta.SelectedItem.Value
        objUsuarioZonaVta.CodUsuarioSys = Session("CodUsuario")
        lblMsg.Text = objUsuarioZonaVta.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla.SelectedIndexChanged
        objUsuarioZonaVta.CodUsuario = Viewstate("CodUsuario")
        objUsuarioZonaVta.CodZonaVta = dgTabla.Items(dgTabla.SelectedIndex).Cells(0).Text
        lblMsg.Text = objUsuarioZonaVta.Borrar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("SegUsuarioFicha.aspx" & _
                   "?CodUsuario=" & viewstate("CodUsuario"))
    End Sub

End Class
