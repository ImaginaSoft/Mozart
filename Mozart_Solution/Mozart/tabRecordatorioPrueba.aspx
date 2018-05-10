<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabRecordatorioPrueba.aspx.vb" Inherits="tabRecordatorioPrueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="frmRTB" method="post" runat="server">
			<TABLE class="tabla" id="Table1" style="Z-INDEX: 105; LEFT: 8px; WIDTH: 496px; POSITION: absolute; TOP: 64px; HEIGHT: 97px"
				cellSpacing="0" cellPadding="0" width="496" border="0">
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 24px">De</TD>
					<TD style="HEIGHT: 24px" align="left">
						<asp:textbox id="txtDe" runat="server" Width="344px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 24px">Para</TD>
					<TD style="HEIGHT: 24px" align="left">
						<asp:textbox id="txtPara" runat="server" Width="344px"></asp:textbox>&nbsp;
						<asp:button id="cmdSend" runat="server" Text="Enviar" Width="83px"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 17px">Cc</TD>
					<TD style="HEIGHT: 17px" align="left">
						<asp:textbox id="txtCC" runat="server" Width="344px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 7px">Asunto</TD>
					<TD style="HEIGHT: 7px" align="left">
						<asp:textbox id="txtAsunto" runat="server" Width="344px"></asp:textbox></TD>
				</TR>
			</TABLE>
			<asp:Label id="lblpie" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 480px" runat="server"></asp:Label>
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 496px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="496" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
			<asp:label id="lblmsg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server"
				Width="392px" CssClass="error"></asp:label>
		</form>
		<TABLE id="Table2" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 496px; POSITION: absolute; TOP: 168px; HEIGHT: 26px"
			cellSpacing="1" cellPadding="1" width="496" border="1">
			<TR>
				<TD>
					<asp:Label id="lblMensaje" runat="server"></asp:Label></TD>
			</TR>
		</TABLE>
</body>
</html>
