<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segLogAccesoMozart.aspx.vb" Inherits="segLogAccesoMozart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD class="Titulo">Log de accesos a Mozart</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 68px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 468px; HEIGHT: 48px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="468" border="1">
							<TR>
								<TD>Fecha Ingreso del</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22"><asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd"></asp:textbox>&nbsp;
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="1">Usuario&nbsp;</TD>
								<TD><asp:dropdownlist id="ddlUsuario" runat="server" Width="280px" DataTextField="NomUsuario" DataValueField="CodUsuario"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Ubicación</TD>
								<TD>
									<asp:RadioButton id="rbtTodos" runat="server" Text="Todos" GroupName="g1"></asp:RadioButton>&nbsp; 
									&nbsp;
									<asp:RadioButton id="rbtLocal" runat="server" Text="Local" GroupName="g1"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtExterno" runat="server" Text="Externo" GroupName="g1" Checked="True"></asp:RadioButton>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdConsultar" runat="server" Width="80px" Text="Buscar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px"><asp:label id="lblmsg" runat="server" Width="462px" 
                            CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 137px"><asp:datagrid id="dgLog" runat="server" Width="576px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Fecha">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="Mensaje" SortExpression="Mensaje" HeaderText="Mensaje">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Proveedor" SortExpression="Proveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="PC" SortExpression="PC" HeaderText="PC">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ubica" SortExpression="Ubica" HeaderText="Ubica">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraRoja" SortExpression="HoraRoja" HeaderText="HoraRoja">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
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
