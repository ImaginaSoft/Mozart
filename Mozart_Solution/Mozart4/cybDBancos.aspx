<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybDBancos.aspx.vb" Inherits="cybDBancos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 589px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Detalle Banco</P>
					</TD>
				</TR>
			</TABLE>
			<asp:label id="lblmsg" 
                style="Z-INDEX: 105; LEFT: 7px; POSITION: absolute; TOP: 222px" runat="server"
				CssClass="msg" Width="715px"></asp:label>
			<asp:button id="cmdAnularDoc" style="Z-INDEX: 104; LEFT: 232px; POSITION: absolute; TOP: 184px"
				runat="server" Text="Anular Documento"></asp:button>
			<asp:button id="cmdModifDoc" style="Z-INDEX: 103; LEFT: 7px; POSITION: absolute; TOP: 184px"
				runat="server" Text="Modificar Documento"></asp:button>
			<TABLE class="tabla" id="Table2" style="Z-INDEX: 101; LEFT: 7px; WIDTH: 631px; POSITION: absolute; TOP: 41px; HEIGHT: 127px"
				cellSpacing="1" cellPadding="1" width="631" border="1">
				<TR>
					<TD style="WIDTH: 141px">&nbsp;Tipo Documento</TD>
					<TD><asp:label id="lblTipoDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblNomDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 141px">&nbsp;Numero de Documento</TD>
					<TD><asp:label id="lblNumeroDocumento" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 141px; HEIGHT: 20px">&nbsp;Banco</TD>
					<TD style="HEIGHT: 20px"><asp:label id="lblCodigoBanco" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 141px; HEIGHT: 20px">&nbsp;SecBanco&nbsp;</TD>
					<TD style="HEIGHT: 20px"><asp:label id="lblSecBanco" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 141px">&nbsp;Referencia
					</TD>
					<TD><asp:label id="lblReferencia" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 141px">&nbsp;Total</TD>
					<TD>
						<asp:label id="lbltotal" runat="server" CssClass="Dato"></asp:label>&nbsp;
						<asp:label id="lblMoneda" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
