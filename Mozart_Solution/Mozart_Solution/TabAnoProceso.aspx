<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabAnoProceso.aspx.vb" Inherits="TabAnoProceso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 460px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				cellSpacing="0" cellPadding="1" width="460" border="0" class="form">
				<TR>
					<TD style="WIDTH: 467px">
						<P class="Titulo">&nbsp;Año de Proceso</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 462px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="462" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 64px"><FONT size="2">&nbsp;Año</FONT></TD>
								<TD><asp:textbox id="txtAnoProceso" runat="server" Width="73px" MaxLength="4"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ControlToValidate="txtAnoProceso"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Estado</TD>
								<TD>
                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="120px">
                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp; Consulta</TD>
								<TD>
                                    <asp:DropDownList ID="ddlConsulta" runat="server" Width="120px">
                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" CssClass="msg" 
                            Width="451px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgLista" runat="server" AllowSorting="True" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" Height="17px"  Width="460px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="anoproceso" SortExpression="anoproceso" HeaderText="A&#241;o">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="stsanoproceso" SortExpression="stsanoproceso" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="stsConsulta" SortExpression="stsConsulta" HeaderText="Consulta">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
