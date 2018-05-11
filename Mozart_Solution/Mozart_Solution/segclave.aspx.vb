Imports cmpSeguridad

Partial Class segclave
    Inherits System.Web.UI.Page
    Dim objUsuario As New clsUsuario

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            EditaUsuario()
        End If
    End Sub

    Private Sub EditaUsuario()
        objUsuario.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objUsuario.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblNomUsuario.Text = objUsuario.NomUsuario
        End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        objUsuario.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objUsuario.CambiarClave(txtClave.Text, txtClave1.Text, txtclave2.Text)
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = "La nueva clave fue actualizado correctamente."
            lblMsg.CssClass = "msg"
        End If
    End Sub

End Class
