<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucProveedor.ascx.vb" Inherits="ucProveedor" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 576px; HEIGHT: 56px" cellSpacing="1"
	cellPadding="1" width="576" border="0">
	<TR>
		<TD style="WIDTH: 71px; HEIGHT: 24px">
			<asp:label id="Label3" EnableViewState="False" CssClass="Cabecera" runat="server"> Proveedor</asp:label></TD>
		<TD style="WIDTH: 236px; HEIGHT: 24px">
			<asp:label id="lblCod" runat="server" CssClass="Cabecera" Width="23px"></asp:label>&nbsp;<asp:label id="lblNombre" runat="server" CssClass="Cabecera" Width="158px"></asp:label></TD>
		<TD style="WIDTH: 62px; HEIGHT: 24px">
			<asp:Label id="Label2" runat="server" CssClass="Cabecera">Email </asp:Label></TD>
		<TD style="HEIGHT: 24px">
			<asp:label id="lblEmail" runat="server" CssClass="Cabecera" Width="192px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 71px; HEIGHT: 17px">
			<asp:Label id="Contacto" runat="server" CssClass="Cabecera">Contacto</asp:Label></TD>
		<TD style="WIDTH: 236px; HEIGHT: 17px">
			<asp:label id="lblContacto" runat="server" CssClass="Cabecera" Width="188px"></asp:label>&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 62px; HEIGHT: 17px">
			<asp:Label id="Label1" runat="server" CssClass="Cabecera">Telefono </asp:Label></TD>
		<TD style="HEIGHT: 17px">
			<asp:label id="lblTelefono" runat="server" CssClass="Cabecera" Width="188px"></asp:label></TD>
	</TR>
	</TR>
</TABLE>

