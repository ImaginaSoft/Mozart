<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcEnvioKitObs.aspx.vb" Inherits="cpcEnvioKitObs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 592px; POSITION: absolute; TOP: 8px; HEIGHT: 230px"
				cellSpacing="0" cellPadding="0" width="592" border="0" class="Form">
				<TR>
					<TD style="HEIGHT: 16px">
						<P class="Titulo">&nbsp;Envio de kit - actualiza observación</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 592px; HEIGHT: 140px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="592" border="1">
							<TR>
								<TD style="WIDTH: 110px">Nro Pedido</TD>
								<TD>
									<asp:label id="lblNroPedido" runat="server" Width="120px"></asp:label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 2px">Cliente</TD>
								<TD style="HEIGHT: 2px">
									<asp:Label id="lblNomCliente" runat="server" Width="456px"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 18px">Dirección</TD>
								<TD style="HEIGHT: 18px">
									<asp:Label id="lblDireccion" runat="server" Width="456px"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 16px">Ciudad</TD>
								<TD style="HEIGHT: 16px">
									<asp:Label id="lblCiudad" runat="server" Width="456px"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 18px">Observación</TD>
								<TD style="HEIGHT: 18px">
									<asp:textbox id="txtObsEnvioKit" runat="server" Width="456px" MaxLength="100"></asp:textbox>&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Estado del envio</TD>
								<TD>
									<asp:dropdownlist id="ddlStsEnvio" runat="server" Width="128px" DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="585px" CssClass="error" ></asp:label></TD>
				</TR>
			</TABLE>
			<asp:label id="lblCodigo" style="Z-INDEX: 101; LEFT: 29px; POSITION: absolute; TOP: 244px"
				runat="server" Width="46px" Visible="False">0</asp:label></form>
</body>
</html>
