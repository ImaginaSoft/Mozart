<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppDocumento.aspx.vb" Inherits="cppDocumento" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 676px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="676" border="0">
				<TR>
					<TD>
						<P class="Titulo">Modificar/Anular Documentos</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 512px; HEIGHT: 64px" cellSpacing="0" cellPadding="0"
							width="512" border="0">
							<TR>
								<TD style="WIDTH: 194px; HEIGHT: 30px">Movtos a partir</TD>
								<TD style="WIDTH: 215px; HEIGHT: 30px"><asp:textbox id="txtFchEmision" runat="server"  AutoPostBack="True" Width="75px"
										CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" CssClass="error" ControlToValidate="txtFchEmision"
										ForeColor=" " Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 137px; HEIGHT: 30px"><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 194px; HEIGHT: 25px">Tipo</TD>
								<TD style="WIDTH: 215px; HEIGHT: 25px"><asp:radiobutton id="rbPendiente" runat="server" Text="Pendientes" Checked="True" GroupName="1"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbTodos" runat="server" Text="Todos" GroupName="1"></asp:radiobutton></TD>
								<TD style="WIDTH: 137px; HEIGHT: 25px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 194px">Cliente / N° Pedido</TD>
								<TD style="WIDTH: 215px">
									<asp:textbox id="txtNomCliente" runat="server" Width="256px"></asp:textbox></TD>
								<TD style="WIDTH: 137px"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="584px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgCtaCte" runat="server" Width="750px" CssClass="Grid" Height="17px" AllowSorting="True"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchEmision" SortExpression="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" SortExpression="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" DataFormatString="{0:#########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodMoneda" SortExpression="CodMoneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="Pend." DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" SortExpression="StsDocumento" HeaderText="Sts">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="Tipo Servicio">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tabla" HeaderText="Tabla">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" HeaderText="Operacion">
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle HorizontalAlign="Left" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="NroPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="NroVersion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="correlativo" HeaderText="correlativo">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCuenta" HeaderText="Cuenta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroComprobante" HeaderText="NroComprobante">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Origen" HeaderText="Origen">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
