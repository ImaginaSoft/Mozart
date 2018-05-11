<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcEnvioKit.aspx.vb" Inherits="cpcEnvioKit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 800px; POSITION: absolute; TOP: 8px; HEIGHT: 174px"
				cellSpacing="0" cellPadding="0" width="800" border="0">
				<TR>
					<TD class="Titulo">
						<P class="Titulo">
							&nbsp;Envío de kit</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE class="tabla" id="Table5" style="WIDTH: 760px; HEIGHT: 36px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="760" border="1">
							<TR>
								<TD style="WIDTH: 108px">&nbsp;Inicio de tour&nbsp;
								</TD>
								<TD style="WIDTH: 360px"><asp:textbox id="txtFchIni" runat="server" CssClass="fd" Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchIni',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" Width="18px" ForeColor=" "
										ControlToValidate="txtFchIni" Height="8px">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFin" runat="server"  CssClass="fd" Width="75px"></asp:textbox><INPUT class="fd" id="Button1" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFin',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" CssClass="error" Width="18px" ForeColor=" "
										ControlToValidate="txtFchFin" Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 115px">Estado del envío</TD>
								<TD style="WIDTH: 134px"><asp:dropdownlist id="ddlStsEnvio" runat="server" Width="128px" DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Width="74px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE class="tabla" id="Table6" style="WIDTH: 384px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="384" border="0">
							<TR>
								<TD style="WIDTH: 127px">&nbsp;Programar de&nbsp;envío</TD>
								<TD style="WIDTH: 178px"><asp:textbox id="txtFchEnvioKit" runat="server"  CssClass="fd" Width="75px" Wrap="False"></asp:textbox><INPUT class="fd" id="Button2" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEnvioKit',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEnvioKit">&nbsp;
									<asp:linkbutton id="LinkButton1" runat="server">Limpiar</asp:linkbutton></TD>
								<TD><asp:button id="btnGrabar" runat="server" Width="74px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" CssClass="msg" Width="688px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgLista" runat="server" CssClass="Grid" Width="800px" Height="24px" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" AllowSorting="True" DataKeyNames="NroPedido">
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
								<asp:BoundField DataField="FchInicio" SortExpression="FchInicio" HeaderText="Inicio" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:TemplateField SortExpression="NomCliente" HeaderText="Cliente">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NomCliente")%>' NavigateUrl='<%# "cpcClienteFicha.aspx?CodCliente=" + cstr(DataBinder.Eval(Container.DataItem,"CodCliente"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="Direccion" SortExpression="Direccion" HeaderText="Direccion">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Ciudad" SortExpression="Ciudad" HeaderText="Ciudad"></asp:BoundField>
								<asp:BoundField DataField="Estado" SortExpression="Estado" HeaderText="Estado"></asp:BoundField>
								<asp:BoundField DataField="CodigoPostal" SortExpression="CodigoPostal" HeaderText="Cód.Postal"></asp:BoundField>
								<asp:BoundField DataField="NomPais" SortExpression="NomPais" HeaderText="Pais"></asp:BoundField>
								<asp:TemplateField SortExpression="Obs" HeaderText="Obs">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Obs")%>' NavigateUrl='<%# "cpcEnvioKitObs.aspx?NroPedido=" + cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&StsEnvioKit="+DataBinder.Eval(Container.DataItem,"StsEnvioKit")+"&Opc=E&NomCliente="+DataBinder.Eval(Container.DataItem,"NomCliente")+"&Direccion="+DataBinder.Eval(Container.DataItem,"Direccion")+"&Ciudad="+DataBinder.Eval(Container.DataItem,"Ciudad")+"&ObsEnvioKit="+DataBinder.Eval(Container.DataItem,"ObsEnvioKit")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="FchEnvioKit" SortExpression="FchEnvioKit" HeaderText="EnvioKit" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="ObsEnvioKit" SortExpression="ObsEnvioKit" HeaderText="Observación"></asp:BoundField>
								<asp:BoundField DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundField>
								<asp:BoundField DataField="NomEleEsp" SortExpression="NomEleEsp" HeaderText="Sts"></asp:BoundField>
								<asp:BoundField DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" Visible="False">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="StsEnvioKit" SortExpression="StsEnvioKit" HeaderText="Sts" Visible="False"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</FORM>
</body>
</html>
