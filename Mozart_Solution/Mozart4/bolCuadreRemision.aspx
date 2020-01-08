<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolCuadreRemision.aspx.vb" Inherits="bolCuadreRemision" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 547px; POSITION: absolute; TOP: 6px; HEIGHT: 72px"
				cellSpacing="0" cellPadding="1" width="547" border="0">
				<TR>
					<TD>
						<P class="Titulo">Cuadre&nbsp;de Remisión o Reembolso</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 10px" cellSpacing="1" cellPadding="1"
							width="544" border="1" borderColor="#cccccc"	>
							<TR>
								<TD style="WIDTH: 130px">Fecha de la remisión o reembolso</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" DESIGNTIMEDRAGDROP="21" CssClass="fd" ReadOnly="True"
										Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" DESIGNTIMEDRAGDROP="23" CssClass="error" Width="18px"
										ForeColor=" " ControlToValidate="txtFchInicial" Height="8px">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="24" Width="17px">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" DESIGNTIMEDRAGDROP="25" CssClass="fd" ReadOnly="True"
										Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" DESIGNTIMEDRAGDROP="27" CssClass="error"
										Width="18px" ForeColor=" " ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" CssClass="Msg" Width="462px"></asp:label><asp:datagrid id="dgLista" runat="server" CssClass="Grid" Width="544px" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue" ShowFooter="True"
							OnItemDataBound="ComputeSum">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroReembolso" SortExpression="NroReembolso" HeaderText="NroPedido / NroReembolso">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Nuevo Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PagoBoleto" SortExpression="PagoBoleto" HeaderText="Pago de Boleto "
									DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="#FFFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Recuperado" SortExpression="Recuperado" HeaderText="Remisi&#243;n o Reembolso"
									DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Provision" SortExpression="Provision" HeaderText="Provisi&#243;n" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Diferencia" SortExpression="Diferencia" HeaderText="Diferencia" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Boleto" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="NroPedido">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="NroPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="Versi&#243;n">
									 <ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text="Version" NavigateUrl='<%# "bolCuadreRemisionVersion.aspx?NroPedido=" + cstr(DataBinder.Eval(Container.DataItem,"NroPedido")) +"&NroPropuesta=" + cstr(DataBinder.Eval(Container.DataItem,"NroPropuesta"))+"&NroVersion=" + cstr(DataBinder.Eval(Container.DataItem,"NroVersion"))+"&NroReembolso=" + cstr(DataBinder.Eval(Container.DataItem,"NroReembolso"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
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
