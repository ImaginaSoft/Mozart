Imports cmpSeguridad
Imports cmpTabla
Imports cmpNegocio
Imports cmpRutinas
Imports System.Data
Imports System.Drawing

Partial Class VtaFacturadas
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT053005") = "X" Then
                lbkCierreVtas.Visible = True
            End If

            ' Configurado Español
            System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("es-PE")

            Dim objPeriodoVta As New clsPeriodoVta
            lblmsg.Text = objPeriodoVta.EditarPeriodoAbierto
            If lblmsg.Text.Trim = "OK" Then
                lblmsg.Text = ""
                txtFchInicial.Text = String.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchIniPeriodo)
                txtFchFinal.Text = String.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchFinPeriodo)
            End If
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()

        Dim objUsuario As New clsUsuario
        objUsuario.CodUsuario = Session("CodUsuario")
        objUsuario.Editar()
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

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub CargaPedidos()
        Dim objVersion As New clsVersion
        Dim ds As New DataSet

        If ddlIdioma.SelectedItem.Value = "T" Then
            If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                ds = objVersion.CargarVersionesFacturada(ddlZonaVta1.CodZonaVta, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            Else
                ds = objVersion.CargarVersionesFacturada(ddlVendedor.SelectedItem.Value, ddlZonaVta1.CodZonaVta, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            End If
        Else
            If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
                ds = objVersion.CargarVersionesFacturadaIdioma(ddlZonaVta1.CodZonaVta, ddlIdioma.SelectedItem.Value, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            Else
                ds = objVersion.CargarVersionesFacturadaIdioma(ddlVendedor.SelectedItem.Value, ddlZonaVta1.CodZonaVta, ddlIdioma.SelectedItem.Value, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            End If

        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
        dgVersiones.DataKeyField = "KeyReg"
        dgVersiones.DataSource = dv
        dgVersiones.DataBind()
        lblmsg.Text = CStr(dgVersiones.Items.Count) + " Registro(s)"

    End Sub

    Private Sub dgVersiones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgVersiones.SelectedIndexChanged
        Session("CodCliente") = dgVersiones.Items(dgVersiones.SelectedIndex).Cells(10).Text

        Response.Redirect("VtaVersionFicha.aspx" & _
        "?CodCliente=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(10).Text & _
        "&NroPedido=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(1).Text & _
        "&NroPropuesta=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(11).Text & _
        "&NroVersion=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(2).Text & _
        "&CantAdultos=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(12).Text & _
        "&CantNinos=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(13).Text)
    End Sub

    Private Sub dgVersiones_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVersiones.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If

            If e.Item.Cells(3).Text.Trim = "A" Then
                e.Item.ForeColor = Color.Red
            ElseIf e.Item.Cells(3).Text.Trim = "L" Then
                e.Item.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub dgVersiones_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVersiones.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalSum += wTotal

            Dim wUtilidad As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Utilidad"))
            wUtilidadSum += wUtilidad

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(5).Text = "Total: "
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.00}", wTotalSum)
            e.Item.Cells(7).Text = String.Format("{0:###,###,###,###.00}", wUtilidadSum)

            If wUtilidadSum > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgVersiones_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVersiones.EditCommand
        Response.Redirect("VtaFacturadasDet.aspx" & _
            "?CodCliente=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 1, 10) & _
            "&CodZonaVta=" & ddlZonaVta1.CodZonaVta & _
            "&NroPedido=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 11, 10) & _
            "&NroPropuesta=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 21, 2) & _
            "&NroVersion=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 23, 2) & _
            "&FchInicial=" & txtFchInicial.Text & _
            "&FchFinal=" & txtFchFinal.Text)
    End Sub

    Private Sub lbkCierreVtas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbkCierreVtas.Click
        Response.Redirect("VtaFacturadasCierre.aspx")
    End Sub

End Class
