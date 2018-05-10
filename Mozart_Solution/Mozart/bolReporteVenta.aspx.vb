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

Partial Class bolReporteVenta
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Dim wTotalSum As Double = 0
    Dim wComi1Sum As Double = 0
    Dim wComi2Sum As Double = 0
    Dim wIGV1Sum As Double = 0
    Dim wIGV2Sum As Double = 0
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "Bol_ReporteVenta_S"
        da.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FechaFinal", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Boletos")
        dgReportes.DataKeyField = "CodLinea"
        dgReportes.DataSource = ds.Tables("Boletos")
        dgReportes.DataBind()
        lblfchinicial.Text = txtFchInicial.Text
        lblfchfinal.Text = txtFchFinal.Text
        lblmsg.Text = "Del " & txtFchInicial.Text & " al " & txtFchFinal.Text
    End Sub

    Private Sub dgReportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgReportes.SelectedIndexChanged
        Response.Redirect("bolReporteBoletos.aspx" & _
                "?CodProveedor=" & dgReportes.Items(dgReportes.SelectedIndex).Cells(9).Text & _
                "&CodLinea=" & dgReportes.Items(dgReportes.SelectedIndex).Cells(2).Text & _
                "&FchIni=" & ObjRutina.fechayyyymmdd(txtFchInicial.Text) & _
                "&FchFin=" & ObjRutina.fechayyyymmdd(txtFchFinal.Text))

    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotalSum += wTotal
            Dim wComi1 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision1"))
            wComi1Sum += wComi1
            Dim wIGV1 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV1"))
            wIGV1Sum += wIGV1
            Dim wComi2 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision2"))
            wComi2Sum += wComi2
            Dim wIGV2 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV2"))
            wIGV2Sum += wIGV2
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            '            e.Item.Cells(3).Text = "Total: "
            '           e.Item.Cells(3).Font.Bold = True
            e.Item.Cells(4).Text = String.Format("{0:###,###,###.00}", wTotalSum)
            e.Item.Cells(4).Font.Bold = True
            e.Item.Cells(5).Text = String.Format("{0:###,###,###.00}", wComi1Sum)
            e.Item.Cells(5).Font.Bold = True
            e.Item.Cells(6).Text = String.Format("{0:###,###,###.00}", wIGV1Sum)
            e.Item.Cells(6).Font.Bold = True
            e.Item.Cells(7).Text = String.Format("{0:###,###,###.00}", wComi2Sum)
            e.Item.Cells(7).Font.Bold = True
            e.Item.Cells(8).Text = String.Format("{0:###,###,###.00}", wIGV2Sum)
            e.Item.Cells(8).Font.Bold = True
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(8).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub


End Class
