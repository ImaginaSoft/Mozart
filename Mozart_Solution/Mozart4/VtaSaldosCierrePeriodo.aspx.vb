Imports cmpSeguridad
Imports cmpTabla
Imports cmpNegocio
Imports cmpRutinas
Imports System.Data
Imports System.Drawing


Partial Class VtaSaldosCierrePeriodo
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0
    Dim objRutina As New clsRutinas
    Dim objZonaVta As New clsZonaVta
    Dim objUsuario As New clsUsuario
    Dim objPeriodoVta As New clsPeriodoVta
    Dim objCierreVersion As New clsCierreVersion

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ' Configurado Español
            System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("es-PE")


            objUsuario.CodUsuario = Session("CodUsuario")
            objUsuario.Editar()
            CargaZonaVta()
            CargaVendedor()
            CargaPeriodosVta()
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim ds As New DataSet
        ds = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()

        If objUsuario.FlagVtaAcceso = "P" Then
            'sin opcion todos
        Else
            ddlZonaVta.Items.Insert(0, New ListItem("Todos"))
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()

        If objUsuario.FlagVtaAcceso = "P" Then
            Try
                ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
            Catch ex As Exception
                ddlVendedor.Items.Insert(0, New ListItem("Usuario sin Cod.Vendedor"))
            End Try
            ddlVendedor.Enabled = False
        Else
            ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        End If
    End Sub


    Private Sub CargaPeriodosVta()

        If txtNroReg.Text.Trim = "" Then
            lblmsg.Text = "Nro de periodos es obligatorio"
            Return
        ElseIf Not IsNumeric(txtNroReg.Text) Then
            lblmsg.Text = "Nro de periodos es dato númerico"
            Return
        End If

        Dim ds As New DataSet
        ds = objPeriodoVta.CargaxNroReg(txtNroReg.Text, "C")
        ddlPeriodoVtaIni.DataSource = ds
        ddlPeriodoVtaIni.DataBind()

        ddlPeriodoVtaFin.DataSource = ds
        ddlPeriodoVtaFin.DataBind()
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        Carga()
    End Sub

    Private Sub Carga()
        Dim ds As New DataSet

        If rbtResumen.Checked Then
            dgVersiones.Columns(0).Visible = False
            dgVersiones.Columns(1).Visible = False
            dgVersiones.Columns(2).Visible = False
            dgVersiones.Columns(6).Visible = False
            'resumen 
            If ddlZonaVta.SelectedItem.Value.Trim = "Todos" Then
                If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                    ds = objCierreVersion.SaldosTot(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue)
                Else
                    ds = objCierreVersion.SaldosTotVen(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlVendedor.SelectedValue)
                End If
            Else
                If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                    ds = objCierreVersion.SaldosTot(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlZonaVta.SelectedValue)
                Else
                    ds = objCierreVersion.SaldosTot(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlZonaVta.SelectedValue, ddlVendedor.SelectedValue)
                End If
            End If
        Else
            dgVersiones.Columns(0).Visible = True
            dgVersiones.Columns(1).Visible = True
            dgVersiones.Columns(2).Visible = True
            dgVersiones.Columns(6).Visible = True
            'detalle
            If ddlZonaVta.SelectedItem.Value.Trim = "Todos" Then
                If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                    ds = objCierreVersion.SaldosDet(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue)
                Else
                    ds = objCierreVersion.SaldosDetVen(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlVendedor.SelectedValue)
                End If
            Else
                If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                    ds = objCierreVersion.SaldosDet(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlZonaVta.SelectedValue)
                Else
                    ds = objCierreVersion.SaldosDet(ddlPeriodoVtaIni.SelectedValue, ddlPeriodoVtaFin.SelectedValue, ddlZonaVta.SelectedValue, ddlVendedor.SelectedValue)
                End If
            End If

        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        'dgVersiones.DataKeyField = "KeyReg"
        dgVersiones.DataSource = dv
        dgVersiones.DataBind()
        'lblmsg.Text = CStr(dgVersiones.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgVersiones_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVersiones.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(5).Text > 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgVersiones_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVersiones.SortCommand
        ViewState("Campo") = e.SortExpression()
        Carga()
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalSum += wTotal

            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Utilidad"))
            wUtilidadSum += wUtilidad

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(3).Text = "Total: "
            e.Item.Cells(4).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Center
            e.Item.Cells(5).Text = String.Format("{0:###,###,###,###.00}", wUtilidadSum)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center

            If wUtilidadSum > 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub lbtMostrarPeriodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtMostrarPeriodos.Click
        CargaPeriodosVta()
    End Sub


End Class
