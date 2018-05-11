<%@ Page Language="VB" AutoEventWireup="false" CodeFile="plaTourPlantilla.aspx.vb" Inherits="plaTourPlantilla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 632px; POSITION: absolute; TOP: 8px; HEIGHT: 120px"
				cellSpacing="0" cellPadding="0" width="632" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 467px">&nbsp;Plantillas del Tour</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 50px">
						<TABLE class="cabecera" id="Table1" style="WIDTH: 608px; HEIGHT: 34px" cellSpacing="0"
							cellPadding="0" width="608" border="0">
							<TR>
								<TD style="WIDTH: 135px; HEIGHT: 18px">Tour</TD>
								<TD style="HEIGHT: 18px"><asp:label id="lblCodTour" runat="server"></asp:label>&nbsp;
									<asp:label id="lblNomTour" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 135px">Cantidad dias</TD>
								<TD><asp:label id="lblCantDias" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px; HEIGHT: 9px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 632px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="632" border="1">
							<TR>
								<TD style="WIDTH: 166px; HEIGHT: 2px">Plantilla</TD>
								<TD style="HEIGHT: 2px"><asp:dropdownlist id="ddlPlantilla" runat="server" Width="456px" DataTextField="DesPlantilla" DataValueField="NroPlantilla"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 166px">Usar para mostrar resumen del itinerario en el Tour
								</TD>
								<TD><asp:radiobutton id="rbtSI" runat="server" Text="SI" GroupName="G1"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbtNO" runat="server" Text="No" Checked="True" GroupName="G1"></asp:radiobutton></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:label id="lblMsg" runat="server" CssClass="msg" 
                            Width="451px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 467px"><asp:datagrid id="dgLista" runat="server" CssClass="Grid" Width="632px" Height="17px" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2"  >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="NroPlantilla" HeaderText="N&#250;mero">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="DesPlantilla" HeaderText="Plantilla">
									<ItemStyle Wrap="False"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesPlantilla")%>' NavigateUrl='<%# "vtaPlantillaFicha.aspx?NroPlantilla=" + cstr(DataBinder.Eval(Container.DataItem,"NroPlantilla"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NomCateTour" HeaderText="Categoria">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Itinerario" HeaderText="Itinerario">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsPlantilla" HeaderText="Estado Plantilla">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
