<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaCuadreAereoDet.aspx.vb" Inherits="VtaCuadreAereoDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 728px; POSITION: absolute; TOP: 6px; HEIGHT: 240px"
				cellSpacing="0" cellPadding="1" width="728" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 584px; HEIGHT: 17px">
						<asp:label id="lblTitulo" runat="server">Label</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 17px"><asp:label id="lblmsg" runat="server" CssClass="Msg" Height="9px" Width="462px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 19px">Versión Facturada</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 8px">
						<asp:datagrid id="dgVersiones" runat="server" Width="568px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSumVersion">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesServicio" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioNeto" HeaderText="Precio Neto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioFact" HeaderText="Total Facturado" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 19px">Remisión de Boletos</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 19px">
						<asp:datagrid id="dgRemision" runat="server" Width="568px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSumRemision">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Boleto" HeaderText="Boleto"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchRemision" HeaderText="Remisi&#243;n" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="MontoRemision" HeaderText="Monto " DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 19px">Boletos Vendidos</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 6px">
						<asp:datagrid id="dgBoleto" runat="server" Width="664px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSumBoleto">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Boleto" HeaderText="Boleto"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tarifa" HeaderText="Tarifa" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Impuesto" HeaderText="Impuesto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision" HeaderText="Comisi&#243;n" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioBoleto" HeaderText="Total Boleto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha Emisi&#243;n" DataFormatString="{0:dd-MM-yyyy}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 16px" align="left">Boletos en el Stock Comprados</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 16px" align="left">
						<asp:datagrid id="dgStockComprados" runat="server" Width="568px" Height="17px" CssClass="Grid"
							BorderColor="CadetBlue" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True"
							ShowFooter="True" OnItemDataBound="ComputeSumCupon">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Boleto" HeaderText="Boleto"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tarifa" HeaderText="Tarifa" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Impuesto" HeaderText="Impuesto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision" HeaderText="Comisi&#243;n" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioBoleto" HeaderText="Tota Boleto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 16px" align="center">
						<asp:label id="lblDiferencia" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 17px">Ajustes realizados en Proveedor</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px">
						<asp:datagrid id="dgAjuste" runat="server" Width="568px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSumAjuste">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ajuste" HeaderText="Total Ajuste" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
