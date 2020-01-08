<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionDesaprueba.aspx.vb" Inherits="VtaVersionDesaprueba" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="593" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 591px; HEIGHT: 64px" cellSpacing="0" cellPadding="0"
							width="591" border="1">
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 25px">&nbsp;Nro Versión</TD>
								<TD style="HEIGHT: 25px">&nbsp;
									<asp:label id="lblNroVersion" runat="server" Width="81px" ForeColor="Black"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label2" runat="server">Estado</asp:label>
									<asp:label id="lblStsVersion" runat="server" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Descripción</TD>
								<TD>&nbsp;
									<asp:label id="lblDesVersion" runat="server" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 24px">&nbsp;Fecha</TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:label id="lblFchVersion" runat="server" Width="187px" ForeColor="Black"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label7" runat="server" Width="84px">Fecha Inicio:</asp:label><asp:label id="lblFchInicio" runat="server" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 20px">&nbsp;% Utilidad</TD>
								<TD style="HEIGHT: 20px">&nbsp;
									<asp:label id="lblPorUtilidad" runat="server" Width="213px" ForeColor="Black"></asp:label>&nbsp;
									<asp:label id="Label8" runat="server">Publicado</asp:label>&nbsp;
									<asp:label id="lblFlagPublica" runat="server" ForeColor="Black"></asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Pasajeros</TD>
	&nbsp;&nbsp;
									<asp:label id="lblPasajeros" runat="server" ForeColor="Black"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdGrabar" runat="server" Width="128px" Visible="False" Text="Desaprobar Versión"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="545px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblFlagAtencion" runat="server" ForeColor="Black" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>

</body>
</html>
