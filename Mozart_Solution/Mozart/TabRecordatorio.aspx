<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabRecordatorio.aspx.vb" Inherits="TabRecordatorio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 608px; POSITION: absolute; TOP: 8px; HEIGHT: 93px"
				cellSpacing="0" cellPadding="1" width="608" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Recordatorio</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 608px; HEIGHT: 96px" cellSpacing="0" cellPadding="0"
							width="608" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 79px; HEIGHT: 16px">Zona Venta</TD>
								<TD style="HEIGHT: 16px">
									<asp:dropdownlist id="ddlZonaVta" runat="server" DataValueField="CodZonaVta" DataTextField="NomZonaVta"
										AutoPostBack="True" Width="224px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 79px; HEIGHT: 14px">&nbsp;Idioma</TD>
								<TD style="HEIGHT: 14px">
									<asp:radiobutton id="rbtIngles" runat="server" GroupName="grupo3" Text="Ingles"></asp:radiobutton>
									<asp:radiobutton id="rbtEspanol" runat="server" GroupName="grupo3" Text="Español"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 79px; HEIGHT: 8px"><FONT size="2">&nbsp;Número</FONT></TD>
								<TD style="HEIGHT: 8px">
									<asp:textbox id="txtCodigo" runat="server" Width="47px" MaxLength="3"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 79px; HEIGHT: 11px">&nbsp;Descripción</TD>
								<TD style="HEIGHT: 11px">
									<asp:textbox id="txtDescripcion" runat="server" Width="424px" MaxLength="100"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtDescripcion" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 79px; HEIGHT: 4px">&nbsp;Días</TD>
								<TD style="HEIGHT: 4px">
									<asp:textbox id="txtDias" runat="server" Width="37px" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 79px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" GroupName="Grupo1" Text="Activo" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" CssClass="msg" Height="17px" Width="536px"></asp:label></TD>
				</TR>
				<TR>
					<TD>Mostrar
						<asp:dropdownlist id="ddlListaZonaVta" runat="server" Width="224px" AutoPostBack="True" DataTextField="NomZonaVta"
							DataValueField="CodZonaVta"></asp:dropdownlist>&nbsp;
						<asp:RadioButton id="rbtListaIng" runat="server" Text="Ingles" GroupName="g4" Checked="True" AutoPostBack="True"></asp:RadioButton>&nbsp;
						<asp:RadioButton id="rbtListaEsp" runat="server" Text="Español" GroupName="g4" AutoPostBack="True"></asp:RadioButton></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLista" runat="server" AllowSorting="True" CssClass="Grid" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" Height="17px" 
							Width="750px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodZonaVta" SortExpression="CodZonaVta" HeaderText="Zona"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomIdioma" SortExpression="NomIdioma" HeaderText="Idioma"></asp:BoundColumn>
								<asp:BoundColumn DataField="NroRecordatorio" SortExpression="NroRecordatorio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesRecordatorio" SortExpression="DesRecordatorio" HeaderText="Descripci&#243;n">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Edit" EditText="Editar"></asp:EditCommandColumn>
								<asp:BoundColumn DataField="NroDias" SortExpression="NroDias" HeaderText="D&#237;as">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DatoBase" SortExpression="DatoBase" HeaderText="Dato Base">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomstsRecordatorio" SortExpression="NomstsRecordatorio" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
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
