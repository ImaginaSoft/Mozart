Imports System.Data
Imports System.Data.SqlClient
Imports cmpSeguridad
Imports cmpRutinas

Partial Class seglogin
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objCifrado As New cmpRutinas.clsCifrado
    Dim objRutina As New clsRutinas


    Dim wMensaje As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            'txtCodUsuario.Text = "fernando"
            Session("MenuColorBG") = objRutina.LeeParametroTexto("MenuColorBG")
            Session("Mandante") = objRutina.LeeParametroTexto("Mandante")
            lblMandante.Text = Session("Mandante")
        End If
    End Sub


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        lblMsg.Text = ""
        wMensaje = "Error, codigo de usuario no existe"

        Dim wUsuarioOk As Boolean = False
        Dim wClave1 As String
        Dim wClave2 As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_LeeUsuario_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 50).Value = txtCodUsuario.Text

        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                If dr.GetValue(dr.GetOrdinal("StsUsuario")) = "I" Then
                    wMensaje = "Error, Usuario esta inactivo, comunicar al responsable de seguridad."
                ElseIf dr.GetValue(dr.GetOrdinal("FlagModoTrabajo")) = "L" And Mid(Request.UserHostAddress(), 1, 10) <> "192.168.50" Then
                    wMensaje = "Error, Usuario no tiene acceso externo, comunicar al responsable de seguridad."
                ElseIf dr.GetValue(dr.GetOrdinal("FlagModoTrabajo")) = "E" And Mid(Request.UserHostAddress(), 1, 10) = "192.168.50" Then
                    wMensaje = "Error, Usuario no tiene acceso local, comunicar al responsable de seguridad."
                Else
                    wClave1 = objCifrado.EncryptString128Bit(txtClave.Text, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))
                    wClave2 = dr.GetValue(dr.GetOrdinal("Clave"))
                    If wClave1 = wClave2 Then
                        Session("CodPerfil") = dr.GetValue(dr.GetOrdinal("CodPerfil"))
                        Session("CodUsuario") = dr.GetValue(dr.GetOrdinal("CodUsuario"))

                        ' Autoriza al menu de opciones, 30 posiciones
                        ' 1 posicion con X  : esta autorizado
                        ' 1 posicion con " ": no esta autorizado 
                        Dim objAutoriza As New clsAutoriza
                        Session("MenuPedido") = objAutoriza.AccesoOk(Session("CodPerfil"), "GPT101005")

                        wUsuarioOk = True
                        wMensaje = "Usuario y Clave OK"
                    Else
                        wMensaje = "Error, clave de usuario incorrecta"
                    End If
                End If
            Loop
            dr.Close()

        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error de acceso en nivel 1"
        Catch ex2 As System.Exception
            lblMsg.Text = "Error de acceso en nivel 2"
        Finally
            cn.Close()
        End Try


        If wUsuarioOk And GrabaLogAcceso(wMensaje, wClave1) = "OK" Then

            'Variables sesion global
            Session("CodCliente") = 0
            Session("CodProveedor") = 0
            Session("NroPlantilla") = 0
            Session("Trama") = " "
            Session("IdReg") = ""
            Session("NroPedido") = 0

            Session("PIGV") = objRutina.LeeParametroNumero("PorIGV")


            Response.Redirect("default1.htm")
        Else
            lblMsg.Text = wMensaje
        End If

    End Sub


    Function GrabaLogAcceso(ByVal pMensaje As String, ByVal pClave As String) As String
        Dim ClienteIP As String
        ClienteIP = Request.UserHostAddress()

        Dim cd As New SqlCommand
        Dim pa As New SqlParameter

        cd.Connection = cn
        cd.CommandText = "SEG_LogAccesoUsuario_I"
        cd.CommandType = CommandType.StoredProcedure

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@CodUsuario", SqlDbType.VarChar, 15).Value = txtCodUsuario.Text
        cd.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = pClave
        cd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 25).Value = ClienteIP
        cd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Value = pMensaje
        cd.Parameters.Add("@Sigla", SqlDbType.VarChar, 20).Value = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = "OK"
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
            If wMensaje = "Usuario y Clave OK" Then
                wMensaje = "Error en nivel de acceso 3"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
            If wMensaje = "Usuario y Clave OK" Then
                wMensaje = "Error en nivel de acceso 4"
            End If
        Finally
            cn.Close()
        End Try

        Return (lblMsg.Text)
    End Function

End Class
