﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogRevisaFoto.aspx.vb" Inherits="blogRevisaFoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 620px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
				cellSpacing="0" cellPadding="1" width="620" border="0">
				<TR>
					<TD>
						<P class="Titulo">Revisar Fotos&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 24px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 15px">Vendedor</TD>
								<TD style="WIDTH: 338px; HEIGHT: 15px"><asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 15px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px">
									Fecha de ingreso</TD>
								<TD style="WIDTH: 338px"><asp:textbox id="txtFchInicial" runat="server" Width="75px" DESIGNTIMEDRAGDROP="21" CssClass="fd"
										></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" Height="8px" DESIGNTIMEDRAGDROP="23"
										CssClass="error" ForeColor=" " ControlToValidate="txtFchInicial">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px" DESIGNTIMEDRAGDROP="25" CssClass="fd"
										></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" Height="8px" DESIGNTIMEDRAGDROP="27"
										CssClass="ERROR" ForeColor=" " ControlToValidate="txtFchFinal">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"><asp:label id="lblmsg" runat="server" Width="462px" Height="9px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPedidos" runat="server" Width="776px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Target=_blank Text="Blog" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"NavigateUrl")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" ReadOnly="True" HeaderText="Fecha ">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrdenFoto" SortExpression="NroOrdenFoto" HeaderText="N&#176; Foto">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TamanoKB" SortExpression="TamanoKB" HeaderText="Size KB">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesRevision" SortExpression="DesRevision" HeaderText="Sts">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuReviso" SortExpression="CodUsuReviso" HeaderText="Revisado"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
