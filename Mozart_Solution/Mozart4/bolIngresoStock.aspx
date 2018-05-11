<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolIngresoStock.aspx.vb" Inherits="bolIngresoStock" %>

<%@ Register src="ucddlProveedor.ascx" tagname="ucddlProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        #Table4
        {
            width: 482px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" 
				cellSpacing="0" cellPadding="1" border="0">
				<TR>
					<TD style="HEIGHT: 22px">
						<P class="Titulo">&nbsp;Ingreso de boletos al Stock&nbsp;</P>
					</TD>
				</TR>
				
				<TR>
					<TD>
			<TABLE class="Tabla" id="Table1" 
				cellSpacing="1" cellPadding="1" width="438" border="1" borderColor="#cccccc">
				<TR>
					<TD style="WIDTH: 89px"><FONT size="2"> Proveedor</FONT></TD>
					<TD style="WIDTH: 214px"><FONT color="#0000ff" size="2">
							<uc1:ucddlProveedor id="UcddlProveedor1" runat="server"></uc1:ucddlProveedor><A href="ucLinea.aspx"><U></U></A></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px; HEIGHT: 18px">Forma</TD>
					<TD style="WIDTH: 214px; HEIGHT: 18px"><asp:textbox id="txtForma" runat="server" Width="77px" tabIndex="1" MaxLength="4"></asp:textbox><asp:requiredfieldvalidator id="rfdForma" runat="server" ControlToValidate="txtForma" ErrorMessage="Dato es obligatorio"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px; HEIGHT: 7px">Serie inicial</TD>
					<TD style="WIDTH: 214px; HEIGHT: 7px"><asp:textbox id="txtSerieInicial" runat="server" Width="77px" tabIndex="2" MaxLength="10" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="rfvSerieInicial" runat="server" ControlToValidate="txtSerieInicial" ErrorMessage="Dato es obligatorio"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px">Serie Final</TD>
					<TD style="WIDTH: 214px"><asp:textbox id="txtSerieFinal" runat="server" Width="77px" tabIndex="3" MaxLength="10" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="rfvSerieFinal" runat="server" ControlToValidate="txtSerieFinal" ErrorMessage="Dato es obligatorio"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px; HEIGHT: 21px">Total boletos</TD>
					<TD style="WIDTH: 214px; HEIGHT: 21px"><asp:label id="lblBoletos" runat="server" Width="74px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px">Fecha Ingreso</TD>
					<TD style="WIDTH: 214px"><asp:textbox id="txtFchIngreso" runat="server" Width="75px" ReadOnly="True" tabIndex="4"></asp:textbox><INPUT id="cmdFchIngreso" onclick="show_calendar('Form1.txtFchIngreso',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="5" type="button" value="..." name="cmdFchIngreso">&nbsp;
						<asp:requiredfieldvalidator id="rfvFchIngreso" runat="server" ControlToValidate="txtFchIngreso" ErrorMessage="Dato es obligatorio"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 89px">&nbsp;</TD>
					<TD style="WIDTH: 214px"><asp:button id="cmdIngresa" runat="server" Width="80px" Text="Grabar" tabIndex="6"></asp:button></TD>
				</TR>
			</TABLE>
						
					</TD>
				</TR>
				

				<TR>
					<TD>
			<asp:label id="lblMsg" runat="server" Width="375px"  Height="17px" 
				CssClass="error"></asp:label>
					</TD>
				</TR>
				
			</TABLE>
			
			
		</form>
</body>
</html>
