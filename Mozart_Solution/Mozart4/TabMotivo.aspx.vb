Imports cmpTabla
Imports System.Data

Partial Class TabMotivo
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objMotivo As New clsMotivo

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            rbActivo.Checked = True
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objMotivo.Cargar
        dglista.DataKeyField = "CodMotivo"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Motivo(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtCodigo.Text) Then
            lblMsg.Text = "Código motivos es numerico"
            Return
        End If

        If rbActivo.Checked Then
            objMotivo.StsMotivo = "A"
        Else
            objMotivo.StsMotivo = "I"
        End If
        objMotivo.CodMotivo = txtCodigo.Text
        objMotivo.NomMotivo = txtNombre.Text
        objMotivo.NroOrden = txtNroOrden.Text
        objMotivo.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objMotivo.Grabar
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
        objMotivo.CodMotivo = dglista.DataKeys(e.Item.ItemIndex).ToString
        lblMsg.Text = objMotivo.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtNroOrden.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim

        If dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim = "I" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dglista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dglista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

End Class
