Imports cmpTabla
Imports cmpNegocio

Partial Class plaTourPlantilla
    Inherits System.Web.UI.Page
    Dim objPlantilla As New clsPlantilla
    Dim objTourPlantilla As New clsTourPlantilla
    Dim objTour As New clsTour

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblCodTour.Text = Request.Params("CodTour")
            objTour.Editar(lblCodTour.Text)
            lblNomTour.Text = objTour.NomTour
            lblCantDias.Text = objTour.CantDias

            ddlPlantilla.DataSource = objPlantilla.CargaxFlagDias(lblCantDias.Text)
            ddlPlantilla.DataBind()
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        dgLista.DataKeyField = "NroPlantilla"
        dgLista.DataSource = objTourPlantilla.Cargar(lblCodTour.Text)
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count) + " Plantilla(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTourPlantilla.CodTour = lblCodTour.Text
        objTourPlantilla.NroPlantilla = ddlPlantilla.SelectedValue
        objTourPlantilla.CodUsuario = Session("CodUsuario")
        If rbtSI.Checked Then
            objTourPlantilla.Asigna = "S"
        Else
            objTourPlantilla.Asigna = "N"
        End If
        lblMsg.Text = objTourPlantilla.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
            lblMsg.CssClass = "msg"
        Else
            lblMsg.CssClass = "error"
        End If
    End Sub

    Private Sub rbtSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSI.CheckedChanged
        rbtSI.Checked = True
        rbtNO.Checked = False
    End Sub

    Private Sub rbtNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNO.CheckedChanged
        rbtSI.Checked = False
        rbtNO.Checked = True
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        ddlPlantilla.DataSource = objPlantilla.CargaNroPlantilla(dgLista.Items(dgLista.SelectedIndex).Cells(1).Text)
        ddlPlantilla.DataBind()
        If dgLista.Items(dgLista.SelectedIndex).Cells(3).Text.Trim = "SI" Then
            rbtSI.Checked = True
            rbtNO.Checked = False
        Else
            rbtSI.Checked = False
            rbtNO.Checked = True
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objTourPlantilla.Borrar(lblCodTour.Text, dgLista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

End Class
