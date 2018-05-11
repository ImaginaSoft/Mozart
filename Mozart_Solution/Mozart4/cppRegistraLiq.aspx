<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraLiq.aspx.vb" Inherits="cppRegistraLiq" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 592px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="592" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Registra&nbsp;Liquidación</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD>
									<TABLE class="tabla" id="Table1" style="WIDTH: 363px; HEIGHT: 138px" cellSpacing="0" cellPadding="0"
										width="363" border="1">
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 13px">Tipo Documento&nbsp;</TD>
											<TD style="HEIGHT: 13px">&nbsp;
												<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 13px">Nro Documento</TD>
											<TD style="HEIGHT: 13px">&nbsp;
												<asp:label id="lblNroDocumento" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 3px">Fecha Emisión&nbsp;</TD>
											<TD style="HEIGHT: 3px">&nbsp;
												<asp:label id="lblFchEmision" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 13px">Referencia&nbsp;</TD>
											<TD style="HEIGHT: 13px">&nbsp;
												<asp:label id="lblReferencia" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 21px">Banco&nbsp;</TD>
											<TD style="HEIGHT: 21px">&nbsp;
												<asp:label id="lblNomBanco" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 99px; HEIGHT: 16px">Nro Cuenta&nbsp;</TD>
											<TD style="HEIGHT: 16px">&nbsp;
												<asp:label id="lblNroCuenta" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 271px; HEIGHT: 139px" cellSpacing="1" cellPadding="1"
										width="271" border="1">
										<TR>
											<TD style="WIDTH: 92px">Estado Doc.</TD>
											<TD>&nbsp;
												<asp:label id="lblStsDoc" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 92px">Importe</TD>
											<TD>&nbsp;
												<asp:label id="lblImporte" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 92px">Tipo Cambio</TD>
											<TD>&nbsp;
												<asp:label id="lblTipoCambio" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 92px">Pago Proveedor</TD>
											<TD>&nbsp;
												<asp:label id="lblPago" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="FONT-WEIGHT: bold; WIDTH: 92px">Pendiente</TD>
											<TD>&nbsp;
												<asp:Label id="lblPendiente" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="FONT-WEIGHT: bold; WIDTH: 92px" colSpan="1">&nbsp;</TD>
											<TD>
												<asp:button id="cmdGrabar" runat="server" Text="Liquidar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" Width="346px"  CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:GridView id="dgDocumento" runat="server" Width="600px" Height="24px" CssClass="Grid" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" DataKeyNames="KeyReg">
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
								<asp:BoundField DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="TipoDocumento" SortExpression="NroReporte" HeaderText="Tipo"></asp:BoundField>
								<asp:BoundField DataField="NroDocumento" HeaderText="Nro Doc"></asp:BoundField>
								<asp:BoundField DataField="NroPedido" HeaderText="Pedido" DataFormatString="{0:########}"></asp:BoundField>
								<asp:BoundField DataField="Referencia" HeaderText="Referencia"></asp:BoundField>
								<asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Moneda" HeaderText="Moneda"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;
						<asp:Label id="lblsaldo" runat="server" Visible="False"></asp:Label>
						<asp:label id="lblCodMoneda" runat="server" Visible="False"></asp:label><asp:label id="lblMoneda" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</form>
</body>
</html>
