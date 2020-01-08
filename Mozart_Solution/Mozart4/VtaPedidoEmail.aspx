<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaPedidoEmail.aspx.vb" Inherits="VtaPedidoEmail" %>
<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="frmRTB" method="post" runat="server">
			<TABLE class="form" id="Table4" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 1px"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
                        <uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<asp:Label id="lblPaginaPersonalizada" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"><asp:label id="lblUltRecordatorio" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">Recordatorio
						<asp:dropdownlist id="ddlRecordatorio" runat="server" Width="480px" DataTextField="DesRecordatorio"
							DataValueField="NroRecordatorio" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 560px; HEIGHT: 125px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="560" border="1">
							<TR>
								<TD style="WIDTH: 33px; HEIGHT: 5px"></TD>
								<TD style="HEIGHT: 7px" align="left">
									<asp:label id="lblMsg" runat="server" Width="472px" CssClass="error"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 33px; HEIGHT: 5px">De</TD>
								<TD style="HEIGHT: 7px" align="left">
									<asp:textbox id="txtDesde" runat="server" Width="382px"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 33px; HEIGHT: 7px">Para</TD>
								<TD style="HEIGHT: 7px" align="left">
									<asp:textbox id="txtPara" runat="server" Width="382px"></asp:textbox>&nbsp;
									<asp:button id="cmdSend" runat="server" Width="83px" Text="Enviar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 33px; HEIGHT: 19px">Cc</TD>
								<TD style="HEIGHT: 19px" align="left">
									<asp:textbox id="txtCC" runat="server" Width="382px"></asp:textbox>&nbsp;
									<asp:label id="lblNroRecordatorio" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 33px; HEIGHT: 7px">Asunto</TD>
								<TD style="HEIGHT: 7px" align="left">
									<asp:textbox id=txtAsunto runat="server" Width="496px" Text='<%# DataBinder.Eval(dsEdit, "Tables[TRECORDATORIO].DefaultView.[0].Asunto") %>'>
									</asp:textbox>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<ftb:FreeTextBox ID="FreeTextBox1" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[TRECORDATORIO].DefaultView.[0].Mensaje") %>'>
                        </ftb:FreeTextBox>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<TABLE class="tabla" id="Table3" style="WIDTH: 552px; HEIGHT: 35px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="552" border="1">
							<TR>
								<TD style="HEIGHT: 18px">Archivo</TD>
								<TD style="HEIGHT: 18px"><INPUT id="UploadImage" style="WIDTH: 410px; HEIGHT: 22px" type="file" size="49" name="UploadImage"
										runat="server">&nbsp;&nbsp;
									<asp:button id="cmdAdjuntar" runat="server" Text="Adjuntar"></asp:button></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<asp:datagrid id="dgFile" runat="server" Width="497px" Height="20px" CssClass="Grid" CellPadding="2"
										BorderWidth="1px" BorderColor="CadetBlue" AllowSorting="True" AutoGenerateColumns="False"
										BorderStyle="None">
										<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
										<ItemStyle CssClass="GridData"></ItemStyle>
										<HeaderStyle CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="Eliminar" HeaderText="Opci&#243;n" CommandName="select"></asp:ButtonColumn>
											<asp:BoundColumn DataField="DirFileOrigen" HeaderText="Archivo"></asp:BoundColumn>
											<asp:BoundColumn DataField="TamFile" HeaderText="Tama&#241;o"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
