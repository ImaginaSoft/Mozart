<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaNueva.aspx.vb" Inherits="VtaPropuestaNueva" %>

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
			<TABLE class="form" id="Table4" style="Z-INDEX: 103; LEFT: 16px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="0" width="593" border="0">
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
						<TABLE class="tabla" id="Table1" style="WIDTH: 591px; HEIGHT: 128px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="591" border="1">
							<TR>
								<TD style="WIDTH: 134px; HEIGHT: 21px">&nbsp;Nro. Propuesta</TD>
								<TD style="HEIGHT: 21px"><asp:label id="lblNroPropuesta" runat="server" ForeColor="Black" Width="81px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px">&nbsp;Descripción</TD>
								<TD><asp:textbox id="txtDesPropuesta" runat="server" Width="347px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px; HEIGHT: 24px">&nbsp;Fecha</TD>
								<TD style="HEIGHT: 24px"><asp:label id="lblFchPropuesta" runat="server" ForeColor="Black" Width="213px"></asp:label>&nbsp;<asp:label id="Label2" runat="server">Estado</asp:label>&nbsp;
									<asp:label id="lblStsPropuesta" runat="server" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px">&nbsp;Idioma</TD>
								<TD><asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px">&nbsp;% Utilidad</TD>
								<TD><asp:textbox id="txtPorUtilidad" runat="server" Width="43px" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ForeColor=" " Width="168px" CssClass="error"
										ErrorMessage="Dato obligatorio" ControlToValidate="txtPorUtilidad"></asp:requiredfieldvalidator>&nbsp;Publicado
									<asp:label id="lblPublica" runat="server" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px; HEIGHT: 15px">&nbsp;N° de Pasajeros</TD>
								<TD style="HEIGHT: 15px">
									<TABLE class="tabla" id="Table2" borderColor="#cccccc" cellSpacing="0" cellPadding="0"
										width="288" border="0" style="WIDTH: 288px; HEIGHT: 72px">
										<TR>
											<TD></TD>
											<TD>
												<asp:label id="Label1" runat="server">Simple</asp:label></TD>
											<TD>
												<asp:label id="Label5" runat="server">Doble</asp:label></TD>
											<TD>
												<asp:label id="Label3" runat="server">Triple</asp:label></TD>
											<TD>
												<asp:label id="Label4" runat="server">Cuadruple</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label6" runat="server">Adultos</asp:label></TD>
											<TD>
												<asp:textbox id="txtAS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtAD" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtAT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtAC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label7" runat="server">Niños</asp:label></TD>
											<TD>
												<asp:textbox id="txtNS" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtND" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtNT" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtNC" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 134px; HEIGHT: 13px">Fecha de inicio</TD>
								<TD style="HEIGHT: 13px">
									<asp:textbox id="txtFchInicio" runat="server" Width="75px"  AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchInicio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicio"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="545px" CssClass="ERROR"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
