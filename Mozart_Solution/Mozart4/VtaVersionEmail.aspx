<%@ Page Language="VB" ValidateRequest="false"  AutoEventWireup="false" CodeFile="VtaVersionEmail.aspx.vb" Inherits="VtaVersionEmail" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="1" leftMargin="1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 16px; WIDTH: 624px; POSITION: absolute; TOP: 8px; HEIGHT: 47px"
				cellSpacing="0" cellPadding="1" width="624" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD><uc1:ucversion id="UcVersion1" runat="server"></uc1:ucversion></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 629px; HEIGHT: 240px" cellSpacing="0" cellPadding="0"
							width="629" border="0">
							<TR>
								<TD style="WIDTH: 48px; HEIGHT: 23px">De</TD>
								<TD style="HEIGHT: 23px" align="left"><asp:textbox id="txtDesde" runat="server" Width="464px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px; HEIGHT: 24px">Para</TD>
								<TD style="HEIGHT: 24px" align="left"><asp:textbox id="txtPara" runat="server" Width="464px"></asp:textbox>&nbsp;
									<asp:button id="cmSend" runat="server" Width="83px" Text="Enviar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px; HEIGHT: 17px">Cc</TD>
								<TD style="HEIGHT: 17px" align="left"><asp:textbox id="txtCC" runat="server" Width="463px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px; HEIGHT: 7px">Asunto</TD>
								<TD style="HEIGHT: 7px" align="left"><asp:textbox id="txtAsunto" runat="server" Width="463px"></asp:textbox><asp:label id="lblTipoCliente" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px"></TD>
								<TD align="left"><FTB:FREETEXTBOX id="FreeTextBox1" runat="server"></FTB:FREETEXTBOX></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px"></TD>
								<TD align="left">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px">Archivo</TD>
								<TD><INPUT id="UploadImage" style="WIDTH: 435px; HEIGHT: 22px" type="file" size="53" name="UploadImage"
										runat="server">&nbsp;&nbsp;&nbsp;
									<asp:button id="cmdAdjuntar" runat="server" Text="Adjuntar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px"></TD>
								<TD><asp:label id="lblMsg" runat="server" Width="545px" Height="22px" CssClass="msg"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 48px"></TD>
								<TD><asp:datagrid id="dgFile" runat="server" Width="580px" Height="20px" BorderStyle="None" CssClass="Grid"
										BorderColor="CadetBlue" BorderWidth="2px" CellPadding="2" AutoGenerateColumns="False">
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
			</TABLE>
		</FORM>
</body>
</html>
