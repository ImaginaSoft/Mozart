<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioCopia.aspx.vb" Inherits="VtaServicioCopia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 584px; POSITION: absolute; TOP: 8px; HEIGHT: 207px"
				cellSpacing="0" cellPadding="1" width="584" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 70px">
						<TABLE class="tabla" id="Table5" style="WIDTH: 584px; HEIGHT: 88px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="584" border="1">
							<TR>
								<TD style="WIDTH: 29px; HEIGHT: 19px">Proveedor</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:dropdownlist id="ddlProveedor" 
                                        runat="server" DataValueField="CodProveedor" DataTextField="NomProveedor" 
                                        Width="354px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 29px; HEIGHT: 19px">Ciudad</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:dropdownlist id="ddlCiudad" runat="server" DataValueField="CodCiudad" DataTextField="NomCiudad"
										Width="352px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 29px; HEIGHT: 19px">Tipo</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px">
									<asp:dropdownlist id="ddltiposervicio" runat="server" Width="352px" DataTextField="TipoServicio" DataValueField="CodTipoServicio"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 29px; HEIGHT: 19px">Servicio</TD>
								<TD style="WIDTH: 350px; HEIGHT: 19px"><asp:label id="lblDesProveedor" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar" Visible="False"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="504px" DESIGNTIMEDRAGDROP="187" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
