<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comComprobanteComprasRH.aspx.vb" Inherits="comComprobanteComprasRH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<P></P>
			<P>
				<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 7px; WIDTH: 529px; POSITION: absolute; TOP: 7px; HEIGHT: 368px"
					cellSpacing="0" cellPadding="0" width="529" border="0">
					<TR>
						<TD class="Titulo" style="WIDTH: 356px"><asp:label id="lbltitulo" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="TABLA" id="Table3" style="WIDTH: 528px; HEIGHT: 157px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="528" border="1">
								<TR>
									<TD style="WIDTH: 125px">Tipo Documento</TD>
									<TD><asp:dropdownlist id="ddlTipoDocumento" runat="server" DataValueField="TipoDocumento" DataTextField="NomDocumento"
											Width="332px" AutoPostBack="True" BackColor="#C0FFFF" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 125px">Nº Documento</TD>
									<TD><asp:textbox id="txtNroDocumento" runat="server" Width="141px" MaxLength="15"></asp:textbox>&nbsp;
										<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="169px" ForeColor=" " ControlToValidate="txtNroDocumento"
											Height="8px" CssClass="error"> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 125px; HEIGHT: 13px">Fecha Documento</TD>
									<TD style="HEIGHT: 13px"><asp:textbox id="txtFchDocumento" runat="server" Width="75px" CssClass="fd"  AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
											tabIndex="2" type="button" value="..." name="cmdFchNacimiento"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 125px; HEIGHT: 23px">Proveedor</TD>
									<TD style="HEIGHT: 23px"><asp:textbox id="lblNomProveedor" runat="server" Width="198px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 125px; HEIGHT: 19px">Nº RUC</TD>
									<TD style="HEIGHT: 19px"><asp:textbox id="lblRuc" runat="server" Width="112px" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 125px; HEIGHT: 20px">
										<asp:LinkButton id="lbtTC" runat="server">Tipo Cambio </asp:LinkButton>
										&nbsp;
										<asp:label id="Label2" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
									<TD style="HEIGHT: 20px"><asp:textbox id="txtTipoCambio" runat="server" Width="81px" MaxLength="10" AutoPostBack="True"></asp:textbox>&nbsp;
										<asp:checkbox id="cbCombierteSoles" runat="server" AutoPostBack="True" Text="Convertir a Nuevos Soles"></asp:checkbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                            Width="104px" ForeColor=" " ControlToValidate="txtTipoCambio" CssClass="error"> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
							</TABLE>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 328px; HEIGHT: 71px" cellSpacing="0" cellPadding="0"
								width="328" border="1" borderColor="#cccccc">
								<TR>
									<TD style="WIDTH: 127px"></TD>
									<TD style="WIDTH: 88px" align="center">US $</TD>
									<TD align="center">S/</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 127px">SubTotal</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="txtSubtotal" runat="server" Width="81px" MaxLength="14" AutoPostBack="True"></asp:textbox></TD>
									<TD><asp:textbox id="txtSubtotalS" runat="server" Width="81px" MaxLength="14" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 127px">Ret.
										<asp:label id="Label3" runat="server" ForeColor="Red">(TAB)</asp:label>&nbsp;&nbsp;
										<asp:textbox id="txtPorIGV" runat="server" Width="36px" AutoPostBack="True"></asp:textbox>%</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lblIgv" runat="server" Width="81px" MaxLength="14" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
									<TD><asp:textbox id="lblIgvS" runat="server" Width="81px" MaxLength="14" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 127px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lbltotal" runat="server" Width="81px" MaxLength="14" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
									<TD><asp:textbox id="lbltotalS" runat="server" Width="81px" MaxLength="14" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="tabla" id="Table6" style="WIDTH: 328px; HEIGHT: 40px" cellSpacing="0" cellPadding="0"
								width="328" border="0">
								<TR>
									<TD style="WIDTH: 110px">Declaración Año</TD>
									<TD style="WIDTH: 50px">
										<asp:textbox id="txtano" runat="server" Width="37px" MaxLength="4" DESIGNTIMEDRAGDROP="21">2005</asp:textbox>&nbsp;&nbsp;</TD>
									<TD>Mes</TD>
									<TD>
										<asp:dropdownlist id="ddlMes" runat="server" AutoPostBack="True" Width="136px" DataTextField="NomElemento"
											DataValueField="CodElemento"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 23px"><asp:button id="btnGrabar" runat="server" Text="Grabar"></asp:button><asp:label id="lblOrigen" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px">&nbsp;
							<asp:label id="lblmsg" runat="server" Width="480px" CssClass="error" 
                                Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
