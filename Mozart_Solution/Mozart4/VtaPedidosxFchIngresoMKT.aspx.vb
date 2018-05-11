Imports cmpTabla
Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class VtaPedidosxFchIngresoMKT
    Inherits System.Web.UI.Page

    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objZonaVta As New clsZonaVta
    Dim objStsPedido As New clsStsPedido
    Dim objpedido As New clsPedido
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaZonaVta()
            CargaStsPedido()
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-30)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim ds As New DataSet
        ds = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()
    End Sub

    Private Sub CargaStsPedido()
        Dim ds As New DataSet
        ds = objStsPedido.Cargar
        ddlStsPedido.DataSource = ds
        ddlStsPedido.DataBind()
        ddlStsPedido.Items.Insert(0, New ListItem("Todos"))
    End Sub

    Private Sub CargaPedidos()
        Dim ds As New DataSet
        If ddlStsPedido.SelectedItem.Value.Trim = "Todos" Then
            ds = objpedido.CargaxFchIngreso(ddlZonaVta.SelectedValue, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        Else
            ds = objpedido.CargaxFchIngreso(ddlZonaVta.SelectedValue, ddlStsPedido.SelectedValue, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()
        lblmsg.Text = CStr(dgPedidos.Items.Count) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPedidos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPedidos.SelectedIndexChanged
        Session("CodCliente") = dgPedidos.Items(dgPedidos.SelectedIndex).Cells(12).Text

        Response.Redirect("VtaPedidoFicha.aspx" & _
                          "?NroPedido=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(11).Text & _
                         "&CodCliente=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(12).Text)
    End Sub

    Private Sub dgPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedidos.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Trim(e.Item.Cells(13).Text) = "N" Then
                ' e.Item.ForeColor = Color.DarkGray
            ElseIf e.Item.Cells(13).Text.Trim = "M" Then
                e.Item.ForeColor = Color.Green
            ElseIf e.Item.Cells(13).Text.Trim = "I" Then
                e.Item.ForeColor = Color.DarkBlue
            ElseIf e.Item.Cells(13).Text.Trim = "S" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub ddlEstadoPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaPedidos()
    End Sub

End Class
