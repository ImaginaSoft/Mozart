<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabTarea.aspx.vb" Inherits="TabTarea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 105; LEFT: 8px; WIDTH: 717px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="717" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Tarea</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 527px; HEIGHT: 72px" cellSpacing="0" cellPadding="0"
							width="527" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 94px"><FONT size="2">&nbsp;Número</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="47px" MaxLength="2"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 94px">&nbsp;Descripción</TD>
								<TD><asp:textbox id="txtDescripcion" runat="server" Width="289px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtDescripcion" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 94px">&nbsp;Días</TD>
								<TD>
									<asp:TextBox id="txtDias" runat="server" Width="37px" MaxLength="3"></asp:TextBox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="error" ControlToValidate="txtDias"
										ErrorMessage="Dato Obligatorio" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 94px">&nbsp;Dato Base</TD>
								<TD>
									<asp:DropDownList id="ddlDatoBase" runat="server" Width="288px" DataValueField="CodDatoBase" DataTextField="DatoBase"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 94px; HEIGHT: 25px">&nbsp;Area
								</TD>
								<TD style="HEIGHT: 25px">
									<asp:dropdownlist id="ddlArea" runat="server" Width="288px" AutoPostBack="True" DataTextField="NomArea"
										DataValueField="CodArea"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 94px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="528px" Height="17px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgTarea" runat="server" Width="718px"  Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroTarea" SortExpression="NroTarea" HeaderText="N&#250;mero">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesTarea" SortExpression="DesTarea" HeaderText="Descripci&#243;n">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDias" SortExpression="NroDias" HeaderText="D&#237;as">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DatoBase" SortExpression="DatoBase" HeaderText="Dato Base">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="stsTarea" SortExpression="stsTarea" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodArea" SortExpression="CodArea" HeaderText="Area"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
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
