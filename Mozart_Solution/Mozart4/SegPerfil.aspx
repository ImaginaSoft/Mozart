<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SegPerfil.aspx.vb" Inherits="SegPerfil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE class="TABLA" id="Table1" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 472px; POSITION: absolute; TOP: 8px; HEIGHT: 213px"
					cellSpacing="0" cellPadding="0" width="472" border="0">
					<TR>
						<TD class="Titulo" style="HEIGHT: 18px">&nbsp;Perfiles de Usuario</TD>
					</TR>
					<TR>
						<TD class="opciones" style="HEIGHT: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lbtNuevo" runat="server" Width="98px">Nuevo Perfil</asp:linkbutton></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px"><asp:label id="lblMsg" runat="server" Width="304px" 
                                CssClass="msg"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgTabla" runat="server" Width="544px" CssClass="Grid" DataKeyField="CodPerfil"
								AllowSorting="True" CellPadding="3" BorderWidth="1px" BorderStyle="None" Font-Names="Verdana"
								BackColor="White" BorderColor="#999999" AutoGenerateColumns="False" Font-Size="8pt">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="CodPerfil" SortExpression="CodPerfil" HeaderText="C&#243;digo"></asp:BoundColumn>
									<asp:BoundColumn DataField="NomPerfil" SortExpression="NomPerfil" HeaderText="Nombre de Perfil"></asp:BoundColumn>
									<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario Reg."></asp:BoundColumn>
									<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Fecha Reg."></asp:BoundColumn>
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
