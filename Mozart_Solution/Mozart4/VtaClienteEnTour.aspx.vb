Imports cmpTabla
Imports cmpSeguridad
Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class VtaClienteEnTour
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Dim objVersionDet As New clsVersionDet
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaVendedor()
            txtFchInicial.Text = objRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(1)
        End If
    End Sub


    Private Sub CargaVendedor()
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()

        Dim objUsuario As New clsUsuario
        objUsuario.CodUsuario = Session("CodUsuario")
        objUsuario.Editar()
        If objUsuario.FlagVtaAcceso = "P" Then
            Try
                ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
            Catch ex As Exception
                ddlVendedor.Items.Insert(0, New ListItem("Usuario sin Cod.Vendedor"))
            End Try
            ddlVendedor.Enabled = False
        Else
            ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        End If
    End Sub


    Private Sub CargaPedidos()
        Dim ds As New DataSet
        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            ds = objVersionDet.CargaClienteEnTour(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        Else
            ds = objVersionDet.CargaClienteEnTour(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlVendedor.SelectedValue)
        End If

        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
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
        Session("CodCliente") = dgPedidos.Items(dgPedidos.SelectedIndex).Cells(14).Text
        Response.Redirect("VtaVersionFicha.aspx" & _
                          "?NroPedido=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(11).Text & _
                         "&NroPropuesta=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(12).Text & _
                         "&NroVersion=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(13).Text)
    End Sub

    'Private Sub dgPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedidos.ItemDataBound
    '    If (e.Item.ItemType = ListItemType.Item Or _
    '       e.Item.ItemType = ListItemType.AlternatingItem) Then
    '        If Trim(e.Item.Cells(15).Text) = "N" Then
    '            ' e.Item.ForeColor = Color.DarkGray
    '        ElseIf e.Item.Cells(15).Text.Trim = "M" Then
    '            e.Item.ForeColor = Color.Green
    '        ElseIf e.Item.Cells(15).Text.Trim = "I" Then
    '            e.Item.ForeColor = Color.DarkBlue
    '        ElseIf e.Item.Cells(15).Text.Trim = "S" Then
    '            e.Item.ForeColor = Color.Red
    '        End If
    '    End If
    'End Sub

    Private Sub ddlEstadoPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaPedidos()
    End Sub

End Class
