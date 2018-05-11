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

Partial Class bolCuadreRemision
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView
    Dim dTotPago As Double = 0
    Dim dTotRecu As Double = 0
    Dim dTotProv As Double = 0
    Dim dTotDife As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-30)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
            CargaPedidos()
        End If
    End Sub

    Private Sub CargaPedidos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wtipodoc As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_CuadreRemision_S"
        da.SelectCommand.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)

        Dim nReg As Integer = da.Fill(ds, "Movtos")
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        'dgLista.DataKeyField = "KeyReg"
        dgLista.DataSource = dv
        dgLista.DataBind()

        'lblmsg.Text = CStr(nReg) + " Version(es)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub


    Private Sub dgLista_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Response.Redirect("VtaCuadreAereoDet.aspx" & _
            "?NroPedido=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 11, 10) & _
            "&NroPropuesta=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 21, 2) & _
            "&NroVersion=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 23, 2))
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            'Snip out the ViewCount
            Dim dPago As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PagoBoleto"))
            Dim dRecu As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Recuperado"))
            Dim dProv As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Provision"))
            Dim dDife As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Diferencia"))
            dTotPago += dPago
            dTotRecu += dRecu
            dTotProv += dProv
            dTotDife += dDife

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(1).Text = "Total: "
            e.Item.Cells(2).Text = String.Format("{0:###,###,###,###.##}", dTotPago)
            e.Item.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(3).Text = String.Format("{0:###,###,###,###.##}", dTotRecu)
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.##}", dTotProv)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.##}", dTotDife)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right

            If dTotDife >= 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If

        End If
    End Sub

    Private Sub dgLista_ItemDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(5).Text >= 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        '        "?FchInicio=" & objRutina.fechayyyymmdd(txtFchInicial.Text) & _
        '       "&FchFin=" & objRutina.fechayyyymmdd(txtFchFinal.Text) & _
        Response.Redirect("bolCuadreRemisionBoleto.aspx" & _
        "?NroReembolso=" & dgLista.Items(dgLista.SelectedIndex).Cells(0).Text & _
        "&NroPedido=" & dgLista.Items(dgLista.SelectedIndex).Cells(7).Text & _
        "&NroPropuesta=" & dgLista.Items(dgLista.SelectedIndex).Cells(8).Text & _
        "&NroVersion=" & dgLista.Items(dgLista.SelectedIndex).Cells(9).Text)
    End Sub

End Class
