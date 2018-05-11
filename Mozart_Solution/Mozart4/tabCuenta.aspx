<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabCuenta.aspx.vb" Inherits="tabCuenta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 421px; POSITION: absolute; TOP: 8px; HEIGHT: 81px"
				cellSpacing="0" cellPadding="0" width="421" border="0">
				<TR>
					<TD>
						<P class="Titulo">Tabla de cuentas de ingresos y gastos</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 15px">&nbsp;
						<asp:linkbutton id="lblNuevoGasto" runat="server">• Nueva Cuenta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 425px; HEIGHT: 3px" cellSpacing="0" cellPadding="0"
							width="425" border="1">
							<TR>
								<TD style="WIDTH: 41px"><FONT size="2">&nbsp;Cuenta&nbsp;</FONT></TD>
								<TD><asp:dropdownlist id="ddlCuenta2" runat="server" DataTextField="NomCuenta" DataValueField="CodCuenta"
										Width="288px" ></asp:dropdownlist></TD>
								<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"><asp:label id="lblMsg" runat="server" Width="592px" 
                            CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgGastos" runat="server" Width="608px" Height="17px" CssClass="Grid" 
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCuenta" SortExpression="CodCuenta" HeaderText="Cuenta"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCuenta" SortExpression="NomCuenta" HeaderText="Nombre Cuenta">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Grupo" SortExpression="Grupo" HeaderText="Grupo "></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
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
