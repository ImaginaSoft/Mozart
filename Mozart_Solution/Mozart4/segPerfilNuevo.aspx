<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segPerfilNuevo.aspx.vb" Inherits="segPerfilNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="FORM" id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 473px; POSITION: absolute; TOP: 8px; HEIGHT: 200px"
				cellSpacing="0" cellPadding="0" width="473" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 7px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 5px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtRegresar" runat="server" Width="70px">• Perfiles</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 472px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="472" border="1">
							<TR>
								<TD style="WIDTH: 54px; HEIGHT: 1px"><FONT size="2">Código</FONT></TD>
								<TD style="WIDTH: 214px; HEIGHT: 1px"><FONT size="2"><asp:textbox id="txtCodigo" tabIndex="1" runat="server" Width="135px" MaxLength="15"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 54px; HEIGHT: 26px"><FONT size="2">Nombre</FONT></TD>
								<TD style="HEIGHT: 26px">
									<asp:textbox id="txtNombre" tabIndex="2" runat="server" Width="318px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 54px; HEIGHT: 28px"><FONT size="2"><FONT size="2">Estado</FONT></FONT></TD>
								<TD style="HEIGHT: 28px"><asp:radiobutton id="rbActivo" tabIndex="3" runat="server" Text="Activo" Checked="True" GroupName="estado"></asp:radiobutton><asp:radiobutton id="rbInactivo" tabIndex="4" runat="server" Text="Inactivo" GroupName="estado"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 9px"><asp:button id="cmdGrabar" runat="server" Text="Grabar"></asp:button><asp:label id="lblMsg" runat="server" Width="344px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
</body>
</html>
