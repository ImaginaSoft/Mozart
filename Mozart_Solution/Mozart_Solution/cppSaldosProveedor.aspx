<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppSaldosProveedor.aspx.vb" Inherits="cppSaldosProveedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 531px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="531" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Saldos de Proveedores</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 402px; HEIGHT: 58px" cellSpacing="0" cellPadding="0"
							width="402" border="1" borderColor="#cccccc">
							<TR>
								<TD>
									Moneda</TD>
								<TD style="WIDTH: 137px">
									Saldos al</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:radiobutton id="rbDolar" runat="server" Text="Dólares" GroupName="GRUPO1" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbSoles" runat="server" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
								<TD style="WIDTH: 137px">
									<asp:textbox id="txtFecha" runat="server" Width="75px" AutoPostBack="True"  CssClass="fd"></asp:textbox>
									<INPUT class="fd" id="cmdFecha" style="WIDTH: 36px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFecha',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFecha">&nbsp;
									<asp:requiredfieldvalidator id="rfvFecha" runat="server" Width="11px" ControlToValidate="txtFecha" Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:Button id="cmdConsultar" runat="server" Text="Consultar"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblmsg" runat="server" CssClass="msg"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgSaldos" runat="server" Width="518px" Height="10px" AutoGenerateColumns="False"
							BorderWidth="1px" BorderColor="CadetBlue" CellPadding="2" CssClass="Grid" AllowSorting="True"
							ShowFooter="True" OnItemDataBound="ComputeSum">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CodProveedor" SortExpression="CodProveedor" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Provedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="Saldo" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SaldoPend" SortExpression="SaldoPend" HeaderText="Pendiente" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
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
