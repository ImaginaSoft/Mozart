<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybConfirmaDeposito.aspx.vb" Inherits="cybConfirmaDeposito" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 882px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="882" border="0">
				<TR>
					<TD style="HEIGHT: 22px">
						<P class="Titulo">&nbsp;Confirmar Depósito</P>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPagos" runat="server" ShowFooter="True" Width="883px" CssClass="Grid" BorderColor="CadetBlue"
							Height="17px" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" HeaderText=" ">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DocMonto" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ComisionTC" HeaderText="Comisi&#243;n" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Deposito" HeaderText="Dep&#243;sito" DataFormatString="{0:###,###,###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Referencia"></asp:BoundColumn>
								<asp:BoundColumn DataField="GlosaDocumento" HeaderText="Titular"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodAutoriza" HeaderText="C&#243;d.Autorizaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomBanco" HeaderText="Banco">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroCuenta" HeaderText="Cuenta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoOperacion" HeaderText="TipoOperacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 448px; HEIGHT: 90px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="448" border="1">
							<TR>
								<TD style="HEIGHT: 28px">Fecha depósito</TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd" AutoPostBack="True"
										></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px">Banco</TD>
								<TD class="dato" style="HEIGHT: 20px"><asp:dropdownlist id="ddlBanco" 
                                        runat="server" Width="288px" AutoPostBack="True" DataTextField="NomBanco"
										DataValueField="CodBanco"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 19px">Nro. Cuenta</TD>
								<TD class="dato" style="HEIGHT: 19px"><asp:dropdownlist id="ddlNroCuenta" 
                                        runat="server" Width="288px" DataTextField="NroCuenta"
										DataValueField="SecBanco"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px">Monto depósito</TD>
								<TD class="dato" style="HEIGHT: 20px"><asp:label id="lblDeposito" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">Procesos que se ejecutara:</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 38px">
						<TABLE class="form" id="Table2" style="WIDTH: 608px; HEIGHT: 18px" cellSpacing="0" cellPadding="0"
							width="608" border="0">
							<TR>
								<TD style="WIDTH: 297px" vAlign="top"><asp:label id="lblAcciones1" runat="server" Width="600px" CssClass="msg"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="120px" Text="Procesar depósito"></asp:button></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
