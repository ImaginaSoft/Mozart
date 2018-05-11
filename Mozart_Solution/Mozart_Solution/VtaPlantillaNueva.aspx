<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaNueva.aspx.vb" Inherits="VtaPlantillaNueva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 648px; POSITION: absolute; TOP: 8px; HEIGHT: 242px"
				cellSpacing="0" cellPadding="1" width="648" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lbltitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 648px; HEIGHT: 142px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="648" border="1">
							<TR>
								<TD style="WIDTH: 127px; HEIGHT: 15px">Zona Venta</TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlZonaVta" runat="server" DataTextField="NomZonaVta" DataValueField="CodZonaVta"
										AutoPostBack="True" Width="208px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px; HEIGHT: 28px">Titulo</TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="txtTitulo" runat="server" Width="456px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px; HEIGHT: 12px">Tipo plantilla</TD>
								<TD style="HEIGHT: 12px"><asp:dropdownlist id="ddlTipoPlantilla" runat="server" DataTextField="NomElemento" DataValueField="CodElemento"
										AutoPostBack="True" Width="208px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px; HEIGHT: 31px">Categoría</TD>
								<TD style="HEIGHT: 31px"><asp:dropdownlist id="ddlCateTour" runat="server" DataTextField="NomElemento" DataValueField="CodElemento"
										AutoPostBack="True" Width="208px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px">Peru4alll</TD>
								<TD><asp:checkbox id="CheckBoxFlagUsoAge" runat="server" Text="Disponible para inlcuir en los Tours"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px">Estado</TD>
								<TD><asp:radiobutton id="rbtActivo" runat="server" Text="Activo" GroupName="g1" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtInactivo" runat="server" Text="Inactivo" GroupName="g1"></asp:radiobutton>&nbsp;
								</TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px"><asp:label id="lblMsg" runat="server" Width="472px" CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
