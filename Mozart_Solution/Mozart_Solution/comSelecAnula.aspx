<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comSelecAnula.aspx.vb" Inherits="comSelecAnula" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE id="Table3" 
					cellSpacing="0" cellPadding="1" width="636" border="0">
					<TR>
						<TD>
							<P class="Titulo">Eliminar Comprobantes para volver a Liquidar en el Pedido</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD><asp:label id="lblmsg" runat="server" CssClass="msg"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgDocumento" runat="server" Width="744px" CssClass="Grid" AllowSorting="True"
								Height="24px" AutoGenerateColumns="False" CellPadding="2" BorderWidth="1px" 
                                BorderColor="CadetBlue">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" >
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
										<ItemStyle Wrap="False" ></ItemStyle>
									</asp:BoundColumn>

									<asp:BoundColumn DataField="FchComprobante" SortExpression="FchComprobante" HeaderText="Dia" DataFormatString="{0:dd-MM-yyyy}">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodSunat" SortExpression="CodSunat" HeaderText="Tipo de Documento">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NroComprobante" SortExpression="NroComprobante" HeaderText="Numero de comprobante">
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC"></asp:BoundColumn>
									<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="Proveedor / Cliente">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DTotal" SortExpression="DTotal" HeaderText="Importe en Dolares Total"
										DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TipoCambio" SortExpression="TipoCambio" HeaderText="Tipo de Cambio">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SSubTotal" SortExpression="SSubTotal" HeaderText="Base imponible soles"
										DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIGV" SortExpression="SIGV" HeaderText="IGV " DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SInafecto" SortExpression="SInafecto" HeaderText="Ventas Inafectas" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STotal" SortExpression="STotal" HeaderText="TOTAL " DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Correlativo" HeaderText="Correlativo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TipoComprobante" HeaderText="TipoComprobante"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD>&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD><asp:button id="btnEliminar" runat="server" Width="74px" Text="Eliminar"></asp:button></TD>
					</TR>
				</TABLE>
			</P>
		</form>
</body>
</html>
