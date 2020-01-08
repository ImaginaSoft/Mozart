<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SegOpciones.aspx.vb" Inherits="SegOpciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;</P>
			<P>
				<TABLE class="tabla" id="Table2" style="Z-INDEX: 105; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 80px"
					cellSpacing="0" cellPadding="0" width="600" border="0">
					<TR>
						<TD class="Titulo" style="HEIGHT: 7px">&nbsp;Asignación de opciones al Perfil
						</TD>
					</TR>
					<TR>
						<TD class="opciones" style="HEIGHT: 15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lbtRegresar" runat="server" Width="70px">• Regresar</asp:linkbutton></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 2px">
							<asp:label id="lblMsg" runat="server" Width="528px"   ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 16px">
							<TABLE id="Table1" style="WIDTH: 584px; HEIGHT: 36px" cellSpacing="0" cellPadding="0" width="584"
								border="0" class="tabla">
								<TR>
									<TD><asp:label id="Label1" runat="server">Opciones del Sistema</asp:label></TD>
									<TD><asp:label id="Label2" runat="server" Width="272px">Opciones del Perfil </asp:label></TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<asp:datagrid id="dgTabla" runat="server" Width="273px" CssClass="Grid" Font-Size="8pt" AutoGenerateColumns="False"
											BorderColor="CadetBlue" BackColor="White" Font-Names="Verdana" BorderStyle="None" BorderWidth="1px"
											CellPadding="3" GridLines="Vertical" AllowSorting="True" DataKeyField="CodFuncion">
											<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
											<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
											<ItemStyle CssClass="GridData"></ItemStyle>
											<HeaderStyle CssClass="GridHeader"></HeaderStyle>
											<Columns>
												<asp:ButtonColumn Text="Asignar" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="CodFuncion" SortExpression="CodFuncion" HeaderText="C&#243;digo"></asp:BoundColumn>
												<asp:BoundColumn DataField="NomFuncion" HeaderText="Opci&#243;n"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
									<TD vAlign="top">
										<P>
											<asp:datagrid id="dgTabla2" runat="server" Width="273px" CssClass="Grid" AutoGenerateColumns="False"
												BorderColor="CadetBlue" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True"
												DataKeyField="CodFuncion">
												<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
												<ItemStyle CssClass="GridData"></ItemStyle>
												<HeaderStyle CssClass="GridHeader"></HeaderStyle>
												<Columns>
													<asp:ButtonColumn Text="Eliminar" CommandName="Select"></asp:ButtonColumn>
													<asp:BoundColumn DataField="CodFuncion" SortExpression="CodFuncion" HeaderText="C&#243;digo"></asp:BoundColumn>
													<asp:BoundColumn DataField="NomFuncion" HeaderText="Opci&#243;n"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;
						</TD>
					</TR>
				</TABLE>
			</P>
		</form>
</body>
</html>
