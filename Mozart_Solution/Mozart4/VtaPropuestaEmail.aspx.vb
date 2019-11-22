Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Stream
Imports System.Web.Mail
'Imports System.Net.Mail
Imports cmpRutinas
Imports cmpNegocio

Partial Class VtaPropuestaEmail
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim bdfile As New String(System.Configuration.ConfigurationManager.AppSettings("BDFILE"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("CodCliente") = Request.Params("CodCliente")
            lblTitulo.Text = "Nuevo Mensaje al Cliente"
            Session("IdReg") = Now
            LeePedido()
            CargaData()
        End If

    End Sub

    Private Sub LeePedido()
        Dim wPaterno As String
        txtAsunto.Text = "RE:Your Trip to Peru / "

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoNroPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Email"))) Then
                    txtDesde.Text = dr.GetValue(dr.GetOrdinal("EmailVendedor"))
                    txtCC.Text = dr.GetValue(dr.GetOrdinal("EmailVendedor"))
                End If
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Email"))) Then
                    txtPara.Text = dr.GetValue(dr.GetOrdinal("Email"))
                End If
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("EmailContacto"))) Then
                    If RTrim(dr.GetValue(dr.GetOrdinal("EmailContacto"))).Length > 0 Then
                        txtPara.Text = txtPara.Text.Trim & ";" & LTrim(dr.GetValue(dr.GetOrdinal("EmailContacto")))
                    End If
                End If
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("Nombre"))) Then
                    txtAsunto.Text = txtAsunto.Text & " " & dr.GetValue(dr.GetOrdinal("Nombre"))
                End If

                If Not IsDBNull(wPaterno = dr.GetValue(dr.GetOrdinal("Paterno"))) Then
                    wPaterno = dr.GetValue(dr.GetOrdinal("Paterno"))
                    txtAsunto.Text = txtAsunto.Text & " " & wPaterno.ToUpper
                End If
                lblTipoCliente.Text = dr.GetValue(dr.GetOrdinal("TipoCliente"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub CargaData()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_ClienteLogFileTempo_S"
        da.SelectCommand.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        da.SelectCommand.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")

        Dim nReg As Integer = da.Fill(ds, "Log")
        dgFile.DataKeyField = "DirFileDestino"
        dgFile.DataSource = ds.Tables("Log")
        dgFile.DataBind()

        lblMsg.Text = CStr(nReg) + " Archivo(s) encontrado(s)"
    End Sub

    Private Sub cmdAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdjuntar.Click
        lblMsg.Text = ""
        If Path.GetFileName(UploadImage.PostedFile.FileName).Trim.Length = 0 Then
            lblMsg.Text = "No existe File para adjuntar"
            Return
        End If

        Dim DirFileDestino As String
        DirFileDestino = bdfile & "TEMPO\" & _
            Trim(ViewState("NroPedido")) & "." & Trim(ViewState("NroPropuesta")) & "-" & _
            Path.GetFileName(UploadImage.PostedFile.FileName)

        'Dim NomFile As String
        Dim DirFileOrigen As String
        Dim TamFile As Integer = UploadImage.PostedFile.ContentLength()

        DirFileOrigen = UploadImage.PostedFile.FileName

        UploadImage.PostedFile.SaveAs(DirFileDestino)

        ' Grabar en Temporal
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ClienteLogFileTempo_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@IdReg", SqlDbType.VarChar, 25).Value = Session("IdReg")
        cd.Parameters.Add("@DirFileOrigen", SqlDbType.VarChar, 255).Value = DirFileOrigen
        cd.Parameters.Add("@TamFile", SqlDbType.Int).Value = CInt(TamFile / 1000)
        cd.Parameters.Add("@DirFileDestino", SqlDbType.Char, 255).Value = DirFileDestino
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            CargaData()
        End If
    End Sub

    Private Sub cmSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmSend.Click
        lblMsg.Text = ""
        If txtDesde.Text.Trim.Length = 0 Then
            lblMsg.Text = "E-mail de origen es dato obligatorio"
            Return
        End If
        If txtPara.Text.Trim.Length = 0 Then
            lblMsg.Text = "E-mail del cliente es dato obligatorio"
            Return
        End If
        If txtAsunto.Text.Trim.Length = 0 Then
            lblMsg.Text = "Asunto es dato obligatorio"
            Return
        End If

        ' concatena los archivos adjuntos del e-mail
        Dim wfiles As String

        'Ubicacion final de los archivos adjuntos
        Dim wFileFinal As String
        Dim wDirDestino As String

        Dim wAno As String = Year(Now)
        Dim wMes As String = Month(Now)
        Dim wDia As String = Day(Now)

        If ((wMes).Trim).Length = 1 Then
            wMes = "0" + wMes
        End If
        If ((wDia).Trim).Length = 1 Then
            wDia = "0" + wDia
        End If

        wDirDestino = bdfile & wAno & "\" & wMes & "\" & wDia & "\"
        If Not Directory.Exists(wDirDestino) Then
            Directory.CreateDirectory(wDirDestino)
        End If

        'Valida si ya existe archivo en la carpeta destino
        lblMsg.Text = ""
        Dim wFileTempo As String
        Dim item As DataGridItem
        For Each item In dgFile.Items
            wFileTempo = dgFile.DataKeys(item.ItemIndex).ToString
            wFileFinal = wDirDestino & wFileTempo.Substring(21, 200).Trim
            If File.Exists(wFileFinal) Then
                lblMsg.Text = "Archivo " & wFileFinal & " con ese nombre ya fue enviado al Cliente. "
                Return
            End If
        Next
        If lblMsg.Text <> "" Then
            Return
        End If

        'Proceso para enviar e-mail
        'Dim client As New SmtpClient
        'With client
        '    .Port = System.Configuration.ConfigurationManager.AppSettings("port")
        '    .Host = System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")
        '    .Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("sendusername"), System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
        '    .EnableSsl = True
        'End With

        Dim email As New MailMessage
        With email
            '.Sender = New MailAddress(txtDesde.Text)

            '.From = New MailAddress(txtDesde.Text, txtDesde.Text)
            '.To.Add(txtPara.Text)
            '.CC.Add(txtCC.Text)
            '.Subject = txtAsunto.Text
            '.Body = FreeTextBox1.Text
            '.IsBodyHtml = True
            '.Priority = MailPriority.High
            '.Attachments.Add(New )
            .From = txtDesde.Text
            .To = txtPara.Text
            .CC = txtCC.Text
            .Subject = txtAsunto.Text
            .Body = FreeTextBox1.Text
            .BodyFormat = MailFormat.Html
            .Priority = MailPriority.High

            For Each item In dgFile.Items
                wFileTempo = dgFile.DataKeys(item.ItemIndex).ToString
                wFileFinal = wDirDestino & wFileTempo.Substring(21, 200).Trim

                File.Move(wFileTempo, wFileFinal)
                .Attachments.Add(New MailAttachment(Trim(wFileFinal)))

                wfiles = wfiles & " " & wFileFinal
            Next
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")) 'smtp Server Address
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", System.Configuration.ConfigurationManager.AppSettings("port"))
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network

            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings("sendusername"))
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
        End With
        SmtpMail.Send(email)
        'Dim client As New SmtpClient
        'client.EnableSsl = True
        'client.Host = "smtp.gmail.com"
        'client.EnableSsl = True
        'client.Send(email)
        'email.Dispose()

        'Agencia (peru4all)
        If lblTipoCliente.Text.Trim = "A" Then
            ActualizaRpta()
        End If

        Dim objRutina As New clsRutinas
        lblMsg.Text = objRutina.GrabaHistorial(FreeTextBox1.Text & wfiles, _
          Viewstate("CodCliente"), Viewstate("NroPedido"), _
          Viewstate("NroPropuesta"), 0, "2", "S", Session("CodUsuario"))

        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPropuestaHistorial.aspx" & _
               "?NroPedido=" & Viewstate("NroPedido") & _
               "&NroPropuesta=" & Viewstate("NroPropuesta") & _
               "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Private Sub ActualizaRpta()
        Dim objPublica As New clsPublica
        lblMsg.Text = objPublica.GrabaFchRpta(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Session("CodUsuario"))
    End Sub


    Private Sub dgFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgFile.SelectedIndexChanged
        ' Borra del File Server
        Dim wfile As String
        wfile = dgFile.DataKeys(dgFile.SelectedIndex).ToString
        File.Delete(wfile)

        ' Borra de la Tabla Temporal
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ClienteLogFileTempo_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@IdReg", SqlDbType.VarChar, 25).Value = Session("IdReg")
        cd.Parameters.Add("@DirFileDestino", SqlDbType.Char, 255).Value = wfile
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            CargaData()
        End If
    End Sub

End Class
