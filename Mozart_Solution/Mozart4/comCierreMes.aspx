<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comCierreMes.aspx.vb" Inherits="comCierreMes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE class="tabla" id="Table3" 
					cellSpacing="0" cellPadding="1" width="440" border="0">
					<TR>
						<TD style="HEIGHT: 1px">
							<P class="Titulo">&nbsp;Cierre del Mes</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px">
							<TABLE class="form" id="Table1" cellSpacing="0" cellPadding="0"
								width="410" border="1">
								<TR>
									<TD style="WIDTH: 72px">Declaración
									</TD>
									<TD>
										<TABLE class="tabla" id="Table6"  cellSpacing="0" cellPadding="0"
											width="230" border="0">
											<TR>
												<TD style="WIDTH: 32px">Año</TD>
												<TD style="WIDTH: 50px"><asp:textbox id="txtano" runat="server" DESIGNTIMEDRAGDROP="21" Width="37px">2005</asp:textbox>&nbsp;&nbsp;</TD>
												<TD>Mes</TD>
												<TD><asp:dropdownlist id="ddlCalendario" runat="server" Width="105px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
									<TD><asp:button id="cmdConsultar" runat="server" Width="74px" Text="Buscar"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px">&nbsp;Resumen&nbsp;Ventas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px"><asp:datagrid id="dgVentas" runat="server" Width="328px" Height="24px" CssClass="Grid" AutoGenerateColumns="False"
								CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="NroDocs" HeaderText="N&#176; Doc's"></asp:BoundColumn>
									<asp:BoundColumn DataField="SSubTotal" SortExpression="SSubTotal" HeaderText="SubTotal" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIGV" SortExpression="SIGV" HeaderText="IGV /Ret." DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SInafecto" SortExpression="SInafecto" HeaderText="Inafecta" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STotal" SortExpression="STotal" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px">Resumen Compras</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 11px"><asp:datagrid id="dgCompras" runat="server" Width="328px" Height="24px" CssClass="Grid" AutoGenerateColumns="False"
								CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="NroDocs" HeaderText="N&#176; Doc's"></asp:BoundColumn>
									<asp:BoundColumn DataField="SSubTotal" SortExpression="SSubTotal" HeaderText="SubTotal" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIGV" SortExpression="SIGV" HeaderText="IGV /Ret." DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SInafecto" SortExpression="SInafecto" HeaderText="Inafecta" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STotal" SortExpression="STotal" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px"><asp:button id="cmdCierre" runat="server" Width="184px" Text="Procesa Cierre"></asp:button>&nbsp;
							<asp:label id="lblmsg" runat="server" CssClass="msg"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblAnoCierre" runat="server" Visible="False"></asp:label><asp:label id="lblMesCierre" runat="server" DESIGNTIMEDRAGDROP="423" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</form>
</body>
</html>
