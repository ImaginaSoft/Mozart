Imports cmpTabla
Partial Class tabla
    Inherits System.Web.UI.Page
    Dim objTabla As New clsTabla
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        dgLista.DataKeyField = "codtabla"
        dgLista.DataSource = objTabla.Cargar
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count) + " Tablas"
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        txtCodigo.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text.Trim
        txtNombreEsp.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim
        txtCodEleLong.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text.Trim
        If dgLista.Items(dgLista.SelectedIndex).Cells(3).Text.Trim = "Activo" Then
            rbInactivo.Checked = False
            rbActivo.Checked = True
        Else
            rbActivo.Checked = False
            rbInactivo.Checked = True
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTabla.CodTabla = txtCodigo.Text
        objTabla.NomTabla = txtNombreEsp.Text
        objTabla.CodEleLong = txtCodEleLong.Text
        If rbActivo.Checked Then
            objTabla.StsTabla = "A"
        Else
            objTabla.StsTabla = "I"
        End If
        objTabla.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTabla.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.CssClass = "msg"
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


    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objTabla.Borrar(dgLista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgLista_EditCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        Response.Redirect("tablaElemento.aspx" & _
                    "?CodTabla=" & dgLista.DataKeys(e.Item.ItemIndex))
    End Sub

    Private Sub dgLista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

End Class
