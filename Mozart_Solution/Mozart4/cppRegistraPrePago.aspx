<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraPrePago.aspx.vb" Inherits="cppRegistraPrePago" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 592px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="592" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Registra&nbsp;Pre-Pagos</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 549px; HEIGHT: 156px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="549" border="1">
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 13px">&nbsp;
									<asp:label id="Label4" runat="server" Width="103px">Tipo Documento</asp:label></TD>
								<TD style="HEIGHT: 13px">&nbsp;&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" AutoPostBack="True"
										DataTextField="NomDocumento" DataValueField="TipoDocumento"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label><asp:textbox id="txtNroDocumento" runat="server" Width="77px" BackColor="#C0FFFF" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 7px">&nbsp;
									<asp:label id="Label5" runat="server" Width="93px"> Fecha Emisión</asp:label></TD>
								<TD style="HEIGHT: 7px">&nbsp;
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" R
										CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="96px" Height="8px" CssClass="error" ControlToValidate="txtFchEmision"
										ForeColor=" "> Dato obligatorio</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblEstado" runat="server" Visible="False">Estado </asp:label><asp:textbox id="txtEstado" runat="server" Width="77px" BackColor="#C0FFFF" ReadOnly="True" Visible="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 24px">&nbsp;
									<asp:label id="Label1" runat="server"> Referencia</asp:label></TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="292px" MaxLength="50"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="error" ControlToValidate="txtReferencia"
										ForeColor=" " ErrorMessage="Dato Obligatorio"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
									<asp:label id="Label7" runat="server">Importe Pago</asp:label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtImporte" runat="server" Width="93px" AutoPostBack="True" MaxLength="11"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="error" ControlToValidate="txtImporte"
										ForeColor=" " ErrorMessage="Dato Obligatorio"></asp:requiredfieldvalidator>&nbsp;
									<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton>&nbsp;<asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
									<asp:label id="lblTipoCambio" runat="server">Tipo Cambio</asp:label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtTipoCambio" runat="server" Width="93px" AutoPostBack="True" MaxLength="11"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblpc" runat="server">Pago al Proveedor</asp:label>&nbsp;
									<asp:textbox id="txtPagoCliente" runat="server" Width="91px" AutoPostBack="True" ForeColor="Silver"
										MaxLength="11" Enabled="False"></asp:textbox>&nbsp;
									<asp:label id="lblSimbolo" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
									<asp:label id="lblBanco" runat="server" Width="85px">Banco</asp:label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:dropdownlist id="ddlBanco" runat="server" Width="288px" AutoPostBack="True"  DataTextField="NomBanco"
										DataValueField="CodBanco"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 27px">&nbsp;
									<asp:label id="lblnumeroC" runat="server" Width="85px">Nro Cuenta</asp:label></TD>
								<TD style="HEIGHT: 27px">&nbsp;
									<asp:dropdownlist id="ddlNroCuenta" runat="server" Width="288px"  DataTextField="NroCuenta"
										DataValueField="SecBanco"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Text="Grabar Pago"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgDocumento" runat="server" Width="600px" Height="24px" CssClass="Grid" BorderColor="CadetBlue"
							AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Tipo">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label id="TipoDocumento" runat="server" Text='<%# Container.DataItem("TipoDocumento") %>' >
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Nro">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label id="NroDocumento" runat="server" Text='<%# Container.DataItem("NroDocumento") %>' >
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="Pedido" DataFormatString="{0:########}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Saldo">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label id="saldo" runat="server" Text='<%# Container.DataItem("Saldo") %>' >
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Moneda">
									<ItemTemplate>
										<asp:label id="Moneda" runat="server" Text='<%# Container.DataItem("Moneda") %>' >
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Pre-Pago">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtPago runat="server" Width="70px" Text='<%# Container.DataItem("Pago") %>' MaxLength="12">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Referencia" HeaderText="Referencia"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
