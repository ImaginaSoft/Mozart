
Partial Class cpcClienteContactoClave
    Inherits System.Web.UI.Page
    Dim objCifrado As New cmpRutinas.clsCifrado
    Dim objContacto As New cmpNegocio.clsClienteContacto

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            viewstate("CodCliente") = Request.Params("CodCliente")
            viewstate("CodUsuario") = Request.Params("CodContacto")
            lblNomCliente.Text = Request.Params("NomCliente")
            lblNomUsuario.Text = Request.Params("NomContacto")
        End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        lblMsg.Text = ""
        If txtClave.Text.Trim.Length = 0 Then
            lblMsg.Text = "Clave es dato obligatorio"
            Return
        End If

        Dim wClave As String
        wClave = objCifrado.EncryptString128Bit(txtClave.Text, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))
        Dim UsuarioIP As String
        UsuarioIP = Request.UserHostAddress()

        objContacto.CodCliente = viewstate("CodCliente")
        objContacto.CodContacto = viewstate("CodUsuario")
        objContacto.Clave = wClave
        objContacto.IPAddress = UsuarioIP
        objContacto.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objContacto.CambiarClave
        If lblMsg.Text.Trim = "OK" Then
            Regresa()
        End If
    End Sub
    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Regresa()
    End Sub
    Private Sub Regresa()
        Response.Redirect("cpcClienteContacto.aspx" & _
                  "?CodCliente=" & viewstate("CodCliente") & _
                  "&NomCliente=" & lblNomCliente.Text)
    End Sub

End Class
