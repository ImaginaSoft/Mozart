Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cpcSaldosCliente
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim wTotalSum As Double = 0
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            txtFecha.Text = ObjRutina.fechaddmmyyyy(-1)
        End If
    End Sub
    Private Sub CargaSaldosCliente(ByVal fecha As String, ByVal Moneda As String)

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet
        'Envia Data
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_SaldosCliente_S"
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Moneda
        da.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFecha.Text)

        Dim nReg As Integer = da.Fill(ds, "Campo")
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgSaldos.DataSource = dv
        dgSaldos.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"

    End Sub
    Private Sub dgSaldos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSaldos.SortCommand
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()

        Dim wMoneda, wFecha As String

        'Validacionde moneda
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = txtFecha.Text.Substring(6, 4) + txtFecha.Text.Substring(3, 2) + txtFecha.Text.Substring(0, 2)
        CargaSaldosCliente(wFecha, wMoneda)

    End Sub

    Private Sub rbDolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDolar.CheckedChanged
        Dim wMoneda, wFecha As String
        'Validacionde moneda
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = txtFecha.Text.Substring(6, 4) + txtFecha.Text.Substring(3, 2) + txtFecha.Text.Substring(0, 2)
        CargaSaldosCliente(wFecha, wMoneda)
    End Sub

    Private Sub rbSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged
        Dim wMoneda, wFecha As String

        rbDolar.Checked = False
        rbSoles.Checked = True
        'Validacionde moneda
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = txtFecha.Text.Substring(6, 4) + txtFecha.Text.Substring(3, 2) + txtFecha.Text.Substring(0, 2)
        CargaSaldosCliente(wFecha, wMoneda)
    End Sub

    Private Sub txtFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim wMoneda, wFecha As String
        'Validacionde moneda
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = txtFecha.Text.Substring(6, 4) + txtFecha.Text.Substring(3, 2) + txtFecha.Text.Substring(0, 2)
        CargaSaldosCliente(wFecha, wMoneda)

    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        Dim wMoneda, wFecha As String
        'Validacionde moneda
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = txtFecha.Text.Substring(6, 4) + txtFecha.Text.Substring(3, 2) + txtFecha.Text.Substring(0, 2)
        CargaSaldosCliente(wFecha, wMoneda)
    End Sub

    Private Sub dgSaldos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgSaldos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            If IsNumeric(e.Item.Cells(4).Text) Then
                If e.Item.Cells(3).Text > 0 Then
                    e.Item.Cells(3).ForeColor = Color.Blue
                ElseIf e.Item.Cells(3).Text < 0 Then
                    e.Item.Cells(3).ForeColor = Color.Red
                End If
            End If

            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            ElseIf e.Item.Cells(4).Text < 0 Then
                e.Item.Cells(4).ForeColor = Color.Red
            End If

            If e.Item.Cells(5).Text > 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            ElseIf e.Item.Cells(5).Text < 0 Then
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgSaldos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSaldos.SelectedIndexChanged
        Session("CodCliente") = CInt(dgSaldos.Items(dgSaldos.SelectedIndex).Cells(1).Text())
        Response.Redirect("CpcClienteFicha.aspx" & _
                                    "?CodCliente=" & dgSaldos.Items(dgSaldos.SelectedIndex).Cells(1).Text)
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            If wTotalSum >= 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If
            e.Item.Cells(5).Text = "Total: " & String.Format("{0:###,###,###,###.##}", wTotalSum)
        End If
    End Sub


End Class
