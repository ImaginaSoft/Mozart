<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaFacturadas.aspx.vb" Inherits="VtaFacturadas" %>

<%@ Register src="ddlZonaVta.ascx" tagname="ddlZonaVta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 589px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Versiones Facturadas</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 16px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbkCierreVtas" runat="server" Visible="False">Cierre Periodo de Ventas</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 10px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="HEIGHT: 23px">Vendedor</TD>
								<TD style="HEIGHT: 23px"><asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 23px"></TD>
							</TR>
							<TR>
								<TD>Zona de Venta</TD>
								<TD style="HEIGHT: 23px">
                                    <uc1:ddlZonaVta ID="ddlZonaVta1" runat="server" />
                                </TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="style1">Idioma</TD>
								<TD style="HEIGHT: 23px">
                                    <asp:DropDownList ID="ddlIdioma" runat="server"  Width="118px">
                                        <asp:ListItem Value="T">Todos</asp:ListItem>
                                        <asp:ListItem Value="I">Ingles</asp:ListItem>
                                        <asp:ListItem Value="E">Español</asp:ListItem>
                                    </asp:DropDownList>
                                </TD>
								<TD class="style1"></TD>
							</TR>
							<TR>
								<TD>Fecha Movto del</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" CssClass="error" DESIGNTIMEDRAGDROP="23"
										Height="8px" ControlToValidate="txtFchInicial" ForeColor=" ">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" CssClass="error" DESIGNTIMEDRAGDROP="27"
										Height="8px" ControlToValidate="txtFchFinal" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgVersiones" runat="server" Width="900px" CssClass="Grid" Height="17px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
							OnItemDataBound="ComputeSum">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<FooterStyle Wrap="False"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select" DataTextFormatString="{0:dd-MM-yyyy}"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="Ver">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsVersion" SortExpression="StsVersion" HeaderText="Sts">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomVendedor" SortExpression="NomVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" SortExpression="PrecioTotal" HeaderText="Total" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Utilidad" SortExpression="Utilidad" HeaderText="Utilidad" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantDoc" SortExpression="CantDoc" HeaderText="Doc's">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Detalle"></asp:EditCommandColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="Nro Propuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAdultos" HeaderText="CantAdultos">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinos" HeaderText="CantNinos">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFinPeriodo" SortExpression="FchFinPeriodo" HeaderText="Cierre" DataFormatString="{0:dd-MMM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchPedido" SortExpression="FchPedido" HeaderText="Fecha Pedido" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPais" SortExpression="NomPais" HeaderText="Pais"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomEleEsp" SortExpression="NomEleEsp" HeaderText="Origen"></asp:BoundColumn>
								<asp:BoundColumn DataField="Idioma" SortExpression="Idioma" HeaderText="Idioma"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesPedido" SortExpression="DesPedido" HeaderText="DesPedido"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
