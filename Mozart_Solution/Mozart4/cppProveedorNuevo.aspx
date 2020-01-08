<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppProveedorNuevo.aspx.vb" Inherits="cppProveedorNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 546px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="546" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">
							<asp:label id="lblTitulo" runat="server" Cssclass="Titulo"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" style="WIDTH: 576px; HEIGHT: 290px" cellSpacing="0" cellPadding="0"
							width="576" border="1" class="Tabla" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 143px">&nbsp;Nombre&nbsp;&nbsp;Comercial&nbsp;</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtnombre" runat="server" Width="413px" BackColor="White" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Razón Social</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtrazon" runat="server" Width="414px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Ruc</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtruc" runat="server" Width="225px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Dirección</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtdir1" runat="server" Width="414px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Ciudad</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtciudad" runat="server" Width="184px"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp;&nbsp;País</TD>
								<TD style="WIDTH: 242px">
									<asp:dropdownlist id="ddlpais" runat="server" Width="189px" DataValueField="CodPais" DataTextField="NomPais"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Banco Cuenta</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtBcoCta" runat="server" Width="414px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Pagina Web</TD>
								<TD style="WIDTH: 242px">
									<P>
										<asp:TextBox id="txtweb" runat="server" Width="225px"></asp:TextBox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp;&nbsp;Estado &nbsp;</TD>
								<TD style="WIDTH: 242px">
									<asp:radiobutton id="rbActivo" runat="server" GroupName="Grupo2" Text="Activo" Checked="True"></asp:radiobutton>
									<asp:radiobutton id="rbInactivo" runat="server" GroupName="Grupo2" Text="Inactivo"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp;&nbsp;Fax</TD>
								<TD style="WIDTH: 242px"><asp:textbox id="txtfax" runat="server" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Extrajero No paga IGV</TD>
								<TD style="WIDTH: 242px">
									<asp:CheckBox id="ChkIGVHotel" runat="server" Text="Hotel"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:CheckBox id="ChkIGVTerrestre" runat="server" Text="Terrestre"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:CheckBox id="ChkIGVOtros" runat="server" Text="Otros"></asp:CheckBox>&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px">&nbsp; Sigla del Proveedor</TD>
								<TD style="WIDTH: 242px">
									<asp:textbox id="txtSigla" runat="server" MaxLength="20" Width="216px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table1" style="WIDTH: 542px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="542"
							border="0" class="FORM">
							<TR>
								<TD style="WIDTH: 98px">
									<asp:Button id="CmdGrabar" runat="server" Text="Grabar" Width="90px"></asp:Button></TD>
								<TD style="WIDTH: 86px">
									<asp:Button id="CmdEliminar" runat="server" Text="Eliminar" Visible="False" Width="87px"></asp:Button></TD>
								<TD>
									<asp:label id="lblError" runat="server" Width="344px" CssClass="Error"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			<P>
			</P>
			<P>
			</P>
			<P>&nbsp;</P>
		</FORM>
</body>
</html>
