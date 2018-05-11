<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcSaldosCliente.aspx.vb" Inherits="cpcSaldosCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 564px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
				cellSpacing="0" cellPadding="1" width="564"  border="0"
				class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Saldos de Clientes</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 402px; HEIGHT: 58px" cellSpacing="0" cellPadding="0"
							width="402" bgColor="#cccccc" border="1">
							<TR>
								<TD>Moneda</TD>
								<TD style="WIDTH: 137px">Vencidos al</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:radiobutton id="rbDolar" runat="server" Text="Dólares" GroupName="GRUPO1" Checked="True" AutoPostBack="True"></asp:radiobutton>
									<asp:radiobutton id="rbSoles" runat="server" Text="Nuevo Soles" GroupName="GRUPO1" AutoPostBack="True"></asp:radiobutton></TD>
								<TD style="WIDTH: 137px">
									<asp:textbox id="txtFecha" runat="server" AutoPostBack="True" Width="75px"  CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFecha" style="WIDTH: 36px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFecha',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFecha">&nbsp;
									<asp:requiredfieldvalidator id="rfvFecha" runat="server" Width="11px" ControlToValidate="txtFecha" Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="560px" CssClass="MSG" ></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgSaldos" runat="server" Width="565px" CssClass="Grid" Height="10px" 
							OnItemDataBound="ComputeSum"
							ShowFooter="True" 
							AutoGenerateColumns="False" BorderWidth="1px" BorderColor="CadetBlue" CellPadding="2"
							AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCliente" SortExpression="CodCliente" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="Vencido" DataFormatString="{0:###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SaldoPend" SortExpression="SaldoPend" HeaderText="Pendiente" DataFormatString="{0:###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total" DataFormatString="{0:###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Vendedor"></asp:BoundColumn>
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
