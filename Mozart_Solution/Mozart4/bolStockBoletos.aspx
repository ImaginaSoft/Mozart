<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolStockBoletos.aspx.vb" Inherits="bolStockBoletos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblmsg" style="Z-INDEX: 102; LEFT: 18px; POSITION: absolute; TOP: 53px" runat="server"
				Width="228px"  CssClass="msg"></asp:label>
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 260px; WIDTH: 143px; POSITION: absolute; TOP: 43px; HEIGHT: 28px"
				cellSpacing="1" cellPadding="1" width="143" border="0">
				<TR>
					<TD>
						<asp:Button id="cmdEliminar" runat="server" Text="Eliminar Boletos"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:datagrid id="dgStock" style="Z-INDEX: 103; LEFT: 18px; POSITION: absolute; TOP: 72px" runat="server"
				CssClass="Grid" Height="17px" Width="384px" BorderColor="CadetBlue" AutoGenerateColumns="False"
				BorderWidth="1px" CellPadding="2">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="CodProveedor" HeaderText="Cod.Proveedor">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Forma" HeaderText="Forma">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Serie" HeaderText="Serie">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="FchAct" HeaderText="Actulizado">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 387px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="387" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;Boletos en&nbsp;Stock</P>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
