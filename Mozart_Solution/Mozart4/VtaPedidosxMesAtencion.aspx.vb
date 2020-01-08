Imports cmpTabla
Imports cmpSeguridad
Imports cmpNegocio
Imports System.Data

Partial Class VtaPedidosxMesAtencion
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

            Try
                ddlMesFin.Items.FindByValue(Month(DateAdd("m", 2, Today))).Selected = True
            Catch ex As Exception
            End Try


            CargaZonaVta()
            CargaAno()
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim objZonaVta As New clsZonaVta
        Dim ds As New DataSet
        ds = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()
    End Sub

    Private Sub CargaAno()
        Dim objAnoProceso As New clsAnoProceso
        Dim ds As New DataSet
        ds = objAnoProceso.Cargar()
        ddlAnoIni.DataSource = ds
        ddlAnoIni.DataBind()
        Try
            ddlAnoIni.Items.FindByValue(Year(DateTime.Now)).Selected = True
        Catch ex As Exception
        End Try

        ddlAnoFin.DataSource = ds
        ddlAnoFin.DataBind()
        Try
            ddlAnoFin.Items.FindByValue(Year(DateAdd("m", 2, Today))).Selected = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo()
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
        Dim objPedido As New clsPedido
        Dim ds As New DataSet

        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            ds = objPedido.CargarAtencion(ddlZonaVta.SelectedItem.Value, ddlMesIni.SelectedItem.Value, ddlAnoIni.SelectedItem.Value, ddlMesFin.SelectedItem.Value, ddlAnoFin.SelectedItem.Value)
        Else
            ds = objPedido.CargarAtencion(ddlZonaVta.SelectedItem.Value, ddlMesIni.SelectedItem.Value, ddlAnoIni.SelectedItem.Value, ddlMesFin.SelectedItem.Value, ddlAnoFin.SelectedItem.Value, ddlVendedor.SelectedItem.Value)
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblmsg.Text = CStr(dgLista.Items.Count) + " Pedido(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Response.Redirect("VtaPedidoFicha.aspx" & _
                  "?NroPedido=" & dgLista.Items(dgLista.SelectedIndex).Cells(1).Text & _
                  "&CodCliente=" & dgLista.Items(dgLista.SelectedIndex).Cells(9).Text)

    End Sub
End Class
