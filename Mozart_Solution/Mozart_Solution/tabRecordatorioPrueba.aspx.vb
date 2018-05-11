Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Web.Mail
Imports System.Data.SqlClient

Partial Class tabRecordatorioPrueba
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Prueba de enviar Recordatorio"

            txtDe.Text = "malka@perutourism.com"
            txtPara.Text = "Fernando@pentagrama.com"
            txtCC.Text = ""

            txtAsunto.Text = "Recordatorio Nro " & Request.Params("NroRecordatorio")
            If Request.Params("Idioma") = "I" Then
                txtAsunto.Text = txtAsunto.Text & " (en Ingles)"
            Else
                txtAsunto.Text = txtAsunto.Text & " (en Español)"
            End If

            Viewstate("CodZonaVta") = Request.Params("CodZonaVta")
            Viewstate("Idioma") = Request.Params("Idioma")
            Viewstate("NroRecordatorio") = Request.Params("NroRecordatorio")

            LeeRecordatorio()
        End If
    End Sub
    Private Sub LeeRecordatorio()
        Dim wFchProceso As DateTime = Now
        ' Lee e-mail de Recordatorio
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_DEMAILPruebaEnvio_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@FchProceso", SqlDbType.DateTime).Value = wFchProceso
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = Viewstate("CodZonaVta")
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = Viewstate("Idioma")
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = Viewstate("NroRecordatorio")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtAsunto.Text = dr.GetValue(dr.GetOrdinal("Asunto"))
                lblMensaje.Text = dr.GetValue(dr.GetOrdinal("Mensaje"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        'Proceso para enviar e-mail
        Dim email As New MailMessage

        With email
            .From = txtDe.Text
            .To = txtPara.Text
            .Cc = txtCC.Text
            .Subject = txtAsunto.Text
            .Body = lblMensaje.Text
            .BodyFormat = MailFormat.Html
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")) 'smtp Server Address
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings("sendusername"))
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
            ' .Priority = MailPriority.High
        End With
        SmtpMail.Send(email)

        Response.Redirect("tabRecordatorio.aspx")
    End Sub

End Class
