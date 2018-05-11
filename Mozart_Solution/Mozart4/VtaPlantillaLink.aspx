<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaLink.aspx.vb" Inherits="VtaPlantillaLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="Tabla" id="Table3" style="Z-INDEX: 104; LEFT: 15px; WIDTH: 509px; POSITION: absolute; TOP: 56px; HEIGHT: 73px"
				cellSpacing="1" cellPadding="1" width="509" border="1">
				<TR>
					<TD style="WIDTH: 109px">&nbsp;
						<asp:label id="Label1" runat="server">TipoLink</asp:label></TD>
					<TD><asp:dropdownlist id="ddlTipoLink" runat="server" DataValueField="CodTipoLink" DataTextField="TipoLink"
							Width="252px" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 109px; HEIGHT: 5px">&nbsp;
						<asp:label id="Label2" runat="server">Ciudad</asp:label></TD>
					<TD style="HEIGHT: 5px"><asp:dropdownlist id="ddlCiudad" runat="server" DataValueField="CodCiudad" DataTextField="NomCiudad"
							Width="253px" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 109px; HEIGHT: 19px">&nbsp;&nbsp;<asp:label id="Label3" runat="server">Link</asp:label></TD>
					<TD style="HEIGHT: 19px"><asp:dropdownlist id="ddlLink" runat="server" DataValueField="CodLink" DataTextField="Titulo" Width="373px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 109px">&nbsp;</TD>
					<TD>
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:datagrid id="dgLink" style="Z-INDEX: 103; LEFT: 14px; POSITION: absolute; TOP: 208px" runat="server"
				Width="596px" Height="25px" CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False"
				BorderStyle="None" CssClass="Grid" BorderColor="CadetBlue">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="NroServicio" HeaderText="Serv">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodLink" HeaderText="Link"></asp:BoundColumn>
					<asp:BoundColumn DataField="TipoLink" HeaderText="Tipo link"></asp:BoundColumn>
					<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
					<asp:BoundColumn DataField="Titulo" HeaderText="Titulo"></asp:BoundColumn>
					<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="NomStsServicio" HeaderText="Estado"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:label id="lblMsg" 
                style="Z-INDEX: 102; LEFT: 15px; POSITION: absolute; TOP: 180px" runat="server"
				Width="498px" CssClass="error"></asp:label>
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 595px; POSITION: absolute; TOP: 15px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="595"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
