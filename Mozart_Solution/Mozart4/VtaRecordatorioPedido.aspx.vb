Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Mail
'Imports System.Net.Mail


Partial Class VtaRecordatorioPedido
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim cn1 As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
            lblmsg.CssClass = "Msg"
            lblmsg.Text = ""
            CargaPedidos()
        End If
    End Sub
    Private Sub CargaPedidos()
        Dim da As New SqlDataAdapter
        Dim wtipodoc As String
        Dim westado, wEstadoPedido As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_RecordatorioPedido_S"
        da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = "S"
        da.SelectCommand.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Pedido")
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()
        If nReg = 0 Then
            cmdEnviar.Enabled = False
        Else
            cmdEnviar.Enabled = True
        End If

        If lblmsg.Text = "" Then
            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        lblmsg.Text = ""
        lblmsg.CssClass = "Msg"
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPedidos.SortCommand
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPedidos.SelectedIndexChanged
        Response.Redirect("VtaPedidoFicha.aspx" & _
                          "?NroPedido=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(4).Text & _
                         "&CodCliente=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(7).Text)
    End Sub


    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        ' Limpia mensaje de errores    
        lblmsg.Text = ""
        lblmsg.CssClass = "Error"

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_RecordatorioPedido_S"
        da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = "S"
        da.SelectCommand.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Pedido")

        'Proceso para enviar e-mail
        Dim email As New MailMessage

        Dim wFchProceso As DateTime = Now
        Dim wStsEnvio As Boolean = False

        Dim oDataRow As DataRow
        For Each oDataRow In ds.Tables(0).Rows
            If Trim(oDataRow.Item(7)).Length = 0 Then
                lblmsg.Text = lblmsg.Text & " NroPedido=" & oDataRow.Item(1) & " Error: Falta e-mail <br>"

                'No tiene email , que como pendiente de enviar
            Else
                wStsEnvio = False

                ' Lee y envia e-mail de Recordatorio
                Dim cd As New SqlCommand
                Dim dr As SqlDataReader
                cd.Connection = cn
                cd.CommandText = "VTA_DEMAIL_S"
                cd.CommandType = CommandType.StoredProcedure
                cd.Parameters.Add("@FchProceso", SqlDbType.DateTime).Value = wFchProceso
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = oDataRow.Item(1)
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                Try
                    cn.Open()
                    dr = cd.ExecuteReader
                    Do While dr.Read()

                        With email
                            .From = dr.GetValue(dr.GetOrdinal("De"))
                            .To = dr.GetValue(dr.GetOrdinal("Para"))
                            .CC = dr.GetValue(dr.GetOrdinal("De"))
                            .Subject = dr.GetValue(dr.GetOrdinal("Asunto"))
                            .Body = dr.GetValue(dr.GetOrdinal("Mensaje"))
                            .BodyFormat = MailFormat.Html
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")) 'smtp Server Address
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", System.Configuration.ConfigurationManager.AppSettings("port"))
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings("sendusername"))
                            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
                            ' .Priority = MailPriority.High
                        End With


                        'Proceso para enviar e-mail
                        'Dim client As New SmtpClient
                        'With client
                        '    .Port = System.Configuration.ConfigurationManager.AppSettings("port")
                        '    .Host = System.Configuration.ConfigurationManager.AppSettings("ServidorEmail")
                        '    .Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("sendusername"), System.Configuration.ConfigurationManager.AppSettings("sendpassword"))
                        '    .EnableSsl = True
                        'End With

                        ''Dim email As New MailMessage
                        'With email

                        '    .From = New MailAddress(dr.GetValue(dr.GetOrdinal("De")), dr.GetValue(dr.GetOrdinal("De")))
                        '    .To.Add(dr.GetValue(dr.GetOrdinal("Para")))
                        '    .CC.Add(dr.GetValue(dr.GetOrdinal("De")))
                        '    .Subject = dr.GetValue(dr.GetOrdinal("Asunto"))
                        '    .Body = dr.GetValue(dr.GetOrdinal("Mensaje"))
                        '    .IsBodyHtml = True
                        '    .Priority = MailPriority.High

                        'End With

                        Try
                            SmtpMail.Send(email)
                            'client.Send(email)
                            wStsEnvio = True
                            'email.Dispose()

                        Catch ehttp As System.Web.HttpException
                            wStsEnvio = False
                            lblmsg.Text = lblmsg.Text & " NroPedido=" & oDataRow.Item(1) & " Error al enviar:" & ehttp.Message & "<br>"

                            ' Mensaje detallado
                            'lblmsg.Text = lblmsg.Text & " NroPedido=" & oDataRow.Item(1) & " Error al enviar e-mail:" & ehttp.ToString() & "<br>"
                        End Try
                    Loop
                    dr.Close()
                Finally
                    cn.Close()
                End Try

                'Actualiza el estado del e-mail que fue enviado
                If wStsEnvio Then
                    Dim cd1 As New SqlCommand
                    cd1.Connection = cn1
                    cd1.CommandText = "VTA_DEMAIL_U"
                    cd1.CommandType = CommandType.StoredProcedure

                    Dim pa1 As New SqlParameter
                    pa1 = cd1.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                    pa1.Direction = ParameterDirection.Output
                    pa1.Value = ""
                    cd1.Parameters.Add("@FchProceso", SqlDbType.DateTime).Value = wFchProceso
                    cd1.Parameters.Add("@NroPedido", SqlDbType.Int).Value = oDataRow.Item(1)
                    Try
                        cn1.Open()
                        cd1.ExecuteNonQuery()
                    Catch ex1 As System.Data.SqlClient.SqlException
                        lblmsg.Text = lblmsg.Text & " Error :" & ex1.Message & "<br>"
                    Catch ex2 As System.Exception
                        lblmsg.Text = lblmsg.Text & " Error:" & ex2.Message & "<br>"
                    Finally
                        cn1.Close()
                    End Try
                    '    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                End If
            End If
        Next

        'Recargado los pedidos
        CargaPedidos()

    End Sub

End Class
