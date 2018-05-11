<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybConfirma.aspx.vb" Inherits="cybConfirma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 882px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="882" border="0" class="form">
				<TR>
					<TD style="HEIGHT: 21px">
						<P class="Titulo">&nbsp;Pagos pendientes de procesar</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 17px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;
						<asp:LinkButton id="lbtDeposito" runat="server">Confirma Depósito por Tarjeta de Crédito</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="594px"  CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px">
						<asp:GridView id="dgPagos" runat="server" Width="883px" CssClass="Grid" BorderColor="CadetBlue"
							Height="17px" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"  DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonField Text="Editar" CommandName="select"></asp:ButtonField>
								<asp:BoundField DataField="FchEmision" HeaderText="Fecha" DataFormatString="{0:dd-MM-yy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="TipoDocumento" HeaderText="Tipo">
									<ItemStyle HorizontalAlign="center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroDocumento" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="Moneda" HeaderText=" ">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="DocMonto" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="ComisionTC" HeaderText="Comisi&#243;n" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:TemplateField HeaderText="Referencia">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Referencia")%>' NavigateUrl='<%# "cybConfirmaPago.aspx?TipoDocumento=" + DataBinder.Eval(Container.DataItem,"TipoDocumento")+"&NroDocumento="+cstr(DataBinder.Eval(Container.DataItem,"NroDocumento"))+"&Opcion=R"%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="GlosaDocumento" HeaderText="Titular"></asp:BoundField>
								<asp:BoundField DataField="CodAutoriza" HeaderText="C&#243;d.Autorizaci&#243;n"></asp:BoundField>
								<asp:BoundField DataField="NomBanco" HeaderText="Banco">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NroCuenta" HeaderText="Cuenta">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField DataField="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
								<asp:BoundField  DataField="TipoOperacion" HeaderText="TipoOperacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundField>
								<asp:BoundField  DataField="FlagComisionTC" HeaderText="FlagComisionTC">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundField>
								<asp:BoundField  DataField="FlagCtaDeposito" HeaderText="FlagCtaDeposito">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundField>
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
