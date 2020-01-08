<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioTarifa.aspx.vb" Inherits="VtaServicioTarifa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 692px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
				cellSpacing="0" cellPadding="1" width="692" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 601px; HEIGHT: 22px">Tarifas 
						del&nbsp;Servicio&nbsp;</TD>
				</TR>
				<TR>
					<TD class="opciones" style="WIDTH: 601px; HEIGHT: 22px">
						&nbsp;
						<asp:linkbutton id="lbtPeriodoTarifa" runat="server" Height="8px">Periodos de la Tarifa</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtCopiaTarifas" runat="server" Height="8px">Copiar Tarifas x Periodo</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtServicios" runat="server" Height="8px" Width="144px">Regresar a Servicios</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 601px; HEIGHT: 11px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 688px; HEIGHT: 184px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="688" border="1">
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 16px">Proveedor</TD>
								<TD style="WIDTH: 214px; HEIGHT: 16px">
									<asp:label id="lblNomProveedor" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 16px">Ciudad</TD>
								<TD style="WIDTH: 214px; HEIGHT: 16px">
									<asp:label id="lblNomCiudad" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 16px">Tipo Servicio</TD>
								<TD style="WIDTH: 214px; HEIGHT: 16px">
									<asp:label id="lblTipoServicio" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 16px">
									<asp:label id="Label3" runat="server" Width="139px">Nro del Servicio</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 16px">
									<asp:label id="lblNroServicio" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 16px"><FONT size="2">
										<asp:label id="Label1" runat="server" Width="139px">Descripción del Servicio</asp:label></FONT></TD>
								<TD style="WIDTH: 214px; HEIGHT: 16px"><FONT size="2">
										<asp:label id="lblDesServicio" runat="server" Width="390px"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 2px">
									<asp:label id="Label5" runat="server" Width="135px">Periodo de la Tarifa</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 2px">
									<asp:dropdownlist id="ddlTarifaPeriodo" runat="server" Width="432px" AutoPostBack="True" DataValueField="CodTarifa"
										DataTextField="DesTarifa"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 2px">
									<asp:label id="Label2" runat="server" Width="135px">Tipo de Acomodación</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 2px">
									<asp:dropdownlist id="ddlTipoAcomodacion" runat="server" Width="432px" DataValueField="CodTipoAcomodacion"
										DataTextField="TipoAcomodacion"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 1px">
									<asp:label id="lblTipoPasajero" runat="server" Width="135px" Visible="False">Tipo de Pasajero</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 1px">
									<asp:dropdownlist id="ddltipopasajero" runat="server" Width="128px" DataValueField="CodTipoPasajero"
										DataTextField="TipoPasajero" Visible="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px; HEIGHT: 1px">
									<asp:label id="lblSubTipo" runat="server" Width="96px" Visible="False">Tipo Habitación</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 1px">
									<asp:dropdownlist id="ddlSubTipo" runat="server" Width="128px" DataValueField="CodSubTipo" DataTextField="NomSubTipo"
										Visible="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px">
									<asp:label id="lblDesde" runat="server" Width="129px">Nro. Personas desde</asp:label></TD>
								<TD style="WIDTH: 214px">
									<asp:textbox id="txtInicio" runat="server" Width="77px"></asp:textbox>&nbsp;
									<asp:label id="lblHasta" runat="server" Width="40px"> hasta</asp:label>
									<asp:textbox id="txtFin" runat="server" Width="77px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 191px">
									<asp:label id="Label10" runat="server" Width="176px"> Tarifa neta x Persona US$</asp:label></TD>
								<TD style="WIDTH: 214px">
									<asp:textbox id="txtTarifa" runat="server" Width="77px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 601px; HEIGHT: 22px"><asp:button id="cmbGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="408px" CssClass="MSG"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 601px; HEIGHT: 20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtEliminarall" runat="server" Height="8px">Eliminar todas las tarifas</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 601px; HEIGHT: 22px">
						<asp:datagrid id="dgTarifas" runat="server" Height="25px" Width="688px" CssClass="Grid" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo Acomodaci&#243;n">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoPasajero" HeaderText="Tipo1 ">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomSubTipo" HeaderText="Tipo2">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RangoTarifa" HeaderText="Rango">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TarifaNeta" HeaderText="Tarifa Neta en $" DataFormatString="{0:###,###,###,###.##}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="DELETE"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:BoundColumn DataField="KeyReg" HeaderText="REGISTRO">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoAcomodacion" HeaderText="CodTipoAcomodacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoPasajero" HeaderText="CodTipoPasajero">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodSubTipo" HeaderText="CodSubTipo">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagColorTarifa" SortExpression="FlagColorTarifa" HeaderText="FlagColorTarifa">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 601px; HEIGHT: 22px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
