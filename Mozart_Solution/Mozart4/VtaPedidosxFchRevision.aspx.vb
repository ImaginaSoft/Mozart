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

Imports cmpSeguridad
Imports cmpTabla

Partial Class VtaPedidosxFchRevision
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaVendedor()

            ddlEstadoPedido.Items.Insert(0, New ListItem("Todos"))
            ddlEstadoPedido.Items.Insert(1, New ListItem("Solicitado"))
            ddlEstadoPedido.Items.Insert(2, New ListItem("Negociación"))
            ddlEstadoPedido.Items.Insert(3, New ListItem("Vendido"))
            ddlEstadoPedido.Items.Insert(4, New ListItem("Cerrado"))
            ddlEstadoPedido.Items.Insert(5, New ListItem("Anulado"))
            ddlEstadoPedido.Items.FindByValue("Negociación").Selected = True
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-60)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
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
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        If ddlVendedor.SelectedItem.Value.Trim = "Todos" And ddlEstadoPedido.SelectedItem.Value.Trim = "Todos" Then
            da.SelectCommand.CommandText = "VTA_CronoRevision_S"

        ElseIf ddlVendedor.SelectedItem.Value.Trim = "Todos" And ddlEstadoPedido.SelectedItem.Value.Trim <> "Todos" Then
            da.SelectCommand.CommandText = "VTA_CronoRevisionSts_S"
            da.SelectCommand.Parameters.Add("@StsPedido", SqlDbType.Char, 1).Value = Mid(ddlEstadoPedido.SelectedItem.Value, 1, 1)

        ElseIf ddlVendedor.SelectedItem.Value.Trim <> "Todos" And ddlEstadoPedido.SelectedItem.Value.Trim = "Todos" Then
            da.SelectCommand.CommandText = "VTA_CronoRevisionVen_S"
            da.SelectCommand.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value
        Else
            da.SelectCommand.CommandText = "VTA_CronoRevisionVenSts_S"
            da.SelectCommand.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value
            da.SelectCommand.Parameters.Add("@StsPedido", SqlDbType.Char, 1).Value = Mid(ddlEstadoPedido.SelectedItem.Value, 1, 1)
        End If
        da.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchFinal.Text)

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Campo")
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()

        lblmsg.Text = CStr(nReg) + " Pedido(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPedidos.SortCommand
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub
    Private Sub dgPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPedidos.SelectedIndexChanged
        'Elige el cliente
        Session("CodCliente") = dgPedidos.Items(dgPedidos.SelectedIndex).Cells(13).Text

        Response.Redirect("VtaPedidoFicha.aspx" & _
                          "?NroPedido=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(11).Text & _
                         "&CodCliente=" & dgPedidos.Items(dgPedidos.SelectedIndex).Cells(13).Text)
    End Sub

    Private Sub dgPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedidos.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Trim(e.Item.Cells(12).Text) = "N" Then
                ' e.Item.ForeColor = Color.DarkGray
            ElseIf e.Item.Cells(12).Text.Trim = "M" Then
                e.Item.ForeColor = Color.Green
            ElseIf e.Item.Cells(12).Text.Trim = "I" Then
                e.Item.ForeColor = Color.DarkBlue
            ElseIf e.Item.Cells(12).Text.Trim = "S" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub ddlEstadoPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEstadoPedido.SelectedIndexChanged
        CargaPedidos()
    End Sub


End Class
