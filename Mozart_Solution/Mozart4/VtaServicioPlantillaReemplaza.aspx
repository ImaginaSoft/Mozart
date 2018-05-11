<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioPlantillaReemplaza.aspx.vb" Inherits="VtaServicioPlantillaReemplaza" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 10px; WIDTH: 589px; POSITION: absolute; TOP: 7px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="0" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Reemplazar servicio en todas las plantillas</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">Servicio Actual N°
						<asp:label id="lblNroServicioActual" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 520px; HEIGHT: 108px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="520" border="1">
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 10px">Proveedor</TD>
								<TD style="HEIGHT: 10px"><asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="288px" AutoPostBack="True"
										DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlCiudad" runat="server" Width="288px" AutoPostBack="True" DataValueField="CodCiudad"
										DataTextField="NomCiudad"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 17px">Tipo Servicio</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddltiposervicio" runat="server" Width="288px" AutoPostBack="True" DataValueField="CodTipoServicio"
										DataTextField="TipoServicio"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 24px">Servicio actual</TD>
								<TD style="HEIGHT: 24px"><asp:dropdownlist id="ddlServicio" runat="server" Width="424px" AutoPostBack="True" DataValueField="NroServicio"
										DataTextField="DesProveedor"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">Nuevo Servicio N°
						<asp:label id="lblNroServicioNuevo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 520px; HEIGHT: 108px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="520" border="1">
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 7px">Proveedor</TD>
								<TD style="HEIGHT: 7px"><asp:dropdownlist id="ddlProveedor2" tabIndex="1" runat="server" Width="288px" AutoPostBack="True"
										DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 6px">Ciudad</TD>
								<TD style="HEIGHT: 6px"><asp:dropdownlist id="ddlCiudad2" runat="server" Width="288px" AutoPostBack="True" DataValueField="CodCiudad"
										DataTextField="NomCiudad"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 17px">Tipo Servicio</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlTipoServicio2" runat="server" Width="288px" AutoPostBack="True" DataValueField="CodTipoServicio"
										DataTextField="TipoServicio"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 24px">Nuevo servicio</TD>
								<TD style="HEIGHT: 24px"><asp:dropdownlist id="ddlServicio2" runat="server" Width="424px" AutoPostBack="True" DataValueField="NroServicio"
										DataTextField="DesProveedor"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="425px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
