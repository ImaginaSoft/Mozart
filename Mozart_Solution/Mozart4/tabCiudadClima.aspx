<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabCiudadClima.aspx.vb" Inherits="tabCiudadClima" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 616px; POSITION: absolute; TOP: 8px; HEIGHT: 341px"
				cellSpacing="0" cellPadding="1" width="616" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 616px; HEIGHT: 80px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="616" border="1">
							<TR>
								<TD style="WIDTH: 151px; HEIGHT: 17px">&nbsp;Mes</TD>
								<TD style="HEIGHT: 17px">
									<asp:TextBox id="txtNroMes" runat="server" Width="40px" MaxLength="2"></asp:TextBox>&nbsp;
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" CssClass="error" ForeColor=" " ErrorMessage="obligatorio"
										ControlToValidate="txtNroMes"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 151px; HEIGHT: 17px">&nbsp;Temperatura mínima</TD>
								<TD style="HEIGHT: 17px">
									<asp:TextBox id="txtTempMinima" runat="server" Width="304px" MaxLength="30"></asp:TextBox>&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" ForeColor=" " ErrorMessage="obligatorio"
										ControlToValidate="txtTempMinima"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 151px; HEIGHT: 17px">&nbsp;Temperatura máxima&nbsp;</TD>
								<TD style="HEIGHT: 17px">
									<asp:TextBox id="txtTempMaxima" runat="server" Width="304px" MaxLength="30"></asp:TextBox>&nbsp;
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" ForeColor=" " ErrorMessage="obligatorio"
										ControlToValidate="txtTempMaxima"></asp:requiredfieldvalidator></TD>
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
					<TD style="WIDTH: 467px"><asp:datagrid id="dglista" runat="server" Width="616px" CssClass="Grid" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCiudad" SortExpression="CodCiudad" HeaderText="Ciudad">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroMes" SortExpression="NroMes" HeaderText="Mes">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TempMinima" SortExpression="TempMinima" HeaderText="Temperatura m&#237;nima">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TempMaxima" SortExpression="TempMaxima" HeaderText="Temperatura m&#225;xima">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
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
