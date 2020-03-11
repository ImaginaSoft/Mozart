<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionFicha.aspx.vb" Inherits="VtaVersionFicha" %>

<%@ Register Src="ucVersion.ascx" TagName="ucVersion" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="Styles.css" type="text/css" rel="stylesheet">
   <script type="text/javascript">

       function MigrarGG() {
           var txt;
           var version = prompt("Por favor ingrese el numero de versión:");
           debugger
           if (version == null || version == "" || version == undefined) {
               txt = "Usuario cancelo el proceso.";
             
           } else {
               txt = "Se  migro desde la version " + version;
           }
           document.getElementById("versionGG").value = version;
           document.getElementById("mensajeGG").innerHTML = txt;
       }
    
   </script>
    <style type="text/css">
        .style1 {
            height: 16px;
            width: 123px;
        }

        .style2 {
            height: 17px;
            width: 123px;
        }

        .style3 {
            height: 15px;
            width: 123px;
        }

        .style4 {
            height: 5px;
            width: 123px;
        }

        .style5 {
            height: 3px;
            width: 123px;
        }

        .style6 {
            height: 2px;
            width: 123px;
        }

        .style7 {
            width: 123px;
        }
    </style>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table id="Table3" style="z-index: 101; left: 8px; width: 567px; position: absolute; top: 0px; height: 22px"
            cellspacing="0" cellpadding="1" width="567" border="0">
            <tr>
                <td style="height: 21px">
                    <p class="Titulo">
                        &nbsp;
							<asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ucVersion ID="ucVersion1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="opciones">
                    <table class="opciones" id="Table4" style="width: 726px; height: 112px" cellspacing="0"
                        cellpadding="0" width="726" border="0">
                        <tr>
                            <td class="style1">
                                <asp:LinkButton ID="lbtServicio" runat="server">• Servicios</asp:LinkButton></td>
                            <td style="width: 154px; height: 16px">
                                <asp:LinkButton ID="lbtPublica" runat="server">• Publica Versión</asp:LinkButton></td>
                            <td style="height: 16px">
                                <asp:LinkButton ID="lbtNotaAbono" runat="server" Width="143px">• Devolución al Cliente</asp:LinkButton></td>
                            <td style="height: 16px">
                                <asp:LinkButton ID="lbtHistProveedor" runat="server" Width="124px">• Historial Proveedor</asp:LinkButton></td>
                            <td style="height: 16px">
                                <asp:LinkButton ID="lbtCambiarHotel" runat="server" Width="168px">• Cambiar Nombre Servicio</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:LinkButton ID="lbtPrecio" runat="server" Width="88px">• Precios</asp:LinkButton></td>
                            <td style="width: 154px; height: 17px">
                                <asp:LinkButton ID="lbtPaginaPublicada" runat="server" Width="148px">• Ver Pagina Publicada(old)</asp:LinkButton></td>
                            <td style="height: 17px">
                                <asp:LinkButton ID="lbtNotaCargo" runat="server">• Mayor pago del Cliente</asp:LinkButton></td>
                            <td style="height: 17px">
                                <asp:LinkButton ID="lbtHistorial" runat="server">• Historial Pedido</asp:LinkButton></td>
                            <td style="height: 17px">
                                <asp:LinkButton ID="lbtExcluirReserva" runat="server" Width="152px">• Cambiar Status Reserva</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:LinkButton ID="lbkResumen" runat="server">• Resumen</asp:LinkButton></td>
                            <td style="width: 154px; height: 15px">
                                <asp:LinkButton ID="lbtPrintPagina" runat="server" Width="148px">• Imprimir Pagina</asp:LinkButton></td>
                            <td style="height: 15px">
                                <asp:LinkButton ID="lbtProveedorNotaCargo" runat="server" Width="154px">• Menor pago al Proveedor</asp:LinkButton></td>
                            <td style="height: 15px">
                                <asp:LinkButton ID="lbtTareas" runat="server">• Tareas</asp:LinkButton></td>
                            <td style="height: 15px">
                                <asp:LinkButton ID="lbtDiaOrden" runat="server" Width="152px">• Cambiar Día - Orden</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:LinkButton ID="lbtModificaDias" runat="server" Width="98px">• Modificar Dias</asp:LinkButton></td>
                            <td style="width: 154px; height: 5px">
                                <asp:LinkButton ID="lbtModificar" runat="server" Width="115px">• Modificar Versión</asp:LinkButton></td>
                            <td style="height: 5px">
                                <asp:LinkButton ID="lbtProveedorNotaAbono" runat="server" Width="154px">• Mayor pago al Proveedor</asp:LinkButton></td>
                            <td style="height: 5px">
                                <asp:LinkButton ID="lbtEnviaEmail" runat="server" Width="87px">• Envia E-mail</asp:LinkButton></td>
                            <td style="height: 5px">
                                <asp:LinkButton ID="lbtCambiarHora" runat="server" Width="152px">• Cambiar Hora Servicio</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:LinkButton ID="lbtModificaLink" runat="server" Width="98px">• Modificar Link</asp:LinkButton></td>
                            <td style="width: 154px; height: 3px">
                                <asp:LinkButton ID="lbtEliminar" runat="server">• Eliminar Versión</asp:LinkButton></td>
                            <td style="height: 3px">
                                <asp:LinkButton ID="lbtDocAjuste" runat="server" Width="154px">• Documentos de Ajuste</asp:LinkButton></td>
                            <td style="height: 3px">
                                <asp:LinkButton ID="lbtReserva" runat="server" Width="114px">• Reserva Servicios</asp:LinkButton></td>
                            <td style="height: 3px">
                                <asp:LinkButton ID="lbtEspecificacion" runat="server" Width="112px">• Especificaciones</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:LinkButton ID="lbtLink" runat="server" Width="117px"
                                    Height="17px">• Sts Reserva Hotel</asp:LinkButton></td>
                            <%--								<TD style="WIDTH: 154px; HEIGHT: 17px"><asp:linkbutton id="lbtPaginaPublicadaNew" runat="server" Width="148px">• Ver Pagina Publicada(New)</asp:linkbutton></TD>--%>
                            <td style="height: 2px">&nbsp;</td>
                            <td style="height: 2px">&nbsp;</td>
                            <td style="height: 2px">
                                <asp:LinkButton ID="lbtVuelosInter" runat="server" Width="168px">• Vuelos Internacionales</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:LinkButton ID="lbtReservaBoleto" runat="server"
                                    Width="119px" Height="16px">• Sts Reserva Avión</asp:LinkButton></td>
                            <td style="width: 154px">
                                <asp:LinkButton ID="lbtAprueba" runat="server">• Aprueba Versión</asp:LinkButton></td>
                            <td>
                                <asp:LinkButton ID="lbtBoletos" runat="server"
                                    Width="103px">• Boletos Avión</asp:LinkButton></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:LinkButton ID="lbtReservaBoletoTren" runat="server" Width="120px"
                                    Height="16px">• Sts Reserva Tren</asp:LinkButton></td>
                            <td style="width: 154px">
                                <asp:LinkButton ID="lkbDesaprueba" runat="server">• Desaprueba Versión</asp:LinkButton></td>
                            <td>
                                <asp:LinkButton ID="lbtTrasladarBoletoAereo" runat="server" Width="153px"
                                    Height="16px">• Trasladar Boleto Aéreo</asp:LinkButton></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="lbtIncidencia" runat="server" Width="112px">• Incidencia</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="style7">&nbsp;</td>
                            <td style="width: 154px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="lbtCreaCopia" runat="server" Width="140px" Visible="False">• Crea copia de Versión</asp:LinkButton></td>
                        </tr>
                     <%--   <tr>
                            <td colspan="5">
                                <asp:LinkButton ID="lbtMigrarPedido" runat="server">• Migrar pedido al mes actual</asp:LinkButton></td>
                        </tr>--%>
              <%--          <tr>
                            <td colspan="5">
                                <asp:LinkButton ID="lbtMigrarPedidoGG" runat="server" OnClientClick="MigrarGG()">• Migrar GG</asp:LinkButton>
                                <asp:HiddenField ID="versionGG" runat="server" />
                                <asp:Label ID="mensajeGG"></asp:Label>
                            </td>
                            
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Width="800px" CssClass="msg"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgServicio" runat="server" Width="900px" CssClass="Grid" Height="27px" CellPadding="2"
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
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>

</body>
</html>
