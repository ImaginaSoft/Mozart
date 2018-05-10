Imports cmpRutinas
Imports cmpNegocio
Imports System.Drawing

Partial Class VtaVersionFicha
    Inherits System.Web.UI.Page
    Dim ObjRutina As New clsRutinas
    Dim objVersion As New clsVersion
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            LeeNroVersion()
            lblTitulo.Text = "Ficha de la Versión N° " & ViewState("NroVersion")
            CargaData()
        End If
    End Sub

    Private Sub LeeNroVersion()
        lblMsg.Text = objVersion.Editar(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            Viewstate("CodZonaVta") = objVersion.CodZonaVta
            Viewstate("FlagEdita") = objVersion.FlagEdita
            Viewstate("FlagPublica") = objVersion.FlagPublica
            Viewstate("StsVersion") = objVersion.StsVersion
            Viewstate("DesVersion") = objVersion.DesVersion
            Viewstate("CodCliente") = objVersion.CodCliente
            Viewstate("CodVendedor") = objVersion.CodVendedor

            Viewstate("EmailCliente") = Request.Params("EmailCliente")
        End If
    End Sub

    Private Sub CargaData()
        dgServicio.DataSource = objVersion.CargarVersionServicios(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        dgServicio.DataBind()
    End Sub

    Private Sub lbtServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicio.Click
        Response.Redirect("VtaVersionServicio.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLink.Click
        Response.Redirect("VtaVersionHotelReserva.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion") & _
        "&FlagPublica=" & Viewstate("FlagPublica") & _
        "&StsVersion=" & Viewstate("StsVersion") & _
        "&DesVersion=" & ucVersion1.DesVersion)
    End Sub

    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        If Viewstate("FlagEdita") = "N" Then
            lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar"
            Return
        End If
        If Viewstate("StsVersion") = "V" Then
            lblMsg.Text = "La Versión está Aprobado, esta pendiente de facturar"
            Return
        End If
        If Viewstate("StsVersion") = "F" Then
            lblMsg.Text = "La Versión ya está Facturado, no se puede modificar"
            Return
        End If
        If Viewstate("FlagPublica") = "S" Then
            lblMsg.Text = "La Versión está publicada, no se puede modificar"
            Return
        End If
        lblMsg.Text = objVersion.Borrar(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaPedidoFicha.aspx" & _
                             "?CodCliente=" & Viewstate("CodCliente") & _
                             "&NroPedido=" & Viewstate("NroPedido"))
        End If
    End Sub

    Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
        Response.Redirect("VtaVersionNueva.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtPublica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPublica.Click
        Response.Redirect("VtaVersionPublica.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)

    End Sub

    Private Sub lbtAprueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAprueba.Click
        Response.Redirect("VtaVersionAprueba.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)
    End Sub

    Private Sub lbtTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTareas.Click
        Response.Redirect("VtaVersionTareas.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&CodVendedor=" & Viewstate("CodVendedor") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion)
    End Sub

    Private Sub lbtHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistorial.Click
        Response.Redirect("VtaVersionHistorial.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion)
    End Sub

    Private Sub lbtEnviaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEnviaEmail.Click
        Response.Redirect("VtaVersionEmail.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion)
    End Sub

    Private Sub lbtPaginaPublicada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPaginaPublicada.Click
        'PRODUCCION actual
        'O = Origen es Mozart, se pasa este parametro para no grabar log
        'ID= Identificador de cliente, se pasa para no pedir clave

        Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
        Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
        Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
        Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")

        If Viewstate("CodZonaVta") = "PER" Then
            Response.Redirect(URL_perutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
            'Response.Redirect("http://penta/peru4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
        ElseIf Viewstate("CodZonaVta") = "ECU" Then
            Response.Redirect(URL_galapagostourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
            'Response.Redirect("http://penta/ecua4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
        ElseIf Viewstate("CodZonaVta") = "CHL" Then
            Response.Redirect(URL_chiletourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
            'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
        ElseIf Viewstate("CodZonaVta") = "GAY" Then
            Response.Redirect(URL_gayperutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
            'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
        End If
    End Sub

    Private Sub lbtReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReserva.Click
        Response.Redirect("VtaVersionReserva.aspx" & _
                        "?CodCliente=" & Viewstate("CodCliente") & _
                        "&NroPedido=" & Viewstate("NroPedido") & _
                        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub lbtNotaAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNotaAbono.Click
        Response.Redirect("cpcRegistraAbono.aspx" & _
                               "?NroPedido=" & Viewstate("NroPedido") & _
                                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                                "&NroVersion=" & Viewstate("NroVersion") & _
                                "&CodCliente=" & Viewstate("CodCliente") & _
                                "&NroDocumento=" & 0)
    End Sub

    Private Sub lbtNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNotaCargo.Click
        Response.Redirect("cpcRegistraCargo.aspx" & _
                               "?NroPedido=" & Viewstate("NroPedido") & _
                                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                                "&NroVersion=" & Viewstate("NroVersion") & _
                                "&CodCliente=" & Viewstate("CodCliente") & _
                                "&NroDocumento=" & 0)
    End Sub
    Private Sub lbtProveedorNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtProveedorNotaCargo.Click
        Response.Redirect("VtaVersionAjuste.aspx" & _
                               "?NroPedido=" & Viewstate("NroPedido") & _
                                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                                "&NroVersion=" & Viewstate("NroVersion") & _
                                "&Opcion=" & "Cargo" & _
                                "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub lbtProveedorNotaAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtProveedorNotaAbono.Click
        Response.Redirect("VtaVersionAjuste.aspx" & _
                               "?NroPedido=" & Viewstate("NroPedido") & _
                               "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                               "&NroVersion=" & Viewstate("NroVersion") & _
                               "&Opcion=" & "Abono" & _
                               "&CodCliente=" & Viewstate("CodCliente"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(13).Text.Trim = "S" Then
                e.Item.ForeColor = Color.Red
            End If
            If e.Item.Cells(11).Text.Trim = "OK" Or e.Item.Cells(11).Text.Trim = "OF" Then
                e.Item.Cells(11).ForeColor = Color.Blue
            Else
                e.Item.Cells(11).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub lbtBoletos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtBoletos.Click
        Response.Redirect("vtaVersionBoletoVta.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&StsVersion=" & ucVersion1.StsVersion)
    End Sub

    Private Sub lbtModificaDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificaDias.Click
        Response.Redirect("VtaVersionDias.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbkResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbkResumen.Click
        Response.Redirect("VtaVersionResumen.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lkbDesaprueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbDesaprueba.Click
        Response.Redirect("VtaVersionDesaprueba.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)
    End Sub

    Private Sub lbtDocAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDocAjuste.Click
        Response.Redirect("VtaVersionAjusteDoc.aspx" & _
        "?CodCliente=" & Viewstate("CodCliente") & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)
    End Sub

    Private Sub lbtHistProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistProveedor.Click
        Response.Redirect("VtaPedidoHistProveedor.aspx" & _
           "?NroPedido=" & Viewstate("NroPedido") & _
           "&CodCliente=" & Viewstate("CodCliente") & _
           "&opcion=1")
    End Sub

    Private Sub lbtPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrecio.Click
        Response.Redirect("VtaVersionPrecio.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtModificaLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificaLink.Click
        Response.Redirect("VtaVersionLink.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)
    End Sub

    Private Sub lbtCambiarHotel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarHotel.Click
        Response.Redirect("VtaVersionCambiarHotel.aspx" & _
        "?&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEspecificacion.Click
        Response.Redirect("VtaVersionEspeci.aspx" & _
        "?&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtExcluirReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtExcluirReserva.Click
        Response.Redirect("VtaVersionCambiarStatus.aspx" & _
        "?&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtReservaBoleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReservaBoleto.Click
        Response.Redirect("VtaVersionBoletoReserva.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion") & _
        "&FlagPublica=" & Viewstate("FlagPublica") & _
        "&StsVersion=" & Viewstate("StsVersion") & _
        "&DesVersion=" & ucVersion1.DesVersion)
    End Sub

    Private Sub lbtDiaOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDiaOrden.Click
        Response.Redirect("VtaVersionCambiarOrden.aspx" & _
        "?&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Private Sub lbtPrintPagina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrintPagina.Click
        Response.Redirect("vtaVersionPrint.aspx" & _
        "?&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagIdioma=" & ucVersion1.FlagIdioma & _
        "&Cliente=" & ucVersion1.Cliente)
    End Sub

    Private Sub lbtCreaCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCreaCopia.Click
        lblMsg.Text = objVersion.Copia(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaClienteVersion.aspx" & _
                            "?CodCliente=" & Viewstate("CodCliente") & _
                            "&EmailCliente=" & Viewstate("EmailCliente"))
        End If
    End Sub

    Private Sub lbtCambiarHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarHora.Click
        Response.Redirect("VtaVersionCambiarHora.aspx" & _
            "?&NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & ucVersion1.NroVersion & _
            "&FlagEdita=" & Viewstate("FlagEdita"))
    End Sub

    Protected Sub lbtReservaBoletoTren_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtReservaBoletoTren.Click
        Response.Redirect("VtaVersionBoletoTerrestre.aspx" & _
        "?NroPedido=" & ViewState("NroPedido") & _
        "&NroPropuesta=" & ViewState("NroPropuesta") & _
        "&NroVersion=" & ViewState("NroVersion") & _
        "&FlagPublica=" & ViewState("FlagPublica") & _
        "&StsVersion=" & ViewState("StsVersion") & _
        "&DesVersion=" & ucVersion1.DesVersion)

    End Sub


    Protected Sub lbtTrasladarBoletoAereo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtTrasladarBoletoAereo.Click
        Response.Redirect("VtaVersionTrasladoBoleto.aspx" & _
        "?NroPedido=" & ViewState("NroPedido") & _
        "&NroPropuesta=" & ViewState("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion)

    End Sub

    Protected Sub lbtIncidencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtIncidencia.Click
        Response.Redirect("VtaVersionIncidencia.aspx" & _
        "?&NroPedido=" & ViewState("NroPedido") & _
        "&NroPropuesta=" & ViewState("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&FlagEdita=" & ViewState("FlagEdita"))

    End Sub

    Protected Sub lbtVuelosInter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtVuelosInter.Click
        If ViewState("StsVersion") <> "F" Then
            lblMsg.Text = "Opción válida para versión facturada"
            Return
        End If


        Response.Redirect("VtaVersionServicioVuelosInter.aspx" & _
        "?NroPedido=" & ViewState("NroPedido") & _
        "&NroPropuesta=" & ViewState("NroPropuesta") & _
        "&NroVersion=" & ucVersion1.NroVersion & _
        "&DesVersion=" & ucVersion1.DesVersion & _
        "&FlagPublica=" & ucVersion1.FlagPublica & _
        "&StsVersion=" & ucVersion1.StsVersion & _
        "&FlagEdita=" & ViewState("FlagEdita"))

    End Sub
End Class
