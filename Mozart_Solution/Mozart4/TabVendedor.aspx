<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabVendedor.aspx.vb" Inherits="TabVendedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 744px; POSITION: absolute; TOP: 8px; HEIGHT: 451px"
				cellSpacing="0" cellPadding="1" width="744" border="0" class="form">
				<TR>
					<TD class="titulo" style="WIDTH: 467px">&nbsp;Vendedor</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 600px; HEIGHT: 304px" cellSpacing="0" cellPadding="0"
							width="600" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 173px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" Width="198px" MaxLength="15"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtCodigo"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px">&nbsp;Nombre</TD>
								<TD>
									<asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 28px">&nbsp;E-mail</TD>
								<TD style="HEIGHT: 28px">
									<asp:textbox id="txtEmail" runat="server" Width="289px" MaxLength="50"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtEmail"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 19px">&nbsp;Telefono</TD>
								<TD style="HEIGHT: 19px">
									<asp:textbox id="txttfemergencia" runat="server" Width="198px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 20px">&nbsp;Area</TD>
								<TD style="HEIGHT: 20px">
									<asp:dropdownlist id="ddlArea" runat="server" Width="288px" DataValueField="CodArea" DataTextField="NomArea"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 20px">&nbsp;Cargo Español</TD>
								<TD style="HEIGHT: 20px">
									<asp:textbox id="txtCargoEsp" runat="server" MaxLength="50" Width="288px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 20px">&nbsp;Cargo Ingles</TD>
								<TD style="HEIGHT: 20px">
									<asp:textbox id="txtCargoIng" runat="server" MaxLength="50" Width="288px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 18px">&nbsp;Orden Staff Penta</TD>
								<TD style="HEIGHT: 18px">
									<asp:textbox id="txtNroOrdenStaff" runat="server" MaxLength="1" Width="32px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									1=Vendedor&nbsp;&nbsp;&nbsp; 2=Supervidor&nbsp;&nbsp;&nbsp; 3=Coordinardor</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 14px">&nbsp;Supervisor</TD>
								<TD style="HEIGHT: 14px">
									<asp:dropdownlist id="ddlSupervisor" runat="server" Width="288px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 17px">
									&nbsp;Coordinador</TD>
								<TD style="HEIGHT: 17px">
									<asp:dropdownlist id="ddlCoordinador" runat="server" Width="288px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 18px">&nbsp;Responsable Operaciones</TD>
								<TD style="HEIGHT: 18px">
									<asp:dropdownlist id="ddlVendedor" runat="server" Width="288px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 20px">Blog del Vendedor</TD>
								<TD style="HEIGHT: 20px">
									<asp:textbox id="txtBlogVendedor" runat="server" MaxLength="50" Width="288px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 20px">&nbsp;Estado</TD>
								<TD style="HEIGHT: 20px">
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="311px" Height="17px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgVendedor" runat="server" Width="752px"  Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="tfemergencia" SortExpression="tfemergencia" HeaderText="Telefono"></asp:BoundColumn>
								<asp:BoundColumn DataField="stsVendedor" SortExpression="stsVendedor" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodArea" SortExpression="CodArea" HeaderText="Area"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedorOpe" SortExpression="CodVendedorOpe" HeaderText="Responsable Operaciones">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroOrdenStaff" SortExpression="NroOrdenStaff" HeaderText="N&#176; Staff">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CargoEsp" SortExpression="CargoEsp" HeaderText="Cargo Espa&#241;ol"></asp:BoundColumn>
								<asp:BoundColumn DataField="CargoIng" SortExpression="CargoIng" HeaderText="Cargo Ingles"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedorAlt1" SortExpression="CodVendedorAlt1" HeaderText="Supervisor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedorAlt2" SortExpression="CodVendedorAlt2" HeaderText="Coordinador"></asp:BoundColumn>
								<asp:BoundColumn DataField="BlogVendedor" SortExpression="CodVendedorAlt2" HeaderText="Blog"></asp:BoundColumn>
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
