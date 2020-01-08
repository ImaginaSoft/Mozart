Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Web.Mail
Imports System.Data.SqlClient

Partial Class tabRecordatorioDet
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Recordatorio Nro " & Request.Params("NroRecordatorio")
            If Request.Params("Idioma") = "I" Then
                lblTitulo.Text = lblTitulo.Text & Request.Params("CodZonaVta") & " (en Ingles)"
            Else
                lblTitulo.Text = lblTitulo.Text & Request.Params("CodZonaVta") & " (en Español)"
            End If

            Viewstate("CodZonaVta") = Request.Params("CodZonaVta")
            Viewstate("Idioma") = Request.Params("Idioma")
            Viewstate("NroRecordatorio") = Request.Params("NroRecordatorio")
            LeeRecordatorio()
        End If
        'With cmdSend
        '.Attributes.Add("onClick", "getHTML()")
        'End With
    End Sub
    Private Sub LeeRecordatorio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_RecordatorioDet_S"
        da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = Viewstate("CodZonaVta")
        da.SelectCommand.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = Viewstate("Idioma")
        da.SelectCommand.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = Viewstate("NroRecordatorio")
        dsEdit.Clear()
        da.Fill(dsEdit, "TRECORDATORIO")
        FreeTextBox1.DataBind()
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        lblmsg.Text = ""

        

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_RecordatorioDet_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = Viewstate("CodZonaVta")
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = Viewstate("Idioma")
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = Viewstate("NroRecordatorio")
        cd.Parameters.Add("@Recordatorio", SqlDbType.Text).Value = FreeTextBox1.Text
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
            Response.Redirect("TabRecordatorio.aspx")
        End If
    End Sub

    Private Sub cmdPrueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrueba.Click
        Response.Redirect("TabRecordatorioPrueba.aspx" & _
                "?CodZonaVta=" & Viewstate("CodZonaVta") & _
                "&Idioma=" & Viewstate("Idioma") & _
                "&NroRecordatorio=" & Viewstate("NroRecordatorio"))
    End Sub


End Class
