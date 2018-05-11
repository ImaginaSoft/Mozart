<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaServicioInf.aspx.vb" Inherits="VtaServicioInf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 795px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="0" cellPadding="1" width="795" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 792px; HEIGHT: 12px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="792" border="1">
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Tipo</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlTipoInformacion" runat="server" AutoPostBack="True" DataTextField="NomTipoInfEsp"
										DataValueField="NroTipoInf" Width="344px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Nivel</TD>
								<TD style="HEIGHT: 17px">
									<asp:radiobutton id="rbZonaVta" runat="server" AutoPostBack="True" Text="Zona Venta" Checked="True"
										GroupName="Grupo2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbCiudad" runat="server" AutoPostBack="True" Text="Ciudad" GroupName="Grupo2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbServicio" runat="server" AutoPostBack="True" Text="Nro Servicio" GroupName="Grupo2"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Información</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlInformacion" runat="server" AutoPostBack="True" DataTextField="NomInfEsp"
										DataValueField="NroInformacion" Width="648px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="528px" 
                            CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dglista" runat="server" Width="792px" Height="17px" CssClass="Grid"  
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomTipoInfEsp" SortExpression="NomTipoInfEsp" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nivel" SortExpression="Nivel" HeaderText="Nivel"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroInformacion" SortExpression="NroInformacion" HeaderText="Nro ">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomInfEsp" SortExpression="NomInfEsp" HeaderText="Nombre Espa&#241;ol">
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
