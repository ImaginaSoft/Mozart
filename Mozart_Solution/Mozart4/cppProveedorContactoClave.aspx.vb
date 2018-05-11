Imports System.Data
Imports System.Data.SqlClient

Partial Class cppProveedorContactoClave
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjCifrado As New cmpRutinas.clsCifrado

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            viewstate("CodProveedor") = Request.Params("CodProveedor")
            viewstate("CodUsuario") = Request.Params("CodContacto")
            lblNomProveedor.Text = Request.Params("NomProveedor")
            lblNomUsuario.Text = Request.Params("NomContacto")
        End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If txtClave.Text.Trim.Length = 0 Then
            lblMsg.Text = "Clave es dato obligatorio"
            Return
        Else
            lblMsg.Text = ""
        End If

        Dim wClave As String

        wClave = ObjCifrado.EncryptString128Bit(txtClave.Text, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))

        Dim UsuarioIP As String
        UsuarioIP = Request.UserHostAddress()

        Dim cd2 As New SqlCommand
        cd2.Connection = cn
        cd2.CommandText = "CPP_ProveedorContactoClave_U"
        cd2.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd2.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd2.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = viewstate("CodProveedor")
        cd2.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = viewstate("CodUsuario")
        cd2.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = wClave
        cd2.Parameters.Add("@IPAddress", SqlDbType.VarChar, 25).Value = UsuarioIP
        cd2.Parameters.Add("@CodUsuarioSys", SqlDbType.Char, 15).Value = Session("CodUsuario")
        lblMsg.Text = ""
        Try
            cn.Open()
            cd2.ExecuteNonQuery()
            lblMsg.Text = cd2.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("cppProveedorContacto.aspx" & _
                      "?CodProveedor=" & viewstate("CodProveedor") & _
                      "&NomProveedor=" & lblNomProveedor.Text)
        End If
    End Sub
    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("cppProveedorContacto.aspx" & _
                  "?CodProveedor=" & viewstate("CodProveedor") & _
                  "&NomProveedor=" & lblNomProveedor.Text)
    End Sub

End Class
