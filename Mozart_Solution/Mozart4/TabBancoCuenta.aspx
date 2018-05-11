<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabBancoCuenta.aspx.vb" Inherits="TabBancoCuenta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 546px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="546" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Cuentas del&nbsp;
							<asp:Label id="lblBanco" runat="server" Cssclass="Titulo"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 488px; HEIGHT: 96px" cellSpacing="0" cellPadding="0"
							width="488" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 28px"><FONT size="2">&nbsp;Secuencia</FONT></TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="3"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px">&nbsp;Tipo Cuenta</TD>
								<TD>
									<asp:textbox id="txtTipoCuenta" runat="server" Width="148px" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px">&nbsp;Nro Cuenta</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtNombre" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 20px">&nbsp;Cta Deposito</TD>
								<TD style="HEIGHT: 20px">
									<asp:radiobutton id="rbtSI" runat="server" Text="SI" GroupName="Grupo3"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtNO" runat="server" Text="NO" GroupName="Grupo3" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									|(SI =deposito x TC&nbsp;&nbsp;&nbsp; NO=solo confirma )</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 20px">&nbsp;Moneda</TD>
								<TD style="HEIGHT: 20px">
									<asp:radiobutton id="rbDolares" runat="server" Checked="True" GroupName="Grupo1" Text="Dolares"></asp:radiobutton>
									<asp:radiobutton id="rbSoles" runat="server" GroupName="Grupo1" Text="Soles"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px">&nbsp;Estado</TD>
								<TD>
									<asp:radiobutton id="rbActivo" runat="server" Text="Activo" GroupName="Grupo2" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" Text="Inactivo" GroupName="Grupo2"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="536px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgBancoCuenta" runat="server" Width="548px"  Height="17px"
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid"
							AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="SecBanco" SortExpression="SecBanco" HeaderText="Sec.">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroCuenta" SortExpression="NroCuenta" HeaderText="NroCuenta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Tipo" SortExpression="Tipo" HeaderText="Tipo Cuenta"></asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="Moneda">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsCuenta" SortExpression="NomStsCuenta" HeaderText="Estado">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagCtaDeposito" SortExpression="FlagCtaDeposito" HeaderText="CtaDep">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
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
