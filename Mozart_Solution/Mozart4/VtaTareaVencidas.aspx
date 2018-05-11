<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaTareaVencidas.aspx.vb" Inherits="VtaTareaVencidas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 760px; POSITION: absolute; TOP: 8px; HEIGHT: 144px"
				cellSpacing="0" cellPadding="0" width="760" border="0">
				<TR>
					<TD style="HEIGHT: 15px">
						<P class="Titulo">Consulta Tareas Vencidas por Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 544px; HEIGHT: 60px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="HEIGHT: 19px">Vendedor</TD>
								<TD style="HEIGHT: 19px">
									<asp:dropdownlist id="ddlVendedor" runat="server" Width="331px" DataValueField="CodVendedor" DataTextField="NomVendedor"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 19px">&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD>Fecha Pedido del</TD>
								<TD>
									<asp:textbox id="txtFchInicial" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" CssClass="error" ControlToValidate="txtFchInicial"
										ForeColor=" " Height="8px" DESIGNTIMEDRAGDROP="23">*</asp:requiredfieldvalidator>
									<asp:label id="Label1" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Width="18px" CssClass="ERROR" ControlToValidate="txtFchFinal"
										ForeColor=" " Height="8px" DESIGNTIMEDRAGDROP="27">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="311px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgTareasxPedido" runat="server" Width="760px" CssClass="Grid" Height="25px"
							AutoGenerateColumns="False" ShowFooter="True" OnItemDataBound="ComputeSum" AllowSorting="True"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2">
							<FooterStyle HorizontalAlign="Center" ForeColor="Black"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="Nro Pedido">
									<HeaderStyle HorizontalAlign="Center" CssClass="Hide"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsCaptacion" SortExpression="NomStsCaptacion" HeaderText="Perfil"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tareas" SortExpression="Tareas" HeaderText="Tareas">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Destarea" SortExpression="Destarea" HeaderText="Pendiente"></asp:BoundColumn>
								<asp:ButtonColumn Text="Ficha" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchTarea" SortExpression="FchTarea" HeaderText="Fecha" DataFormatString="{0:dd--MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
