<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabParametro.aspx.vb" Inherits="tabParametro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 712px; POSITION: absolute; TOP: 8px; HEIGHT: 210px"
				borderColor="#cccccc" cellSpacing="0" cellPadding="0" width="712" border="0" class="form">
				<TR>
					<TD class="Titulo">Parámetros generales del sistema</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="311px" Height="9px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLista" runat="server" Width="928px"   Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="#CCCCCC" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="descCampo" SortExpression="descCampo" HeaderText="Descripci&#243;n">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ValorCampo" SortExpression="ValorCampo" HeaderText="Valor"></asp:BoundColumn>
								<asp:BoundColumn DataField="TextoCampo" SortExpression="TextoCampo" HeaderText="Texto"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Actualizado">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagModifica" HeaderText="FlagModifica">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCampo" SortExpression="NomCampo" HeaderText="Parametro">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
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
