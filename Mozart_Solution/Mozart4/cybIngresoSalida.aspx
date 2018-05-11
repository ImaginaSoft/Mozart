<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybIngresoSalida.aspx.vb" Inherits="cybIngresoSalida" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="Ta" >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" 
				cellSpacing="0" cellPadding="1" width="621"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Ingreso y Salida de Banco</P>
					</TD>
				</TR>
				<TR>
					<TD>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>
			<TABLE class="Tabla" id="Table1" 
				cellSpacing="0" cellPadding="0" width="622" border="1" borderColor="#cccccc">
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 13px">&nbsp;
						<asp:label id="Label4" runat="server" Width="103px">Tipo Documento</asp:label></TD>
					<TD style="HEIGHT: 13px">&nbsp;
						<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" AutoPostBack="True"
							DataTextField="NomDocumento" DataValueField="TipoDocumento"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="lblNumero" runat="server" Visible="False">Nro Documento</asp:Label>&nbsp;
						<asp:textbox id="txtNumero" runat="server" Width="74px" MaxLength="11" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 7px">&nbsp;
						<asp:label id="Label5" runat="server" Width="93px"> Fecha Emisión</asp:label></TD>
					<TD style="HEIGHT: 7px">&nbsp;
						<asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" CssClass="fd"
							></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
						<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="223px" Height="8px" ControlToValidate="txtFchEmision"
							CssClass="error" ForeColor=" "> Dato obligatorio</asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 24px">&nbsp;
						<asp:label id="Label1" runat="server"> Referencia</asp:label></TD>
					<TD style="HEIGHT: 24px">&nbsp;
						<asp:textbox id="txtReferencia" runat="server" Width="292px" MaxLength="50"></asp:textbox>&nbsp;
						<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtReferencia" ErrorMessage="Dato Obligatorio"
							CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
						<asp:label id="Label7" runat="server">Importe</asp:label></TD>
					<TD style="HEIGHT: 17px">&nbsp;
						<asp:textbox id="txtImporte" runat="server" Width="93px" MaxLength="11"></asp:textbox>&nbsp;
						<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporte" ErrorMessage="Dato Obligatorio"
							CssClass="error" ForeColor=" "></asp:requiredfieldvalidator>&nbsp;
						<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton>&nbsp;<asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
						<asp:label id="lblBanco" runat="server" Width="85px">Banco</asp:label></TD>
					<TD style="HEIGHT: 17px">&nbsp;
						<asp:dropdownlist id="ddlBanco" runat="server" Width="288px" AutoPostBack="True"  DataTextField="NomBanco"
							DataValueField="CodBanco"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 27px">&nbsp;
						<asp:label id="lblnumeroC" runat="server" Width="85px">Nro Cuenta</asp:label></TD>
					<TD style="HEIGHT: 27px">&nbsp;
						<asp:dropdownlist id="ddlNroCuenta" runat="server" Width="288px" DataTextField="NroCuenta"
							DataValueField="SecBanco"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 98px; HEIGHT: 27px">&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 27px">&nbsp;
						<asp:Button id="cmdGrabar" runat="server" Text="Grabar"></asp:Button></TD>
				</TR>
			</TABLE>
						
						
						</TD>
				</TR>
				<TR>
					<TD >
			<asp:label id="lblmsg" 
                 runat="server"
				Width="410px" CssClass="Msg"></asp:label></form>
					
					
					</TD>
				</TR>
				
			</TABLE>
</body>
</html>
