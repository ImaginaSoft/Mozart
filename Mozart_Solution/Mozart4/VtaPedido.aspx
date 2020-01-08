<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedido.aspx.vb" Inherits="VtaPedido" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 728px; POSITION: absolute; TOP: 8px; HEIGHT: 79px"
				cellSpacing="0" cellPadding="1" width="728" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Pedido&nbsp;del Cliente</P>
					    <uc1:ucCliente ID="ucCliente1" runat="server" />
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 576px; HEIGHT: 248px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="576" border="1">
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 25px">&nbsp;Nro Pedido</TD>
								<TD style="HEIGHT: 25px">&nbsp;
									<asp:label id="lblNroPedido" runat="server" Width="81px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Descripción</TD>
								<TD><asp:textbox id="txtDesc" tabIndex="1" runat="server" Width="345px" MaxLength="100"></asp:textbox><asp:requiredfieldvalidator id="rfvNomPedido" runat="server" Width="93px" ErrorMessage="Dato obligatorio" ControlToValidate="txtDesc"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 25px">&nbsp;Fecha Pedido</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtFchPedido" tabIndex="2" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchPedido" onclick="show_calendar('Form1.txtFchPedido',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="3" type="button" value="..." name="cmdFchPedido">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchPedido" runat="server" Width="140px" ControlToValidate="txtFchPedido"
										CssClass="error" ForeColor=" " Height="8px">Dato obligatorio</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label2" runat="server">Estado</asp:label>&nbsp;
									<asp:label id="lblStsPedido" runat="server" Width="99px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 13px">&nbsp;Probable atención</TD>
								<TD style="HEIGHT: 13px"><asp:dropdownlist id="ddlMes" tabIndex="4" runat="server" Width="123px">
										<asp:ListItem Value="0">Mes</asp:ListItem>
										<asp:ListItem Value="1">Enero</asp:ListItem>
										<asp:ListItem Value="2">Febrero</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Abril</asp:ListItem>
										<asp:ListItem Value="5">Mayo</asp:ListItem>
										<asp:ListItem Value="6">Junio</asp:ListItem>
										<asp:ListItem Value="7">Julio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Setiembre</asp:ListItem>
										<asp:ListItem Value="10">Octubre</asp:ListItem>
										<asp:ListItem Value="11">Noviembre</asp:ListItem>
										<asp:ListItem Value="12">Diciembre</asp:ListItem>
									</asp:dropdownlist>&nbsp;Año&nbsp;&nbsp;
									<asp:dropdownlist id="ddlAno" tabIndex="5" runat="server" Width="72px" DataTextField="AnoProceso"
										DataValueField="AnoProceso"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 9px">&nbsp;Vendedor</TD>
								<TD style="HEIGHT: 9px"><asp:dropdownlist id="ddlVendedor" tabIndex="6" runat="server" Width="264px" DataTextField="NomVendedor"
										DataValueField="CodVendedor"></asp:dropdownlist><asp:label id="lblerror1" runat="server" CssClass="error"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;N° pasajeros</TD>
								<TD><asp:textbox id="txtAdultos" tabIndex="7" runat="server" Width="43px" 
                                        MaxLength="3"></asp:textbox><asp:label id="Label6" runat="server"> Adultos</asp:label>&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;
									<asp:textbox id="txtNinos" tabIndex="8" runat="server" Width="44px" MaxLength="2"></asp:textbox><asp:label id="Label7" runat="server"> Niños</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Perfil Cliente</TD>
								<TD><asp:dropdownlist id="ddlStsCaptacion" runat="server" Width="264px" DataTextField="NomStsCaptacion"
										DataValueField="StsCaptacion"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Zona Venta</TD>
								<TD><asp:dropdownlist id="ddlZonaVta" runat="server" Width="264px" DataTextField="NomZonaVta" DataValueField="CodZonaVta"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Origen Pedido</TD>
								<TD><asp:dropdownlist id="ddlOrigenPedido" runat="server" Width="264px" DataTextField="NomElemento" DataValueField="CodElemento"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Tiene Comentario&nbsp;</TD>
								<TD>
									<asp:dropdownlist id="ddlFlagComentario" runat="server" Width="64px" 
                                        DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Idioma</TD>
								<TD><asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px">&nbsp;Pasajero
								</TD>
								<TD>&nbsp;
									<asp:radiobutton id="rbtExtranjero" runat="server" Text="Extranjero" GroupName="g2" Checked="True"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtPeruano" runat="server" Text="Peruano" GroupName="g2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px"><asp:button id="cmdGrabar" tabIndex="11" runat="server" Width="80px" Text="Grabar "></asp:button><asp:label id="lblMsg" runat="server" Width="448px" CssClass="ERROR" Height="22px" BorderWidth="0px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px">&nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			&nbsp;</FORM>
</body>
</html>
