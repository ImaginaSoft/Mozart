<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPedido.ascx.vb" Inherits="ucPedido" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 712px; HEIGHT: 118px" cellSpacing="0"
	cellPadding="0" width="712" border="0">
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 18px">
			Cliente</TD>
		<TD style="WIDTH: 330px; HEIGHT: 18px">
			<asp:Label id="Cod" runat="server" CssClass="Cabecera" EnableViewState="False"></asp:Label>
			<asp:Label id="lblNomCliente" CssClass="cabecera" runat="server"></asp:Label>
			<asp:Label id="lblNomComprador" CssClass="msg" runat="server"></asp:Label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 18px">
			Vendedor</TD>
		<TD style="HEIGHT: 18px">
			<asp:Label id="NomVendedor" runat="server" CssClass="Cabecera" EnableViewState="False" Width="216px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 8px">
			Email&nbsp;&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 330px; HEIGHT: 8px">
			<asp:Label id="lblEmailCliente" EnableViewState="False" CssClass="Cabecera" runat="server"
				Width="312px"></asp:Label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 8px">
			Teléfono</TD>
		<TD style="HEIGHT: 8px">
			<asp:Label id="lblFono" runat="server" CssClass="Cabecera" EnableViewState="False" Width="208px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 20px">
			Pais&nbsp;&nbsp;&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 330px; HEIGHT: 20px">
			<asp:Label id="lblPais" runat="server" CssClass="Cabecera" EnableViewState="False" Width="304px"></asp:Label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 20px">
			Perfil cliente</TD>
		<TD style="HEIGHT: 20px">
			<asp:label id="txtcumple" runat="server" CssClass="msg" EnableViewState="False" Width="208px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 16px">ID</TD>
		<TD style="WIDTH: 330px; HEIGHT: 16px">
			<asp:Label id="lblClaveCliente" EnableViewState="False" CssClass="Cabecera" runat="server"
				Width="263px"></asp:Label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 16px">Zona Venta</TD>
		<TD style="HEIGHT: 16px">
			<asp:Label id="lblZonaVta" EnableViewState="False" CssClass="Cabecera" runat="server" Width="208px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 16px">
			<asp:Label id="Label3" runat="server" CssClass="Cabecera" EnableViewState="False" Font-Bold="True">Pedido</asp:Label>&nbsp;</TD>
		<TD style="WIDTH: 330px; HEIGHT: 16px">
			<asp:label id="lbldespedido" runat="server" CssClass="Cabecera" EnableViewState="False" Width="312px"
				Font-Bold="True"></asp:label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 16px">
			<asp:Label id="Label4" runat="server" CssClass="Cabecera" EnableViewState="False" Font-Bold="True"
				Width="49px">Fecha</asp:Label>&nbsp;</TD>
		<TD style="HEIGHT: 16px">
			<asp:Label id="lblFecha" runat="server" CssClass="Cabecera" EnableViewState="False" Width="91px"
				Font-Bold="True"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px; HEIGHT: 16px">
			<asp:Label id="Label5" EnableViewState="False" CssClass="Cabecera" runat="server">Msg</asp:Label></TD>
		<TD style="WIDTH: 330px; HEIGHT: 16px">
			<asp:label id="lblEntradaSalida" EnableViewState="False" CssClass="Cabecera" runat="server"
				Width="279px"></asp:label></TD>
		<TD style="WIDTH: 84px; HEIGHT: 16px">
			<asp:Label id="Label6" EnableViewState="False" CssClass="Cabecera" runat="server" Width="49px">IngresoWeb</asp:Label></TD>
		<TD style="HEIGHT: 16px">
			<asp:Label id="lblIngresoWeb" EnableViewState="False" CssClass="Cabecera" runat="server" Width="91px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 64px"></TD>
		<TD style="WIDTH: 330px"></TD>
		<TD style="WIDTH: 84px">Atención</TD>
		<TD>
			<asp:Label id="lblMesAno" EnableViewState="False" CssClass="Cabecera" runat="server" Width="91px"></asp:Label></TD>
	</TR>
</TABLE>
<asp:Label id="lblIdioma" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblStsPedido" runat="server" Visible="False"></asp:Label>

