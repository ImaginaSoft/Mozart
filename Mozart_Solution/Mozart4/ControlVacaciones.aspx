<%@ Page Language="VB" AutoEventWireup="false"  CodeFile="ControlVacaciones.aspx.vb" Inherits="ControlVacaciones" %>

<%@ Register Src="ucPersonal.ascx" TagName="ucPersonal" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <table border="0" cellpadding="0" cellspacing="0" style="width: 555px">
            <tr>
                <td class="Titulo" style="width: 650px; height: 19px;" >
                    &nbsp;Control de Vacaciones</td>
            </tr>
            <tr>
                <td style="width: 650px; height: 15px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px; height: 17px">
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 274px" bordercolor="#cccccc">
                        <tr>
                            <td style="width: 75px; height: 13px">
                                &nbsp;<asp:Label ID="Label1" runat="server" Text="A partir de " Width="93px"></asp:Label></td>
                            <td style="width: 75px; height: 13px">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 117px">
                                            <tr>
                                                <td style="width: 67px">
                                                    <asp:TextBox ID="txtFchIni" runat="server" Columns="30" Enabled="False" Width="88px"></asp:TextBox>
                                                </td>
                                                <td style="width: 9px">
                                                    <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="Click para mostrar calendario"
                                                        CssClass="GridHeader" ImageUrl="~/Images/Calendar.png" /></td>
                                            </tr>
                                        </table>
                                        <cc1:CalendarExtender ID="CE2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtFchIni" Format="dd-MM-yyyy">
                                        </cc1:CalendarExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px" colspan="2">
                                &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 650px; height: 17px">
                    <asp:Label ID="lblMsg" runat="server" Width="429px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 550px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="550px" CellPadding="1"  BorderWidth="1px"  CssClass="Grid" >
                        <Columns>
                        <asp:BoundField DataField="FchMarca" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"  HtmlEncode="False">
                            <HeaderStyle CssClass="GridHeader" />
                              <ItemStyle Wrap="False" />
                              <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="NomPersonal" HeaderText="Nombre" >
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:BoundField>

                            <asp:BoundField DataField="Estado" HeaderText="Estado" >
                                <HeaderStyle CssClass="GridHeader" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="AnoVacacion" HeaderText="Periodo" >
                                <HeaderStyle CssClass="GridHeader" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="CantDiasReal" HeaderText="Dias" DataFormatString="{0:#####.##}" HtmlEncode="False">
                                <HeaderStyle CssClass="GridHeader" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                        </Columns>
                        <RowStyle CssClass="GridData" />
                        <SelectedRowStyle CssClass="GridSelect" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GridAlterna" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 650px; height: 24px;" >
                    </td>
            </tr>
        </table>

         </ContentTemplate>
       

        </asp:UpdatePanel>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
