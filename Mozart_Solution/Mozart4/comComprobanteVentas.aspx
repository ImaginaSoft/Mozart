<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comComprobanteVentas.aspx.vb" Inherits="comComprobanteVentas" %>

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
				<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 520px; POSITION: absolute; TOP: 8px; HEIGHT: 437px"
					cellSpacing="0" cellPadding="0" width="520" border="0">
					<TR>
						<TD class="Titulo" style="WIDTH: 491px">
							<asp:label id="lbltitulo" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 491px; HEIGHT: 1px">
							<TABLE class="TABLA" id="Table3" style="WIDTH: 520px; HEIGHT: 190px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="520" border="1">
								<TR>
									<TD style="WIDTH: 120px">Tipo Documento</TD>
									<TD>
										<asp:dropdownlist id="ddlTipoDocumento" runat="server" DataValueField="TipoDocumento" DataTextField="NomDocumento"
											Width="332px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px">Nº Documento</TD>
									<TD>
										<asp:textbox id="txtNroDocumento" runat="server" Width="141px" MaxLength="15"></asp:textbox>&nbsp;
										<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="169px" 
                                            ForeColor=" " ControlToValidate="txtNroDocumento" CssClass="error"> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 13px">Fecha Documento</TD>
									<TD style="HEIGHT: 13px">
										<asp:textbox id="txtFchDocumento" runat="server" Width="75px" CssClass="fd" ></asp:textbox>
										<INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
											tabIndex="2" type="button" value="..." name="cmdFchNacimiento"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 23px">Cliente</TD>
									<TD style="HEIGHT: 23px">
										<asp:textbox id="lblNomProveedor" runat="server" Width="198px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 23px">Pais&nbsp;</TD>
									<TD style="HEIGHT: 23px">
										<asp:textbox id="txtNomPais" runat="server" Width="335px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 19px">Nº RUC</TD>
									<TD style="HEIGHT: 19px">
										<asp:textbox id="lblRuc" runat="server" Width="112px" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 19px">Glosa</TD>
									<TD style="HEIGHT: 19px">
										<asp:textbox id="txtGlosa" runat="server" Width="335px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 120px; HEIGHT: 20px">
										<asp:LinkButton id="lbtTC" runat="server">Tipo Cambio </asp:LinkButton>&nbsp;
										<asp:label id="Label2" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
									<TD style="HEIGHT: 20px">
										<asp:textbox id="txtTipoCambio" runat="server" Width="81px" MaxLength="10" AutoPostBack="True"></asp:textbox>&nbsp;
										<asp:checkbox id="cbCombierteSoles" runat="server" AutoPostBack="True" Text="Convertir a Nuevos Soles"></asp:checkbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Width="104px" ForeColor=" " ControlToValidate="txtTipoCambio"
											CssClass="error"> Dato obligatorio</asp:requiredfieldvalidator></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 491px; HEIGHT: 16px">&nbsp;
							<TABLE class="form" id="Table4" style="WIDTH: 520px; HEIGHT: 144px" cellSpacing="0" cellPadding="0"
								width="520" border="0">
								<TR>
									<TD style="WIDTH: 298px" vAlign="top">
										<TABLE class="tabla" id="Table2" style="WIDTH: 288px; HEIGHT: 112px" cellSpacing="0" cellPadding="0"
											width="288" border="1" borderColor="#cccccc">
											<TR>
												<TD style="WIDTH: 166px"></TD>
												<TD style="WIDTH: 88px" align="center">US $</TD>
												<TD align="center">S/</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 166px">SubTotal</TD>
												<TD style="WIDTH: 88px">
													<asp:textbox id="lblSubtotal" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"
														MaxLength="14"></asp:textbox></TD>
												<TD>
													<asp:textbox id="lblSubtotalS" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False"
														MaxLength="14"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 166px">IGV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:textbox id="txtPorIGV" runat="server" Width="36px" AutoPostBack="True"></asp:textbox>%</TD>
												<TD style="WIDTH: 88px">
													<asp:textbox id="lblIgv" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False" MaxLength="14"></asp:textbox></TD>
												<TD>
													<asp:textbox id="lblIgvS" runat="server" Width="81px" BackColor="#C0FFFF" Enabled="False" MaxLength="14"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 166px">Inafectos&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:label id="Label1" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
												<TD style="WIDTH: 88px">
													<asp:textbox id="txtInafectos" runat="server" Width="81px" MaxLength="14" AutoPostBack="True"></asp:textbox></TD>
												<TD>
													<asp:textbox id="txtInafectosS" runat="server" Width="81px" MaxLength="14" AutoPostBack="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 166px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
												<TD style="WIDTH: 88px">
													<asp:textbox id="lbltotal" runat="server" Width="81px" AutoPostBack="True" MaxLength="14"></asp:textbox></TD>
												<TD>
													<asp:textbox id="lbltotalS" runat="server" Width="81px" AutoPostBack="True" MaxLength="14"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD vAlign="top" align="center">
										<TABLE class="tabla" id="Table6" style="WIDTH: 144px; HEIGHT: 47px" cellSpacing="0" cellPadding="0"
											width="144" border="0">
											<TR>
												<TD style="WIDTH: 32px; HEIGHT: 24px">Año</TD>
												<TD style="WIDTH: 50px; HEIGHT: 24px">
													<asp:textbox id="txtano" runat="server" Width="37px" MaxLength="4" DESIGNTIMEDRAGDROP="21">2005</asp:textbox>&nbsp;&nbsp;</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 32px; HEIGHT: 23px">Mes</TD>
												<TD style="WIDTH: 50px; HEIGHT: 23px">
													<asp:dropdownlist id="ddlMes" runat="server" Width="136px" DataTextField="NomElemento" DataValueField="CodElemento"
														AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 491px">
							<asp:button id="btnGrabar" runat="server" Text="Grabar"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnImprimir" runat="server" Text="Imprimir" Enabled="False"></asp:button>
							<asp:Label id="lblOrigen" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCodRelacion" runat="server" Visible="False"></asp:Label>
                        </TD>
					</TR>
					<TR>
						<TD style="WIDTH: 491px">&nbsp;
							<asp:label id="lblmsg" runat="server" Width="480px" CssClass="error" 
                                Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
