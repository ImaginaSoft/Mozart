<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EstFactTrimVen.aspx.vb" Inherits="EstFactTrimVen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style7
        {
            width: 33%;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 507px; POSITION: absolute; TOP: 8px; HEIGHT: 156px"
				cellSpacing="0" cellPadding="1" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">Ventas por Trimestre</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<table class="style7">
                            <tr>
                                <td>
&nbsp;Año</td>
                                <td>
                                                <asp:dropdownlist id="ddlAno" tabIndex="5" runat="server" 
                                                    DataTextField="AnoProceso" DataValueField="AnoProceso"
										Width="90px" AutoPostBack="True"></asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Trimestre</td>
                                <td>
                                                <asp:DropDownList ID="ddlTrim" runat="server" Width="90px">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem Value="T">Todos</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                            </tr>
                            <tr>
                                <td>
                                    idioma</td>
                                <td>
                                                <asp:DropDownList ID="ddlIdioma" runat="server" AppendDataBoundItems="True" 
                                                    Width="90px">
                                                    <asp:ListItem Value="I">Ingles</asp:ListItem>
                                                    <asp:ListItem Value="E">Español</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                                <asp:button id="btnBuscar" tabIndex="2" runat="server" Width="86px" 
                                                    Text="Buscar"></asp:button>
                                            </td>
                            </tr>
                        </table>
                    </TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblerror" runat="server" Width="571px" CssClass="Error"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgLista" runat="server" Height="24px" Width="550px" 
                            CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="3" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None" 
							UseAccessibleHeader="False" ShowFooter="true">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundField DataField="Ano"  HeaderText="Año" >
									<ItemStyle  HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Trimestre"  HeaderText="Trimestre" >
									<ItemStyle  HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Idioma" HeaderText="Idioma">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Vendedor" HeaderText="Vendedor" ></asp:BoundField>
								<asp:BoundField DataField="Venta" HeaderText="Venta" DataFormatString="{0:###,###,###}" >
								<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###,###}">
								<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="puti" HeaderText="%Uti." DataFormatString="{0:###,###.00}">
								<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="PedidoAsig" HeaderText="Pedidos Asignados" DataFormatString="{0:###,###,###}">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="PedidoFact" HeaderText="Pedido Facturados" DataFormatString="{0:###,###,###}">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="pfac" HeaderText="%Fact." DataFormatString="{0:###,###.00}">
								<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField >
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
