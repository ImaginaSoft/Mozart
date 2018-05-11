<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPlantillaServicio.aspx.vb" Inherits="VtaPlantillaServicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 619px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="619" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lbtServicios" runat="server">Servicios</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 592px; HEIGHT: 174px" cellSpacing="0" cellPadding="0"
							width="592" border="1" borderColor="#cccccc">
							<TR>
								<TD>Proveedor</TD>
								<TD><asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" DataTextField="NomProveedor" DataValueField="CodProveedor"
										Width="400px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="ddlCiudad" runat="server" DataTextField="NomCiudad" DataValueField="CodCiudad"
										Width="400px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Tipo de Servicio</TD>
								<TD>
									<asp:dropdownlist id="ddltiposervicio" runat="server" AutoPostBack="True" Width="400px" DataValueField="CodTipoServicio"
										DataTextField="TipoServicio"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px">Servicio</TD>
								<TD style="HEIGHT: 24px"><asp:dropdownlist id="ddlServicio" runat="server" DataTextField="DesProveedor" DataValueField="NroServicio"
										Width="400px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 7px">Tipo acomodación</TD>
								<TD style="HEIGHT: 7px">
									<asp:dropdownlist id="ddlTipoAcomodacion" runat="server" Width="400px" DataValueField="CodTipoAcomodacion"
										DataTextField="TipoAcomodacion"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Día</TD>
								<TD><asp:textbox id="Textdia" runat="server" Width="41px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Orden Servicio</TD>
								<TD><asp:textbox id="Textorden" runat="server" Width="42px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Hora Servicio</TD>
								<TD>
									<asp:textbox id="txtHoraServicio" runat="server" Width="72px" MaxLength="8"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px">
						<asp:button id="cmbGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;<asp:label 
                            id="lblMsg" runat="server" Width="440px" CssClass="Error"></asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:TextBox id="txtDiaAnt" runat="server" Width="17px" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtOrdenAnt" runat="server" Width="17px" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtNroServicioAnt" runat="server" Width="17px" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtCodTipoAcomodacionAnt" runat="server" Width="17px" Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgPlanilla" runat="server" Width="800px" CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False"
							BorderStyle="None" Height="20px" CssClass="Grid" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="KeyReg">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDia" HeaderText="D&#237;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroOrden" HeaderText="Ord">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="HoraServicio" HeaderText="Hora"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Acomodaci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomStsServicio" HeaderText="Estado"></asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroServicio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoAcomodacion" HeaderText="CodTipoAcomodacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
