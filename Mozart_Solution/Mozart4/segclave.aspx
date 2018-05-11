<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segclave.aspx.vb" Inherits="segclave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 103; LEFT: 14px; WIDTH: 415px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="415" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Cambiar Clave de Usuario</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 408px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="408" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Usuario</TD>
								<TD>
									<asp:Label id="lblNomUsuario" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Clave actual</TD>
								<TD>
									<asp:textbox id="txtClave" runat="server" MaxLength="15" Height="21px" Width="170px" TextMode="Password"></asp:textbox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Dato obligatorio" ControlToValidate="txtClave"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Nueva Clave</TD>
								<TD>
									<asp:textbox id="txtClave1" runat="server" MaxLength="30" Height="21px" Width="170px" TextMode="Password"></asp:textbox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Dato obligatorio" ControlToValidate="txtClave1"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Repita Nueva Clave</TD>
								<TD>
									<asp:textbox id="txtclave2" runat="server" MaxLength="30" Height="21px" Width="170px" TextMode="Password"></asp:textbox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Dato obligatorio" ControlToValidate="txtclave2"></asp:RequiredFieldValidator></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdAceptar" runat="server" Text="Aceptar"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" CssClass="ERROR"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
