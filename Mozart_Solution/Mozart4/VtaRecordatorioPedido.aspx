<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaRecordatorioPedido.aspx.vb" Inherits="VtaRecordatorioPedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 13px; WIDTH: 777px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="777"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Clientes&nbsp;para &nbsp;envio de Recordatorio</P>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table4" style="Z-INDEX: 105; LEFT: 16px; WIDTH: 576px; POSITION: absolute; TOP: 40px; HEIGHT: 67px"
				borderColor="#cccccc" cellSpacing="0" cellPadding="0" width="576" border="1">
				<TR>
					<TD style="HEIGHT: 26px">&nbsp;Permite enviar e-mail de recordatorio a todos los 
						clientes seleccionados&nbsp;que muestra en la lista</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdEnviar" runat="server" Width="168px" Text="Enviar e-mail  a los Clientes"></asp:Button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 192px" cellSpacing="1"
				cellPadding="1" width="300" border="0" class="tabla">
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgPedidos" runat="server" Width="662px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="ProximoEnvio" SortExpression="ProximoEnvio" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SgteRecord" SortExpression="SgteRecord" HeaderText="Recordatorio">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomIdioma" SortExpression="NomIdioma" HeaderText="Idioma"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" SortExpression="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="E-mail Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table1" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 576px; POSITION: absolute; TOP: 152px; HEIGHT: 33px"
				cellSpacing="0" cellPadding="0" width="576" border="1" borderColor="#cccccc">
				<TR>
					<TD>Fecha Recordatorio del</TD>
					<TD style="WIDTH: 334px">
						<asp:textbox id="txtFchInicial" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox>
						<INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
						<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchInicial"
							DESIGNTIMEDRAGDROP="23" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator>
						<asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
						&nbsp;
						<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox>
						<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchFinal"
							DESIGNTIMEDRAGDROP="27" CssClass="ERROR" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
					<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
