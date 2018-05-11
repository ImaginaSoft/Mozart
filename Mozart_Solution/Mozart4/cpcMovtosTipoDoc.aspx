<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcMovtosTipoDoc.aspx.vb" Inherits="cpcMovtosTipoDoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 627px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="627" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Consulta Movimientos por Tipo Documento</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table1" style="WIDTH: 521px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="521"
							border="1" class="tabla" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 77px"><asp:label id="Label1" runat="server" Width="103px">Tipo Sistema</asp:label></TD>
								<TD><asp:dropdownlist id="ddlTipoSistema" runat="server" Width="288px"  AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px"><asp:label id="Label4" runat="server" Width="103px">Tipo Documento</asp:label></TD>
								<TD><asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="287px" DataValueField="TipoDocumento"
										DataTextField="NomDocumento" ></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px"><asp:label id="Label5" runat="server" Width="116px">Rango  Fecha del </asp:label></TD>
								<TD>
									<asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" ></asp:textbox>
									<INPUT class="fd" id="cmdFchInicial" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchInicial"
										CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator>&nbsp;
									<asp:label id="Label2" runat="server" Width="17px">  al</asp:label>&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px" CssClass="fd" ></asp:textbox>
									<INPUT class="fd" id="cmdFchFinal" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Height="8px" Width="18px" ControlToValidate="txtFchFinal"
										CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdConsultar" runat="server" Text="Buscar" Width="72px"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="462px"  CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgMovimientos" runat="server" Width="962px" Height="17px" CssClass="Grid" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="Versi&#243;n" DataFormatString="{0:###}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" HeaderText="Operaci&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Importe" DataFormatString="{0:###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodMoneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Referencia">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Banco" HeaderText="Banco">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Cuenta" HeaderText="Cuenta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="FchSys">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
