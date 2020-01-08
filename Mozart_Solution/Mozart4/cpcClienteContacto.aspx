<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcClienteContacto.aspx.vb" Inherits="cpcClienteContacto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 724px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
				cellSpacing="0" cellPadding="1" width="724" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">
						<asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 6px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 400px; HEIGHT: 168px" cellSpacing="0" cellPadding="0"
							width="400" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 72px"><FONT size="2">Código</FONT></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" MaxLength="15" Width="198px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px">Nombre</TD>
								<TD>
									<asp:textbox id="txtNombre" runat="server" MaxLength="50" Width="289px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 28px">E-mail</TD>
								<TD style="HEIGHT: 28px">
									<asp:textbox id="txtEmail" runat="server" MaxLength="50" Width="289px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 19px">Telefono</TD>
								<TD style="HEIGHT: 19px">
									<asp:textbox id="txtTelefono" runat="server" Width="200px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 20px">Experto</TD>
								<TD style="HEIGHT: 20px">
									<asp:CheckBox id="CheckBoxFlagExperto" runat="server" Text="Personaliza propuestas  en Peru4all"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 2px">Orden</TD>
								<TD style="HEIGHT: 2px">
									<asp:textbox id="txtNroOrden" runat="server" MaxLength="2" Width="32px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 20px">Estado</TD>
								<TD style="HEIGHT: 20px">
									<asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:Label id="lblMsg" runat="server" CssClass="msg"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgLista" runat="server" AllowSorting="True" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" Height="17px"  
							Width="720px">
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
								<asp:BoundColumn DataField="Experto" SortExpression="Experto" HeaderText="Experto">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" SortExpression="NroOrden" HeaderText="Orden">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomstsContacto" SortExpression="NomstsContacto" HeaderText="Estado">
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
