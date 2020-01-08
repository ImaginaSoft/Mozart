<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" CodeFile="tabRecordatorioDet.aspx.vb" Inherits="tabRecordatorioDet" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 105%;
        }
        .style2
        {
            width: 577px;
        }
        .style3
        {
            width: 575px;
        }
        .style4
        {
            width: 570px;
        }
        .style5
        {
            width: 560px;
        }
        .style6
        {
            width: 271px;
        }
    </style>
	</HEAD>
	<body>
		<form id="form1" runat="server">
		<table class="style3">
            <tr>
                <td class="Titulo">
							<asp:label id="lblTitulo" runat="server"></asp:label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    1) Variables para usar dentro del recordatorio, se 
						reemplaza su valor al enviar email.</td>
            </tr>
            <tr>
                <td>
						<TABLE class="tabla" id="Table1" 
                            cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD class="style1">NombreCliente :</TD>
								<TD>&nbsp;Miguel</TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="WIDTH: 104px">NombreVendedor :</TD>
								<TD>Rosario Chahud</TD>
							</TR>
							<TR>
								<TD class="style2">ClaveCliente :</TD>
								<TD style="HEIGHT: 17px">&nbsp;lider</TD>
								<TD style="HEIGHT: 17px"></TD>
								<TD style="WIDTH: 104px; HEIGHT: 17px">EmailVendedor :</TD>
								<TD style="HEIGHT: 17px"><A href="mailto:rosario@perutourism.com">
                                    rosario@perutourism.com</A></TD>
							</TR>
							<TR>
								<TD class="style1">EmailCliente :</TD>
								<TD>&nbsp;<A href="mailto:mlahura@hotmail.com">mlahura@hotmail.com</A></TD>
								<TD></TD>
								<TD style="WIDTH: 104px">BlogVendedor:</TD>
								<TD>Blog_Carla@perutourism.co</TD>
							</TR>
							<TR>
								<TD class="style1">LoginCliente</TD>
								<TD>ilogin.aspx?ID=1234</TD>
								<TD>&nbsp;</TD>
								<TD style="WIDTH: 104px">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>					
					</td>
            </tr>
            <tr>
					<TD>
							<P>2)&nbsp;Click edit HTML, reemplazar&nbsp;las etiquetas &lt;P&gt; por &lt;div&gt; 
							y &lt;/P&gt; por &lt;/div&gt;, desmarcar edit HTML y grabar el recordatorio, el 
							objetivo es eliminar las lineas en blancoE>
							</P>

					</TD>
				</tr>
            <tr>
					<TD class="style4">
							<asp:Label ID="lblmsg" runat="server" CssClass="Error"></asp:Label>
                    </TD>
				</tr>
            <tr>
					<TD class="style4">
							<table class="style1">
                                <tr>
                                    <td class="style6">
                                        <asp:Button ID="cmdSend" runat="server" Text="Grabar Recordatorio" 
                                            Width="132px" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="cmdPrueba" runat="server" Text="Prueba E-mail" Width="132px" />
                                    </td>
                                </tr>
                            </table>
&nbsp;</TD>
				</tr>
            <tr>
                <td>
                    <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[TRECORDATORIO].DefaultView.[0].Recordatorio") %>'>
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblpie" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        </form>
</body>
</html>
