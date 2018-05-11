<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segPerfilFicha.aspx.vb" Inherits="segPerfilFicha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body">
		<form id="Form1" method="post" runat="server">
			<TABLE class="FORM" id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 439px; POSITION: absolute; TOP: 8px; HEIGHT: 8px"
				cellSpacing="0" cellPadding="0" width="439" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 23px">Ficha&nbsp;del Perfil de Usuario</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px">
						<TABLE class="opciones" id="Table4" style="WIDTH: 438px; HEIGHT: 16px" cellSpacing="1"
							cellPadding="1" width="438" border="0">
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 20px"><asp:linkbutton id="lbtNuevo" runat="server" Width="114px">• Nuevo Perfil</asp:linkbutton></TD>
								<TD style="WIDTH: 137px; HEIGHT: 20px"><asp:linkbutton id="lbtModificar" runat="server" Width="129px">• Modificar Perfil</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 20px" align="left"><asp:linkbutton id="lbtEliminar" runat="server" Width="139px">• Eliminar  Perfil</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 5px"><asp:linkbutton id="lbtOpciones" runat="server" Width="112px">• Ver Opciones</asp:linkbutton></TD>
								<TD style="WIDTH: 137px; HEIGHT: 5px"><asp:linkbutton id="lbtRestriccion" runat="server" Width="112px">• Restricciones</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 5px" align="left"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px">
						<asp:Label id="lblMsg" runat="server" CssClass="error"></asp:Label>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 438px; HEIGHT: 38px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="438" border="1">
							<TR>
								<TD style="WIDTH: 123px; HEIGHT: 18px">Codigo</TD>
								<TD class="Dato" style="HEIGHT: 18px">&nbsp;
									<asp:label id="lblCodPerfil" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px; HEIGHT: 17px">Nombre</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblNomPerfil" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px; HEIGHT: 17px">Estado</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblNomStsPerfil" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px; HEIGHT: 17px">Actualizado</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblActualiza" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px; HEIGHT: 17px">Usuario</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblUsuario" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">Restricciones para el perfil de usuario: No 
						puede&nbsp;cambiar perfil de Cliente</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgTabla" runat="server" Width="440px" BorderStyle="None" Font-Size="8pt" AutoGenerateColumns="False"
							BorderColor="#CCCCCC" BackColor="White" Font-Names="Verdana" BorderWidth="1px" CellPadding="3"
							AllowSorting="True" CssClass="Grid">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomStsCaptacionActual" HeaderText="Perfil cliente actual "></asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsCaptacionNuevo" HeaderText="Nuevo perfil cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
