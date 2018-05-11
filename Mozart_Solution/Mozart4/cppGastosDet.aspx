<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppGastosDet.aspx.vb" Inherits="cppGastosDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 8px; HEIGHT: 96px"
				cellSpacing="0" cellPadding="0" width="680" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Movimiento de pagos por Cuenta</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 103px">
						<TABLE class="tabla" id="Table3" style="WIDTH: 552px; HEIGHT: 92px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="552" border="0">
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 29px">&nbsp;Fecha emisión</TD>
								<TD style="WIDTH: 68px; HEIGHT: 29px">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" background="tabla" border="0">
										<TR>
											<TD style="WIDTH: 82px"><asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" ></asp:textbox></TD>
											<TD><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchInicial"></TD>
											<TD>&nbsp;al
											</TD>
											<TD style="WIDTH: 75px"><asp:textbox id="txtFchFinal" runat="server" Width="75px" CssClass="fd" ></asp:textbox></TD>
											<TD><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchFinal"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 17px">&nbsp;Tipo</TD>
								<TD style="WIDTH: 68px; HEIGHT: 17px"><asp:dropdownlist id="ddlTipoCuenta" 
                                        runat="server" Width="440px" DataTextField="NomCuenta" 
                                        DataValueField="CodCuenta" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp;Cuenta
								</TD>
								<TD style="WIDTH: 68px"><asp:dropdownlist id="ddlCuenta" runat="server" 
                                        Width="439px" DataTextField="NomCuenta4" DataValueField="CodCuenta"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdBuscar" runat="server" Width="75px" Text="Buscar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="456px" CssClass="Msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"><asp:datagrid id="dgGastos" runat="server" Width="768px" CssClass="Grid" Height="17px" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="CadetBlue" CellPadding="2" BorderWidth="1px" ShowFooter="True" OnItemDataBound="ComputeSum">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Tipo" SortExpression="Tipo" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nro" SortExpression="Nro" HeaderText="Nro">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" SortExpression="FchEmision" HeaderText="Emisi&#243;n" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Soles" SortExpression="Soles" HeaderText="S/." DataFormatString="{0:###,###,###,###.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Dolares" SortExpression="Dolares" HeaderText="US$" DataFormatString="{0:###,###,###,###.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total US$" DataFormatString="{0:###,###,###,###.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="Referencia"></asp:BoundColumn>
								<asp:BoundColumn DataField="Proveedor" SortExpression="Proveedor" HeaderText="Proveedor"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
