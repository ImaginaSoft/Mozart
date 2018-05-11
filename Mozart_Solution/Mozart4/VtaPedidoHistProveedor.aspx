<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaPedidoHistProveedor.aspx.vb" Inherits="VtaPedidoHistProveedor" %>

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
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 209px"
				cellSpacing="0" cellPadding="0" width="600" border="0">
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
					<TD style="HEIGHT: 15px">Descripción</TD>
				</TR>
				<TR>
					<TD>
                        <FTB:FreeTextBox ID="FreeTextBox1" runat="server">
                        </FTB:FreeTextBox>
                    </TD>
				</TR>
				<TR>
					<TD><asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button><asp:requiredfieldvalidator id="rfvNomPedido" runat="server" Width="93px" ForeColor=" " CssClass="error" ErrorMessage="Dato obligatorio"
							ControlToValidate="FreeTextBox1"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Height="22px" Width="480px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgHistorial" runat="server" Height="20px" Width="632px" CssClass="Grid" CellPadding="2"
							BorderWidth="2px" BorderColor="CadetBlue" AllowSorting="True" AutoGenerateColumns="False"
							BorderStyle="None">
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
