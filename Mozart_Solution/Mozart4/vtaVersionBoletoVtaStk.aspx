<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaVersionBoletoVtaStk.aspx.vb" Inherits="vtaVersionBoletoVtaStk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 576px; POSITION: absolute; TOP: 0px; HEIGHT: 8px"
				cellSpacing="0" cellPadding="1" width="576" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Boletos en el Stock de Comprados</P>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="form" id="Table6" style="Z-INDEX: 107; LEFT: 8px; WIDTH: 624px; POSITION: absolute; TOP: 317px; HEIGHT: 7px"
				cellSpacing="0" cellPadding="0" width="624" border="0">
				<TR>
					<TD><asp:datagrid id="dgPasajeros" runat="server" DESIGNTIMEDRAGDROP="135" Width="621px" Height="17px"
							CssClass="Grid" BorderColor="CadetBlue" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodLinea" HeaderText="Linea"></asp:BoundColumn>
								<asp:BoundColumn DataField="Forma" HeaderText="Forma"></asp:BoundColumn>
								<asp:BoundColumn DataField="Serie" HeaderText="Serie"></asp:BoundColumn>
								<asp:BoundColumn DataField="Cupon" HeaderText="Cupon">
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsUbica" HeaderText="Ubica">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoPasajero" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Emisi&#243;n" DataFormatString="{0:dd-MM-yy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ruta" HeaderText="Ruta"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" HeaderText="Stock" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="Proveedor">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table5" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 576px; POSITION: absolute; TOP: 37px; HEIGHT: 8px"
				cellSpacing="1" cellPadding="1" width="576" border="1">
				<TR>
					<TD style="WIDTH: 62px">&nbsp;Proveedor</TD>
					<TD style="WIDTH: 128px"><asp:dropdownlist id="ddlProveedor" runat="server" 
                            Width="146px" AutoPostBack="True"
							DataValueField="CodProveedor" DataTextField="NomProveedor"></asp:dropdownlist></TD>
					<TD style="WIDTH: 40px">&nbsp;Forma</TD>
					<TD class="tabla" style="WIDTH: 72px"><asp:textbox id="txtForma" runat="server" Width="54px" MaxLength="4"></asp:textbox></TD>
					<TD style="WIDTH: 35px">&nbsp;Serie</TD>
					<TD style="WIDTH: 79px"><asp:textbox id="txtSerie" runat="server" Width="61px"></asp:textbox></TD>
					<TD>Cupon
					</TD>
					<TD><asp:textbox id="txtCupon" runat="server" Width="27px" MaxLength="1"></asp:textbox></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table4" style="Z-INDEX: 105; LEFT: 352px; WIDTH: 232px; POSITION: absolute; TOP: 77px; HEIGHT: 148px"
				cellSpacing="1" cellPadding="1" width="232" border="1">
				<TR>
					<TD style="WIDTH: 151px" colSpan="2">&nbsp;Tarifa Neta&nbsp;
						<asp:label id="Label1" runat="server" CssClass="ERROR">(TAB's)</asp:label></TD>
					<TD><asp:textbox id="txttarifa" runat="server" Width="75px" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px">&nbsp;IGV</TD>
					<TD style="WIDTH: 55px"><asp:textbox id="txtporigv" runat="server" Width="33px" AutoPostBack="True"></asp:textbox>&nbsp;%</TD>
					<TD><asp:textbox id="txtIGV" runat="server" Width="74px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 151px" colSpan="2">&nbsp;Otros</TD>
					<TD><asp:textbox id="txtotros" runat="server" Width="74px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px">&nbsp;Comisión 1</TD>
					<TD style="WIDTH: 55px"><asp:textbox id="txtporcom1" runat="server" Width="33px" AutoPostBack="True"></asp:textbox>&nbsp;%</TD>
					<TD><asp:textbox id="txtcom1" runat="server" Width="74px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px">&nbsp;Comisión 2</TD>
					<TD style="WIDTH: 55px"><asp:textbox id="txtporcom2" runat="server" Width="33px" AutoPostBack="True"></asp:textbox>&nbsp;%</TD>
					<TD><asp:textbox id="txtcom2" runat="server" Width="74px"></asp:textbox></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table2" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 336px; POSITION: absolute; TOP: 77px; HEIGHT: 230px"
				cellSpacing="1" cellPadding="1" width="336" border="1">
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Linea Aerea</TD>
					<TD><asp:dropdownlist id="ddlLineaAerea" runat="server" Width="176px" DataValueField="CodLinea"
							DataTextField="NomLinea"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Pasajero</TD>
					<TD><asp:dropdownlist id="ddlTipoPasajero" runat="server" Width="107px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Fecha Emisión</TD>
					<TD><asp:textbox id="txtFchEmision" runat="server" Width="81px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchEmision"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Nombre Pasajero</TD>
					<TD><asp:textbox id="txtNomPasajero" runat="server" Width="215px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Ruta</TD>
					<TD><asp:textbox id="txtruta" runat="server" Width="215px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Observación</TD>
					<TD><asp:textbox id="txtobserv" runat="server" Width="214px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Forma Pago</TD>
					<TD><asp:radiobutton id="rbContado" runat="server" GroupName="Grupo1" Text="Contado" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:radiobutton id="rbCredito" runat="server" GroupName="Grupo1" Text="Crédito"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Boleto</TD>
					<TD><asp:radiobutton id="rbPrincipal" runat="server" GroupName="Grupo2" Text="Principal" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:radiobutton id="rbconexion" runat="server" GroupName="Grupo2" Text="Conexión"></asp:radiobutton></TD>
				</TR>
			</TABLE>
			<asp:label id="lblmsg" 
                style="Z-INDEX: 102; LEFT: 352px; POSITION: absolute; TOP: 277px" runat="server"
				Width="224px" CssClass="error"></asp:label>
            <asp:button id="cmdGrabar" style="Z-INDEX: 104; LEFT: 352px; POSITION: absolute; TOP: 232px; "
				runat="server" Width="78px" Text="Grabar"></asp:button>
				
            	
				
				</form>
</body>
</html>
