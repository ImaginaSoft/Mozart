<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybDocumentoBancos.aspx.vb" Inherits="cybDocumentoBancos" %>

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
				cellSpacing="0" cellPadding="1" width="784"  border="0">
				<TR>
					<TD>
						<P class="Titulo">Modificar/Anular Documentos</P>
					</TD>
				</TR>

				<TR>
					<TD>
			<TABLE class="tabla" id="Table4" 
				cellSpacing="1" cellPadding="1" width="402" border="1">
				<TR>
					<TD><asp:label id="Label3" runat="server" Width="110px">Movtos apartir de</asp:label></TD>
					<TD style="WIDTH: 137px"><asp:textbox id="txtFchEmision" runat="server" Width="75px" CssClass="fd"  AutoPostBack="True"></asp:textbox><INPUT class="fd" id="cmdFchEmision" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchEmision',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
							tabIndex="2" type="button" value="..." name="cmdFchEmision">&nbsp;
						<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="11px" Height="8px" ControlToValidate="txtFchEmision"
							CssClass="error" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
					<TD><asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
				</TR>
			</TABLE>

					</TD>
				</TR>


				<TR>
					<TD>
        			<asp:label id="lblmsg" 
                 runat="server"
				Width="715px" CssClass="msg"></asp:label>
					</TD>
				</TR>



				<TR>
					<TD>
			<asp:datagrid id="dgDBancos" 
				runat="server" Width="786px" CssClass="Grid" BorderColor="CadetBlue" Height="17px" AutoGenerateColumns="False"
				BorderWidth="1px" CellPadding="2">
				<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
				<ItemStyle CssClass="GridData"></ItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Editar" CommandName="select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="FchEmision" HeaderText="Fecha " DataFormatString="{0:dd-MM-yy}">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NroDocumento" HeaderText="Nro" DataFormatString="{0:########}">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Referencia" HeaderText="Referencia">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NomBanco" HeaderText="Banco"></asp:BoundColumn>
					<asp:BoundColumn DataField="NroCuenta" HeaderText="Cuenta"></asp:BoundColumn>
					<asp:BoundColumn DataField="CodMoneda">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="StsDocumento" HeaderText="Estado">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
					<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yy}{0,13:hh:mm tt }"></asp:BoundColumn>
					<asp:BoundColumn DataField="CodBanco">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TipoDocTransf">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NroDocTransf">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
						
					</TD>
				</TR>


				<TR>
					<TD>

					</TD>
				</TR>


			</TABLE>
		</form>
</body>
</html>
