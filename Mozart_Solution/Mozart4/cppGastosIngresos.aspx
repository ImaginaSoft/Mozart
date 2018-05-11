<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppGastosIngresos.aspx.vb" Inherits="cppGastosIngresos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 786px; POSITION: absolute; TOP: 8px; HEIGHT: 68px"
				cellSpacing="0" cellPadding="0" width="786" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">&nbsp;Ingresos y Gastos por&nbsp;mes&nbsp;en US$</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 4px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lbtActualizar" runat="server">Actualizar Mes</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 39px">
						<TABLE class="tabla" id="Table6" style="WIDTH: 456px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
							width="456" border="0">
							<TR>
								<TD style="WIDTH: 58px">Informe</TD>
								<TD style="WIDTH: 221px"><asp:dropdownlist id="ddlInforme" runat="server" Width="215px" DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
								<TD style="WIDTH: 58px" align="right">Año</TD>
								<TD style="WIDTH: 125px">&nbsp;
									<asp:dropdownlist id="ddlAno" tabIndex="9" runat="server" Width="72px" DataValueField="AnoProceso"
										DataTextField="AnoProceso"></asp:dropdownlist></TD>
								<TD style="WIDTH: 125px"><asp:button id="cmdBuscar" runat="server" Width="75px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="768px"  CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLista" runat="server" Width="800px" Height="25px" CssClass="Grid" BorderWidth="1px"
							CellPadding="2" BorderColor="#CCCCCC" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CodCuenta" HeaderText="Cuenta"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesCuenta" HeaderText="Nombre Cuenta"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Ene">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total01","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=01&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Feb">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total02","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=02&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mar">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total03","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=03&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Abr">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total04","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=04&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="May">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total05","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=05&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Jun">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total06","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=06&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Jul">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total07","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=07&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ago">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink08" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total08","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=08&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sep">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink09" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total09","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=09&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Oct">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total10","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=10&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Nov">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total11","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=11&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Dic">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Total12","{0:###,###,###,###}")%>' NavigateUrl='<%# "cppGastosCanceladosDet.aspx?AnoProceso=" + DataBinder.Eval(Container.DataItem,"AnoProceso")+"&MesProceso=12&NomCuenta=" + DataBinder.Eval(Container.DataItem,"DesCuenta") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="AnoProceso" HeaderText="AnoProceso">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoReg" HeaderText="TipoReg">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>
						&nbsp;&nbsp;&nbsp;
						<asp:Label id="lblFechaInicio" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblFechaFin" runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
