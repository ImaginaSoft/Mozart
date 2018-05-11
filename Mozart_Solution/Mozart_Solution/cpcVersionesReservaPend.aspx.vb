Imports cmpNegocio
Imports cmpRutinas
Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class cpcVersionesReservaPend
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim objVersion As New clsVersion
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            txtFchInicial.Text = objRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(365)
            CargaProveedor()
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaProveedor()
        Dim ds As New DataSet
        ds = objVersion.ProveedorReservasPendientes(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        ddlProveedor.DataSource = ds
        ddlProveedor.DataBind()
    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarTodos
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        Try
            ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        cargadatos()
    End Sub

    Private Sub cargadatos()
        Dim ds As New DataSet
        If ddlVendedor.SelectedItem.Text.Trim = "Todos" Then
            If ddlProveedor.SelectedItem.Text.Trim = "Todos" Then
                ds = objVersion.ReservasPendientes(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            Else
                ds = objVersion.ReservasPendientes(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlProveedor.SelectedItem.Value)
            End If
        Else
            If ddlProveedor.SelectedItem.Text.Trim = "Todos" Then
                ds = objVersion.ReservasPendientesVend(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlVendedor.SelectedItem.Value)
            Else
                ds = objVersion.ReservasPendientes(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlProveedor.SelectedItem.Value, ddlVendedor.SelectedItem.Value)
            End If
        End If

        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblmsg.CssClass = "msg"
        lblmsg.Text = CStr(dgLista.Items.Count) + " Version(es)"
    End Sub
    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Session("CodCliente") = dgLista.Items(dgLista.SelectedIndex).Cells(14).Text
        Response.Redirect("vtaVersionFicha.aspx" & _
           "?NroPedido=" & dgLista.Items(dgLista.SelectedIndex).Cells(1).Text & _
           "&NroPropuesta=" & dgLista.Items(dgLista.SelectedIndex).Cells(2).Text & _
           "&NroVersion=" & dgLista.Items(dgLista.SelectedIndex).Cells(3).Text)
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.Cells(5).Text.Trim = "Cons" Then
            'e.Item.ForeColor = Color.Red
        ElseIf e.Item.Cells(5).Text.Trim = "Apro" Then
            e.Item.Cells(5).ForeColor = Color.Blue
        ElseIf e.Item.Cells(5).Text.Trim = "Fact" Then
            e.Item.Cells(5).ForeColor = Color.Green
        End If
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        cargadatos()
    End Sub

End Class
