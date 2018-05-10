<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segUsuarioFicha.aspx.vb" Inherits="segUsuarioFicha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 18px;
            width: 133px;
        }
        .style2
        {
            height: 17px;
            width: 133px;
        }
        .style3
        {
            height: 19px;
            width: 133px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 439px; POSITION: absolute; TOP: 8px; HEIGHT: 8px"
				cellSpacing="0" cellPadding="0" width="439" border="0" class="form">
				<TR>
					<TD class="Titulo" style="HEIGHT: 23px">
						Ficha&nbsp;de Usuario</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px">
						<TABLE class="opciones" id="Table4" style="WIDTH: 438px; HEIGHT: 16px" cellSpacing="1"
							cellPadding="1" width="438" border="0">
							<TR>
								<TD style="WIDTH: 138px; HEIGHT: 20px">
									<asp:linkbutton id="lbtNuevo" runat="server" Width="114px">• Nuevo Usuario</asp:linkbutton></TD>
								<TD style="WIDTH: 137px; HEIGHT: 20px">
									<asp:linkbutton id="lbtModificar" runat="server" Width="129px">• Modificar Usuario</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 20px" align="left">
									<asp:linkbutton id="lbtEliminar" runat="server" Width="139px">• Eliminar  Usuario</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 138px; HEIGHT: 5px">
									<asp:linkbutton id="lbtCambiarClave" runat="server" Width="102px">• Cambiar Clave</asp:linkbutton></TD>
								<TD style="WIDTH: 137px; HEIGHT: 5px">
									<asp:linkbutton id="lbtAsignarZonaVta" runat="server" Width="142px">• Asignar Zona Venta</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 5px" align="left"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 438px; HEIGHT: 38px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="438" border="1">
							<TR>
								<TD class="style1">
									Codigo</TD>
								<TD class="Dato" style="HEIGHT: 18px">&nbsp;
									<asp:label id="lblCodigoUsuario" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Nombre</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblNombreUsuario" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Perfil</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblCodPerfil" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style3">Estado</TD>
								<TD class="Dato" style="HEIGHT: 19px">&nbsp;
									<asp:label id="lblEstado" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Default Idioma Pedido</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblTipoIdioma" runat="server" BorderStyle="None"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Consulta log acceso</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblLogAcceso" runat="server" BorderStyle="None"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Consulta Ventas</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblVtaAcceso" runat="server" BorderStyle="None"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style1">Acceso a Mozart</TD>
								<TD class="Dato" style="HEIGHT: 18px">&nbsp;
									<asp:label id="lblModoTrabajo" runat="server" BorderStyle="None"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Actualizado</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblActualiza" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="style2">Usuario</TD>
								<TD class="Dato" style="HEIGHT: 17px">&nbsp;
									<asp:label id="lblUsuario" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:datagrid id="dgTabla" runat="server" Width="440px" CssClass="Grid" AllowSorting="True" CellPadding="3"
							BorderWidth="1px" BorderStyle="None" Font-Names="Verdana" BackColor="White" BorderColor="#CCCCCC"
							AutoGenerateColumns="False" Font-Size="8pt">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CodZonaVta" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomZonaVta" HeaderText="Zona de Venta"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuarioSys" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="368px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
