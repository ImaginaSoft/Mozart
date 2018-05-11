Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpNegocio
Imports System.Drawing

Partial Class VtaPedidoFicha
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Autorizacion()
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            CargaDatos()
            lblTitulo.Text = "Ficha del Pedido Nro. " & Request.Params("NroPedido")
        End If
    End Sub

    Private Sub Autorizacion()
        If Session("MenuPedido") = "X" Then
            lbtAnulaFactPedido.Visible = True
            lbtAnulaFactMes.Visible = True
            lbtAnulaFactVersion.Visible = True
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaNroPedido_S", New SqlParameter("@NroPedido", Viewstate("NroPedido")))
        dgPropuesta.DataKeyField = "NroPropuesta"
        dgPropuesta.DataSource = ds.Tables(0)
        dgPropuesta.DataBind()

        lblMsg.Text = CStr(dgPropuesta.Items.Count) + " Propuesta(s)"
    End Sub

    Private Sub dgPropuesta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPropuesta.SelectedIndexChanged
        Response.Redirect("VtaPropuestaFicha.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & dgPropuesta.Items(dgPropuesta.SelectedIndex).Cells(1).Text)
    End Sub

    Private Sub lbtPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPropuesta.Click
        Response.Redirect("VtaPropuestaNueva.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtDesdePlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDesdePlantilla.Click
        Response.Redirect("VtaPropuestaPlantilla.aspx" & _
                                    "?NroPedido=" & Viewstate("NroPedido") & _
                                    "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtDesdePropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDesdePropuesta.Click
        Response.Redirect("VtaPropuestaPropuesta.aspx" & _
                                    "?NroPedido=" & Viewstate("NroPedido") & _
                                    "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModifica.Click
        Response.Redirect("VtaPedido.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        Dim objPedido As New cmpNegocio.clsPedido
        lblMsg.Text = objPedido.Borrar(Viewstate("NroPedido"))
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("cpcClienteFicha.aspx" & _
                    "?CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Private Sub lbtHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistorial.Click
        Response.Redirect("VtaPedidoHistorial.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtEnviaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEnviaEmail.Click
        Response.Redirect("VtaPedidoEmail.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente") & _
                   "&Idioma=" & ucPedido1.Idioma)
    End Sub

    Private Sub lbtTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTareas.Click
        Response.Redirect("VtaPedidoTareas.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtPasajero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPasajero.Click
        Response.Redirect("VtaPedidoPasajero.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido"))
    End Sub

    Private Sub lbtHistProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistProveedor.Click
        Response.Redirect("VtaPedidoHistProveedor.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente") & _
                   "&Opcion=1")
    End Sub

    Private Sub Linkbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("VtaPedidoHistProveedor.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFinalizar.Click
        Response.Redirect("VtaPedidoFinalizar.aspx" & _
                   "?NroPedido=" & Viewstate("NroPedido") & _
                   "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtAnulaFactPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAnulaFactPedido.Click
        Response.Redirect("VtaPedidoAnulaFact.aspx" & _
                  "?NroPedido=" & Viewstate("NroPedido") & _
                  "&Opcion=A" & _
                  "&StsPedido=" & ucPedido1.StsPedido & _
                  "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtAnulaFactVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAnulaFactVersion.Click
        Response.Redirect("vtaPedidoAnulaFactVersion.aspx" & _
                  "?NroPedido=" & Viewstate("NroPedido") & _
                  "&Opcion=" & "V" & _
                  "&StsPedido=" & ucPedido1.StsPedido & _
                  "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtConsultaPenalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtConsultaPenalidad.Click
        Response.Redirect("VtaPedidoAnulaFact.aspx" & _
          "?NroPedido=" & Viewstate("NroPedido") & _
          "&Opcion=C" & _
          "&StsPedido=" & ucPedido1.StsPedido & _
          "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtLiqPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLiqPedido.Click
        Response.Redirect("cpcPedidoLiquidacion.aspx" & _
                  "?NroPedido=" & Viewstate("NroPedido") & _
                  "&CodMoneda=" & "D")
    End Sub

    Private Sub lbtAnulaFactMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAnulaFactMes.Click
        Response.Redirect("vtaPedidoAnulaFactVersion.aspx" & _
          "?NroPedido=" & Viewstate("NroPedido") & _
          "&Opcion=" & "M" & _
          "&StsPedido=" & ucPedido1.StsPedido & _
          "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub dgPropuesta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPropuesta.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(12).Text.Trim = "Q" Then
                e.Item.ForeColor = Color.DarkGray
            Else
                e.Item.Cells(4).ForeColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub lbtCierreVersionFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCierreVersionFact.Click
        Response.Redirect("VtaPedidoCierrePeriodo.aspx?&NroPedido=" & Viewstate("NroPedido"))
    End Sub

End Class
