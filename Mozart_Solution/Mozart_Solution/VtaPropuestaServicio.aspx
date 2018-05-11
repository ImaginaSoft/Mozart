﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaServicio.aspx.vb" Inherits="VtaPropuestaServicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 91px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 10px; WIDTH: 589px; POSITION: absolute; TOP: 7px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="0" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 25px">&nbsp;&nbsp;<asp:textbox id="txtDiaAnt" runat="server" Width="17px" Visible="False"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtOrdenAnt" runat="server" Width="17px" Visible="False"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtNroServicioAnt" runat="server" Width="48px" Visible="False"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtFlagValoriza" runat="server" Width="20px" Visible="False" MaxLength="12"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtPrecio" runat="server" Width="56px">• Precio</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 215px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 800px; HEIGHT: 238px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="800" border="1">
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 7px">Proveedor</TD>
								<TD style="HEIGHT: 7px"><asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="288px" DataTextField="NomProveedor"
										DataValueField="CodProveedor" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlCiudad" runat="server" Width="288px" DataTextField="NomCiudad" DataValueField="CodCiudad"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 17px">Tipo Servicio</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddltiposervicio" runat="server" Width="288px" DataTextField="TipoServicio" DataValueField="CodTipoServicio"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 19px">Servicio</TD>
								<TD style="HEIGHT: 19px"><asp:dropdownlist id="ddlServicio" runat="server" Width="664px" DataTextField="DesProveedor" DataValueField="NroServicio"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 15px"><asp:label id="lblTipoAcomodacion" runat="server" Width="112px" Visible="False">Tipo Acomodación</asp:label></TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlTipoAcomodacion" runat="server" Width="424px" Visible="False" DataTextField="TipoAcomodacion"
										DataValueField="CodTipoAcomodacion"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 25px"><asp:label id="lblRangoTarifa" runat="server" Visible="False" BorderStyle="None">Rango Tarifa</asp:label></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtRangoTarifa" tabIndex="10" runat="server" Width="24px" Visible="False" MaxLength="2"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblMontoFijo" runat="server" Width="67px" Visible="False">Monto Fijo</asp:label><asp:textbox id="txtMontoFijo" runat="server" Width="75px" Visible="False" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 25px"><asp:label id="lblPaxHab" runat="server" Width="96px" BorderStyle="None">N° Pasajeros</asp:label></TD>
								<TD style="HEIGHT: 25px">
									<TABLE class="tabla" id="Table4" style="WIDTH: 320px; HEIGHT: 72px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="320" border="0">
										<TR>
											<TD style="WIDTH: 52px"></TD>
											<TD><asp:label id="lblHabSimple" runat="server">Simple</asp:label></TD>
											<TD><asp:label id="lblHabDoble" runat="server">Doble</asp:label></TD>
											<TD><asp:label id="lblHabTriple" runat="server">Triple</asp:label></TD>
											<TD><asp:label id="lblHabCuadruple" runat="server">Cuadruple</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px"><asp:label id="lblAdultos" runat="server">Adultos</asp:label></TD>
											<TD><asp:textbox id="txtAS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAD" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px"><asp:label id="lblNinos" runat="server">Niños</asp:label></TD>
											<TD><asp:textbox id="txtNS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtND" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 576px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="576" border="0">
							<TR>
								<TD class="tabla" style="WIDTH: 19px">Día&nbsp;
								</TD>
								<TD style="WIDTH: 49px"><asp:textbox id="Textdia" runat="server" Width="24px" MaxLength="2"></asp:textbox></TD>
								<TD style="WIDTH: 39px">&nbsp;Orden</TD>
								<TD style="WIDTH: 66px"><asp:textbox id="Textorden" runat="server" Width="24px" MaxLength="2"></asp:textbox></TD>
								<TD style="WIDTH: 49px" align="right">&nbsp;Hora</TD>
								<TD style="WIDTH: 109px" align="left"><asp:textbox id="txtHoraServicio" runat="server" Width="73px" MaxLength="8"></asp:textbox></TD>
								<TD align="left" class="style1"><asp:radiobutton id="rbtNuevo" runat="server" GroupName="G1" Text="Nuevo"></asp:radiobutton>&nbsp;&nbsp;&nbsp;</TD>
								<TD style="WIDTH: 161px" align="left"><asp:radiobutton id="rbtUpdate" runat="server" GroupName="G1" Text="Reemplazar" Checked="True"></asp:radiobutton></TD>
								<TD style="WIDTH: 161px" align="left"><asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="425px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgServicio" runat="server" Width="800px" BorderStyle="None" CssClass="Grid"
							Height="20px" BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="KeyReg" HeaderText="KeyReg">
                                     <HeaderStyle CssClass="Hide" />
									 <ItemStyle ForeColor="Crimson" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Servicio">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesProveedor")%>' NavigateUrl='<%# "vtaPropuestaDesItem.aspx?KeyReg=" + DataBinder.Eval(Container.DataItem,"KeyReg")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="FlagValoriza" HeaderText="V"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Cantidad">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesCantidad")%>' NavigateUrl='<%# "vtaServicioTarifa.aspx?NroServicio=" + MID(DataBinder.Eval(Container.DataItem,"KeyReg"),15,8)%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="NroServicio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoAcomodacion" HeaderText="CodTipoAcomodacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoServicio" HeaderText="CodTipoServicio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagPrecio" HeaderText="FlagPrecio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
