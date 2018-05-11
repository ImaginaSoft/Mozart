<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaFicha.aspx.vb" Inherits="VtaPropuestaFicha" %>

<%@ Register src="ucPropuesta.ascx" tagname="ucPropuesta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 610px; POSITION: absolute; TOP: 8px; HEIGHT: 64px"
				cellSpacing="0" cellPadding="1" width="610" border="0">
				<TR>
					<TD style="HEIGHT: 21px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
                        <uc1:ucPropuesta ID="ucPropuesta1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 1px">
						<TABLE class="opciones" id="Table4" style="WIDTH: 704px; HEIGHT: 97px" cellSpacing="0"
							cellPadding="0" width="704" border="0">
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 17px"><asp:linkbutton id="lbtServicio" runat="server">• Servicios</asp:linkbutton></TD>
								<TD style="WIDTH: 151px; HEIGHT: 17px"><asp:linkbutton id="lbtPublica" runat="server">• Publica Propuesta</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtPaginaPublicada" runat="server" Width="153px">• Ver pagina publicada</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtHistProveedor" runat="server" Width="124px">• Historial Proveedor</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtPlantilla" runat="server" Width="112px" Visible="False">• Generar Plantilla</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 17px"><asp:linkbutton id="lbtValorizacion" runat="server" Width="96px">• Precios</asp:linkbutton></TD>
								<TD style="WIDTH: 151px; HEIGHT: 17px"><asp:linkbutton id="lbtModificar" runat="server">• Modificar Propuesta</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtRevisarVersion" runat="server" Width="123px">• Revisar Versiones</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtHistorial" runat="server">• Historial Pedido</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 15px"><asp:linkbutton id="lbtResumen" runat="server">• Resumen</asp:linkbutton></TD>
								<TD style="WIDTH: 151px; HEIGHT: 15px"><asp:linkbutton id="lbtEliminar" runat="server">• Eliminar Propuesta</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtGenerarVersion" runat="server" Width="147px">• Generar Nueva Versión</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtTareas" runat="server">• Tareas</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 16px"><asp:linkbutton id="lbtCambiarHotel" runat="server" Width="104px">• Cambiar Hotel</asp:linkbutton></TD>
								<TD style="WIDTH: 151px; HEIGHT: 16px"><asp:linkbutton id="lbkLimpiaResumen" runat="server" Width="147px">• Limpia Resumen</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtLink" runat="server" Width="104px">• Modificar Link</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtEnviaEmail" runat="server">• Envia E-mail</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px; HEIGHT: 16px"><asp:linkbutton id="lbtDias" runat="server" Width="104px">• Modificar Dias</asp:linkbutton></TD>
								<TD style="WIDTH: 151px; HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px">
									<asp:linkbutton id="lbtEspecificacion" runat="server" Width="112px">• Especificaciones</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtReserva" runat="server" Width="120px">• Reserva Servicios</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 111px"></TD>
								<TD style="WIDTH: 151px"></TD>
								<TD colspan="3"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"><asp:label id="lblMsg" runat="server" Width="533px" 
                            CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"><asp:datagrid id="dgServicio" runat="server" Width="800px" CssClass="Grid" Height="20px" BorderColor="CadetBlue"
							BorderStyle="None" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="N&#176;">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###.00} ">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###.00} ">
									<ItemStyle HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" HeaderText="Uti" DataFormatString="{0:###,###.00} ">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioNeto" HeaderText="Neto" DataFormatString="{0:###,###.##} ">
									<ItemStyle HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesCantidad" HeaderText="Cantidad"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsReserva" HeaderText="Reserva">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HotelAlternativo" HeaderText="Alternativo">
									<ItemStyle BackColor="#CCFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagPrecio" HeaderText="FlagPrecio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
