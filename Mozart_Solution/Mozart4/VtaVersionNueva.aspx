<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionNueva.aspx.vb" Inherits="VtaVersionNueva" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 104; LEFT: 16px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
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
						<TABLE class="tabla" id="Table1" style="WIDTH: 591px; HEIGHT: 112px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="591" border="1">
							<TR>
								<TD style="WIDTH: 119px; HEIGHT: 25px">&nbsp;Nro. Versión</TD>
								<TD style="HEIGHT: 25px">&nbsp;
									<asp:label id="lblNroVersion" runat="server" CssClass="dato" Width="81px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px">&nbsp;Descripción</TD>
								<TD><asp:textbox id="txtDesVersion" runat="server" Width="347px"></asp:textbox><asp:requiredfieldvalidator id="rfvNomPedido" runat="server" CssClass="error" Width="93px" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtDesVersion"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px; HEIGHT: 22px">&nbsp;Fecha Versión</TD>
								<TD style="HEIGHT: 22px">&nbsp;
									<asp:label id="lblFchVersion" runat="server" CssClass="dato" Width="129px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado&nbsp;<asp:label id="lblStsVersion" runat="server" CssClass="dato"></asp:label>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px; HEIGHT: 21px">&nbsp;Idioma</TD>
								<TD style="HEIGHT: 21px"><asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px">&nbsp;% Utilidad</TD>
								<TD><asp:textbox id="txtPorUtilidad" runat="server" Width="43px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtPorUtilidad"></asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label1" runat="server">Publicado</asp:label>&nbsp;
									<asp:label id="lblPublica" runat="server" CssClass="dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px">&nbsp;N° de Pasajeros</TD>
								<TD>
									<TABLE class="tabla" id="Table2" style="WIDTH: 272px; HEIGHT: 72px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="272" border="0">
										<TR>
											<TD></TD>
											<TD><asp:label id="Label2" runat="server">Simple</asp:label></TD>
											<TD><asp:label id="Label5" runat="server">Doble</asp:label></TD>
											<TD><asp:label id="Label3" runat="server">Triple</asp:label></TD>
											<TD><asp:label id="Label4" runat="server">Cuadruple</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label6" runat="server">Adultos</asp:label></TD>
											<TD><asp:textbox id="txtAS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAD" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label7" runat="server">Niños</asp:label></TD>
											<TD><asp:textbox id="txtNS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtND" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
									</TABLE>
									&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 119px">Fecha de inicio</TD>
								<TD><asp:textbox id="txtFchInicio" runat="server" Width="75px"  AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchInicio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicio"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar "></asp:Button>&nbsp;
						<asp:label id="lblMsg" runat="server" CssClass="error" Width="488px" Height="22px"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>

</body>
</html>
