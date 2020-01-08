<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraRH.aspx.vb" Inherits="cppRegistraRH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="FORM" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 578px; POSITION: absolute; TOP: 8px; HEIGHT: 415px"
				cellSpacing="0" cellPadding="0" width="578" border="0">
				<TR>
					<TD>
						<P class="Titulo">Registro Recibos de Honorarios</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 322px">
						<TABLE class="tabla" id="Table3" style="WIDTH: 604px; HEIGHT: 323px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="604" border="1">
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 12px">Tipo Documento</TD>
								<TD style="HEIGHT: 12px">&nbsp;<asp:dropdownlist id="ddlTipoDocumento" 
                                        runat="server" Enabled="False" BackColor="#C0FFFF"
										DataTextField="NomDocumento" DataValueField="TipoDocumento" Width="303px"></asp:dropdownlist>&nbsp;
									<asp:label id="lblNº" runat="server" Visible="False">Nº Doc</asp:label>&nbsp;
									<asp:label id="lblDocProveedor" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">N° Comprobante</TD>
								<TD>&nbsp;<asp:textbox id="txtNroDocumento" runat="server" Width="159px" MaxLength="20"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Height="8px" Width="141px" CssClass="error"
										ForeColor=" " ErrorMessage="Dato obligatorio" ControlToValidate="txtNroDocumento"> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">Fecha</TD>
								<TD>&nbsp;<asp:textbox id="txtFchDocumento" runat="server" Width="75px" CssClass="fd" ReadOnly="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Height="8px" Width="141px" CssClass="error" ForeColor=" "
										ErrorMessage="Dato obligatorio" ControlToValidate="txtFchDocumento"> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 25px">Proveedor</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtNomProveedor" runat="server" Width="304px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 26px">Ruc</TD>
								<TD style="HEIGHT: 26px"><asp:textbox id="txtRuc" runat="server" Width="159px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">Referencia</TD>
								<TD>&nbsp;<asp:textbox id="txtReferencia" runat="server" Width="290px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtReferencia"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">Moneda</TD>
								<TD>&nbsp;<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">Sub Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label3" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
								<TD>&nbsp;<asp:textbox id="txtSubTotal" runat="server" Width="93px" AutoPostBack="True"></asp:textbox>&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="lbtTipoCambio" runat="server">Tipo Cambio Sunat </asp:linkbutton><asp:textbox id="txtTipoCambio" runat="server" Width="93px" AutoPostBack="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">Retencion&nbsp;
									<asp:textbox id="txtPorIGV" runat="server" Width="44px" AutoPostBack="True"></asp:textbox>&nbsp;%</TD>
								<TD>&nbsp;<asp:textbox id="txtIGV" runat="server" Width="91px" AutoPostBack="True"></asp:textbox><asp:label id="Label4" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 6px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="HEIGHT: 6px">&nbsp;<asp:textbox id="txtTotal" runat="server" BackColor="#C0FFFF" Width="91px" ReadOnly="True" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtTotal"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 14px">&nbsp;</TD>
								<TD style="HEIGHT: 14px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 14px">Tipo Gasto</TD>
								<TD style="HEIGHT: 14px">&nbsp;<asp:dropdownlist id="ddlTipoGasto" runat="server" 
                                        DataTextField="NomCuenta" DataValueField="CodCuenta"
										Width="384px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 14px">Cuenta Gasto</TD>
								<TD style="HEIGHT: 14px">&nbsp;<asp:dropdownlist id="ddlCuentaGasto" runat="server" 
                                        DataTextField="NomCuenta" DataValueField="CodCuenta"
										Width="384px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px"><asp:button id="cmdGrabar" runat="server" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblmsg" runat="server" Width="519px" Visible="False" 
                            CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
