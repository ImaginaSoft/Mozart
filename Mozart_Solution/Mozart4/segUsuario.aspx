<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segUsuario.aspx.vb" Inherits="segUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE class="form" id="Table1" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 642px; POSITION: absolute; TOP: 8px; HEIGHT: 213px"
					cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD class="Titulo" style="HEIGHT: 18px">Usuarios del Sistema</TD>
					</TR>
					<TR>
						<TD class="opciones" style="HEIGHT: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lbtNuevo" runat="server" Width="98px">Nuevo Usuario</asp:linkbutton></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px">
							<asp:label id="lblMsg" runat="server" Width="304px" CssClass="msg"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgTabla" runat="server" Width="640px" CssClass="Grid" DataKeyField="CodUsuario"
								AllowSorting="True" CellPadding="3" BorderWidth="1px" BorderStyle="None" Font-Names="Verdana"
								BackColor="White" BorderColor="#CCCCCC" AutoGenerateColumns="False" >
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="C&#243;digo"></asp:BoundColumn>
									<asp:BoundColumn DataField="NomUsuario" SortExpression="NomUsuario" HeaderText="Nombre "></asp:BoundColumn>
									<asp:BoundColumn DataField="StsUsuario" SortExpression="StsUsuario" HeaderText="Estado"></asp:BoundColumn>
									<asp:BoundColumn DataField="CodPerfil" SortExpression="CodPerfil" HeaderText="Perfil"></asp:BoundColumn>
									<asp:BoundColumn DataField="CodUsuarioSys" SortExpression="CodUsuarioSys" HeaderText="Usuario"></asp:BoundColumn>
									<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
				</TABLE>
			</P>
			<P></P>
		</form>
</body>
</html>
