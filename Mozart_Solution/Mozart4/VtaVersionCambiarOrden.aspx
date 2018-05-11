<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionCambiarOrden.aspx.vb" Inherits="VtaVersionCambiarOrden" %>

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
					<TD class="opciones" style="HEIGHT: 24px"><asp:label id="lblCodProveedor" runat="server" Visible="False"></asp:label><asp:label id="lblCodCiudad" runat="server" Visible="False"></asp:label><asp:label id="lblNroServicio" runat="server" Visible="False"></asp:label>&nbsp;
						<asp:label id="lblCodTipoAcomodacion" runat="server" Visible="False"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lbtFichaVersion" runat="server" Width="107px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 94px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 576px; HEIGHT: 50px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="576" border="1">
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 17px"></TD>
								<TD class="msg" style="HEIGHT: 17px">La opción solo es válida para versiones 
									facturadas.</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 17px">Proveedor</TD>
								<TD style="HEIGHT: 17px"><asp:label id="lblNomProveedor" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px"><asp:label id="lblNomCiudad" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 19px">Servicio
								</TD>
								<TD style="HEIGHT: 19px"><asp:label id="lblDesProveedor" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 19px">Día</TD>
								<TD style="HEIGHT: 19px"><asp:label id="lblNroDia" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px">Orden</TD>
								<TD style="HEIGHT: 15px"><asp:label id="lblNroOrden" runat="server"></asp:label></TD>
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
								<TD style="WIDTH: 41px" align="right">Hora</TD>
								<TD style="WIDTH: 109px" align="left"><asp:textbox id="txtHoraServicio" runat="server" Width="73px" MaxLength="8"></asp:textbox></TD>
								<TD style="WIDTH: 366px" align="left">&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtUpdate" runat="server" Checked="True" GroupName="G1" Text="Reemplazar"></asp:radiobutton></TD>
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
					<TD><asp:datagrid id="dgServicio" runat="server" Width="600px" CssClass="Grid" Height="20px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
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
