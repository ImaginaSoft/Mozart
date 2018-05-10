Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cppSaldosProveedor
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim wTotSaldo As Double = 0
    Dim wTotPendi As Double = 0
    Dim wTotalSum As Double = 0
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            txtFecha.Text = ObjRutina.fechaddmmyyyy(0)
        End If
    End Sub
    Private Sub CargaSaldosProveedor()
        Dim wMoneda As String

        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_SaldosProveedor_S"
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        da.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFecha.Text)

        Dim nReg As Integer = da.Fill(ds, "Campo")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgSaldos.DataSource = dv
        dgSaldos.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub
    Private Sub dgSaldos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSaldos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaSaldosProveedor()
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaSaldosProveedor()
    End Sub

    Private Sub dgSaldos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgSaldos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(2).Text > 0 Then
                e.Item.Cells(2).ForeColor = Color.Red
            ElseIf e.Item.Cells(2).Text < 0 Then
                e.Item.Cells(2).ForeColor = Color.Blue
            End If

            If e.Item.Cells(3).Text > 0 Then
                e.Item.Cells(3).ForeColor = Color.Red
            ElseIf e.Item.Cells(3).Text < 0 Then
                e.Item.Cells(3).ForeColor = Color.Blue
            End If

            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Red
            ElseIf e.Item.Cells(4).Text < 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            End If
        End If
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wSaldo As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Saldo"))
            Dim wPendi As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "SaldoPend"))
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotSaldo += wSaldo
            wTotPendi += wPendi
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(1).Text = "Total: "
            e.Item.Cells(2).Text = String.Format("{0:###,###,###,###.00}", wTotSaldo)
            e.Item.Cells(3).Text = String.Format("{0:###,###,###,###.00}", wTotPendi)
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.BackColor = Color.Beige

            If wTotSaldo > 0 Then
                e.Item.Cells(2).ForeColor = Color.Red
            ElseIf wTotSaldo < 0 Then
                e.Item.Cells(2).ForeColor = Color.Blue
            End If

            If wTotPendi > 0 Then
                e.Item.Cells(3).ForeColor = Color.Red
            ElseIf wTotPendi < 0 Then
                e.Item.Cells(3).ForeColor = Color.Blue
            End If

            If wTotalSum > 0 Then
                e.Item.Cells(4).ForeColor = Color.Red
            ElseIf wTotalSum < 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            End If
        End If
    End Sub


End Class
