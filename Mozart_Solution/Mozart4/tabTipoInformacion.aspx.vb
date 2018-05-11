Imports cmpTabla
Imports System.Data

Partial Class tabTipoInformacion
    Inherits System.Web.UI.Page
    Dim objTipoInformacion As New clsTipoInformacion
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTipoInformacion.Cargar()
        dgTipoInformacion.DataKeyField = "NroTipoInf"
        dgTipoInformacion.DataSource = ds
        dgTipoInformacion.DataBind()
        lblMsg.Text = CStr(dgTipoInformacion.Items.Count) + " Tipos de Información"
    End Sub

    Private Sub dgTipoInformacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTipoInformacion.SelectedIndexChanged
        txtCodigo.Text = dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(1).Text.Trim
        txtNombreEsp.Text = dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(2).Text.Trim
        txtNombreIng.Text = dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(3).Text.Trim
        txtNombrePor.Text = dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(8).Text.Trim
        If dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(4).Text.Trim = "Activo" Then
            rbInactivo.Checked = False
            rbActivo.Checked = True
        Else
            rbActivo.Checked = False
            rbInactivo.Checked = True
        End If
        txtNroOrden.Text = dgTipoInformacion.Items(dgTipoInformacion.SelectedIndex).Cells(5).Text.Trim
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTipoInformacion.NroTipoInf = txtCodigo.Text
        objTipoInformacion.NomTipoInfEsp = txtNombreEsp.Text
        objTipoInformacion.NomTipoInfIng = txtNombreIng.Text
        objTipoInformacion.NomTipoInfPor = txtNombrePor.Text
        If rbActivo.Checked Then
            objTipoInformacion.StsTipoInf = "A"
        Else
            objTipoInformacion.StsTipoInf = "I"
        End If
        objTipoInformacion.NroOrden = txtNroOrden.Text
        objTipoInformacion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoInformacion.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgTipoInformacion_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoInformacion.DeleteCommand
        lblMsg.Text = objTipoInformacion.Borrar(dgTipoInformacion.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInactivo.CheckedChanged
        rbActivo.Checked = False
        rbInactivo.Checked = True

    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgTipoInformacion_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoInformacion.EditCommand
        Response.Redirect("tabTipoInformacionDet.aspx" & _
                    "?NroTipoInf=" & dgTipoInformacion.DataKeys(e.Item.ItemIndex))
    End Sub

    Private Sub dgTipoInformacion_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTipoInformacion.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

End Class
