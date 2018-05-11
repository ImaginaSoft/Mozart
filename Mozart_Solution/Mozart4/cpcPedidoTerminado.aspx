<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcPedidoTerminado.aspx.vb" Inherits="cpcPedidoTerminado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 560px; POSITION: absolute; TOP: 8px; HEIGHT: 283px"
				cellSpacing="0" cellPadding="0" width="560" border="0">
				<TR>
					<TD style="WIDTH: 594px; HEIGHT: 1px">
						<P class="Titulo">Pedidos Terminado</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px; HEIGHT: 85px">
						<TABLE class="form" id="Table3" style="WIDTH: 385px; HEIGHT: 47px" cellSpacing="0" cellPadding="0"
							width="385" border="0">
							<TR>
								<TD style="WIDTH: 321px; HEIGHT: 47px">
									<TABLE class="tabla" id="Table2" style="WIDTH: 318px; HEIGHT: 51px" cellSpacing="0" cellPadding="0"
										width="318" border="1" bgColor="#cccccc">
										<TR>
											<TD style="WIDTH: 136px">Pedidos terminados al</TD>
											<TD>
												<asp:textbox id="txtFchEmision" runat="server" AutoPostBack="True"  CssClass="fd"
													Width="75px"></asp:textbox>
												<INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchEmision">
												<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" CssClass="error" Width="11px" ForeColor=" " ControlToValidate="txtFchEmision"
													Height="8px">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 136px">Moneda</TD>
											<TD>
												<asp:radiobutton id="rbdolar" runat="server" Text="Dólares" GroupName="GRUPO1" Checked="True"></asp:radiobutton>
												<asp:radiobutton id="rbsoles" runat="server" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 47px">
									<asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px">
						<asp:label id="lblmsg" runat="server" Width="586px"  CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px">
						<asp:datagrid id="dgCtaCte" runat="server" Width="424px" CssClass="Grid" BorderColor="CadetBlue"
							Height="17px"   AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
							AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Liquida" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchTermino" SortExpression="FchTermino" HeaderText="Termino" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="Moneda"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Pago" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Factura" SortExpression="Factura" HeaderText="Factura" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Otros" SortExpression="Otros" HeaderText="Otros" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SinDoc" SortExpression="SinDoc" HeaderText="Sin Doc" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Boleta" SortExpression="Boleta" HeaderText="Boleta" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodMoneda" HeaderText="CodMoneda">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
