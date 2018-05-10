<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segLogAccesoPeru4me.aspx.vb" Inherits="segLogAccesoPeru4me" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 15px; WIDTH: 589px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							Log de&nbsp;Accesos&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 632px; HEIGHT: 116px" cellSpacing="0" cellPadding="0"
							width="700" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 120px">&nbsp;Fecha Ingreso del</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" DESIGNTIMEDRAGDROP="21" CssClass="fd" 
										Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" DESIGNTIMEDRAGDROP="23" CssClass="error" Width="18px"
										ForeColor=" " ControlToValidate="txtFchInicial" Height="8px">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="24" Width="17px">al</asp:label>&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" CssClass="fd"  Width="75px"></asp:textbox>&nbsp;
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" Width="18px" ForeColor=" "
										ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 120px">
									&nbsp;Modulos</TD>
								<TD>
									<asp:RadioButton id="rbtPeru4me" runat="server" Text="Peru4me, Galapagos4me y Chile4me" GroupName="g1"
										Checked="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 120px">Vendedor</TD>
								<TD>
									<asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 120px">&nbsp;E-mail</TD>
								<TD><asp:textbox id="txtemail" runat="server" Width="240px"></asp:textbox>(opcional)</TD>
							</TR>
							<TR>
								<TD colSpan="1" style="WIDTH: 120px">&nbsp;</TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" CssClass="Msg" Width="462px" ></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLog" runat="server" CssClass="Grid" Width="800px" Height="17px" BorderColor="CadetBlue"
							CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Fecha">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodPais" SortExpression="CodPais" HeaderText="País" >
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" DataFormatString="{0:#########}"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroDoc" SortExpression="NroDoc" HeaderText="Nro" DataFormatString="{0:###}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Paterno" SortExpression="Paterno" HeaderText="ID">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acceso" SortExpression="Acceso" HeaderText="Tp">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PC" SortExpression="PC" HeaderText="PC">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
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
