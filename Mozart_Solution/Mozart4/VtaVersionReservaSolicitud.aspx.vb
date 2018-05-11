Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Web.Mail
Imports System.Data.SqlClient

Partial Class VtaVersionReservaSolicitud
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Solicitud al Proveedor " & Request.Params("NomProveedor")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodContacto") = Request.Params("CodContacto")

            CargaSolicita()
            LeeVersion()
            LeeVersionServicios()
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
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        da.SelectCommand.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = Viewstate("CodContacto")
        Dim ds As New DataSet
        da.Fill(ds, "Contacto")
        ddlContacto.DataSource = ds.Tables("Contacto")
        ddlContacto.DataBind()
        If ddlContacto.Items.Count > 0 Then
            If Len(Trim(Viewstate("CodContacto"))) > 0 Then
                ddlContacto.Items.FindByValue(Viewstate("CodContacto")).Selected = True
            End If
            AsignaEmailContacto()
        End If
    End Sub

    Private Sub CargaSolicita()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_Solicita_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Solicita")
        ddlSolicita.DataSource = ds.Tables("Solicita")
        ddlSolicita.DataBind()
    End Sub


    Private Sub AsignaEmailContacto()
        txtPara.Text = ""

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "OPE_LeeContacto_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
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

    Private Sub LeeVersion()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_VersionNroVersion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ViewState("Pax") = dr.GetValue(dr.GetOrdinal("NomCliente")) & " x " & _
                               CStr(dr.GetValue(dr.GetOrdinal("CantAdultos")) + _
                                    dr.GetValue(dr.GetOrdinal("CantNinos")))
                If ddlSolicita.Items.Count > 0 Then
                    txtAsunto.Text = ddlSolicita.SelectedItem.Text.Trim & " " & CStr(ViewState("Pax"))
                End If

                txtDe.Text = dr.GetValue(dr.GetOrdinal("EmailVendedorOpe"))
                'txtCC.Text = dr.GetValue(dr.GetOrdinal("EmailVendedor"))
                ViewState("CodCliente") = dr.GetValue(dr.GetOrdinal("CodCliente"))
            Loop
            dr.Close()
        Catch ex As Exception
            lblmsg.Text = ex.Message
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub LeeVersionServicios()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        da.SelectCommand.CommandText = "VTA_VersionReserva_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")

        If ddlSolicita.Items.Count = 0 Then
            da.SelectCommand.Parameters.Add("@NomSolicita", SqlDbType.VarChar, 50).Value = ""
        Else
            da.SelectCommand.Parameters.Add("@NomSolicita", SqlDbType.VarChar, 50).Value = ddlSolicita.SelectedItem.Text
        End If

        dsEdit.Clear()
        da.Fill(dsEdit, "DLOGPROVEEDOR")
        txtRTB.DataBind()
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
        cd.CommandText = "VTA_VersionReserva_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = txtRTB.Text
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = ddlContacto.SelectedItem.Value
        cd.Parameters.Add("@CodSolicita", SqlDbType.Char, 1).Value = ddlSolicita.SelectedItem.Value
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
            Dim email As New MailMessage
            With email
                .From = txtDe.Text
                .To = txtPara.Text
                .Cc = txtCC.Text
                .Subject = txtAsunto.Text
                .Body = txtRTB.Text
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

            Response.Redirect("VtaVersionReserva.aspx" & _
                       "?NroPedido=" & Viewstate("NroPedido") & _
                       "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                       "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

    Private Sub ddlContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlContacto.SelectedIndexChanged
        AsignaEmailContacto()
    End Sub

    Private Sub ddlSolicita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSolicita.SelectedIndexChanged
        txtAsunto.Text = ddlSolicita.SelectedItem.Text.Trim & ": " & Viewstate("Pax")
        LeeVersionServicios()
    End Sub


End Class
