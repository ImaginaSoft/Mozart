<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabLinea.aspx.vb" Inherits="TabLinea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">Linea Aérea</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 504px; HEIGHT: 179px" cellSpacing="0" cellPadding="0"
							width="504" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 68px"><FONT size="2">Código</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="3"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 68px">Nombre</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtNombre" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 68px">Proveedor</TD>
								<TD>
									<asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="288px" AutoPostBack="True"
										DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 68px">Ruc</TD>
								<TD>
									<asp:TextBox id="txtRuc" runat="server" MaxLength="15"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 68px">Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 68px">Proveedor&nbsp;para&nbsp; reembolso&nbsp;</TD>
								<TD>
									<asp:dropdownlist id="ddlProReembolso" tabIndex="1" runat="server" Width="288px" DataTextField="NomProveedor"
										DataValueField="CodProveedor" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="451px" Height="17px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgLinea" runat="server" Width="576px"  Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodLinea" SortExpression="CodLinea" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomLinea" SortExpression="NomLinea" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedor">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="StsLinea" SortExpression="StsLinea" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="Ruc"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodProReembolso" SortExpression="CodProReembolso" HeaderText="Proveedor Reembolso">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
