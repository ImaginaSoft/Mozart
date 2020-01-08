<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidoFicha.aspx.vb" Inherits="VtaPedidoFicha" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgColor="#ffffff" >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 759px; POSITION: absolute; TOP: 8px; HEIGHT: 264px"
				cellSpacing="0" cellPadding="1" width="759" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 11px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD class="tabla" style="HEIGHT: 116px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 616px; HEIGHT: 98px" cellSpacing="0" cellPadding="0"
							width="616" border="0">
							<TR>
								<TD style="WIDTH: 221px; HEIGHT: 18px"><asp:linkbutton id="lbtModifica" runat="server">• Modificar Pedido</asp:linkbutton></TD>
								<TD style="WIDTH: 247px; HEIGHT: 18px"><asp:linkbutton id="lbtPropuesta" runat="server">• Nueva Propuesta</asp:linkbutton></TD>
								<TD style="HEIGHT: 18px"><asp:linkbutton id="lbtHistProveedor" runat="server">• Historial Proveedor</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 221px; HEIGHT: 16px"><asp:linkbutton id="lbtEliminar" runat="server">• Eliminar Pedido</asp:linkbutton></TD>
								<TD style="WIDTH: 247px; HEIGHT: 16px"><asp:linkbutton id="lbtDesdePlantilla" runat="server">• Crear Propuesta desde una Plantilla</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtHistorial" runat="server">• Historial del Pedido</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 221px; HEIGHT: 16px"><asp:linkbutton id="lbtFinalizar" runat="server" ForeColor="Blue">• Estado Pedido y Recordatorio</asp:linkbutton></TD>
								<TD style="WIDTH: 247px; HEIGHT: 16px"><asp:linkbutton id="lbtDesdePropuesta" runat="server">• Crear Propuesta desde una Propuesta</asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"><asp:linkbutton id="lbtTareas" runat="server">• Tareas</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 221px; HEIGHT: 12px">
									<asp:linkbutton id="lbtAnulaFactPedido" runat="server" Visible="False">• Extorna Facturación </asp:linkbutton></TD>
								<TD style="WIDTH: 247px; HEIGHT: 12px">
									<asp:linkbutton id="lbtLiqPedido" runat="server">• Liquidación del Pedido </asp:linkbutton></TD>
								<TD style="HEIGHT: 12px"><asp:linkbutton id="lbtEnviaEmail" runat="server">• Envia E-mail</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 221px; HEIGHT: 16px">
									<asp:linkbutton id="lbtAnulaFactMes" runat="server" Visible="False" Width="208px">• Anula Fact. Mes actual de Ventas</asp:linkbutton></TD>
								<TD style="WIDTH: 247px; HEIGHT: 16px"><asp:linkbutton id="lbtConsultaPenalidad" runat="server">• Consulta Penalidades </asp:linkbutton></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 221px"><asp:linkbutton id="lbtAnulaFactVersion" runat="server" Visible="False" Width="200px">• Anula Fact. Meses Anteriores</asp:linkbutton></TD>
								<TD style="WIDTH: 247px">
									<asp:linkbutton id="lbtCierreVersionFact" runat="server">• Saldos al Cierre de Periodo de Ventas</asp:linkbutton></TD>
								<TD><asp:linkbutton id="lbtPasajero" runat="server">• Pasajeros</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="549px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPropuesta" runat="server" Height="17px" Width="1000px" CssClass="Grid" BorderStyle="None"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="3" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPropuesta" SortExpression="NroPropuesta" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesPropuesta" SortExpression="DesPropuesta" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchPropuesta" SortExpression="FchPropuesta" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsPropuesta" SortExpression="NomStsPropuesta" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="Publicado" HeaderText="Publicado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###.00}"></asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###,###.00}"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSolicita" HeaderText="Fch.Solicita" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchRpta" HeaderText="Fch.Rpta" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="StsPropuesta" HeaderText="StsPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Version_new" HeaderText="Migrado"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersionBase" HeaderText="Nro Base"></asp:BoundColumn>
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
