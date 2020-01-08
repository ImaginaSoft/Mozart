<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolReporteVenta.aspx.vb" Inherits="bolReporteVenta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 92px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 576px; POSITION: absolute; TOP: 8px; HEIGHT: 104px"
				cellSpacing="0" cellPadding="1" width="576" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;Reporte de Ventas</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Label id="lblfchfinal" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblfchinicial" runat="server" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 520px; HEIGHT: 33px" cellSpacing="1" cellPadding="1"
							width="520" border="1" borderColor="#cccccc"	>
							<TR>
								<TD style="WIDTH: 116px">&nbsp;Fecha Emisión del
								</TD>
								<TD><asp:textbox id="txtFchInicial" runat="server" CssClass="fd" Width="75px" ></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchInicial">
									<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" CssClass="error" Height="8px" Width="18px" ForeColor=" "
										ControlToValidate="txtFchInicial">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
									<asp:textbox id="txtFchFinal" runat="server" CssClass="fd" Width="75px" ></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
										tabIndex="2" type="button" value="..." name="cmdFchFinal">
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="error" Height="8px" Width="18px"
										ForeColor=" " ControlToValidate="txtFchFinal">*</asp:requiredfieldvalidator></TD>
								<TD class="style1"><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="462px" CssClass="msg" ></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgReportes" runat="server" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
							BorderColor="CadetBlue" CssClass="Grid" Height="17px" Width="568px" OnItemDataBound="ComputeSum"
							ShowFooter="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Boletos" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodLinea" HeaderText="C&#243;d."></asp:BoundColumn>
								<asp:BoundColumn DataField="NomLinea" HeaderText="Linea"></asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision1" HeaderText="Comi.1" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV1" HeaderText="IGV" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Comision2" HeaderText="Comi.2" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IGV2" HeaderText="IGV" DataFormatString="{0:###,###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CodProveedor" HeaderText="CodProveedor">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
