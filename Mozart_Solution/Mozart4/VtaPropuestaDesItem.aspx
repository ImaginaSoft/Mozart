<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaPropuestaDesItem.aspx.vb" Inherits="VtaPropuestaDesItem" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body  MS_POSITIONING="GridLayout">
		<form id="frmRTB" method="post" runat="server">
		
			<TABLE class="form" id="Table1" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD class="Titulo">
					    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD>
			            &nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
                        <asp:Label ID="lblDesProveedor" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[DPROPUESTA].DefaultView.[0].DesProveedor") %>'></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD><asp:textbox id=txtDesServicio runat="server" Width="528px" Text='<%# DataBinder.Eval(dsEdit, "Tables[DPROPUESTA].DefaultView.[0].DesServicio") %>'></asp:textbox></TD>
				</TR>
					
				<TR>
					<TD>&nbsp;</TD>
				</TR>
					
				<TR>
					<TD>
                        <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text='<%# DataBinder.Eval(dsEdit,"Tables[DPROPUESTA].DefaultView.[0].DesServicioDet") %>'>
                        </FTB:FreeTextBox>
                    </TD>
				</TR>
					
				<TR>
					<TD align="center">
						<asp:Button id="cmdGrabar" runat="server" Text="Grabar" Width="107px"></asp:Button></TD>
				</TR>
					
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="392px" CssClass="Error"></asp:label></TD>
				</TR>
					
            </TABLE>
		</form>
</body>
</html>
