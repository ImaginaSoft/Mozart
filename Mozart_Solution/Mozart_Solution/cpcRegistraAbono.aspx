<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcRegistraAbono.aspx.vb" Inherits="cpcRegistraAbono" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

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
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 555px; POSITION: absolute; TOP: 8px; HEIGHT: 216px"
				cellSpacing="0" cellPadding="0" width="555" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Registra&nbsp;Nota de Abono</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 538px; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
							width="538" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 24px">&nbsp; Tipo Documento</TD>
								<TD style="HEIGHT: 24px">&nbsp;
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="288px" DataTextField="NomDocumento"
										DataValueField="TipoDocumento"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblNroDocumento" runat="server">Nro.</asp:label>
									<asp:textbox id="txtNroDocumento" runat="server" Width="77px" ReadOnly="True" BackColor="#C0FFFF"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 7px">&nbsp; Fecha</TD>
								<TD style="HEIGHT: 7px">&nbsp;
									<asp:textbox id="txtFchEmision" runat="server" Width="75px" ReadOnly="True" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchEmision" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchEmision">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="223px" Height="8px" ControlToValidate="txtFchEmision"
										CssClass="error" ForeColor=" "> Dato obligatorio</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 22px">&nbsp; Referencia</TD>
								<TD style="HEIGHT: 22px">&nbsp;
									<asp:textbox id="txtReferencia" runat="server" Width="312px" MaxLength="50"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtReferencia" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 17px">&nbsp; Importe
									<asp:Label id="Label1" runat="server" CssClass="error">(TAB)</asp:Label></TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtImporte" runat="server" Width="89px" AutoPostBack="True"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporte" ErrorMessage="Dato obligatorio"
										CssClass="error" ForeColor=" "></asp:requiredfieldvalidator>&nbsp;
									<asp:radiobutton id="rbdolar" runat="server" Text="Dólares" Checked="True" GroupName="GRUPO1"></asp:radiobutton><asp:radiobutton id="rbsoles" runat="server" Text="Nuevo Soles" GroupName="GRUPO1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 17px">&nbsp; IGV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtpIGV" runat="server" Width="30px" AutoPostBack="True"></asp:textbox>%</TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtIGV" runat="server" Width="89px" ForeColor="Silver" BackColor="WhiteSmoke"
										AutoPostBack="True" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 106px; HEIGHT: 17px">&nbsp; Total</TD>
								<TD style="HEIGHT: 17px">&nbsp;
									<asp:textbox id="txtTotal" runat="server" Width="91px" ForeColor="Silver" BackColor="WhiteSmoke"
										AutoPostBack="True" Enabled="False"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdGrabar" runat="server" Width="127px" Text="Grabar Nota Abono"></asp:button>&nbsp;
						<asp:Label id="txtPedido" runat="server" Width="278px"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="415px"  CssClass="Error"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:GridView id="dgServicio" runat="server" Width="700px" Height="24px" 
                            CssClass="Grid" AutoGenerateColumns="False"
							BorderWidth="1px" CellPadding="2" BorderColor="CadetBlue" DataKeyNames="KeyReg" 
                            UseAccessibleHeader="False">
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
							
								<asp:BoundField DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yy}"></asp:BoundField>
								<asp:BoundField DataField="TipoDocumento" SortExpression="NroReporte" HeaderText="Tipo"></asp:BoundField>
								<asp:BoundField DataField="NroDocumento" HeaderText="Nro Doc"></asp:BoundField>
								<asp:BoundField DataField="Referencia" HeaderText="Referencia"></asp:BoundField>
								<asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Saldo" HeaderText="Pendiente" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Moneda" HeaderText="Moneda"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
		</form>
</body>
</html>
