<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcDocumentoDet.aspx.vb" Inherits="cpcDocumentoDet" %>
<%@ Register TagPrefix="uc1" TagName="ucCliente" Src="ucCliente.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 631px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="631" border="0" class="FORM">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;&nbsp;
							<asp:label id="lbltitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 592px; HEIGHT: 127px" cellSpacing="0" cellPadding="0"
							width="592" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 135px">Tipo Documento</TD>
								<TD>
									<asp:label id="lblTipoDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNomDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Nro. Documento</TD>
								<TD>
									<asp:label id="lblNumeroDocumento" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px; HEIGHT: 20px">Fecha Emisión</TD>
								<TD style="HEIGHT: 20px">
									<asp:label id="lblFchEmision" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Nro. Pedido</TD>
								<TD>
									<asp:label id="lblNroPedido" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;
									<asp:label id="lblDesPedido" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Referencia</TD>
								<TD><asp:label id="lblReferencia" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Importe</TD>
								<TD><asp:label id="lblImporte" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;
									<asp:label id="lblMoneda" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lbltc" runat="server">Tipo Cambio</asp:label>&nbsp;&nbsp;
									<asp:label id="lblTipoCambio" runat="server" CssClass="Dato" Width="73px" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="tabla" id="Table7" style="WIDTH: 592px; HEIGHT: 43px" cellSpacing="0" cellPadding="0"
							width="592" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 61px">IGV</TD>
								<TD style="WIDTH: 72px">Otros</TD>
								<TD style="WIDTH: 71px">Total</TD>
								<TD style="WIDTH: 85px">Pendiente</TD>
								<TD style="WIDTH: 90px">Moneda</TD>
								<TD>Estado Documento</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 61px"><asp:label id="IGV" runat="server" CssClass="Dato" Width="49px"></asp:label></TD>
								<TD style="WIDTH: 72px"><asp:label id="lblOtros" runat="server" CssClass="Dato" Width="73px"></asp:label></TD>
								<TD style="WIDTH: 71px"><asp:label id="lblTotal" runat="server" CssClass="Dato" Width="82px"></asp:label></TD>
								<TD style="WIDTH: 85px"><asp:label id="lblSaldo" runat="server" CssClass="Dato" Width="80px"></asp:label></TD>
								<TD style="WIDTH: 90px"><asp:label id="lblMoneda5" runat="server" CssClass="Dato" Width="78px"></asp:label></TD>
								<TD><asp:label id="lblStsDoc" runat="server" CssClass="Dato" Width="60px"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="tabla" id="Table6" style="WIDTH: 592px; HEIGHT: 45px" cellSpacing="0" cellPadding="0"
							width="592" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 19px">Banco</TD>
								<TD style="WIDTH: 252px; HEIGHT: 19px">Nro. de Cuenta</TD>
								<TD style="HEIGHT: 19px">Estado Doc. en Banco</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px"><asp:label id="lblNomBanco" runat="server" CssClass="Dato" Width="164px"></asp:label></TD>
								<TD style="WIDTH: 252px"><asp:label id="lblNroCuenta" runat="server" CssClass="Dato" Width="239px"></asp:label></TD>
								<TD><asp:label id="lblFlagBanco" runat="server" CssClass="Dato" Width="96px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 48px">
						<TABLE class="FORM" id="Table1" style="WIDTH: 626px; HEIGHT: 28px" cellSpacing="0" cellPadding="0"
							width="626" border="0">
							<TR>
								<TD>
									<asp:button id="cmdAnularLiq" runat="server" Text="Anular Liquidación" Width="120px"></asp:button></TD>
								<TD>
									<asp:button id="cmdModifDoc" runat="server" Text="Modificar Documento" Width="128px"></asp:button></TD>
								<TD>
									<asp:button id="cmdAnularDoc" runat="server" Text="Anular Documento" Width="130px"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="608px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgDocumentos" runat="server" Width="632px" Height="17px" CssClass="Grid"  
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Referencia"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" HeaderText="Pendiente" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoAplica" HeaderText="Aplicado" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodMoneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StsDocumento" HeaderText="StsDoc">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
