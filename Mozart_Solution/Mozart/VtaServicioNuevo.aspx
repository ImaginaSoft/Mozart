<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioNuevo.aspx.vb" Inherits="VtaServicioNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 664px; POSITION: absolute; TOP: 8px; HEIGHT: 597px"
				cellSpacing="0" cellPadding="1" width="664" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD><asp:linkbutton id="lbtCopia" runat="server">Crear servicio desde el servicio actual</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 329px">
						<TABLE class="tabla" id="Table5" style="WIDTH: 656px; HEIGHT: 301px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 663px; HEIGHT: 15px">Proveedor</TD>
								<TD style="WIDTH: 350px; HEIGHT: 15px"><asp:dropdownlist id="ddlProveedor" runat="server" DataValueField="CodProveedor" DataTextField="NomProveedor"
										 Width="354px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px; HEIGHT: 19px">Ciudad</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:dropdownlist id="ddlCiudad" runat="server" DataValueField="CodCiudad" DataTextField="NomCiudad"
										Width="232px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Tipo</TD>
								<TD style="WIDTH: 350px"><asp:dropdownlist id="ddltiposervicio" runat="server" DataValueField="CodTipoServicio" DataTextField="TipoServicio"
										Width="232px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Descripción</TD>
								<TD style="WIDTH: 350px"><asp:textbox id="txtDesProveedor" runat="server" Width="448px" MaxLength="300" Height="56px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Valoriza Servicio por</TD>
								<TD style="WIDTH: 350px">
									<P><asp:radiobutton id="rbtPasajero" runat="server" Width="296px" Checked="True" GroupName="grupo1"
											Text="C=Cantidad de Pasajeros o Habitaciones"></asp:radiobutton>
										<asp:RadioButton id="rbtTipoHabPasajero" runat="server" Width="416px" Text="T=Cantidad  de Pasajeros  en un determinado tipo habitación"
											GroupName="grupo1"></asp:RadioButton><asp:radiobutton id="rbtMonto" runat="server" Width="112px" GroupName="grupo1" Text="M=Monto Fijo"></asp:radiobutton><asp:textbox id="txtMontoFijo" runat="server" Width="80px"></asp:textbox><asp:radiobutton id="rbtAjuste" runat="server" Width="190px" GroupName="grupo1" Text="A=Ajuste a la Utilidad"></asp:radiobutton>
										<asp:radiobutton id="rbtPorcen" runat="server" Width="208px" Text="P=Porcentaje de la venta total"
											GroupName="grupo1"></asp:radiobutton>
										<asp:textbox id="txtPorcen" runat="server" Width="64px"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Ver itinerario Cliente</TD>
								<TD style="WIDTH: 350px"><asp:radiobutton id="rbtSI" runat="server" Checked="True" GroupName="Grupo2" Text="Si "></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtNo" runat="server" GroupName="Grupo2" Text="No"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Ver Itinerario Proveedor</TD>
								<TD style="WIDTH: 350px"><asp:radiobutton id="rbtSIP" runat="server" Checked="True" GroupName="G3" Text="Si "></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtNOP" runat="server" GroupName="G3" Text="No" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Precio Obligatorio</TD>
								<TD style="WIDTH: 350px"><asp:radiobutton id="rbtFlagPrecioSI" runat="server" Checked="True" GroupName="G4" Text="Si "></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtFlagPrecioNO" runat="server" GroupName="G4" Text="No" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px; HEIGHT: 17px">Servicio de Transporte</TD>
								<TD style="WIDTH: 350px; HEIGHT: 17px">
									<P><asp:radiobutton id="rbtTipoRecorridoNO" runat="server" Width="392px" Checked="True" GroupName="G7"
											Text="No aplica"></asp:radiobutton><asp:radiobutton id="rbtTipoRecorridoLargo" runat="server" Width="382px" GroupName="G7" Text="Recorrido Largo        (Avion, Bus, Barco,etc)"></asp:radiobutton><asp:radiobutton id="rbtTipoRecorridoCorto" runat="server" GroupName="G7" Text="Recorrido Corto        (traslados en taxi)"></asp:radiobutton></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px; HEIGHT: 23px">Servicio Incluye</TD>
								<TD style="WIDTH: 350px; HEIGHT: 23px"><asp:checkbox id="chkDesayuno" runat="server" Text="Desayuno"></asp:checkbox>&nbsp;
									<asp:checkbox id="chkAlmuerzo" runat="server" Text="Almuerzo" BorderStyle="None"></asp:checkbox>&nbsp;&nbsp;&nbsp;
									<asp:checkbox id="chkCena" runat="server" Text="Cena"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px; HEIGHT: 23px">Solicitar reserva en Status</TD>
								<TD style="WIDTH: 350px; HEIGHT: 23px"><asp:textbox id="txtCodStsReserva" runat="server" Width="32px" MaxLength="2"></asp:textbox>&nbsp; 
									(RQ=On Request)</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Hora inicio de reserva (HH:MM)</TD>
								<TD style="WIDTH: 350px">
									<asp:textbox id="txtHoraInicioReserva" runat="server" Width="56px" MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Boleto transporte terrestre</TD>
								<TD style="WIDTH: 350px">
									<asp:CheckBox id="CheckBoxFlagServicioAge" runat="server" 
                                        Text="Marcar  para ingresar datos del boleto en la Versión"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 663px">Estado del servicio</TD>
								<TD style="WIDTH: 350px"><asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo3" Text="Activo"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo3" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px">Caracteristica especial del servicio para mostrar en el 
						resumen de la pagina personalizada</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 656px; HEIGHT: 8px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 195px; HEIGHT: 17px">Descripción en Español</TD>
								<TD style="WIDTH: 350px; HEIGHT: 17px"><asp:textbox id="txtCaraEspeServicio" runat="server" Height="44px" Width="448px" MaxLength="250"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 195px; HEIGHT: 19px">Descripción en Ingles</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:textbox id="txtCaraEspeServicio2" runat="server" Height="44px" Width="448px" MaxLength="250"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 195px; HEIGHT: 19px">Descripción en Portugués</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:textbox id="txtCaraEspeServicio3" 
                                        runat="server" Height="44px" Width="448px" MaxLength="250"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px"><asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar" Visible="False"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="504px" CssClass="error" DESIGNTIMEDRAGDROP="187"></asp:label></TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
