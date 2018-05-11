<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolStockCompradoReembolso.aspx.vb" Inherits="bolStockCompradoReembolso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="Form" id="Table1" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 58px"
				cellSpacing="0" cellPadding="0" width="536" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Reembolso&nbsp;de Boletos</TD>
				</TR>
				<TR>
					<TD class="OPCIONES" style="HEIGHT: 15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 584px; HEIGHT: 48px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="584" border="1">
							<TR>
								<TD style="WIDTH: 159px">N° Reembolso</TD>
								<TD><asp:textbox id="txtNroPedido" runat="server" MaxLength="15" Width="144px"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 159px">Fecha de la Reembolso</TD>
								<TD><asp:textbox id="txtFchEmision" runat="server" Width="75px"  CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 159px">Monto de la Reembolso</TD>
								<TD><asp:textbox id="txtMontoRemision" runat="server" MaxLength="12" Width="106px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 159px">Proveedor&nbsp;para aplicar Nota Crédito x Reembolso</TD>
								<TD><asp:dropdownlist id="ddlProveedor" runat="server" Width="392px" DataTextField="NomProveedor" DataValueField="CodProveedor"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px"><asp:datagrid id="dgBoleto" runat="server" Width="600px" CssClass="Grid" Height="17px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2">
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
