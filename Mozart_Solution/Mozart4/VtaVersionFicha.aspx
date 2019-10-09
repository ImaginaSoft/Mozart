<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionFicha.aspx.vb" Inherits="VtaVersionFicha" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 16px;
            width: 123px;
        }
        .style2
        {
            height: 17px;
            width: 123px;
        }
        .style3
        {
            height: 15px;
            width: 123px;
        }
        .style4
        {
            height: 5px;
            width: 123px;
        }
        .style5
        {
            height: 3px;
            width: 123px;
        }
        .style6
        {
            height: 2px;
            width: 123px;
        }
        .style7
        {
            width: 123px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 567px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="567" border="0">
				<TR>
					<TD style="HEIGHT: 21px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD class="opciones">
						<TABLE class="opciones" id="Table4" style="WIDTH: 726px; HEIGHT: 112px" cellSpacing="0"
							cellPadding="0" width="726" border="0">
							<TR>
								<TD class="style1"><asp:linkbutton id="lbtServicio" runat="server">• Servicios</asp:linkbutton></TD>
								<TD style="WIDTH: 154px; HEIGHT: 16px"><asp:linkbutton id="lbtPublica" runat="server">• Publica Versión</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtNotaAbono" runat="server" Width="143px">• Devolución al Cliente</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtHistProveedor" runat="server" Width="124px">• Historial Proveedor</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px">
									<asp:linkbutton id="lbtCambiarHotel" runat="server" Width="168px">• Cambiar Nombre Servicio</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style2"><asp:linkbutton id="lbtPrecio" runat="server" Width="88px">• Precios</asp:linkbutton></TD>
								<TD style="WIDTH: 154px; HEIGHT: 17px"><asp:linkbutton id="lbtPaginaPublicada" runat="server" Width="148px">• Ver Pagina Publicada(old)</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtNotaCargo" runat="server">• Mayor pago del Cliente</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtHistorial" runat="server">• Historial Pedido</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px"><asp:linkbutton id="lbtExcluirReserva" runat="server" Width="152px">• Cambiar Status Reserva</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style3"><asp:linkbutton id="lbkResumen" runat="server">• Resumen</asp:linkbutton></TD>
								<TD style="WIDTH: 154px; HEIGHT: 15px">
									<asp:linkbutton id="lbtPrintPagina" runat="server" Width="148px">• Imprimir Pagina</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtProveedorNotaCargo" runat="server" Width="154px">• Menor pago al Proveedor</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px"><asp:linkbutton id="lbtTareas" runat="server">• Tareas</asp:linkbutton></TD>
								<TD style="HEIGHT: 15px">
									<asp:linkbutton id="lbtDiaOrden" runat="server" Width="152px">• Cambiar Día - Orden</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style4"><asp:linkbutton id="lbtModificaDias" runat="server" Width="98px">• Modificar Dias</asp:linkbutton></TD>
								<TD style="WIDTH: 154px; HEIGHT: 5px"><asp:linkbutton id="lbtModificar" runat="server" Width="115px">• Modificar Versión</asp:linkbutton></TD>
								<TD style="HEIGHT: 5px"><asp:linkbutton id="lbtProveedorNotaAbono" runat="server" Width="154px">• Mayor pago al Proveedor</asp:linkbutton></TD>
								<TD style="HEIGHT: 5px"><asp:linkbutton id="lbtEnviaEmail" runat="server" Width="87px">• Envia E-mail</asp:linkbutton></TD>
								<TD style="HEIGHT: 5px">
									<asp:linkbutton id="lbtCambiarHora" runat="server" Width="152px">• Cambiar Hora Servicio</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style5"><asp:linkbutton id="lbtModificaLink" runat="server" Width="98px">• Modificar Link</asp:linkbutton></TD>
								<TD style="WIDTH: 154px; HEIGHT: 3px"><asp:linkbutton id="lbtEliminar" runat="server">• Eliminar Versión</asp:linkbutton></TD>
								<TD style="HEIGHT: 3px"><asp:linkbutton id="lbtDocAjuste" runat="server" Width="154px">• Documentos de Ajuste</asp:linkbutton></TD>
								<TD style="HEIGHT: 3px"><asp:linkbutton id="lbtReserva" runat="server" Width="114px">• Reserva Servicios</asp:linkbutton></TD>
								<TD style="HEIGHT: 3px">
									<asp:linkbutton id="lbtEspecificacion" runat="server" Width="112px">• Especificaciones</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style6"><asp:linkbutton id="lbtLink" runat="server" Width="117px" 
                                        Height="17px">• Sts Reserva Hotel</asp:linkbutton></TD>
<%--								<TD style="WIDTH: 154px; HEIGHT: 17px"><asp:linkbutton id="lbtPaginaPublicadaNew" runat="server" Width="148px">• Ver Pagina Publicada(New)</asp:linkbutton></TD>--%>
								<TD style="HEIGHT: 2px">&nbsp;</TD>
								<TD style="HEIGHT: 2px">&nbsp;</TD>
								<TD style="HEIGHT: 2px">
									<asp:linkbutton id="lbtVuelosInter" runat="server" Width="168px">• Vuelos Internacionales</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style7"><asp:linkbutton id="lbtReservaBoleto" runat="server" 
                                        Width="119px" Height="16px">• Sts Reserva Avión</asp:linkbutton></TD>
								<TD style="WIDTH: 154px"><asp:linkbutton id="lbtAprueba" runat="server">• Aprueba Versión</asp:linkbutton></TD>
								<TD><asp:linkbutton id="lbtBoletos" runat="server" 
                                        Width="103px">• Boletos Avión</asp:linkbutton></TD>
								<TD>
									&nbsp;</TD>
								<TD>
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style7">
									<asp:linkbutton id="lbtReservaBoletoTren" runat="server" Width="120px" 
                                        Height="16px">• Sts Reserva Tren</asp:linkbutton></TD>
								<TD style="WIDTH: 154px"><asp:linkbutton id="lkbDesaprueba" runat="server">• Desaprueba Versión</asp:linkbutton></TD>
								<TD>
									<asp:linkbutton id="lbtTrasladarBoletoAereo" runat="server" Width="153px" 
                                        Height="16px">• Trasladar Boleto Aéreo</asp:linkbutton></TD>
								<TD>
									&nbsp;</TD>
								<TD>
									<asp:linkbutton id="lbtIncidencia" runat="server" Width="112px">• Incidencia</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD class="style7">
									&nbsp;</TD>
								<TD style="WIDTH: 154px">&nbsp;</TD>
								<TD>
									&nbsp;</TD>
								<TD>
									&nbsp;</TD>
								<TD>
									<asp:linkbutton id="lbtCreaCopia" runat="server" Width="140px" Visible="False">• Crea copia de Versión</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD colspan="5"><asp:linkbutton id="lbtMigrarPedido" runat="server">• Migrar pedido al mes actual</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="800px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgServicio" runat="server" Width="900px" CssClass="Grid" Height="27px" CellPadding="2"
							BorderWidth="2px" BorderColor="CadetBlue" AllowSorting="True" AutoGenerateColumns="False"
							BorderStyle="None">
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
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###,###,###.00} ">
									<ItemStyle HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV" HeaderText="IGV" DataFormatString="{0:###,###,###,###.00} ">
									<ItemStyle HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" HeaderText="Uti" DataFormatString="{0:###,###,###,###.00} ">
									<ItemStyle HorizontalAlign="Right" BackColor="OldLace"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioNeto" HeaderText="Servicio" DataFormatString="{0:###,###,###,###.00} ">
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
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Especificacion" HeaderText="Especificaci&#243;n"></asp:BoundColumn>

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
