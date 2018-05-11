Imports cmpTabla
Imports cmpRutinas
Imports System.Data

Partial Class TabTipoCambio
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTipoCambio As New clsTipoCambio
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblTitulo.Text = "Tipo Cambio"
            CargaAno()
            CargaMes()
        End If
    End Sub
    Private Sub CargaAno()
        Dim objAnoProceso As New clsAnoProceso
        ddlAno.DataSource = objAnoProceso.Cargar
        ddlAno.DataBind()
        Dim iAno As Integer = Year(Now)
        Try
            ddlAno.Items.FindByValue(iAno).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaMes()
        Dim objTablaElemento As New clsTablaElemento
        ddlMes.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(9, "E")
        ddlMes.DataBind()
        Dim iMes As Integer = Month(Now)
        Try
            ddlMes.Items.FindByValue(iMes).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        dglista.DataKeyField = "Fecha"
        dglista.DataSource = objTipoCambio.CargaxMesAno(ddlAno.SelectedValue, ddlMes.SelectedValue)
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Registro(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTipoCambio.Fecha = objRutina.fechayyyymmdd(txtFchPedido.Text)
        objTipoCambio.TipoCambioVta = txtTipoCambioVta.Text
        objTipoCambio.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoCambio.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub


    Private Sub dglista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtFchPedido.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtTipoCambioVta.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
    End Sub

    Private Sub cmdBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBusca.Click
        CargaDatos()
    End Sub

    Private Sub dglista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        lblMsg.Text = objTipoCambio.Borrar(objRutina.fechayyyymmdd(dglista.DataKeys(e.Item.ItemIndex)))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub


End Class
