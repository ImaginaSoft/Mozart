<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabManCiudad.aspx.vb" Inherits="tabManCiudad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 448px; POSITION: absolute; TOP: 8px; HEIGHT: 187px"
				cellSpacing="0" cellPadding="1" width="448" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">Ciudad</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="Tabla" id="Table1" style="WIDTH: 488px; HEIGHT: 24px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="488" border="1">
							<TR>
								<TD style="WIDTH: 9px"><FONT size="2"><asp:label id="lblCodigo" runat="server">Código</asp:label></FONT></TD>
								<TD style="WIDTH: 214px"><FONT size="2"><asp:textbox id="txtCodigo" runat="server" MaxLength="20" Width="73px"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " CssClass="error" ErrorMessage="obligatorio"
											ControlToValidate="txtCodigo"></asp:requiredfieldvalidator></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 9px; HEIGHT: 24px"><asp:label id="lblNombre" runat="server">Nombre</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 24px"><asp:textbox id="txtNombre" runat="server" MaxLength="50" Width="291px"></asp:textbox><asp:requiredfieldvalidator id="rfvNombre" runat="server" ForeColor=" " CssClass="error" ErrorMessage="obligatorio"
										ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 9px; HEIGHT: 24px"><asp:label id="lblstsCiudad" runat="server">Estado</asp:label></TD>
								<TD style="WIDTH: 214px; HEIGHT: 24px"><asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="311px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgCiudad" runat="server" Width="403px" CssClass="Grid" Height="25px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCiudad" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
