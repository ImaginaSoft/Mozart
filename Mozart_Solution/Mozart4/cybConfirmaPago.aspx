<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybConfirmaPago.aspx.vb" Inherits="cybConfirmaPago" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 216px"
				cellSpacing="0" cellPadding="1" width="536"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="lblTitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 523px; HEIGHT: 172px" cellSpacing="0" cellPadding="0"
							width="523" border="1">
							<TR>
								<TD style="WIDTH: 110px">Documento</TD>
								<TD>
									<asp:label id="lblDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 20px">Fecha</TD>
								<TD style="HEIGHT: 20px">
									<asp:label id="lblFchEmision" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Importe&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD>
									<asp:label id="lblTotal" runat="server" CssClass="Dato"></asp:label>&nbsp;
									<asp:label id="lblMoneda" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 19px">Referencia</TD>
								<TD style="HEIGHT: 19px">
									<asp:label id="lblReferencia" runat="server" Width="384px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Titular</TD>
								<TD>
									<asp:label id="lblGlosaDocumento" runat="server" Width="376px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Cód.Autorización</TD>
								<TD>
									<asp:label id="lblCodAutoriza" runat="server" Width="200px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 20px">Banco</TD>
								<TD style="HEIGHT: 20px">
									<asp:Label id="lblBanco" runat="server"></asp:Label>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 17px">Cuenta</TD>
								<TD style="HEIGHT: 17px">
									<asp:label id="lblCuenta" runat="server" Width="376px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 19px">
									<asp:Label id="lblComision" runat="server" CssClass="TABLA" Visible="False">Comisión TC</asp:Label></TD>
								<TD style="HEIGHT: 19px">
									<asp:TextBox id="txtComisionTC" runat="server" Width="112px" MaxLength="12" Visible="False"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmbGrabar" runat="server" Text="Grabar" Width="77px" Visible="False"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" CssClass="msg" Width="488px"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
