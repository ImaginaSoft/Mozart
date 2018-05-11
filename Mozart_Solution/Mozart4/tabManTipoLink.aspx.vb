Imports cmpTabla
Imports System.Data

Partial Class tabManTipoLink
    Inherits System.Web.UI.Page
    Dim objTipoLink As New clsTipoLink

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        rbActivo.Checked = True
        CargaDatos()
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTipoLink.Cargar()
        dgTipoLink.DataKeyField = "CodTipoLink"
        dgTipoLink.DataSource = ds.Tables(0)
        dgTipoLink.DataBind()
        lblMsg.Text = CStr(dgTipoLink.Items.Count) + " Link(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wEstado As String
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If
        objTipoLink.CodTipoLink = txtCodigo.Text
        objTipoLink.TipoLink = txtNombre.Text
        objTipoLink.StsTipoLink = wEstado
        objTipoLink.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoLink.Grabar()
        If lblMsg.Text = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgTipoLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTipoLink.SelectedIndexChanged
        If dgTipoLink.Items(dgTipoLink.SelectedIndex).Cells(3).Text.Trim = "Activo" Then
            rbActivo.Checked = True
            rbInactivo.Checked = False
        Else
            rbActivo.Checked = False
            rbInactivo.Checked = True
        End If
        txtCodigo.Text = dgTipoLink.Items(dgTipoLink.SelectedIndex).Cells(1).Text
        txtNombre.Text = dgTipoLink.Items(dgTipoLink.SelectedIndex).Cells(2).Text
    End Sub

    Private Sub dgTipoLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoLink.DeleteCommand
        objTipoLink.CodTipoLink = dgTipoLink.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objTipoLink.Borrar()
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
End Class
