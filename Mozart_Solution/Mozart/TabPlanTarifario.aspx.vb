Imports cmpTabla
Imports System.Data

Partial Class TabPlanTarifario
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objPlanTarifario As New clsPlanTarifario

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblTitulo.Text = "Plan Tarifario "
            rbActivo.Checked = True
            CargaDatos()
        End If

    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objPlanTarifario.Cargar
        dglista.DataKeyField = "CodPlanTarifario"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Planes"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objPlanTarifario.StsPlanTarifario = "A"
        Else
            objPlanTarifario.StsPlanTarifario = "I"
        End If
        objPlanTarifario.CodPlanTarifario = txtCodigo.Text
        objPlanTarifario.NomPlanTarifario = txtNombre.Text
        objPlanTarifario.PorUtilidadAnoActual = txtPorcen1.Text
        objPlanTarifario.PorUtilidadSgtesAnos = txtPorcen2.Text
        objPlanTarifario.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPlanTarifario.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        lblMsg.Text = objPlanTarifario.Borrar(dglista.DataKeys(e.Item.ItemIndex).ToString)
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text
        txtNombre.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text
        txtPorcen1.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text
        txtPorcen2.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text
        If Trim(dglista.Items(dglista.SelectedIndex).Cells(5).Text) = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

End Class
