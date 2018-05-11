<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioPlantilla.aspx.vb" Inherits="VtaServicioPlantilla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" style="COLOR: #ffffff" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="600" border="0">
				<TR>
					<TD style="HEIGHT: 20px">
						<P class="Titulo">&nbsp;Lista Servicios</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lbtPlantilla" runat="server">Reemplazar Servicio en Plantillas</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 76px">
						<TABLE class="Tabla" id="Table1" style="WIDTH: 461px; HEIGHT: 16px" cellSpacing="0" cellPadding="0"
							width="461" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 109px">&nbsp; Proveedor</TD>
								<TD>
									<asp:dropdownlist id="ddlProveedor" runat="server" Width="332px" DataTextField="NomProveedor" DataValueField="CodProveedor"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 109px">&nbsp; Ciudad</TD>
								<TD>
									<asp:dropdownlist id="ddlCiudad" runat="server" Width="332px" DataTextField="NomCiudad" DataValueField="CodCiudad"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 109px">&nbsp; Tipo Servicio</TD>
								<TD>
									<P>
										<asp:dropdownlist id="ddltiposervicio" runat="server" Width="331px" DataTextField="TipoServicio" DataValueField="CodTipoServicio"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 109px"></TD>
								<TD>
									<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="477px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P>
							<asp:datagrid id="dgServicio" runat="server" Width="606px" Height="25px" DataKeyField="NroServicio"
								AutoGenerateColumns="False" AllowSorting="True" BorderColor="CadetBlue" BorderWidth="1px"
								CellPadding="2" CssClass="Grid">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Plantillas" HeaderText="Editar" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="NroServicio" HeaderText="Nro ">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
									<asp:BoundColumn DataField="TipoServicio" HeaderText="Tipo"></asp:BoundColumn>
									<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
									<asp:BoundColumn DataField="NomStsServicio" HeaderText="Estado"></asp:BoundColumn>
									<asp:BoundColumn DataField="NroVeces" HeaderText="NroVeces">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<P>
			</P>
		</form>

</body>
</html>
