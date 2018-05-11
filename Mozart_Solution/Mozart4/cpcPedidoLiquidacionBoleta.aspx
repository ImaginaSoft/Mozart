<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcPedidoLiquidacionBoleta.aspx.vb" Inherits="cpcPedidoLiquidacionBoleta" %>

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
				<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 7px; WIDTH: 490px; POSITION: absolute; TOP: 7px; HEIGHT: 289px"
					cellSpacing="0" cellPadding="0" width="490" border="0">
					<TR>
						<TD class="Titulo" style="WIDTH: 356px"><asp:label id="lbltitulo" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="TABLA" id="Table3" style="WIDTH: 568px; HEIGHT: 173px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="568" border="1">
								<TR>
									<TD style="WIDTH: 141px">Tipo Documento Sunat</TD>
									<TD><asp:dropdownlist id="ddlTipoDocumento" runat="server" DataValueField="TipoDocumento" DataTextField="NomDocumento"
											Width="332px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px">Nº Documento</TD>
									<TD><asp:textbox id="txtNroDocumento" runat="server" Width="141px" MaxLength="15"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 13px">Fecha Documento</TD>
									<TD style="HEIGHT: 13px"><asp:textbox id="txtFchDocumento" runat="server" Width="75px" CssClass="fd" AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
											tabIndex="2" type="button" value="..." name="cmdFchNacimiento"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 23px">Cliente</TD>
									<TD style="HEIGHT: 23px"><asp:label id="lblNomCliente" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 19px">Nº RUC</TD>
									<TD style="HEIGHT: 19px"><asp:label id="lblRuc" runat="server"></asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 19px">Glosa</TD>
									<TD style="HEIGHT: 19px">
										<asp:textbox id="txtGlosa" runat="server" Width="335px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 20px">
										<asp:LinkButton id="lbtTC" runat="server">Tipo Cambio Sunat</asp:LinkButton></TD>
									<TD style="HEIGHT: 20px"><asp:textbox id="txtTipoCambio" runat="server" Width="81px" MaxLength="10"></asp:textbox>
										&nbsp;
										<asp:label id="Label2" runat="server" ForeColor="Red">(TAB)</asp:label>&nbsp; 
										&nbsp;
										<asp:checkbox id="cbCombierteSoles" runat="server" AutoPostBack="True" Text="Convertir a Nuevos Soles"></asp:checkbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Width="104px" ForeColor=" " ControlToValidate="txtTipoCambio"
											Height="8px" CssClass="error"> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
							</TABLE>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 320px; HEIGHT: 125px" cellSpacing="0" cellPadding="0"
								width="320" border="1" borderColor="#cccccc">
								<TR>
									<TD style="WIDTH: 141px"></TD>
									<TD style="WIDTH: 88px" align="center">US $</TD>
									<TD align="center">S/</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 27px">SubTotal</TD>
									<TD style="WIDTH: 88px; HEIGHT: 27px"><asp:textbox id="lblSubtotal" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
									<TD style="HEIGHT: 27px"><asp:textbox id="lblSubtotalS" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px">IGV&nbsp;
										<asp:label id="Label3" runat="server" ForeColor="Red">(TAB)</asp:label>&nbsp;
										<asp:textbox id="txtPorIGV" runat="server" Width="36px" AutoPostBack="True">0</asp:textbox>%</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lblIgv" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
									<TD><asp:textbox id="lblIgvS" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px; HEIGHT: 25px">Inafectos&nbsp;
										<asp:label id="Label1" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
									<TD style="WIDTH: 88px; HEIGHT: 25px"><asp:textbox id="txtInafectos" runat="server" Width="81px" MaxLength="10" AutoPostBack="True"></asp:textbox></TD>
									<TD style="HEIGHT: 25px"><asp:textbox id="txtInafectosS" runat="server" Width="81px" MaxLength="10" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 141px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lbltotal" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
									<TD><asp:textbox id="lbltotalS" runat="server" Width="81px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 23px"><asp:button id="btnGrabar" runat="server" Text="Grabar" Width="88px"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px">&nbsp;
							<asp:label id="lblmsg" runat="server" Width="480px"  CssClass="error" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
