<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaTareaResumen.aspx.vb" Inherits="vtaTareaResumen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table7" style="Z-INDEX: 101; LEFT: 11px; WIDTH: 547px; POSITION: absolute; TOP: 15px; HEIGHT: 105px"
				cellSpacing="0" cellPadding="0" width="547" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 19px">Resumen de Tareas Vencidas+Pendientes</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 427px; HEIGHT: 33px" cellSpacing="1" cellPadding="1"
							width="427" border="1">
							<TR>
								<TD style="WIDTH: 36px">&nbsp; Del</TD>
								<TD>
									<asp:textbox id="txtFchInicial" runat="server" ReadOnly="True" Width="75px" CssClass="fd"></asp:textbox>
									<INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" CssClass="error" ControlToValidate="txtFchInicial"
										ForeColor=" " Height="8px">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" ReadOnly="True" Width="75px" CssClass="fd"></asp:textbox>
									<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" CssClass="error" ControlToValidate="txtFchFinal"
										ForeColor=" " Height="8px">*</asp:requiredfieldvalidator></TD>
								<TD>
									<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<asp:label id="lblmsg" runat="server" Width="462px" CssClass="msg"></asp:label>
						<asp:label id="lblColumnas" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgLista" runat="server" Width="539px" CssClass="Grid" Height="25px" BorderColor="#CCCCCC"
							CellPadding="2" BorderWidth="1px" Font-Size="XX-Small">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" CssClass="GridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblerror" runat="server" Width="513px" CssClass="error" 
                            Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</FORM>
</body>
</html>
