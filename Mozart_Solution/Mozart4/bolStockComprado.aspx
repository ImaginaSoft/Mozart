<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolStockComprado.aspx.vb" Inherits="bolStockComprado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 58px"
				cellSpacing="0" cellPadding="0" width="536" border="0" class="Form">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Stock de Boletos Comprados no usados</TD>
				</TR>
				<TR>
					<TD class="OPCIONES" style="HEIGHT: 14px">
						<TABLE class="opciones" id="Table2" style="WIDTH: 512px; HEIGHT: 32px" cellSpacing="0"
							cellPadding="0" width="512" border="0">
							<TR>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtRemision" runat="server">Remisión de Boletos</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtSolReembolso" runat="server">Solicitar Reembolso</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtCambioVersion" runat="server">Cambio de Versión</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:linkbutton id="lbtConReembolso" runat="server">Confirmar Reembolso</asp:linkbutton></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="OPCIONES" style="HEIGHT: 15px">
						<asp:Label id="lblNroPedido" runat="server" Visible="False"></asp:Label>&nbsp;
						<asp:Label id="lblPedidos" runat="server" Visible="False"></asp:Label>&nbsp;
						<asp:Label id="lblBoletosVtaStk" runat="server" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px"><asp:label id="lblMsg" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px"><asp:GridView id="dgBoleto" runat="server" AllowSorting="True" CellPadding="2" BorderWidth="1px"
							AutoGenerateColumns="False" BorderColor="CadetBlue" Width="800px" Height="17px" CssClass="Grid" ShowFooter="True"
							OnItemDataBound="ComputeSum" DataKeyNames="KeyReg" >
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
							
								<asp:BoundField DataField="FchEmision" SortExpression="FchEmision" HeaderText="Emisi&#243;n" DataFormatString="{0:dd-MM-yy}"
									ItemStyle-Wrap="False"></asp:BoundField>
								<asp:BoundField DataField="Boleto" SortExpression="Boleto" HeaderText="Boleto"></asp:BoundField>
								<asp:BoundField DataField="PagoBoleto" SortExpression="PagoBoleto" HeaderText="Pago Boleto" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Provision" SortExpression="Provision" HeaderText="Provisión" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomPasajero" SortExpression="NomPasajero" HeaderText="Pasajero">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Ruta" SortExpression="Ruta" HeaderText="Ruta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido"></asp:BoundField>
								<asp:BoundField DataField="NroVersion" SortExpression="NroVersion" HeaderText="Versi&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="FchRemision" SortExpression="FchRemision" HeaderText="Solicitud Reembolso"
									DataFormatString="{0:dd-MM-yy}"></asp:BoundField>
								<asp:BoundField DataField="FlagSol" HeaderText="FlagSol" Visible="False"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<asp:Label id="lblNota" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
		
		</form>
</body>
</html>
