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

Partial Class bolCuadreRemisionBoleto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Dim dTotPago As Double = 0
    Dim dTotMonto As Double = 0
    Dim dTotProv As Double = 0
    Dim dTotDife As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            If Request.Params("NroPedido") = 0 Then
                lblTitulo.Text = "Detalle Cuadre Reembolso N° " & Request.Params("NroReembolso")
                dgBoleto.Columns(4).HeaderText = "Fecha Reembolso"
                dgBoleto.Columns(5).HeaderText = "Monto Reembolso"
            Else
                lblTitulo.Text = "Detalle Cuadre Remisión N° " & Request.Params("NroReembolso")
                dgBoleto.Columns(4).HeaderText = "Fecha Remisión"
                dgBoleto.Columns(5).HeaderText = "Monto Remisión"
            End If
            CargaBoleto()
        End If
    End Sub

    Private Sub CargaBoleto()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Request.Params("NroPedido") = 0 Then
            da.SelectCommand.CommandText = "BOL_CuadreRemisionDet2_S"
            da.SelectCommand.Parameters.Add("@NroReembolso", SqlDbType.Char, 15).Value = Request.Params("NroReembolso")
        Else
            da.SelectCommand.CommandText = "BOL_CuadreRemisionDet1_S"
            da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
            da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
            da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")
        End If

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "BOLETO")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()
    End Sub


    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dPago As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PagoBoleto"))
            Dim dmonto As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "MontoRemision"))
            Dim dProv As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Provision"))
            Dim dDife As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Diferencia"))
            dTotPago += dPago
            dTotMonto += dmonto
            dTotProv += dProv
            dTotDife += dDife
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(3).Text = String.Format("{0:###,###,###,###.00}", dTotPago)
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.00}", dTotMonto)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.00}", dTotProv)
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.00}", dTotDife)
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right

            If dTotDife >= 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If

        End If
    End Sub

    Private Sub dgBoleto_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgBoleto.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(7).Text >= 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If

    End Sub

End Class
