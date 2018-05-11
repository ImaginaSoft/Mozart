<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybTransferencia.aspx.vb" Inherits="cybTransferencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" 
				cellSpacing="0" cellPadding="1" width="443" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Transferencia entre&nbsp;Bancos</P>
					</TD>
				</TR>

				<TR>
					<TD>
			<TABLE class="Tabla" id="Table3" 
				cellSpacing="1" cellPadding="1" width="445" border="1" borderColor="#cccccc">
				<TR>
					<TD  style="WIDTH: 97px">&nbsp;Origen</TD>
					<TD  style="WIDTH: 250px">
						<asp:label id="lblNumero" runat="server" Visible="False">Nro Documento</asp:label>
						<asp:textbox id="txtNumero" runat="server" Width="74px" Visible="False" MaxLength="11"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px">&nbsp;Banco</TD>
					<TD style="WIDTH: 250px">
						<asp:dropdownlist id="ddlBanco" runat="server" Width="237px" DataValueField="CodBanco"
							DataTextField="NomBanco" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px; HEIGHT: 24px">&nbsp;Nro Cuenta</TD>
					<TD style="WIDTH: 250px; HEIGHT: 24px">
						<asp:dropdownlist id="ddlNroCuenta" runat="server" Width="237px" DataValueField="SecBanco"
							DataTextField="NroCuenta" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px">&nbsp;Saldo Actual</TD>
					<TD style="WIDTH: 252px" colSpan="2">
						<asp:label id="lblS" runat="server"></asp:label>
						<asp:label id="lblMonedaOrigen" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px">&nbsp;Fecha Emisión</TD>
					<TD style="WIDTH: 252px">
						<asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd" ></asp:textbox>
						<INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchEmision"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px; HEIGHT: 23px">&nbsp;Referencia</TD>
					<TD style="WIDTH: 302px; HEIGHT: 23px">
						<asp:textbox id="txtReferencia" runat="server" Width="233px" MaxLength="50"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" 
                            Width="27px" CssClass="error"
							ControlToValidate="txtReferencia" ForeColor=" "> Obligatorio</asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 97px">&nbsp;Importe</TD>
					<TD style="WIDTH: 252px">
						<asp:textbox id="txtImporte" runat="server" Width="93px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" 
                            Width="91px" CssClass="error"
							ControlToValidate="txtImporte" ForeColor=" ">Dato obligatorio</asp:requiredfieldvalidator></TD>
				</TR>
			</TABLE>
					</TD>
				</TR>

				<TR>
					<TD>
                        &nbsp;
					</TD>
				</TR>

				<TR>
					<TD>
			<TABLE class="Tabla" id="Table1" 
				cellSpacing="1" cellPadding="1" width="447" border="1" borderColor="#cccccc">
				<TR>
					<TD  style="WIDTH: 78px">&nbsp;Destino</TD>
					<TD  style="WIDTH: 246px">
						<asp:label id="lblNumero2" runat="server" Visible="False">Nro Documento</asp:label>
						<asp:textbox id="txtNumero2" runat="server" Width="74px" Visible="False" MaxLength="11"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px">&nbsp;Banco</TD>
					<TD style="WIDTH: 246px"><asp:dropdownlist id="ddlBancoDestino" runat="server" 
                            Width="234px" AutoPostBack="True"
							DataTextField="NomBanco" DataValueField="CodBanco"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px">&nbsp;Nro Cuenta</TD>
					<TD style="WIDTH: 246px">
						<asp:dropdownlist id="ddlNroCtaDestino" runat="server" Width="235px" DataValueField="SecBanco"
							DataTextField="NroCuenta" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px">&nbsp;Saldo&nbsp;Actual&nbsp;</TD>
					<TD style="WIDTH: 246px">
						<asp:label id="lblSd" runat="server"></asp:label>
						<asp:label id="lblMonedaDestino" runat="server" Width="57px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px">&nbsp;Tipo Cambio</TD>
					<TD style="WIDTH: 246px">
						<asp:textbox id="txtTipoCambio" runat="server" Width="93px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px">
						<asp:button id="cmbGrabar" runat="server" Width="76px" Text="Grabar"></asp:button></TD>
					<TD style="WIDTH: 246px">
						<asp:label id="lblmsg" runat="server" Width="264px" CssClass="ERROR"></asp:label></TD>
				</TR>
			</TABLE>
						
					</TD>
				</TR>


			</TABLE>
		</form>
</body>
</html>
