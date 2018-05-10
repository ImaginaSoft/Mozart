<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPlantilla.ascx.vb" Inherits="ucPlantilla" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 490px; HEIGHT: 38px" cellSpacing="1"
	cellPadding="1" width="490" border="0">
	<TR>
		<TD style="WIDTH: 74px; HEIGHT: 25px">
			<P><asp:label id="Label6" runat="server" CssClass="Cabecera" EnableViewState="False" Width="55px">Número</asp:label></P>
		</TD>
		<TD style="HEIGHT: 25px"><asp:label id="lblNroPlantilla" runat="server" CssClass="Cabecera"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 74px"><asp:label id="Label7" runat="server" CssClass="Cabecera" EnableViewState="False" Width="54px">Titulo</asp:label></TD>
		<TD><asp:label id="lblDesPlantilla" runat="server" CssClass="Cabecera" Width="401px"></asp:label></TD>
	</TR>
</TABLE>
<asp:Label id="lblCodZonaVta" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblStsPlantilla" runat="server" Visible="False"></asp:Label>

