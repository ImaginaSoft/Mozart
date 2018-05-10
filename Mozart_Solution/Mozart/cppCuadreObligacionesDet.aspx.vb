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

Partial Class cppCuadreObligacionesDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodMoneda") = Request.Params("CodMoneda")
            lbltitulo.Text = "Pedido # " & CStr(Viewstate("NroPedido"))
            CargaDocumentos()
        End If

    End Sub
    Private Sub CargaDocumentos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CuadreObligacionesDet_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Request.Params("CodMoneda")

        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "Documentos")

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgCtaCte.DataSource = dv
        dgCtaCte.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub
    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("cppCompletaDatosDetalle.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor"))
    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            'Snip out the ViewCount
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotalSum += wTotal

            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Saldo"))
            wUtilidadSum += wUtilidad

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = "Total: "
            e.Item.Cells(5).Text = String.Format("{0:###,###,###.00}", wTotalSum)
            e.Item.Cells(6).Text = String.Format("{0:###,###,###.00}", wUtilidadSum)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Center

            If wTotalSum > 0 Then
                e.Item.Cells(5).ForeColor = Color.Red
            Else
                e.Item.Cells(5).ForeColor = Color.Blue
            End If
            If wUtilidadSum > 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            Else
                e.Item.Cells(6).ForeColor = Color.Blue
            End If
        End If
    End Sub
    Private Sub lbtPendientesCuadre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("cppCuadreObligaciones.aspx" & _
                       "?CodProveedor=" & Viewstate("CodProveedor"))
    End Sub

    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If Trim(e.Item.Cells(10).Text) = "Anulado" Then
            e.Item.ForeColor = Color.DarkGray
        Else
            If IsNumeric(e.Item.Cells(5).Text) Then
                If e.Item.Cells(5).Text > 0 Then
                    e.Item.Cells(5).ForeColor = Color.Red
                Else
                    e.Item.Cells(5).ForeColor = Color.Blue
                End If

                If e.Item.Cells(6).Text > 0 Then
                    e.Item.Cells(6).ForeColor = Color.Red
                Else
                    If e.Item.Cells(6).Text < 0 Then
                        e.Item.Cells(6).ForeColor = Color.Blue
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgCtaCte_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCtaCte.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

End Class
