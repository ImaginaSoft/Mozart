<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaReserva.aspx.vb" Inherits="VtaPropuestaReserva" %>

<%@ Register src="ucPropuesta.ascx" tagname="ucPropuesta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="593" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="lbltitulo" runat="server">Label</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucPropuesta ID="ucPropuesta1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="545px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgProveedor" runat="server" Width="600px" Height="20px" BorderStyle="None" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="2px" CellPadding="2" CssClass="Grid">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink3" runat="server" Text='Solicitud' NavigateUrl='<%# "VtaPropuestaReservaSolicitud.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))%>'>
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
								<asp:BoundColumn DataField="FchSolicita" HeaderText="Fecha Solicitud" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Precio Cotizado" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='Email' NavigateUrl='<%# "VtaPropuestaReservaEmail.aspx?CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&NomProveedor="+DataBinder.Eval(Container.DataItem,"NomProveedor")+"&CodContacto="+DataBinder.Eval(Container.DataItem,"CodContacto")+"&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&NroPropuesta="+cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))%>'>
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
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="NroPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodContacto" HeaderText="CodContacto">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
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
