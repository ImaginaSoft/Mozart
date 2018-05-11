<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaVersionBoletoVta.aspx.vb" Inherits="vtaVersionBoletoVta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        #Form1
        {
            width: 581px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">



			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="576" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Datos del Boleto</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones">&nbsp;&nbsp;<asp:linkbutton id="lbtPagoConRemision" runat="server"></asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbkStkComprados" runat="server">Ingresar Boleto al Stock de Comprados</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="opciones">
					
			<TABLE class="tabla" id="Table5" 
				cellSpacing="1" cellPadding="1" width="576" border="1">
				<TR>
					<TD style="WIDTH: 62px">&nbsp;Proveedor</TD>
					<TD style="WIDTH: 128px"><asp:dropdownlist id="ddlProveedor" runat="server" 
                            Width="146px" DataTextField="NomProveedor"
							DataValueField="CodProveedor" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD style="WIDTH: 40px">&nbsp;Forma</TD>
					<TD class="tabla" style="WIDTH: 72px"><asp:dropdownlist id="ddlForma" 
                            runat="server" Width="71px" DataTextField="Forma" DataValueField="Forma"
							AutoPostBack="True"></asp:dropdownlist></TD>
					<TD style="WIDTH: 35px">&nbsp;Serie</TD>
					<TD style="WIDTH: 79px"><asp:dropdownlist id="ddlSerie" runat="server"  Width="78px" DataTextField="Serie" DataValueField="Serie"
							AutoPostBack="True"></asp:dropdownlist></TD>
					<TD>&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 62px">&nbsp;&nbsp;</TD>
					<TD style="WIDTH: 128px"><asp:textbox id="txtProveedor" runat="server" Width="71px" MaxLength="3"></asp:textbox></TD>
					<TD style="WIDTH: 40px">&nbsp;
					</TD>
					<TD class="tabla" style="WIDTH: 72px"><asp:textbox id="txtForma" runat="server" Width="54px" MaxLength="4"></asp:textbox></TD>
					<TD style="WIDTH: 35px">&nbsp;
					</TD>
					<TD style="WIDTH: 79px"><asp:textbox id="txtSerie" runat="server" Width="61px"></asp:textbox></TD>
					<TD><asp:button id="cmdBuscar" runat="server" Width="76px" Text="Buscar"></asp:button></TD>
				</TR>
			</TABLE>
					
					</TD>
				</TR>
				<TR>
					<TD class="opciones">
					
			<TABLE class="tabla" id="Table2" style="Z-INDEX: 103; LEFT: 12px; WIDTH: 336px; POSITION: absolute; TOP: 153px; HEIGHT: 230px"
				cellSpacing="1" cellPadding="1" width="336" border="1">
				<TR>
					<TD style="WIDTH: 107px" colSpan="1">&nbsp;Estado&nbsp;Boleto</TD>
					<TD><asp:dropdownlist id="ddlEstadoBoleto" runat="server" Width="105px" 
                            AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Linea Aerea</TD>
					<TD><asp:dropdownlist id="ddlLineaAerea" runat="server" Width="176px" DataTextField="NomLinea"
							DataValueField="CodLinea"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Pasajero</TD>
					<TD><asp:dropdownlist id="ddlTipoPasajero" runat="server" Width="107px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Fecha Emisión</TD>
					<TD><asp:textbox id="txtFchEmision" runat="server" CssClass="fd" Width="81px" ></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
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
					<TD><asp:radiobutton id="rbContado" runat="server" Text="Contado" GroupName="Grupo1"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:radiobutton id="rbCredito" runat="server" Text="Crédito" GroupName="Grupo1"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Boleto</TD>
					<TD><asp:radiobutton id="rbPrincipal" runat="server" Text="Principal" GroupName="Grupo2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:radiobutton id="rbconexion" runat="server" Text="Conexión" GroupName="Grupo2"></asp:radiobutton></TD>
				</TR>
			</TABLE>
			            <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
			<asp:label id="lblmsg" 
                style="Z-INDEX: 102; LEFT: 439px; POSITION: absolute; TOP: 381px" runat="server"
				Width="180px" CssClass="error"></asp:label>
                            <br />
                            <br />
                            <br />
                        <br />
                        <br />
					
					</TD>
				</TR>
				<TR>
					<TD class="opciones">
					<asp:datagrid id="dgPasajeros" runat="server" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
							BorderColor="CadetBlue" CssClass="Grid" Height="17px" Width="621px" DESIGNTIMEDRAGDROP="135">
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
								<asp:BoundColumn DataField="NomStsBoleto" HeaderText="StsBol">
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
								<asp:ButtonColumn Text="Devolver " HeaderText="Stock" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="Proveedor">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					
					</TD>
				</TR>
				
				<TR>
					<TD class="opciones">&nbsp;</TD>
				</TR>
				
			</TABLE>

			<TABLE class="tabla" id="Table1" style="Z-INDEX: 107; LEFT: 354px; WIDTH: 232px; POSITION: absolute; TOP: 316px; HEIGHT: 51px"
				cellSpacing="1" cellPadding="1" width="232" border="1">
				<TR>
					<TD>Seleccione Pasajero</TD>
				</TR>
				<TR>
					<TD><asp:dropdownlist id="ddlPasajero" runat="server" Width="196px" DataTextField="NomPasajero"
							DataValueField="NomPasajero" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table4" style="Z-INDEX: 105; LEFT: 354px; WIDTH: 232px; POSITION: absolute; TOP: 155px; HEIGHT: 148px"
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
			<asp:button id="cmdGrabar" style="Z-INDEX: 104; LEFT: 354px; POSITION: absolute; TOP: 375px"
				runat="server" Width="78px" Text="Grabar"></asp:button></form>

</body>
</html>
