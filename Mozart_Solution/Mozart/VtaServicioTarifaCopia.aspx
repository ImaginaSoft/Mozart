<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioTarifaCopia.aspx.vb" Inherits="VtaServicioTarifaCopia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="0" width="460" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Copia Tarifas x Periodo</TD>
				</TR>
				<TR>
					<TD class="opciones" style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtTarifas" runat="server">Regresar Tarifas</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="opciones" style="WIDTH: 467px">Servicio y periodo&nbsp;de origen</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 143px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 656px; HEIGHT: 144px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">N° Servicio</TD>
								<TD style="HEIGHT: 25px">
									<asp:Label id="lblNroServicioOrigen" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									Periodo</TD>
								<TD style="HEIGHT: 25px">
									<asp:dropdownlist id="ddlTarifaPeriodoOrigen" runat="server" Width="432px" DataTextField="DesTarifa"
										DataValueField="CodTarifa" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Proveedor</TD>
								<TD style="HEIGHT: 25px">
									<asp:label id="lblNomProveedorOrigen" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Ciudad</TD>
								<TD style="HEIGHT: 25px">
									<asp:label id="lblNomCiudadOrigen" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Tipo Servicio</TD>
								<TD style="HEIGHT: 25px">
									<asp:label id="lblTipoServicioOrigen" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Descripción</TD>
								<TD style="HEIGHT: 25px">
									<asp:label id="lblDesServicioOrigen" runat="server" Width="520px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 4px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 4px">Servicio y periodo de destino</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 25px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 656px; HEIGHT: 144px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">N° Servicio</TD>
								<TD style="HEIGHT: 25px" class="error">
									<asp:TextBox id="txtNroServicioDestino" runat="server" Width="88px" AutoPostBack="True"></asp:TextBox>&nbsp;(tecla 
									TAB para mostrar el servicio destino)</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									Periodo</TD>
								<TD style="HEIGHT: 25px">
									<asp:dropdownlist id="ddlTarifaPeriodoDestino" runat="server" Width="432px" DataTextField="DesTarifa"
										DataValueField="CodTarifa" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Proveedor</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblNomProveedorDestino" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Ciudad</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblNomCiudadDestino" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 9px">&nbsp;Tipo Servicio</TD>
								<TD style="HEIGHT: 9px"><asp:label id="lblTipoServicioDestino" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Servicio</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblDesServicioDestino" runat="server" Width="520px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" CssClass="msg" 
                            Width="632px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
