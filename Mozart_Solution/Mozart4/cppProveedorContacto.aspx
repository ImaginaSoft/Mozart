<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppProveedorContacto.aspx.vb" Inherits="cppProveedorContacto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">
						<asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 6px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 576px; HEIGHT: 239px" cellSpacing="1" cellPadding="1"
							width="576" border="1">
							<TR>
								<TD style="WIDTH: 89px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="198px" MaxLength="15"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtCodigo"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Nombre</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 28px">&nbsp;E-mail</TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="txtEmail" runat="server" Width="289px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 19px">&nbsp;Telefono</TD>
								<TD style="HEIGHT: 19px"><asp:textbox id="txtTelefono" runat="server" Width="200px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 20px">&nbsp;Estado</TD>
								<TD style="HEIGHT: 20px"><asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Orden</TD>
								<TD>
									<asp:textbox id="txtNroOrden" runat="server" MaxLength="2" Width="32px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Tipo Contacto</TD>
								<TD>
									<asp:RadioButton id="rbActualiza" runat="server" Checked="True" GroupName="Grupo2" Text="Actualiza Reserva"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="rbConsulta" runat="server" GroupName="Grupo2" Text="Consulta Reserva"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;</TD>
								<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:Label id="lblMsg" runat="server" CssClass="msg"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgLista" runat="server" AllowSorting="True" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" Height="17px" 
							Width="712px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodContacto" SortExpression="CodContacto" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomContacto" SortExpression="NomContacto" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Clave" CommandName="Cancel"></asp:ButtonColumn>
								<asp:BoundColumn DataField="EmailContacto" SortExpression="EmailContacto" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="Telefono1" SortExpression="Telefono1" HeaderText="Telefono"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomstsContacto" SortExpression="NomstsContacto" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" SortExpression="NroOrden" HeaderText="Orden">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesTipoContacto" SortExpression="DesTipoContacto" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
