<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppCuadreVComprobantes.aspx.vb" Inherits="cppCuadreVComprobantes" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<P></P>
			<P>
				<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 384px; POSITION: absolute; TOP: 8px; HEIGHT: 79px"
					cellSpacing="0" cellPadding="0" width="384" border="0">
					<TR>
						<TD class="Titulo" style="WIDTH: 390px">Generar Varios Comprobantes</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px">
                            <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                        </TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px; HEIGHT: 16px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 246px; HEIGHT: 20px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="246" border="1">
								<TR>
									<TD style="WIDTH: 173px">Monto&nbsp;total a distribuir</TD>
									<TD><asp:label id="lblTotal" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px">&nbsp;
							<TABLE class="tabla" id="Table3" style="WIDTH: 246px; HEIGHT: 150px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="246" border="1">
								<TR>
									<TD style="WIDTH: 173px">Monto total comprobante 1
									</TD>
									<TD><asp:textbox id="txtMonto1" runat="server" Width="62px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 173px">Monto total comprobante 2
									</TD>
									<TD><asp:textbox id="txtMonto2" runat="server" Width="61px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 173px">Monto total comprobante 3
									</TD>
									<TD><asp:textbox id="txtMonto3" runat="server" Width="61px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 173px">Monto total comprobante 4
									</TD>
									<TD><asp:textbox id="txtMonto4" runat="server" Width="61px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 173px">Monto total comprobante 5
									</TD>
									<TD><asp:textbox id="txtMonto5" runat="server" Width="60px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 173px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										Total</TD>
									<TD align="center"><asp:label id="lblSuma" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px; HEIGHT: 20px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px"><asp:button id="btnCompletaDatos" runat="server" Width="131px" Text="Completar Datos"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 390px">&nbsp;
							<asp:label id="lblmsg" runat="server" Width="410px" Visible="False" CssClass="error" ></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
</body>
</html>
