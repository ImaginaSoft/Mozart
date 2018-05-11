<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppCuadreObligaciones.aspx.vb" Inherits="cppCuadreObligaciones" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 527px; POSITION: absolute; TOP: 7px; HEIGHT: 80px"
				cellSpacing="0" cellPadding="0" width="527" border="0">
				<TR>
					<TD class="Titulo">
						<P class="Titulo">Obligaciones&nbsp;Pendientes de Cuadre</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD class="style1">
                                    <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                                </TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE class="form" id="Table3" style="WIDTH: 488px; HEIGHT: 56px" cellSpacing="0" cellPadding="0"
							width="488" border="0">
							<TR>
								<TD style="WIDTH: 418px; HEIGHT: 47px">
									<TABLE class="tabla" id="Table4" style="WIDTH: 408px; HEIGHT: 64px" cellSpacing="0" cellPadding="0"
										width="408" border="1">
										<TR>
											<TD style="WIDTH: 178px">Pedidos terminados al</TD>
											<TD><asp:textbox id="txtFchFinal" runat="server"  DESIGNTIMEDRAGDROP="25" CssClass="fd"
													Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
												<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" DESIGNTIMEDRAGDROP="27" CssClass="error"
													Width="18px" ForeColor=" " ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 178px">Moneda</TD>
											<TD><asp:radiobutton id="rbdolar" runat="server" Checked="True" GroupName="GRUPO1" Text="Dólares"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" GroupName="GRUPO1" Text="Nuevo Soles"></asp:radiobutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 178px">Cliente</TD>
											<TD><asp:textbox id="txtNomCliente" runat="server" Width="256px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 47px"><asp:button id="btnBuscar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE class="form" id="Table5" style="WIDTH: 483px; HEIGHT: 28px" cellSpacing="0" cellPadding="0"
							width="483" border="0">
							<TR>
								<TD><asp:button id="btnUnComprobante" runat="server" Width="128px" Text="Un Comprobante" Visible="False"></asp:button></TD>
								<TD><asp:button id="btnVariosComprobantes" runat="server" Width="150px" Text="Varios comprobantes"
										Visible="False"></asp:button></TD>
								<TD></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD class="msg"><asp:label id="lblmsg" runat="server" CssClass="Msg" Width="410px"  Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
                                    <asp:GridView id="dgDocumento" runat="server" CssClass="Grid" Width="550px" 
                                        Height="24px" AllowSorting="True"
							BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" DataKeyNames="KeyReg" 
                                        UseAccessibleHeader="False" >
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:BoundField DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido" DataFormatString="{0:########}">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
								</asp:BoundField>
								<asp:BoundField DataField="CodMoneda" HeaderText="CodMoneda">
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomCliente" SortExpression="NomCliente" HeaderText="NomCliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Moneda" SortExpression="Moneda" HeaderText="Moneda">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Docs" HeaderText="Docs" SortExpression="Docs" DataFormatString="{0:###,###}">
									<ItemStyle HorizontalAlign="center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="FchTermino" SortExpression="FchTermino" HeaderText="FchTermino" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:ButtonField Text="Detalle" CommandName="select"></asp:ButtonField>
							</Columns>
						</asp:GridView>
                                    </TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</FORM>
</body>
</html>
