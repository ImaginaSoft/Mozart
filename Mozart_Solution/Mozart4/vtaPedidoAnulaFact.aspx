<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaPedidoAnulaFact.aspx.vb" Inherits="vtaPedidoAnulaFact" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 676px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="676" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							<asp:Label id="lblTitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><asp:label id="lblMsg" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblSubtitCli" runat="server">Documentos en el cliente para anular </asp:Label>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4px">
						<asp:datagrid id="dgDCLIENTE" runat="server" CssClass="Grid" Width="680px" Height="17px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" AllowSorting="True">
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
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<asp:Label id="lblSubTitPro" runat="server">Documentos en el Proveedor para Anular</asp:Label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDPROVEEDOR" runat="server" AllowSorting="True" CellPadding="2" BorderWidth="1px"
							AutoGenerateColumns="False" BorderColor="CadetBlue" Height="17px" CssClass="Grid" Width="656px">
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
					<TD>&nbsp;
						<asp:button id="cmdAnulaFact" runat="server" Width="140px" Text="Anular Facturación"></asp:button></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
