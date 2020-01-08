<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidosxMesAtencion.aspx.vb" Inherits="VtaPedidosxMesAtencion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 589px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Pedidos por Mes-Año de Atención</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 46px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 776px; HEIGHT: 26px" cellSpacing="0" cellPadding="0"
							width="776" border="0">
							<TR>
								<TD style="WIDTH: 73px">Zona Venta</TD>
								<TD style="WIDTH: 188px"><asp:dropdownlist id="ddlZonaVta" runat="server" DataTextField="NomZonaVta" DataValueField="CodZonaVta"
										Width="184px"></asp:dropdownlist></TD>
								<TD>Vendedor</TD>
								<TD><asp:dropdownlist id="ddlVendedor" runat="server" DataTextField="NomVendedor" DataValueField="CodVendedor"
										Width="280px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 532px; HEIGHT: 40px" cellSpacing="1" cellPadding="1"
							width="532" border="0">
							<TR>
								<TD style="WIDTH: 19px">Del&nbsp;</TD>
								<TD><asp:dropdownlist id="ddlMesIni" tabIndex="4" runat="server" Width="123px">
										<asp:ListItem Value="0">Mes</asp:ListItem>
										<asp:ListItem Value="1">Enero</asp:ListItem>
										<asp:ListItem Value="2">Febrero</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Abril</asp:ListItem>
										<asp:ListItem Value="5">Mayo</asp:ListItem>
										<asp:ListItem Value="6">Junio</asp:ListItem>
										<asp:ListItem Value="7">Julio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Setiembre</asp:ListItem>
										<asp:ListItem Value="10">Octubre</asp:ListItem>
										<asp:ListItem Value="11">Noviembre</asp:ListItem>
										<asp:ListItem Value="12">Diciembre</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><asp:dropdownlist id="ddlAnoIni" tabIndex="5" runat="server" DataTextField="AnoProceso" DataValueField="AnoProceso"
										Width="72px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 39px">&nbsp;&nbsp;&nbsp;Al&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:dropdownlist id="ddlMesFin" tabIndex="4" runat="server" Width="123px">
										<asp:ListItem Value="0">Mes</asp:ListItem>
										<asp:ListItem Value="1">Enero</asp:ListItem>
										<asp:ListItem Value="2">Febrero</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Abril</asp:ListItem>
										<asp:ListItem Value="5">Mayo</asp:ListItem>
										<asp:ListItem Value="6">Junio</asp:ListItem>
										<asp:ListItem Value="7">Julio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Setiembre</asp:ListItem>
										<asp:ListItem Value="10">Octubre</asp:ListItem>
										<asp:ListItem Value="11">Noviembre</asp:ListItem>
										<asp:ListItem Value="12">Diciembre</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><asp:dropdownlist id="ddlAnoFin" tabIndex="5" runat="server" DataTextField="AnoProceso" DataValueField="AnoProceso"
										Width="72px"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdConsultar" runat="server" Width="80px" Text="Buscar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLista" runat="server" Width="792px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesPedido" SortExpression="DesPedido" HeaderText="Pedido"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchPedido" SortExpression="FchPedido" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AnoMes" SortExpression="AnoMes" HeaderText="Atenci&#243;n">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsPedido" SortExpression="StsPedido" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="StsAtencion" SortExpression="StsAtencion" HeaderText="Servicios"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPais" SortExpression="NomPais" HeaderText="Pa&#237;s"></asp:BoundColumn>
								<asp:BoundColumn DataField="CantIngWeb" SortExpression="CantIngWeb" HeaderText="IngWeb">
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
