Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybDocumentoBancos
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Fecha") = Request.Params("Fecha")

            If Len(Trim(Viewstate("Fecha"))) > 0 Then
                txtFchEmision.Text = Viewstate("Fecha")
                CargaGrilla(ObjRutina.fechayyyymmdd(txtFchEmision.Text))
            Else
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            End If
        End If
    End Sub

    Private Sub CargaGrilla(ByVal cfecha As String)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet
        'Envia Data
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CYB_MovtosDBancos_S"
        da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = cfecha
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgDBancos.DataSource = ds.Tables("Documentos")
        dgDBancos.DataBind()
        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub dgDBancos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDBancos.ItemDataBound
        If Trim(e.Item.Cells(9).Text) = "Anul" Then
            e.Item.ForeColor = Color.DarkGray
        ElseIf IsNumeric(e.Item.Cells(8).Text) Then
            If e.Item.Cells(8).Text > 0 Then
                e.Item.Cells(8).ForeColor = Color.Blue
            Else
                e.Item.Cells(8).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaGrilla(ObjRutina.fechayyyymmdd(txtFchEmision.Text))
    End Sub


    Private Sub dgDBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDBancos.SelectedIndexChanged
        Response.Redirect("cybDBancosDetalle.aspx" & _
                  "?TipoDocumento=" & dgDBancos.Items(dgDBancos.SelectedIndex).Cells(2).Text & _
                  "&NroDocumento=" & dgDBancos.Items(dgDBancos.SelectedIndex).Cells(3).Text & _
                  "&TipoDocumento2=" & dgDBancos.Items(dgDBancos.SelectedIndex).Cells(13).Text & _
                  "&NroDocumento2=" & dgDBancos.Items(dgDBancos.SelectedIndex).Cells(14).Text)
    End Sub


End Class
