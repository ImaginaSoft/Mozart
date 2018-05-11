<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segLogAccesoVisa.aspx.vb" Inherits="segLogAccesoVisa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1"  runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 589px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">Log de&nbsp;Accesos&nbsp;a Visa</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 632px; HEIGHT: 116px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="632" border="1">
							<TR>
								<TD style="WIDTH: 120px">&nbsp;Fecha Ingreso del</TD>
								<TD> 
                                    <asp:TextBox ID="txtFchInicial" runat="server" Width="80px" ></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFchInicial_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFchInicial">
                                    </asp:CalendarExtender>
&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtFchFinal" runat="server" Width="80px" ></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFchFinal_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFchFinal">
                                    </asp:CalendarExtender>
                                </TD>
							</TR>
							<TR>
								<TD style="WIDTH: 120px">&nbsp;E-mail</TD>
								<TD><asp:textbox id="txtemail" runat="server" Width="240px"></asp:textbox>(opcional)</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 120px" colSpan="1">&nbsp;</TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLog" runat="server" Width="780px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchEnvPago" SortExpression="FchEnvPago" HeaderText="Fecha">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrdenPago" SortExpression="NroOrdenPago" HeaderText="Orden" DataFormatString="{0:#########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" DataFormatString="{0:#########}"></asp:BoundColumn>
								<asp:BoundColumn DataField="MonOrdenPago" SortExpression="MonOrdenPago" HeaderText="Monto USD" DataFormatString="{0:###,###,###,###.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Visa" SortExpression="Visa" HeaderText="Rpta Visa">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RptOrdenPago" SortExpression="RptOrdenPago" HeaderText="Hora Rpta" DataFormatString="{0:HH:mm}">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="pan" SortExpression="pan" HeaderText="Tarjeta">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="imp_autorizado" SortExpression="imp_autorizado" HeaderText="Importe Autorizado"
									DataFormatString="{0:###,###,###,###.##}">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cod_autoriza" SortExpression="cod_autoriza" HeaderText="Codigo Autoriza">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Cod_accion" SortExpression="Cod_accion" HeaderText="CodVisa">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesAccion" SortExpression="DesAccion" HeaderText="DesVisa">
									<ItemStyle BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodZonaVta" SortExpression="CodZonaVta" HeaderText="Zona"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" SortExpression="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="NroDoc" DataFormatString="{0:#########}"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
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
