<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioBusca.aspx.vb" Inherits="VtaServicioBusca" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 15px;
            width: 35px;
        }
        .style2
        {
            height: 25px;
            width: 35px;
        }
        .style3
        {
            width: 35px;
        }
        .style4
        {
            height: 15px;
            width: 129px;
        }
        .style5
        {
            height: 25px;
            width: 129px;
        }
        .style6
        {
            width: 129px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" style="COLOR: #ffffff" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 944px; POSITION: absolute; TOP: 8px; HEIGHT: 128px"
				cellSpacing="0" cellPadding="1" width="944" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Buscar Servicio</P>
					</TD>
				</TR>
				<TR>
					<TD class="OPCIONES"><asp:linkbutton id="lbtNuevoServicio" runat="server">Nuevo Servicio</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" style="WIDTH: 626px; HEIGHT: 75px" cellSpacing="0" cellPadding="0"
							border="0">
							<TR>
								<TD style="WIDTH: 322px">
									<TABLE class="Tabla" id="Table1" style="WIDTH: 328px; HEIGHT: 75px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="328" border="1">
										<TR>
											<TD style="WIDTH: 65px; HEIGHT: 18px">&nbsp;Proveedor</TD>
											<TD ><asp:dropdownlist id="ddlProveedor" runat="server" AutoPostBack="True" DataValueField="CodProveedor"
													DataTextField="NomProveedor" Width="248px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 65px; HEIGHT: 18px">&nbsp;Ciudad</TD>
											<TD ><asp:dropdownlist id="ddlCiudad" runat="server" AutoPostBack="True" DataValueField="CodCiudad" DataTextField="NomCiudad"
													Width="248px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 65px">&nbsp;Tipo</TD>
											<TD>
												<asp:dropdownlist id="ddltiposervicio" runat="server" AutoPostBack="True" DataValueField="CodTipoServicio"
														DataTextField="TipoServicio" Width="248px"></asp:dropdownlist>&nbsp;
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<P>
										<TABLE class="Tabla" id="Table3" style="WIDTH: 333px; HEIGHT: 75px" borderColor="#cccccc"
											cellSpacing="0" cellPadding="0" border="1">
											<TR>
												<TD class="style1" >
													Proveedor</TD>
												<TD class="style4 ">
													<asp:dropdownlist id="ddlProveedor2" runat="server" AutoPostBack="True" DataValueField="CodProveedor"
															DataTextField="NomProveedor" Width="202px"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="style2" >
													<asp:Label ID="Label1" runat="server" Text="N° / Desc" Width="65px"></asp:Label>
												</TD>
												<TD class="style5">
													<asp:textbox id="txtNroServicio" runat="server" Width="200px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="style3">
													&nbsp;</TD>
												<TD class="style6">
													<asp:button id="cmdBuscar" runat="server" Width="96px" Text="Buscar Servicio"></asp:button>
												</TD>
											</TR>
										</TABLE>
									</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px"><asp:button id="cmbGrabar" runat="server" Width="80px" Text="Activos"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdInactivos" runat="server" Width="80px" Text="Inactivos"></asp:button><asp:label id="lblStsServicio" runat="server" Visible="False"></asp:label><asp:label id="lblBoton" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="592px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px">
						<P><asp:datagrid id="dgServicio" runat="server" Width="904px" CssClass="Grid" Height="25px" DataKeyField="NroServicio"
								AutoGenerateColumns="False" AllowSorting="True" BorderColor="CadetBlue" BorderWidth="1px"
								CellPadding="2">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Editar" CommandName="edit"></asp:ButtonColumn>
									<asp:BoundColumn DataField="NroServicio" SortExpression="NroServicio" HeaderText="Nro ">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn SortExpression="DesProveedor" HeaderText="Servicio">
										<ItemStyle></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesProveedor")%>' NavigateUrl='<%# "vtaServicioNuevoDes.aspx?NroServicio=" + cstr(DataBinder.Eval(Container.DataItem,"NroServicio"))+"&CodProveedor=" + cstr(DataBinder.Eval(Container.DataItem,"CodProveedor"))+"&CodCiudad=" + cstr(DataBinder.Eval(Container.DataItem,"CodCiudad"))+"&CodTipoServicio=" + cstr(DataBinder.Eval(Container.DataItem,"CodTipoServicio"))+"&DesProveedor="+DataBinder.Eval(Container.DataItem,"DesProveedor")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Tarifas" CommandName="select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="FlagValoriza" SortExpression="FlagValoriza" HeaderText="V"></asp:BoundColumn>
									<asp:ButtonColumn Text="Link" CommandName="Cancel"></asp:ButtonColumn>
									<asp:ButtonColumn Text="Eliminar" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="NomStsServicio" SortExpression="NomStsServicio" HeaderText="Estado"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="Inf">
										<ItemStyle Wrap="False"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink2" runat="server" Text='Info' NavigateUrl='<%# "vtaServicioInf.aspx?NroServicio=" + cstr(DataBinder.Eval(Container.DataItem,"NroServicio"))+"&DesProveedor="+DataBinder.Eval(Container.DataItem,"DesProveedor")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Proveedor">
										<ItemStyle></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NomCiudad" SortExpression="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
									<asp:BoundColumn DataField="TipoServicio" SortExpression="TipoServicio" HeaderText="Tipo"></asp:BoundColumn>
									<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Servicio Actualizado" DataFormatString="{0,1:dd MMM yy}{0,13:hh:mm tt }">
										<ItemStyle></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodProveedor" SortExpression="CodProveedor" HeaderText="CodProveedor">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodCiudad" SortExpression="CodCiudad" HeaderText="CodCiudad">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodTipoServicio" SortExpression="CodTipoServicio" HeaderText="CodTipoServicio">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FchIniTarifa" SortExpression="FchIniTarifa" HeaderText="RangoInicio Tarifa"
										DataFormatString="{0:dd MMM yy}">
										<ItemStyle></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FchFinTarifa" SortExpression="FchFinTarifa" HeaderText="RangoFinal Tarifa"
										DataFormatString="{0:dd MMM yy}">
										<ItemStyle></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FlagColorTarifa" SortExpression="FlagColorTarifa" HeaderText="FlagColorTarifa">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px">
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
			<P>&nbsp;</P>
		</form>
</body>
</html>
