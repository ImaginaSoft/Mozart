Imports cmpRutinas
Imports cmpNegocio
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions

Partial Class VtaVersionFicha
	Inherits System.Web.UI.Page
	Dim cn As New SqlConnection(ConfigurationManager.AppSettings("cnMozart"))
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
			OcultarBotonMigrarGG()
		End If
	End Sub

	Private Sub LeeNroVersion()
		lblMsg.Text = objVersion.Editar(ViewState("NroPedido"), ViewState("NroPropuesta"), ViewState("NroVersion"))
		If lblMsg.Text.Trim = "OK" Then
			lblMsg.Text = ""
			ViewState("CodZonaVta") = objVersion.CodZonaVta
			ViewState("FlagEdita") = objVersion.FlagEdita
			ViewState("FlagPublica") = objVersion.FlagPublica
			ViewState("StsVersion") = objVersion.StsVersion
			ViewState("DesVersion") = objVersion.DesVersion
			ViewState("CodCliente") = objVersion.CodCliente
			ViewState("CodVendedor") = objVersion.CodVendedor

			ViewState("EmailCliente") = Request.Params("EmailCliente")
		End If
	End Sub

	Private Sub CargaData()
		dgServicio.DataSource = objVersion.CargarVersionServicios(ViewState("NroPedido"), ViewState("NroPropuesta"), ViewState("NroVersion"))
		dgServicio.DataBind()
	End Sub

	Private Sub lbtServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicio.Click
		Response.Redirect("VtaVersionServicio.aspx" & _
		"?NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion & _
		"&FlagPublica=" & ucVersion1.FlagPublica & _
		"&StsVersion=" & ucVersion1.StsVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLink.Click
		Response.Redirect("VtaVersionHotelReserva.aspx" & _
		"?NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ViewState("NroVersion") & _
		"&FlagPublica=" & ViewState("FlagPublica") & _
		"&StsVersion=" & ViewState("StsVersion") & _
		"&DesVersion=" & ucVersion1.DesVersion)
	End Sub

	Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
		If ViewState("FlagEdita") = "N" Then
			lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar"
			Return
		End If
		If ViewState("StsVersion") = "V" Then
			lblMsg.Text = "La Versión está Aprobado, esta pendiente de facturar"
			Return
		End If
		If ViewState("StsVersion") = "F" Then
			lblMsg.Text = "La Versión ya está Facturado, no se puede modificar"
			Return
		End If
		If ViewState("FlagPublica") = "S" Then
			lblMsg.Text = "La Versión está publicada, no se puede modificar"
			Return
		End If
		lblMsg.Text = objVersion.Borrar(ViewState("NroPedido"), ViewState("NroPropuesta"), ViewState("NroVersion"))
		If lblMsg.Text.Trim = "OK" Then
			Response.Redirect("VtaPedidoFicha.aspx" & _
							 "?CodCliente=" & ViewState("CodCliente") & _
							 "&NroPedido=" & ViewState("NroPedido"))
		End If
	End Sub

	Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
		Response.Redirect("VtaVersionNueva.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion & _
		"&FlagPublica=" & ucVersion1.FlagPublica & _
		"&StsVersion=" & ucVersion1.StsVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtPublica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPublica.Click
		Response.Redirect("VtaVersionPublica.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion)

	End Sub

	Private Sub lbtAprueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtAprueba.Click
		Response.Redirect("VtaVersionAprueba.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion)
	End Sub

	Private Sub lbtTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTareas.Click
		Response.Redirect("VtaVersionTareas.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&CodVendedor=" & ViewState("CodVendedor") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion)
	End Sub

	Private Sub lbtHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistorial.Click
		Response.Redirect("VtaVersionHistorial.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion)
	End Sub

	Private Sub lbtEnviaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEnviaEmail.Click
		Response.Redirect("VtaVersionEmail.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
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
		Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")

		If ViewState("CodZonaVta") = "PER" Then
			Response.Redirect(URL_perutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
			'Response.Redirect(URL_perutourism & "/" & ucVersion1.IDCliente)


			'Dim URL As String = URL_perutourism & "/" & ucVersion1.IDCliente
			'Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")


			'Response.Redirect("http://penta/peru4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
		ElseIf ViewState("CodZonaVta") = "ECU" Then
			'Dim URL As String = URL_perutourism & "/" & ucVersion1.IDCliente
			'Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

			Response.Redirect(URL_galapagostourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
			'Response.Redirect("http://penta/ecua4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
		ElseIf ViewState("CodZonaVta") = "CHL" Then

			'Dim URL As String = URL_perutourism & "/" & ucVersion1.IDCliente
			'Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
			Response.Redirect(URL_chiletourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
			'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
		ElseIf ViewState("CodZonaVta") = "GAY" Then
			'Dim URL As String = URL_perutourism & "/" & ucVersion1.IDCliente
			'Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
			Response.Redirect(URL_gayperutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
			'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
		ElseIf ViewState("CodZonaVta") = "LAJ" Then
			'Dim URL As String = URL_perutourism & "/" & ucVersion1.IDCliente
			'Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
			Response.Redirect(URL_latajourneys & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
		End If
	End Sub

	'Private Sub lbtPaginaPublicadaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPaginaPublicadaNew.Click
	'    'PRODUCCION actual
	'    'O = Origen es Mozart, se pasa este parametro para no grabar log
	'    'ID= Identificador de cliente, se pasa para no pedir clave

	'    Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
	'    Dim URL_perutourism_new As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism_new")

	'    Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
	'    Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
	'    Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")
	'    Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")

	'    If ViewState("CodZonaVta") = "PER" Then
	'        'Response.Redirect(URL_perutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
	'        'Response.Redirect(URL_perutourism & "/" & ucVersion1.IDCliente)


	'        Dim URL As String = URL_perutourism_new & "/" & ucVersion1.IDCliente
	'        Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")


	'        'Response.Redirect("http://penta/peru4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
	'    ElseIf ViewState("CodZonaVta") = "ECU" Then
	'        Dim URL As String = URL_perutourism_new & "/" & ucVersion1.IDCliente
	'        Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

	'        'Response.Redirect(URL_galapagostourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
	'        'Response.Redirect("http://penta/ecua4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
	'    ElseIf ViewState("CodZonaVta") = "CHL" Then

	'        Dim URL As String = URL_perutourism_new & "/" & ucVersion1.IDCliente
	'        Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
	'        'Response.Redirect(URL_chiletourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
	'        'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
	'    ElseIf ViewState("CodZonaVta") = "GAY" Then
	'        Dim URL As String = URL_perutourism_new & "/" & ucVersion1.IDCliente
	'        Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
	'        'Response.Redirect(URL_gayperutourism & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
	'        'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucVersion1.IDCliente)
	'    ElseIf ViewState("CodZonaVta") = "LAJ" Then
	'        Dim URL As String = URL_perutourism_new & "/" & ucVersion1.IDCliente
	'        Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")
	'        'Response.Redirect(URL_latajourneys & "/ilogin.aspx?O=M&ID=" & ucVersion1.IDCliente)
	'    End If
	'End Sub


	Private Sub lbtReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReserva.Click
		Response.Redirect("VtaVersionReserva.aspx" & _
						"?CodCliente=" & ViewState("CodCliente") & _
						"&NroPedido=" & ViewState("NroPedido") & _
						"&NroPropuesta=" & ViewState("NroPropuesta") & _
						"&NroVersion=" & ViewState("NroVersion"))
	End Sub

	Private Sub lbtNotaAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNotaAbono.Click
		Response.Redirect("cpcRegistraAbono.aspx" & _
							   "?NroPedido=" & ViewState("NroPedido") & _
								"&NroPropuesta=" & ViewState("NroPropuesta") & _
								"&NroVersion=" & ViewState("NroVersion") & _
								"&CodCliente=" & ViewState("CodCliente") & _
								"&NroDocumento=" & 0)
	End Sub

	Private Sub lbtNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNotaCargo.Click
		Response.Redirect("cpcRegistraCargo.aspx" & _
							   "?NroPedido=" & ViewState("NroPedido") & _
								"&NroPropuesta=" & ViewState("NroPropuesta") & _
								"&NroVersion=" & ViewState("NroVersion") & _
								"&CodCliente=" & ViewState("CodCliente") & _
								"&NroDocumento=" & 0)
	End Sub
	Private Sub lbtProveedorNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtProveedorNotaCargo.Click
		Response.Redirect("VtaVersionAjuste.aspx" & _
							   "?NroPedido=" & ViewState("NroPedido") & _
								"&NroPropuesta=" & ViewState("NroPropuesta") & _
								"&NroVersion=" & ViewState("NroVersion") & _
								"&Opcion=" & "Cargo" & _
								"&CodCliente=" & ViewState("CodCliente"))
	End Sub

	Private Sub lbtProveedorNotaAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtProveedorNotaAbono.Click
		Response.Redirect("VtaVersionAjuste.aspx" & _
							   "?NroPedido=" & ViewState("NroPedido") & _
							   "&NroPropuesta=" & ViewState("NroPropuesta") & _
							   "&NroVersion=" & ViewState("NroVersion") & _
							   "&Opcion=" & "Abono" & _
							   "&CodCliente=" & ViewState("CodCliente"))
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
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&StsVersion=" & ucVersion1.StsVersion)
	End Sub

	Private Sub lbtModificaDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificaDias.Click
		Response.Redirect("VtaVersionDias.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion & _
		"&FlagPublica=" & ucVersion1.FlagPublica & _
		"&StsVersion=" & ucVersion1.StsVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbkResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbkResumen.Click
		Response.Redirect("VtaVersionResumen.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion & _
		"&FlagPublica=" & ucVersion1.FlagPublica & _
		"&StsVersion=" & ucVersion1.StsVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lkbDesaprueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbDesaprueba.Click
		Response.Redirect("VtaVersionDesaprueba.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion)
	End Sub

	Private Sub lbtDocAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDocAjuste.Click
		Response.Redirect("VtaVersionAjusteDoc.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion)
	End Sub

	Private Sub lbtHistProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistProveedor.Click
		Response.Redirect("VtaPedidoHistProveedor.aspx" & _
		   "?NroPedido=" & ViewState("NroPedido") & _
		   "&CodCliente=" & ViewState("CodCliente") & _
		   "&opcion=1")
	End Sub

	Private Sub lbtPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrecio.Click
		Response.Redirect("VtaVersionPrecio.aspx" & _
		"?NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&DesVersion=" & ucVersion1.DesVersion & _
		"&FlagPublica=" & ucVersion1.FlagPublica & _
		"&StsVersion=" & ucVersion1.StsVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtModificaLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificaLink.Click
		Response.Redirect("VtaVersionLink.aspx" & _
		"?NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion)
	End Sub

	Private Sub lbtCambiarHotel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarHotel.Click
		Response.Redirect("VtaVersionCambiarHotel.aspx" & _
		"?&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEspecificacion.Click
		Response.Redirect("VtaVersionEspeci.aspx" & _
		"?&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtExcluirReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtExcluirReserva.Click
		Response.Redirect("VtaVersionCambiarStatus.aspx" & _
		"?&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtReservaBoleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReservaBoleto.Click
		Response.Redirect("VtaVersionBoletoReserva.aspx" & _
		"?NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ViewState("NroVersion") & _
		"&FlagPublica=" & ViewState("FlagPublica") & _
		"&StsVersion=" & ViewState("StsVersion") & _
		"&DesVersion=" & ucVersion1.DesVersion)
	End Sub

	Private Sub lbtDiaOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDiaOrden.Click
		Response.Redirect("VtaVersionCambiarOrden.aspx" & _
		"?&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&FlagEdita=" & ViewState("FlagEdita"))
	End Sub

	Private Sub lbtPrintPagina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrintPagina.Click
		Response.Redirect("vtaVersionPrint.aspx" & _
		"?&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&FlagIdioma=" & ucVersion1.FlagIdioma & _
		"&Cliente=" & ucVersion1.Cliente)
	End Sub

	Private Sub lbtCreaCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCreaCopia.Click
		lblMsg.Text = objVersion.Copia(ViewState("NroPedido"), ViewState("NroPropuesta"), ViewState("NroVersion"))
		If lblMsg.Text.Trim = "OK" Then
			Response.Redirect("VtaClienteVersion.aspx" & _
							"?CodCliente=" & ViewState("CodCliente") & _
							"&EmailCliente=" & ViewState("EmailCliente"))
		End If
	End Sub

	Private Sub lbtCambiarHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarHora.Click
		Response.Redirect("VtaVersionCambiarHora.aspx" & _
			"?&NroPedido=" & ViewState("NroPedido") & _
			"&NroPropuesta=" & ViewState("NroPropuesta") & _
			"&NroVersion=" & ucVersion1.NroVersion & _
			"&FlagEdita=" & ViewState("FlagEdita"))
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

	Protected Sub lbtMigrarPedido_Click(sender As Object, e As EventArgs) Handles lbtMigrarPedido.Click
		Dim procesado As Boolean = False
		Dim sMensajeError As String = ""

		Dim sResultado As String = ""
		Dim iPropuestaNueva As Integer = 0
		Dim iVersionNueva As Integer = 0
		Dim wPorcentaje1, wPorcentaje2 As Double
		Dim wTotal, wTotal1, wTotal2, wTotal3 As Double
		Dim dFchInicial, dFchEmision1, dFchEmision2, dFchEmision3 As String

		Using transScope As New TransactionScope()
			Try
				'-----------------------------------------------------
				'Validaciones
				'-----------------------------------------------------
				Dim cd As New SqlCommand
				cd.Connection = cn
				cd.CommandType = CommandType.StoredProcedure
				cd.CommandText = "SYS_ValidarFacturacion_S"

				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error: " & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error: " & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Anulación de pedido actual
				'-----------------------------------------------------
				Dim wFchSys As Date = ObjRutina.FchSys
				Dim sIdReg As String = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

				cd = New SqlCommand
				cd.Connection = cn
				cd.CommandType = CommandType.StoredProcedure
				cd.CommandText = "CPC_AnulaFactPedidoVersion2_U_2"

				cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuestaBase", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@NroVersionBase", SqlDbType.Int).Value = ViewState("NroVersion")
				cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = "Gastos de anulación de viaje"
				cd.Parameters.Add("@TotalCliente", SqlDbType.Money).Value = 0
				cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error: " & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error: " & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Crear pedido en base al pedido actual
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "VTA_PropuestaPropuesta_I"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@NroPedidoOrigen", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuestaOrigen", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@NroDiaInicio", SqlDbType.Int).Value = 1
				cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150).Value = ""
				cd.Parameters.Add("@NroPropuestaOut", SqlDbType.Int).Value = 0

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output
				cd.Parameters("@NroPropuestaOut").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value

					If sResultado.Trim().Equals("OK") Then
						iPropuestaNueva = cd.Parameters("@NroPropuestaOut").Value
					End If
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Publicar pedido
				'-----------------------------------------------------
				sResultado = ""
				Dim objPropuesta As New clsPropuesta

				objPropuesta.NroPedido = ViewState("NroPedido")
				objPropuesta.NroPropuesta = iPropuestaNueva

				sResultado = objPropuesta.Editar

				If sResultado.Trim().Equals("OK") Then
					sResultado = ""

					objPropuesta.FlagPublica = "S"
					objPropuesta.FlagAtencion = "F"
					objPropuesta.NroPedido = ViewState("NroPedido")
					objPropuesta.NroPropuesta = iPropuestaNueva
					objPropuesta.CodUsuario = Session("CodUsuario")

					sResultado = objPropuesta.Publica

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Generar nueva versión de pedido
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "VTA_VersionPropuesta_I"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""
				cd.Parameters.Add("@NroVersionOut", SqlDbType.Int).Value = 0

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output
				cd.Parameters("@NroVersionOut").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value

					If sResultado.Trim().Equals("OK") Then
						iVersionNueva = cd.Parameters("@NroVersionOut").Value
					End If
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Publicar pedido
				'-----------------------------------------------------
				sResultado = ""
				objPropuesta = New clsPropuesta

				objPropuesta.NroPedido = ViewState("NroPedido")
				objPropuesta.NroPropuesta = iPropuestaNueva

				sResultado = objPropuesta.Editar

				If sResultado.Trim().Equals("OK") Then
					sResultado = ""

					objPropuesta.FlagPublica = "S"
					objPropuesta.FlagAtencion = "F"
					objPropuesta.NroPedido = ViewState("NroPedido")
					objPropuesta.NroPropuesta = iPropuestaNueva
					objPropuesta.CodUsuario = Session("CodUsuario")

					sResultado = objPropuesta.Publica

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Aprobar pedido
				'-----------------------------------------------------
				Dim dr As SqlDataReader
				Dim sObservacionVersion As String = ""
				Dim bAprobar As Boolean = False

				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "VTA_VersionNroVersion_S"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iVersionNueva

				Try
					cn.Open()
					dr = cd.ExecuteReader
					Do While dr.Read()
						sObservacionVersion = dr.GetValue(dr.GetOrdinal("ObsVersion"))
						bAprobar = True
					Loop
					dr.Close()
				Finally
					cn.Close()
				End Try

				If (bAprobar) Then
					sResultado = ""
					cd = New SqlCommand()
					cd.Connection = cn
					cd.CommandText = "VTA_VersionAprueba_U"
					cd.CommandType = CommandType.StoredProcedure

					cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
					cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
					cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
					cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iVersionNueva
					cd.Parameters.Add("@ObsVersion", SqlDbType.VarChar, 100).Value = sObservacionVersion
					cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
					cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

					cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

					Try
						cn.Open()
						cd.ExecuteNonQuery()
						sResultado = cd.Parameters("@MsgTrans").Value
					Catch ex1 As SqlException
						sResultado = "Error:" & ex1.Message
					Catch ex2 As Exception
						sResultado = "Error:" & ex2.Message
					Finally
						cn.Close()
					End Try

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception("No se ha podido aprobar la nueva versión.")
				End If

				'-----------------------------------------------------
				'Facturar pedido
				'-----------------------------------------------------
				dFchEmision1 = ""
				dFchEmision2 = ""
				dFchEmision3 = ""
				wTotal = 0
				wTotal1 = 0
				wTotal2 = 0
				wTotal3 = 0
				dFchInicial = ObjRutina.fechaddmmyyyy(0)
				Dim drCosto As SqlDataReader
				Dim bFacturar As Boolean = False

				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "CPC_FacturarVersion_S"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")

				Try
					cn.Open()
					drCosto = cd.ExecuteReader
					Do While drCosto.Read()
						Dim version As Integer = drCosto.GetValue(drCosto.GetOrdinal("NroVersion"))

						If (version = iVersionNueva) Then
							dFchEmision3 = drCosto.GetValue(drCosto.GetOrdinal("FchInicio"))
							wTotal = drCosto.GetValue(drCosto.GetOrdinal("PrecioTotal"))

							If wTotal > 0 Then
								wPorcentaje1 = 30
								wPorcentaje2 = 70

								wTotal1 = String.Format("{0:###,###,###.00}", Math.Round(wTotal * (wPorcentaje1 / 100), 2))
								wTotal2 = 0
								wTotal3 = String.Format("{0:###,###,###.00}", Math.Round(wTotal - wTotal1, 2))

								dFchEmision1 = ObjRutina.fechaddmmyyyy(0)
								dFchEmision2 = ""

								bFacturar = True
							End If
						End If
					Loop
					drCosto.Close()
				Finally
					cn.Close()
				End Try

				If (bFacturar) Then
					sIdReg = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

					sResultado = ""
					cd = New SqlCommand()
					cd.Connection = cn
					cd.CommandText = "CPC_FacturarVersion1_I"
					cd.CommandType = CommandType.StoredProcedure

					cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
					cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
					cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
					cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = iPropuestaNueva
					cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = iVersionNueva
					cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
					cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

					cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

					Try
						cn.Open()
						cd.ExecuteNonQuery()
						sResultado = cd.Parameters("@MsgTrans").Value
					Catch ex1 As SqlException
						sResultado = "Error:" & ex1.Message
					Catch ex2 As Exception
						sResultado = "Error:" & ex2.Message
					Finally
						cn.Close()
					End Try

					If sResultado.Trim().Equals("OK") Then
						sResultado = ""
						cd = New SqlCommand()
						cd.Connection = cn
						cd.CommandText = "CPC_FacturarVersion2_I"
						cd.CommandType = CommandType.StoredProcedure

						cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
						cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = "DC"
						cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
						cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
						cd.Parameters.Add("@Total1", SqlDbType.Money).Value = wTotal1
						cd.Parameters.Add("@Total2", SqlDbType.Money).Value = wTotal2
						cd.Parameters.Add("@Total3", SqlDbType.Money).Value = wTotal3
						cd.Parameters.Add("@FchEmision1", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision1)
						cd.Parameters.Add("@FchEmision2", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision2)
						cd.Parameters.Add("@FchEmision3", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision3)
						cd.Parameters.Add("@FchVersion", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchInicial)
						cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
						cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""
						cd.Parameters.Add("@NroDoc", SqlDbType.Int).Value = 0
						cd.Parameters.Add("@TotalFact", SqlDbType.Money).Value = 0

						cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output
						cd.Parameters("@NroDoc").Direction = ParameterDirection.Output
						cd.Parameters("@TotalFact").Direction = ParameterDirection.Output

						Try
							cn.Open()
							cd.ExecuteNonQuery()
							sResultado = cd.Parameters("@MsgTrans").Value
						Catch ex1 As SqlException
							sResultado = "Error:" & ex1.Message
						Catch ex2 As Exception
							sResultado = "Error:" & ex2.Message
						Finally
							cn.Close()
						End Try

						If Not sResultado.Trim().Equals("OK") Then
							Throw New Exception(sResultado)
						End If
					Else
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception("No se ha podido facturar la nueva versión.")
				End If

				'-----------------------------------------------------
				'Ajustar totales
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "SYS_AjustarFacturacion_U"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
				cd.Parameters.Add("@NroPropuestaNueva", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@NroVersionNueva", SqlDbType.Int).Value = iVersionNueva
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				'-----------------------------------------------------
				'Flag Ajuste
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "REG_Migracion_I"
				cd.CommandType = CommandType.StoredProcedure


				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta_new", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@NroVersion_new", SqlDbType.Int).Value = iVersionNueva
				cd.Parameters.Add("@NroVersion_base", SqlDbType.Int).Value = ViewState("NroVersion")

				cd.Parameters.Add("@Propuesta_base", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = Session("CodUsuario")
				cd.Parameters.Add("@procedencia", SqlDbType.VarChar, 1).Value = "M"

				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				If sResultado.Trim().Equals("OK") Then
					transScope.Complete()
					procesado = True
				Else
					Throw New Exception(sResultado)
				End If
			Catch ex As Exception
				transScope.Dispose()
				procesado = False
				sMensajeError = ex.Message
			End Try
		End Using

		If (procesado) Then
			Response.Redirect("VtaVersionFicha.aspx?NroPedido=" & ViewState("NroPedido") & "&NroPropuesta=" & iPropuestaNueva & "&NroVersion=" & iVersionNueva)
		Else
			Response.Write(String.Format("<script type='text/javascript'>alert('{0}');</script>", sMensajeError))
		End If
	End Sub
	Protected Sub lbtMigrarPedidoGG_Click(sender As Object, e As EventArgs) Handles lbtMigrarPedidoGG.Click

		Dim version_gg As Integer = 0

		'Dim flagGG As Boolean
		If versionGG.Value = String.Empty Then
			Exit Sub
		Else
			version_gg = Convert.ToInt32(versionGG.Value)
		End If

		Dim procesado As Boolean = False
		Dim sMensajeError As String = ""
		Dim sResultado As String = ""
		Dim iPropuestaNueva As Integer = version_gg
		Dim iVersionNueva As Integer = 0
		Dim wPorcentaje1, wPorcentaje2 As Double
		Dim wTotal, wTotal1, wTotal2, wTotal3 As Double
		Dim dFchInicial, dFchEmision1, dFchEmision2, dFchEmision3 As String

		Using transScope As New TransactionScope()
			Try
				'-----------------------------------------------------
				'Validaciones
				'-----------------------------------------------------
				Dim cd As New SqlCommand
				cd.Connection = cn
				cd.CommandType = CommandType.StoredProcedure
				cd.CommandText = "SYS_ValidarFacturacion_S"

				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error: " & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error: " & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Anulación de pedido actual
				'-----------------------------------------------------
				Dim wFchSys As Date = ObjRutina.FchSys
				Dim sIdReg As String = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

				cd = New SqlCommand
				cd.Connection = cn
				cd.CommandType = CommandType.StoredProcedure
				cd.CommandText = "CPC_AnulaFactPedidoVersion2_U"

				cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = "Gastos de anulación de viaje"
				cd.Parameters.Add("@TotalCliente", SqlDbType.Money).Value = 0
				cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error: " & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error: " & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Publicar pedido
				'-----------------------------------------------------
				sResultado = ""
				Dim objPropuesta As New clsPropuesta

				objPropuesta.NroPedido = ViewState("NroPedido")
				objPropuesta.NroPropuesta = iPropuestaNueva

				sResultado = objPropuesta.Editar

				If sResultado.Trim().Equals("OK") Then
					sResultado = ""

					objPropuesta.FlagPublica = "S"
					objPropuesta.FlagAtencion = "F"
					objPropuesta.NroPedido = ViewState("NroPedido")
					objPropuesta.NroPropuesta = iPropuestaNueva
					objPropuesta.CodUsuario = Session("CodUsuario")

					sResultado = objPropuesta.Publica

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Generar nueva versión de pedido
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "VTA_VersionPropuesta_I"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""
				cd.Parameters.Add("@NroVersionOut", SqlDbType.Int).Value = 0

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output
				cd.Parameters("@NroVersionOut").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value

					If sResultado.Trim().Equals("OK") Then
						iVersionNueva = cd.Parameters("@NroVersionOut").Value
					End If
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				If Not sResultado.Trim().Equals("OK") Then
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Publicar pedido
				'-----------------------------------------------------
				sResultado = ""
				objPropuesta = New clsPropuesta

				objPropuesta.NroPedido = ViewState("NroPedido")
				objPropuesta.NroPropuesta = iPropuestaNueva

				sResultado = objPropuesta.Editar

				If sResultado.Trim().Equals("OK") Then
					sResultado = ""

					objPropuesta.FlagPublica = "S"
					objPropuesta.FlagAtencion = "F"
					objPropuesta.NroPedido = ViewState("NroPedido")
					objPropuesta.NroPropuesta = iPropuestaNueva
					objPropuesta.CodUsuario = Session("CodUsuario")

					sResultado = objPropuesta.Publica

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception(sResultado)
				End If

				'-----------------------------------------------------
				'Aprobar pedido
				'-----------------------------------------------------
				Dim dr As SqlDataReader
				Dim sObservacionVersion As String = ""
				Dim bAprobar As Boolean = False

				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "VTA_VersionNroVersion_S"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iVersionNueva

				Try
					cn.Open()
					dr = cd.ExecuteReader
					Do While dr.Read()
						sObservacionVersion = dr.GetValue(dr.GetOrdinal("ObsVersion"))
						bAprobar = True
					Loop
					dr.Close()
				Finally
					cn.Close()
				End Try

				If (bAprobar) Then
					sResultado = ""
					cd = New SqlCommand()
					cd.Connection = cn
					cd.CommandText = "VTA_VersionAprueba_U"
					cd.CommandType = CommandType.StoredProcedure

					cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
					cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
					cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iPropuestaNueva
					cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iVersionNueva
					cd.Parameters.Add("@ObsVersion", SqlDbType.VarChar, 100).Value = sObservacionVersion
					cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
					cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

					cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

					Try
						cn.Open()
						cd.ExecuteNonQuery()
						sResultado = cd.Parameters("@MsgTrans").Value
					Catch ex1 As SqlException
						sResultado = "Error:" & ex1.Message
					Catch ex2 As Exception
						sResultado = "Error:" & ex2.Message
					Finally
						cn.Close()
					End Try

					If Not sResultado.Trim().Equals("OK") Then
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception("No se ha podido aprobar la nueva versión.")
				End If

				'-----------------------------------------------------
				'Facturar pedido
				'-----------------------------------------------------
				dFchEmision1 = ""
				dFchEmision2 = ""
				dFchEmision3 = ""
				wTotal = 0
				wTotal1 = 0
				wTotal2 = 0
				wTotal3 = 0
				dFchInicial = ObjRutina.fechaddmmyyyy(0)
				Dim drCosto As SqlDataReader
				Dim bFacturar As Boolean = False

				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "CPC_FacturarVersion_S"
				cd.CommandType = CommandType.StoredProcedure

				cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")

				Try
					cn.Open()
					drCosto = cd.ExecuteReader
					Do While drCosto.Read()
						Dim version As Integer = drCosto.GetValue(drCosto.GetOrdinal("NroVersion"))

						If (version = iVersionNueva) Then
							dFchEmision3 = drCosto.GetValue(drCosto.GetOrdinal("FchInicio"))
							wTotal = drCosto.GetValue(drCosto.GetOrdinal("PrecioTotal"))

							If wTotal > 0 Then
								wPorcentaje1 = 30
								wPorcentaje2 = 70

								wTotal1 = String.Format("{0:###,###,###.00}", Math.Round(wTotal * (wPorcentaje1 / 100), 2))
								wTotal2 = 0
								wTotal3 = String.Format("{0:###,###,###.00}", Math.Round(wTotal - wTotal1, 2))

								dFchEmision1 = ObjRutina.fechaddmmyyyy(0)
								dFchEmision2 = ""

								bFacturar = True
							End If
						End If
					Loop
					drCosto.Close()
				Finally
					cn.Close()
				End Try

				If (bFacturar) Then
					sIdReg = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

					sResultado = ""
					cd = New SqlCommand()
					cd.Connection = cn
					cd.CommandText = "CPC_FacturarVersion1_I"
					cd.CommandType = CommandType.StoredProcedure

					cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
					cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
					cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
					cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = iPropuestaNueva
					cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = iVersionNueva
					cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
					cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

					cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

					Try
						cn.Open()
						cd.ExecuteNonQuery()
						sResultado = cd.Parameters("@MsgTrans").Value
					Catch ex1 As SqlException
						sResultado = "Error:" & ex1.Message
					Catch ex2 As Exception
						sResultado = "Error:" & ex2.Message
					Finally
						cn.Close()
					End Try

					If sResultado.Trim().Equals("OK") Then
						sResultado = ""
						cd = New SqlCommand()
						cd.Connection = cn
						cd.CommandText = "CPC_FacturarVersion2_I"
						cd.CommandType = CommandType.StoredProcedure

						cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
						cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = "DC"
						cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
						cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
						cd.Parameters.Add("@Total1", SqlDbType.Money).Value = wTotal1
						cd.Parameters.Add("@Total2", SqlDbType.Money).Value = wTotal2
						cd.Parameters.Add("@Total3", SqlDbType.Money).Value = wTotal3
						cd.Parameters.Add("@FchEmision1", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision1)
						cd.Parameters.Add("@FchEmision2", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision2)
						cd.Parameters.Add("@FchEmision3", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchEmision3)
						cd.Parameters.Add("@FchVersion", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(dFchInicial)
						cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
						cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""
						cd.Parameters.Add("@NroDoc", SqlDbType.Int).Value = 0
						cd.Parameters.Add("@TotalFact", SqlDbType.Money).Value = 0

						cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output
						cd.Parameters("@NroDoc").Direction = ParameterDirection.Output
						cd.Parameters("@TotalFact").Direction = ParameterDirection.Output

						Try
							cn.Open()
							cd.ExecuteNonQuery()
							sResultado = cd.Parameters("@MsgTrans").Value
						Catch ex1 As SqlException
							sResultado = "Error:" & ex1.Message
						Catch ex2 As Exception
							sResultado = "Error:" & ex2.Message
						Finally
							cn.Close()
						End Try

						If Not sResultado.Trim().Equals("OK") Then
							Throw New Exception(sResultado)
						End If
					Else
						Throw New Exception(sResultado)
					End If
				Else
					Throw New Exception("No se ha podido facturar la nueva versión.")
				End If

				'-----------------------------------------------------
				'Flag Ajuste
				'-----------------------------------------------------
				sResultado = ""
				cd = New SqlCommand()
				cd.Connection = cn
				cd.CommandText = "REG_Migracion_I"
				cd.CommandType = CommandType.StoredProcedure


				cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
				cd.Parameters.Add("@NroPropuesta_new", SqlDbType.Int).Value = iPropuestaNueva
				cd.Parameters.Add("@NroVersion_new", SqlDbType.Int).Value = iVersionNueva
				cd.Parameters.Add("@NroVersion_base", SqlDbType.Int).Value = ViewState("NroVersion")

				cd.Parameters.Add("@Propuesta_base", SqlDbType.Int).Value = ViewState("NroPropuesta")
				cd.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = Session("CodUsuario")

				If version_gg <> 0 Then
					cd.Parameters.Add("@procedencia", SqlDbType.VarChar, 1).Value = "R"
				Else
					cd.Parameters.Add("@procedencia", SqlDbType.VarChar, 1).Value = "M"
				End If

				cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

				cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

				Try
					cn.Open()
					cd.ExecuteNonQuery()
					sResultado = cd.Parameters("@MsgTrans").Value
				Catch ex1 As SqlException
					sResultado = "Error:" & ex1.Message
				Catch ex2 As Exception
					sResultado = "Error:" & ex2.Message
				Finally
					cn.Close()
				End Try

				If sResultado.Trim().Equals("OK") Then
					transScope.Complete()
					procesado = True
				Else
					Throw New Exception(sResultado)
				End If
			Catch ex As Exception
				transScope.Dispose()
				procesado = False
				sMensajeError = ex.Message
			End Try
		End Using

		If (procesado) Then
			Response.Redirect("VtaVersionFicha.aspx?NroPedido=" & ViewState("NroPedido") & "&NroPropuesta=" & iPropuestaNueva & "&NroVersion=" & iVersionNueva)
		Else
			Response.Write(String.Format("<script type='text/javascript'>alert('{0}');</script>", sMensajeError))
		End If
	End Sub

	Private Sub OcultarBotonMigrarGG()
		Dim sResultado As String = ""

		Dim cd As New SqlCommand
		cd.Connection = cn
		cd.CommandType = CommandType.StoredProcedure
		cd.CommandText = "SYS_OcultarBotonMigrar"

		cd.Parameters.Add("@CodUsuario", SqlDbType.Char).Value = Session("CodUsuario")

		cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 15).Value = ""

		cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

		Try
			cn.Open()
			cd.ExecuteNonQuery()
			sResultado = cd.Parameters("@MsgTrans").Value

			If (sResultado.Trim = "ADMI") Then
				lbtMigrarPedidoGG.Visible = True
			Else
				lbtMigrarPedidoGG.Visible = False

			End If


		Catch ex1 As SqlException
			sResultado = "Error: " & ex1.Message
		Catch ex2 As Exception
			sResultado = "Error: " & ex2.Message
		Finally
			cn.Close()
		End Try



	End Sub
	Protected Sub bltServiciosA_Click(sender As Object, e As EventArgs) Handles bltServiciosA.Click
		Response.Redirect("VtaVersionServicioAdicional.aspx" & _
		"?CodCliente=" & ViewState("CodCliente") & _
		"&NroPedido=" & ViewState("NroPedido") & _
		"&NroPropuesta=" & ViewState("NroPropuesta") & _
		"&NroVersion=" & ucVersion1.NroVersion & _
		"&StsVersion=" & ucVersion1.StsVersion)
	End Sub
End Class
