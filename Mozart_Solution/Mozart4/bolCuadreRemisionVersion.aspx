<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolCuadreRemisionVersion.aspx.vb" Inherits="bolCuadreRemisionVersion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 589px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="589" border="0" class="form">
				<TR>
					<TD class="Titulo" style="WIDTH: 584px">
						<asp:Label id="lblTitulo" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px">
						<asp:label id="lblmsg" runat="server" Width="462px"  CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 18px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px">
						<asp:datagrid id="dgBoleto" runat="server" OnItemDataBound="ComputeSum" ShowFooter="True" AllowSorting="True"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue" CssClass="Grid"
							Height="17px" Width="608px">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomClienteAntiguo" HeaderText="Cliente Antiguo">
									<ItemStyle Wrap="False" BackColor="#FFFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="Pedido">
									<ItemStyle Wrap="False" BackColor="#FFFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="Version">
									<ItemStyle BackColor="#FFFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PagoBoleto" HeaderText="Pago Boleto" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="#FFFFCC"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Provision" HeaderText="Provision" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="#CCFF99"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoRemision" HeaderText="Remisi&#243;n" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="#CCFFFF"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Ajuste" DataFormatString="{0:###,###,###,##0.00}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Diferencia" HeaderText="Diferencia" DataFormatString="{0:###,###,###,##0.00}">
									<ItemStyle Wrap="False" HorizontalAlign="Right" BackColor="#FFCCCC"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 584px; HEIGHT: 16px" align="left">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
