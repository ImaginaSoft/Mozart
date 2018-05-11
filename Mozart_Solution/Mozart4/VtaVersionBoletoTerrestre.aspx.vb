Imports cmpNegocio
Imports cmpTabla
Imports cmpRutinas
Imports System.Drawing
Imports System.Data

Partial Class VtaVersionBoletoTerrestre
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim ObjVersionDet As New clsVersionDet
    Dim ObjStsReserva As New clsStsReserva

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Estado Reserva de Boletos Transporte Terrestre - Versión N° " & ViewState("NroVersion")
            CargaBoletos()

            If ViewState("FlagEdita") = "N" Then
                cmdGrabar.Visible = False
                dgServicio.Columns(0).Visible = False
                lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar"
                lblMsg.CssClass = "msg"
                Return
            End If
        End If
    End Sub

    Private Sub CargaBoletos()
        Dim ds As New DataSet
        ds = ObjVersionDet.CargarBoletosTerrestre(ViewState("NroPedido"), ViewState("NroPropuesta"), ViewState("NroVersion"))
        dgServicio.DataSource = ds
        dgServicio.DataBind()
        dgServicio.SelectedItemStyle.Reset()

        lblNroServicio.Text = ""
        lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicios"
    End Sub

    Private Sub CargaStsReserva(ByVal pCodStsReserva As String)
        Dim ds As New DataSet
        ds = ObjStsReserva.Cargar
        ddlStsReserva.DataSource = ds
        ddlStsReserva.DataBind()
        If pCodStsReserva.Trim.Length > 0 Then
            ddlStsReserva.Items.FindByValue(pCodStsReserva).Selected = True
        End If
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If lblNroServicio.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar boleto"
            Return
        End If
        If ddlStsReserva.Items.Count() = 0 Then
            lblMsg.Text = "No existe estados de la reserva"
            Return
        End If
        If ddlStsReserva.SelectedItem.Value = "OK" Then
            'If txtCodReserva.Text.Trim.Length = 0 Then
            'lblMsg.Text = "Falta ingresar Código de Reserva"
            'Return
            'End If
            'If txtAerolinea.Text.Trim.Length = 0 Then
            'lblMsg.Text = "Falta ingresar Empresa"
            'Return
            'End If
            If txtNroVuelo.Text.Trim.Length = 0 Then
                lblMsg.Text = "Falta ingresar Nro boleto"
                Return
            End If
            'If txtRutaVuelo.Text.Trim.Length = 0 Then
            'lblMsg.Text = "Falta ingresar Ruta del boleto"
            'Return
            'End If
            If txtHoraSalida.Text.Trim.Length = 0 Then
                lblMsg.Text = "Falta ingresar Hora Salida"
                Return
            End If
            If txtHoraLlegada.Text.Trim.Length = 0 Then
                lblMsg.Text = "Falta ingresar Hora Llegada"
                Return
            End If
        End If

        ObjVersionDet.NroPedido = ViewState("NroPedido")
        ObjVersionDet.NroPropuesta = ViewState("NroPropuesta")
        ObjVersionDet.NroVersion = ViewState("NroVersion")
        ObjVersionDet.NroDia = lblNroDia.Text
        ObjVersionDet.NroOrden = lblNroOrden.Text
        ObjVersionDet.NroServicio = lblNroServicio.Text
        ObjVersionDet.CodStsReserva = ddlStsReserva.SelectedItem.Value
        '       ObjVersionDet.FchEmision = objRutina.fechayyyymmdd(txtFchEmision.Text)
        ObjVersionDet.FchEmision = Space(8) ' 09 Jun 2007 este dato no se debe digitar
        ObjVersionDet.CodReserva = ""
        ObjVersionDet.Aerolinea = txtAerolinea.Text
        ObjVersionDet.NroVuelo = txtNroVuelo.Text
        ObjVersionDet.FchVuelo = objRutina.fechayyyymmdd(txtFchVuelo.Text)
        ObjVersionDet.FchVuelo = objRutina.fechayyyymmdd(txtFchVuelo.Text)
        ObjVersionDet.RutaVuelo = txtRutaVuelo.Text
        ObjVersionDet.HoraLlegada = txtHoraLlegada.Text
        ObjVersionDet.HoraSalida = txtHoraSalida.Text
        ObjVersionDet.CodUsuario = Session("CodUsuario")
        lblMsg.Text = ObjVersionDet.GrabarBoletoReserva
        If lblMsg.Text.Trim = "OK" Then
            CargaBoletos()
            ddlStsReserva.Items.Clear()
            txtAerolinea.Text = ""
            txtNroVuelo.Text = ""
            txtFchVuelo.Text = ""
            txtRutaVuelo.Text = ""
            txtHoraLlegada.Text = ""
            txtHoraSalida.Text = ""
        End If
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & ViewState("NroPedido") & _
            "&NroPropuesta=" & ViewState("NroPropuesta") & _
            "&NroVersion=" & ViewState("NroVersion"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "OK" Or e.Item.Cells(5).Text.Trim = "OF" Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(2).ForeColor = Color.Red
                e.Item.Cells(3).ForeColor = Color.Red
                e.Item.Cells(4).ForeColor = Color.Red
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(9).Text
        lblNroServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(10).Text
        CargaStsReserva(dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text)
        'txtFchEmision.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(7).Text.Trim
        'txtCodReserva.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text.Trim

        txtAerolinea.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text.Trim
        txtNroVuelo.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text.Trim
        txtRutaVuelo.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(14).Text.Trim
        txtHoraSalida.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(15).Text.Trim
        txtHoraLlegada.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(16).Text.Trim

        If IsDBNull(dgServicio.Items(dgServicio.SelectedIndex).Cells(13).Text.Trim) Then
            txtFchVuelo.Text = ""
        ElseIf dgServicio.Items(dgServicio.SelectedIndex).Cells(13).Text.Trim = "&nbsp;" Then
            txtFchVuelo.Text = ""
        Else
            txtFchVuelo.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(13).Text.Trim
        End If

        'If txtCodReserva.Text.Trim = "&nbsp;" Then
        'txtCodReserva.Text = ""
        'End If

        If txtAerolinea.Text.Trim = "&nbsp;" Then
            txtAerolinea.Text = ""
        End If
        If txtNroVuelo.Text.Trim = "&nbsp;" Then
            txtNroVuelo.Text = ""
        End If
        If txtRutaVuelo.Text.Trim = "&nbsp;" Then
            txtRutaVuelo.Text = ""
        End If
        If txtHoraLlegada.Text.Trim = "&nbsp;" Then
            txtHoraLlegada.Text = ""
        End If
        If txtHoraSalida.Text.Trim = "&nbsp;" Then
            txtHoraSalida.Text = ""
        End If
    End Sub

    Private Sub Checkbox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox2.CheckedChanged
        txtFchVuelo.Text = ""
    End Sub


End Class
