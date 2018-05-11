<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybPosicionCaja.aspx.vb" Inherits="cybPosicionCaja" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			
			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="498" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Posición de Caja</P>
					</TD>
				</TR>

				<TR>
					<TD>
						
			<TABLE class="tabla" id="Table1" 
				cellSpacing="1" cellPadding="1" width="135" border="0">
				<TR>
					<TD style="WIDTH: 108px">Tipo Cambio</TD>
					<TD style="WIDTH: 46px">
						<asp:label id="lbltc" runat="server" Width="31px" CssClass="Dato"></asp:label></TD>
				</TR>
			</TABLE>
					</TD>
				</TR>


				<TR>
					<TD>
    			<asp:label id="lblmsg" 
                runat="server"
				Width="316px" CssClass="msg"></asp:label>
					</TD>
				</TR>


				<TR>
					<TD>
						
			<TABLE id="Table7"  cellSpacing="1"
				cellPadding="1" width="300" border="0">
				<TR>
					<TD style="HEIGHT: 9px">
						<asp:datagrid id="dgPosicionCaja" runat="server" BorderWidth="1px" CellPadding="2" Height="111px"
							AutoGenerateColumns="False" CssClass="Grid" Width="487px" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NomBanco" HeaderText="Banco">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroCuenta" HeaderText="N&#250;mero de Cuenta">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SaldoSoles" HeaderText="Saldo S/." DataFormatString="{0:###,###,###,##0.00}">
									<HeaderStyle Width="95px"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SaldoDolares" HeaderText="Saldo $" DataFormatString="{0:###,###,###,##0.00}">
									<HeaderStyle Width="95px"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False"></asp:BoundColumn>
								<asp:BoundColumn Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 50px">
						<TABLE id="Table9" style="WIDTH: 487px; HEIGHT: 118px" cellSpacing="1" cellPadding="1"
							width="487" border="1" class="tabla" borderColor="#cccccc"	>
							<TR>
								<TD style="WIDTH: 298px" class="GridHeader">Resumen</TD>
								<TD style="WIDTH: 95px" class="GridHeader">Saldos S/.</TD>
								<TD style="WIDTH: 94px" class="GridHeader">Saldo $</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 320px" colSpan="2">Total Caja y Bancos en Dólares</TD>
								<TD align="right">
									<asp:label id="BancoDolar" runat="server" CssClass="Dato" Width="93px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 298px; HEIGHT: 19px">Total stock boletos comprados sin uso</TD>
								<TD style="WIDTH: 94px; HEIGHT: 19px" align="right">
									<asp:label id="StkComSoles" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
								<TD style="HEIGHT: 19px" align="right">
									<asp:label id="StkComDolar" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 298px; HEIGHT: 16px">Ingreso pendiente a Bancos</TD>
								<TD style="WIDTH: 94px; HEIGHT: 16px" align="right">
									<asp:label id="PendSoles" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
								<TD style="HEIGHT: 16px" align="right">
									<asp:label id="PendDolar" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 298px">Cuentas por Cobrar</TD>
								<TD style="WIDTH: 94px" align="right">
									<asp:label id="CobrarSoles" runat="server" CssClass="Dato" Width="94px"></asp:label></TD>
								<TD align="right">
									<asp:label id="CobrarDolar" runat="server" CssClass="Dato" Width="93px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 298px; HEIGHT: 19px" class="error">Cuentas por Pagar</TD>
								<TD style="WIDTH: 94px; HEIGHT: 19px" align="right">
									<asp:label id="PagarSoles" runat="server" CssClass="Dato" Width="94px"></asp:label></TD>
								<TD align="right" style="HEIGHT: 19px">
									<asp:label id="PagarDolar" runat="server" CssClass="Dato" Width="93px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 298px; HEIGHT: 19px">Saldos del personal</TD>
								<TD style="WIDTH: 94px; HEIGHT: 19px" align="right">
									<asp:label id="PersonalSoles" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
								<TD style="HEIGHT: 19px" align="right">
									<asp:label id="PersonalDolar" runat="server" Width="93px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD class="error" style="WIDTH: 298px; HEIGHT: 20px">Provisiones pendientes de pago 
									al personal</TD>
								<TD style="WIDTH: 94px; HEIGHT: 20px" align="right">
									<asp:label id="ProvisionSoles" runat="server" Width="94px" CssClass="Dato"></asp:label></TD>
								<TD style="HEIGHT: 20px" align="right">
									<asp:label id="ProvisionDolar" runat="server" Width="93px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 320px" colSpan="2">Posicion de Caja en Dolares</TD>
								<TD align="right" style="FONT-WEIGHT: bold">
									<asp:label id="Total" runat="server" CssClass="Dato" Width="93px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="error" style="WIDTH: 320px" colSpan="2">Fondo Pandero</TD>
								<TD align="right">
									<asp:label id="PanderoDolar" runat="server" Width="93px" CssClass="Dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 320px" colSpan="2">Posicion Neto&nbsp;de Caja en Dolares</TD>
								<TD style="FONT-WEIGHT: bold" align="right">
									<asp:label id="NetoDolar" runat="server" Width="93px" CssClass="Dato"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>

					</TD>
				</TR>


			</TABLE>
		</form>
</body>
</html>
