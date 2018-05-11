<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaPropuesta.aspx.vb" Inherits="VtaPropuestaPropuesta" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 498px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="498"  border="0">
				<TR>
					<TD style="WIDTH: 510px">
						<P class="Titulo">
							&nbsp;Nueva Propuesta</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 510px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="WIDTH: 510px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 510px">
						<P class="SubTitulo">Los servicios se elige desde una Propuesta</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 510px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 496px; HEIGHT: 64px" cellSpacing="0" cellPadding="0"
							width="496" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 135px; HEIGHT: 20px">Propuestas</TD>
								<TD style="HEIGHT: 20px"><asp:dropdownlist id="ddlPropuesta" runat="server" 
                                        Width="354px" AutoPostBack="True" DataValueField="KeyReg"
										DataTextField="DesPropuesta"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Nro Propuesta Origen</TD>
								<TD><asp:textbox id="txtNroPropuesta" runat="server" Width="63px" AutoPostBack="True" MaxLength="3"></asp:textbox><asp:label id="lblerror1" runat="server" CssClass="error"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label4" runat="server" Width="109px">Día Inicio</asp:label></TD>
								<TD><asp:textbox id="txtNroDiaInicio" runat="server" Width="40px" MaxLength="3"></asp:textbox>
									<asp:label id="lblerror2" runat="server" CssClass="error"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 510px">
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="398px" CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
