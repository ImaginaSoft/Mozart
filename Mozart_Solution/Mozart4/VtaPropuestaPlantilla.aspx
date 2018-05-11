<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaPlantilla.aspx.vb" Inherits="VtaPropuestaPlantilla" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 14px; WIDTH: 555px; POSITION: absolute; TOP: 7px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="0" width="555" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Nueva Propuesta desde la Plantilla&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 35px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table5" style="WIDTH: 552px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="552" border="1">
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 25px">Zona de Venta</TD>
								<TD style="HEIGHT: 25px">
									<asp:dropdownlist id="ddlZonaVta" runat="server" AutoPostBack="True" Width="216px" DataTextField="NomZonaVta"
										DataValueField="CodZonaVta"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 25px">Nro. Platilla origen</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtNroPlantilla" runat="server" Width="84px" AutoPostBack="True" MaxLength="8"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 21px">Tipo de Plantilla</TD>
								<TD style="HEIGHT: 21px"><asp:dropdownlist id="ddlTipoPlantilla" runat="server" Width="216px" AutoPostBack="True" DataValueField="CodElemento"
										DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 25px">Ingrese Titulo&nbsp;
									<asp:label id="Label1" runat="server" CssClass="error">(TAB)</asp:label></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtTitulo" runat="server" Width="211px" AutoPostBack="True" MaxLength="80"></asp:textbox>&nbsp;
									<asp:checkbox id="chbTitulo" runat="server" AutoPostBack="True" Text="Exacto"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;Dias
									<asp:textbox id="txtCantDias" runat="server" Width="32px" AutoPostBack="True" MaxLength="3"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:dropdownlist id="ddlPlantilla" runat="server" Width="552px" AutoPostBack="True" DataValueField="NroPlantilla"
							DataTextField="DesPlantilla"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 552px; HEIGHT: 80px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="552" border="1">
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 25px">Nro. Propuesta Destino</TD>
								<TD style="HEIGHT: 25px"><asp:dropdownlist id="ddlPropuesta" runat="server" Width="384px" AutoPostBack="True" DataValueField="NroPropuesta"
										DataTextField="DesPropuesta"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px">Día de inicio</TD>
								<TD><asp:textbox id="txtNroDiaInicio" runat="server" Width="40px" MaxLength="2"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 20px">Idioma</TD>
								<TD style="HEIGHT: 20px"><asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px">Fecha Inicio
								</TD>
								<TD><asp:textbox id="txtFchInicio" runat="server" Width="75px" AutoPostBack="True" ></asp:textbox><INPUT class="fd" id="cmdFchInicio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicio"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px">N° de Pasajeros</TD>
								<TD>
									<TABLE class="tabla" id="Table1" borderColor="#cccccc" cellSpacing="0" cellPadding="0"
										width="100%" border="1">
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
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="457px" CssClass="ERROR"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
