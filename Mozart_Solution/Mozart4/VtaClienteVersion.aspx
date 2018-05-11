<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaClienteVersion.aspx.vb" Inherits="VtaClienteVersion" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 693px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="693" border="0" class="FORM">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Versiones del Cliente</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 528px; HEIGHT: 29px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="528" border="0">
							<TR>
								<TD style="WIDTH: 140px">Fecha solicitud peru4all</TD>
								<TD style="WIDTH: 300px">
									<asp:textbox id="txtFchInicial" runat="server" CssClass="fd" Width="75px"  DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">&nbsp;&nbsp;
									<asp:label id="lblAl" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>
									<asp:textbox id="txtFchFinal" runat="server" CssClass="fd" Width="75px"  DESIGNTIMEDRAGDROP="25"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
								</TD>
								<TD align="left">
									<asp:button id="cmdBuscar" runat="server" Width="72px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Height="19px" Width="573px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgVersion" runat="server" Height="17px" Width="800px" AutoGenerateColumns="False"
							AllowSorting="True" BorderWidth="1px" CellPadding="2" CssClass="Grid" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<EditItemStyle CssClass="GridData"></EditItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" HeaderText="Pedido">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" HeaderText="Prop.">
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" HeaderText="Version">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchVersion" HeaderText="Fch.Versi&#243;n" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchSolicita" HeaderText="Fch.Solicita" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomComprador" HeaderText="Cliente Age."></asp:BoundColumn>
								<asp:BoundColumn DataField="DesVersion" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="StsVersion" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchRpta" HeaderText="Fch.Rpta" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomFlagAnulaFact" HeaderText="Facturaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsVersion" HeaderText="CodStsVersion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FlagAnulaFact" HeaderText="FlagAnulaFact">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
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
