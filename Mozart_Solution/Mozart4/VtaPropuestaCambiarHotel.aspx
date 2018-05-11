<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaCambiarHotel.aspx.vb" Inherits="VtaPropuestaCambiarHotel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 704px; POSITION: absolute; TOP: 8px; HEIGHT: 411px"
				cellSpacing="0" cellPadding="0" width="704" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="lbltitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 10px" class="opciones">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lbtFichaPropuesta" runat="server" Width="107px">• Ficha Propuesta</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 59px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 600px; HEIGHT: 57px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="600" border="1">
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 7px">Proveedor</TD>
								<TD style="HEIGHT: 7px">
									<asp:Label id="lblNomProveedor" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px">Ciudad</TD>
								<TD style="HEIGHT: 15px">
									<asp:Label id="lblNomCiudad" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 19px">Hotel actual</TD>
								<TD style="HEIGHT: 19px">
									<asp:Label id="lblDesProveedor" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<asp:Label id="lblCodProveedor" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblCodCiudad" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblNroServicio" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lblCodTipoAcomodacion" runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 600px; HEIGHT: 64px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="600" border="1">
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 18px">Proveedor</TD>
								<TD style="HEIGHT: 18px">
									<asp:dropdownlist id="ddlProveedor" tabIndex="1" runat="server" Width="464px" DataTextField="NomProveedor"
										DataValueField="CodProveedor" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 18px">Nuevo Hotel</TD>
								<TD style="HEIGHT: 18px">
									<asp:dropdownlist id="ddlServicio" runat="server" Width="464px" AutoPostBack="True" DataValueField="NroServicio"
										DataTextField="DesProveedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 121px; HEIGHT: 15px">
									<asp:label id="Label1" runat="server" Width="112px">Tipo Acomodación</asp:label></TD>
								<TD style="HEIGHT: 15px">
									<asp:dropdownlist id="ddlTipoAcomodacion" runat="server" Width="464px" DataValueField="CodTipoAcomodacion"
										DataTextField="TipoAcomodacion"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdGrabar" runat="server" Width="77px" Text="Grabar"></asp:button>&nbsp;
						<asp:label id="lblMsg" runat="server" Width="425px"  CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:datagrid id="dgServicio" runat="server" Width="704px" BorderStyle="None" Height="20px" CssClass="Grid"
							CellPadding="2" BorderWidth="2px" AutoGenerateColumns="False" BorderColor="CadetBlue">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroServicio" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesProveedor" HeaderText="Servicio"></asp:BoundColumn>
								<asp:BoundColumn DataField="TipoAcomodacion" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="FlagValoriza" HeaderText="V"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesCantidad" HeaderText="Cantidad"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodProveedor" HeaderText="CodProveedor">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodCiudad" HeaderText="CodCiudad">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoServicio" HeaderText="CodTipoServicio">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodTipoAcomodacion" HeaderText="CodTipoAcomodacion">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CodLink" HeaderText="Link" DataFormatString="{0:######}"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
