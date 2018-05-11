Imports cmpSeguridad

Partial Class SegOpciones
    Inherits System.Web.UI.Page

    Dim objPerfilFuncion As New clsPerfilFuncion

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            viewstate("CodPerfil") = Request.Params("CodPerfil")
            viewstate("NomPerfil") = Request.Params("NomPerfil")
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim objfuncion As New clsFuncion

        Label2.Text = "Opciones de " & viewstate("NomPerfil")
        dgTabla.DataSource = objfuncion.Cargar("GPT", viewstate("CodPerfil"))
        dgTabla.DataBind()

        dgTabla2.DataSource = objPerfilFuncion.Cargar("GPT", viewstate("CodPerfil"))
        dgTabla2.DataBind()
    End Sub

    Private Sub dgTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla.SelectedIndexChanged
        objPerfilFuncion.CodPerfil = viewstate("CodPerfil")
        objPerfilFuncion.CodFuncion = dgTabla.Items(dgTabla.SelectedIndex).Cells(1).Text
        objPerfilFuncion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPerfilFuncion.Grabar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            CargaDatos()
        End If
    End Sub

    Private Sub dgTabla2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla2.SelectedIndexChanged
        objPerfilFuncion.CodPerfil = viewstate("CodPerfil")
        objPerfilFuncion.CodFuncion = dgTabla2.Items(dgTabla2.SelectedIndex).Cells(1).Text
        objPerfilFuncion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPerfilFuncion.Borrar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            CargaDatos()
        End If
    End Sub

    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("segPerfilFicha.aspx" & _
        "?CodPerfil=" & viewstate("CodPerfil"))
    End Sub
End Class
