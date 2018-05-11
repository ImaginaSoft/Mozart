<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcRegistraCargo.aspx.vb" Inherits="cpcRegistraCargo" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        #Form1
        {
            margin-bottom: 19px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 11px; WIDTH: 544px; POSITION: absolute; TOP: 9px; HEIGHT: 47px"
				cellSpacing="0" cellPadding="1" width="544" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Registra&nbsp;Nota de Cargo</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 543px; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
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
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="141px" Height="8px" ControlToValidate="txtFchEmision"
										ErrorMessage="Dato obligatorio" CssClass="error" ForeColor=" "> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">&nbsp; Referencia</TD>
								<TD>&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="290px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtReferencia" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">&nbsp; Importe
									<asp:Label id="Label1" runat="server" CssClass="error">(TAB)</asp:Label></TD>
								<TD>&nbsp;
									<asp:textbox id="txtImporte" runat="server" Width="93px" AutoPostBack="True"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporte" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator><asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" GroupName="GRUPO1" Checked="True"
										Text="Dólares"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" GroupName="GRUPO1" Text="Nuevo Soles"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">&nbsp; IGV&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtpIGV" runat="server" Width="38px" AutoPostBack="True"></asp:textbox>%</TD>
								<TD>&nbsp;
									<asp:textbox id="txtIGV" runat="server" Width="91px" AutoPostBack="True" ForeColor="Silver" Enabled="False"
										BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px; HEIGHT: 14px">&nbsp; Total</TD>
								<TD style="HEIGHT: 14px">&nbsp;
									<asp:textbox id="txtTotal" runat="server" Width="91px" AutoPostBack="True" ForeColor="Silver"
										Enabled="False" BackColor="WhiteSmoke"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Label id="txtPedido" runat="server" Width="278px"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Button id="cmdGrabar" runat="server" Text="Grabar Cargo"></asp:Button></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblmsg" runat="server" Width="519px"  CssClass="Msg"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
