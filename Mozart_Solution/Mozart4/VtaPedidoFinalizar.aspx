<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidoFinalizar.aspx.vb" Inherits="VtaPedidoFinalizar" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" >
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 499px; POSITION: absolute; TOP: 8px; HEIGHT: 104px"
				cellSpacing="0" cellPadding="1" width="499" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Estado&nbsp;del Pedido&nbsp;y Recordatorio</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 496px; HEIGHT: 168px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="496" border="1">
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 24px">&nbsp;Nro Pedido</TD>
								<TD style="HEIGHT: 24px"><asp:label id="lblNroPedido" runat="server" Width="81px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px">&nbsp;Descripción</TD>
								<TD><asp:label id="lblDesPedido" runat="server" Width="81px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 25px">&nbsp;Fecha Pedido</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblfchPedido" runat="server" Width="99px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 14px">&nbsp;Vendedor</TD>
								<TD style="HEIGHT: 14px"><asp:label id="lblVendedor" runat="server" Width="99px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 22px">&nbsp;Estado del Pedido</TD>
								<TD style="HEIGHT: 22px"><asp:radiobutton id="rbtSolicitado" runat="server" Text="Solicitado" GroupName="grupo1" AutoPostBack="True"></asp:radiobutton>&nbsp;&nbsp;
									<asp:radiobutton id="rbtNegociacion" runat="server" Text="Negociación" GroupName="grupo1" AutoPostBack="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtAnulado" runat="server" Text="Anulado" GroupName="grupo1" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 22px">&nbsp;</TD>
								<TD style="HEIGHT: 22px"><asp:radiobutton id="rbtVendido" runat="server" Text="Vendido" GroupName="grupo1" AutoPostBack="True"
										Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtCerrado" runat="server" Text="Cerrado" GroupName="grupo1" AutoPostBack="True"
										Enabled="False"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px; HEIGHT: 22px"><asp:label id="lblmotivo" runat="server" Visible="False">Motivo anulación</asp:label></TD>
								<TD style="HEIGHT: 22px"><asp:dropdownlist id="ddlMotivo" runat="server" Width="360px" Visible="False" DataValueField="CodMotivo"
										DataTextField="NomMotivo"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 496px; HEIGHT: 40px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="496" border="1">
							<TR>
								<TD style="WIDTH: 127px">Nro. Recordatorio</TD>
								<TD><asp:textbox id="txtNroRecordatorio" runat="server" Width="40px" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px">Fecha último envio</TD>
								<TD><asp:textbox id="txtFchUltEnvio" runat="server" Width="75px" CssClass="fd"></asp:textbox><INPUT id="cmdFchUltEnvio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchUltEnvio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchUltEnvio"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 127px">Idioma Recordatorio</TD>
								<TD><asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="81" Text="Grabar " Height="27"></asp:button><asp:label id="lblCodStsPedido" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="480px" CssClass="ERROR" Height="20px" BorderWidth="0px"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
