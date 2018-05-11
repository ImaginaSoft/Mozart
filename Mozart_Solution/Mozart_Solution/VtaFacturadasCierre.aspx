<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaFacturadasCierre.aspx.vb" Inherits="VtaFacturadasCierre" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 103; LEFT: 14px; WIDTH: 415px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="415" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Cierre Periodo de Ventas</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 408px; HEIGHT: 8px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="408" border="1">
							<TR>
								<TD style="WIDTH: 108px">&nbsp;Periodo abierto:</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 108px">&nbsp;Fecha inicio&nbsp;</TD>
								<TD><asp:label id="lblfchini" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 108px">&nbsp;Fecha termino&nbsp;</TD>
								<TD><asp:label id="lblfchfin" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdCierre" runat="server" Text="Ejecutar Cierre"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
