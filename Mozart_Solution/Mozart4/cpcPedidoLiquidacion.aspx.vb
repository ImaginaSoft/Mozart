Imports cmpNegocio
Imports System.Data
Imports System.Drawing

Partial Class cpcPedidoLiquidacion
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim wTotalSum1 As Double = 0
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0
    Dim wComiDescSum As Double = 0
    Dim objPedido As New clsPedido

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodMoneda") = Request.Params("CodMoneda")
            EditaTotal()
            CargaDocumentos()
            CargaPendientesCuadre()

            If IsNumeric(lblTotal.Text) Then
                lblBoleta.Text = CDbl(lblTotal.Text)
                If IsNumeric(lblOtros.Text) Then
                    lblBoleta.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) - CDbl(lblOtros.Text))
                End If
                If IsNumeric(lblComiDesc.Text) Then
                    lblBoleta.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) - CDbl(lblComiDesc.Text))
                End If
                If IsNumeric(lblSinDoc.Text) Then
                    lblBoleta.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) - CDbl(lblSinDoc.Text))
                End If
                If IsNumeric(lblReembo.Text) Then
                    lblBoleta.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) - CDbl(lblReembo.Text))
                End If
                If IsNumeric(lblSeguro.Text) Then
                    lblBoleta.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) + CDbl(lblSeguro.Text))
                End If
                If IsNumeric(lblBoleta.Text) Then
                    lblUtilidad.Text = String.Format("{0:###,###,###,###.00}", CDbl(lblBoleta.Text) - CDbl(lblFactura.Text))
                End If
            End If
            EditaCorrelativo()

            If Viewstate("CodMoneda") = "S" Then
                lblTitMoneda.Text = "Monto S/."
            End If
        End If
    End Sub
    Private Sub EditaCorrelativo()
        Dim iCorrelativo As Integer
        iCorrelativo = objPedido.EditaCorrelativo(Viewstate("NroPedido"))
        If iCorrelativo > 0 Then
            btnEmitirBoleta.Enabled = False
            lblLiqPedido.Visible = False
            cmdLiqPedido.Visible = False

        ElseIf iCorrelativo < 0 Then
            btnEmitirBoleta.Visible = False
            lblLiqPedido.Enabled = False
            cmdLiqPedido.Enabled = False

        ElseIf CDbl(lblBoleta.Text) > 0 Then
            btnEmitirBoleta.Enabled = True
            lblLiqPedido.Visible = False
            cmdLiqPedido.Visible = False
        Else
            cmdLiqPedido.Enabled = True
            btnEmitirBoleta.Enabled = False
        End If
    End Sub
    Private Sub EditaTotal()
        lblTotal.Text = String.Format("{0:###,###,###,###.00}", objPedido.TotalPagoCliente(Viewstate("NroPedido"), Viewstate("CodMoneda")))
        lblReembo.Text = String.Format("{0:###,###,###,###.00}", objPedido.ReembolsoAlCliente(Viewstate("NroPedido"), Viewstate("CodMoneda")))
        lblSeguro.Text = String.Format("{0:###,###,###,###.00}", objPedido.SeguroCancelacionViaje(Viewstate("NroPedido"), Viewstate("CodMoneda")))
    End Sub
    Private Sub CargaDocumentos()
        Dim ds As New DataSet
        ds = objPedido.LiqPedidoDocRevisado(Viewstate("NroPedido"), Viewstate("CodMoneda"))
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgCtaCte.DataSource = dv
        dgCtaCte.DataBind()
        lblmsg.Text = CStr(dgCtaCte.Items.Count) + " Documento(s)"
    End Sub
    Private Sub CargaPendientesCuadre()
        Dim ds As New DataSet
        ds = objPedido.LiqPedidoDocPendCuadre(Viewstate("NroPedido"), Viewstate("CodMoneda"))
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPenCuadre.DataSource = dv
        dgPenCuadre.DataBind()
        lblmsg1.Text = CStr(dgPenCuadre.Items.Count) + " Documento(s) pendientes de cuadre"
    End Sub
    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If IsNumeric(e.Item.Cells(5).Text) Then
            If e.Item.Cells(5).Text > 0 Then
                e.Item.Cells(5).ForeColor = Color.Red
            ElseIf e.Item.Cells(5).Text < 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            End If
        End If
        If IsNumeric(e.Item.Cells(6).Text) Then
            If e.Item.Cells(6).Text > 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            ElseIf e.Item.Cells(6).Text < 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            End If
        End If
    End Sub
    Private Sub dgCtaCte_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCtaCte.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Factura"))
            wTotalSum += wTotal

            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Otros"))
            wUtilidadSum += wUtilidad

            Dim wComiDesc As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComisionDescontada"))
            wComiDescSum += wComiDesc

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = "Total: "
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.00}", wUtilidadSum)
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.00}", wComiDescSum)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right

            lblFactura.Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            lblOtros.Text = String.Format("{0:###,###,###,###.00}", wUtilidadSum)
            lblComiDesc.Text = String.Format("{0:###,###,###,###.00}", wComiDescSum)

            If lblOtros.Text > 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            ElseIf lblOtros.Text < 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            End If
        End If
    End Sub
    Sub ComputeSum1(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotalSum1 += wTotal

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(1).Text = "Total: "
            e.Item.Cells(2).Text = String.Format("{0:###,###,###,###.00}", wTotalSum1)
            e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(2).HorizontalAlign = HorizontalAlign.Right
            lblSinDoc.Text = String.Format("{0:###,###,###,###.00}", wTotalSum1)
            If wTotalSum1 > 0 Then
                e.Item.Cells(2).ForeColor = Color.Red
            ElseIf wTotalSum1 < 0 Then
                e.Item.Cells(1).ForeColor = Color.Blue
            End If
        End If
    End Sub
    Private Sub dgPenCuadre_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPenCuadre.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPendientesCuadre()
    End Sub

    Private Sub dgPenCuadre_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPenCuadre.ItemDataBound
        If IsNumeric(e.Item.Cells(2).Text) Then
            If e.Item.Cells(2).Text > 0 Then
                e.Item.Cells(2).ForeColor = Color.Red
            ElseIf e.Item.Cells(2).Text < 0 Then
                e.Item.Cells(2).ForeColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub dgPenCuadre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPenCuadre.SelectedIndexChanged
        Response.Redirect("cppCuadreObligaciones.aspx" & _
                    "?CodProveedor=" & dgPenCuadre.Items(dgPenCuadre.SelectedIndex).Cells(4).Text & _
                    "&NroPedido=" & Viewstate("NroPedido") & _
                    "&CodMoneda=" & Viewstate("CodMoneda") & _
                    "&NomCliente=" & ucPedido1.NomCliente & _
                    "&Opcion=" & "Cuadre")
    End Sub

    Private Sub btnEmitirBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmitirBoleta.Click
        If lblBoleta.Text.Trim.Length = 0 Then
            lblError.Text = "No se puede emitir comprobante de ventas sin monto"
            lblError.Visible = True
            Return
        ElseIf CDbl(lblBoleta.Text.Trim) = 0 Then
            lblError.Text = "No se puede emitir comprobante de ventas sin monto"
            lblError.Visible = True
            Return
        ElseIf CDbl(lblBoleta.Text.Trim) < 0 Then
            lblError.Text = "No se puede emitir comprobante de ventas con monto negativo"
            lblError.Visible = True
            Return
        End If
        Response.Redirect("cpcPedidoLiquidacionBoleta.aspx" & _
          "?CodCliente=" & ucPedido1.CodCliente() & _
          "&NroPedido=" & Viewstate("NroPedido") & _
          "&CodMoneda=" & Viewstate("CodMoneda") & _
          "&Opcion=" & "Directo" & _
          "&Total=" & lblBoleta.Text)
    End Sub

    Private Sub cmdLiqPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiqPedido.Click
        lblError.Text = objPedido.LiqPedidoSinBoleta(Viewstate("NroPedido"), Session("CodUsuario"))
        If lblError.Text.Trim = "OK" Then
            Response.Redirect("cpcPedidoTerminado.aspx")
        Else
            lblError.Visible = True
        End If
    End Sub



End Class
