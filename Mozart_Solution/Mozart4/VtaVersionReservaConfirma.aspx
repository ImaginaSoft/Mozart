<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionReservaConfirma.aspx.vb" Inherits="VtaVersionReservaConfirma" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<!-- Style for the Rich Text Box -->
		<style type="text/css">.advertisement {
	BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 12px; VERTICAL-ALIGN: middle; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: verdana, tahoma; TEXT-ALIGN: center; arial: 
}
.tblToolbar {
	BORDER-RIGHT: 1px outset; PADDING-RIGHT: 1px; BORDER-TOP: 1px outset; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px outset; COLOR: menutext; PADDING-TOP: 1px; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: buttonface
}
.raiseme {
	BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset
}
.raisemeleft {
	BORDER-LEFT: 2px groove
}
.cbtn {
	BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; BORDER-BOTTOM: buttonface 1px solid
}
.codedisplay {
	FONT-SIZE: 10px; FONT-FAMILY: courier; TEXT-ALIGN: left
}
.selects {
	FONT-SIZE: 10px; FONT-FAMILY: tahoma, verdana, arial, courier, serif
}
.txtbtn {
	FONT-SIZE: 70%; COLOR: menutext; FONT-FAMILY: tahoma, verdana, arial, courier, serif
}
.DivMenu {
	BORDER-RIGHT: buttonface 1px groove; BORDER-TOP: buttonface 1px groove; Z-INDEX: 100; LEFT: -200px; BORDER-LEFT: buttonface 1px groove; WIDTH: 125px; BORDER-BOTTOM: buttonface 1px groove; POSITION: absolute; TOP: -1000px; BACKGROUND-COLOR: buttonface
}
.TDMenu {
	FONT-SIZE: 70%; WIDTH: 100%; CURSOR: default; COLOR: buttonface; font-familt: verdana
}
		</style>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmRTB" method="post" runat="server">
			<TABLE class="tabla" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 488px; POSITION: absolute; TOP: 8px; HEIGHT: 158px"
				cellSpacing="0" cellPadding="1" width="488" border="0">
				<TR>
					<TD style="WIDTH: 489px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 489px">
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="WIDTH: 489px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 489px; HEIGHT: 20px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 472px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="472" border="0">
							<TR>
								<TD style="WIDTH: 174px; HEIGHT: 17px">Cambiar estado de la reserva</TD>
								<TD style="HEIGHT: 9px" align="left">&nbsp;
									<asp:dropdownlist id="ddlSolicita" tabIndex="6" runat="server" DataTextField="NomSolicita" DataValueField="CodSolicita"
										AutoPostBack="True" Width="248px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 489px; HEIGHT: 20px"><asp:button id="cmdSend" runat="server" Width="83px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 489px"><asp:label id="lblmsg" runat="server" Width="472px" CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
