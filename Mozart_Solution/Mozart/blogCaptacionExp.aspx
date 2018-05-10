<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogCaptacionExp.aspx.vb" Inherits="blogCaptacionExp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 640px;
        }
        .style4
        {
            width: 640px;
            height: 14px;
        }
        .style5
        {
            height: 14px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 620px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
				cellSpacing="0" cellPadding="1" width="620" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Experiencias&nbsp;para Captación</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
                        <table class="style1">
                            <tr>
                                <td class="style3">
                                    <asp:Button ID="ButtonMarcar" runat="server" Height="23px" 
                                        Text="Eliminar" Width="70px" Visible="False" />
                                </td>
                                <td>
                                    <asp:Button ID="ButtonOrden" runat="server" Text="Actualizar Orden" />
                                </td>
                            </tr>
                        </table>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"><asp:label id="lblmsg" runat="server" Width="462px" 
                            CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgPedidos" runat="server" 
					        Width="808px" Height="17px" 
					        CssClass="Grid"  AutoGenerateColumns="False"  DataKeyNames="NroPedido,NroExp"
							CellPadding="2" BorderWidth="1px"  BorderColor="CadetBlue" AllowSorting="True">
                            <SelectedRowStyle CssClass="GridSelect" />
                            <PagerStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="GridHeader"   />
                            <AlternatingRowStyle CssClass="GridAlterna" />
							
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>

							
								<asp:TemplateField>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Target=_blank Text="Blog" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"NavigateUrl")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								
                    <asp:BoundField DataField="FchAct" SortExpression="FchAct" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                    </asp:BoundField>
								<asp:BoundField DataField="TitExp" SortExpression="TitExp" HeaderText="Titulo Experiencia"></asp:BoundField>
								<asp:BoundField DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Tag" SortExpression="Tag" HeaderText="Tag">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Fotos" SortExpression="Fotos" HeaderText="Foto">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="DesRevision" SortExpression="DesRevision" HeaderText="Sts">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Revisado"></asp:BoundField>

									<asp:TemplateField HeaderText="Orden">
										<ItemTemplate>
											<asp:TextBox id="OrdenCaptacion" runat="server" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem,"OrdenCaptacion") %>'>
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>

		</form>
</body>
</html>
