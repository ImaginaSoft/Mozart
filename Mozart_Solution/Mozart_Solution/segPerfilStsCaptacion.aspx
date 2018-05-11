<%@ Page Language="VB" AutoEventWireup="false" CodeFile="segPerfilStsCaptacion.aspx.vb" Inherits="segPerfilStsCaptacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE class="TABLA" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 542px; POSITION: absolute; TOP: 8px; HEIGHT: 232px"
					cellSpacing="0" cellPadding="0" width="542" border="0">
					<TR>
						<TD class="Titulo" style="HEIGHT: 18px">Restricciones para el Perfil de usuario</TD>
					</TR>
					<TR>
						<TD class="opciones" style="HEIGHT: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lbtRegresar" runat="server" Width="70px">• Regresar</asp:linkbutton></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 14px">
							<asp:label id="lblNomPerfil" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 2px">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 2px">
							<TABLE class="tabla" id="Table2" style="WIDTH: 440px; HEIGHT: 16px" borderColor="#cccccc"
								cellSpacing="0" cellPadding="0" width="440" border="1">
								<TR>
									<TD style="WIDTH: 142px"><FONT size="2"> Perfil cliente actual</FONT></TD>
									<TD>
										<P>
											<asp:dropdownlist id="dllStsCaptacionActual" runat="server" Width="272px" DataTextField="NomStsCaptacion"
												DataValueField="StsCaptacion"></asp:dropdownlist></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 142px"><FONT size="2"> Nuevo perfil cliente</FONT></TD>
									<TD>
										<P>
											<asp:dropdownlist id="ddlStsCaptacionNuevo" runat="server" Width="272px" DataValueField="StsCaptacion"
												DataTextField="NomStsCaptacion"></asp:dropdownlist></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<P><asp:button id="cmdGrabar" tabIndex="6" runat="server" Width="76px" Text="Grabar"></asp:button>&nbsp;<asp:label id="lblMsg" runat="server" Width="424px" Height="17px" CssClass="error"></asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>El usuario que tiene este&nbsp;perfil, NO ESTA AUTORIZADO a realizar cambios 
							del perfil cliente actual al Nuevo perfil cliente.</TD>
					</TR>
					<TR>
						<TD>
							<P><asp:datagrid id="dgTabla" runat="server" Width="540px" CssClass="Grid" Font-Size="8pt" AutoGenerateColumns="False"
									BorderColor="#CCCCCC" BackColor="White" Font-Names="Verdana" BorderStyle="None" BorderWidth="1px"
									CellPadding="3" AllowSorting="True">
									<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
									<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
									<ItemStyle CssClass="GridData"></ItemStyle>
									<HeaderStyle CssClass="GridHeader"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="NomStsCaptacionActual" HeaderText="Perfil cliente actual "></asp:BoundColumn>
										<asp:BoundColumn DataField="NomStsCaptacionNuevo" HeaderText="Nuevo perfl cliente"></asp:BoundColumn>
										<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
										<asp:BoundColumn DataField="FchSys" HeaderText="Actualizado" DataFormatString="{0,1:dd MMM yyyy}{0,13:hh:mm tt }"></asp:BoundColumn>
										<asp:ButtonColumn Text="Eliminar" CommandName="select"></asp:ButtonColumn>
										<asp:BoundColumn DataField="StsCaptacionActual" HeaderText="StsCaptacionActual">
    		    							 <ItemStyle CssClass="Hide" />
                                             <HeaderStyle CssClass="Hide" />
										</asp:BoundColumn>
										<asp:BoundColumn DataField="StsCaptacionNuevo" HeaderText="StsCaptacionNuevo">
        									 <ItemStyle CssClass="Hide" />
                                             <HeaderStyle CssClass="Hide" />
										</asp:BoundColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></P>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;&nbsp;
						</TD>
					</TR>
				</TABLE>
			</P>
			<P>&nbsp;</P>
		</form>
</body>
</html>
