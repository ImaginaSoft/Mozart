<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaMLinkNuevo.aspx.vb" Inherits="VtaMLinkNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 537px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="537" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="Titulo" runat="server" Cssclass="Titulo"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 538px; HEIGHT: 121px" cellSpacing="0" cellPadding="0"
							width="538" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 60px">&nbsp;Código</TD>
								<TD>
									<asp:Label id="lblcodigo" runat="server">0</asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px">
									&nbsp;Pagina</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="470px" MaxLength="150" TextMode="MultiLine"
										Height="96px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px">&nbsp;Título</TD>
								<TD><asp:textbox id="txtTitulo" runat="server" Width="289px" MaxLength="100"></asp:textbox>
									<asp:requiredfieldvalidator id="rvfTitulo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtTitulo"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px; HEIGHT: 17px">&nbsp;Ciudad</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlCiudad" tabIndex="1" runat="server" Width="288px" DataTextField="NomCiudad"
										DataValueField="CodCiudad" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px">&nbsp;Tipo Link</TD>
								<TD><asp:dropdownlist id="ddlTipoLink" tabIndex="1" runat="server" Width="288px" DataTextField="tipolink"
										DataValueField="codtipolink" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px">&nbsp;Telefono</TD>
								<TD>
									<asp:textbox id="txtTelefono1" runat="server" MaxLength="25" Width="192px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 60px">&nbsp;Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" CssClass="msg" Height="17px" Width="408px"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
