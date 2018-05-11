<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tabIGVxCiudad.aspx.vb" Inherits="tabIGVxCiudad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<DIV style="Z-INDEX: 100; LEFT: 0px; WIDTH: 10px; POSITION: absolute; TOP: 0px; HEIGHT: 10px"
			ms_positioning="text2D">
			<FORM id="Form1" method="post" runat="server">
				<TABLE id="Table4" style="Z-INDEX: 107; LEFT: 8px; WIDTH: 528px; POSITION: absolute; TOP: 8px; HEIGHT: 8px"
					cellSpacing="0" cellPadding="0" width="528" border="0" class="form">
					<TR>
						<TD class="Titulo" style="WIDTH: 467px">&nbsp;IGV por Ciudad</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 467px">
							<TABLE class="Tabla" id="Table1" style="WIDTH: 460px; HEIGHT: 45px" cellSpacing="0" cellPadding="0"
								width="460" border="1" borderColor="#cccccc">
								<TR>
									<TD style="WIDTH: 29px; HEIGHT: 20px"><FONT size="2">
											<asp:label id="lblestado" runat="server" Width="120px">Ciudad</asp:label></FONT></TD>
									<TD style="WIDTH: 214px; HEIGHT: 20px"><FONT size="2">
											<asp:dropdownlist id="ddlCiudad" runat="server" Width="332px" DataTextField="NomCiudad" DataValueField="CodCiudad"></asp:dropdownlist></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 29px">
										<asp:label id="lblservicio" runat="server" Width="106px">Tipo Servicio</asp:label></TD>
									<TD style="WIDTH: 214px">
										<asp:dropdownlist id="ddltiposervicio" runat="server" Width="330px" DataTextField="TipoServicio" DataValueField="CodTipoServicio"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 29px">
										<asp:label id="Label1" runat="server" Width="66px">Paga IGV</asp:label></TD>
									<TD style="WIDTH: 214px">
										<asp:radiobutton id="rbSi" runat="server" GroupName="Grupo2" Text="Si"></asp:radiobutton>
										<asp:radiobutton id="rbNo" runat="server" GroupName="Grupo2" Text="No"></asp:radiobutton></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 467px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:Button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 467px">
							<asp:label id="lblMsg" runat="server" Width="311px" Height="17px" CssClass="msg"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 467px">
							<asp:datagrid id="dgDCiudad" runat="server" Width="423px" Height="100px" CellPadding="2" BorderWidth="2px"
								BorderColor="CadetBlue" AutoGenerateColumns="False" BorderStyle="None" CssClass="Grid">
								<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
								<ItemStyle CssClass="GridData"></ItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="NomCiudad" HeaderText="Ciudad"></asp:BoundColumn>
									<asp:BoundColumn DataField="TipoServicio" HeaderText="Tipo Servicio"></asp:BoundColumn>
									<asp:BoundColumn DataField="PagoIGV" HeaderText="Paga IGV"></asp:BoundColumn>
									<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="KeyReg" HeaderText="KeyReg">
	    								 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodTipoServicio">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodCiudad">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 467px"></TD>
					</TR>
				</TABLE>
			</FORM>
</body>
</html>
