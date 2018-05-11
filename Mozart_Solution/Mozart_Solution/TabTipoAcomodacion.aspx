<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabTipoAcomodacion.aspx.vb" Inherits="TabTipoAcomodacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0" class="form">
				<TR>
					<TD style="WIDTH: 467px">
						<P class="Titulo">&nbsp;
							<asp:Label id="lblTitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 462px; HEIGHT: 82px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="462" border="1">
							<TR>
								<TD style="WIDTH: 64px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="5"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ControlToValidate="txtCodigo" ErrorMessage="Dato Obligatorio"
										ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Nombre</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px; HEIGHT: 17px">&nbsp;Abreviado</TD>
								<TD style="HEIGHT: 17px">
									<asp:textbox id="txtAbr" runat="server" MaxLength="50" Width="289px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px; HEIGHT: 17px">&nbsp;Orden</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtNroOrden" runat="server" Width="73px" 
                                        MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo1" Checked="True"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="528px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dglista" runat="server" Width="688px"  Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTipoAcomodacion" SortExpression="CodTipoAcomodacion" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" SortExpression="TipoAcomodacion" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AbrTipoAcomodacion" SortExpression="AbrTipoAcomodacion" HeaderText="Abreviado"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" SortExpression="NroOrden" HeaderText="Orden"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomstsTipoAcomodacion" SortExpression="NomstsTipoAcomodacion" HeaderText="Estado">
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
