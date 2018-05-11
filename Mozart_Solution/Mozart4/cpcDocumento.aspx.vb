Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class cpcDocumento
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(-366)
            CargaDocumentos()
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub

    Private Sub CargaDocumentos()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodCliente", SqlDbType.Int)
        arParms(0).Value = Viewstate("CodCliente")
        arParms(1) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(1).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_MovtosxCliente_S", arParms)
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()

        lblmsg.Text = CStr(dgDocumento.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        Response.Redirect("cpcDocumentoDet.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&Nombre=" & ucCliente1.Nombre & _
        "&TipoDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(2).Text & _
        "&NroDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(3).Text & _
        "&Tabla=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(14).Text & _
        "&TipoOperacion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(15).Text & _
        "&NroPedido=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(4).Text & _
        "&NroPropuesta=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(16).Text & _
        "&NroVersion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(17).Text & _
        "&Origen=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(18).Text)
    End Sub

    Private Sub dgDocumento_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento.ItemDataBound
        If Trim(e.Item.Cells(8).Text) = "Anul" Then
            e.Item.ForeColor = Color.DarkGray
        ElseIf IsNumeric(e.Item.Cells(6).Text) Then
            If e.Item.Cells(6).Text > 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
            End If

            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            ElseIf e.Item.Cells(7).Text < 0 Then
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgDocumento_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgDocumento.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub
End Class
