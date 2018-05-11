<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionIncidencia.aspx.vb" Inherits="VtaVersionIncidencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style2
        {
            height: 18px;
        }
        .style3
        {
            height: 17px;
            width: 106px;
        }
        .style4
        {
            height: 18px;
            width: 106px;
        }
        .style5
        {
            height: 19px;
            width: 106px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 10px; WIDTH: 589px; POSITION: absolute; TOP: 7px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="0" width="589" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" class="opciones">
						<asp:Label id="lblCodProveedorCompensa" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblCodCiudad" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblNroServicio" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lbtFichaVersion" runat="server" Width="107px">• Ficha Versión</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 94px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 772px; HEIGHT: 50px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" border="1">
							<TR>
								<TD class="style3"></TD>
								<TD class="msg" style="HEIGHT: 17px"></TD>
							</TR>
							<TR>
								<TD class="style4">Proveedor</TD>
								<TD style="HEIGHT: 18px">
									<asp:Label id="lblNomProveedor" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style3">Ciudad</TD>
								<TD style="HEIGHT: 17px">
									<asp:Label id="lblNomCiudad" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style5">
									Servicio&nbsp;
								</TD>
								<TD style="HEIGHT: 19px">
									<asp:Label id="lblDesProveedor" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style5">Incidencia&nbsp;</TD>
								<TD style="HEIGHT: 19px">
									<asp:TextBox id="txtEspeci" runat="server" Width="630px" MaxLength="100"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="style4">Solución&nbsp;</TD>
								<TD class="style2">
									<asp:TextBox id="txtSolIncidencia" runat="server" Width="630px" MaxLength="100"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="style5">Compensado por</TD>
								<TD style="HEIGHT: 19px">
									<asp:dropdownlist id="ddlProveedor" runat="server" 
                                        DataValueField="CodProveedor" DataTextField="NomProveedor"
										Width="253px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="style5">Monto USD</TD>
								<TD style="HEIGHT: 19px">
									<asp:TextBox ID="txtImpIncidencia" runat="server" Width="100px"></asp:TextBox>
                                </TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px">
						<TABLE class="tabla" id="Table2" style="WIDTH: 600px; HEIGHT: 32px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="576" border="1">
							<TR>
								<TD class="tabla" style="WIDTH: 19px">Día&nbsp;
								</TD>
								<TD style="WIDTH: 49px">
									<asp:Label id="lblNroDia" runat="server"></asp:Label></TD>
								<TD style="WIDTH: 39px">&nbsp;Orden</TD>
								<TD style="WIDTH: 101px">
									<asp:Label id="lblNroOrden" runat="server"></asp:Label></TD>
								<TD style="WIDTH: 64px" align="right">&nbsp;</TD>
								<TD style="WIDTH: 150px" align="left">
									&nbsp;</TD>
								<TD style="WIDTH: 149px" align="left">&nbsp;&nbsp;&nbsp;<asp:radiobutton id="rbtUpdate" runat="server" Text="Reemplazar" GroupName="G1" Checked="True"></asp:radiobutton></TD>
								<TD style="WIDTH: 161px" align="left"><asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMsg" runat="server" Width="425px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgServicio" runat="server" Width="780px" BorderStyle="None" Height="20px" CssClass="Grid"
							CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="#">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodStsReserva" HeaderText="Reserva">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Especificacion" HeaderText="Especificaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesIncidencia" HeaderText="Incidencia"></asp:BoundColumn>
								<asp:BoundColumn DataField="SolIncidencia" HeaderText="Solución"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedorCompensa" HeaderText="Compensa" DataFormatString="{0:#########}">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>    
								</asp:BoundColumn>
    							<asp:BoundColumn DataField="ImpIncidencia" HeaderText="Monto" DataFormatString="{0:###,###,###,##0.00}">
    							<ItemStyle HorizontalAlign="Right"></ItemStyle>
    							</asp:BoundColumn>

							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
