Imports cmpNegocio
Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class EstFactTrimVen
    Inherits System.Web.UI.Page
    Dim objPeriodoVta As New clsPeriodoVta
    Private dv As DataView
    Dim tVta As Double = 0
    Dim tUti As Double = 0
    Dim tAsig As Double = 0
    Dim tFact As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaAno()
        End If
    End Sub

    Private Sub CargaAno()
        Dim objAnoProceso As New clsAnoProceso
        Dim ds As New DataSet
        'ds = objAnoProceso.Cargar()
        ds = objAnoProceso.Consulta()
        ddlAno.DataSource = ds
        ddlAno.DataBind()
        Try
            ddlAno.Items.FindByValue(Year(DateTime.Now)).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Dim objPedido As New clsPedido
        Dim ds As DataSet
        If ddlTrim.SelectedValue = "T" Then
            ds = objPedido.VentaAnualxVen(ddlAno.SelectedValue, ddlIdioma.SelectedValue)
        Else
            ds = objPedido.VentaTrimestrexVen(ddlAno.SelectedValue, ddlTrim.SelectedValue, ddlIdioma.SelectedValue)
        End If

        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
    End Sub


    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim RowVta As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Venta"))
            tVta = tVta + RowVta

            Dim RowUti As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Utilidad"))
            tUti = tUti + RowUti

            Dim RowAsig As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PedidoAsig"))
            tAsig = tAsig + RowAsig

            Dim RowFact As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PedidoFact"))
            tFact = tFact + RowFact

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = String.Format("{0:###,###,###}", tVta)
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(5).Text = String.Format("{0:###,###,###}", tUti)
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right

            If tVta > 0 Then
                e.Row.Cells(6).Text = String.Format("{0:###,###.##}", tUti * 100 / tVta)
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            End If

            e.Row.Cells(7).Text = String.Format("{0:###,###,###}", tAsig.ToString())
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(8).Text = String.Format("{0:###,###,###}", tFact.ToString())
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Center

            If tAsig > 0 Then
                e.Row.Cells(9).Text = String.Format("{0:###,###.##}", tFact * 100 / tAsig)
                e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            End If

        End If
    End Sub

End Class
