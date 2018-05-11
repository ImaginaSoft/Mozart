<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabManTipoLink.aspx.vb" Inherits="tabManTipoLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 9px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 328px"
				cellSpacing="0" cellPadding="1" width="536" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">Tipo Link</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE id="Table1" style="WIDTH: 536px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="536"
							border="1" class="tabla" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 78px; HEIGHT: 26px"><FONT size="2"> Código</FONT></TD>
								<TD style="WIDTH: 214px; HEIGHT: 26px"><FONT size="2">
										<asp:textbox id="txtCodigo" runat="server" Width="42px" MaxLength="2"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvcodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="obligatorio"
											CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 78px; HEIGHT: 25px">Tipo Servicio</TD>
								<TD style="WIDTH: 214px; HEIGHT: 25px">
									<asp:textbox id="txtNombre" runat="server" Width="278px" MaxLength="50"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="obligatorio"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 78px; HEIGHT: 21px">
									Estado</TD>
								<TD style="WIDTH: 214px; HEIGHT: 21px">
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 26px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:Button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="311px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgTipoLink" runat="server" Width="403px" CssClass="Grid" Height="25px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="2px" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTipoLink" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoLink" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
