<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaPublica.aspx.vb" Inherits="VtaPropuestaPublica" %>

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
			<TABLE id="Table4" style="Z-INDEX: 104; LEFT: 16px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="593" border="0" class="form">
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
						<TABLE class="tabla" id="Table1" style="WIDTH: 591px; HEIGHT: 120px" cellSpacing="0" cellPadding="0"
							width="591" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 25px">&nbsp;Nro Propuesta</TD>
								<TD style="HEIGHT: 25px">&nbsp;
									<asp:label id="lblNroPropuesta" runat="server" Width="81px" ForeColor="Black"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Descripción</TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:Label id="lblDesPropuesta" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 24px">&nbsp;Cantidad Dias</TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:Label id="lblCantDias" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 24px">&nbsp;Fecha</TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:label id="lblFchPropuesta" runat="server" Width="213px" ForeColor="Black"></asp:label>&nbsp;<asp:label id="Label2" runat="server">Estado</asp:label>&nbsp;
									<asp:Label id="lblStsPropuesta" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;% Utilidad</TD>
								<TD>&nbsp;
									<asp:Label id="lblPorUtilidad" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Pasajeros</TD>
								<TD>&nbsp;
									<asp:Label id="lblPasajeros" runat="server" ForeColor="Black"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">&nbsp;Propuesta</TD>
								<TD>
									<asp:RadioButton id="rbtSi" runat="server" Text="Si Publicar" GroupName="grupo1"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtNo" runat="server" Text="No Publicar " GroupName="grupo1"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 22px">&nbsp;Precio en Euros</TD>
								<TD style="HEIGHT: 22px">
									<asp:RadioButton id="rbtEuroSI" runat="server" GroupName="grupo3" Text="Si " AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="rbtEuroNO" runat="server" GroupName="grupo3" Text="No " AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp; 
									&nbsp;Tipo Cambio de US$ a Euro&nbsp;&nbsp;
									<asp:Label id="lblTipoCambioEuro" runat="server" ForeColor="Black"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 26px">&nbsp;Itinerario en</TD>
								<TD style="HEIGHT: 26px">
									<asp:RadioButton id="rbtNroDia" runat="server" GroupName="grupo2" Text="Nro. Dias"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="rbtFecha" runat="server" GroupName="grupo2" Text="Fechas"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label1" runat="server" Width="89px">Fecha Inicio:</asp:label>
									<asp:textbox id="txtFchInicio" runat="server" Width="75px"  AutoPostBack="True"></asp:textbox>
									<INPUT class="fd" id="cmdFchInicio" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicio',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicio"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 6px">&nbsp;Perfil Cliente</TD>
								<TD style="HEIGHT: 6px">
									<asp:dropdownlist id="ddlStsCaptacion" runat="server" Width="224px" DataTextField="NomStsCaptacion"
										DataValueField="StsCaptacion"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px">Proyección de Venta</TD>
								<TD>
									<asp:radiobutton id="rbtSIVta" runat="server" GroupName="G4" Text="SI"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtNOVta" runat="server" GroupName="G4" Text="NO"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="496px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
