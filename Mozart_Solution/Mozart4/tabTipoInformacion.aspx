<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabTipoInformacion.aspx.vb" Inherits="tabTipoInformacion" %>

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
					<TD class="Titulo" style="WIDTH: 467px">Tipo de Información</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 760px; HEIGHT: 129px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="760" border="1">
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 27px">Numero</TD>
								<TD style="HEIGHT: 27px"><asp:textbox id="txtCodigo" runat="server" Width="40px" MaxLength="2"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtCodigo"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 16px">Tipo en Español</TD>
								<TD style="HEIGHT: 16px"><asp:textbox id="txtNombreEsp" runat="server" Width="472px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="rfvNombre" runat="server" Width="104px" CssClass="error" ForeColor=" " ErrorMessage="Dato obligatorio"
										ControlToValidate="txtNombreEsp"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Tipo en Ingles</TD>
								<TD><asp:textbox id="txtNombreIng" runat="server" Width="472px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="104px" CssClass="error" ForeColor=" "
										ErrorMessage="Dato obligatorio" ControlToValidate="txtNombreIng"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Tipo en Portugués</TD>
								<TD><asp:textbox id="txtNombrePor" runat="server" Width="472px" MaxLength="50"></asp:textbox>
                                    <asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                        Width="104px" CssClass="error" ForeColor=" "
										ErrorMessage="Dato obligatorio" ControlToValidate="txtNombrePor"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px">Orden</TD>
								<TD><asp:textbox id="txtNroOrden" runat="server" Width="40px" MaxLength="1"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Width="128px" CssClass="error" ForeColor=" "
										ErrorMessage="Dato obligatorio" ControlToValidate="txtNroOrden"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px"></TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
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
					<TD style="WIDTH: 467px"><asp:datagrid id="dgTipoInformacion" runat="server" Width="800px" CssClass="Grid" Height="25px"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroTipoInf" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomTipoInfEsp" HeaderText="Tipo en Espa&#241;ol"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomTipoInfIng" HeaderText="Tipo en Ingles"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="Orden">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="Cancelar" EditText="Detalle">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomTipoInfPor" HeaderText="Tipo en Portugués"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
