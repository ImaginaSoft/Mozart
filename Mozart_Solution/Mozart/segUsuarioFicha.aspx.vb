Imports cmpSeguridad
Imports cmpTabla


Partial Class segUsuarioFicha
    Inherits System.Web.UI.Page
    Dim objUsuario As New clsUsuario

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("CodUsuario") = Request.Params("CodUsuario")
            EditaUsuario()
            CargaDatos()
        End If
    End Sub
    Private Sub EditaUsuario()
        objUsuario.CodUsuario = Viewstate("CodUsuario")
        lblMsg.Text = objUsuario.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblCodigoUsuario.Text = objUsuario.CodUsuario
            lblNombreUsuario.Text = objUsuario.NomUsuario
            lblCodPerfil.Text = objUsuario.CodPerfil
            lblEstado.Text = objUsuario.NomStsUsuario
            lblTipoIdioma.Text = objUsuario.NomTipoIdioma
            If objUsuario.FlagLogAcceso = "P" Then
                lblLogAcceso.Text = "Ver log propio"
            Else
                lblLogAcceso.Text = "Ver log de todos los usuarios"
            End If
            If objUsuario.FlagVtaAcceso = "P" Then
                lblVtaAcceso.Text = "Ver ventas propias"
            Else
                lblVtaAcceso.Text = "Ver ventas de todos los vendedores"
            End If
            If objUsuario.FlagModoTrabajo = "A" Then
                lblModoTrabajo.Text = "Acceso local y externo"
            ElseIf objUsuario.FlagModoTrabajo = "L" Then
                lblModoTrabajo.Text = "Solo acceso local"
            Else
                lblModoTrabajo.Text = "Solo acceso externo"
            End If
            lblActualiza.Text = String.Format("{0,1:dd MMM yyyy}{0,13:hh:mm tt }", objUsuario.FchSys)
            lblUsuario.Text = objUsuario.CodUsuarioSys
        End If
    End Sub

    Private Sub CargaDatos()
        Dim objZonaVta As New clsZonaVta
        dgTabla.DataSource = objZonaVta.Cargar(Viewstate("CodUsuario"))
        dgTabla.DataBind()
    End Sub

    Private Sub lbtCambiarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarClave.Click
        Response.Redirect("segUsuarioClave.aspx" & _
                     "?CodUsuario=" & Viewstate("CodUsuario") & _
                     "&NomUsuario=" & lblNombreUsuario.Text)
    End Sub

    Private Sub lbtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevo.Click
        Response.Redirect("segUsuarioNuevo.aspx" & _
                           "?Opcion=" & "Nuevo")
    End Sub
    Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
        Response.Redirect("segUsuarioNuevo.aspx" & _
                          "?Opcion=" & "Modifica" & _
                          "&CodUsuario=" & Viewstate("CodUsuario"))
    End Sub
    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        objUsuario.CodUsuario = Viewstate("CodUsuario")
        lblMsg.Text = objUsuario.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("segUsuario.aspx")
        End If
    End Sub

    Private Sub lbtAsignarZonaVta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAsignarZonaVta.Click
        Response.Redirect("segUsuarioZonaVta.aspx" & _
        "?CodUsuario=" & Viewstate("CodUsuario") & _
        "&NomUsuario=" & lblNombreUsuario.Text)
    End Sub

End Class
