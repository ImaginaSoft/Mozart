<%@ Page Language="vb" AutoEventWireup="false" CodeFile="bolReporteBoletos.aspx.vb" Inherits="bolReporteBoletos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			
			
			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="602" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="lbltitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>


				<TR>
					<TD>
			<TABLE id="Table1" 
				cellSpacing="1" cellPadding="1" width="602" border="0">
				<TR>
					<TD class="tabla" style="WIDTH: 394px">Si Ud. esta conforme con los boletos, 
						generar Reporte de Ventas</TD>
					<TD><asp:button id="cmdFacturar" runat="server" Width="104px" Text="Facturar"></asp:button></TD>
				</TR>
				<TR>
					<TD class="tabla" style="WIDTH: 394px">
						<asp:Label id="lblmsg" runat="server" CssClass="error"></asp:Label></TD>
					<TD></TD>
				</TR>
			</TABLE>



					</TD>
				</TR>


				<TR>
					<TD>
						<asp:datagrid id="dgBoleto" runat="server" OnItemDataBound="ComputeSum" ShowFooter="True" CssClass="Grid"
							Height="17px" Width="850px" BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="1px"
							CellPadding="2">
							<FooterStyle HorizontalAlign="Right"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Boleto" HeaderText="Boleto">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Tarifa" HeaderText="TarifaNeta" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Impuesto" HeaderText="Impuesto" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="credito" HeaderText="Cr&#233;dito" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PComision1" HeaderText="%Comi1" DataFormatString="{0:###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision1" HeaderText="Comi1" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV1" HeaderText="IGV1" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision2" HeaderText="Comi2" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV2" HeaderText="IGV2" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Observacion" HeaderText="Obs.">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Emisi&#243;n" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>&nbsp;&nbsp;</TD>

					</TD>
				</TR>



				<TR>
					<TD>
                        <class="TABLA">Total reporte de ventas&nbsp;(<FONT color="#cc6699">Tarifa Neta + IGV 
							+ Impuesto&nbsp;- Comi1 - IGV1 - Comi2 - IGV2&nbsp;</FONT>) =
						<asp:Label id="lblTotRep" runat="server"></asp:Label>
					
					</TD>
				</TR>

			</TABLE>
		</form>
</body>
</html>
