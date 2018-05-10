<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segUsuarioNuevo.aspx.vb" Inherits="segUsuarioNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 760px; POSITION: absolute; TOP: 8px; HEIGHT: 344px"
				cellSpacing="0" cellPadding="0" width="760" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 7px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 5px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtRegresar" runat="server" Width="70px">• Regresar</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">
						<TABLE class="form" id="Table1" style="WIDTH: 696px; HEIGHT: 200px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="696" border="1">
							<TR>
								<TD style="WIDTH: 150px"><FONT size="2">Código</FONT></TD>
								<TD style="WIDTH: 214px; HEIGHT: 9px"><FONT size="2"><asp:textbox id="txtCodigo" tabIndex="1" runat="server" Width="135px" MaxLength="15"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 26px"><FONT size="2">Nombre</FONT></TD>
								<TD style="HEIGHT: 26px"><asp:textbox id="txtNombre" tabIndex="2" runat="server" Width="318px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Perfil</TD>
								<TD><asp:dropdownlist id="ddlPerfil" runat="server" Width="317px" DataValueField="CodPerfil" DataTextField="NomPerfil"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 28px"><FONT size="2"><FONT size="2">Estado</FONT></FONT></TD>
								<TD style="HEIGHT: 28px"><asp:radiobutton id="rbActivo" tabIndex="3" runat="server" Text="Activo" Checked="True" GroupName="estado"></asp:radiobutton>&nbsp;&nbsp;<asp:radiobutton id="rbInactivo" tabIndex="4" runat="server" Text="Inactivo" GroupName="estado"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 21px">Default Idioma del Pedido</TD>
								<TD style="HEIGHT: 21px"><asp:dropdownlist id="ddlIdioma" tabIndex="6" 
                                        runat="server" Width="317px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 20px">Consulta log acceso</TD>
								<TD style="HEIGHT: 20px">
									<asp:DropDownList ID="ddlLog" runat="server" Width="317px">
                                        <asp:ListItem Value="P">Solo del usuario</asp:ListItem>
                                        <asp:ListItem Value="T">Todos los usuarios</asp:ListItem>
                                    </asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 20px">Consulta Ventas
								</TD>
								<TD style="HEIGHT: 20px">
									<asp:DropDownList ID="ddlVentas" runat="server" Width="317px">
                                        <asp:ListItem Value="P">Solo del vendedor</asp:ListItem>
                                        <asp:ListItem Value="T">Todos los vendedores</asp:ListItem>
                                    </asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 20px">Consulta Email Cliente</TD>
								<TD style="HEIGHT: 20px">
									<asp:DropDownList ID="ddlEmail" runat="server" Width="317px">
                                        <asp:ListItem Value="P">Solo del vendedor</asp:ListItem>
                                        <asp:ListItem Value="T">Todos los vendedores</asp:ListItem>
                                    </asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Acceso a Mozart</TD>
								<TD>
									<asp:RadioButton id="rbtAmbos" runat="server" GroupName="g5" Checked="True" Text="Ambos"></asp:RadioButton>&nbsp;
									<asp:RadioButton id="rbtLocal" runat="server" GroupName="g5" Text="Local"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtExterno" runat="server" GroupName="g5" Text="Externo"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px" vAlign="top">
									<P>Fecha de inicio&nbsp;a partir del cual consulta tarifas</P>
								</TD>
								<TD>
									<TABLE class="FORM" id="Table4" style="WIDTH: 539px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
										width="539" border="0">
										<TR>
											<TD style="WIDTH: 201px; HEIGHT: 17px">
												<asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchInicial">
												<asp:LinkButton id="LinkButton1" runat="server">Limpiar</asp:LinkButton></TD>
											<TD style="HEIGHT: 17px">1. Fecha en blanco&nbsp;muestra&nbsp;tarifas vigentes</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 201px; HEIGHT: 19px"></TD>
											<TD style="HEIGHT: 19px">2. Asigne fecha&nbsp;si desea ver&nbsp;historial de 
												tarifas</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px"><asp:button id="cmdGrabar" runat="server" Text="Grabar"></asp:button>&nbsp;<asp:label id="lblMsg" runat="server" Width="344px" CssClass="error"></asp:label></TD>
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
