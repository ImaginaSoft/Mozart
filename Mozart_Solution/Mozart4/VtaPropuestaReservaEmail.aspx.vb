﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
'Imports System.Net.Mail
Imports System.Web.Mail
Imports System.Data.SqlClient

Partial Class VtaPropuestaReservaEmail
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Reserva para Proveedor " & Request.Params("NomProveedor")
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            ViewState("CodContacto") = Request.Params("CodContacto")
            LeePropuesta()
            CargaContacto()
        End If
        With cmdSend
            .Attributes.Add("onClick", "getHTML()")
        End With
    End Sub

    Private Sub CargaContacto()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "OPE_Contacto_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ViewState("CodProveedor")
        da.SelectCommand.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = ViewState("CodContacto")
        Dim ds As New DataSet
        da.Fill(ds, "Contacto")
        ddlContacto.DataSource = ds.Tables("Contacto")
        ddlContacto.DataBind()
        If ddlContacto.Items.Count > 0 Then
            If Len(Trim(ViewState("CodContacto"))) > 0 Then
                ddlContacto.Items.FindByValue(ViewState("CodContacto")).Selected = True
            End If
            AsignaEmailContacto()
        End If
    End Sub


    Private Sub AsignaEmailContacto()
        txtPara.Text = ""

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "OPE_LeeContacto_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ViewState("CodProveedor")
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = ddlContacto.SelectedItem.Value
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtPara.Text = dr.GetValue(dr.GetOrdinal("EmailContacto"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LeePropuesta()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaNroPropuesta_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtAsunto.Text = "PAX " & _
                                dr.GetValue(dr.GetOrdinal("NomCliente")) & " x " & _
                                CStr(dr.GetValue(dr.GetOrdinal("CantAdultos")) + _
                                     dr.GetValue(dr.GetOrdinal("CantNinos")))
                txtDe.Text = dr.GetValue(dr.GetOrdinal("Email"))
                txtCC.Text = dr.GetValue(dr.GetOrdinal("Email"))
                ViewState("CodCliente") = dr.GetValue(dr.GetOrdinal("CodCliente"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        lblmsg.Text = ""
        If txtDe.Text.Trim.Length = 0 Then
            lblmsg.Text = "E-mail de origen es dato obligatorio"
            Return
        End If
        If ddlContacto.Items.Count = 0 Then
            lblmsg.Text = "E-mail del responsable en proveedor es dato obligatorio"
            Return
        End If
        If txtAsunto.Text.Trim.Length = 0 Then
            lblmsg.Text = "Asunto es dato obligatorio"
            Return
        End If

        'Grabar Reserva 
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ProveedorLog_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroLog", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = txtRTB.Text
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ViewState("CodProveedor")
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = 0 'Viewstate("NroVersion")
        cd.Parameters.Add("@TipoLog", SqlDbType.Char, 1).Value = "2"
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblmsg.Text) = "OK" Then
            'Proceso para enviar e-mail

            Dim objEmail As New cmpNegocio.clsEmailSendGrid
            Dim rpta As String = objEmail.EnviarCorreo("Pentagrama", txtDe.Text, txtPara.Text, txtAsunto.Text, txtRTB.Text, Nothing)



            'Dim email As New MailMessage
            'With email
            '    .From = txtDe.Text
            '    .To = txtPara.Text
            '    .CC = txtCC.Text
            '    .Subject = txtAsunto.Text
            '    .Body = txtRTB.Text
            '    .BodyFormat = MailFormat.Html
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")) 'smtp Server Address
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", System.Configuration.ConfigurationManager.AppSettings("port"))
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings("sendusername"))
            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
            '    ' .Priority = MailPriority.High
            'End With
            'SmtpMail.Send(email)


            'Proceso para enviar e-mail(new)
            'Dim client As New SmtpClient
            'With client
            '    .Port = System.Configuration.ConfigurationManager.AppSettings("port")
            '    .Host = System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")
            '    .Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("sendusername"), System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
            '    .EnableSsl = True
            'End With

            'Dim email As New MailMessage
            'With email

            '    .From = New MailAddress(txtDe.Text, txtDe.Text)
            '    .To.Add(txtPara.Text)
            '    .Cc.Add(txtCC.Text)
            '    .Subject = txtAsunto.Text
            '    .Body = txtRTB.Text
            '    .IsBodyHtml = True
            '    .Priority = MailPriority.High

            'End With

            'client.Send(email)
            'email.Dispose()


            Response.Redirect("VtaPropuestaReserva.aspx" & _
                       "?NroPedido=" & ViewState("NroPedido") & _
                       "&NroPropuesta=" & ViewState("NroPropuesta"))
        End If
    End Sub

    Private Sub ddlContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlContacto.SelectedIndexChanged
        AsignaEmailContacto()
    End Sub

End Class
