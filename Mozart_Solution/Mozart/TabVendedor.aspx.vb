Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class TabVendedor
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objVendedor As New clsVendedor
    Dim objArea As New clsArea

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            rbActivo.Checked = True
            CargaDatos()
            CargaArea("")
            CargaVendedorOpe("")
            CargaSupervisor("")
            CargaCoordinador("")
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objVendedor.Cargar()
        dgVendedor.DataKeyField = "CodVendedor"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgVendedor.DataSource = dv
        dgVendedor.DataBind()
        lblMsg.Text = CStr(dgVendedor.Items.Count) + " Vendedor(es) "
    End Sub

    Private Sub CargaArea(ByVal pCodArea As String)
        Dim ds As New DataSet
        ds = objArea.Cargar()
        ddlArea.DataSource = ds.Tables(0)
        ddlArea.DataBind()
        If pCodArea.Trim.Length > 0 Then
            ddlArea.Items.FindByValue(pCodArea).Selected = True
        End If
    End Sub

    Private Sub CargaVendedorOpe(ByVal pCodVendedorOpe As String)
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo()
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem(" "))
        Try
            ddlVendedor.Items.FindByValue(pCodVendedorOpe).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaSupervisor(ByVal pCodVendedor As String)
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo()
        ddlsupervisor.DataSource = ds
        ddlsupervisor.DataBind()
        ddlsupervisor.Items.Insert(0, New ListItem(" "))
        Try
            ddlSupervisor.Items.FindByValue(pCodVendedor).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaCoordinador(ByVal pCodVendedor As String)
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo()
        ddlCoordinador.DataSource = ds
        ddlCoordinador.DataBind()
        ddlCoordinador.Items.Insert(0, New ListItem(" "))
        Try
            ddlCoordinador.Items.FindByValue(pCodVendedor).Selected = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not (txtNroOrdenStaff.Text = "1" Or txtNroOrdenStaff.Text = "2" Or txtNroOrdenStaff.Text = "3") Then
            lblMsg.Text = "N° de Orden en el Staff es 1,2 ó 3"
            Return
        End If
        If rbActivo.Checked Then
            objVendedor.StsVendedor = "A"
        Else
            objVendedor.StsVendedor = "I"
        End If
        objVendedor.CodVendedor = txtCodigo.Text
        objVendedor.NomVendedor = txtNombre.Text
        objVendedor.Email = txtEmail.Text
        objVendedor.TfEmergencia = txttfemergencia.Text
        objVendedor.CodArea = ddlArea.SelectedItem.Value
        objVendedor.NroOrdenStaff = txtNroOrdenStaff.Text
        objVendedor.CargoEsp = txtCargoEsp.Text
        objVendedor.CargoIng = txtCargoIng.Text
        If ddlSupervisor.SelectedItem.Text = " " Then
            objVendedor.CodVendedorAlt1 = ""
        Else
            objVendedor.CodVendedorAlt1 = ddlSupervisor.SelectedItem.Value
        End If

        If ddlCoordinador.SelectedItem.Text = " " Then
            objVendedor.CodVendedorAlt2 = ""
        Else
            objVendedor.CodVendedorAlt2 = ddlCoordinador.SelectedItem.Value
        End If

        If ddlVendedor.SelectedItem.Text = " " Then
            objVendedor.CodVendedorOpe = ""
        Else
            objVendedor.CodVendedorOpe = ddlVendedor.SelectedItem.Value
        End If
        objVendedor.BlogVendedor = txtBlogVendedor.Text
        objVendedor.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objVendedor.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub
    Private Sub dgPais_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVendedor.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub
    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgVendedor.SelectedIndexChanged
        txtCodigo.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(2).Text.Trim
        txtEmail.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(3).Text.Trim
        txttfemergencia.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(4).Text.Trim
        If dgVendedor.Items(dgVendedor.SelectedIndex).Cells(5).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If

        CargaArea(dgVendedor.Items(dgVendedor.SelectedIndex).Cells(6).Text)
        CargaVendedorOpe(dgVendedor.Items(dgVendedor.SelectedIndex).Cells(7).Text)
        txtNroOrdenStaff.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(9).Text.Trim
        txtCargoEsp.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(10).Text.Trim
        txtCargoIng.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(11).Text.Trim
        CargaSupervisor(dgVendedor.Items(dgVendedor.SelectedIndex).Cells(12).Text)
        CargaCoordinador(dgVendedor.Items(dgVendedor.SelectedIndex).Cells(13).Text)
        If dgVendedor.Items(dgVendedor.SelectedIndex).Cells(14).Text.Trim = "&nbsp;" Then
            txtBlogVendedor.Text = ""
        Else
            txtBlogVendedor.Text = dgVendedor.Items(dgVendedor.SelectedIndex).Cells(14).Text.Trim
        End If

    End Sub

    Private Sub dgVendedor_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVendedor.DeleteCommand
        objVendedor.CodVendedor = dgVendedor.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objVendedor.Borrar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgVendedor_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVendedor.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(5).Text.Trim = "Inactivo" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub


End Class
