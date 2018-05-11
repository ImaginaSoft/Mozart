<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SegSesion.aspx.vb" Inherits="SegSesion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server" target="_top">
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 343px; POSITION: absolute; TOP: 45px; HEIGHT: 77px"
				cellSpacing="1" cellPadding="1" width="343" border="0">
				<TR>
					<TD class="error">
						<P>Estimado usuario, su sesión de trabajo&nbsp;expiro Por favor volver a ingresar 
							al sistema&nbsp;&nbsp;&nbsp;</P>
						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;
							<asp:LinkButton id="lbtLogin" runat="server">Hacer click para continuar</asp:LinkButton></P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" style="Z-INDEX: 103; LEFT: 17px; WIDTH: 344px; POSITION: absolute; TOP: 10px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="344"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Sesión de Trabajo</P>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
