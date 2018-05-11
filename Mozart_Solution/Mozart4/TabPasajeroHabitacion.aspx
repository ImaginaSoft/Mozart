<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabPasajeroHabitacion.aspx.vb" Inherits="TabPasajeroHabitacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 345px"
				cellSpacing="0" cellPadding="1" width="600" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 520px; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
							width="520" border="0">
							<TR>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 416px; HEIGHT: 120px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="416" border="0">
										<TR>
											<TD style="HEIGHT: 16px"></TD>
											<TD style="HEIGHT: 16px"><asp:label id="Label1" runat="server">Simple</asp:label></TD>
											<TD style="HEIGHT: 16px"><asp:label id="Label5" runat="server">Doble</asp:label></TD>
											<TD style="HEIGHT: 16px"><asp:label id="Label3" runat="server">Triple</asp:label></TD>
											<TD style="HEIGHT: 16px"><asp:label id="Label4" runat="server">Cuadruple</asp:label></TD>
											<TD style="WIDTH: 32px; HEIGHT: 16px">
												<asp:label id="Label8" runat="server">Total</asp:label></TD>
											<TD style="HEIGHT: 16px"></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label6" runat="server">Adultos</asp:label></TD>
											<TD><asp:textbox id="txtAduSGL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAduDBL" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAduTPL" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtAduCDL" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD style="WIDTH: 32px">
												<asp:textbox id="txtADT" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>ADT</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label7" runat="server">Niños</asp:label></TD>
											<TD><asp:textbox id="txtNinSGL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNinDBL" tabIndex="11" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNinTPL" tabIndex="12" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtNinCDL" tabIndex="13" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD style="WIDTH: 32px">
												<asp:textbox id="txtCHD" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD>CHD</TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD style="WIDTH: 32px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>SGL</TD>
											<TD>DBL</TD>
											<TD>TPL</TD>
											<TD>CDL</TD>
											<TD style="WIDTH: 32px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label2" runat="server">Total</asp:label></TD>
											<TD><asp:textbox id="txtSGL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtDBL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtTPL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD><asp:textbox id="txtCDL" tabIndex="10" runat="server" Width="35px" MaxLength="2"></asp:textbox></TD>
											<TD style="WIDTH: 32px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
								<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 7px"><asp:button id="cmdBusca" runat="server" Width="184px" Text="Mostrar combinaciones para "></asp:button><asp:textbox id="txtCantAdultos" tabIndex="10" runat="server" Width="40px" MaxLength="2">4</asp:textbox>&nbsp;adultos 
						y
						<asp:textbox id="txtCantNinos" tabIndex="10" runat="server" Width="40px" MaxLength="2">2</asp:textbox>&nbsp;niños</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="528px" CssClass="msg" Height="17px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dglista" runat="server" Width="600px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CantAdultos" SortExpression="CantAdultos" HeaderText="ADT">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinos" SortExpression="CantNinos" HeaderText="CHD">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantSimple" SortExpression="CantSimple" HeaderText="SGL">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantDoble" SortExpression="CantDoble" HeaderText="DBL">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantTriple" SortExpression="CantTriple" HeaderText="TPL">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantCuadruple" SortExpression="CantCuadruple" HeaderText="CDL">
									<ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAduSGL" SortExpression="CantAduSGL" HeaderText="AduSGL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAduDBL" SortExpression="CantAduDBL" HeaderText="AduDBL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAduTPL" SortExpression="CantAduTPL" HeaderText="AduTPL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAduCDL" SortExpression="CantAduCDL" HeaderText="AduCDL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinSGL" SortExpression="CantNinSGL" HeaderText="NinSGL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinDBL" SortExpression="CantNinDBL" HeaderText="NinDBL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinTPL" SortExpression="CantNinTPL" HeaderText="NinTPL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantNinCDL" SortExpression="CantNinCDL" HeaderText="NinCDL">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="KeyReg" HeaderText="KeyReg">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Fchsys" HeaderText="Actualizado">
									<ItemStyle Wrap="False"></ItemStyle>
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
