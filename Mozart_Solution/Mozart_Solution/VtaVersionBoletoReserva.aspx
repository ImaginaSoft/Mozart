<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionBoletoReserva.aspx.vb" Inherits="VtaVersionBoletoReserva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 520px; POSITION: absolute; TOP: 8px; HEIGHT: 297px"
				cellSpacing="0" cellPadding="1" width="520" border="0">
				<TR>
					<TD>
						<P class="Titulo"><asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaVersion" runat="server" Width="107px">• Ficha Version</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="Tabla" id="Table3" style="WIDTH: 448px; HEIGHT: 40px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="448" border="1">
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 16px">&nbsp;Estado Reserva&nbsp;</TD>
								<TD style="HEIGHT: 16px"><asp:dropdownlist id="ddlStsReserva" runat="server" Width="280px" DataValueField="CodStsReserva" DataTextField="StsReserva"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 5px">&nbsp;Código de Reserva</TD>
								<TD style="HEIGHT: 5px"><asp:textbox id="txtCodReserva" runat="server" Width="112px" MaxLength="10"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="Tabla" id="Table1" style="WIDTH: 616px; HEIGHT: 81px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="616" border="1">
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 25px">&nbsp;Linea Aérea</TD>
								<TD style="WIDTH: 187px; HEIGHT: 25px"><asp:textbox id="txtAerolinea" runat="server" Width="184px" MaxLength="25"></asp:textbox></TD>
								<TD style="WIDTH: 92px; HEIGHT: 25px">Ruta</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtRutaVuelo" runat="server" Width="184px" MaxLength="25"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 5px">&nbsp;Número Vuelo</TD>
								<TD style="WIDTH: 187px; HEIGHT: 5px"><asp:textbox id="txtNroVuelo" runat="server" Width="112px" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 92px; HEIGHT: 5px">Hora Salida</TD>
								<TD style="HEIGHT: 5px"><asp:textbox id="txtHoraSalida" runat="server" Width="72px" MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 5px">&nbsp;Fecha Vuelo</TD>
								<TD style="WIDTH: 187px; HEIGHT: 5px"><asp:textbox id="txtFchVuelo" runat="server" Width="75px" AutoPostBack="True" ></asp:textbox><INPUT class="fd" id="Button1" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchVuelo',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:checkbox id="Checkbox2" runat="server" AutoPostBack="True" Text="Limpiar"></asp:checkbox></TD>
								<TD style="WIDTH: 92px; HEIGHT: 5px">Hora Llegada</TD>
								<TD style="HEIGHT: 5px"><asp:textbox id="txtHoraLlegada" runat="server" Width="72px" MaxLength="5"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;<asp:label 
                            id="lblMsg" runat="server" Width="408px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px">
						<asp:datagrid id="dgServicio" runat="server" Width="1140px" Height="17px" CssClass="Grid" BorderStyle="None"
							AutoGenerateColumns="False" AllowSorting="True" BorderColor="CadetBlue" BorderWidth="2px"
							CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Acomodaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesCantidad" HeaderText="Cantidad">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsReserva" HeaderText="Estado Reserva">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha Emisi&#243;n" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle BackColor="#CCFFFF" CssClass="Hide"></ItemStyle>
                                    <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodReserva" HeaderText="Codigo Reserva">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="NroOrden">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="NroServicio">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="aerolinea" HeaderText="Linea A&#233;rea">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVuelo" HeaderText="N&#250;mero Vuelo">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchVuelo" HeaderText="Fecha Vuelo" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RutaVuelo" HeaderText="Ruta">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraSalida" HeaderText="Hora Salida">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraLlegada" HeaderText="Hora Llegada">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="fchsys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblNroDia" runat="server" Visible="False"></asp:label><asp:label id="lblNroOrden" runat="server" Visible="False"></asp:label><asp:label id="lblNroServicio" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
