Imports cmpTabla
Imports System.Data

Partial Class tabCiudad
    Inherits System.Web.UI.Page
    Dim objCiudad As New clsCiudad
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
        ds = objCiudad.Cargar()
        dgCiudad.DataKeyField = "CodCiudad"
        dgCiudad.DataSource = ds.Tables(0)
        dgCiudad.DataBind()
        lblMsg.Text = CStr(dgCiudad.Items.Count()) + " Ciudad(es)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wEstado As String
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If

        objCiudad.CodCiudad = txtCodigo.Text
        objCiudad.NomCiudad = txtNombre.Text
        objCiudad.StsCiudad = wEstado
        objCiudad.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objCiudad.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgCiudad_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCiudad.DeleteCommand
        objCiudad.CodCiudad = dgCiudad.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objCiudad.Borrar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCiudad.SelectedIndexChanged
        If dgCiudad.Items(dgCiudad.SelectedIndex).Cells(3).Text.Trim = "Activo" Then
            rbInactivo.Checked = False
            rbActivo.Checked = True
        Else
            rbActivo.Checked = False
            rbInactivo.Checked = True
        End If
        txtCodigo.Text = dgCiudad.Items(dgCiudad.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgCiudad.Items(dgCiudad.SelectedIndex).Cells(2).Text.Trim
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInactivo.CheckedChanged
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgCiudad_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCiudad.EditCommand
        Response.Redirect("tabCiudadInf.aspx" & _
            "?CodCiudad=" & dgCiudad.DataKeys(e.Item.ItemIndex))
    End Sub


End Class
