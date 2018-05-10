Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cppCuadreTC
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            CargaDocumentos()
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub
    Private Sub CargaDocumentos()
        Dim wCodMoneda As String
        If rbsoles.Checked Then
            wCodMoneda = "S"
        ElseIf rbdolar.Checked Then
            wCodMoneda = "D"
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CuadreTC_S"
        da.SelectCommand.Parameters.Add("@FechFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()

        lblmsg.Text = CStr(nReg) + " Pedido(s) Finalizado(s) al " & txtFchEmision.Text
    End Sub
    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Session("CodCliente") = dgLista.Items(dgLista.SelectedIndex).Cells(6).Text
        Response.Redirect("cpcClienteFicha.aspx" & _
                "?CodCliente=" & Session("CodCliente"))
    End Sub

    Private Sub dgLista_ItemDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            ElseIf e.Item.Cells(4).Text < 0 Then
                e.Item.Cells(4).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgLista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

End Class
