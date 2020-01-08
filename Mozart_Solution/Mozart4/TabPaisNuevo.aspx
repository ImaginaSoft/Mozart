<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabPaisNuevo.aspx.vb" Inherits="TabPaisNuevo" %>

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
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 473px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
					cellSpacing="0" cellPadding="0" width="473" border="0" class="Form">
					<TR>
						<TD class="Titulo" style="HEIGHT: 9px">
							<asp:Label id="lbltitulo" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 704px; HEIGHT: 176px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="704" border="1">
								<TR>
									<TD style="WIDTH: 193px"><FONT size="2">&nbsp;Código</FONT></TD>
									<TD>
										<asp:textbox id="txtCodigo" runat="server" MaxLength="3" Width="73px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ControlToValidate="txtCodigo" ErrorMessage="Dato Obligatorio"
											ForeColor=" "></asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px">&nbsp;Nombre país (español)
									</TD>
									<TD>
										<asp:textbox id="txtNombre" runat="server" MaxLength="50" Width="289px"></asp:textbox>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ControlToValidate="txtNombre"
											ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px">&nbsp;Nombre país&nbsp;(ingles)</TD>
									<TD>
										<asp:textbox id="txtNomPaisIngles" runat="server" MaxLength="50" Width="289px"></asp:textbox>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" ControlToValidate="txtNomPaisIngles"
											ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px; HEIGHT: 7px">&nbsp;Doc. Requeridos (español)</TD>
									<TD style="HEIGHT: 7px">
										<asp:textbox id="txtDocReqEsp" runat="server" MaxLength="50" Width="528px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px; HEIGHT: 18px">&nbsp;Doc. Requeridos (ingles)</TD>
									<TD style="HEIGHT: 18px">
										<asp:textbox id="txtDocReqIng" runat="server" MaxLength="50" Width="528px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px">&nbsp;Toll Free</TD>
									<TD>
										<asp:textbox id="txtTollFree" runat="server" MaxLength="50" Width="289px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 193px">&nbsp;Estado</TD>
									<TD>
										<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton>
										<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnGrabar" runat="server" Text="Grabar" Width="72px"></asp:Button></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px">&nbsp;
							<asp:label id="lblMsg" runat="server" Width="376px" Height="17px" CssClass="error" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
