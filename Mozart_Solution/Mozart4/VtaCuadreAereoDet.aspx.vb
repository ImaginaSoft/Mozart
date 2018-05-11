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

Partial Class VtaCuadreAereoDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Dim wTotalFact As Double = 0
    Dim wTotalRemision As Double = 0
    Dim wTotalBoleto As Double = 0
    Dim wTotalCupon As Double = 0
    Dim wTotalAjuste As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblTitulo.Text = "Detalle Cuadre Aéreo Versión N° " & Request.Params("NroPedido") & "-" & Request.Params("NroVersion")
            CargaVersion()
            CargaRemision()
            CargaBoleto()
            CargaStockComprados()
            CargaAjuste()
        End If
    End Sub
    Private Sub CargaVersion()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereoVersion_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "DVERSION")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgVersiones.DataSource = dv
        dgVersiones.DataBind()
    End Sub

    Private Sub CargaRemision()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereoRemision_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "REMISION")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgRemision.DataSource = dv
        dgRemision.DataBind()
    End Sub

    Private Sub CargaBoleto()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereoBoleto_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "BOLETO")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()
    End Sub

    Private Sub CargaStockComprados()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereoStockComprados_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "STOCK")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgStockComprados.DataSource = dv
        dgStockComprados.DataBind()
    End Sub


    Private Sub CargaAjuste()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereoAjuste_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "DPROVEEDOR")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgAjuste.DataSource = dv
        dgAjuste.DataBind()
    End Sub


    Sub ComputeSumVersion(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioFact"))
            wTotalFact += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            '            e.Item.Cells(3).Text = "Total: "
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotalFact)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Sub ComputeSumRemision(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "MontoRemision"))
            wTotalRemision += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotalRemision)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Sub ComputeSumBoleto(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioBoleto"))
            wTotalBoleto += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.00}", wTotalBoleto)
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Sub ComputeSumCupon(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioBoleto"))
            wTotalCupon += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.00}", wTotalCupon)
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub


    Sub ComputeSumAjuste(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Ajuste"))
            wTotalAjuste += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotalAjuste)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right

            If e.Item.Cells(4).Text >= 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If

            Dim wdiferencia As Double = wTotalFact - wTotalRemision - (wTotalBoleto - wTotalCupon)
            lblDiferencia.Text = "El Ajuste debe ser por &nbsp;&nbsp;"
            lblDiferencia.Text = lblDiferencia.Text & String.Format("{0:###,###,###,###.00}", wTotalFact) & "&nbsp;-&nbsp;" & String.Format("{0:###,###,###,###.00}", wTotalRemision) & "&nbsp;-&nbsp;" & String.Format("{0:###,###,###,###.00}", wTotalBoleto) & "&nbsp;+&nbsp;" & String.Format("{0:###,###,###,###.00}", wTotalCupon) & "&nbsp; = &nbsp;"
            lblDiferencia.Text = lblDiferencia.Text & String.Format("{0:###,###,###,###.00}", wdiferencia)
            If wdiferencia >= 0 Then
                lblDiferencia.ForeColor = Color.Blue
            Else
                lblDiferencia.ForeColor = Color.Red
            End If
        End If
    End Sub


    Private Sub dgAjuste_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgAjuste.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text >= 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If
        End If
    End Sub


End Class
