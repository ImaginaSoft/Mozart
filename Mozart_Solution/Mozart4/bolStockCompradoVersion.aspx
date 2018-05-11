<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolStockCompradoVersion.aspx.vb" Inherits="bolStockCompradoVersion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 58px"
				cellSpacing="0" cellPadding="0" width="536" border="0" class="Form">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Boletos Cambian&nbsp;de Versión</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" class="OPCIONES">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 46px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 584px; HEIGHT: 21px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="584" border="1">
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 25px">N° Pedido&nbsp;(TAB)</TD>
								<TD style="HEIGHT: 25px">
									<asp:TextBox id="txtNroPedido" runat="server" Width="106px" MaxLength="8" AutoPostBack="True"
										BackColor="#C0FFFF" Enabled="False"></asp:TextBox>
									<asp:Label id="lblNomCliente" runat="server" Width="304px"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 12px">N° Versión</TD>
								<TD style="HEIGHT: 12px">
									<asp:dropdownlist id="ddlVersion" runat="server" Width="424px" DataTextField="DesVersion" DataValueField="KeyReg"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:Button>&nbsp;
						<asp:Label id="lblMsg" runat="server" CssClass="error"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<asp:datagrid id="dgBoleto" runat="server" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"
							BorderColor="CadetBlue" Width="600px" Height="17px" CssClass="Grid">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" SortExpression="FchEmision" HeaderText="Emisi&#243;n" DataFormatString="{0:dd-MM-yy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Boleto" SortExpression="Boleto" HeaderText="Boleto"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tarifa" SortExpression="Tarifa" HeaderText="Tarifa" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" SortExpression="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Impuesto" SortExpression="Impuesto" HeaderText="Impu" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision1" SortExpression="Comision1" HeaderText="Com1" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision2" SortExpression="Comision2" HeaderText="Com2" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" SortExpression="NomPasajero" HeaderText="Pasajero">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" SortExpression="Ruta" HeaderText="Ruta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="Versi&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
