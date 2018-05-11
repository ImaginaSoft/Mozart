<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybSaldos.aspx.vb" Inherits="cybSaldos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="dgSaldos" style="Z-INDEX: 103; LEFT: 12px; POSITION: absolute; TOP: 57px" runat="server"
				BorderWidth="1px" CellPadding="2" Height="17px" AutoGenerateColumns="False" CssClass="Grid"
				Width="587px" BorderColor="CadetBlue">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="NomBanco" HeaderText="Banco">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NroCuenta" HeaderText="N&#250;mero de Cuenta">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:###,###.00}">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Moneda" HeaderText="Moneda">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodBanco">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SecBanco">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblmsg" style="Z-INDEX: 105; LEFT: 11px; POSITION: absolute; TOP: 38px" runat="server"
				 Width="583px" CssClass="msg"></asp:label>
			<TABLE id="Table3" style="Z-INDEX: 104; LEFT: 8px; WIDTH: 589px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Saldo de Bancos</P>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
