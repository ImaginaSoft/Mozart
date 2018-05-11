<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionCambiarStatus.aspx.vb" Inherits="VtaVersionCambiarStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 705px; POSITION: absolute; TOP: 8px; HEIGHT: 224px"
				cellSpacing="0" cellPadding="0" width="705" border="0">
				<TR>
					<TD style="HEIGHT: 17px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="Opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaVersion" runat="server" Width="112px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<TABLE class="form" id="Table2" style="WIDTH: 640px; HEIGHT: 76px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="640" border="1">
							<TR>
								<TD style="WIDTH: 153px; HEIGHT: 34px">&nbsp;Proveedor</TD>
								<TD style="HEIGHT: 34px">
									<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="300" border="0">
										<TR>
											<TD><asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="399px" AutoPostBack="True"
													DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="lblReserva" runat="server" CssClass="error"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 153px; HEIGHT: 30px">&nbsp;Nuevo estado del servicio</TD>
								<TD style="HEIGHT: 30px"><asp:dropdownlist id="ddlStsReserva" runat="server" Width="224px" DataValueField="CodStsReserva" DataTextField="StsReserva"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px">
						<TABLE class="form" id="Table1" style="WIDTH: 704px; HEIGHT: 88px" cellSpacing="0" cellPadding="0"
							width="704" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 185px; HEIGHT: 24px">Actualiza el nuevo estado del servicio en 
									las filas seleccionadas.</TD>
								<TD style="WIDTH: 244px; HEIGHT: 24px">Todos los servicios cambia al estado OK y la 
									version pasa a lista de pedidos contratados con el Proveedor</TD>
								<TD style="HEIGHT: 24px">Todos los servicios cambia al estado Anulado y la versión 
									se retira de la lista de pedidos pendientes de atención&nbsp;por Proveedor.</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 185px; HEIGHT: 24px"><asp:button id="cmdGrabar" runat="server" Width="160px" Text="Aplicar nuevo estado "></asp:button></TD>
								<TD style="WIDTH: 244px; HEIGHT: 24px"><asp:button id="cmdPedidosContratados" runat="server" Width="184px" Text="Confirmar Reserva x Proveedor"
										Height="26px"></asp:button></TD>
								<TD style="HEIGHT: 24px"><asp:button id="cmdPedidosAnulados" runat="server" Width="168px" Text="Anular Reserva x Proveedor"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:label id="lblNroFile" runat="server" Visible="False"></asp:label><asp:label id="lblCodSolicita" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px">&nbsp;
						<asp:label id="lblMsg" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px"><asp:GridView id="dgServicio" runat="server" Width="800px" Height="24px" CssClass="Grid" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:BoundField DataField="NroDia" HeaderText="Día">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundField>
								<asp:BoundField DataField="DesProveedor" HeaderText="Servicio"></asp:BoundField>
								<asp:BoundField DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundField>
								<asp:BoundField DataField="CodStsReserva" HeaderText="Reserva"></asp:BoundField>
								<asp:BoundField DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundField>
								<asp:BoundField DataField="CodUsuario" HeaderText="Usuario"></asp:BoundField>
								<asp:BoundField DataField="FchSys" HeaderText="Actualizado"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</form>
</body>
</html>
