<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaCuadreAereo.aspx.vb" Inherits="VtaCuadreAereo" %>

<%@ Register src="ddlZonaVta.ascx" tagname="ddlZonaVta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 589px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Versiones Facturadas - Cuadre Aéreo</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 10px" cellSpacing="0" cellPadding="0"
							width="544" border="1" borderColor="#cccccc">
							<TR>
								<TD>Zona de Venta</TD>
								<TD>
									<uc1:ddlZonaVta ID="ddlZonaVta1" runat="server" />
                                </TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Fecha Version del</TD>
								<TD>
									<asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox>
									<INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchInicial"
										DESIGNTIMEDRAGDROP="23" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator>
									<asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox>
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchFinal"
										DESIGNTIMEDRAGDROP="27" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgVersiones" runat="server" Width="584px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select" DataTextFormatString="{0:dd-MM-yyyy}"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="Versi&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioFact" SortExpression="PrecioFact" HeaderText="Facturado" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioBoleto" SortExpression="PrecioBoleto" HeaderText="Boleto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Diferencia" SortExpression="Diferencia" HeaderText="Diferencia" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalAjuste" SortExpression="TotalAjuste" HeaderText="Ajuste" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Detalle"></asp:EditCommandColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="Nro Propuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
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
