<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraPago.aspx.vb" Inherits="cppRegistraPago" %>

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
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 592px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="592" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;Registra&nbsp;Pagos</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 549px; HEIGHT: 156px" cellSpacing="0" cellPadding="0"
							width="549" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 13px">&nbsp;
									<asp:label id="Label4" runat="server" Width="103px">Tipo Documento</asp:label></TD>
								<TD style="HEIGHT: 13px">&nbsp;&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" DataValueField="TipoDocumento"
										DataTextField="NomDocumento" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label><asp:textbox id="txtNroDocumento" runat="server" Width="77px" ReadOnly="True" BackColor="#C0FFFF"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 7px">&nbsp;
									<asp:label id="Label5" runat="server" Width="93px"> Fecha Emisión</asp:label></TD>
								<TD style="HEIGHT: 7px">&nbsp;
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" AutoPostBack="True" 
										CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="96px" Height="8px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchEmision"> Dato obligatorio</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblEstado" runat="server" Visible="False">Estado </asp:label>
									<asp:textbox id="txtEstado" runat="server" Width="77px" ReadOnly="True" Visible="False" BackColor="#C0FFFF"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 24px">&nbsp;
									<asp:label id="Label1" runat="server"> Referencia</asp:label></TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="292px" MaxLength="50"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="error" ForeColor=" " ControlToValidate="txtReferencia"
										ErrorMessage="Dato Obligatorio"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 17px">&nbsp;
									<asp:label id="Label7" runat="server">Importe</asp:label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtImporte" runat="server" Width="93px" AutoPostBack="True" MaxLength="11"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="error" ForeColor=" " ControlToValidate="txtImporte"
										ErrorMessage="Dato Obligatorio"></asp:requiredfieldvalidator>&nbsp;
									<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" GroupName="GRUPO1" Checked="True"
										Text="Dólares"></asp:radiobutton>&nbsp;<asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" GroupName="GRUPO1" Text="Nuevo Soles"></asp:radiobutton></TD>
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
									<asp:dropdownlist id="ddlBanco" runat="server" Width="288px" 
                                        DataValueField="CodBanco" DataTextField="NomBanco" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 27px">&nbsp;
									<asp:label id="lblnumeroC" runat="server" Width="85px">Nro Cuenta</asp:label></TD>
								<TD style="HEIGHT: 27px">&nbsp;
									<asp:dropdownlist id="ddlNroCuenta" runat="server" Width="288px" 
                                        DataValueField="SecBanco" DataTextField="NroCuenta"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Text="Grabar Pago"></asp:button>&nbsp;&nbsp;&nbsp;
						</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="584px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:GridView id="dgDocumento" runat="server" Width="600px" Height="24px" CssClass="Grid" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
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
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
			
		</form>
</body>
</html>
