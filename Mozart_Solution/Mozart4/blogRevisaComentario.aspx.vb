Imports System.Web.Mail
Imports cmpNegocio
Imports cmpTabla
Imports cmpBlog
Imports System.Data
Imports System.Drawing

Partial Class blogRevisaComentario
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Dim objComentario As New clsComentario
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaVendedor()
            txtFchInicial.Text = objRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        Try
            ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
        Catch ex As Exception
            ddlVendedor.Items.FindByValue("Todos").Selected = True
        End Try
    End Sub

    Private Sub CargaPedidos()
        lblaviso.Visible = False
        btnGrabar.Visible = False

        Dim ds As New DataSet
        If rbtTodos.Checked Then
            If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                ds = objComentario.CargaComentario(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
            Else
                ds = objComentario.CargaComentario(ddlVendedor.SelectedItem.Value, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
            End If
        Else
            'solo pendientes
            If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                ds = objComentario.ComentarioPendiente("P", objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
            Else
                ds = objComentario.ComentarioPendiente(ddlVendedor.SelectedItem.Value, "P", objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
            End If
        End If

        'dgPedidos.DataKeyField = "KeyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()
        lblmsg.Text = CStr(dgPedidos.Rows.Count) + " Comentario(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub InitializeComponent()

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim wCheck As Boolean
        wCheck = False
        Dim sClienteRecibeComentario As String
        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgPedidos.Rows.Count - 1
            Dim cb As CheckBox = CType(dgPedidos.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                lblmsg.Text = ""
                wCheck = True
                Try
                    objComentario.NroPedido = Mid(dgPedidos.DataKeys(index).Value, 1, 10)
                    objComentario.NroExp = Mid(dgPedidos.DataKeys(index).Value, 11, 5)
                    objComentario.NroComentario = Mid(dgPedidos.DataKeys(index).Value, 16, 5)
                    sClienteRecibeComentario = Mid(dgPedidos.DataKeys(index).Value, 21, 2)
                    objComentario.CodUsuario = Session("CodUsuario")
                    lblmsg.Text = objComentario.ActualizaFlagRevisado
                    If lblmsg.Text.Trim = "OK" And sClienteRecibeComentario = "SI" Then
                        'Proceso para enviar e-mail
                        lblmsg.Text = objComentario.DatosParaEmail
                        If lblmsg.Text.Trim = "OK" Then
                            'Dim email As New MailMessage
                            'With email
                            '    .From = objComentario.EmailOrigen
                            '    .To = objComentario.EmailCliente
                            '    .CC = ""
                            '    .Subject = objComentario.Asunto
                            '    .Body = objComentario.Detalle
                            '    .BodyFormat = MailFormat.Html
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", System.Configuration.ConfigurationSettings.AppSettings("ServidorEmail")) 'smtp Server Address
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", System.Configuration.ConfigurationSettings.AppSettings("port"))
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 to send using SMTP over the network
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1) '1 = basic authentication
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationSettings.AppSettings("sendusername"))
                            '    .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationSettings.AppSettings("sendpassword"))
                            '    ' .Priority = MailPriority.High
                            'End With
                            'SmtpMail.Send(email)

                            Dim objEmail As New cmpNegocio.clsEmailSendGrid
                            Dim rpta As String = objEmail.EnviarCorreo("Pentagrama", objComentario.EmailOrigen, objComentario.EmailCliente, objComentario.Asunto, objComentario.Detalle, Nothing)


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

                            '    .From = New MailAddress(objComentario.EmailOrigen, objComentario.EmailOrigen)
                            '    .To.Add(objComentario.EmailCliente)
                            '    .CC.Add("")
                            '    .Subject = objComentario.Asunto
                            '    .Body = objComentario.Detalle
                            '    .IsBodyHtml = True
                            '    .Priority = MailPriority.High

                            'End With

                            'client.Send(email)
                            'email.Dispose()

                        End If

                    End If

                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                    Return
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                    Return
                End Try
            Else
                'NO MARCADO
                'objComentario.NroPedido = Mid(MiSeleccion.PrimaryKey.ToString, 1, 10)
            End If
        Next

        'Recarga comentarios con los nuevos estados
        If wCheck And lblmsg.Text.Trim = "OK" Then
            CargaPedidos()
        End If
    End Sub

    Protected Sub dgPedidos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPedidos.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgPedidos.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgPedidos.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next

        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"



    End Sub

    Protected Sub dgPedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgPedidos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Trim(e.Row.Cells(5).Text) = "Pend" Then
                e.Row.Cells(5).ForeColor = Color.Red
                lblaviso.Visible = True
                btnGrabar.Visible = True
            Else
                e.Row.Cells(0).Text = ""
            End If
        End If
    End Sub

    Protected Sub dgPedidos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgPedidos.RowDeleting

        objComentario.NroPedido = Mid(dgPedidos.DataKeys(e.RowIndex).Value, 1, 10)
        objComentario.NroExp = Mid(dgPedidos.DataKeys(e.RowIndex).Value, 11, 5)
        objComentario.NroComentario = Mid(dgPedidos.DataKeys(e.RowIndex).Value, 16, 5)
        lblmsg.Text = objComentario.Borrar
        If lblmsg.Text.Trim = "OK" Then
            CargaPedidos()
        End If
    End Sub

    Protected Sub dgPedidos_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgPedidos.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub
End Class
