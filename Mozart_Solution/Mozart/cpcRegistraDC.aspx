<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcRegistraDC.aspx.vb" Inherits="cpcRegistraDC" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 11px; WIDTH: 546px; POSITION: absolute; TOP: 9px; HEIGHT: 184px"
				cellSpacing="0" cellPadding="1" width="546" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Modifica Documento de Cobranza</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 543px; HEIGHT: 107px" cellSpacing="0" cellPadding="0"
							width="543" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 104px">&nbsp; Tipo Documento</TD>
								<TD>&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="300px" DataValueField="TipoDocumento"
										DataTextField="NomDocumento"></asp:dropdownlist>&nbsp;
									<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label>
									<asp:textbox id="txtNroDocumento" runat="server" Width="77px" ReadOnly="True" BackColor="#C0FFFF"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">&nbsp; Fecha</TD>
								<TD>&nbsp;
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchEmision" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">&nbsp; Referencia</TD>
								<TD>&nbsp;
									<asp:Label id="lblReferencia" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px; HEIGHT: 14px">&nbsp; Total</TD>
								<TD style="HEIGHT: 14px">&nbsp;
									<asp:Label id="lblTotal" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdGrabar" runat="server" Text="Grabar " Width="80px"></asp:Button>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="519px"  CssClass="Msg"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
