<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppCuadreVComprobanteLista.aspx.vb" Inherits="cppCuadreVComprobanteLista" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 502px; POSITION: absolute; TOP: 7px; HEIGHT: 187px"
				cellSpacing="0" cellPadding="0" width="502" border="0">
				<TR>
					<TD class="Titulo">
						<P class="Titulo">Completar Datos por&nbsp;Pre-Comprobante</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD>
                                    <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                                </TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDocumento" runat="server" Width="600px" Height="24px" CssClass="Grid" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="IdReg" HeaderText="IdReg">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoSistema" SortExpression="TipoSistema" HeaderText="TipoSistema">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchComprobante" SortExpression="FchComprobante" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoComprobante" SortExpression="TipoComprobante" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroComprobante" SortExpression="NroComprobante" HeaderText="N&#170; Documento">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodRelacion" SortExpression="CodRelacion" HeaderText="Proveedor">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DMoneda" SortExpression="DMoneda" HeaderText="Moneda"></asp:BoundColumn>
								<asp:BoundColumn DataField="SubTotalG" SortExpression="SubTotal" HeaderText="SubTotal" DataFormatString="{0:###,###,###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGVG" SortExpression="IGVG" HeaderText="IGV" DataFormatString="{0:###,###,###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="InafectoG" SortExpression="InafectoG" HeaderText="Inafecta">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalG" SortExpression="TotalG" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroMonto" HeaderText="NroMonto">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodMoneda">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblmsg" runat="server" CssClass="error"  Width="410px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:button id="btnGrabar" runat="server" Width="149px" Text="Grabar Comprobantes"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
