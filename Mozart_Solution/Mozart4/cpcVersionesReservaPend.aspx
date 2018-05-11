<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcVersionesReservaPend.aspx.vb" Inherits="cpcVersionesReservaPend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 13px; WIDTH: 575px; POSITION: absolute; TOP: 14px; HEIGHT: 54px"
				cellSpacing="0" cellPadding="0" width="575" border="0" class="Form">
				<TR>
					<TD>
						<P class="Titulo">
							Versiones con&nbsp;Reservas&nbsp;Pendientes&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 520px; HEIGHT: 26px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="520" border="1">
							<TR>
								<TD style="WIDTH: 71px">Proveedor</TD>
								<TD style="WIDTH: 68px">
									<asp:dropdownlist id="ddlProveedor" runat="server" Width="376px" DataValueField="CodProveedor"
										DataTextField="NomProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 71px">Vendedor</TD>
								<TD style="WIDTH: 68px">
									<asp:dropdownlist id="ddlVendedor" runat="server" DataTextField="NomVendedor" DataValueField="CodVendedor"
										Width="250px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px">
						<TABLE class="tabla" id="Table3" style="WIDTH: 520px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
							width="520" border="0">
							<TR>
								<TD style="WIDTH: 161px">Fecha inicio de la versión</TD>
								<TD style="WIDTH: 293px">
									<asp:textbox id="txtFchInicial" runat="server"  Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Width="18px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchInicial" Height="8px">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server"  Width="75px" CssClass="fd"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" CssClass="error" ForeColor=" "
										ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:button id="cmdConsultar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" CssClass="msg" Width="568px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgLista" runat="server" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"
							  Height="17px" BorderColor="CadetBlue" CssClass="Grid" Width="573px" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPedido" SortExpression="NroPedido" HeaderText="Pedido">
                                     <HeaderStyle CssClass="Hide" />
									<ItemStyle HorizontalAlign="Center" CssClass="Hide"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroPropuesta" SortExpression="NroPropuesta" HeaderText="NroPropuesta">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroVersion" HeaderText="N&#176;"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Cliente">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsVersion" SortExpression="NomStsVersion" HeaderText="Sts"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchInicio" SortExpression="FchInicio" HeaderText="Inicio" DataFormatString="{0:dd-MM-yyyy}">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OK" SortExpression="OK" HeaderText="OK">
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RQ" SortExpression="RQ" HeaderText="RQ">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="WL" SortExpression="WL" HeaderText="WL"></asp:BoundColumn>
								<asp:BoundColumn DataField="UC" SortExpression="UC" HeaderText="UC">
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PE" SortExpression="PE" HeaderText="PE"></asp:BoundColumn>
								<asp:BoundColumn DataField="PS" SortExpression="PS" HeaderText="PS">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FchRevision" SortExpression="FchRevision" HeaderText="Revisi&#243;n"
									DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodCliente" HeaderText="CodCliente">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
