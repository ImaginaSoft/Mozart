<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaFicha.aspx.vb" Inherits="VtaPlantillaFicha" %>

<%@ Register src="ucPlantilla.ascx" tagname="ucPlantilla" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 601px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="601" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Ficha de la Plantilla</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">
						<TABLE class="tabla" id="Table4" style="WIDTH: 540px; HEIGHT: 8px" cellSpacing="0" cellPadding="0"
							width="540" border="0">
							<TR>
								<TD style="WIDTH: 173px; HEIGHT: 23px">
									<asp:linkbutton id="lbtServicio" runat="server">• Servicios</asp:linkbutton></TD>
								<TD style="HEIGHT: 23px">
									<asp:linkbutton id="lbtModificar" runat="server">• Modificar plantilla</asp:linkbutton></TD>
								<TD style="HEIGHT: 23px">
									<asp:linkbutton id="lbtNuevaPlantilla" runat="server" Width="109px">• Nueva Plantilla</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 173px">
									<asp:linkbutton id="lbtLink" runat="server">• Link</asp:linkbutton></TD>
								<TD>
									<asp:linkbutton id="lbtDias" runat="server" Width="104px">• Modificar Dias</asp:linkbutton></TD>
								<TD>
									<asp:linkbutton id="lbtEliminar" runat="server">• Eliminar Plantilla</asp:linkbutton></TD>
							</TR>
							<TR> <TD> <asp:LinkButton id="lbtImg" runat="server">• Cargar imagenes </asp:LinkButton></TD></TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucPlantilla ID="ucPlantilla1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" CssClass="msg" Width="593px" Height="21px"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgServicio" runat="server" CellPadding="2" BorderWidth="2px" BorderColor="CadetBlue"
							CssClass="Grid" AutoGenerateColumns="False" BorderStyle="None" Width="800px" Height="27px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="Ord">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Acomodaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsServicio" HeaderText="Estado"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
