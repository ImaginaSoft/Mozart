Imports cmpSeguridad
Partial Class segPerfilFicha
    Inherits System.Web.UI.Page
    Dim objPerfil As New clsPerfil

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("CodPerfil") = Request.Params("CodPerfil")
            EditaPerfil()
            CargaDatos()
        End If
    End Sub

    Private Sub EditaPerfil()
        objPerfil.CodPerfil = Viewstate("CodPerfil")
        lblMsg.Text = objPerfil.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblCodPerfil.Text = objPerfil.CodPerfil
            lblNomPerfil.Text = objPerfil.NomPerfil
            lblNomStsPerfil.Text = objPerfil.NomStsPerfil
            lblActualiza.Text = String.Format("{0,1:dd MMM yyyy}{0,13:hh:mm tt }", objPerfil.FchSys)
            lblUsuario.Text = objPerfil.CodUsuario
        End If
    End Sub

    Private Sub CargaDatos()
        Dim objPerfilRestriccion As New clsPerfilRestriccion
        dgTabla.DataSource = objPerfilRestriccion.Cargar(lblCodPerfil.Text)
        dgTabla.DataBind()
    End Sub

    Private Sub lbtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevo.Click
        Response.Redirect("segPerfilNuevo.aspx" & _
                           "?Opcion=" & "Nuevo")
    End Sub
    Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
        Response.Redirect("segPerfilNuevo.aspx" & _
                          "?Opcion=" & "Modifica" & _
                          "&CodPerfil=" & Viewstate("CodPerfil"))
    End Sub
    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        objPerfil.CodPerfil = lblCodPerfil.Text
        lblMsg.Text = objPerfil.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("segPerfil.aspx")
        End If
    End Sub

    Private Sub lbtOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtOpciones.Click
        Response.Redirect("SegOpciones.aspx" & _
            "?CodPerfil=" & lblCodPerfil.Text & _
            "&NomPerfil=" & lblNomPerfil.Text)
    End Sub

    Private Sub lbtRestriccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRestriccion.Click
        Response.Redirect("SegPerfilStsCaptacion.aspx" & _
            "?CodPerfil=" & lblCodPerfil.Text & _
            "&NomPerfil=" & lblNomPerfil.Text)
    End Sub

End Class
