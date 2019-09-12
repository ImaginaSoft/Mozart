<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppRegistraCredito.aspx.vb" Inherits="cppRegistraCredito" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

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
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 517px; POSITION: absolute; TOP: 8px; HEIGHT: 263px"
				cellSpacing="0" cellPadding="1" width="517" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Registra&nbsp;Nota de Crédito</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 573px; HEIGHT: 92px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="573" border="1">
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 13px">&nbsp;
									<asp:label id="Label4" runat="server" Width="103px">Tipo Documento</asp:label></TD>
								<TD style="HEIGHT: 13px">&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" DataValueField="TipoDocumento"
										DataTextField="NomDocumento"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label><asp:textbox id="txtNroDocumento" runat="server" Width="77px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 7px">&nbsp;
									<asp:label id="Label5" runat="server" Width="85px"> Fecha</asp:label></TD>
								<TD style="HEIGHT: 7px">&nbsp;
									<asp:textbox id="txtFchEmision" runat="server" Width="75px"  CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="223px" Height="8px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchEmision"> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 22px">&nbsp;
									<asp:label id="Label1" runat="server"> Referencia</asp:label></TD>
								<TD style="HEIGHT: 22px">&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="312px" MaxLength="50"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="error" ForeColor=" " ControlToValidate="txtReferencia"
										ErrorMessage="Dato obligatorio"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 17px">&nbsp;
									<asp:label id="Label7" runat="server">Importe</asp:label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtImporte" runat="server" Width="93px" AutoPostBack="True"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="error" ForeColor=" " ControlToValidate="txtImporte"
										ErrorMessage="Dato obligatorio"></asp:requiredfieldvalidator>&nbsp;
									<asp:radiobutton id="rbdolar" runat="server" GroupName="GRUPO1" Checked="True" Text="Dólares"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" GroupName="GRUPO1" Text="Nuevo Soles"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px">&nbsp;</TD>
								<TD>&nbsp;&nbsp;
									<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar " Height="25px"></asp:button><asp:label id="txtPedido" runat="server" Width="278px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"><asp:label id="lblmsg" runat="server" Width="415px" 
                            CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdTodos" runat="server" Text="Todos Doc"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdPedido" runat="server" Width="96px" Text="Doc x Pedido"></asp:Button></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgServicio" runat="server" Width="600px" Height="24px" CssClass="Grid" CellPadding="2"
							BorderWidth="1px" AutoGenerateColumns="False" BorderColor="CadetBlue" DataKeyNames="KeyReg">
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
								<asp:BoundField DataField="NroDocumento" HeaderText="Nro Doc"></asp:BoundField>
								<asp:BoundField DataField="Referencia" HeaderText="Referencia"></asp:BoundField>
								<asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>
								<asp:BoundField DataField="Saldo" HeaderText="Saldo"></asp:BoundField>
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
