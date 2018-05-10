<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaPedidoHistorial.aspx.vb" Inherits="VtaPedidoHistorial" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 16px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="593" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 430px; HEIGHT: 175px" cellSpacing="0" cellPadding="0"
							width="430" border="1">
							<TR>
								<TD style="HEIGHT: 7px">
									<asp:RadioButton id="rbtLibre" runat="server" Text="Mensaje Libre" Checked="True" GroupName="g1"></asp:RadioButton>&nbsp;
									<asp:RadioButton id="rbtEntrada" runat="server" Text="Mensaje Entrada" GroupName="g1"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtSalida" runat="server" Text="Mensaje Salida" GroupName="g1"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 7px"></TD>
							</TR>
							<TR>
								<TD>
									<FTB:FreeTextBox ID="FreeTextBox1" runat="server"  Height="250px">
                                    </FTB:FreeTextBox>
                                </TD>
							</TR>
							<TR>
								<TD>&nbsp;
									<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="545px" Height="22px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgHistorial" runat="server" Width="700px" Height="20px" BorderStyle="None" AutoGenerateColumns="False"
							AllowSorting="True" CssClass="Grid" BorderColor="CadetBlue" BorderWidth="2px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchAct" HeaderText="Fecha ">
									<HeaderStyle Width="12pt"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesLog" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoLog" HeaderText="TipoLog">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
