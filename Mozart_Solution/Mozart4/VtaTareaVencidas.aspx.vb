Imports cmpTabla
Imports System.Data

Partial Class VtaTareaVencidas
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objTarea As New clsTarea
    Private dv As DataView
    Dim wTotalSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-30)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Todos los Vendedores"))
        Try
            ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
        Catch ex As Exception
            ddlVendedor.Items.FindByValue("Todos los Vendedores").Selected = True
        End Try
    End Sub

    Private Sub CargaPedidosxVendedor()
        Dim ds As New DataSet
        If ddlVendedor.SelectedItem.Value = "Todos los Vendedores" Then
            ds = objTarea.CargaTareaVencida(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        Else
            ds = objTarea.CargaTareaVencida(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlVendedor.SelectedItem.Value)
        End If
        dgTareasxPedido.DataKeyField = "NroTarea"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTareasxPedido.DataKeyField = "KeyReg"
        dgTareasxPedido.DataSource = dv
        dgTareasxPedido.DataBind()
        lblMsg.Text = CStr(dgTareasxPedido.Items.Count) + " Pedido(s)"
    End Sub

    Private Sub dgTareasxPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTareasxPedido.SelectedIndexChanged
        Session("CodCliente") = dgTareasxPedido.Items(dgTareasxPedido.SelectedIndex).Cells(8).Text
        Response.Redirect("VtaPedidoTareas.aspx" & _
                                    "?NroPedido=" & dgTareasxPedido.Items(dgTareasxPedido.SelectedIndex).Cells(1).Text)
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidosxVendedor()
    End Sub
    Private Sub dgTareasxPedido_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTareasxPedido.DeleteCommand
        Dim wCodCliente, wNroPedido As Integer
        wCodCliente = Mid(dgTareasxPedido.DataKeys(e.Item.ItemIndex), 1, 8)
        wNroPedido = Mid(dgTareasxPedido.DataKeys(e.Item.ItemIndex), 9, 8)

        Response.Redirect("VtaPedidoFicha.aspx" & _
          "?NroPedido=" & wNroPedido & _
          "&CodCliente=" & wCodCliente)
    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Tareas"))
            wTotalSum += wTotal

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(3).Text = "Total: "
            e.Item.Cells(4).Text = String.Format("{0:###,###,###}", wTotalSum)
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Center
        End If
    End Sub

    Private Sub dgTareasxPedido_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTareasxPedido.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidosxVendedor()
    End Sub



End Class
