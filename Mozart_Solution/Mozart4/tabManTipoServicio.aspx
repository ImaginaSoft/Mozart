<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabManTipoServicio.aspx.vb" Inherits="tabManTipoServicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">Tipo Servicio</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 536px; HEIGHT: 78px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="536" border="1">
							<TR>
								<TD style="WIDTH: 46px">
									<asp:label id="lblCodigo" runat="server" Width="72px">Código</asp:label></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="1"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtCodigo"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px">
									<asp:label id="TipoSevicio" runat="server" Width="96px">Tipo de Servicio</asp:label></TD>
								<TD>
									<asp:textbox id="txtNombre" runat="server" Width="264px" MaxLength="50"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvNombre" runat="server" Width="88px" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 46px">
									<asp:label id="lblsts" runat="server" Width="80px">Estado</asp:label></TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:Button>&nbsp;<asp:label id="lblMsg" runat="server" Height="17px" Width="311px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblError" runat="server" Height="17px" Width="149px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dgTipoServicio" runat="server" Height="25px" Width="568px" AutoGenerateColumns="False"
							BorderWidth="1px" CellPadding="2" CssClass="Grid" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTipoServicio" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoServicio" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="Cancelar" EditText="Tipos Acomodaci&#243;n">
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
