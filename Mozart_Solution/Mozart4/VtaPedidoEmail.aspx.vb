Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Stream
'Imports System.Web.Mail
Imports System.Net.Mail

Partial Class VtaPedidoEmail
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim bdfile As New String(System.Configuration.ConfigurationManager.AppSettings("BDFILE"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("Idioma") = Request.Params("Idioma")

            lblTitulo.Text = "Nuevo Mensaje al Cliente"
            Session("IdReg") = Now
            LeePedido()
            CargaRecordatorio()
            CargaData()
        End If
        With cmdSend
            .Attributes.Add("onClick", "getHTML()")
        End With

    End Sub


    Private Sub LeePedido()
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoNroPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
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

                If dr.GetValue(dr.GetOrdinal("NroRecordatorio")) > 0 Then
                    lblUltRecordatorio.Text = "Ultimo Recordatorio enviado " & dr.GetValue(dr.GetOrdinal("NroRecordatorio"))
                End If

                ViewState("CodZonaVta") = dr.GetValue(dr.GetOrdinal("CodZonaVta"))

                Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
                Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
                Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
                Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")
                Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")

                'PRODUCCION Actual (Idioma del pedido)
                If dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "PER" Then
                    If dr.GetValue(dr.GetOrdinal("Idioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_perutourism & "/ilogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    Else
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_perutourism & "/elogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "ECU" Then
                    If dr.GetValue(dr.GetOrdinal("Idioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_galapagostourism & "/ilogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    Else
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_galapagostourism & "/elogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    End If
                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "CHL" Then
                    If dr.GetValue(dr.GetOrdinal("Idioma")) = "I" Then
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_chiletourism & "/ilogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    Else
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_chiletourism & "/elogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    End If

                ElseIf dr.GetValue(dr.GetOrdinal("CodZonaVta")) = "LAJ" Then
                    If dr.GetValue(dr.GetOrdinal("Idioma")) = "I" Then

                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_latajourneys & "/ilogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    Else
                        lblPaginaPersonalizada.Text = URL_perutourism & "/" & dr.GetValue(dr.GetOrdinal("IDCliente"))

                        'lblPaginaPersonalizada.Text = URL_latajourneys & "/elogin.aspx?ID=" & dr.GetValue(dr.GetOrdinal("IDCliente"))
                    End If


                End If

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub CargaRecordatorio()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_RecordatorioIdioma_S"
        da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = Viewstate("CodZonaVta")
        da.SelectCommand.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = Viewstate("Idioma")
        da.Fill(ds, "Recordatorio")
        ddlRecordatorio.DataSource = ds.Tables("Recordatorio")
        ddlRecordatorio.DataBind()
        ddlRecordatorio.Items.Insert(0, New ListItem("Elegir"))
        ddlRecordatorio.Items.FindByValue("Elegir").Selected = True
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


        'lblMsg.Text = CStr(nReg) + " Archivo(s) encontrado(s)"
    End Sub

    Private Sub cmdAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdjuntar.Click
        lblMsg.Text = ""
        If Path.GetFileName(UploadImage.PostedFile.FileName).Trim.Length = 0 Then
            lblMsg.Text = "No existe File para adjuntar"
            Return
        End If

        Dim DirFileDestino As String
        DirFileDestino = bdfile & "TEMPO\" & _
            Trim(Viewstate("NroPedido")) & "-" & _
            Path.GetFileName(UploadImage.PostedFile.FileName)

        Dim DirFileOrigen As String
        Dim TamFile As Integer = UploadImage.PostedFile.ContentLength()

        DirFileOrigen = UploadImage.PostedFile.FileName

        ' Graba en file server carpeta C:BDFILE\TEMPO
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
            lblMsg.Text = ""
            CargaData()
        End If
    End Sub


    ' Esta funcion existe en RUTINA, pero para facilitar el cambio 
    ' de actualizar el Nro de Recordatorio , se hace una copia
    ' temporal.

    Function GrabaHistorial(ByVal pDesLog As String, _
                                   ByVal pCodCliente As Integer, _
                                   ByVal pNroPedido As Integer, _
                                   ByVal pNroPropuesta As Integer, _
                                   ByVal pNroVersion As Integer, _
                                   ByVal pTipoLog As String, _
                                   ByVal pIdioma As String, _
                                   ByVal pNroRecordatorio As Integer, _
                                   ByVal pCodUsuario As String) As String
        Dim wMsg As String
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ClienteLogNroRecordatorio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = pDesLog
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = pCodCliente
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = pNroVersion
        cd.Parameters.Add("@TipoLog", SqlDbType.Char, 1).Value = pTipoLog
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = pIdioma
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = pNroRecordatorio
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            wMsg = Trim(cd.Parameters("@MsgTrans").Value)
        Catch ex1 As System.Data.SqlClient.SqlException
            wMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            wMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (wMsg)
    End Function

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

    Private Sub ddlRecordatorio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRecordatorio.SelectedIndexChanged
        LeeRecordatorio()
    End Sub

    Private Sub LeeRecordatorio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_DEMAILxNroPedido_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        If ddlRecordatorio.SelectedValue.Trim.Length = 0 Then
            da.SelectCommand.Parameters.Add("@NroRecordatorio", SqlDbType.SmallInt).Value = 0
        Else
            da.SelectCommand.Parameters.Add("@NroRecordatorio", SqlDbType.SmallInt).Value = ddlRecordatorio.SelectedItem.Value
        End If
        dsEdit.Clear()
        da.Fill(dsEdit, "TRECORDATORIO")
        txtAsunto.DataBind()
        FreeTextBox1.DataBind()
    End Sub

    Private Sub rbtEspanol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaRecordatorio()
    End Sub

    Private Sub rbtIngles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaRecordatorio()
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
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
        If FreeTextBox1.Text.Trim.Length = 0 Then
            lblMsg.Text = "Detalle del mensaje es obligatorio"
            Return
        End If

        Dim wNroRecordatorio As Integer = 0
        Dim sDesRecordatorio As String = ""
        If ddlRecordatorio.SelectedItem.Text.Trim <> "Elegir" Then
            wNroRecordatorio = ddlRecordatorio.SelectedValue
            sDesRecordatorio = "N° " & ddlRecordatorio.SelectedItem.Text & "<br><br>"
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

        'Valida si ya existe archivo en la carpeta  destino
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


        Dim client As New SmtpClient
        With client
            .Port = System.Configuration.ConfigurationManager.AppSettings("port")
            .Host = System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")
            .Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("sendusername"), System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
            .EnableSsl = True
        End With


        Dim email As New MailMessage
        With email


            .From = New MailAddress(txtDesde.Text, txtDesde.Text)
            .To.Add(txtPara.Text)
            .CC.Add(txtCC.Text)
            .Subject = txtAsunto.Text
            .Body = FreeTextBox1.Text
            .IsBodyHtml = True
            .Priority = MailPriority.High
            '.Attachments.Add(New )
            '.To = txtPara.Text
            '.Cc = txtCC.Text
            '.Subject = txtAsunto.Text
            '.Body = FreeTextBox1.Text
            '.BodyFormat = MailFormat.Html
            '.Priority = MailPriority.High

            For Each item In dgFile.Items
                wFileTempo = dgFile.DataKeys(item.ItemIndex).ToString
                wFileFinal = wDirDestino & wFileTempo.Substring(21, 200).Trim

                File.Move(wFileTempo, wFileFinal)
                .Attachments.Add(New Attachment(Trim(wFileFinal)))

                wfiles = wfiles & " " & wFileFinal
            Next
            '.From = txtDesde.Text
            '.To = txtPara.Text
            '.Cc = txtCC.Text
            '.Subject = txtAsunto.Text
            '.Body = FreeTextBox1.Text
            '.BodyFormat = MailFormat.Html
            '.Priority = MailPriority.High
            'For Each item In dgFile.Items
            '    wFileTempo = dgFile.DataKeys(item.ItemIndex).ToString
            '    wFileFinal = wDirDestino & wFileTempo.Substring(21, 200).Trim

            '    File.Move(wFileTempo, wFileFinal)
            '    .Attachments.Add(New MailAttachment(Trim(wFileFinal)))

            '    wfiles = wfiles & " " & wFileFinal
            'Next
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")) 'smtp Server Address
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings("sendusername"))
            '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
        End With
        'SmtpMail.Send(email)
        client.Send(email)
        email.Dispose()

        lblMsg.Text = GrabaHistorial(sDesRecordatorio & FreeTextBox1.Text & wfiles, _
          Viewstate("CodCliente"), Viewstate("NroPedido"), _
          0, 0, "5", Viewstate("Idioma"), wNroRecordatorio, Session("CodUsuario"))

        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPedidoHistorial.aspx" & _
               "?NroPedido=" & Viewstate("NroPedido") & _
               "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

End Class
