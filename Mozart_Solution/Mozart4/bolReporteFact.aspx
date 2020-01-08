<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolReporteFact.aspx.vb" Inherits="bolReporteFact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
		
			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="676" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							Reportes&nbsp;Facturados</P>
					</TD>
				</TR>

				<TR>
					<TD>
			<TABLE class="tabla" id="Table2" 
				cellSpacing="1" cellPadding="1" width="520" border="1" borderColor="#cccccc"	>
				<TR>
					<TD style="WIDTH: 116px">&nbsp;Fecha Reporte del
					</TD>
					<TD>
						<asp:textbox id="txtFchInicial" runat="server" CssClass="fd" Width="75px" ></asp:textbox>
						<INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchInicial">
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Height="8px" CssClass="error" Width="18px"
							ForeColor=" " ControlToValidate="txtFchInicial">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
						<asp:textbox id="txtFchFinal" runat="server" CssClass="fd" Width="75px" ></asp:textbox>
						<INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchFinal">
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Height="8px" CssClass="error" Width="18px"
							ForeColor=" " ControlToValidate="txtFchFinal">*</asp:requiredfieldvalidator></TD>
					<TD>
						<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
				</TR>
			</TABLE>
                        
					</TD>
				</TR>



				<TR>
					<TD>
			<asp:datagrid id="dgReporte" 
				runat="server" Width="680px" CssClass="Grid" BorderColor="CadetBlue" Height="17px" 
				AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Boletos" CommandName="select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Referencia" HeaderText="Linea ">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###.00} ">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodMoneda" HeaderText="Moneda">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="StsDocumento" HeaderText="Estado">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>

					</TD>
				</TR>


				<TR>
					<TD>
        			<asp:label id="lblmsg"  runat="server"
		    		Width="715px" CssClass="msg"></asp:label>
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
