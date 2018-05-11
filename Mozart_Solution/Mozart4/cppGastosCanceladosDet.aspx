<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppGastosCanceladosDet.aspx.vb" Inherits="cppGastosCanceladosDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 101; LEFT: 6px; WIDTH: 436px; POSITION: absolute; TOP: 8px; HEIGHT: 162px"
				cellSpacing="0" cellPadding="0" width="436" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 13px">&nbsp;Saldo de la cuenta</TD>
				</TR>
				<TR>
					<TD>
						<P></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 616px; HEIGHT: 56px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="616" border="0">
							<TR>
								<TD style="WIDTH: 57px; HEIGHT: 17px">&nbsp;Año&nbsp;</TD>
								<TD style="HEIGHT: 17px"><asp:label id="lblAno" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 57px">&nbsp;Mes&nbsp;</TD>
								<TD><asp:label id="lblMes" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 57px">&nbsp;Cuenta</TD>
								<TD><asp:label id="lblNomCuenta" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLista" runat="server" OnItemDataBound="ComputeSum" ShowFooter="True" AutoGenerateColumns="False"
							BorderColor="#CCCCCC" CellPadding="2" BorderWidth="1px" Height="25px" CssClass="Grid" Width="616px">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="GrupoCuenta" HeaderText="Grupo"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCuenta" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Cuenta">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NomCuenta")%>' NavigateUrl='<%# "cppGastosDet.aspx?FchIni=" + DataBinder.Eval(Container.DataItem,"FchIni")+"&FchFin=" + DataBinder.Eval(Container.DataItem,"FchFin") +"&CodCuenta=" + DataBinder.Eval(Container.DataItem,"CodCuenta")+"&Opcion=R"%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="MontoS" HeaderText="Monto S/." DataFormatString="{0:###,###,###,###}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGVS" HeaderText="IGV S/." DataFormatString="{0:###,###,###,###}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoD" HeaderText="Monto USD" DataFormatString="{0:###,###,###,###}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGVD" HeaderText="IGV USD" DataFormatString="{0:###,###,###,###}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalD" HeaderText="Total USD" DataFormatString="{0:###,###,###,###}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchIni" HeaderText="FchIni">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchFin" HeaderText="FchFin">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>
						<P><asp:label id="lblMsg" runat="server" Height="3px" CssClass="Msg" Width="398px"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
			<P>&nbsp;</P>
		</form>
</body>
</html>
