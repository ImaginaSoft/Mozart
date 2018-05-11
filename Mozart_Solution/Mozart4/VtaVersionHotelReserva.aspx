<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionHotelReserva.aspx.vb" Inherits="VtaVersionHotelReserva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
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
						<TABLE class="Tabla" id="Table3" style="WIDTH: 624px; HEIGHT: 100px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="624" border="1">
							<TR>
								<TD style="WIDTH: 189px; HEIGHT: 16px">&nbsp;Estado Reserva&nbsp;</TD>
								<TD style="HEIGHT: 16px"><asp:dropdownlist id="ddlStsReserva" runat="server" Width="272px" DataValueField="CodStsReserva" DataTextField="StsReserva"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 189px; HEIGHT: 24px">&nbsp;Ciudad</TD>
								<TD style="HEIGHT: 24px">
									<asp:Label id="lblCiudad" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 189px; HEIGHT: 23px">&nbsp;Proveedor Alternativo&nbsp;(
									<asp:linkbutton id="LinkButtonTodos" runat="server">Todos</asp:linkbutton>)</TD>
								<TD style="HEIGHT: 23px"><asp:dropdownlist id="ddlProveedor" runat="server" Width="400px" DataValueField="CodProveedor" DataTextField="NomProveedor"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 189px; HEIGHT: 5px">&nbsp;Hotel Alternativo&nbsp;</TD>
								<TD style="HEIGHT: 5px"><asp:dropdownlist id="ddlHotelAlternativo" runat="server" Width="400px" DataValueField="NroServicio"
										DataTextField="Titulo"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;<asp:label 
                            id="lblMsg" runat="server" Width="408px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLink" runat="server" Width="752px" BorderStyle="None" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="1" Height="25px"
							CssClass="Grid">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodLink" HeaderText="Link"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="Titulo" HeaderText="Hotel"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsReserva" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="HotelAlternativo" HeaderText="Hotel Alternativo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedorAlternativo" HeaderText="Proveedor Alternativo"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCiudad" HeaderText="CodCiudad">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroAlternativo" HeaderText="NroAlternativo">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="CodProveedor">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedorAlternativo" HeaderText="CodProveedorAlternativo">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Label id="lblNroServicio" runat="server" Visible="False"></asp:Label>&nbsp;
						<asp:Label id="lblCodCiudad" runat="server" Visible="False"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
