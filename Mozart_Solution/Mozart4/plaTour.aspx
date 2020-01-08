<%@ Page Language="VB" AutoEventWireup="false" CodeFile="plaTour.aspx.vb" Inherits="plaTour" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 707px; POSITION: absolute; TOP: 8px; HEIGHT: 40px"
				cellSpacing="0" cellPadding="0" width="707" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">
						&nbsp;Tours</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 9px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 704px; HEIGHT: 104px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="704" border="1">
							<TR>
								<TD style="WIDTH: 193px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD><asp:textbox id="txtCodTour" runat="server" MaxLength="3" Width="73px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 193px">&nbsp;Nombre&nbsp;Tour</TD>
								<TD><asp:textbox id="txtNomTour" runat="server" Width="424px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 193px; HEIGHT: 7px">&nbsp;Clasificación Tour</TD>
								<TD style="HEIGHT: 7px"><asp:textbox id="txtClasificaTour" runat="server" MaxLength="100" Width="424px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 193px; HEIGHT: 18px">&nbsp;Cantidad días</TD>
								<TD style="HEIGHT: 18px"><asp:textbox id="txtCantDias" runat="server" Width="64px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 193px; HEIGHT: 18px">&nbsp;Idioma</TD>
								<TD style="HEIGHT: 18px"><asp:dropdownlist id="ddlIdioma" runat="server" Width="128px" DataTextField="NomIdioma" DataValueField="Idioma"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 193px">&nbsp;Estado</TD>
								<TD><asp:radiobutton id="rbActivo" runat="server" Checked="True" GroupName="Grupo1" Text="Activo"></asp:radiobutton><asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo1" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" Width="451px" 
                            CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgTour" runat="server" Width="792px" CssClass="Grid" Height="17px" CellPadding="2"
							BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTour" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomTour" HeaderText="Tour">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ClasificaTour" HeaderText="Clasificaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="Idioma" HeaderText="Idioma">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantDias" HeaderText="Dias">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPlantilla" HeaderText="N&#176;Plantilla">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsTour" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Plantillas"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
