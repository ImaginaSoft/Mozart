<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionServicio.aspx.vb" Inherits="VtaVersionServicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
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
					<TD class="opciones" style="HEIGHT: 24px">&nbsp;&nbsp;<asp:textbox id="txtDiaAnt" runat="server" Visible="False" Width="17px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtOrdenAnt" runat="server" Visible="False" Width="17px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtNroServicioAnt" runat="server" Visible="False" Width="48px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtFlagValoriza" runat="server" Visible="False" Width="20px" MaxLength="12"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtPrecio" runat="server" Width="56px">• Precio</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;<asp:linkbutton id="lbtFichaVersion" runat="server" Width="107px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 157px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 832px; HEIGHT: 238px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="832" border="1">
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 17px">Proveedor</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="384px" AutoPostBack="True"
										DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlCiudad" runat="server" Width="384px" AutoPostBack="True" DataValueField="CodCiudad"
										DataTextField="NomCiudad"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 17px">Tipo Servicio</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddltiposervicio" runat="server" Width="384px" AutoPostBack="True" DataValueField="CodTipoServicio"
										DataTextField="TipoServicio"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 19px">Servicio</TD>
								<TD style="HEIGHT: 19px"><asp:dropdownlist id="ddlServicio" runat="server" Width="688px" AutoPostBack="True" DataValueField="NroServicio"
										DataTextField="DesProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px"><asp:label id="lblTipoAcomodacion" runat="server" Visible="False" Width="112px">Tipo Acomodación</asp:label></TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlTipoAcomodacion" runat="server" Visible="False" Width="384px" DataValueField="CodTipoAcomodacion"
										DataTextField="TipoAcomodacion"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 25px"><asp:label id="lblRangoTarifa" runat="server" Visible="False" BorderStyle="None">Rango Tarifa</asp:label></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtRangoTarifa" tabIndex="10" runat="server" Visible="False" Width="24px" MaxLength="2"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblMontoFijo" runat="server" Width="67px" Visible="False">Monto Fijo</asp:label><asp:textbox id="txtMontoFijo" runat="server" Visible="False" Width="75px" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 25px">N° de pasajeros</TD>
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
									&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 576px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="576" border="1">
							<TR>
								<TD class="tabla" style="WIDTH: 19px">Día&nbsp;
								</TD>
								<TD style="WIDTH: 49px"><asp:textbox id="Textdia" runat="server" Width="24px" MaxLength="2"></asp:textbox></TD>
								<TD style="WIDTH: 39px">&nbsp;Orden</TD>
								<TD style="WIDTH: 60px"><asp:textbox id="Textorden" runat="server" Width="24px" MaxLength="2"></asp:textbox></TD>
								<TD style="WIDTH: 41px" align="right">HoraSalida</TD>
								<TD style="WIDTH: 109px" align="left"><asp:textbox id="txtHoraSalida" runat="server" Width="73px" MaxLength="8"></asp:textbox></TD>
								<TD style="WIDTH: 78px" align="left">HoraLlegada</TD>
								<TD style="WIDTH: 161px" align="left"><asp:textbox id="txtHoraLlegada" runat="server" Width="73px" MaxLength="8"></asp:textbox></TD>
								<TD style="WIDTH: 161px" align="left"><asp:radiobutton id="rbtNuevo" runat="server" GroupName="G1" Text="Nuevo"></asp:radiobutton></TD>
								<TD style="WIDTH: 161px" align="left"><asp:radiobutton id="rbtUpdate" runat="server" Text="Reemplazar" GroupName="G1" Checked="True"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;<asp:label 
                            id="lblMsg" runat="server" Width="425px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgServicio" runat="server" Width="800px" BorderStyle="None" Height="20px" CssClass="Grid"
							CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue">
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
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesProveedor")%>' NavigateUrl='<%# "vtaVersionDesItem.aspx?KeyReg=" + DataBinder.Eval(Container.DataItem,"KeyReg")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="FlagValoriza" HeaderText="V"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesCantidad" HeaderText="Cantidad"></asp:BoundColumn>
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
								<asp:BoundColumn DataField="HoraSalida" SortExpression="HoraSalida" HeaderText="HoraSalida">
        									 <ItemStyle CssClass="Hide" />
                                             <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraLlegada" SortExpression="HoraLlegada" HeaderText="HoraLlegada">
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
