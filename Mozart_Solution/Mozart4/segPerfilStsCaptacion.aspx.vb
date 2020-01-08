Imports cmpTabla
Imports cmpSeguridad
Imports System.Data

Partial Class segPerfilStsCaptacion
    Inherits System.Web.UI.Page
    Dim objPerfilRestriccion As New clsPerfilRestriccion
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("CodPerfil") = Request.Params("CodPerfil")
            lblNomPerfil.Text = Request.Params("NomPerfil")
            CargaStsCaptacion()
            CargaDatos()
        End If
    End Sub
    Private Sub CargaStsCaptacion()
        Dim objStsCaptacion As New clsStsCaptacion

        Dim ds1 As New DataSet
        ds1 = objStsCaptacion.Cargar
        dllStsCaptacionActual.DataSource = ds1
        dllStsCaptacionActual.DataBind()

        Dim ds2 As New DataSet
        ds2 = objStsCaptacion.Cargar
        ddlStsCaptacionNuevo.DataSource = ds2
        ddlStsCaptacionNuevo.DataBind()
    End Sub

    Private Sub CargaDatos()
        dgTabla.DataSource = objPerfilRestriccion.Cargar(Viewstate("CodPerfil"))
        dgTabla.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If dllStsCaptacionActual.Items.Count = 0 Then
            lblMsg.Text = "Perfil cliente actual es obligatorio"
            Return
        End If
        If ddlStsCaptacionNuevo.Items.Count = 0 Then
            lblMsg.Text = "Perfil cliente nuevo es obligatorio"
            Return
        End If
        objPerfilRestriccion.CodPerfil = viewstate("CodPerfil")
        objPerfilRestriccion.StsCaptacionActual = dllStsCaptacionActual.SelectedItem.Value
        objPerfilRestriccion.StsCaptacionNuevo = ddlStsCaptacionNuevo.SelectedItem.Value
        objPerfilRestriccion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPerfilRestriccion.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla.SelectedIndexChanged
        objPerfilRestriccion.CodPerfil = Viewstate("CodPerfil")
        objPerfilRestriccion.StsCaptacionActual = dgTabla.Items(dgTabla.SelectedIndex).Cells(5).Text
        objPerfilRestriccion.StsCaptacionNuevo = dgTabla.Items(dgTabla.SelectedIndex).Cells(6).Text
        lblMsg.Text = objPerfilRestriccion.Borrar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("SegPerfilFicha.aspx" & _
                   "?CodPerfil=" & viewstate("CodPerfil"))
    End Sub


End Class
