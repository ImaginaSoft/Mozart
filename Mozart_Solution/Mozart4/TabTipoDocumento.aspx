<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabTipoDocumento.aspx.vb" Inherits="TabTipoDocumento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Tipo Documento</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 553px; HEIGHT: 188px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="553" bgColor="#cccccc" border="1">
							<TR>
								<TD style="WIDTH: 133px">Tipo Sistema</TD>
								<TD><asp:dropdownlist id="ddlTipoSistema" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Tipo Documento</TD>
								<TD><asp:textbox id="txtTipoDocuemnto" runat="server" MaxLength="2" Width="44px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtTipoDocuemnto" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Descripción</TD>
								<TD><asp:textbox id="txtNomDocumento" runat="server" MaxLength="50" Width="289px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtNomDocumento" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Tipo Operación</TD>
								<TD><asp:radiobutton id="rbCargo" runat="server" Checked="True" GroupName="Grupo2" Text="Cargo"></asp:radiobutton><asp:radiobutton id="rbAbono" runat="server" GroupName="Grupo2" Text="Abono"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Afecta Bancos</TD>
								<TD><asp:radiobutton id="rbsi" runat="server" Checked="True" GroupName="Grupo3" Text="Si"></asp:radiobutton><asp:radiobutton id="rbno" runat="server" GroupName="Grupo3" Text="No"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 23px">Tipo Doc. Sunat</TD>
								<TD style="HEIGHT: 23px"><asp:radiobutton id="TipoDocSunatSI" runat="server" Checked="True" GroupName="Grupo4" Text="Si"></asp:radiobutton><asp:radiobutton id="TipoDocSunatNO" runat="server" GroupName="Grupo4" Text="No"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 28px">Código Sunat</TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="txtDocSunat" runat="server" MaxLength="2" Width="40px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Comisión TC</TD>
								<TD><asp:radiobutton id="rbtComiSI" runat="server" GroupName="Grupo5" Text="Si"></asp:radiobutton><asp:radiobutton id="rbtComiNO" runat="server" Checked="True" GroupName="Grupo5" Text="No"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px">Código Proveedor TC</TD>
								<TD><asp:textbox id="txtCodProveedorTC" runat="server" MaxLength="10" Width="80px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="400px" CssClass="error" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgTipoDocumento" runat="server" Width="850px" CssClass="Grid" Height="17px"
							AllowSorting="True" AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px"
							CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="TipoSistema" SortExpression="TipoSistema" HeaderText="Tipo Sistema">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" SortExpression="TipoDocumento" HeaderText="Tipo Doc">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomDocumento" SortExpression="NomDocumento" HeaderText="Descripci&#243;n">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" SortExpression="TipoOperacion" HeaderText="Tipo Operacion">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AfectaCaja" SortExpression="AfectaCaja" HeaderText="Bancos">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsTipoDocumento" SortExpression="StsTipoDocumento" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocSunat" SortExpression="TipoDocSunat" HeaderText="Tipo Sunat">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DocSunat" SortExpression="DocSunat" HeaderText="Cod Sunat">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagComisionTC" SortExpression="FlagComisionTC" HeaderText="Comision TC">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedorTC" SortExpression="CodProveedorTC" HeaderText="C&#243;digo Proveedor TC">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
