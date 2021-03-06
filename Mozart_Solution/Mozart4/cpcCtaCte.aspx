﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcCtaCte.aspx.vb" Inherits="cpcCtaCte" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 565px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="565" border="0" class="FORM">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Cuenta Corriente del&nbsp;Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 402px; HEIGHT: 58px" cellSpacing="1" cellPadding="1"
							width="402" border="1">
							<TR>
								<TD>
									<asp:Label id="Label4" runat="server" Width="66px">Moneda</asp:Label></TD>
								<TD style="WIDTH: 137px">
									<asp:Label id="Label3" runat="server" Width="110px">Movtos apartir de</asp:Label></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:radiobutton id="rbDolar" runat="server" Text="Dólares" GroupName="GRUPO1" Checked="True" AutoPostBack="True"></asp:radiobutton>
									<asp:radiobutton id="rbSoles" runat="server" Text="Nuevo Soles" GroupName="GRUPO1" AutoPostBack="True"></asp:radiobutton></TD>
								<TD style="WIDTH: 137px">
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" 
										CssClass="fd"></asp:textbox>
									<INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" ControlToValidate="txtFchEmision"
										Height="8px" CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:Button id="cmdConsultar" runat="server" Text="Consultar"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="544px"  CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgCtaCte" runat="server" Width="700px" Height="17px" AutoGenerateColumns="False"
							BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue" CssClass="Grid">
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
								<asp:BoundColumn DataField="NroPedido" HeaderText="Pedido" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Cargo/Abono" DataFormatString="{0:###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:###,###.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Pendiente" HeaderText="Pendiente" DataFormatString="{0:###,###.00}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Tipo Servicio">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
