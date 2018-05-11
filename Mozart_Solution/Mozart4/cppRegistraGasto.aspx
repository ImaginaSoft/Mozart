<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraGasto.aspx.vb" Inherits="cppRegistraGasto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 539px; POSITION: absolute; TOP: 8px; HEIGHT: 399px"
				cellSpacing="1" cellPadding="1" width="539" border="0">
				<TR>
					<TD>
						<P class="Titulo">Registro de Gastos</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 579px; HEIGHT: 349px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="579" border="1">
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 12px">Tipo Documento</TD>
								<TD style="HEIGHT: 12px">&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" AutoPostBack="True"  DataTextField="NomDocumento"
										DataValueField="TipoDocumento" Width="312px"></asp:dropdownlist>&nbsp;
									<asp:label id="lblNº" runat="server" Visible="False">Nº Doc</asp:label>&nbsp;<asp:label id="lblDocProveedor" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">N° Comprobante</TD>
								<TD>&nbsp;
									<asp:textbox id="txtNroDocumento" runat="server" Width="159px" MaxLength="20"></asp:textbox>&nbsp;
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Fecha</TD>
								<TD>&nbsp;
									<asp:textbox id="txtFchDocumento" runat="server" AutoPostBack="True" Width="75px" CssClass="fd"
										></asp:textbox><INPUT class="fd" id="cmdFchEmision" onclick="show_calendar('Form1.txtFchDocumento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Height="8px" Width="141px" CssClass="error" ForeColor=" "
										ErrorMessage="Dato obligatorio" ControlToValidate="txtFchDocumento"> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Proveedor</TD>
								<TD>&nbsp;
									<asp:textbox id="txtNomProveedor" runat="server" Width="344px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Ruc</TD>
								<TD>&nbsp;
									<asp:textbox id="txtRUC" runat="server" Width="152px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Referencia</TD>
								<TD>&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="344px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtReferencia"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Moneda</TD>
								<TD>&nbsp;<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 28px">Sub Total</TD>
								<TD style="HEIGHT: 28px">&nbsp;
									<asp:textbox id="txtSubTotal" runat="server" AutoPostBack="True" Width="93px" ReadOnly="True"
										BackColor="#C0FFFF"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;
									<asp:LinkButton id="lbtTipoCambio" runat="server">Tipo Cambio Sunat </asp:LinkButton>
									<asp:textbox id="txtTipoCambio" runat="server" AutoPostBack="True" Width="93px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">IGV&nbsp;&nbsp;
									<asp:textbox id="txtPorIGV" runat="server" AutoPostBack="True" Width="44px"></asp:textbox>&nbsp;%</TD>
								<TD>&nbsp;
									<asp:textbox id="txtIGV" runat="server" AutoPostBack="True" Width="91px" ForeColor="Silver" ReadOnly="True"
										BackColor="#C0FFFF" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px">Inafecto&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label1" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
								<TD>&nbsp;
									<asp:textbox id="txtOtros" runat="server" AutoPostBack="True" Width="93px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 14px">Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label2" runat="server" ForeColor="Red">(TAB)</asp:label></TD>
								<TD style="HEIGHT: 14px">&nbsp;
									<asp:textbox id="txtTotal" runat="server" AutoPostBack="True" Width="91px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtTotal"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 14px">&nbsp;</TD>
								<TD style="HEIGHT: 14px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 2px">Tipo</TD>
								<TD style="HEIGHT: 2px">&nbsp;
									<asp:dropdownlist id="ddlTipoGasto" runat="server" AutoPostBack="True"  DataTextField="NomCuenta"
										DataValueField="CodCuenta" Width="432px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 101px; HEIGHT: 14px">Cuenta Gasto</TD>
								<TD style="HEIGHT: 14px">&nbsp;
									<asp:dropdownlist id="ddlCuentaGasto" runat="server" DataTextField="NomCuenta4" DataValueField="CodCuenta"
										Width="432px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 45px"><asp:button id="cmdGrabar" runat="server" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblmsg" runat="server"  Width="483px" Visible="False" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblPIGV" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
