<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioTarifaPeriodo.aspx.vb" Inherits="VtaServicioTarifaPeriodo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="0" width="460" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Periodos de la Tarifa</TD>
				</TR>
				<TR>
					<TD class="opciones" style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtTarifas" runat="server">Regresar Tarifas</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 656px; HEIGHT: 208px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Proveedor</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblNomProveedor" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Ciudad</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblNomCiudad" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Tipo Servicio</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblTipoServicio" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Servicio</TD>
								<TD style="HEIGHT: 25px"><asp:label id="lblDesServicio" runat="server" Width="456px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Código Tarifa</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtCodTarifa" runat="server" Width="72px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px"><FONT size="2">&nbsp;Fecha de inicio</FONT></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtFchInicial" runat="server"  CssClass="fd" Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 26px">&nbsp;Fecha de termino</TD>
								<TD style="HEIGHT: 26px"><asp:textbox id="txtFchFinal" runat="server"  CssClass="fd" Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 25px">&nbsp;Descripción</TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtDesTarifa" runat="server" Width="320px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" CssClass="msg" 
                            Width="632px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgLista" runat="server" CssClass="Grid" Width="656px" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTarifa" SortExpression="CodTarifa" HeaderText="C&#243;digo Tarifa">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchIniTarifa" SortExpression="FchIniTarifa" HeaderText="Inicio" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFinTarifa" SortExpression="FchFinTarifa" HeaderText="Termino" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesTarifa" SortExpression="DesTarifa" HeaderText="Descripci&#243;n">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar " CommandName="delete"></asp:ButtonColumn>
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
