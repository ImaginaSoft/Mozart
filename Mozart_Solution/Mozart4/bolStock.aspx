<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bolStock.aspx.vb" Inherits="bolStock" %>

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
				cellSpacing="0" cellPadding="1" width="565" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Consulta Stock de Boletos</P>
					</TD>
				</TR>
				
				<TR>
					<TD>
					<TABLE class="tabla" id="Table4" 
				cellSpacing="1" cellPadding="1" width="440" border="1" borderColor="#cccccc"	>
				<TR>
					<TD style="WIDTH: 182px">A partir de la fecha de ingreso</TD>
					<TD>&nbsp;
						<asp:textbox id="txtFchIngreso" runat="server"  AutoPostBack="True" Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchIngreso" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchIngreso',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchIngreso">&nbsp;
						<asp:requiredfieldvalidator id="rfvFchIngreso" runat="server" Width="11px" 
                            ControlToValidate="txtFchIngreso">*</asp:requiredfieldvalidator></TD>
					<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
				</TR>
			</TABLE>
					</TD>
				</TR>


				<TR>
					<TD>				
								<asp:datagrid id="dgStock"  runat="server"
				Width="568px" Height="17px" CellPadding="2" BorderWidth="1px" AutoGenerateColumns="False"
				CssClass="Grid" BorderColor="CadetBlue">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Boletos" HeaderText="Ver" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="FchIngreso" HeaderText="Ingreso" DataFormatString="{0:dd-MM-yyyy}">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Forma" HeaderText="Forma">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="serieinicial" HeaderText="Serie Inicial">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="seriefinal" HeaderText="Serie Final">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Boletos" HeaderText="Boletos">
						<ItemStyle HorizontalAlign="Center" ForeColor="#FF9966"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CodProveedor" HeaderText="CodProveedor"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
					</TD>
				</TR>
			
				
				<TR>
					<TD>
										<br />
										<asp:label id="lblmsg" runat="server"
				Width="715px"  ForeColor="Red"></asp:label>
					</TD>
				</TR>
				
				
			</TABLE>
		</form>
</body>
</html>
