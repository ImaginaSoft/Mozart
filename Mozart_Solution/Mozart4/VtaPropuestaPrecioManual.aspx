<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaPrecioManual.aspx.vb" Inherits="VtaPropuestaPrecioManual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 467px; POSITION: absolute; TOP: 8px; HEIGHT: 144px"
				cellSpacing="0" cellPadding="1" width="467" border="0" class="form">
				<TR>
					<TD class="Titulo" style="HEIGHT: 7px">&nbsp;
						<asp:Label id="lblTitulo" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 6px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
						<asp:Label id="lblPropuesta" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD class="subtitulo" style="WIDTH: 296px; HEIGHT: 17px">Resumen del Precio por 
									Tipo</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 296px">
									<asp:datagrid id="dgResumen" runat="server" Width="432px" BorderStyle="None" CssClass="Grid" Height="20px"
										BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="2" OnItemDataBound="ComputeSum"
										ShowFooter="True">
										<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
										<ItemStyle CssClass="GridData"></ItemStyle>
										<HeaderStyle CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="TipoPasajero" HeaderText="Tipo Pasajero"></asp:BoundColumn>
											<asp:BoundColumn DataField="NomSubTipo" HeaderText="Tipo Habitaci&#243;n">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Noches" HeaderText="Noches /Servicio">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioPersona" HeaderText="Precio x Persona" DataFormatString="{0:###,###,###.00}">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CantPersonas" HeaderText="N&#176; Personas">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:###,###,###.00}">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CodGrupoServicio" HeaderText="CodGrupoServicio">
            									 <ItemStyle CssClass="Hide" />
                                                 <HeaderStyle CssClass="Hide" />
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px">
						<TABLE class="form" id="Table6" style="WIDTH: 464px; HEIGHT: 62px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="464" border="1">
							<TR>
								<TD style="WIDTH: 166px; HEIGHT: 34px">Descripción</TD>
								<TD style="WIDTH: 69px; HEIGHT: 34px">Precio x Persona</TD>
								<TD style="WIDTH: 72px; HEIGHT: 34px">N° Personas</TD>
								<TD style="HEIGHT: 34px">
									<asp:Label id="lblNroOrden" runat="server" Visible="False"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 166px">
									<asp:TextBox id="txtDesOrden" runat="server" Width="240px" MaxLength="100"></asp:TextBox></TD>
								<TD style="WIDTH: 69px">
									<asp:TextBox id="txtPrecioxPersona" runat="server" Width="64px" MaxLength="12"></asp:TextBox></TD>
								<TD style="WIDTH: 72px">
									<asp:TextBox id="txtCantPersonas" runat="server" Width="48px" MaxLength="3"></asp:TextBox></TD>
								<TD>
									<asp:Button id="cmdGrabar" runat="server" Width="72px" Text="Grabar"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="subtitulo" style="HEIGHT: 18px">Actualizar precios para el Cliente</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 7px">
						<asp:label id="lblMsg" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">
						<asp:datagrid id="dgPrecio" runat="server" Width="432px" ShowFooter="True" OnItemDataBound="ComputeSumP"
							CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue" Height="20px"
							CssClass="Grid" BorderStyle="None">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="DesOrden" HeaderText="Descripci&#243;n">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioxPersona" HeaderText="Precio x Persona" DataFormatString="{0:###,###,###.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantPersonas" HeaderText="N&#176; Personas">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:###,###,###.00}">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="NroOrden">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
