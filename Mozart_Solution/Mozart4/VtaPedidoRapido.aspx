<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidoRapido.aspx.vb" Inherits="VtaPedidoRapido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 568px; POSITION: absolute; TOP: 8px; HEIGHT: 424px"
				cellSpacing="0" cellPadding="1" width="568" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Pedido&nbsp;del Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P class="SubTitulo">Datos del Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 560px; HEIGHT: 102px" cellSpacing="0" cellPadding="0"
							width="560" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 103px">
									Nombre</TD>
								<TD>
									<asp:TextBox id="txtnombre" runat="server" Width="244px" tabIndex="1" MaxLength="40"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 103px; HEIGHT: 25px">
									Apellido Paterno</TD>
								<TD style="HEIGHT: 25px">
									<asp:TextBox id="txtpaterno" runat="server" Width="244px" tabIndex="2" MaxLength="25" AutoPostBack="True"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtpaterno" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 103px; HEIGHT: 24px">E-mail</TD>
								<TD style="HEIGHT: 24px">
									<asp:TextBox id="txtEmail" tabIndex="2" runat="server" MaxLength="50" Width="344px" AutoPostBack="True"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ForeColor=" " CssClass="error" ErrorMessage="Dato obligatorio"
										ControlToValidate="txtEmail" Width="96px"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 103px">
									Idioma</TD>
								<TD>
									<asp:dropdownlist id="ddlIdioma" tabIndex="6" runat="server" Width="264px" DataTextField="NomIdioma"
										DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 103px">
									Rango de Edad&nbsp;</TD>
								<TD>
									<asp:dropdownlist id="ddlRangoEdad" runat="server" Width="264px" 
                                        DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<P class="SubTitulo">Datos del&nbsp;Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 560px; HEIGHT: 179px" cellSpacing="0" cellPadding="0"
							width="560" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 110px">Descripción</TD>
								<TD><asp:textbox id="txtDesc" runat="server" Width="344px" tabIndex="5"></asp:textbox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Dato obligatorio" ControlToValidate="txtDesc"
										CssClass="error" ForeColor=" "></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 20px">Fecha pedido</TD>
								<TD style="HEIGHT: 20px">
									<asp:textbox id="txtFchPedido" runat="server" Width="75px" CssClass="fd"  tabIndex="6"></asp:textbox>
									<INPUT class="fd" id="cmdFchPedido" onclick="show_calendar('Form1.txtFchPedido',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="7" type="button" value="..." name="cmdFchPedido"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 18px">
									Probable atención</TD>
								<TD style="HEIGHT: 18px">
									<asp:DropDownList id="ddlMes" runat="server" Width="123px" tabIndex="8">
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
									</asp:DropDownList>Año
									<asp:dropdownlist id="ddlAno" runat="server" Width="72px" DataTextField="AnoProceso" DataValueField="AnoProceso"
										tabIndex="9"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Vendedor</TD>
								<TD><asp:dropdownlist id="ddlVendedor" runat="server" Width="264px" DataValueField="CodVendedor" DataTextField="NomVendedor"
										tabIndex="10"></asp:dropdownlist>
									<asp:label id="lblVendedor" runat="server" Width="168px" BackColor="White" BorderColor="White"
										ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">
									N° pasajeros</TD>
								<TD>
									<asp:textbox id="txtAdultos" runat="server" Width="35px" tabIndex="10" 
                                        MaxLength="3"></asp:textbox>&nbsp;
									<asp:label id="Label6" runat="server"> Adultos</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;
									<asp:textbox id="txtNinos" runat="server" Width="35px" tabIndex="11" MaxLength="2"></asp:textbox>&nbsp;
									<asp:label id="Label7" runat="server"> Niños</asp:label>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Perfil Cliente</TD>
								<TD>
									<asp:dropdownlist id="ddlStsCaptacion" runat="server" Width="264px" DataValueField="StsCaptacion"
										DataTextField="NomStsCaptacion" tabIndex="14"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 14px">Zona Venta</TD>
								<TD style="HEIGHT: 14px">
									<asp:dropdownlist id="ddlZonaVta" runat="server" Width="264px" DataValueField="CodZonaVta" DataTextField="NomZonaVta"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Origen Pedido</TD>
								<TD>
									<asp:dropdownlist id="ddlOrigenPedido" runat="server" Width="264px" DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Tiene Comentario&nbsp;</TD>
								<TD>
									<asp:dropdownlist id="ddlFlagComentario" runat="server" Width="64px" 
                                        DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdGrabar" runat="server" Text="Grabar" Width="80px" tabIndex="16"></asp:Button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="441px" CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
