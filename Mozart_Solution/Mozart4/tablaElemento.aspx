<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tablaElemento.aspx.vb" Inherits="tablaElemento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 804px; POSITION: absolute; TOP: 8px; HEIGHT: 88px"
				cellSpacing="0" cellPadding="1" width="804" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<TABLE class="tabla" id="Table2" style="WIDTH: 792px; HEIGHT: 112px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="792" border="1">
							<TR>
								<TD style="WIDTH: 118px"><FONT size="2">&nbsp;Codigo</FONT></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" MaxLength="3" Width="56px"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 24px">&nbsp;Nombre español</TD>
								<TD style="HEIGHT: 24px">
									<asp:textbox id="txtNomEleEsp" runat="server" MaxLength="50" Width="560px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 3px">&nbsp;Nombre ingles</TD>
								<TD style="HEIGHT: 3px">
									<asp:textbox id="txtNomEleIng" runat="server" MaxLength="50" Width="560px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px; HEIGHT: 11px">&nbsp;Orden</TD>
								<TD style="HEIGHT: 11px">
									<asp:textbox id="txtNroOrden" runat="server" MaxLength="3" Width="48px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 118px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="528px" Height="17px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dglista" runat="server" Width="800px" Height="17px" CssClass="Grid"  
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodElemento" SortExpression="CodElemento" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomEleEsp" SortExpression="NomEleEsp" HeaderText="Nombre Espa&#241;ol"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomEleIng" SortExpression="NomEleIng" HeaderText="Nombre Ingles">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" SortExpression="NroOrden" HeaderText="Orden">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="estado" SortExpression="estado" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="fchsys" SortExpression="fchsys" HeaderText="Actualizado"></asp:BoundColumn>
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
