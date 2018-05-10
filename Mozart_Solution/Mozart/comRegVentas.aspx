<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comRegVentas.aspx.vb" Inherits="comRegVentas" %>

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
							<P class="Titulo">&nbsp;Registro de Ventas</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px">
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px">
							<TABLE class="form" id="Table1"  cellSpacing="0" cellPadding="0"
								width="410" border="1">
								<TR>
									<TD style="WIDTH: 72px">Declaración
									</TD>
									<TD>
										<TABLE class="tabla" id="Table6"  cellSpacing="0" cellPadding="0"
											width="230" border="0">
											<TR>
												<TD style="WIDTH: 32px">Año</TD>
												<TD style="WIDTH: 50px"><asp:textbox id="txtano" runat="server" DESIGNTIMEDRAGDROP="21" Width="37px">2005</asp:textbox>&nbsp;&nbsp;</TD>
												<TD>Mes</TD>
												<TD><asp:dropdownlist id="ddlCalendario" runat="server" Width="105px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
									<TD><asp:button id="cmdConsultar" runat="server" Width="74px" Text="Buscar"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkNuevoComprobante" runat="server">Nuevo Comprobante</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkNomPais" runat="server" Visible="False">Actualizar Pais del Cliente</asp:linkbutton></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblmsg" runat="server" CssClass="msg"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgDocumento" runat="server" Width="800px" CssClass="Grid" AllowSorting="True"
								AutoGenerateColumns="False" CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" Height="24px">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="FchComprobante" SortExpression="FchComprobante" HeaderText="Dia" DataFormatString="{0:dd-MM-yyyy}">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodSunat" SortExpression="CodSunat" HeaderText="Tipo de Documento">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NroComprobante" SortExpression="NroComprobante" HeaderText="Numero de comprobante">
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Numero de Registro"></asp:BoundColumn>
									<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC/Pasaporte"></asp:BoundColumn>
									<asp:BoundColumn DataField="PaisCliente" SortExpression="PaisCliente" HeaderText="País">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="CLIENTE">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DTotal" SortExpression="DTotal" HeaderText="Importe en Dolares" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TipoCambio" SortExpression="TipoCambio" HeaderText="Tipo de Cambio">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SSubTotal" SortExpression="SSubTotal" HeaderText="Base imponible soles"
										DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIGV" SortExpression="SIGV" HeaderText="I.G.V. " DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SInafecto" SortExpression="SInafecto" HeaderText="Ventas Inafectas" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STotal" SortExpression="STotal" HeaderText="TOTAL " DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="correlativo" HeaderText="correlativo"></asp:BoundColumn>
									<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
				</TABLE>
			</P>
		</form>
</body>
</html>
