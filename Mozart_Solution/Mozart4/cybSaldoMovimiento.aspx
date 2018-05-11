<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybSaldoMovimiento.aspx.vb" Inherits="cybSaldoMovimiento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 768px; POSITION: absolute; TOP: 8px; HEIGHT: 244px"
				cellSpacing="0" cellPadding="1" width="768" border="0" class="FORM">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 402px; HEIGHT: 13px" cellSpacing="0" cellPadding="0"
							width="402" border="1" borderColor="#cccccc">
							<TR>
								<TD>
									Movimientos a partir del</TD>
								<TD style="WIDTH: 137px">
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" 
										CssClass="fd"></asp:textbox>
									<INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" ControlToValidate="txtFchEmision"
										Height="8px" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:Button id="cmdConsultar" runat="server" Text="Consultar"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="542px"  CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgMvto" runat="server" Width="776px" Height="17px" AutoGenerateColumns="False"
							BorderWidth="1px" CellPadding="2" CssClass="Grid" BorderColor="CadetBlue" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" SortExpression="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" SortExpression="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDepositoTC" SortExpression="NroDepositoTC" HeaderText="Grupo" DataFormatString="{0:#########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DocMonto" SortExpression="DocMonto" HeaderText="Cargo/Abono" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="Saldo" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="Tipo Servicio">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="clipro" SortExpression="clipro" HeaderText="Cliente / Proveedor / Personal">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ComisionTC" SortExpression="ComisionTC" HeaderText="Comi.TC" DataFormatString="{0:###,###,###,###.00}">
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
