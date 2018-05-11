<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabBanco.aspx.vb" Inherits="TabBanco" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 464px; POSITION: absolute; TOP: 8px; HEIGHT: 120px"
				cellSpacing="0" cellPadding="0" width="464" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Banco</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 462px; HEIGHT: 82px" cellSpacing="0" cellPadding="0"
							width="462" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 64px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="3"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ControlToValidate="txtCodigo" ErrorMessage="Dato Obligatorio"
										ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Nombre</TD>
								<TD>
									<asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ControlToValidate="txtNombre"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 23px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="448px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgBanco" runat="server" Width="460px"  Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodBanco" SortExpression="CodBanco" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomBanco" SortExpression="NomBanco" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="stsBanco" SortExpression="stsBanco" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:ButtonColumn Text="Cuentas" CommandName="Edit"></asp:ButtonColumn>
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
