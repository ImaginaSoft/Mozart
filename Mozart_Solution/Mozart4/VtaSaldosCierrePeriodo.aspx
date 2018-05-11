<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaSaldosCierrePeriodo.aspx.vb" Inherits="VtaSaldosCierrePeriodo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 589px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD style="HEIGHT: 20px">
						<P class="Titulo">Saldo de Versiones Facturadas al cierre de periodo de ventas</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 16px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 10px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="WIDTH: 177px; HEIGHT: 23px">Tipo de informe</TD>
								<TD style="HEIGHT: 23px">
									<TABLE class="tabla" id="Table4" style="WIDTH: 328px; HEIGHT: 20px" cellSpacing="0" cellPadding="0"
										width="328" border="0">
										<TR>
											<TD>
												<asp:RadioButton id="rbtResumen" runat="server" Text="Resumen por vendedor" GroupName="g1"></asp:RadioButton></TD>
											<TD>
												<asp:RadioButton id="rbtDetalle" runat="server" Width="155px" Text="Detalle por versión" Checked="True"
													GroupName="g1"></asp:RadioButton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 23px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 177px; HEIGHT: 10px">Zona de Venta</TD>
								<TD style="HEIGHT: 10px">
									<asp:dropdownlist id="ddlZonaVta" runat="server" Width="298px" DataValueField="CodZonaVta" DataTextField="NomZonaVta"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 10px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 177px">
									Vendedor</TD>
								<TD><asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 177px"></TD>
								<TD>
									<asp:LinkButton id="lbtMostrarPeriodos" runat="server">Mostrar las últimos </asp:LinkButton>&nbsp;
									<asp:TextBox id="txtNroReg" runat="server" Width="40px">12</asp:TextBox>&nbsp;periodos 
									de venta cerrados
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 177px">Cierre de Periodo&nbsp;Ventas del</TD>
								<TD>
									<TABLE class="tabla" id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
										<TR>
											<TD style="WIDTH: 124px">
												<asp:dropdownlist id="ddlPeriodoVtaIni" runat="server" DataValueField="NroPeriodoVta" DataTextField="FchFinPeriodo"
													Width="112px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 28px">&nbsp;al</TD>
											<TD>
												<asp:dropdownlist id="ddlPeriodoVtaFin" runat="server" Width="112px" DataValueField="NroPeriodoVta"
													DataTextField="FchFinPeriodo"></asp:dropdownlist>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 177px"></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgVersiones" runat="server" Width="595px" CssClass="Grid" Height="17px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSum">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="Version">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodZonaVta" SortExpression="CodZonaVta" HeaderText="Zona">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" SortExpression="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" SortExpression="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFinPeriodo" SortExpression="FchFinPeriodo" HeaderText="Cierre" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
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
