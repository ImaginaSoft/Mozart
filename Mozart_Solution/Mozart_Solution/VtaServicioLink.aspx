<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioLink.aspx.vb" Inherits="VtaServicioLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 480px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="480" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 481px; HEIGHT: 48px" cellSpacing="1" cellPadding="1"
							width="481" background="images/SubTitulo.jpg" border="0">
							<TR>
								<TD style="WIDTH: 66px"><asp:label id="Label1" runat="server">Ciudad</asp:label></TD>
								<TD><asp:label id="txtCiudad" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 66px; HEIGHT: 10px">
									<asp:label id="Label2" runat="server">Tipo Link</asp:label></TD>
								<TD style="HEIGHT: 10px">
									<asp:dropdownlist id="ddlTLink" runat="server" Width="400px" DataTextField="TipoLink" DataValueField="CodTipoLink"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 66px; HEIGHT: 10px">
									<asp:label id="Label3" runat="server">Link</asp:label></TD>
								<TD style="HEIGHT: 10px">
									<asp:dropdownlist id="ddlLink" runat="server" DataValueField="CodLink" DataTextField="Titulo" Width="400px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="345px" CssClass="Error"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblCodCiudad" runat="server" Visible="False"></asp:Label>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLink" runat="server" Width="480px" CssClass="Grid" CellPadding="2" BorderWidth="1px"
							BorderColor="CadetBlue" AllowSorting="True" AutoGenerateColumns="False" Height="25px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CodLink" HeaderText="Link"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoLink" HeaderText="Tipo Link"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="Titulo" HeaderText="Titulo"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
