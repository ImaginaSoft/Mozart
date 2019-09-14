<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPropuesta.ascx.vb" Inherits="ucPropuesta" %>
<LINK href="Styles.css" type="text/css" rel="stylesheet">
<TABLE class="cabecera" id="Table1" style="WIDTH: 800px; HEIGHT: 66px" cellSpacing="0"
	cellPadding="0" width="760" border="0">
	<TR>
		<TD style="WIDTH: 77px; HEIGHT: 17px"><asp:label id="Label6" runat="server" EnableViewState="False" Width="54px">Cliente</asp:label></TD>
		<TD style="WIDTH: 420px; HEIGHT: 21px">
			<asp:Label id="lblNombre" CssClass="cabecera" runat="server" Width="707px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 77px; HEIGHT: 21px"><asp:label id="Label9" runat="server" EnableViewState="False"> Propuesta</asp:label></TD>
		<TD style="WIDTH: 420px; HEIGHT: 17px">
			<asp:Label id="lblDesPropuesta" CssClass="Cabecera" runat="server" Width="712px"></asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 77px; HEIGHT: 17px"><asp:label id="Nro" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
		<TD style="WIDTH: 420px; HEIGHT: 17px"><asp:label id="lblCantPersonas" runat="server" CssClass="Cabecera" EnableViewState="False"
				Width="712px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 77px; HEIGHT: 17px" vAlign="top"></TD>
		<TD style="WIDTH: 420px; HEIGHT: 17px">
			<TABLE class="cabecera" id="Table2" style="WIDTH: 712px; HEIGHT: 24px" cellSpacing="0"
				cellPadding="0" width="712" border="0">
				<TR>
					<TD style="WIDTH: 45px" align="left">
						<asp:label id="Label14" Width="48px" EnableViewState="False" runat="server" CssClass="Form">Servicio</asp:label></TD>
					<TD style="WIDTH: 38px" align="left">
						<asp:label id="lblSer" Width="104px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 38px" align="right">
						<asp:label id="Label12" EnableViewState="False" runat="server" CssClass="Form">IGV</asp:label></TD>
					<TD style="WIDTH: 75px" align="left">&nbsp;
						<asp:label id="lblIGV" Width="64px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 93px" align="right">
						<asp:label id="utilidad" Width="101px" EnableViewState="False" runat="server" CssClass="Form">Utilidad</asp:label></TD>
					<TD style="WIDTH: 53px" align="left">
						<asp:label id="lbluti" Width="88px" runat="server" CssClass="Cabecera"></asp:label></TD>
					<TD style="WIDTH: 47px" align="right">&nbsp;
						<asp:label id="Label4" Width="40px" EnableViewState="False" runat="server" CssClass="Form">Total</asp:label></TD>
					<TD align="left">&nbsp;
						<asp:label id="lbltot" Width="35px" runat="server" CssClass="Cabecera"></asp:label></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 77px; HEIGHT: 17px">
			<asp:label id="Label1" EnableViewState="False" runat="server">Link</asp:label></TD>
		<TD style="WIDTH: 420px; HEIGHT: 17px">
			<asp:TextBox ID="lblPaginaPersonalizada" runat="server" Width="696px" 
                BackColor="#CCFFFF"></asp:TextBox>
            <asp:TextBox ID="lblPaginaPersonalizada_old" runat="server" Width="696px" 
                BackColor="#CCFFFF"></asp:TextBox>
        </TD>
	</TR>
</TABLE>
<asp:label id="lblstsPropuesta" runat="server" Visible="False"></asp:label>
<asp:label id="lblPublica" Width="48px" runat="server" Visible="False"></asp:label>
<asp:Label id="lblEmailCliente" Width="80px" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblCodCliente" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblFlagEdita" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblCodZonaVta" runat="server" Visible="False"></asp:Label>
<asp:Label id="lblIDCliente" runat="server" Visible="False"></asp:Label>

