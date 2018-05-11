Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class bolStockCompradoSolicitud
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim wTarifaSum As Double = 0
    Dim wIGVSum As Double = 0
    Dim wImpuestoSum As Double = 0
    Dim wComi1Sum As Double = 0
    Dim wComi2Sum As Double = 0
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            viewstate("IdReg") = Request.Params("IdReg")
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            CargaBoletos()
        End If
    End Sub

    Private Sub CargaBoletos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_StockCompradoRemision_S"
        da.SelectCommand.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = viewstate("IdReg")

        Dim nReg As Integer = da.Fill(ds, "Campo")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()
    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTarifa As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Tarifa"))
            wTarifaSum += wTarifa

            Dim wIGV As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV"))
            wIGVSum += wIGV

            Dim wImpuesto As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Impuesto"))
            wImpuestoSum += wImpuesto

            Dim wComi1 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision1"))
            wComi1Sum += wComi1

            Dim wComi2 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision2"))
            wComi2Sum += wComi2

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(2).Text = "Total: "
            '            e.Item.Cells(2).Font.Bold = True
            e.Item.Cells(3).Text = String.Format("{0:###,###,###.00}", wTarifaSum)
            '           e.Item.Cells(3).Font.Bold = True
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).Text = String.Format("{0:###,###,###.00}", wIGVSum)
            '          e.Item.Cells(4).Font.Bold = True
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).Text = String.Format("{0:###,###,###.00}", wImpuestoSum)
            '        e.Item.Cells(5).Font.Bold = True
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(6).Text = String.Format("{0:###,###,###.00}", wComi1Sum)
            '            e.Item.Cells(6).Font.Bold = True
            e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(7).Text = String.Format("{0:###,###,###.00}", wComi2Sum)
            '           e.Item.Cells(7).Font.Bold = True
            e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Private Sub dgBoleto_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgBoleto.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaBoletos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_StockCompradoSolicitud_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FchRemision", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = viewstate("IdReg")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("bolStockComprado.aspx")
        End If
    End Sub

End Class
