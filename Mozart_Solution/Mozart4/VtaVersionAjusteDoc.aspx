<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionAjusteDoc.aspx.vb" Inherits="VtaVersionAjusteDoc" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 544px; POSITION: absolute; TOP: 8px; HEIGHT: 85px"
				cellSpacing="0" cellPadding="1" width="544" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Documentos de Ajuste</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" CssClass="msg" Width="528px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDocumento" runat="server" CssClass="Grid" Height="17px" Width="778px" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" ReadOnly="True" HeaderText="Pedido" DataFormatString="{0:##########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Servicio">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" HeaderText="Pend." DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tabla" HeaderText="Tabla">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" HeaderText="TipoOperacion">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="NroPropuesta">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="NroVersion">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Origen" HeaderText="Origen">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Codigo" HeaderText="Codigo">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
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
