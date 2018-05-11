<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionPrecio.aspx.vb" Inherits="VtaVersionPrecio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 611px; POSITION: absolute; TOP: 8px; HEIGHT: 128px"
				cellSpacing="0" cellPadding="0" width="611" border="0" class="form">
				<TR>
					<TD style="HEIGHT: 17px">
						<P class="Titulo">&nbsp;
							<asp:Label id="lblTitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD class="Opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtServicios" runat="server" Width="80px">• Servicios</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaVersion" runat="server" Width="112px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 7px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD class="form">Precio por Tipo</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 296px">
									<asp:datagrid id="dgResumen" runat="server" Width="432px" ShowFooter="True" OnItemDataBound="ComputeSum"
										CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="20px"
										CssClass="Grid" BorderStyle="None">
										<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
										<ItemStyle CssClass="GridData"></ItemStyle>
										<HeaderStyle CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="TipoPasajero" HeaderText="Tipo Pasajero">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NomSubTipo" HeaderText="Tipo Habitaci&#243;n">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Noches" HeaderText="Noches / Servicios">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioPersona" HeaderText="Precio x Persona" DataFormatString="{0:###,###,###.00}">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CantPersonas" HeaderText="N&#176; Personas">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:###,###,###.00}">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;&nbsp;&nbsp;
						<TABLE id="Table4" style="WIDTH: 544px; HEIGHT: 20px" cellSpacing="0" cellPadding="0" width="544"
							border="0">
							<TR>
								<TD class="form" style="WIDTH: 296px; HEIGHT: 17px">Precios para mostrar al Cliente</TD>
								<TD style="WIDTH: 296px; HEIGHT: 17px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 296px">
									<asp:datagrid id="dgPrecio" runat="server" Width="432px" ShowFooter="True" OnItemDataBound="ComputeSumP"
										CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="20px"
										CssClass="Grid" BorderStyle="None">
										<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
										<ItemStyle CssClass="GridData"></ItemStyle>
										<HeaderStyle CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="DesOrden" HeaderText="Descripci&#243;n">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioxPersona" HeaderText="Precio x Persona" DataFormatString="{0:###,###,###.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CantPersonas" HeaderText="N&#176; Personas">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:###,###,###.00}">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
								<TD style="WIDTH: 296px">&nbsp;&nbsp;
									<asp:button id="cmdModif" runat="server" Text="Actualizar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 32px" cellSpacing="1" cellPadding="1"
							width="544" border="1">
							<TR>
								<TD style="WIDTH: 71px; HEIGHT: 23px" align="right">
									<asp:CheckBox id="chbRangoTarifa" runat="server" Width="100px" Text="Rango Tarifa"></asp:CheckBox></TD>
								<TD style="WIDTH: 4px; HEIGHT: 23px">
									<asp:textbox id="txtRangoTarifa" runat="server" Width="30px"></asp:textbox></TD>
								<TD style="WIDTH: 124px; HEIGHT: 23px" align="right">
									<asp:CheckBox id="chbCantSolicita" runat="server" Width="116px" Text="Cantidad x Tipo"></asp:CheckBox></TD>
								<TD style="WIDTH: 41px; HEIGHT: 23px">
									<asp:textbox id="txtCantSolicita" runat="server" Width="30px"></asp:textbox></TD>
								<TD style="WIDTH: 84px; HEIGHT: 23px" align="right">
									<asp:CheckBox id="chbCantPersonas" runat="server" Width="116px" Text="N° Personas"></asp:CheckBox></TD>
								<TD style="HEIGHT: 23px">
									<asp:textbox id="txtCantPersonas" runat="server" Width="30px"></asp:textbox></TD>
								<TD style="HEIGHT: 23px">
									<asp:button id="cmdGrabar" runat="server" Width="68px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;
						<asp:label id="lblMsg" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px"><asp:GridView id="dgServicio" runat="server" Width="800px" CssClass="Grid" Height="24px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:BoundField DataField="NroDia" HeaderText="Día">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomCiudad" HeaderText="Ciudad">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="DesProveedor" HeaderText="Servicio">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomProveedor" HeaderText="Proveedor">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="FlagValoriza" HeaderText="V">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="RangoTarifa" HeaderText="Rango Tarifa">
									<ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CantSolicita" HeaderText="Cant. Tipo">
									<ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="TipoPasajero" HeaderText="Tipo Pas.">
									<ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CantPersonas" HeaderText="Nro. Pers.">
									<ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomSubTipo" HeaderText="Tipo Hab.">
									<ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="TarifaxPersona" HeaderText="Tarifa Pers." DataFormatString="{0:####,###,###.##}">
									<ItemStyle HorizontalAlign="right" BackColor="LightCyan" Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="PrecioNeto" HeaderText="Precio Neto" DataFormatString="{0:####,###,###.##}">
									<ItemStyle HorizontalAlign="right" BackColor="OldLace" Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="IGV" HeaderText="IGV" DataFormatString="{0:####,###,###.##}">
									<ItemStyle HorizontalAlign="right" BackColor="OldLace" Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Utilidad" HeaderText="Uti." DataFormatString="{0:####,###,###.##}">
									<ItemStyle HorizontalAlign="right" BackColor="OldLace" Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:####,###,###.##}">
									<ItemStyle HorizontalAlign="right" BackColor="OldLace" Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CodGrupoServicio" HeaderText="CodGrupoServicio" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="FlagPrecio" HeaderText="FlagPrecio" Visible="false"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</form>
</body>
</html>
