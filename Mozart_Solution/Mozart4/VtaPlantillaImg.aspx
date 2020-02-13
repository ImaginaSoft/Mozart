<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaImg.aspx.vb" Inherits="VtaPlantillaImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table4" style="z-index: 102; left: 8px; width: 619px; position: absolute; top: 8px; height: 21px"
            cellspacing="0" cellpadding="1" width="619" border="0" class="form">
            <tr>
                <td>
                    <p class="Titulo">
                        &nbsp;
							<asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </p>
                </td>
            </tr>

            <tr>
                <td class="style1"></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="211px" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Upload" />
                </td>
            </tr>
            <tr>
                <td><asp:Image ID="Image1" runat="server" Height="155px" Width="265px" /></td>
                 <td><asp:Image ID="Image2" runat="server" Height="155px" Width="265px" /></td>
                 <td><asp:Image ID="Image3" runat="server" Height="155px" Width="265px" /></td>
            </tr>
            <%--    <tr>
                <td align="left" class="style3">&nbsp; Imagen 1&nbsp;: &nbsp;<asp:FileUpload ID="btnImportar" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style3">&nbsp;&nbsp;Imagen 2 :&nbsp;                        
                    <asp:FileUpload ID="btnImportar2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style3">&nbsp;&nbsp;Imagen 3 :&nbsp;
                    <asp:FileUpload ID="btnImportar3" runat="server" />
                </td>
            </tr>--%>


            <%--<tr>
                <td align="left" class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    Imagen 01:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    <br />
                    <asp:Image ID="fotox" runat="server" Height="155px" Width="265px" />
                    &nbsp;<br />
                    <br />
                    Imagen 02:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    <br />
                    <asp:Image ID="fotox02" runat="server" Height="155px" Width="265px" />
                    &nbsp;<br />
                    &nbsp;<br />
                    Imagen 03:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    <br />
                    <asp:Image ID="fotox03" runat="server" Height="155px" Width="265px" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>--%>
   
            <tr>
                <td style="height: 25px">
                    <asp:Button ID="cmbGrabar" runat="server" Width="77px"
                        Text="Grabar" Visible="False" Height="26px"></asp:Button></td>
            </tr>

        </table>
    </form>
</body>
</html>
