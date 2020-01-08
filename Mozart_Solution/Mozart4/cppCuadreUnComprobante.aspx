<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppCuadreUnComprobante.aspx.vb" Inherits="cppCuadreUnComprobante" %>

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
							<TABLE class="TABLA" id="Table3" style="WIDTH: 584px; HEIGHT: 169px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="584" border="1">
								<TR>
									<TD style="WIDTH: 120px">Tipo Documento</TD>
									<TD><asp:dropdownlist id="ddlTipoDocumento" runat="server" AutoPostBack="True" Width="332px" DataTextField="NomDocumento"
											DataValueField="TipoDocumento"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px">Nº Documento</TD>
									<TD><asp:textbox id="txtNroDocumento" runat="server" Width="141px" MaxLength="15"></asp:textbox>&nbsp;
										</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 26px">Fecha Documento</TD>
									<TD style="HEIGHT: 26px"><asp:textbox id="txtFchDocumento" runat="server" Width="75px" ></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
											tabIndex="2" type="button" value="..." name="cmdFchNacimiento"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 23px">Proveedor</TD>
									<TD style="HEIGHT: 23px"><asp:label id="lblNomProveedor" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 19px">Nº RUC</TD>
									<TD style="HEIGHT: 19px"><asp:label id="lblRuc" runat="server"></asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 25px"><asp:linkbutton id="lbtTC" runat="server">Tipo Cambio Sunat</asp:linkbutton></TD>
									<TD style="HEIGHT: 25px"><asp:textbox id="txtTipoCambio" runat="server" AutoPostBack="True" Width="81px" MaxLength="10"></asp:textbox><asp:label id="Label2" runat="server" ForeColor="Red">(TAB)</asp:label>&nbsp;
										<asp:checkbox id="cbCombierteSoles" runat="server" AutoPostBack="True" Text="Convertir a Nuevos Soles"
											Visible="False"></asp:checkbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Width="104px" CssClass="error" Height="8px"
											ControlToValidate="txtTipoCambio" ForeColor=" "> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px"><asp:checkbox id="cbCombierteDolares" runat="server" AutoPostBack="True" Text="Convertir a Dolares"
											Visible="False"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 296px; HEIGHT: 124px" cellSpacing="0" cellPadding="0"
								width="296" border="1">
								<TR>
									<TD style="WIDTH: 146px"></TD>
									<TD style="WIDTH: 88px" align="center">US $</TD>
									<TD align="center">S/</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px">SubTotal</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lblSubtotal" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
									<TD><asp:textbox id="lblSubtotalS" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px">IGV&nbsp;
										<asp:label id="Label3" runat="server" ForeColor="Red">(TAB)</asp:label>&nbsp;
										<asp:textbox id="txtPorIGV" runat="server" AutoPostBack="True" Width="36px"></asp:textbox>%</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lblIgv" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
									<TD><asp:textbox id="lblIgvS" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px">Inafectos&nbsp;
										<asp:label id="Label1" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
									<TD style="WIDTH: 88px"><asp:textbox id="txtInafectos" runat="server" AutoPostBack="True" Width="81px" MaxLength="10"></asp:textbox></TD>
									<TD><asp:textbox id="txtInafectosS" runat="server" AutoPostBack="True" Width="81px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 88px"><asp:textbox id="lbltotal" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
									<TD><asp:textbox id="lbltotalS" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px"></TD>
									<TD style="WIDTH: 88px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 146px">Comisión Dscontada</TD>
									<TD style="WIDTH: 88px">
										<asp:textbox id="txtComisionDescontada" runat="server" Width="81px" AutoPostBack="True" MaxLength="10"></asp:textbox></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px; HEIGHT: 1px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px"><asp:button id="btnGrabar" runat="server" Text="Grabar"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px"><asp:label id="lblmsg" runat="server" Width="456px" CssClass="error"  Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 356px"><asp:label id="lblPIGV" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
