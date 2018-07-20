Imports cmpSeguridad
Imports cmpNegocio
Imports cmpTabla
Imports cmpRutinas
Imports System.Drawing
Imports System.Data

Partial Class VtaServicioTarifa
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim objServicio As New clsServicio
    Dim objTipoAcomodacion As New clsTipoAcomodacion
    Dim objTipoPasajero As New clsTipoPasajero
    Dim objTipoHab As New clsTipoHabitacion
    Dim objTarifaPeriodo As New clsTarifaPeriodo
    Dim objTarifa As New clsTarifa

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT030505") <> "X" Then
                cmbGrabar.Visible = False
                dgTarifas.Columns(6).Visible = False
                lbtEliminarall.Visible = False
                lbtPeriodoTarifa.Visible = False
                lbtCopiaTarifas.Visible = False
            End If
            If Request.Params("OpcionLink") <> "S" Then
                ' Cuando el sistema no es Mozart y viene desde una consulta de propuesta o version
                lbtServicios.Visible = False
            End If
            Viewstate("NroServicio") = Request.Params("NroServicio")
            LeeServicio()
            lblNroServicio.Text = Viewstate("NroServicio")
            lblDesServicio.Text = Viewstate("Titulo")
            CargaTarifaRango()
            CargaTipoAcomodacion(0)
            CargaDatos()
        End If
    End Sub

    Private Sub LeeServicio()
        lblMsg.Text = objServicio.Editar(ViewState("NroServicio"), "")
        If lblMsg.Text.Trim = "OK" Then
            Viewstate("Titulo") = objServicio.DesProveedor
            Viewstate("CodProveedor") = objServicio.CodProveedor
            Viewstate("CodCiudad") = objServicio.CodCiudad
            Viewstate("CodTipoServicio") = objServicio.CodTipoServicio
            Viewstate("FlagValoriza") = objServicio.FlagValoriza
            lblNomProveedor.Text = objServicio.NomProveedor
            lblNomCiudad.Text = objServicio.NomCiudad
            lblTipoServicio.Text = objServicio.TipoServicio

            If Viewstate("CodTipoServicio") = 2 Then
                lblDesde.Text = "Nro Habitaciones "
                lblSubTipo.Visible = True
                ddlSubTipo.Visible = True
                CargaTipoHabitacion("")
                If objServicio.FlagValoriza = "T" Then
                    lblTipoPasajero.Visible = True
                    ddltipopasajero.Visible = True
                    CargaTipoPasajero("")
                    lblDesde.Text = "Rango"
                Else
                    Label10.Text = "Tarifa neta x Habitación US$"
                    lblHasta.Visible = False
                    txtInicio.Enabled = False
                    txtFin.Visible = False
                    txtInicio.Text = 1
                    txtFin.Text = 1
                End If
            Else
                CargaTipoPasajero("")
                lblTipoPasajero.Visible = True
                ddltipopasajero.Visible = True
            End If
        End If
    End Sub

    Private Sub CargaTipoAcomodacion(ByVal pCodTipoAcomodacion As Integer)
        Dim ds As New DataSet
        ds = objTipoAcomodacion.CargarDDL(Viewstate("CodTipoServicio"))
        ddlTipoAcomodacion.DataSource = ds.Tables(0)
        ddlTipoAcomodacion.DataBind()
        Try
            ddlTipoAcomodacion.Items.FindByValue(pCodTipoAcomodacion).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaTipoPasajero(ByVal pCodTipoPasajero As String)
        Dim ds As New DataSet
        ds = objTipoPasajero.CargarDDL()
        ddltipopasajero.DataSource = ds.Tables(0)
        ddltipopasajero.DataBind()
        Try
            ddltipopasajero.Items.FindByValue(pCodTipoPasajero).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaTipoHabitacion(ByVal pCodTipoHab As String)
        Dim ds As New DataSet
        ds = objTipoHab.CargarDDL()
        ddlSubTipo.DataSource = ds.Tables(0)
        ddlSubTipo.DataBind()
        Try
            ddlSubTipo.Items.FindByValue(pCodTipoHab).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaTarifaRango()
        Dim ds As New DataSet
        ds = objTarifaPeriodo.CargarDDL(Viewstate("NroServicio"), Session("CodUsuario"))
        ddlTarifaPeriodo.DataSource = ds.Tables(0)
        ddlTarifaPeriodo.DataBind()
    End Sub

    Private Sub CargaDatos()
        Dim iCodTarifa As Integer = 0
        If ddlTarifaPeriodo.Items.Count > 0 Then
            iCodTarifa = ddlTarifaPeriodo.SelectedValue
        End If
        Dim ds As New DataSet
        ds = objTarifa.Carga(Viewstate("NroServicio"), iCodTarifa)
        dgTarifas.DataKeyField = "KeyReg"
        dgTarifas.DataSource = ds.Tables(0)
        dgTarifas.DataBind()
        lblMsg.Text = CStr(dgTarifas.Items.Count) + " Tarifa(s) encontrada(s)"
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblMsg.Text = ""
        If txtTarifa.Text.Trim.Length = 0 Then
            lblMsg.Text = "Tarifa es dato obligatorio"
            Return
        ElseIf Not IsNumeric(txtTarifa.Text) Then
            lblMsg.Text = "Tarifa es dato númerico"
            Return
        End If
        If txtInicio.Text.Trim.Length = 0 Then
            lblMsg.Text = "Nro. Personas desde es obligatorio"
            Return
        ElseIf Not IsNumeric(txtInicio.Text) Then
            lblMsg.Text = "Nro. Personas desde es númerico"
            Return
        End If
        If txtFin.Text.Trim.Length = 0 Then
            lblMsg.Text = "Nro. Personas hasta es obligatorio"
            Return
        ElseIf Not IsNumeric(txtFin.Text) Then
            lblMsg.Text = "Nro. Personas hasta es númerico"
            Return
        End If
        If ddlTipoAcomodacion.Items.Count = 0 Then
            lblMsg.Text = "Tipo acomodación es obligatorio"
            Return
        End If
        If ddlTarifaPeriodo.Items.Count = 0 Then
            lblMsg.Text = "Periodo de tarifa es obligatorio"
            Return
        End If
        Dim sCodSubTipo As String
        If ddlSubTipo.Items.Count = 0 Then
            sCodSubTipo = ""
        Else
            sCodSubTipo = ddlSubTipo.SelectedValue
        End If
        Dim sCodTipoPasajero As String
        If ddltipopasajero.Items.Count = 0 Then
            sCodTipoPasajero = ""
        Else
            sCodTipoPasajero = ddltipopasajero.SelectedItem.Value
        End If

        objTarifa.NroServicio = Viewstate("NroServicio")
        objTarifa.CodTipoAcomodacion = ddlTipoAcomodacion.SelectedItem.Value
        objTarifa.CodTipoPasajero = sCodTipoPasajero
        objTarifa.CodSubTipo = sCodSubTipo
        objTarifa.CodTarifa = ddlTarifaPeriodo.SelectedValue
        objTarifa.RangoTarifaIni = txtInicio.Text
        objTarifa.RangoTarifaFin = txtFin.Text
        objTarifa.TarifaNeta = txtTarifa.Text
        objTarifa.CodTipoServicio = Viewstate("CodTipoServicio")
        objTarifa.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTarifa.Grabar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgTarifas_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTarifas.DeleteCommand
        objTarifa.NroServicio = Viewstate("NroServicio")
        objTarifa.CodTipoAcomodacion = Mid(dgTarifas.DataKeys(e.Item.ItemIndex), 1, 4)
        objTarifa.CodTipoPasajero = Mid(dgTarifas.DataKeys(e.Item.ItemIndex), 5, 1)
        objTarifa.CodSubTipo = Mid(dgTarifas.DataKeys(e.Item.ItemIndex), 6, 1)
        objTarifa.CodTarifa = ddlTarifaPeriodo.SelectedValue
        objTarifa.RangoTarifa = Mid(dgTarifas.DataKeys(e.Item.ItemIndex), 7, 4)
        lblMsg.Text = objTarifa.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If

    End Sub

    Private Sub lbtEliminarAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminarall.Click
        objTarifa.NroServicio = Viewstate("NroServicio")
        objTarifa.CodTarifa = ddlTarifaPeriodo.SelectedValue
        lblMsg.Text = objTarifa.BorrarAll
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaServicioBusca.aspx" & _
                "?Opcion=Lista" & _
                "&CodProveedor=" & Viewstate("CodProveedor") & _
                "&CodCiudad=" & Viewstate("CodCiudad") & _
               "&CodTipoServicio=" & Viewstate("CodTipoServicio"))
    End Sub

    Private Sub ddlTarifaPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTarifaPeriodo.SelectedIndexChanged
        CargaDatos()
    End Sub

    Private Sub lbtPeriodoTarifa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPeriodoTarifa.Click
        Response.Redirect("VtaServicioTarifaPeriodo.aspx" & _
                "?NomProveedor=" & lblNomProveedor.Text & _
                "&NomCiudad=" & lblNomCiudad.Text & _
                "&TipoServicio=" & lblTipoServicio.Text & _
                "&NroServicio=" & Viewstate("NroServicio"))
        '"&DesServicio=" & lblDesServicio.Text & _
    End Sub

    Private Sub dgTarifas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTarifas.SelectedIndexChanged
        CargaTipoAcomodacion(dgTarifas.Items(dgTarifas.SelectedIndex).Cells(10).Text)
        If Viewstate("CodTipoServicio") = 2 Then
            CargaTipoHabitacion(dgTarifas.Items(dgTarifas.SelectedIndex).Cells(12).Text.Trim)
            If Viewstate("FlagValoriza") = "T" Then
                CargaTipoPasajero(dgTarifas.Items(dgTarifas.SelectedIndex).Cells(11).Text.Trim)
            End If
        Else
            CargaTipoPasajero(dgTarifas.Items(dgTarifas.SelectedIndex).Cells(11).Text.Trim)
        End If

        txtInicio.Text = dgTarifas.Items(dgTarifas.SelectedIndex).Cells(4).Text
        txtFin.Text = dgTarifas.Items(dgTarifas.SelectedIndex).Cells(4).Text
        txtTarifa.Text = dgTarifas.Items(dgTarifas.SelectedIndex).Cells(5).Text.Trim
    End Sub

    Private Sub lbtCopiaTarifas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCopiaTarifas.Click
        Response.Redirect("VtaServicioTarifaCopia.aspx" & _
        "?NomProveedor=" & lblNomProveedor.Text.Trim & _
        "&NomCiudad=" & lblNomCiudad.Text.Trim & _
        "&TipoServicio=" & lblTipoServicio.Text.Trim & _
        "&DesServicio=" & lblDesServicio.Text.Trim & _
        "&NroServicio=" & ViewState("NroServicio"))
    End Sub

    Private Sub dgTarifas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTarifas.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            If e.Item.Cells(13).Text > 0 Then
                e.Item.Cells(8).BackColor = Color.PaleGreen
            End If
        End If

    End Sub
End Class
