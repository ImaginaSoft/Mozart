Imports cmpTabla
Imports System.Data

Partial Class tablaElemento
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTabla As New clsTabla
    Dim objTablaElemento As New clsTablaElemento
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodTabla") = Request.Params("CodTabla")
            lblTitulo.Text = "Tabla "

            objTabla.Editar(Viewstate("CodTabla"))
            lblTitulo.Text = lblTitulo.Text & " -  " & objTabla.NomTabla
            If objTabla.FlagModifica = "A" Then 'A=Mant. Automatico M=Mant.Manual
                dglista.Columns(0).Visible = False
                dglista.Columns(8).Visible = False
                cmdGrabar.Visible = False
            End If
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTablaElemento.Cargar(Viewstate("CodTabla"))
        dglista.DataKeyField = "CodElemento"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTablaElemento.CodTabla = Viewstate("CodTabla")
        objTablaElemento.CodElemento = txtCodigo.Text
        objTablaElemento.NomEleEsp = txtNomEleEsp.Text
        objTablaElemento.NomEleIng = txtNomEleIng.Text
        objTablaElemento.NroOrden = txtNroOrden.Text
        objTablaElemento.CodUsuario = Session("CodUsuario")
        If rbActivo.Checked Then
            objTablaElemento.StsElemento = "A"
        Else
            objTablaElemento.StsElemento = "I"
        End If

        lblMsg.Text = objTablaElemento.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        lblMsg.Text = objTablaElemento.Borrar(Viewstate("CodTabla"), dglista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dglista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtNomEleEsp.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtNomEleIng.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim
        txtNroOrden.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim
        If dglista.Items(dglista.SelectedIndex).Cells(5).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dglista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dglista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub


End Class
