<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaDias.aspx.vb" Inherits="VtaPropuestaDias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="tabla" id="Table3" style="Z-INDEX: 101; LEFT: 7px; WIDTH: 589px; POSITION: absolute; TOP: 7px; HEIGHT: 288px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lbltitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table6" style="WIDTH: 528px; HEIGHT: 111px" cellSpacing="0" cellPadding="0"
							width="528" border="0">
							<TR>
								<TD style="WIDTH: 299px" vAlign="top">
									<TABLE class="tabla" id="Table1" style="WIDTH: 184px; HEIGHT: 93px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="184" border="1">
										<TR>
											<TD style="HEIGHT: 13px">Elimina dias
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="tabla" id="Table4" style="WIDTH: 183px; HEIGHT: 55px" cellSpacing="0" cellPadding="0"
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
								<TD vAlign="top">
									<TABLE class="tabla" id="Table2" style="WIDTH: 232px; HEIGHT: 93px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="232" border="1">
										<TR>
											<TD style="HEIGHT: 13px">Inserta dias
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="tabla" id="Table5" style="WIDTH: 232px; HEIGHT: 55px" cellSpacing="0" cellPadding="0"
													width="232" border="0">
													<TR>
														<TD style="WIDTH: 99px">A partir del día</TD>
														<TD><asp:textbox id="txtDiaInicio" runat="server" Width="33px" MaxLength="2"></asp:textbox></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 99px">Cantidad Dias</TD>
														<TD><asp:textbox id="txtCantDias" runat="server" Width="33px" MaxLength="2"></asp:textbox></TD>
														<TD><asp:button id="cmdInserta" runat="server" Width="77px" Text="Aplicar"></asp:button></TD>
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
					<TD><asp:label id="lblMsg" runat="server" Width="504px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgServicio" runat="server" Width="800px" CssClass="Grid" Height="20px" BorderColor="CadetBlue"
							BorderStyle="None" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2">
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
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="MontoFijo" HeaderText="Neto" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagValoriza" HeaderText="V"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
