<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaLink.aspx.vb" Inherits="VtaPropuestaLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 528px; POSITION: absolute; TOP: 8px; HEIGHT: 344px"
				cellSpacing="0" cellPadding="1" width="528" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="OPCIONES">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="Tabla" id="Table3" style="WIDTH: 509px; HEIGHT: 43px" cellSpacing="0" cellPadding="0"
							width="509" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 78px; HEIGHT: 5px">&nbsp;
									<asp:label id="Label2" runat="server">Ciudad</asp:label></TD>
								<TD style="HEIGHT: 5px"><asp:dropdownlist id="ddlCiudad" runat="server" DataValueField="CodCiudad" DataTextField="NomCiudad"
										Width="253px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 78px; HEIGHT: 24px">&nbsp;
									<asp:label id="Label4" runat="server">Servicio</asp:label></TD>
								<TD style="HEIGHT: 24px">
									<asp:dropdownlist id="ddlServicio" runat="server" AutoPostBack="True" Width="376px" DataTextField="DesProveedor"
										DataValueField="NroServicio"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 78px">&nbsp;<asp:label id="Label3" runat="server">Link</asp:label></TD>
								<TD><asp:dropdownlist id="ddlLink" runat="server" DataValueField="CodLink" DataTextField="Titulo" Width="377px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="498px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLink" runat="server" Width="750px" Height="25px" CellPadding="2" BorderWidth="1px"
							AutoGenerateColumns="False" CssClass="Grid" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro."></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodLink" HeaderText="Link"></asp:BoundColumn>
								<asp:BoundColumn DataField="Titulo" HeaderText="Hotel"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
