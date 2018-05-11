<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppCuadreTC.aspx.vb" Inherits="cppCuadreTC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 552px; POSITION: absolute; TOP: 8px; HEIGHT: 283px"
				cellSpacing="0" cellPadding="0" width="552" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 594px; HEIGHT: 8px">
						<P class="Titulo">Pedidos Terminado - Cuadre&nbsp;TC</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px; HEIGHT: 85px">
						<TABLE class="form" id="Table3" style="WIDTH: 385px; HEIGHT: 47px" cellSpacing="0" cellPadding="0"
							width="385" border="0">
							<TR>
								<TD style="WIDTH: 321px; HEIGHT: 47px">
									<TABLE class="tabla" id="Table2" style="WIDTH: 318px; HEIGHT: 51px" cellSpacing="0" cellPadding="0"
										width="318" bgColor="#cccccc" border="1">
										<TR>
											<TD style="WIDTH: 136px">Pedidos terminados al</TD>
											<TD><asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd"  AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchEmision">
												<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" CssClass="error" Height="8px" ControlToValidate="txtFchEmision"
													ForeColor=" ">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 136px">Moneda</TD>
											<TD><asp:radiobutton id="rbdolar" runat="server" Checked="True" GroupName="GRUPO1" Text="Dólares"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" GroupName="GRUPO1" Text="Nuevo Soles"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 47px"><asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px"><asp:label id="lblmsg" runat="server" Width="536px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px"><asp:datagrid id="dgLista" runat="server" Width="560px" CssClass="Grid" Height="17px" AllowSorting="True"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Cliente" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchTermino" SortExpression="FchTermino" HeaderText="Termino" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TC" SortExpression="TC" HeaderText="Provisi&#243;n TC" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='Proveedor' NavigateUrl='<%# "cppDocumento.aspx?CodProveedor=91&NroPedido="+cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 594px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
