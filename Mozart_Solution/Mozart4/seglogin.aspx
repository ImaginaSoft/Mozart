<%@ Page Language="VB" AutoEventWireup="false" CodeFile="seglogin.aspx.vb" Inherits="seglogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
	</HEAD>
	<body  bgcolor='<%=Session("MenuColorBG")%>'>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 102; LEFT: 216px; WIDTH: 294px; POSITION: absolute; TOP: 128px; HEIGHT: 179px"
				cellSpacing="1" cellPadding="1" width="294" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 9pt; FONT-FAMILY: Verdana, Arial" align="center">
						<asp:Label id="lblMandante" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 9pt; FONT-FAMILY: Verdana, Arial">
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Verdana, Arial">&nbsp;Ingrese 
						su código y clave de usuario</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 9pt; FONT-FAMILY: Verdana">
						<TABLE id="Table1" style="WIDTH: 295px; HEIGHT: 89px" cellSpacing="1" cellPadding="1" width="295"
							border="0">
							<TR>
								<TD style="FONT-SIZE: 9pt; WIDTH: 73px; FONT-FAMILY: Verdana, Arial">&nbsp;Código&nbsp;&nbsp;</TD>
								<TD style="FONT-SIZE: 9pt; WIDTH: 175px; FONT-FAMILY: Verdana, Arial; HEIGHT: 25px">
									<asp:textbox id="txtCodUsuario" runat="server" MaxLength="15" Height="21px" Width="170px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-SIZE: 9pt; WIDTH: 73px; FONT-FAMILY: Verdana, Arial">&nbsp;Clave</TD>
								<TD style="FONT-SIZE: 9pt; WIDTH: 175px; FONT-FAMILY: Verdana, Arial; HEIGHT: 25px">
									<asp:textbox id="txtClave" runat="server" MaxLength="30" Height="21px" Width="170px" TextMode="Password"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-SIZE: 9pt; WIDTH: 73px; FONT-FAMILY: Verdana, Arial"></TD>
								<TD style="FONT-SIZE: 9pt; WIDTH: 175px; FONT-FAMILY: Verdana, Arial; HEIGHT: 25px">
									<asp:Button id="cmdAceptar" runat="server" Text="Aceptar"></asp:Button></TD>
							</TR>
						</TABLE>
						<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<IMG style="Z-INDEX: 103; LEFT: 5px; POSITION: absolute; TOP: 3px" src="images/cabecera.jpg">
		</form>
</body>
</html>
