<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="tabParametroDetalle.aspx.vb" Inherits="tabParametroDetalle" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 103px;
        }
    </style>
	</HEAD>
	<body  MS_POSITIONING="GridLayout">
		<form id="frmRTB" method="post" runat="server">
			<table class="style1">
                <tr>
                    <td class="Titulo">
                        Actualizar Parámetro</td>
                </tr>
                <tr>
                    <td >
			<asp:label id="lblDescCampo" 
				runat="server"></asp:label>
			        </td>
                </tr>
                <tr>
                    <td >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td class="style2">
                                    Valor númerico</td>
                                <td>
                                    <asp:textbox id="txtValor" runat="server" Width="114px" MaxLength="12"></asp:textbox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[tblRTB].DefaultView.[0].TextoCampo") %>'>
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
						<asp:button id="btnSave" runat="server" Text="Grabar" 
                            ToolTip="This will save the data in the Rich Text Box to the database." 
                            Width="67px"></asp:button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblmsg" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
			            &nbsp;&nbsp;</td>
                </tr>
            </table>
		</form>
</body>
</html>
