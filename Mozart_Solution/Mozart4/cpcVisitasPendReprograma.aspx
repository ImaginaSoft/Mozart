<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcVisitasPendReprograma.aspx.vb" Inherits="cpcVisitasPendReprograma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 581px; POSITION: absolute; TOP: 8px; HEIGHT: 290px"
				cellSpacing="0" cellPadding="0" width="581" border="0" class="Form">
				<TR>
					<TD>
						<P class="Titulo"><asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 584px; HEIGHT: 196px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="584" border="1">
							<TR>
								<TD style="WIDTH: 85px">Nro Pedido</TD>
								<TD><asp:label id="lblNroPedido" runat="server" Width="46px"></asp:label>&nbsp;
									<asp:label id="lblDesPedido" runat="server" Width="399px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px; HEIGHT: 2px">Cliente</TD>
								<TD style="HEIGHT: 2px"><asp:label id="lblNomCliente" runat="server" Width="175px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Vendedor</TD>
								<TD><asp:label id="lblNomVendedor" runat="server" Width="172px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px; HEIGHT: 18px">Pax</TD>
								<TD style="HEIGHT: 18px"><asp:label id="lblPax" runat="server" Width="46px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Tipo Visita</TD>
								<TD><asp:label id="lblTipo" runat="server" Width="171px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Fecha Visita</TD>
								<TD><asp:textbox id="txtFchVisita" runat="server" Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchVisita',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Hora Visita</TD>
								<TD><asp:textbox id="txtHoraVisita" runat="server" Width="74px" MaxLength="5"></asp:textbox>&nbsp;&nbsp;&nbsp;
									<asp:Label id="Label1" runat="server"> (Formato: hh:mm )</asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Responsable</TD>
								<TD><asp:dropdownlist id="ddlVendedor" runat="server" Width="187px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Visita</TD>
								<TD><asp:radiobutton id="rbsi" runat="server" Text="Si" Checked="True" GroupName="Grupo3" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="rbno" runat="server" Text="No" GroupName="Grupo3" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px">Evaluación</TD>
								<TD>
									<asp:dropdownlist id="ddlEvaluacion" runat="server" Width="409px" DataValueField="CodEvaluacion" DataTextField="NomEvaluacion"
										Enabled="False"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="585px" CssClass="error" ></asp:label></TD>
				</TR>
			</TABLE>
			<asp:label id="lblCodigo" style="Z-INDEX: 101; LEFT: 29px; POSITION: absolute; TOP: 244px"
				runat="server" Width="46px" Visible="False">0</asp:label></form></body>
</html>
