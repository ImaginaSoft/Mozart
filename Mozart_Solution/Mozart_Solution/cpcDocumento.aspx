<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcDocumento.aspx.vb" Inherits="cpcDocumento" %>
<%@ Register TagPrefix="uc1" TagName="ucCliente" Src="ucCliente.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 676px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="676" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Documentos del Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD><uc1:uccliente id="UcCliente1" runat="server"></uc1:uccliente></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 402px; HEIGHT: 1px" cellSpacing="1" cellPadding="1"
							width="402" border="1">
							<TR>
								<TD><asp:label id="Label3" runat="server" Width="110px">Movtos apartir de</asp:label></TD>
								<TD style="WIDTH: 137px"><asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" 
										CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" ControlToValidate="txtFchEmision"
										Height="8px" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="715px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDocumento" runat="server" Width="950px" CssClass="Grid" Height="17px" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" AllowSorting="True">
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
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" ReadOnly="True" HeaderText="Pedido"
									DataFormatString="{0:##########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="Pend." DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" SortExpression="StsDocumento" HeaderText="Sts"></asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="Tipo Servicio">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="GlosaDocumento" SortExpression="GlosaDocumento" HeaderText="Titular"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodAutoriza" SortExpression="CodAutoriza" HeaderText="C&#243;d.Autoriza"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tabla" HeaderText="Tabla">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" HeaderText="TipoOperacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="NroPropuesta" DataFormatString="{0:##########}">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="NroVersion">
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
