<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcClienteFicha.aspx.vb" Inherits="cpcClienteFicha" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" class="style1">
            <tr>
                <td class="Titulo">
                    Atención al Cliente</td>
            </tr>
            <tr>
                <td>
                    <uc1:ucCliente ID="ucCliente1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
						<TABLE class="tabla" id="Table4" style="WIDTH: 698px; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
							width="698" border="0">
							<TR>
								<TD class="SubTitulo" style="WIDTH: 139px; HEIGHT: 21px">Opciones</TD>
								<TD class="SubTitulo" style="WIDTH: 133px; HEIGHT: 21px"></TD>
								<TD class="SubTitulo" style="HEIGHT: 21px"></TD>
								<TD class="SubTitulo" style="HEIGHT: 21px"></TD>
								<TD class="SubTitulo" style="HEIGHT: 21px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 139px; HEIGHT: 6px"><asp:linkbutton id="lbtActualizaCliente" runat="server" Width="120px">• Datos del Cliente</asp:linkbutton></TD>
								<TD style="WIDTH: 133px; HEIGHT: 6px"><asp:linkbutton id="lbtNuevoPedido" runat="server" Width="112px">• Nuevo Pedido</asp:linkbutton></TD>
								<TD style="HEIGHT: 6px"><asp:linkbutton id="lbtRegistraPago" runat="server" 
                                        Width="112px" Enabled="False" style="height: 15px">• Registra Pago</asp:linkbutton></TD>
								<TD style="HEIGHT: 6px"><asp:linkbutton id="lbtDocumentos" runat="server" Width="148px" Enabled="False">• Consulta Documentos</asp:linkbutton></TD>
								<TD style="HEIGHT: 6px"><asp:linkbutton id="lbtNuevoCliente" runat="server" Width="110px" Enabled="False">• Nuevo Cliente</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 139px; HEIGHT: 14px"></TD>
								<TD style="WIDTH: 133px; HEIGHT: 14px"></TD>
								<TD style="HEIGHT: 14px"><asp:linkbutton id="lbtRegistraAbono" runat="server" Width="112px" Enabled="False">• Nota Abono</asp:linkbutton></TD>
								<TD style="HEIGHT: 14px"><asp:linkbutton id="lbtCtacte" runat="server" Width="152px">• Consulta Ctacte</asp:linkbutton></TD>
								<TD style="HEIGHT: 14px"><asp:linkbutton id="lbtContacto" runat="server" Width="112px" Enabled="False">• Usuario Peru4all</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 139px; HEIGHT: 19px">
									<asp:linkbutton id="lblEliminarCliente" runat="server" Width="120px">• Eliminar Cliente</asp:linkbutton></TD>
								<TD style="WIDTH: 133px; HEIGHT: 19px">
									<asp:linkbutton id="lbtVersiones" runat="server">• Revisar Versiones</asp:linkbutton></TD>
								<TD style="HEIGHT: 19px">
									<asp:linkbutton id="lbtRegistraCargo" runat="server" Width="112px" Enabled="False">• Nota Cargo</asp:linkbutton></TD>
								<TD style="HEIGHT: 19px"></TD>
								<TD style="HEIGHT: 19px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 139px; HEIGHT: 1px"></TD>
								<TD style="WIDTH: 133px; HEIGHT: 1px"></TD>
								<TD style="HEIGHT: 1px"><asp:linkbutton id="lbtReembolso" runat="server" Width="112px" Enabled="False">• Reembolso</asp:linkbutton></TD>
								<TD style="HEIGHT: 1px"></TD>
								<TD style="HEIGHT: 1px"></TD>
							</TR>
						</TABLE>
					</td>
            </tr>
            <tr>
                <td>
                    <asp:label id="lblMsg" runat="server" Width="573px" CssClass="Msg"></asp:label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:datagrid id="dgPedido" runat="server" Width="800px" CssClass="Grid" Height="17px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchPedido" HeaderText="Fch.Pedido" DataFormatString="{0:dd/MM/yyyy}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSolicita" HeaderText="Fch.Solicita" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomComprador" HeaderText="Cliente Age."></asp:BoundColumn>
								<asp:BoundColumn DataField="DesPedido" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="AnoMes" HeaderText="Atenci&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsPedido" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchRpta" HeaderText="Fch.Rpta" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsPedido" HeaderText="CodStsPedido">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
