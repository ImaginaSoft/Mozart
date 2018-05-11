Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class bolReporteFact
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
            CargaDocumentos()
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub

    Private Sub CargaDocumentos()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_ReporteFact_S"
        da.SelectCommand.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgReporte.DataSource = ds.Tables("Documentos")
        dgReporte.DataBind()
        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub dgReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgReporte.SelectedIndexChanged
        Response.Redirect("bolBoletosFact.aspx" & _
        "?TipoDocumento=" & dgReporte.Items(dgReporte.SelectedIndex).Cells(2).Text & _
        "&NroDocumento=" & dgReporte.Items(dgReporte.SelectedIndex).Cells(3).Text)
    End Sub

    Private Sub dgReporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgReporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            If Trim(e.Item.Cells(7).Text) = "Anulado" Then
                e.Item.ForeColor = Color.DarkGray
            End If

            If e.Item.Cells(2).Text.Trim = "RE" Then
                e.Item.Cells(5).ForeColor = Color.Red
            Else
                e.Item.Cells(5).ForeColor = Color.Blue
            End If

        End If

    End Sub

End Class
