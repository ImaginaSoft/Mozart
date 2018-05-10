<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaMLink.aspx.vb" Inherits="VtaMLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 514px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="0" width="514" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Link</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:LinkButton id="lbtNuevoLink" runat="server">Nuevo Link</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="Tabla" id="Table3" style="WIDTH: 379px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
							width="379" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 109px">
									&nbsp; Ciudad</TD>
								<TD>
									<asp:dropdownlist id="ddlCiudad" runat="server" DataValueField="CodCiudad" DataTextField="NomCiudad"
										Width="253px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 109px; HEIGHT: 22px">&nbsp; Tipo Link</TD>
								<TD style="HEIGHT: 22px">
									<asp:dropdownlist id="ddlTipoLink" runat="server" DataValueField="CodTipoLink" DataTextField="TipoLink"
										Width="252px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdBuscar" runat="server" Width="77px" Text="Buscar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="400px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgMLink" runat="server" Width="520px" AllowSorting="True" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" Height="17px"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodLink" SortExpression="CodLink" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" SortExpression="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="Titulo" SortExpression="Titulo" HeaderText="Titulo">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsLink" SortExpression="StsLink" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="Telefono1" SortExpression="Telefono1" HeaderText="Telefono"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPagina" SortExpression="NomPagina" HeaderText="P&#225;gina"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCiudad" SortExpression="CodCiudad" HeaderText="CodCiudad">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoLink" SortExpression="CodTipoLink" HeaderText="CodTipoLink">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
