Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class VtaPedidoCierrePeriodo
    Inherits System.Web.UI.Page
    Dim wTotalSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            CargaDocumentos()
        End If
    End Sub

    Private Sub CargaDocumentos()
        Dim objPedido As New clsPedido

        Dim ds As New DataSet
        ds = objPedido.CargarCierrePeriodoVentas(Viewstate("NroPedido"))
        dgLista.DataSource = ds
        dgLista.DataBind()
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text >= 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If
        End If
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Utilidad"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            If wTotalSum >= 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If
            e.Item.Cells(4).Text = "Total: " & String.Format("{0:###,###,###,###.##}", wTotalSum)
        End If
    End Sub


End Class
