Imports cmpTabla
Imports cmpNegocio

Partial Class plaTour
    Inherits System.Web.UI.Page
    Dim objTour As New clsTour
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            rbActivo.Checked = True
            CargaIdioma("")
            CargaDatos()
        End If

    End Sub
    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim objIdioma As New clsIdioma
        ddlIdioma.DataSource = objIdioma.Cargar
        ddlIdioma.DataBind()
        Try
            ddlIdioma.Items.FindByValue(pIdioma).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaDatos()
        dgTour.DataKeyField = "CodTour"
        dgTour.DataSource = objTour.Cargar
        dgTour.DataBind()
        lblMsg.Text = CStr(dgTour.Items.Count) + " Tour(s)"
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTour.Idioma = ddlIdioma.SelectedValue
        objTour.CodTour = txtCodTour.Text
        objTour.NomTour = txtNomTour.Text
        objTour.ClasificaTour = txtClasificaTour.Text
        objTour.CantDias = txtCantDias.Text
        objTour.CodUsuario = Session("CodUsuario")
        If rbActivo.Checked Then
            objTour.StsTour = "A"
        Else
            objTour.StsTour = "I"
        End If
        lblMsg.Text = objTour.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
            lblMsg.CssClass = "msg"
        Else
            lblMsg.CssClass = "error"
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



    Private Sub dgTour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTour.SelectedIndexChanged
        txtCodTour.Text = dgTour.Items(dgTour.SelectedIndex).Cells(1).Text.Trim
        txtNomTour.Text = dgTour.Items(dgTour.SelectedIndex).Cells(2).Text.Trim
        txtClasificaTour.Text = dgTour.Items(dgTour.SelectedIndex).Cells(3).Text.Trim
        CargaIdioma(dgTour.Items(dgTour.SelectedIndex).Cells(4).Text.Trim)
        txtCantDias.Text = dgTour.Items(dgTour.SelectedIndex).Cells(5).Text.Trim
        If dgTour.Items(dgTour.SelectedIndex).Cells(7).Text.Trim = "A" Then
            rbActivo.Checked = True
        Else
            rbInactivo.Checked = True
        End If
    End Sub

    Private Sub dgTour_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTour.DeleteCommand
        lblMsg.Text = objTour.Borrar(dgTour.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgTour_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTour.EditCommand
        Response.Redirect("plaTourPlantilla.aspx" & _
          "?CodTour=" & dgTour.DataKeys(e.Item.ItemIndex))
    End Sub

End Class
