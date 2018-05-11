<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabTipoCambio.aspx.vb" Inherits="TabTipoCambio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 48px"
				cellSpacing="0" cellPadding="1" width="600" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE id="Table1" style="WIDTH: 600px; HEIGHT: 92px" cellSpacing="0" cellPadding="0" width="600"
							border="0">
							<TR>
								<TD style="WIDTH: 414px">
									<TABLE class="tabla" id="Table3" style="WIDTH: 232px; HEIGHT: 65px" cellSpacing="0" cellPadding="0"
										width="232" border="0">
										<TR>
											<TD>Fecha</TD>
											<TD><asp:textbox id="txtFchPedido" tabIndex="6" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchPedido" onclick="show_calendar('Form1.txtFchPedido',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="7" type="button" value="..." name="cmdFchPedido"></TD>
										</TR>
										<TR>
											<TD>Tipo cambio venta</TD>
											<TD><asp:textbox id="txtTipoCambioVta" runat="server" Width="72px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 12px"></TD>
											<TD style="HEIGHT: 12px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE class="tabla" id="Table5" style="WIDTH: 232px; HEIGHT: 74px" cellSpacing="0" cellPadding="0"
										width="232" border="0">
										<TR>
											<TD style="HEIGHT: 15px">&nbsp;Año</TD>
											<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlAno" tabIndex="9" runat="server" Width="72px" DataValueField="AnoProceso"
													DataTextField="AnoProceso"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD>&nbsp;Mes&nbsp;</TD>
											<TD><asp:dropdownlist id="ddlMes" runat="server" Width="136px" DataValueField="CodElemento" DataTextField="NomElemento"
													AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 27px"></TD>
											<TD style="HEIGHT: 27px"><asp:button id="cmdBusca" runat="server" Width="80px" Text="Consultar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="528px" Height="17px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dglista" runat="server" Width="600px" Height="17px" CssClass="Grid"  
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoCambioVta" HeaderText="Tipo Cambio Venta">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Fchsys" HeaderText="Actualizado">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
