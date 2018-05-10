Imports cmpTabla
Imports System.Data

Partial Class tabManTipoServicio
    Inherits System.Web.UI.Page
    Dim objTipoServicio As New clsTipoServicio
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        rbActivo.Checked = True
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTipoServicio.Cargar()
        dgTipoServicio.DataKeyField = "CodTipoServicio"
        dgTipoServicio.DataSource = ds
        dgTipoServicio.DataBind()
        lblMsg.Text = CStr(dgTipoServicio.Items.Count) + " Tipos de Servicio(s)"
    End Sub

    Private Sub dgTipoServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTipoServicio.SelectedIndexChanged
        If dgTipoServicio.Items(dgTipoServicio.SelectedIndex).Cells(3).Text.Trim = "Activo" Then
            rbInactivo.Checked = False
            rbActivo.Checked = True
        Else
            rbActivo.Checked = False
            rbInactivo.Checked = True
        End If
        txtCodigo.Text = dgTipoServicio.Items(dgTipoServicio.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgTipoServicio.Items(dgTipoServicio.SelectedIndex).Cells(2).Text.Trim
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wEstado As String
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If

        objTipoServicio.CodTipoServicio = txtCodigo.Text
        objTipoServicio.TipoServicio = txtNombre.Text
        objTipoServicio.StsTipoServicio = wEstado
        objTipoServicio.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoServicio.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgTipoServicio_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoServicio.DeleteCommand
        objTipoServicio.CodTipoServicio = dgTipoServicio.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objTipoServicio.Borrar()
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

    Private Sub dgTipoServicio_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoServicio.CancelCommand
        Response.Redirect("tabTipoAcomodacion.aspx.aspx" & _
                    "?CodTipoServicio=" & dgTipoServicio.DataKeys(e.Item.ItemIndex))
    End Sub

    Private Sub dgTipoServicio_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoServicio.EditCommand
        Response.Redirect("tabTipoAcomodacion.aspx" & _
                    "?CodTipoServicio=" & dgTipoServicio.DataKeys(e.Item.ItemIndex))
    End Sub


End Class
