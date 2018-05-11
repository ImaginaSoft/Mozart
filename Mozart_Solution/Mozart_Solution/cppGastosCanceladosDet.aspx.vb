Imports cmpTabla
Partial Class cppGastosCanceladosDet
    Inherits System.Web.UI.Page
    Dim wTotalSum As Double = 0
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblAno.Text = Request.Params("AnoProceso")
            lblMes.Text = Request.Params("MesProceso")
            lblNomCuenta.Text = Request.Params("CodCuenta") & " " & Request.Params("NomCuenta")
            Carga()
        End If
    End Sub

    Private Sub Carga()
        Dim objCuenta As New clsCuenta
        dgLista.DataSource = objCuenta.CuentaSaldoMes(Request.Params("AnoProceso"), Request.Params("MesProceso"), Request.Params("CodCuenta"))
        dgLista.DataBind()
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TotalD"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(6).Text = "Total: "
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###,###}", wTotalSum)
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

End Class
