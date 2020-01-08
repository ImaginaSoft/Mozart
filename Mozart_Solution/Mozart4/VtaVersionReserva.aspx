<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionReserva.aspx.vb" Inherits="VtaVersionReserva" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 560px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="0" cellPadding="0" width="560" border="0">
				<TR>
					<TD style="HEIGHT: 19px">
						<P class="Titulo">&nbsp;
							<asp:Label id="lbltitulo" runat="server">Label</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaVersion" runat="server" Width="112px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="545px" Height="22px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgProveedor" runat="server" CssClass="Grid" Height="20px" Width="750px" CellPadding="2"
							BorderWidth="2px" BorderColor="CadetBlue" AutoGenerateColumns="False" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink3" runat="server" Text='Solicitud' NavigateUrl='<%# "VtaVersionReservaSolicitud.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))+"&NroVersion="+cstr(DataBinder.Eval(Container.DataItem,"NroVersion"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="C&#243;d.">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Proveedor">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NomProveedor")%>' NavigateUrl='<%# "VtaPedidoHistProveedor.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&CodCliente="+cstr(DataBinder.Eval(Container.DataItem,"CodCliente"))+"&opcion=2" %>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Solicita">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NomSolicita")%>' NavigateUrl='<%# "VtaVersionReservaConfirma.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))+"&NroVersion="+cstr(DataBinder.Eval(Container.DataItem,"NroVersion"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="FchSolicita" HeaderText="Fecha Solicitud" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='Pasajero' NavigateUrl='<%# "VtaVersionReservaPasajero.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))+"&NroVersion="+cstr(DataBinder.Eval(Container.DataItem,"NroVersion"))+"&NroFile="+DataBinder.Eval(Container.DataItem,"NroFile")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>

								<asp:BoundColumn DataField="Total" HeaderText="Precio Cotizado" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='Email' NavigateUrl='<%# "VtaVersionReservaEmail.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))+"&NroVersion="+cstr(DataBinder.Eval(Container.DataItem,"NroVersion"))+"&NroFile="+DataBinder.Eval(Container.DataItem,"NroFile")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NomContacto" HeaderText="Responsable">
									<ItemStyle BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchRpta" HeaderText="Fecha Rpta" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }">
									<ItemStyle BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesRpta" HeaderText="Rpta">
									<ItemStyle BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="NroPedido">
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
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodContacto" HeaderText="CodContacto">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="EmailContacto" DataFormatString="EmailContacto">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroFile" SortExpression="NroFile" HeaderText="N&#176; File">
									<ItemStyle BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</FORM>

</body>
</html>
