<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabTipoInformacionDet.aspx.vb" Inherits="tabTipoInformacionDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 744px; POSITION: absolute; TOP: 8px; HEIGHT: 375px"
				cellSpacing="0" cellPadding="1" width="744" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 792px; HEIGHT: 208px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="792" border="1">
							<TR>
								<TD style="WIDTH: 118px"><FONT size="2">&nbsp;Nro Item</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="56px" MaxLength="3"></asp:textbox>&nbsp;( 
									dato en blanco adiciona nuevo registro)&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px">&nbsp;Nombre Español</TD>
								<TD><asp:textbox id="txtNombreEsp" runat="server" Width="560px" MaxLength="50" TextMode="MultiLine"
										Height="80px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ControlToValidate="txtNombreEsp"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 17px">&nbsp;Nombre Ingles</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtNombreIng" runat="server" Width="560px" MaxLength="50" TextMode="MultiLine"
										Height="80px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" ControlToValidate="txtNombreIng"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 17px">Nombre Portugués</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtNombrePor" runat="server" 
                                        Width="560px" MaxLength="50" TextMode="MultiLine"
										Height="80px"></asp:textbox>
                                    <asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" 
                                        CssClass="error" ControlToValidate="txtNombrePor"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 22px">&nbsp;Aplica a nivel de
								</TD>
								<TD style="HEIGHT: 22px"><asp:radiobutton id="rbZonaVta" runat="server" Text="Zona Venta" GroupName="Grupo2" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbCiudad" runat="server" Text="Ciudad" GroupName="Grupo2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbServicio" runat="server" Text="Nro Servicio" GroupName="Grupo2"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 17px">&nbsp;Orden</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtNroOrden" runat="server" Width="48px" MaxLength="3"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" CssClass="error" ControlToValidate="txtNroOrden"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px">&nbsp;Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="528px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD ><asp:datagrid id="dglista" runat="server" Width="900px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroInformacion" SortExpression="NroInformacion" HeaderText="Nro">
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomInfEsp" SortExpression="NomInfEsp" HeaderText="Nombre Espa&#241;ol">
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomInfIng" SortExpression="NomInfIng" HeaderText="Nombre Ingles"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nivel" SortExpression="Nivel" HeaderText="Nivel"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" SortExpression="NroOrden" HeaderText="Orden">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="estado" SortExpression="estado" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomInfPor" SortExpression="NomInfPor" HeaderText="NombreInformacionEnPortugués"></asp:BoundColumn>
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
