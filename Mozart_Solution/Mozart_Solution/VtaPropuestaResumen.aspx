<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaPropuestaResumen.aspx.vb" Inherits="VtaPropuestaResumen" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="frmRTB" method="post" runat="server">
			<table cellpadding="0" class="style3">
                <tr>
                    <td class="Titulo">
							<asp:label id="lblTitulo" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
							&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>

                        <FTB:FreeTextBox ID="FreeTextBox1" runat="server" DownLevelRows="10" 
                            Height="350px" 
                            Text='<%# DataBinder.Eval(dsEdit, "Tables[tblRTB].DefaultView.[0].Resumen") %>'>
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">
						<asp:Button id="btnSave" runat="server" Text="Grabar" 
                            ToolTip="This will save the data in the Rich Text Box to the database." 
                            Width="79px"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
						<asp:Label id="lblmsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; &nbsp;</td>
                </tr>
            </table>
		</form>

</body>
</html>
