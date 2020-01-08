Imports cmpNegocio
Imports System.Data

Partial Class VtaServicioTarifaPeriodo
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objTarifaPeriodo As New cmpNegocio.clsTarifaPeriodo
    Dim objServicio As New clsServicio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblNomProveedor.Text = Request.Params("NomProveedor")
            lblNomCiudad.Text = Request.Params("NomCiudad")
            lblTipoServicio.Text = Request.Params("TipoServicio")
            ViewState("NroServicio") = Request.Params("NroServicio")
            LeeServicio()
            'lblDesServicio.Text = ViewState("NroServicio") & " " & Request.Params("DesServicio")
            CargaDatos()
        End If
    End Sub

    Private Sub LeeServicio()
        lblMsg.Text = objServicio.Editar(ViewState("NroServicio"), "")
        If lblMsg.Text.Trim = "OK" Then
            lblDesServicio.Text = ViewState("NroServicio") & " " & objServicio.DesProveedor
        End If
    End Sub


    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTarifaPeriodo.Cargar(ViewState("NroServicio"), Session("CodUsuario"))
        dgLista.DataKeyField = "CodTarifa"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count()) + " Periodo(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTarifaPeriodo.NroServicio = ViewState("NroServicio")
        objTarifaPeriodo.CodTarifa = txtCodTarifa.Text
        objTarifaPeriodo.FchIniPeriodo = objRutina.fechayyyymmdd(txtFchInicial.Text)
        objTarifaPeriodo.FchFinPeriodo = objRutina.fechayyyymmdd(txtFchFinal.Text)
        objTarifaPeriodo.DesTarifa = txtDesTarifa.Text
        objTarifaPeriodo.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTarifaPeriodo.Grabar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.CssClass = "Msg"
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        txtCodTarifa.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text.Trim
        txtFchInicial.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim
        txtFchFinal.Text = dgLista.Items(dgLista.SelectedIndex).Cells(3).Text.Trim
        txtDesTarifa.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text.Trim
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objTarifaPeriodo.Borrar(ViewState("NroServicio"), dgLista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub lbtTarifas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTarifas.Click
        Response.Redirect("VtaServicioTarifa.aspx" & _
            "?NroServicio=" & ViewState("NroServicio") & _
            "&OpcionLink=S")
    End Sub



End Class
