<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaClienteEnTour.aspx.vb" Inherits="VtaClienteEnTour" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 620px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
				cellSpacing="0" cellPadding="1" width="620" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;Clientes en Tour</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 60px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="HEIGHT: 17px">Vendedor</TD>
								<TD style="HEIGHT: 17px">
									<asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Fecha Reserva del</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" Height="8px" CssClass="error" DESIGNTIMEDRAGDROP="23"
										ControlToValidate="txtFchInicial" ForeColor=" ">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" Height="8px" CssClass="ERROR"
										DESIGNTIMEDRAGDROP="27" ControlToValidate="txtFchFinal" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"><asp:label id="lblmsg" runat="server" Width="462px" 
                            CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPedidos" runat="server" Width="800px" Height="17px" CssClass="Grid" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchReserva" SortExpression="FchReserva" HeaderText="Reserva" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" SortExpression="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" SortExpression="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" SortExpression="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="FlagIdioma" SortExpression="FlagIdioma" HeaderText="Idioma">
									<ItemStyle HorizontalAlign="Center" ></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Telefono" SortExpression="Telefono" HeaderText="Telefono">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" SortExpression="NroPropuesta" HeaderText="NroPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="NroVersion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" SortExpression="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
