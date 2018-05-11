<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVersion.ascx.vb" Inherits="ucVersion" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 800px; HEIGHT: 96px" cellSpacing="0"
	cellPadding="0" width="600" border="0">
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 19px"><asp:label id="Label6" runat="server" EnableViewState="False" Width="43px">Cliente</asp:label>&nbsp;</TD>
		<TD style="WIDTH: 427px; HEIGHT: 19px">
			<asp:Label id="lblNombre" Width="728px" runat="server" CssClass="cabecera"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 17px"><asp:label id="Label7" runat="server" EnableViewState="False" Width="41px">Pedido</asp:label>&nbsp;&nbsp;</TD>
		<TD style="WIDTH: 427px; HEIGHT: 17px">
			<asp:Label id="lblDesPedido" Width="727px" runat="server" CssClass="cabecera"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 17px">
			<asp:label id="Label1" EnableViewState="False" runat="server" Width="47px">Versión</asp:label></TD>
		<TD style="WIDTH: 427px; HEIGHT: 17px">
			<asp:Label id="NV" runat="server"></asp:Label>
			<asp:Label id="lblDesVersion" runat="server" CssClass="cabecera"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 18px"></TD>
		<TD style="WIDTH: 427px; HEIGHT: 18px">
			<asp:Label id="lblCantPersonas" Width="728px" runat="server" CssClass="cabecera" Height="8px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 18px"></TD>
		<TD style="WIDTH: 427px; HEIGHT: 18px">
			<TABLE id="Table2" style="WIDTH: 728px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="728"
				border="0" class="cabecera">
				<TR>
					<TD style="WIDTH: 53px">
						<asp:label id="Label2" EnableViewState="False" runat="server" CssClass="Form">Servicio </asp:label></TD>
					<TD style="WIDTH: 79px" align="left">
						<asp:label id="lblSer" Width="64px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 19px" align="right">
						<asp:label id="Label5" Width="24px" EnableViewState="False" runat="server" CssClass="Form">IGV</asp:label></TD>
					<TD style="WIDTH: 48px" align="left">&nbsp;
						<asp:label id="lblIGV" Width="58px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 98px" align="right">
						<asp:label id="utilidad" Width="72px" EnableViewState="False" runat="server" CssClass="Form">Utilidad</asp:label></TD>
					<TD style="WIDTH: 100px" align="left">&nbsp;
						<asp:label id="lbluti" Width="72px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 38px" align="right">
						<asp:label id="Label3" EnableViewState="False" runat="server" CssClass="Form">Ajuste</asp:label></TD>
					<TD style="WIDTH: 82px" align="left">&nbsp;
						<asp:label id="lblAju" Width="72px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 30px" align="left">
						<asp:label id="Label4" EnableViewState="False" runat="server" CssClass="Form">Total</asp:label></TD>
					<TD align="left">&nbsp;
						<asp:label id="lbltot" Width="70px" runat="server" CssClass="Cabecera"></asp:label></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 53px; HEIGHT: 18px">
			<asp:label id="Label8" Width="41px" EnableViewState="False" runat="server">Link</asp:label></TD>
		<TD style="WIDTH: 427px; HEIGHT: 18px">
			<asp:TextBox ID="lblPaginaPersonalizada" runat="server" BackColor="#CCFFFF" 
                Width="734px"></asp:TextBox>
        </TD>
	</TR>
</TABLE>
<asp:Label id="lblstsVersion" runat="server" Visible="False"></asp:Label>
<asp:label id="lblPublica" Width="64px" runat="server" Visible="False"></asp:label>
<asp:Label id="lblIDCliente" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblFlagIdioma" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblCliente" runat="server" Visible="False"></asp:Label>

