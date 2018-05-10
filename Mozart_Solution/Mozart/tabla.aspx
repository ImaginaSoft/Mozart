<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabla.aspx.vb" Inherits="tabla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 752px; POSITION: absolute; TOP: 8px; HEIGHT: 306px"
				cellSpacing="0" cellPadding="1" width="752" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">
						Tablas del Sistema</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 760px; HEIGHT: 25px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="760" border="1">
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 27px">Codigo</TD>
								<TD style="HEIGHT: 27px"><asp:textbox id="txtCodigo" runat="server" MaxLength="2" Width="40px"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Dato obligatorio"
										ForeColor=" " CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px; HEIGHT: 27px">Nombre</TD>
								<TD style="HEIGHT: 27px"><asp:textbox id="txtNombreEsp" runat="server" MaxLength="50" Width="472px"></asp:textbox><asp:requiredfieldvalidator id="rfvNombre" runat="server" Width="104px" ControlToValidate="txtNombreEsp" ErrorMessage="Dato obligatorio"
										ForeColor=" " CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px">Tamaño CodElemento</TD>
								<TD>
									<asp:textbox id="txtCodEleLong" runat="server" Width="40px" MaxLength="2"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 140px">Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;<asp:label id="lblMsg" runat="server" Width="311px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblError" runat="server" Width="149px" CssClass="error" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgLista" runat="server" Width="760px" CssClass="Grid" Height="25px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="codtabla" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomTabla" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodEleLong" HeaderText="Tama&#241;o C&#243;dElemento">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="codUsuario" HeaderText="Usuario">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="Cancelar" EditText="Detalle">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
