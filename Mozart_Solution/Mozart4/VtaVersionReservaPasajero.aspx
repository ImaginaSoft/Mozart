<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaVersionReservaPasajero.aspx.vb" Inherits="VtaVersionReservaPasajero" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 104px;
        }
        .style2
        {
            width: 114px;
        }
    </style>
	</HEAD>
	<body  MS_POSITIONING="GridLayout">
				<form id="frmRTB" method="post" runat="server">

			<TABLE class="tabla" id="Table2" 
				cellSpacing="0" cellPadding="0" width="542" border="0">
				<TR>
					<TD class="Titulo">
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </TD>
				</TR>
				<TR>
	    			<TD> 
	    			
	    			    &nbsp;</TD>
				</TR>

				<TR>
	    			<TD class="style13"> 
	    			
	    			    <table cellSpacing="0" cellPadding="0"  border="0" style="width: 409px">
                            <tr>
                                <td class="style1">
                                    Datos Completos</td>
                                <td class="style2">
									<asp:DropDownList ID="ddlDC" runat="server" style="margin-left: 0px" 
                                        Width="60px" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                <td class="style2">
                                    Emisión de Tickets</td>
                                <td>
									<asp:DropDownList ID="ddlET" runat="server" Width="60px" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                            </tr>
                            </table>
	    			
	    			</TD>
				</TR>

				<TR>
	    			<TD> 
	    			
			            &nbsp;&nbsp; </TD>
				</TR>

				<TR>
	    			<TD> 
	    			
			<TABLE class="tabla" id="Table1" 
				cellSpacing="0" cellPadding="0"  border="0">
				
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 24px">De</TD>
					<TD style="HEIGHT: 24px" align="left"><asp:textbox id="txtDe" runat="server" Width="384px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 15px">Para</TD>
					<TD style="HEIGHT: 15px" align="left"><asp:textbox id="txtPara" runat="server" Width="240px"></asp:textbox>&nbsp;
						<asp:dropdownlist id="ddlContacto" tabIndex="6" runat="server" Width="136px" AutoPostBack="True" DataValueField="CodContacto"
							DataTextField="NomContacto"></asp:dropdownlist>&nbsp;
						<asp:button id="cmdSend" runat="server" Width="83px" Text="Enviar"></asp:button>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 17px">Cc</TD>
					<TD style="HEIGHT: 17px" align="left"><asp:textbox id="txtCC" runat="server" Width="384px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 48px; HEIGHT: 7px">Asunto</TD>
					<TD style="HEIGHT: 7px" align="left"><asp:textbox id="txtAsunto" runat="server" Width="390px"></asp:textbox></TD>
				</TR>
			</TABLE>
				    
				     </TD>
				</TR>

				<TR>
	    			<TD height="20PX"> 
	    			
	    			    <asp:label id="lblmsg" runat="server" Width="472px" CssClass="Error"></asp:label></TD>
				</TR>

				<TR>
	    			<TD> 
	    			
	    			    <FTB:FreeTextBox ID="FreeTextBox1" runat="server" >
                        </FTB:FreeTextBox>
                    </TD>
				</TR>

				<TR>
				    <TD>
				    
			            <asp:Label ID="lblNomVendedor" runat="server" Visible="False"></asp:Label>
                    </TD>
				</TR>

				<TR>
				    <TD>
				    
			            &nbsp;</TD>
				</TR>

				<TR>
				    <TD>
				    
			            &nbsp;</TD>
				</TR>
            </TABLE>
</form>
</body>
</html>
