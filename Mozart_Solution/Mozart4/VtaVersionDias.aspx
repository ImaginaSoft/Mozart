<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionDias.aspx.vb" Inherits="VtaVersionDias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 800px; POSITION: absolute; TOP: 8px; HEIGHT: 39px"
				cellSpacing="0" cellPadding="1" width="800" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">
						<asp:linkbutton id="lbtFichaVersion" runat="server" Width="107px">• Ficha Version</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="opciones">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 261px">
									<TABLE id="Table1" style="WIDTH: 197px; HEIGHT: 85px" cellSpacing="0" cellPadding="0" width="197"
										border="1" borderColor="#cccccc" class="tabla">
										<TR>
											<TD style="HEIGHT: 13px">Elimina dias
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="tabla" id="Table2" style="WIDTH: 183px; HEIGHT: 55px" cellSpacing="1" cellPadding="1"
													width="183" border="0">
													<TR>
														<TD style="WIDTH: 53px">Del dia</TD>
														<TD><asp:textbox id="txtDiaIni" runat="server" Width="32px" MaxLength="2"></asp:textbox></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 53px">Al día</TD>
														<TD><asp:textbox id="txtDiaFin" runat="server" Width="33px" MaxLength="2"></asp:textbox></TD>
														<TD><asp:button id="cmdElimina" runat="server" Width="77px" Text="Aplicar"></asp:button></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="1" borderColor="#cccccc"
										class="tabla">
										<TR>
											<TD style="HEIGHT: 13px">Inserta dias
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="tabla" id="Table5" style="WIDTH: 272px; HEIGHT: 36px" cellSpacing="1" cellPadding="1"
													width="272" border="0">
													<TR>
														<TD style="WIDTH: 99px">A partir del día</TD>
														<TD>
															<asp:textbox id="txtDiaInicio" runat="server" MaxLength="2" Width="33px"></asp:textbox></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 99px">Cantidad Dias</TD>
														<TD>
															<asp:textbox id="txtCantDias" runat="server" MaxLength="2" Width="33px"></asp:textbox></TD>
														<TD>
															<asp:button id="cmdInserta" runat="server" Width="77px" Text="Aplicar"></asp:button></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="opciones"><asp:label id="lblMsg" runat="server" Width="425px" 
                            CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD class="opciones">
						<asp:datagrid id="dgServicio" runat="server" Width="800px" CssClass="Grid" CellPadding="2" BorderWidth="2px"
							BorderColor="CadetBlue" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None"
							Height="20px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesCantidad" HeaderText="Cantidad"></asp:BoundColumn>
								<asp:BoundColumn DataField="MontoFijo" HeaderText="Neto" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagValoriza" HeaderText="V"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
