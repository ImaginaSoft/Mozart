Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class bolBoletosFact
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wTarifaSum As Double = 0
    Dim wIGVSum As Double = 0
    Dim wImpuestoSum As Double = 0
    Dim wCreditoSum As Double = 0
    Dim wComi1Sum As Double = 0
    Dim wIGV1Sum As Double = 0
    Dim wComi2Sum As Double = 0
    Dim wIGV2Sum As Double = 0
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lbltitulo.Text = "Boletos del Reporte " & Request.Params("TipoDocumento") & " " & Request.Params("NroDocumento")
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            CargaBoletos()
        End If
    End Sub

    Private Sub CargaBoletos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_BoletosFact_S"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        da.SelectCommand.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Dim nReg As Integer = da.Fill(ds, "Boletos")
        dgBoleto.DataSource = ds.Tables("Boletos")
        dgBoleto.DataBind()

    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        'First, make sure we are dealing with an Item or AlternatingItem
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            'Snip out the ViewCount
            Dim wTarifa As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Tarifa"))
            wTarifaSum += wTarifa

            Dim wIGV As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV"))
            wIGVSum += wIGV

            Dim wImpuesto As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Impuesto"))
            wImpuestoSum += wImpuesto

            Dim wCredito As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Credito"))
            wCreditoSum += wCredito

            Dim wComi1 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision1"))
            wComi1Sum += wComi1

            Dim wIGV1 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV1"))
            wIGV1Sum += wIGV1

            Dim wComi2 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Comision2"))
            wComi2Sum += wComi2

            Dim wIGV2 As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "IGV2"))
            wIGV2Sum += wIGV2

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            '            e.Item.Cells(0).Text = "Total: "
            '           e.Item.Cells(0).Font.Bold = True
            e.Item.Cells(1).Text = String.Format("{0:###,###,###.00}", wTarifaSum)
            e.Item.Cells(1).Font.Bold = True
            e.Item.Cells(2).Text = String.Format("{0:###,###,###.00}", wIGVSum)
            e.Item.Cells(2).Font.Bold = True
            e.Item.Cells(3).Text = String.Format("{0:###,###,###.00}", wImpuestoSum)
            e.Item.Cells(3).Font.Bold = True
            e.Item.Cells(4).Text = String.Format("{0:###,###,###.00}", wCreditoSum)
            e.Item.Cells(4).Font.Bold = True
            e.Item.Cells(6).Text = String.Format("{0:###,###,###.00}", wComi1Sum)
            e.Item.Cells(6).Font.Bold = True
            e.Item.Cells(7).Text = String.Format("{0:###,###,###.00}", wIGV1Sum)
            e.Item.Cells(7).Font.Bold = True
            e.Item.Cells(8).Text = String.Format("{0:###,###,###.00}", wComi2Sum)
            e.Item.Cells(8).Font.Bold = True
            e.Item.Cells(9).Text = String.Format("{0:###,###,###.00}", wIGV2Sum)
            e.Item.Cells(9).Font.Bold = True

            lblTotRep.Text = String.Format("{0:###,###,###.00}", wTarifaSum + wIGVSum + wImpuestoSum - wComi1Sum - wIGV1Sum - wComi2Sum - wIGV2Sum)
        End If
    End Sub

End Class
