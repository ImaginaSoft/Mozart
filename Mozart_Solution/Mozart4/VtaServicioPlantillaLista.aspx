<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioPlantillaLista.aspx.vb" Inherits="VtaServicioPlantillaLista" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="dgPlantilla" style="Z-INDEX: 101; LEFT: 14px; POSITION: absolute; TOP: 115px"
				runat="server" AllowSorting="True" CssClass="Grid" Width="582px" CellPadding="2" BorderWidth="1px"
				BorderColor="CadetBlue" Height="25px" AutoGenerateColumns="False">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Editar" HeaderText="Plantilla" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="NroPlantilla" SortExpression="NroPlantilla" HeaderText="Nro.">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DesPlantilla" SortExpression="DesPlantilla" HeaderText="Titulo"></asp:BoundColumn>
					<asp:BoundColumn DataField="CantDias" SortExpression="CantDias" HeaderText="Dias">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
					<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
					<asp:BoundColumn DataField="NomStsPlantilla" HeaderText="Estado"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<TABLE id="Table3" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 584px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="584"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Lista de Plantillas asociadas al Servicio</P>
					</TD>
				</TR>
			</TABLE>
			<asp:label id="lblMsg" 
                style="Z-INDEX: 102; LEFT: 13px; POSITION: absolute; TOP: 93px" runat="server"
				CssClass="MSG" Width="387px"></asp:label>
			<asp:Label id="lblServicio" style="Z-INDEX: 105; LEFT: 17px; POSITION: absolute; TOP: 46px"
				runat="server" Height="3px" Font-Bold="True"></asp:Label>
		</form>
</body>
</html>
