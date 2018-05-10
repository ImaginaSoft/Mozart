Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpTabla

Partial Class cppGastosDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objCuenta As New clsCuenta
    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wTotSoles As Double = 0
    Dim wTotdolares As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            If Request.Params("CodCuenta") > 0 Then
                txtFchInicial.Text = Request.Params("FchIni")
                txtFchFinal.Text = Request.Params("FchFin")
                CargaTipoCuenta(Mid(Request.Params("CodCuenta"), 1, 2) & "  ")
                CargaCuenta(Request.Params("CodCuenta"))
                CargaDoc()

                'Restringido solo a ver hasta saldos operativos
                If Request.Params("Opcion") = "R" Then
                    ddlTipoCuenta.Enabled = False
                End If
            Else
                txtFchInicial.Text = objRutina.fechaddmmyyyy(-30)
                txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
                CargaTipoCuenta("")
                CargaCuenta("")
            End If
        End If
    End Sub

    Private Sub CargaTipoCuenta(ByVal pCodCuenta As String)
        ddlTipoCuenta.DataSource = objCuenta.CargarCuentaNivel1
        ddlTipoCuenta.DataBind()
        Try
            ddlTipoCuenta.Items.FindByValue(pCodCuenta).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaCuenta(ByVal pCodCuenta As String)
        ddlCuenta.DataSource = objCuenta.CargarCuenta4(ddlTipoCuenta.SelectedItem.Value)
        ddlCuenta.DataBind()
        Try
            ddlCuenta.Items.FindByValue(Request.Params("CodCuenta")).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim wMesIni As Integer = 0
        Dim wMesFin As Integer = 0

        If txtFchInicial.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Fecha de inicio es dato obligatorio"
            Return
        End If
        If txtFchFinal.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Fecha final es dato obligatorio"
            Return
        End If
        CargaDoc()
    End Sub

    Private Sub CargaDoc()
        Dim sCodCuenta As String
        If ddlCuenta.Items.Count = 0 Then
            sCodCuenta = "zzzz" 'no existe cuenta
        Else
            sCodCuenta = ddlCuenta.SelectedItem.Value
        End If
        Dim ds As New DataSet
        ds = objCuenta.CargarCuentaDet(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), sCodCuenta)
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgGastos.DataSource = dv
        dgGastos.DataBind()
        lblMsg.CssClass = "msg"
        lblMsg.Text = CStr(dgGastos.Items.Count) + " Cuenta(s)"
    End Sub

    Private Sub ddlTipoCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoCuenta.SelectedIndexChanged
        CargaCuenta("")
    End Sub


    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wSoles As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Soles"))
            wTotSoles += wSoles
            Dim wdolares As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Dolares"))
            wTotdolares += wdolares
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Total"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(3).Text = String.Format("{0:###,###,###,###.00}", wTotSoles)
            e.Item.Cells(3).Font.Bold = True
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotdolares)
            e.Item.Cells(4).Font.Bold = True
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(5).Font.Bold = True
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Protected Sub dgGastos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgGastos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaCuenta("")
    End Sub

End Class
