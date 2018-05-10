<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcPedidoLiquidacion.aspx.vb" Inherits="cpcPedidoLiquidacion" %>
<%@ Register TagPrefix="uc1" TagName="ucPedido" Src="ucPedido.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 549px; POSITION: absolute; TOP: 8px; HEIGHT: 296px"
				cellSpacing="0" cellPadding="0" width="549" border="0">
				<TR>
					<TD>
						<P class="Titulo">Liquidación del Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD><uc1:ucpedido id="UcPedido1" runat="server"></uc1:ucpedido></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 568px; HEIGHT: 227px" cellSpacing="0" cellPadding="0"
							width="568" border="0">
							<TR>
								<TD style="WIDTH: 432px">
									<TABLE class="tabla" id="Table4" style="WIDTH: 312px; HEIGHT: 211px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="312" border="1">
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 20px"></TD>
											<TD style="WIDTH: 123px; HEIGHT: 20px" align="right"><asp:label id="lblTitMoneda" runat="server">Monto US $</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 20px">Total pago del Cliente</TD>
											<TD style="WIDTH: 123px; HEIGHT: 20px" align="right"><asp:label id="lblTotal" runat="server" ForeColor="Blue"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 23px">Total Otros (no Factura)</TD>
											<TD style="WIDTH: 123px; HEIGHT: 23px" align="right"><asp:label id="lblOtros" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 22px">Comisión&nbsp;Descontada</TD>
											<TD style="WIDTH: 123px; HEIGHT: 22px" align="right"><asp:label id="lblComiDesc" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 22px">Total sin Documentos</TD>
											<TD style="WIDTH: 123px; HEIGHT: 22px" align="right"><asp:label id="lblSinDoc" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 3px">Reembolso al Cliente</TD>
											<TD style="WIDTH: 123px; HEIGHT: 3px" align="right"><asp:label id="lblReembo" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px; HEIGHT: 22px">Seguro de cancelación</TD>
											<TD style="WIDTH: 123px; HEIGHT: 22px" align="right"><asp:label id="lblSeguro" runat="server" ForeColor="Blue"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px"><asp:button id="btnEmitirBoleta" runat="server" Width="176px" Text="Emitir boleta de ventas por"></asp:button></TD>
											<TD style="WIDTH: 123px" align="right"><asp:label id="lblBoleta" runat="server" ForeColor="Blue"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px">&nbsp;</TD>
											<TD style="WIDTH: 123px" align="right"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 388px">Utilidad del Pedido &nbsp;(Boleta-Factura)
											</TD>
											<TD style="WIDTH: 123px" align="right"><asp:label id="lblUtilidad" runat="server" ForeColor="Blue"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<P><asp:label id="lblLiqPedido" runat="server" Width="170px">Opción para liquidar el Pedido cuando monto de la boleta venta es menor o igual a cero.                     </asp:label><asp:button id="cmdLiqPedido" runat="server" Width="162px" Text="Liquida Pedido sin Boleta"></asp:button></P>
									<P><asp:label id="lblFactura" runat="server" ForeColor="Blue" Visible="False"></asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblError" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="560px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgCtaCte" runat="server" Width="568px" CssClass="Grid" Height="17px" AllowSorting="True"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"   BorderColor="CadetBlue"
							OnItemDataBound="ComputeSum" ShowFooter="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" SortExpression="FchEmision" HeaderText="Emision" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoComprobante" SortExpression="TipoComprobante" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroComprobante" SortExpression="NroComprobante" HeaderText="N&#186; Doc">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Factura" SortExpression="Factura" HeaderText="Factura" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Otros" SortExpression="Otros" HeaderText="Otros" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ComisionDescontada" SortExpression="ComisionDescontada" HeaderText="Comision Descontada"
									DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg1" runat="server" Width="560px" CssClass="msg" Height="9px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPenCuadre" runat="server" Width="416px" CssClass="Grid" Height="17px" AllowSorting="True"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"   BorderColor="CadetBlue"
							OnItemDataBound="ComputeSum1" ShowFooter="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Proveedor">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Ingresar Comprobante" CommandName="select">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Wrap="False" VerticalAlign="Middle"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="CodProveedor">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
