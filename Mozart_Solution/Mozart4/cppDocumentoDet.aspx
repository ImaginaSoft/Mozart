<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppDocumentoDet.aspx.vb" Inherits="cppDocumentoDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 631px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="631" border="0">
				<TR>
					<TD>
						<P class="Titulo">Proveedor&nbsp;
							<asp:label id="lblNombre" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 608px; HEIGHT: 127px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="608" border="1">
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label1" runat="server" Width="114px">Tipo Documento</asp:label></TD>
								<TD><asp:label id="lblTipoDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNomDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label2" runat="server" Width="117px">Nº Documento</asp:label></TD>
								<TD><asp:label id="lblNumeroDocumento" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px; HEIGHT: 20px"><asp:label id="Label3" runat="server" Width="109px">Fecha</asp:label></TD>
								<TD style="HEIGHT: 20px"><asp:label id="lblFchSys" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label4" runat="server" Width="106px">Nro Pedido</asp:label></TD>
								<TD><asp:label id="lblNroPedido" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;
									<asp:label id="lblDesPedido" runat="server" Width="352px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label5" runat="server" Width="111px">Tipo Servicio</asp:label></TD>
								<TD><asp:label id="lblReferencia" runat="server" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px"><asp:label id="Label6" runat="server" Width="101px">Importe</asp:label></TD>
								<TD><asp:label id="lblImporte" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;
									<asp:label id="lblMoneda" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;
									<asp:label id="lbltc" runat="server" Width="73px" Visible="False">Tipo  Cambio</asp:label>&nbsp;
									<asp:label id="lblTipoCambio" runat="server" Width="73px" CssClass="Dato" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="tabla" id="Table7" style="WIDTH: 608px; HEIGHT: 43px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="608" border="1">
							<TR>
								<TD style="WIDTH: 61px"><asp:label id="lblNomIgv" runat="server" Width="25px">IGV</asp:label></TD>
								<TD style="WIDTH: 72px"><asp:label id="Label8" runat="server" Width="39px">Otros</asp:label></TD>
								<TD style="WIDTH: 71px"><asp:label id="Label9" runat="server" Width="41px">Total</asp:label></TD>
								<TD style="FONT-WEIGHT: bold; WIDTH: 85px">Pendiente</TD>
								<TD style="WIDTH: 90px"><asp:label id="Label15" runat="server" Width="41px">Moneda</asp:label></TD>
								<TD><asp:label id="Label14" runat="server" Width="60px">Sts Doc</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 61px"><asp:label id="IGV" runat="server" Width="49px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 72px"><asp:label id="lblOtros" runat="server" Width="73px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 71px"><asp:label id="lblTotal" runat="server" Width="82px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 85px"><asp:label id="lblSaldo" runat="server" Width="80px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 90px"><asp:label id="lblMoneda5" runat="server" Width="78px" CssClass="Dato"></asp:label></TD>
								<TD><asp:label id="lblStsDoc" runat="server" Width="60px" CssClass="Dato"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="tabla" id="Table6" style="WIDTH: 608px; HEIGHT: 45px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="608" border="1">
							<TR>
								<TD style="WIDTH: 72px; HEIGHT: 19px"><asp:label id="Label11" runat="server" Width="25px">Banco</asp:label></TD>
								<TD style="WIDTH: 252px; HEIGHT: 19px"><asp:label id="Label12" runat="server" Width="108px">Nro de Cuenta</asp:label></TD>
								<TD style="HEIGHT: 19px"><asp:label id="Label16" runat="server" Width="101px">Sts Banco</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 72px"><asp:label id="lblNomBanco" runat="server" Width="164px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 252px"><asp:label id="lblNroCuenta" runat="server" Width="239px" CssClass="Dato"></asp:label></TD>
								<TD><asp:label id="lblFlagBanco" runat="server" Width="96px" CssClass="Dato"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="tabla" id="Table4" style="WIDTH: 608px; HEIGHT: 45px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="608" border="1">
							<TR>
								<TD style="WIDTH: 152px; HEIGHT: 20px">Nº Comprobante</TD>
								<TD style="WIDTH: 252px; HEIGHT: 20px">Cta Gasto</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 152px"><asp:label id="lblNroComprobante" runat="server" Width="160px" CssClass="Dato"></asp:label></TD>
								<TD style="WIDTH: 252px"><asp:label id="lblCodGasto" runat="server" Width="423px" CssClass="Dato"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="form" id="Table1" style="WIDTH: 633px; HEIGHT: 28px" cellSpacing="1" cellPadding="1"
							width="633" border="0">
							<TR>
								<TD><asp:button id="cmdAnularLiqu" runat="server" Width="124px" Text="Anular Liquidación"></asp:button></TD>
								<TD><asp:button id="cmdLiquida" runat="server" Width="131px" Text="Liquida Pendiente"></asp:button></TD>
								<TD><asp:button id="cmdModifDoc" runat="server" Width="147px" Text="Modificar Documento"></asp:button></TD>
								<TD><asp:button id="cmdAnularDoc" runat="server" Width="137px" Text="Anular Documento"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="600px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDocumentos" runat="server" Width="632px" CssClass="Grid" Height="17px"  
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
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoAplica" HeaderText="Aplica" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Saldo" HeaderText="Pendiente" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
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
