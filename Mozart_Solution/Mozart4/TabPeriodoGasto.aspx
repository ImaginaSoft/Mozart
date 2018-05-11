<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabPeriodoGasto.aspx.vb" Inherits="TabPeriodoGasto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Periodo de Gasto</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 462px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="462" border="1">
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px"><FONT size="2">&nbsp;Fecha de inicio</FONT></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 26px">&nbsp;Fecha de termino</TD>
								<TD style="HEIGHT: 26px"><asp:textbox id="txtFchFinal" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Tipo de cambio</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtTipoCambio" runat="server" MaxLength="7" Width="88px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px">&nbsp;Estado</TD>
								<TD><asp:radiobutton id="rbtIngresado" runat="server" Checked="True" GroupName="Grupo1" Text="Ingresado"></asp:radiobutton>&nbsp;&nbsp;<asp:radiobutton id="rbtAbierto" runat="server" GroupName="Grupo1" Text="Abierto"></asp:radiobutton>&nbsp;&nbsp; 
									&nbsp;
									<asp:radiobutton id="rbtCerrado" runat="server" GroupName="Grupo1" Text="Cerrado"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="451px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgLista" runat="server" Width="584px" CssClass="Grid" Height="17px"  
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FchIniPeriodo" SortExpression="FchIniPeriodo" HeaderText="Inicio" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFinPeriodo" SortExpression="FchFinPeriodo" HeaderText="Termino" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsPeriodo" SortExpression="NomStsPeriodo" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoCambio" SortExpression="TipoCambio" HeaderText="Tipo Cambio">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="StsPeriodo" HeaderText="StsPeriodo">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
