Imports cmpTabla
Imports System.Data

Partial Class tabTipoInformacionDet
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTipoInformacion As New clsTipoInformacion
    Dim objInformacion As New clsInformacion
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroTipoInf") = Request.Params("NroTipoInf")
            lblTitulo.Text = "Tipo de Informacion N° " & Viewstate("NroTipoInf")

            lblMsg.Text = objTipoInformacion.Editar(Viewstate("NroTipoInf"))
            If lblMsg.Text.Trim = "OK" Then
                lblTitulo.Text = lblTitulo.Text & " " & objTipoInformacion.NomTipoInfEsp
            End If
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objInformacion.Cargar(Viewstate("NroTipoInf"))
        dglista.DataKeyField = "NroInformacion"
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
        If rbActivo.Checked Then
            objInformacion.StsInf = "A"
        Else
            objInformacion.StsInf = "I"
        End If

        If rbZonaVta.Checked Then
            objInformacion.NivelInf = "Z"
        ElseIf rbCiudad.Checked Then
            objInformacion.NivelInf = "C"
        Else
            objInformacion.NivelInf = "S"
        End If

        objInformacion.NroInformacion = txtCodigo.Text
        objInformacion.NomInfEsp = txtNombreEsp.Text
        objInformacion.NomInfIng = txtNombreIng.Text
        objInformacion.NomInfPor = txtNombrePor.Text
        objInformacion.NroTipoInf = ViewState("NroTipoInf")
        objInformacion.NroOrden = txtNroOrden.Text
        objInformacion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objInformacion.Grabar()
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
        lblMsg.Text = objInformacion.Borrar(dglista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub



    Private Sub rbZonaVta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbZonaVta.CheckedChanged
        rbZonaVta.Checked = True
        rbCiudad.Checked = False
        rbServicio.Checked = False

    End Sub

    Private Sub rbCiudad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCiudad.CheckedChanged
        rbZonaVta.Checked = False
        rbCiudad.Checked = True
        rbServicio.Checked = False

    End Sub

    Private Sub rbServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbServicio.CheckedChanged
        rbZonaVta.Checked = False
        rbCiudad.Checked = False
        rbServicio.Checked = True
    End Sub

    Private Sub dglista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtNombreEsp.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtNombreIng.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim
        txtNombrePor.Text = dglista.Items(dglista.SelectedIndex).Cells(8).Text.Trim
        rbZonaVta.Checked = False
        rbCiudad.Checked = False
        rbServicio.Checked = False

        If dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim = "ZonaVta" Then
            rbZonaVta.Checked = True
        ElseIf dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim = "Ciudad" Then
            rbCiudad.Checked = True
        Else
            rbServicio.Checked = True
        End If
        txtNroOrden.Text = dglista.Items(dglista.SelectedIndex).Cells(5).Text.Trim
        If dglista.Items(dglista.SelectedIndex).Cells(6).Text.Trim = "Inactivo" Then
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
