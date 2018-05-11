<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaBusca.aspx.vb" Inherits="VtaPlantillaBusca" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 584px; POSITION: absolute; TOP: 8px; HEIGHT: 112px"
				cellSpacing="0" cellPadding="1" width="584" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Busca Plantilla</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table4" style="WIDTH: 656px; HEIGHT: 10px" cellSpacing="0" cellPadding="0"
							width="656" border="0">
							<TR>
								<TD style="WIDTH: 326px">Zona Venta
									<asp:dropdownlist id="ddlZonaVta" runat="server" AutoPostBack="True" DataValueField="CodZonaVta" DataTextField="NomZonaVta"
										Width="208px"></asp:dropdownlist></TD>
								<TD>Estado
									<asp:radiobutton id="rbtActivo" runat="server" Text="Activo" GroupName="g1" Checked="True"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtInactivo" runat="server" Text="Inactivo" GroupName="g1"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtTodos" runat="server" Text="Todos" GroupName="g1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 656px; HEIGHT: 100px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="656" border="1">
							<TR>
								<TD style="WIDTH: 356px; HEIGHT: 25px"><asp:radiobutton id="rbtTitulo" runat="server" Width="172px" Height="10px" Text="Por Titulo de la Plantilla"
										GroupName="grupo1" Checked="True"></asp:radiobutton></TD>
								<TD style="WIDTH: 195px; HEIGHT: 25px"><asp:radiobutton id="rbtNroPlantilla" runat="server" Width="120px" Text="Por Nro. Plantilla" GroupName="grupo1"></asp:radiobutton></TD>
								<TD style="WIDTH: 195px; HEIGHT: 25px"><asp:radiobutton id="rbtFlag" runat="server" Width="120px" Text="Tipo de Plantilla" GroupName="grupo1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 356px; HEIGHT: 62px">
									<TABLE class="tabla" id="Table2" style="LEFT: 4px; TOP: 7px" cellSpacing="1" cellPadding="1"
										width="300" border="0">
										<TR>
											<TD>Titulo</TD>
											<TD><asp:textbox id="txtTitulo" runat="server" Width="238px" MaxLength="80"></asp:textbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD>Dias</TD>
											<TD><asp:textbox id="txtCantDias" runat="server" Width="59px" MaxLength="3"></asp:textbox><asp:label id="lblError1" runat="server" Width="131px" Height="17px" CssClass="error"></asp:label></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 195px; HEIGHT: 62px" vAlign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtNroPlantilla" runat="server" Width="59px" MaxLength="8"></asp:textbox><asp:label id="lblerror2" runat="server" Width="110px" Height="17px" CssClass="error"></asp:label></TD>
								<TD style="WIDTH: 195px; HEIGHT: 62px" vAlign="top">
									<asp:dropdownlist id="ddlTipoPlantilla" runat="server" Width="208px" DataTextField="NomElemento" DataValueField="CodElemento"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<asp:button id="cmdBuscar" runat="server" Width="71px" Text="Buscar"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px"><asp:label id="lblMsg" runat="server" Width="387px" Height="17px" CssClass="MSG"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgPlantilla" runat="server" Width="800px" Height="25px" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" AllowSorting="True">
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
								<asp:BoundColumn DataField="NomTipoPlantilla" SortExpression="NomTipoPlantilla" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCateTour" SortExpression="NomCateTour" HeaderText="Categoria"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchAct" SortExpression="FchAct" HeaderText="Actualizado"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsPlantilla" SortExpression="NomStsPlantilla" HeaderText="Estado"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
