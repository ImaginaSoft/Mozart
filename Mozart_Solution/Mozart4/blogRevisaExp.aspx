<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogRevisaExp.aspx.vb" Inherits="blogRevisaExp" %>

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
        .style2
        {
            width: 115px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 620px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
				cellSpacing="0" cellPadding="1" width="620" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Experiencias&nbsp;ingresadas / modificadas</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 544px; HEIGHT: 24px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="544" border="1">
							<TR>
								<TD style="WIDTH: 116px; HEIGHT: 15px">Vendedor</TD>
								<TD style="WIDTH: 338px; HEIGHT: 15px"><asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 15px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px">
									Fecha de ingreso</TD>
								<TD style="WIDTH: 338px"><asp:textbox id="txtFchInicial" runat="server" Width="75px" DESIGNTIMEDRAGDROP="21" CssClass="fd"
										></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" Height="8px" DESIGNTIMEDRAGDROP="23"
										CssClass="error" ForeColor=" " ControlToValidate="txtFchInicial">*</asp:requiredfieldvalidator><asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
									&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" Width="75px" DESIGNTIMEDRAGDROP="25" CssClass="fd"
										></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" Height="8px" DESIGNTIMEDRAGDROP="27"
										CssClass="ERROR" ForeColor=" " ControlToValidate="txtFchFinal">*</asp:requiredfieldvalidator></TD>
								<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
                        <table class="style1">
                            <tr>
                                <td class="style2">
                                    <asp:Button ID="ButtonMarcar" runat="server" Height="23px" 
                                        Text="Marcar para Captación" Width="145px" Visible="False" />
                                </td>
                                <td>
                                    &nbsp;</td>
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
								<asp:BoundField DataField="NroPedido" HeaderText="NroPedido" Visible="False"></asp:BoundField>
								<asp:BoundField DataField="DesCaptacion" SortExpression="DesCaptacion" HeaderText="Cap">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								
                    
								


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
