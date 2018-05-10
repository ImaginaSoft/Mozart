<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidoPasajero.aspx.vb" Inherits="VtaPedidoPasajero" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 26px;
            width: 100px;
        }
        .style2
        {
            width: 100px;
        }
        .style3
        {
            height: 28px;
            width: 100px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 682px; POSITION: absolute; TOP: 8px; HEIGHT: 23px"
				cellSpacing="0" cellPadding="1" width="682" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Pasajeros</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 595px; HEIGHT: 94px" 
                            cellSpacing="0" cellPadding="0" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 93px; HEIGHT: 26px">Nombre</TD>
								<TD style="HEIGHT: 26px">
									<asp:textbox id="txtNombre" runat="server" MaxLength="50" Width="203px"></asp:textbox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="*" ControlToValidate="txtNombre"
										CssClass="error"></asp:requiredfieldvalidator></TD>
								<TD class="style1">&nbsp;Fecha Nac</TD>
								<TD style="HEIGHT: 26px">
									<asp:textbox id="txtFchNacimiento" runat="server" Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" style="WIDTH: 26px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchNacimiento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:button id="btnlimpiafecha" runat="server" Width="57px" Text="Limpiar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px">Género</TD>
								<TD>
									<asp:dropdownlist id="ddlGenero" runat="server" Width="120px">
                                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:dropdownlist></TD>
								<TD class="style2">Tipo Pasajero</TD>
								<TD>
									<asp:dropdownlist id="ddltipopasajero" runat="server" Width="163px" DataValueField="CodTipoPasajero"
										DataTextField="TipoPasajero"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px">Pasaporte</TD>
								<TD>
									<asp:textbox id="txtPasaporte" runat="server" MaxLength="50" Width="203px"></asp:textbox></TD>
								<TD class="style2">Nacionalidad</TD>
								<TD>
									<asp:dropdownlist id="ddlpais" runat="server" Width="164px" DataValueField="CodPais" DataTextField="NomPais"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px; HEIGHT: 28px">Idioma</TD>
								<TD style="HEIGHT: 28px">
									<asp:textbox id="txtDesIdioma" runat="server" MaxLength="50" Width="203px"></asp:textbox></TD>
								<TD class="style3">Acomodación</TD>
								<TD style="HEIGHT: 28px">
									<asp:textbox id="txtAcomodacion" runat="server" Width="32px" MaxLength="2"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px; HEIGHT: 28px">Tipo habitación</TD>
								<TD style="HEIGHT: 28px" colspan="3">
									<asp:textbox id="txtDesHabitacion" runat="server" MaxLength="50" Width="380px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px; HEIGHT: 28px">Observación</TD>
								<TD style="HEIGHT: 28px" colspan="3">
									<asp:textbox id="txtObservaciones" runat="server" MaxLength="50" Width="380px"></asp:textbox></TD>
							</TR>
							</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 10px">&nbsp;
						<asp:Label id="lblCodigo" runat="server" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" CssClass="error" Width="376px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 22px">&nbsp;
						<asp:datagrid id="dgPasajero" runat="server" CssClass="Grid" AutoGenerateColumns="False" BorderColor="CadetBlue"
							BorderWidth="1px" CellPadding="2" Height="17px"   Width="790px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPasajero" SortExpression="NroPasajero" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" SortExpression="NomPasajero" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoPasajero" SortExpression="TipoPasajero" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Acomodacion" HeaderText="Acomoda">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="Observaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="Pasaporte" SortExpression="Pasaporte" HeaderText="Pasaporte"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPais" SortExpression="NomPais" HeaderText="Nacionalidad"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchNacimiento" SortExpression="FchNacimiento" HeaderText="Fecha Nac."
									DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTipoPasajero" SortExpression="CodTipoPasajero">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Nacionalidad" SortExpression="Nacionalidad">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" SortExpression="FchSys" HeaderText="Modificado"
									DataFormatString="{0:dd-MM-yyyy HH:mm}">
									<ItemStyle ></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodGenero" SortExpression="CodGenero" HeaderText="Género"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesIdioma" SortExpression="DesIdioma" HeaderText="Idioma"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesHabitacion" SortExpression="DesHabitacion" HeaderText="Habitacion"></asp:BoundColumn>

							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
