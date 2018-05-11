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

Partial Class VtaFacturadasDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaPedidos()
        End If
    End Sub
    Private Sub CargaPedidos()
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionFacturadaDet_S"
        da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = Request.Params("CodZonaVta")
        da.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(Request.Params("FchInicial"))
        da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(Request.Params("FchFinal"))
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Request.Params("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Request.Params("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Request.Params("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Movtos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgVersiones.DataSource = dv
        dgVersiones.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub dgVersiones_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVersiones.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If

            If e.Item.Cells(2).Text.Trim = "A" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgVersiones_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVersiones.SortCommand
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            'Snip out the ViewCount
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalSum += wTotal

            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Utilidad"))
            wUtilidadSum += wUtilidad

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(6).Text = "Total: "
            e.Item.Cells(6).Text = String.Format("{0:###,###,###.00}", wTotalSum)
            e.Item.Cells(7).Text = String.Format("{0:###,###,###.00}", wUtilidadSum)

            If wUtilidadSum > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub
End Class
