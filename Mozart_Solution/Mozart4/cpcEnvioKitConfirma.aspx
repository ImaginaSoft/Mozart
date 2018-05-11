<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcEnvioKitConfirma.aspx.vb" Inherits="cpcEnvioKitConfirma" %>

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
					<TD class="Titulo" style="HEIGHT: 13px">
						<P class="Titulo">
							&nbsp;Confirma envío de kit</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE class="tabla" id="Table6" style="WIDTH: 336px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="336" border="0">
							<TR>
								<TD style="WIDTH: 103px">
									Fecha&nbsp;de&nbsp;envío</TD>
								<TD style="WIDTH: 143px"><asp:textbox id="txtFchEnvioKit" runat="server"  CssClass="fd" Width="75px" Wrap="False"></asp:textbox><INPUT class="fd" id="Button2" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEnvioKit',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEnvioKit">&nbsp;</TD>
								<TD><asp:button id="btnGrabar" runat="server" Width="74px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
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
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Ciudad" SortExpression="Ciudad" HeaderText="Ciudad"></asp:BoundField>
								<asp:BoundField DataField="Estado" SortExpression="Estado" HeaderText="Estado"></asp:BoundField>
								<asp:BoundField DataField="CodigoPostal" SortExpression="CodigoPostal" HeaderText="Cód.Postal"></asp:BoundField>
								<asp:BoundField DataField="NomPais" SortExpression="NomPais" HeaderText="Pais"></asp:BoundField>
								<asp:TemplateField SortExpression="Obs" HeaderText="Obs">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Obs")%>' NavigateUrl='<%# "cpcEnvioKitObs.aspx?NroPedido=" + cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&StsEnvioKit="+DataBinder.Eval(Container.DataItem,"StsEnvioKit")+"&Opc=C&NomCliente="+DataBinder.Eval(Container.DataItem,"NomCliente")+"&Direccion="+DataBinder.Eval(Container.DataItem,"Direccion")+"&Ciudad="+DataBinder.Eval(Container.DataItem,"Ciudad")+"&ObsEnvioKit="+DataBinder.Eval(Container.DataItem,"ObsEnvioKit")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="FchEnvioKit" SortExpression="FchEnvioKit" HeaderText="EnvioKit" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="ObsEnvioKit" SortExpression="ObsEnvioKit" HeaderText="Observación"></asp:BoundField>
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
