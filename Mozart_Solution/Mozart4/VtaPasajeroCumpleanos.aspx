<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPasajeroCumpleanos.aspx.vb" Inherits="VtaPasajeroCumpleanos" %>

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
						<P class="Titulo">&nbsp;Pasajeros con fecha de cumpleaños (pedidos vendidos)</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 280px; HEIGHT: 40px" cellSpacing="1" cellPadding="1"
							width="280" border="0">
							<TR>
								<TD style="WIDTH: 19px">Mes&nbsp;</TD>
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
								<TD><asp:button id="cmdConsultar" runat="server" Width="80px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
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
								<asp:BoundColumn DataField="Dia" SortExpression="Dia" HeaderText="Dia">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" SortExpression="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
								<asp:BoundColumn DataField="Edad" SortExpression="Edad" HeaderText="Edad">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" SortExpression="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tour" SortExpression="Tour" HeaderText="Tour"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchIni" SortExpression="FchIni" HeaderText="IniTour" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFin" SortExpression="FchFin" HeaderText="FinTour" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="NroPedido">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
