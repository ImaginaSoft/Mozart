Imports cmpTabla
Imports cmpSeguridad
Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class VtaPasajeroCumpleanos
    Inherits System.Web.UI.Page
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Try
                ddlMesIni.Items.FindByValue(Month(DateTime.Now)).Selected = True
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub CargaPedidos()
        Dim objPedido As New clsPedido
        Dim ds As New DataSet

        ds = objPedido.CargaPasajeroCumpleanos(ddlMesIni.SelectedItem.Value)
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblmsg.Text = CStr(dgLista.Items.Count) + " Pasajero(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Session("CodCliente") = dgLista.Items(dgLista.SelectedIndex).Cells(12).Text
        Response.Redirect("VtaPedidoFicha.aspx" & _
                  "?NroPedido=" & dgLista.Items(dgLista.SelectedIndex).Cells(11).Text & _
                  "&CodCliente=" & dgLista.Items(dgLista.SelectedIndex).Cells(12).Text)
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(7).Text.Trim = "SI" Then
                e.Item.ForeColor = Color.Blue
            End If
        End If
    End Sub
End Class
