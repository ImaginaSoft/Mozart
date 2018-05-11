Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports cmpTabla
Imports cmpSeguridad

Partial Class VtaPedidosxVtasMes
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaVendedor()
        End If
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
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            da.SelectCommand.CommandText = "VTA_ProyecVtasMesTodos_S"
            da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta1.CodZonaVta
        Else
            da.SelectCommand.CommandText = "VTA_ProyecVtasMesVendedor_S"
            da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta1.CodZonaVta
            da.SelectCommand.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value
        End If
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Campo")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()

        lblmsg.Text = CStr(nReg) + " Propuesta(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPedidos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPedidos.SelectedIndexChanged
        Session("CodCliente") = dgPedidos.Items(dgPedidos.SelectedIndex).Cells(8).Text
        Response.Redirect("VtaPropuestaFicha.aspx" & _
                          "?NroPedido=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(2).Text & _
                          "&NroPropuesta=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(3).Text)
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Utilidad"))
            wTotalSum += wTotal
            wUtilidadSum += wUtilidad
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = "Total: "
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.00}", wUtilidadSum)
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

End Class
