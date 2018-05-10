<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabPlanTarifario.aspx.vb" Inherits="TabPlanTarifario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 345px"
				cellSpacing="0" cellPadding="1" width="600" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">
						<asp:Label id="lblTitulo" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 584px; HEIGHT: 119px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="584" border="1">
							<TR>
								<TD style="WIDTH: 89px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD>
									<asp:textbox id="txtCodigo" runat="server" MaxLength="3" Width="73px"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Nombre</TD>
								<TD>
									<asp:textbox id="txtNombre" runat="server" MaxLength="50" Width="289px"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtNombre" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 28px">&nbsp;%Utilidad&nbsp;</TD>
								<TD style="HEIGHT: 28px">
									<asp:textbox id="txtPorcen1" runat="server" MaxLength="3" Width="56px"></asp:textbox>año 
									actual&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtPorcen2" runat="server" Width="56px" MaxLength="3"></asp:textbox>sgtes. 
									años</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:label id="lblMsg" runat="server" Width="528px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<asp:datagrid id="dglista" runat="server" Width="600px"   Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodPlanTarifario" SortExpression="CodPlanTarifario" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomPlanTarifario" SortExpression="NomPlanTarifario" HeaderText="Nombre">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PorUtilidadAnoActual" SortExpression="PorUtilidad" HeaderText="% Utilidad a&#241;o actual"
									DataFormatString="{0:###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PorUtilidadSgtesAnos" SortExpression="PorUtilidadSgtesAnos" HeaderText="% Utilidad sgtes. a&#241;os"
									DataFormatString="{0:###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsPlanTarifario" SortExpression="NomStsPlanTarifario" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
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
