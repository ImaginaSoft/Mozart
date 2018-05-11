<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolConsultaBoleto.aspx.vb" Inherits="bolConsultaBoleto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="576" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;Consulta Boleto</P>
					</TD>
				</TR>
				

				<TR>
					<TD>
			<TABLE class="tabla" id="Table5" 
				cellSpacing="1" cellPadding="1" width="559" border="1" borderColor="#cccccc"	>
				<TR>
					<TD style="WIDTH: 62px">&nbsp;Proveedor</TD>
					<TD style="WIDTH: 128px"><asp:dropdownlist id="ddlProveedor" runat="server" 
                            AutoPostBack="True" DataValueField="CodProveedor"
							DataTextField="NomProveedor" Width="146px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 40px">&nbsp;Forma</TD>
					<TD class="tabla" style="WIDTH: 72px"><asp:dropdownlist id="ddlForma" 
                            runat="server" AutoPostBack="True" DataValueField="Forma" DataTextField="Forma"
							Width="71px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 35px">&nbsp;Serie</TD>
					<TD style="WIDTH: 79px"><asp:dropdownlist id="ddlSerie" runat="server" 
                            AutoPostBack="True" DataValueField="Serie" DataTextField="Serie"
							Width="78px"></asp:dropdownlist></TD>
					<TD>&nbsp;&nbsp; Cupon
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
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtCupon" runat="server" Width="24px" MaxLength="1">0</asp:textbox></TD>
				</TR>
			</TABLE>

					</TD>
				</TR>


				<TR>
					<TD>
			
			&nbsp;<asp:button id="cmdBuscar" runat="server" Width="76px" Text="Buscar" ></asp:button>
			
					&nbsp;&nbsp;

<asp:label id="lblmsg"  runat="server"
				Width="328px" CssClass="error"></asp:label>
			
					</TD>
				</TR>


				<TR>
					<TD>

                        &nbsp;</TD>
				</TR>

				
			</TABLE>
			<TABLE class="tabla" id="Table1" style="Z-INDEX: 106; LEFT: 350px; WIDTH: 230px; POSITION: absolute; TOP: 321px; HEIGHT: 49px"
				cellSpacing="1" cellPadding="1" width="230" border="1">
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Cliente</TD>
					<TD>&nbsp;
						<asp:Label id="NomCliente" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Pedido</TD>
					<TD>&nbsp;
						<asp:Label id="NroPedido" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Versión</TD>
					<TD>&nbsp;
						<asp:Label id="NroVersion" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Reporte</TD>
					<TD>&nbsp;
						<asp:Label id="Reporte" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Usuario&nbsp;</TD>
					<TD>&nbsp;
						<asp:Label id="CodUsuario" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 60px">&nbsp;Actua.</TD>
					<TD>&nbsp;
						<asp:Label id="fchsys" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table4" style="Z-INDEX: 104; LEFT: 351px; WIDTH: 232px; POSITION: absolute; TOP: 158px; HEIGHT: 148px"
				cellSpacing="1" cellPadding="1" width="232" border="1">
				<TR>
					<TD style="WIDTH: 151px" colSpan="2">&nbsp;Tarifa Neta&nbsp;</TD>
					<TD>&nbsp;
						<asp:Label id="Tarifa" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 73px">&nbsp;IGV</TD>
					<TD style="WIDTH: 55px">&nbsp;
						<asp:Label id="PIGV" runat="server"></asp:Label></TD>
					<TD>&nbsp;
						<asp:Label id="IGV" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 151px" colSpan="2">&nbsp;Otros</TD>
					<TD>&nbsp;
						<asp:Label id="Otros" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 73px">&nbsp;Comisión 1</TD>
					<TD style="WIDTH: 55px">&nbsp;
						<asp:Label id="pCom1" runat="server"></asp:Label></TD>
					<TD>&nbsp;
						<asp:Label id="Com1" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 73px">&nbsp;Comisión 2</TD>
					<TD style="WIDTH: 55px">&nbsp;
						<asp:Label id="pCom2" runat="server"></asp:Label></TD>
					<TD>&nbsp;
						<asp:Label id="Com2" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
			<TABLE class="tabla" id="Table2" style="Z-INDEX: 103; LEFT: 7px; WIDTH: 336px; POSITION: absolute; TOP: 159px; HEIGHT: 251px"
				cellSpacing="1" cellPadding="1" width="336" border="1">
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Nro. Boleto</TD>
					<TD>&nbsp;
						<asp:Label id="NroBoleto" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Ubicación</TD>
					<TD>&nbsp;
						<asp:Label id="stsubica" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px" colSpan="1">&nbsp;Estado&nbsp;Boleto</TD>
					<TD>&nbsp;&nbsp;
						<asp:Label id="stsBoleto" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Linea Aerea</TD>
					<TD>&nbsp;
						<asp:Label id="NomLinea" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Pasajero</TD>
					<TD>&nbsp;
						<asp:Label id="TipoPasajero" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Fecha Emisión</TD>
					<TD>&nbsp;
						<asp:Label id="FchEmision" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Nombre Pasajero</TD>
					<TD>&nbsp;
						<asp:Label id="NomPasajero" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Ruta</TD>
					<TD>&nbsp;
						<asp:Label id="Ruta" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px; HEIGHT: 26px">&nbsp;Observación</TD>
					<TD style="HEIGHT: 26px">&nbsp;
						<asp:Label id="Observacion" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Forma Pago</TD>
					<TD>&nbsp;
						<asp:Label id="FormaPago" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 107px">&nbsp;Tipo Boleto</TD>
					<TD>&nbsp;
						<asp:Label id="TipoBoleto" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
			
			</form>
</body>
</html>
