<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaPedidoAnulaFactVersion.aspx.vb" Inherits="vtaPedidoAnulaFactVersion" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 676px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="676" border="0">
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 22px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 17px"><asp:label id="lblMsg" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:label id="lblSubtitCli" runat="server">Documentos en el cliente para anular </asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:datagrid id="dgDCLIENTE" runat="server" CssClass="Grid" AllowSorting="True" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="17px" Width="680px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" ReadOnly="True" HeaderText="Versi&#243;n" DataFormatString="{0:##########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Tipo Servicio">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsDoc" HeaderText="Sts"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 17px"><asp:label id="lblSubTitPro" runat="server">Documentos en el Proveedor para Anular</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:datagrid id="dgDPROVEEDOR" runat="server" CssClass="Grid" AllowSorting="True" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="17px" Width="656px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="Versi&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsDoc" HeaderText="Sts"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 18px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 16px"><asp:label id="lblSubTitBoletos" runat="server"> Boletos que pasaran al stock de comprados</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:datagrid id="dgBoleto" runat="server" CssClass="Grid" AllowSorting="True" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="17px" Width="568px">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Boleto" HeaderText="Boleto">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioBoleto" HeaderText="Total" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
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
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 18px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 18px">Penalidades para cargar en Ctacte del 
						Proveedor</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:datagrid id="dgProveedor" runat="server" CssClass="Grid" CellPadding="2" BorderWidth="2px"
							AutoGenerateColumns="False" BorderColor="CadetBlue" Height="17px" Width="370px" DataKeyField="CodProveedor" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="Código">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Total">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<P>
											<asp:TextBox id=txtTotal runat="server" Width="100px" Text='<%# Container.DataItem("Total") %>' MaxLength="12">
											</asp:TextBox></P>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 11px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px">Penalidades para cargar en Ctacte del Cliente</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 448px; HEIGHT: 48px" cellSpacing="0" cellPadding="0"
							width="448" border="1">
							<TR>
								<TD style="WIDTH: 71px">Referencia</TD>
								<TD style="WIDTH: 305px"><asp:textbox id="txtReferencia" runat="server" Width="368px" MaxLength="50">Gastos de anulaci&#243;n de viaje</asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 71px">Total</TD>
								<TD style="WIDTH: 305px"><asp:textbox id="txtTotal" runat="server" Width="104px" MaxLength="12"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 18px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 18px">Procesos que se realizara:</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 36px">
						<TABLE id="Table2" style="WIDTH: 608px; HEIGHT: 18px" cellSpacing="0" cellPadding="0" width="608"
							border="0" class="form">
							<TR>
								<TD style="WIDTH: 297px" vAlign="top">
									<asp:Label id="lblAcciones1" runat="server" CssClass="msg"></asp:Label></TD>
								<TD vAlign="top">
									<asp:Label id="lblAcciones2" runat="server" CssClass="msg"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px; HEIGHT: 22px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px"><asp:button id="cmdAnulaFact" runat="server" Width="144px" Text="Anular  Facturación"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 684px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
