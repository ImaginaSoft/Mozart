<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcVisitasPend.aspx.vb" Inherits="cpcVisitasPend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="Form" id="Table1" style="Z-INDEX: 101; LEFT: 13px; WIDTH: 575px; POSITION: absolute; TOP: 14px; HEIGHT: 54px"
				cellSpacing="0" cellPadding="0" width="575" border="0">
				<TR>
					<TD>
						<P class="Titulo">Visitas Pendientes</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 446px; HEIGHT: 101px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="446" border="1">
							<TR>
								<TD style="WIDTH: 107px; HEIGHT: 2px">&nbsp;Fecha visita&nbsp;&nbsp;del</TD>
								<TD style="WIDTH: 286px; HEIGHT: 2px"><asp:textbox id="txtFchInicial" runat="server"  Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Width="18px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchInicial" Height="8px">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server"  Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 107px">&nbsp;Tipo visita</TD>
								<TD style="WIDTH: 286px"><asp:radiobutton id="rbLlegada" runat="server" Text="Entrada" GroupName="Grupo1" Checked="True"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbSalida" runat="server" Text="Salida" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 107px">&nbsp;Responsable</TD>
								<TD style="WIDTH: 286px"><asp:dropdownlist id="ddlVendedor" runat="server" Width="187px" DataValueField="CodVendedor" DataTextField="NomVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 107px"></TD>
								<TD style="WIDTH: 286px"><asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="568px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLista" runat="server" Width="600px" CssClass="Grid" Height="17px" AllowSorting="True"
							BorderColor="CadetBlue"   AutoGenerateColumns="False" BorderWidth="1px"
							CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantPasajeros" SortExpression="CantPasajeros" HeaderText="Pax" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchVisita" SortExpression="FchVisita" HeaderText="Visita" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Hora" SortExpression="Hora" HeaderText="Hora Visita">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodResponsable" SortExpression="CodResponsable" HeaderText="Responsable"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoVisita" HeaderText="TipoVisita">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Reprogramar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesServicio" SortExpression="DesServicio" HeaderText="Hotel"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" SortExpression="HoraServicio" HeaderText="Hora Llegada"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Actualizado" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Label id="lblCodResponsable" runat="server" Visible="False"></asp:Label></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
