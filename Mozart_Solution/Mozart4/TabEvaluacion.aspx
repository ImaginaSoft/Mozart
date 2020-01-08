<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TabEvaluacion.aspx.vb" Inherits="TabEvaluacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 105; LEFT: 10px; WIDTH: 497px; POSITION: absolute; TOP: 11px; HEIGHT: 310px"
				cellSpacing="0" cellPadding="0" width="497" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Evaluación de Visitas</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 513px; HEIGHT: 102px" cellSpacing="0" cellPadding="0"
							width="513" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 64px"><FONT size="2">&nbsp;Código</FONT></TD>
								<TD><asp:textbox id="txtCodigo" runat="server" Width="73px" MaxLength="3"></asp:textbox><asp:requiredfieldvalidator id="rfvcodigo" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio" ControlToValidate="txtCodigo"
										CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Nombre</TD>
								<TD><asp:textbox id="txtNombre" runat="server" Width="289px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ForeColor=" " ErrorMessage="Dato Obligatorio"
										ControlToValidate="txtNombre" CssClass="error"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;Tipo</TD>
								<TD>
									<asp:radiobutton id="rbEntrada" runat="server" Checked="True" GroupName="Grupo1" Text="Entrada"></asp:radiobutton>
									<asp:radiobutton id="rbSalida" runat="server" GroupName="Grupo1" Text="Salida"></asp:radiobutton>
									<asp:radiobutton id="rbNo" runat="server" Text="No Visita" GroupName="Grupo1"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 64px">&nbsp;</TD>
								<TD><asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="448px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgEvaluacion" runat="server" Width="512px"  Height="17px"
							CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" AutoGenerateColumns="False" CssClass="Grid"
							AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodEvaluacion" SortExpression="CodEvaluacion" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomEvaluacion" SortExpression="NomEvaluacion" HeaderText="Nombre">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Evaluacion" SortExpression="Evaluacion" HeaderText="Tipo">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="TipoEvaluacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
