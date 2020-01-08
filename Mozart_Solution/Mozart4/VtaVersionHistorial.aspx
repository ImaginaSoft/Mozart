﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionHistorial.aspx.vb" Inherits="VtaVersionHistorial" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 593px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="593"  border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 430px; HEIGHT: 175px" cellSpacing="0" cellPadding="0"
							width="430" border="1">
							<TR>
								<TD style="HEIGHT: 7px">
									<asp:RadioButton id="rbtLibre" runat="server" Text="Mensaje Libre" GroupName="g1" Checked="True"></asp:RadioButton>&nbsp;
									<asp:RadioButton id="rbtEntrada" runat="server" Text="Mensaje Entrada" GroupName="g1"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rbtSalida" runat="server" Text="Mensaje Salida" GroupName="g1"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 7px"></TD>
							</TR>
							<TR>
								<TD>&nbsp;
									<asp:textbox id="txtDesLog" runat="server" Width="419px" Height="128px" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;
									<asp:button id="cmbGrabar" runat="server" Width="80px" Text="Grabar"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="rfvNomPedido" runat="server" Width="93px" ForeColor=" " CssClass="error" ErrorMessage="Dato obligatorio"
										ControlToValidate="txtDesLog"></asp:requiredfieldvalidator></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="545px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgHistorial" runat="server" Width="582px" Height="20px" BorderStyle="None" AutoGenerateColumns="False"
							BorderColor="CadetBlue" BorderWidth="2px" CellPadding="2" CssClass="Grid">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FchAct" HeaderText="Fecha ">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DesLog" HeaderText="Descripci&#243;n">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoLog" HeaderText="TipoLog">
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
		</FORM>

</body>
</html>
