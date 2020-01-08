<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segLinks.aspx.vb" Inherits="segLinks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id=Table1 
style="Z-INDEX: 101; LEFT: 8px; WIDTH: 160px; POSITION: absolute; TOP: 0px; HEIGHT: 144px" 
cellSpacing=0 cellPadding=0 width=160 bgColor='<%=Session("MenuColorBG")%>' 
border=0>
				<TR>
					<TD style="WIDTH: 196px"><asp:image id="Image1" runat="server" Width="144px" Height="96px" ImageUrl="images/logo.gif"></asp:image></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 196px" align="center"><asp:label id="lblNomServidor" runat="server"  ></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 196px" align="center"><asp:label id="lblMandante" runat="server"   Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 196px"><asp:label id="Label1" runat="server"  ></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
