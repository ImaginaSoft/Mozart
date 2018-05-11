Imports cmpSeguridad
Partial Class segPerfilNuevo
    Inherits System.Web.UI.Page
    Dim objPerfil As New clsPerfil

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            If Request.Params("Opcion") = "Nuevo" Then
                lblTitulo.Text = "Nuevo Perfil"
            Else
                lblTitulo.Text = "Modifica Perfil"
                txtCodigo.Enabled = False
                txtCodigo.Text = Request.Params("CodPerfil")
                EditaPerfil()
            End If
        End If
    End Sub

    Private Sub EditaPerfil()
        objPerfil.CodPerfil = txtCodigo.Text
        lblMsg.Text = objPerfil.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            txtCodigo.Text = objPerfil.CodPerfil
            txtNombre.Text = objPerfil.NomPerfil
            If objPerfil.StsPerfil = "A" Then
                rbActivo.Checked = True
            Else
                rbInactivo.Checked = True
            End If
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objPerfil.StsPerfil = "A"
        Else
            objPerfil.StsPerfil = "I"
        End If

        objPerfil.CodPerfil = txtCodigo.Text
        objPerfil.NomPerfil = txtNombre.Text
        objPerfil.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPerfil.Grabar
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("segPerfilFicha.aspx" & _
            "?CodPerfil=" & txtCodigo.Text)
        End If
    End Sub

    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("segPerfil.aspx")
    End Sub

End Class
