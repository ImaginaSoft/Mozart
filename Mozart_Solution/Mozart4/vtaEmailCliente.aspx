<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaEmailCliente.aspx.vb" Inherits="vtaEmailCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="TABLA" id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 21px">Email del Cliente</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 468px; HEIGHT: 48px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="468" border="1">
							<TR>
								<TD>Fecha Ingreso del</TD>
								<TD><asp:textbox id="txtFchInicio" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp;&nbsp;
									<asp:textbox id="txtFchFin" runat="server" Width="75px" ReadOnly="True" CssClass="fd"></asp:textbox>&nbsp;
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFin',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD colSpan="1">Vendedor</TD>
								<TD>
									<asp:dropdownlist id="ddlVendedor" runat="server" Width="278px" DataValueField="CodVendedor" DataTextField="NomVendedor"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="462px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLog" runat="server" Width="776px" CssClass="Grid" 
                            Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Fecha"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Asunto" SortExpression="Asunto" HeaderText="Asunto"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoLog" HeaderText="TipoLog">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroLog" HeaderText="NroLog">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsLog" SortExpression="StsLog" HeaderText="StsLog"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
