<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comComprobanteVentasImprime.aspx.vb" Inherits="comComprobanteVentasImprime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<P></P>
			<P>
				<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 631px; POSITION: absolute; TOP: 8px; HEIGHT: 529px"
					cellSpacing="0" cellPadding="0" width="631" border="0">
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px"></TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 12px">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblDia" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblMes" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblAno" runat="server"></asp:label></TD>
						<TD style="WIDTH: 356px; HEIGHT: 12px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 1px">&nbsp;
						</TD>
						<TD style="WIDTH: 356px; HEIGHT: 1px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 6px">&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblNombre" runat="server"></asp:label></TD>
						<TD style="WIDTH: 356px; HEIGHT: 6px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 6px">&nbsp;</TD>
						<TD style="WIDTH: 356px; HEIGHT: 6px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 1px">&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblDNI" runat="server"></asp:label></TD>
						<TD style="WIDTH: 356px; HEIGHT: 1px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblGlosa" runat="server"></asp:label></TD>
						<TD style="WIDTH: 356px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblTotal" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px; HEIGHT: 16px">&nbsp;</TD>
						<TD style="WIDTH: 356px; HEIGHT: 16px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
					<TR style="HEIGHT: 30x">
						<TD style="WIDTH: 567px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
						<TD style="WIDTH: 356px" vAlign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblTotal1" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 567px">&nbsp;</TD>
						<TD style="WIDTH: 356px"></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
