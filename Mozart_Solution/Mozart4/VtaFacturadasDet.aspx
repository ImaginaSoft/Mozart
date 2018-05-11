<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaFacturadasDet.aspx.vb" Inherits="VtaFacturadasDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="300" border="0">
				<TR>
					<TD class="Titulo">Versiones Facturadas Detalle</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgVersiones" runat="server" Width="792px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSum">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="Versi&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsVersion" SortExpression="StsVersion" HeaderText="Sts">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" SortExpression="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" SortExpression="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="Nro Propuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" SortExpression="TipoDocumento" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="Referencia"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
