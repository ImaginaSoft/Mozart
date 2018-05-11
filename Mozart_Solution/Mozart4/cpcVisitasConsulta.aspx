<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcVisitasConsulta.aspx.vb" Inherits="cpcVisitasConsulta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 13px; WIDTH: 575px; POSITION: absolute; TOP: 14px; HEIGHT: 54px"
				cellSpacing="0" cellPadding="0" width="575" border="0" class="Form">
				<TR>
					<TD class="Titulo" style="WIDTH: 652px">
						<P class="Titulo">Consulta de visitas ejecutadas</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 652px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 652px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 448px; HEIGHT: 77px" cellSpacing="0" cellPadding="0"
							width="448" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 102px; HEIGHT: 2px">&nbsp;Fecha visita&nbsp;&nbsp;del</TD>
								<TD style="WIDTH: 286px; HEIGHT: 2px">
									<asp:textbox id="txtFchInicial" runat="server" CssClass="fd" Width="75px" ></asp:textbox>
									<INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" Width="18px" Height="8px"
										ControlToValidate="txtFchInicial" ForeColor=" ">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" CssClass="fd" Width="75px" ></asp:textbox>
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" Width="18px" Height="8px"
										ControlToValidate="txtFchFinal" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 102px">&nbsp;Tipo visita</TD>
								<TD style="WIDTH: 286px">
									<asp:radiobutton id="rbEntrada" runat="server" Checked="True" GroupName="Grupo1" Text="Entrada"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbSalida" runat="server" GroupName="Grupo1" Text="Salida"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 102px"></TD>
								<TD style="WIDTH: 286px">
									<asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 652px"><asp:label id="lblmsg" runat="server"  CssClass="msg" Width="568px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 750px"><asp:datagrid id="dgLista" runat="server" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"
							  Height="17px" BorderColor="CadetBlue" CssClass="Grid" Width="750px" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchVisita" SortExpression="FchVisita" HeaderText="Visita" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HoraVisita" SortExpression="HoraVisita" HeaderText="Hora">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodResponsable" SortExpression="CodResponsable" HeaderText="Responsable">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="NomEvaluacion" HeaderText="Evaluaci&#243;n">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NomEvaluacion")%>' NavigateUrl='<%# "cpcVisitasConsultaDet.aspx?NroPedido=" + cstr(DataBinder.Eval(Container.DataItem,"NroPedido"))+"&TipoVisita="+DataBinder.Eval(Container.DataItem,"TipoVisita")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="StsVisit" SortExpression="StsVisit" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsVisita" SortExpression="StsVisita" HeaderText="StsVisita">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoVisita" HeaderText="TipoVisita">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantDiaLibre" SortExpression="CantDiaLibre" HeaderText="Dia Libre" DataFormatString="{0:##.####}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
                                <asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email"></asp:BoundColumn>								
								<asp:BoundColumn DataField="Idioma" SortExpression="Idioma" HeaderText="Idioma" >
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 652px">&nbsp;</TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
