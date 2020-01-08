<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionPublica.aspx.vb" Inherits="VtaVersionPublica" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="0" cellPadding="1" width="536" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 531px; HEIGHT: 142px" cellSpacing="0" cellPadding="0"
							width="531" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 25px">&nbsp;Nro Versión</TD>
								<TD style="HEIGHT: 25px">&nbsp;
									<asp:label id="lblNroVersion" runat="server" ForeColor="Black" Width="81px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Descripción</TD>
								<TD>&nbsp;
									<asp:Label id="lblDesVersion" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 24px">&nbsp;Fecha</TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:label id="lblFchVersion" runat="server" ForeColor="Black" Width="213px"></asp:label>&nbsp;Estado&nbsp;
									<asp:Label id="lblStsVersion" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;% Utilidad</TD>
								<TD>&nbsp;
									<asp:Label id="lblPorUtilidad" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Pasajeros</TD>
								<TD>&nbsp;&nbsp;
									<asp:Label id="lblPasajeros" runat="server" ForeColor="Black"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Version</TD>
								<TD>
									<asp:RadioButton id="rbtSi" runat="server" GroupName="grupo1" Text="Si Publica"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtNo" runat="server" GroupName="grupo1" Text="No Publica"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Precio en Euros</TD>
								<TD>
									<asp:RadioButton id="rbtEuroSI" runat="server" Text="Si " GroupName="grupo3" AutoPostBack="True"></asp:RadioButton>
									&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="rbtEuroNO" runat="server" Text="No " GroupName="grupo3" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp; 
									&nbsp;Tipo Cambio de US$ a Euro&nbsp;&nbsp;
									<asp:Label id="lblTipoCambioEuro" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Itinerario en</TD>
								<TD>
									<asp:RadioButton id="rbtNroDia" runat="server" GroupName="grupo2" Text="Nro. Dias"></asp:RadioButton>&nbsp; 
									&nbsp;
									<asp:RadioButton id="rbtFecha" runat="server" GroupName="grupo2" Text="Fechas"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									Fecha Inicio&nbsp;
									<asp:textbox id="txtFchInicio" runat="server" Width="75px" AutoPostBack="True" ></asp:textbox><INPUT class="fd" id="cmdFchInicio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicio">
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;Perfil Cliente</TD>
								<TD>&nbsp;
									<asp:dropdownlist id="ddlStsCaptacion" runat="server" Width="224px" DataTextField="NomStsCaptacion"
										DataValueField="StsCaptacion"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px">
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="519px" Height="22px" CssClass="error"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>

</body>
</html>
