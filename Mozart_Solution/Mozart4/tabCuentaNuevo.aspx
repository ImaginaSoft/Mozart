<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabCuentaNuevo.aspx.vb" Inherits="tabCuentaNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<P></P>
			<P>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 473px; POSITION: absolute; TOP: 8px; HEIGHT: 136px"
					cellSpacing="0" cellPadding="0" width="473" border="0" class="Form">
					<TR>
						<TD class="Titulo" style="HEIGHT: 9px">
							<asp:Label id="lbltitulo" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 472px; HEIGHT: 96px" cellSpacing="0" cellPadding="0"
								width="472" border="1" borderColor="#cccccc">
								<TR>
									<TD style="WIDTH: 110px; HEIGHT: 16px" bgColor="#f5f5f5">Código cuenta</TD>
									<TD style="WIDTH: 207px; HEIGHT: 16px" bgColor="#f5f5f5">
										<asp:textbox id="txtCodCuenta" runat="server" Width="61px" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 110px" bgColor="#f5f5f5">Nombre cuenta</TD>
									<TD style="WIDTH: 207px" bgColor="#f5f5f5">
										<asp:textbox id="txtNomCuenta" runat="server" Width="327px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 110px; HEIGHT: 1px">Tipo cuenta</TD>
									<TD style="WIDTH: 207px; HEIGHT: 1px">
										<asp:dropdownlist id="ddlTipoCuenta" runat="server" Width="288px" AutoPostBack="True" DataTextField="NomElemento"
											DataValueField="CodElemento"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 110px">Grupo Cuenta</TD>
									<TD style="WIDTH: 207px">
										<asp:dropdownlist id="ddlGrupoCuenta" runat="server" Width="288px" DataValueField="CodElemento" DataTextField="NomElemento"
											AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnGrabar" runat="server" Text="Grabar" Width="72px"></asp:Button></TD>
					</TR>
					<TR>
						<TD>&nbsp;
							<asp:label id="lblMsg" runat="server" Width="376px" CssClass="error" 
                                Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
