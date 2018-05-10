<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcRegistraReembolso.aspx.vb" Inherits="cpcRegistraReembolso" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 378px"
				cellSpacing="0" cellPadding="1" width="536" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Registra&nbsp;Reembolso al Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 266px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 560px; HEIGHT: 232px" cellSpacing="0" cellPadding="0"
							width="560" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 13px">&nbsp;Tipo Documento</TD>
								<TD style="HEIGHT: 13px"><asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" DataTextField="NomDocumento"
										DataValueField="TipoDocumento"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label><asp:textbox id="txtNroDocumento" runat="server" Width="77px" ReadOnly="True" BackColor="#C0FFFF"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 7px">&nbsp;Fecha Emisión</TD>
								<TD style="HEIGHT: 7px"><asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd"></asp:textbox><INPUT id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="223px" Height="8px" CssClass="Error" ForeColor=" "
										ControlToValidate="txtFchEmision"> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 7px">&nbsp;Nro. Pedido</TD>
								<TD style="HEIGHT: 7px"><asp:dropdownlist id="ddlNumeroPedido" runat="server" Width="408px" DataTextField="DesPedido"
										DataValueField="NroPedido"></asp:dropdownlist>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 24px">&nbsp;Referencia</TD>
								<TD style="HEIGHT: 24px"><asp:textbox id="txtReferencia" runat="server" Width="352px" MaxLength="50"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="Error" ForeColor=" " ControlToValidate="txtReferencia"
										ErrorMessage="Obligatorio"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Titular Tarjeta</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtGlosa" runat="server" Width="352px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Importe
									<asp:label id="Label1" runat="server" CssClass="error">(TAB)</asp:label></TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtImporte" runat="server" Width="93px" MaxLength="11" AutoPostBack="True"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="Error" ForeColor=" " ControlToValidate="txtImporte"
										ErrorMessage="Obligatorio"></asp:requiredfieldvalidator>&nbsp;
									<asp:radiobutton id="rbdolar" runat="server" AutoPostBack="True" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton>&nbsp;<asp:radiobutton id="rbsoles" runat="server" AutoPostBack="True" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Tipo Cambio</TD>
								<TD style="HEIGHT: 17px"><asp:textbox id="txtTipoCambio" runat="server" Width="93px" MaxLength="11" AutoPostBack="True"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblpc" runat="server">Pago al Cliente</asp:label>&nbsp;
									<asp:textbox id="txtPagoCliente" runat="server" Width="91px" ForeColor="Silver" MaxLength="11"
										Enabled="False"></asp:textbox>&nbsp;
									<asp:label id="lblSimbolo" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 17px">&nbsp;Banco</TD>
								<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlBanco" runat="server" Width="288px"  DataTextField="NomBanco"
										DataValueField="CodBanco" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 27px">&nbsp;Nro. Cuenta</TD>
								<TD style="HEIGHT: 27px"><asp:dropdownlist id="ddlNroCuenta" runat="server" 
                                        Width="288px" DataTextField="NroCuenta"
										DataValueField="SecBanco"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 27px" colSpan="2">
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="cmdGrabar" runat="server" Width="85px" Text="Grabar "></asp:button>&nbsp;
									<asp:Label id="NC" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblMensaje" runat="server" Width="261px" CssClass="error"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblMsg" runat="server" CssClass="error"></asp:Label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgDocumento" runat="server" Width="700px" Height="17px" CssClass="Grid" OnItemDataBound="ComputeSum"
							ShowFooter="True" BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2" DataKeyNames="KeyReg">
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

							
								<asp:BoundField DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="TipoDocumento" SortExpression="NroReporte" HeaderText="Tipo"></asp:BoundField>
								<asp:BoundField DataField="NroDocumento" HeaderText="Doc"></asp:BoundField>
								<asp:BoundField DataField="NroPedido" HeaderText="Pedido" DataFormatString="{0:########}"></asp:BoundField>
								<asp:BoundField DataField="Referencia" HeaderText="Referencia"></asp:BoundField>
								<asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Saldo" HeaderText="Pendiente" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
