<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segUsuarioClave.aspx.vb" Inherits="segUsuarioClave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgColor="#cccccc">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 105; LEFT: 8px; WIDTH: 408px; POSITION: absolute; TOP: 8px; HEIGHT: 145px"
				cellSpacing="0" cellPadding="0" width="408" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Cambiar clave del usuario</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtRegresar" runat="server" Width="70px">• Regresar</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 61px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 403px; HEIGHT: 36px" cellSpacing="0" cellPadding="0"
							width="403" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 78px">&nbsp;Usuario</TD>
								<TD>
									<asp:Label id="lblNomUsuario" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 78px">&nbsp;Nueva Clave</TD>
								<TD>
									<asp:textbox id="txtClave" runat="server" MaxLength="15" Height="21px" Width="170px" TextMode="Password"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdAceptar" runat="server" Text="Aceptar"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
