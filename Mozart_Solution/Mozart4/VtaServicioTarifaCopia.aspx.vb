Imports cmpNegocio
Imports System.Data

Partial Class VtaServicioTarifaCopia
    Inherits System.Web.UI.Page
    Dim objTarifa As New cmpNegocio.clsTarifa
    Dim objTarifaPeriodo As New cmpNegocio.clsTarifaPeriodo
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroServicio") = Request.Params("NroServicio")

            lblNroServicioOrigen.Text = ViewState("NroServicio")
            lblNomProveedorOrigen.Text = Request.Params("NomProveedor")
            lblNomCiudadOrigen.Text = Request.Params("NomCiudad")
            lblTipoServicioOrigen.Text = Request.Params("TipoServicio")
            lblDesServicioOrigen.Text = Request.Params("DesServicio")

            txtNroServicioDestino.Text = ViewState("NroServicio")
            lblNomProveedorDestino.Text = Request.Params("NomProveedor")
            lblNomCiudadDestino.Text = Request.Params("NomCiudad")
            lblTipoServicioDestino.Text = Request.Params("TipoServicio")
            lblDesServicioDestino.Text = Request.Params("DesServicio")

            CargaPeriodos()
        End If
    End Sub

    Private Sub CargaPeriodos()
        Dim ds As New DataSet
        ds = objTarifaPeriodo.CargarDDL(Viewstate("NroServicio"), Session("CodUsuario"))
        ddlTarifaPeriodoOrigen.DataSource = ds.Tables(0)
        ddlTarifaPeriodoOrigen.DataBind()

        ddlTarifaPeriodoDestino.DataSource = ds.Tables(0)
        ddlTarifaPeriodoDestino.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If txtNroServicioDestino.Text.Trim = "" Then
            limpia()
            lblMsg.Text = "N° Servicio destino es obligatorio"
            Return
        End If
        If Not IsNumeric(txtNroServicioDestino.Text) Then
            limpia()
            lblMsg.Text = "N° Servicio es númerico"
            Return
        End If
        If ddlTarifaPeriodoOrigen.Items.Count = 0 Then
            lblMsg.Text = "Periodo de origen es obligatorio"
            Return
        End If
        Dim iCodTarifaDestino As Integer
        If ddlTarifaPeriodoDestino.Items.Count = 0 Then
            iCodTarifaDestino = 0
        Else
            iCodTarifaDestino = ddlTarifaPeriodoDestino.SelectedValue
        End If
        lblMsg.Text = objTarifa.CopiaTarifas(lblNroServicioOrigen.Text, ddlTarifaPeriodoOrigen.SelectedValue, txtNroServicioDestino.Text, iCodTarifaDestino, Session("CodUsuario"))
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaServicioTarifa.aspx" & _
                        "?NroServicio=" & txtNroServicioDestino.Text & _
                        "&OpcionLink=S")
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub lbtTarifas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTarifas.Click
        Response.Redirect("VtaServicioTarifa.aspx" & _
            "?NroServicio=" & ViewState("NroServicio") & _
            "&OpcionLink=S")
    End Sub

    Private Sub ddlTarifaPeriodoOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTarifaPeriodoOrigen.SelectedIndexChanged
        lblMsg.Text = ""
    End Sub

    Private Sub ddlTarifaPeriodoDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTarifaPeriodoDestino.SelectedIndexChanged
        lblMsg.Text = ""
    End Sub

    Private Sub txtNroServicioDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroServicioDestino.TextChanged
        If txtNroServicioDestino.Text.Trim = "" Then
            lblMsg.Text = "N° Servicio destino es obligatorio"
            limpia()
            Return
        End If
        If Not IsNumeric(txtNroServicioDestino.Text) Then
            lblMsg.Text = "N° Servicio es númerico"
            limpia()
            Return
        End If

        ddlTarifaPeriodoDestino.DataSource = objTarifaPeriodo.CargarDDL(txtNroServicioDestino.Text, Session("CodUsuario"))
        ddlTarifaPeriodoDestino.DataBind()

        Dim objServicio As New clsServicio
        lblMsg.Text = objServicio.Editar(txtNroServicioDestino.Text, "")
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblNomProveedorDestino.Text = objServicio.NomProveedor
            lblNomCiudadDestino.Text = objServicio.NomCiudad
            lblTipoServicioDestino.Text = objServicio.TipoServicio
            lblDesServicioDestino.Text = objServicio.DesProveedor
        Else
            limpia()
        End If
    End Sub

    Private Sub limpia()
        lblNomProveedorDestino.Text = ""
        lblNomCiudadDestino.Text = ""
        lblTipoServicioDestino.Text = ""
        lblDesServicioDestino.Text = ""

    End Sub

End Class
