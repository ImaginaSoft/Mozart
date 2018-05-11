Imports cmpNegocio
Imports cmpTabla
Imports System.Data

Partial Class TabLinea
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim objLineaArea As New clsLineaArea
    Dim objProveedor As New clsProveedor

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaProveedor(0)
            CargaProReembolso(0)
            CargaDatos()
        End If
    End Sub
    Private Sub CargaProveedor(ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        ds = objProveedor.CargarActivo
        ddlProveedor.DataSource = ds
        ddlProveedor.DataBind()
        If pCodProveedor > 0 Then
            ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
        End If
    End Sub

    Private Sub CargaProReembolso(ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        ds = objProveedor.CargarActivo
        ddlProReembolso.DataSource = ds
        ddlProReembolso.DataBind()
        If pCodProveedor > 0 Then
            ddlProReembolso.Items.FindByValue(pCodProveedor).Selected = True
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objLineaArea.Cargar
        dgLinea.DataKeyField = "CodLinea"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLinea.DataSource = dv
        dgLinea.DataBind()
        lblMsg.Text = CStr(dgLinea.Items.Count) + " Linea(s)"
    End Sub

    Private Sub dgLinea_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlProveedor.Items.Count = 0 Then
            lblMsg.Text = "Error: Proveedor es obligatorio"
            Return
        End If
        If ddlProReembolso.Items.Count = 0 Then
            lblMsg.Text = "Error: Proveedor para reembolso es obligatorio"
            Return
        End If
        If rbActivo.Checked Then
            objLineaArea.StsLinea = "A"
        Else
            objLineaArea.StsLinea = "I"
        End If

        objLineaArea.CodLinea = txtCodigo.Text
        objLineaArea.NomLinea = txtNombre.Text
        objLineaArea.CodProveedor = ddlProveedor.SelectedItem.Value
        objLineaArea.Ruc = txtRuc.Text
        objLineaArea.CodProReembolso = ddlProReembolso.SelectedItem.Value
        objLineaArea.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objLineaArea.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLinea.SelectedIndexChanged
        txtCodigo.Text = dgLinea.Items(dgLinea.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgLinea.Items(dgLinea.SelectedIndex).Cells(2).Text.Trim
        txtRuc.Text = dgLinea.Items(dgLinea.SelectedIndex).Cells(6).Text.Trim
        If dgLinea.Items(dgLinea.SelectedIndex).Cells(5).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If

        CargaProveedor(dgLinea.Items(dgLinea.SelectedIndex).Cells(3).Text)
        CargaProReembolso(dgLinea.Items(dgLinea.SelectedIndex).Cells(7).Text)
    End Sub

    Private Sub dgLinea_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLinea.DeleteCommand
        objLineaArea.CodLinea = dgLinea.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objLineaArea.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub


End Class
