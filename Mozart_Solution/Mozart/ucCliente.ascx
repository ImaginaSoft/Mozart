<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCliente.ascx.vb" Inherits="ucCliente" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 593px; HEIGHT: 64px" cellSpacing="1"
	cellPadding="1" width="593" border="0">
	<TR>
		<TD style="WIDTH: 52px; HEIGHT: 24px">
			<asp:label id="Label3" EnableViewState="False" CssClass="Cabecera" runat="server"> Cliente</asp:label>&nbsp;</TD>
		<TD style="WIDTH: 321px; HEIGHT: 24px">
			<asp:label id="lblNombre" runat="server" CssClass="Cabecera" Width="313px"></asp:label></TD>
		<TD style="HEIGHT: 24px">
			<asp:label id="Label7" runat="server" CssClass="Cabecera" EnableViewState="False">Vendedor</asp:label></TD>
		<TD style="HEIGHT: 24px">
			<asp:label id="lblNomVendedor" runat="server" CssClass="Cabecera" Width="126px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 52px">
			<asp:label id="Label4" EnableViewState="False" CssClass="Cabecera" runat="server"> Email</asp:label>&nbsp;&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 321px">
			<asp:label id="lblEmail" runat="server" CssClass="Cabecera" Width="312px"></asp:label></TD>
		<TD>
			<asp:label id="Label1" EnableViewState="False" CssClass="Cabecera" runat="server"> Teléfono</asp:label>&nbsp;</TD>
		<TD>
			<asp:label id="lblFono" runat="server" CssClass="Cabecera" Width="109px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 52px">
			<asp:label id="Label2" EnableViewState="False" CssClass="Cabecera" runat="server"> País</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 321px"><asp:label id="lblPais" runat="server" CssClass="Cabecera" Width="282px"></asp:label></TD>
		<TD></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 52px">ID</TD>
		<TD style="WIDTH: 321px">
			<asp:label id="lblClaveCliente" runat="server" CssClass="Cabecera" Width="282px"></asp:label></TD>
		<TD></TD>
		<TD></TD>
	</TR>
</TABLE>
<asp:label id="Cod" runat="server" Width="38px" Visible="False"></asp:label>

