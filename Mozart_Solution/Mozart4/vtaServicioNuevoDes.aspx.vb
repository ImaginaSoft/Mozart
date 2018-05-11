Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Web.Mail
Imports System.Data.SqlClient
Imports cmpSeguridad

Partial Class vtaServicioNuevoDes
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim sOpc As String
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT030505") = "X" Then
                cmdGrabar.Visible = True
            End If



            Viewstate("NroServicio") = Request.Params("NroServicio")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodCiudad") = Request.Params("CodCiudad")
            Viewstate("CodTipoServicio") = Request.Params("CodTipoServicio")
            lblTitulo.Text = Request.Params("NroServicio") + " " + Request.Params("DesProveedor")
            cmdGrabar.Text = "Grabar " & lbtResEspanol.Text
            ViewState("sOpc") = "Res1"
            LeeServicio()
        End If
        '        With cmdGrabar
        '.Attributes.Add("onClick", "getHTML()")
        'End With
    End Sub
    Private Sub LeeServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ViewState("sOpc") = "Det1" Then
            da.SelectCommand.CommandText = "VTA_DesServicioDet_S"
        ElseIf ViewState("sOpc") = "Det2" Then
            da.SelectCommand.CommandText = "VTA_DesServicio2Det_S"
        ElseIf ViewState("sOpc") = "Det3" Then
            da.SelectCommand.CommandText = "VTA_DesServicio3Det_S"
        ElseIf ViewState("sOpc") = "Res1" Then
            da.SelectCommand.CommandText = "VTA_DesServicio_S"
        ElseIf ViewState("sOpc") = "Res2" Then
            da.SelectCommand.CommandText = "VTA_DesServicio2_S"
        ElseIf ViewState("sOpc") = "Res3" Then
            da.SelectCommand.CommandText = "VTA_DesServicio3_S"
        End If
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ViewState("NroServicio")
        'dsEdit.Clear()
        'da.Fill(dsEdit, "Servicio")
        'txtRTB.DataBind()


        dsEdit.Clear()
        da.Fill(dsEdit, "Servicio")
        FreeTextBox1.DataBind()

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblmsg.Text = ""

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandType = CommandType.StoredProcedure

        If ViewState("sOpc") = "Det1" Then
            cd.CommandText = "VTA_DesServicioDet_U"
            cd.Parameters.Add("@DesServicioDet", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Det2" Then
            cd.CommandText = "VTA_DesServicio2Det_U"
            cd.Parameters.Add("@DesServicio2Det", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Det3" Then
            cd.CommandText = "VTA_DesServicio3Det_U"
            cd.Parameters.Add("@DesServicio3Det", SqlDbType.Text).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res1" Then
            cd.CommandText = "VTA_DesServicio_U"
            cd.Parameters.Add("@DesServicio", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res2" Then
            cd.CommandText = "VTA_DesServicio2_U"
            cd.Parameters.Add("@DesServicio2", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        ElseIf ViewState("sOpc") = "Res3" Then
            cd.CommandText = "VTA_DesServicio3_U"
            cd.Parameters.Add("@DesServicio3", SqlDbType.VarChar, 800).Value = FreeTextBox1.Text
        End If

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ViewState("NroServicio")
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
    End Sub


    Private Sub lbtResEspanol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResEspanol.Click
        cmdGrabar.Text = "Grabar " & lbtResEspanol.Text
        ViewState("sOpc") = "Res1"
        LeeServicio()
    End Sub

    Private Sub lbtDetEspanol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetEspanol.Click
        cmdGrabar.Text = "Grabar " & lbtDetEspanol.Text
        ViewState("sOpc") = "Det1"
        LeeServicio()
    End Sub

    Private Sub lbtResIngles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResIngles.Click
        cmdGrabar.Text = "Grabar " & lbtResIngles.Text
        ViewState("sOpc") = "Res2"
        LeeServicio()
    End Sub

    Private Sub lbtDetIngles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetIngles.Click
        cmdGrabar.Text = "Grabar " & lbtDetIngles.Text
        ViewState("sOpc") = "Det2"
        LeeServicio()
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaServicioBusca.aspx" & _
            "?Opcion=" & "NuevoServicio" & _
            "&NroServicio=" & Viewstate("NroServicio") & _
            "&CodProveedor=" & Viewstate("CodProveedor") & _
            "&CodCiudad=" & Viewstate("CodCiudad") & _
            "&CodTipoServicio=" & Viewstate("CodTipoServicio"))
    End Sub


    Protected Sub lbtRes3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtRes3.Click
        cmdGrabar.Text = "Grabar " & lbtResIngles.Text
        ViewState("sOpc") = "Res3"
        LeeServicio()

    End Sub

    Protected Sub lbtDet3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtDet3.Click
        cmdGrabar.Text = "Grabar " & lbtDetIngles.Text
        ViewState("sOpc") = "Det3"
        LeeServicio()
    End Sub
End Class
