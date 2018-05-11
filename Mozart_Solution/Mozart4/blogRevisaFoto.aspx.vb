Imports cmpSeguridad
Imports cmpTabla
Imports cmpBlog
Imports System.Data
Imports System.Drawing


Partial Class blogRevisaFoto
    Inherits System.Web.UI.Page

    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Dim objAlbum As New clsAlbum
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaVendedor()
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        Try
            ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
        Catch ex As Exception
            ddlVendedor.Items.FindByValue("Todos").Selected = True
        End Try
    End Sub

    Private Sub CargaPedidos()
        Dim ds As New DataSet
        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            ds = objAlbum.CargaFotos(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
        Else
            ds = objAlbum.CargaFotos(ddlVendedor.SelectedItem.Value, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()
        lblmsg.Text = CStr(dgPedidos.Items.Count) + " Foto(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPedidos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Private Sub dgPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedidos.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Trim(e.Item.Cells(7).Text) = "Pend" Then
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub

End Class
