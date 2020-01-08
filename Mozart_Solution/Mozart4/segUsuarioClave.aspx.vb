Imports cmpSeguridad
Partial Class segUsuarioClave
    Inherits System.Web.UI.Page
    Dim objUsuario As New clsUsuario
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            viewstate("CodUsuario") = Request.Params("CodUsuario")
            lblNomUsuario.Text = Request.Params("NomUsuario")
        End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        objUsuario.CodUsuario = viewstate("CodUsuario")
        objUsuario.Clave = txtClave.Text
        objUsuario.IPAddress = Request.UserHostAddress()
        objUsuario.CodUsuarioSys = Session("CodUsuario")
        lblMsg.Text = objUsuario.CambiarClave
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("segUsuario.aspx")
        End If
    End Sub
    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("SegUsuarioFicha.aspx" & _
               "?CodUsuario=" & viewstate("CodUsuario"))
    End Sub

End Class
