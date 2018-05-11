<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcFacturaServicio.aspx.vb" Inherits="cpcFacturaServicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">

	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="Form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 520px; POSITION: absolute; TOP: 8px; HEIGHT: 208px"
				cellSpacing="0" cellPadding="1" width="520" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 724px; HEIGHT: 19px">
						Facturar Versiones&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 15px">
						<TABLE class="tabla" id="Table6" style="WIDTH: 384px; HEIGHT: 26px" cellSpacing="1" cellPadding="1"
							width="384" border="0">
							<TR>
								<TD>Cliente</TD>
								<TD><asp:dropdownlist id="ddlCliente" tabIndex="3" runat="server" Width="273px" DataValueField="CodCliente"
										DataTextField="NomCliente" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 24px">
						<P><asp:GridView id="dgServicio" runat="server" Width="696px" Height="24px" 
                                CssClass="Grid" BorderColor="CadetBlue"
								BorderWidth="1px" CellPadding="2" AutoGenerateColumns="False" DataKeyNames="KeyReg" 
                                UseAccessibleHeader="False">
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

									<asp:BoundField DataField="NroPedido" SortExpression="NroReporte" HeaderText="Pedido">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="NroVersion" SortExpression="NroVersion" HeaderText="Versi&#243;n">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="NomComprador" HeaderText="Cliente"></asp:BoundField>
									<asp:BoundField DataField="FchInicio" HeaderText="Fch.Inicio" DataFormatString="{0:dd-MM-yyyy}">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="Pax" HeaderText="Pax">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="CantDias" HeaderText="Dias">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:####,###,###.##}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="ObsVersion" HeaderText="ObsVersion">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundField>
								</Columns>
							</asp:GridView></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 23px">
						<P><asp:button id="cmdTotalizar" runat="server" Width="88px" Visible="False" Text="Suma montos"></asp:button></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 26px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 10px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD>
									<P class="SubTitulo">Datos para generar el cargo al Cliente</P>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="tabla" id="Table5" style="WIDTH: 384px; HEIGHT: 4px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="384" border="1">
										<TR>
											<TD style="WIDTH: 308px">Fecha&nbsp;de la Versión&nbsp; que permite mostrar la 
												utilidad en el mes que corresponda</TD>
											<TD>
												<asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" ReadOnly="True" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">&nbsp;&nbsp;
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="tabla" id="Table1" style="WIDTH: 384px; HEIGHT: 26px" cellSpacing="1" cellPadding="1"
										width="384" border="0">
										<TR>
											<TD style="WIDTH: 139px">
												<P>Tipo Documento
												</P>
											</TD>
											<TD><asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="253px" DataValueField="TipoDocumento"
													DataTextField="NomDocumento"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
									&nbsp;
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 384px; HEIGHT: 134px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="384" border="1">
										<TR>
											<TD style="HEIGHT: 25px" align="center">Cuota</TD>
											<TD style="WIDTH: 57px; HEIGHT: 25px" align="center">%</TD>
											<TD style="WIDTH: 55px; HEIGHT: 25px" align="center">Monto</TD>
											<TD style="HEIGHT: 25px" align="center">Fecha Vencimiento</TD>
										</TR>
										<TR>
											<TD align="center">1</TD>
											<TD style="WIDTH: 57px" align="center"><asp:textbox id="txtp1" runat="server" Width="43px" AutoPostBack="True" MaxLength="8"></asp:textbox></TD>
											<TD style="WIDTH: 55px" align="center"><asp:textbox id="txtMonto1" runat="server" Width="88px" MaxLength="15"></asp:textbox></TD>
											<TD align="center"><asp:textbox id="txtFchEmision1" runat="server" Width="75px" AutoPostBack="True" CssClass="fd"
													ReadOnly="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision1" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision1',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchEmision1"></TD>
										</TR>
										<TR>
											<TD align="center">2</TD>
											<TD style="WIDTH: 57px" align="center"></TD>
											<TD style="WIDTH: 55px" align="center"><asp:textbox id="txtMonto2" runat="server" Width="88px" MaxLength="15"></asp:textbox></TD>
											<TD align="center"><asp:textbox id="txtFchEmision2" runat="server" Width="75px" AutoPostBack="True" CssClass="fd"
													ReadOnly="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision2" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision2',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchEmision1"></TD>
										</TR>
										<TR>
											<TD align="center">3</TD>
											<TD style="WIDTH: 57px" align="center"><asp:textbox id="txtp3" runat="server" Width="43px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
											<TD style="WIDTH: 55px" align="center"><asp:textbox id="txtMonto3" runat="server" Width="88px" MaxLength="15"></asp:textbox></TD>
											<TD align="center"><asp:textbox id="txtFchEmision3" runat="server" Width="75px" AutoPostBack="True" CssClass="fd"
													ReadOnly="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision3" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision3',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchEmision3"></TD>
										</TR>
										<TR>
											<TD align="center"></TD>
											<TD style="WIDTH: 57px" align="center"></TD>
											<TD style="WIDTH: 55px" align="center"><asp:textbox id="txtTotal" runat="server" Width="88px" Enabled="False" BackColor="#C0FFFF"></asp:textbox></TD>
											<TD align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 24px">
						<P><asp:button id="cmdGrabar" runat="server" Width="88px" Text="Grabar "></asp:button>&nbsp;
							<asp:label id="lblError" runat="server" Width="400px"  CssClass="Error"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 20px">
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 724px; HEIGHT: 20px">
						<asp:Label id="lblBodyEmail" runat="server" Visible="False"></asp:Label></TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
</body>
</html>
