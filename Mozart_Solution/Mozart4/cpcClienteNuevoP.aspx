<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcClienteNuevoP.aspx.vb" Inherits="cpcClienteNuevoP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 107px;
            height: 23px;
        }
        .style2
        {
            height: 23px;
        }
    </style>
	</HEAD>
	<BODY >
		<FORM id="Form1" method="post" runat="server">
			<P></P>
			<TABLE class="form" id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 596px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="0" width="596" border="0">
				<TR>
					<TD style="HEIGHT: 21px">
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server" Cssclass="Titulo"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" class="subtitulo">
						<asp:label id="lblError" runat="server" CssClass="Error"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" class="subtitulo">Datos Generales</TD>
				</TR>
				<TR>
					<TD class="subtitulo" style="HEIGHT: 21px">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="640" border="0" 
                            style="WIDTH: 640px; HEIGHT: 263px">
							<TR>
								<TD vAlign="top">
									<TABLE class="tabla" id="Table5" style="WIDTH: 352px; HEIGHT: 233px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="352" border="1">
										<TR>
											<TD style="WIDTH: 107px">Tipo cliente</TD>
											<TD>
												<asp:radiobutton id="rbtPersona" runat="server" Text="Persona" GroupName="Grupo1"></asp:radiobutton>
												<asp:radiobutton id="rbtAgencia" runat="server" Width="65px" Text="Agencia" GroupName="Grupo1"></asp:radiobutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Nombre</TD>
											<TD>
												<asp:textbox id="txtnombre" runat="server" Width="168px" Height="22px"></asp:textbox>
												<asp:Label id="lbln" runat="server" CssClass="error"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Apellido paterno</TD>
											<TD>
												<asp:textbox id="txtpaterno" runat="server" Width="168px" Height="22px"></asp:textbox>
												<asp:Label id="lblp" runat="server" CssClass="error"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px; HEIGHT: 26px">Apellido materno</TD>
											<TD style="HEIGHT: 26px">
												<asp:textbox id="txtmaterno" runat="server" Width="168px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px; HEIGHT: 14px">Email</TD>
											<TD style="HEIGHT: 14px">
												<asp:textbox id="txtemail" runat="server" Width="232px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Contraseña</TD>
											<TD>
												<asp:textbox id="txtClaveCliente" runat="server" Width="173px" Height="22px" MaxLength="30"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Doc.Identificación</TD>
											<TD>
												<asp:textbox id="txtDocPersonal" runat="server" Width="171px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Cumpleaños</TD>
											<TD>
												<asp:textbox id="txtFchNacimiento" runat="server" CssClass="fd" Width="75px" Height="22px" ReadOnly="True"></asp:textbox><INPUT class="fd" id="cmdFchNacimiento" onclick="show_calendar('Form1.txtFchNacimiento',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchNacimiento"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 107px">Teléfono</TD>
											<TD>
												<asp:textbox id="txtfono" runat="server" Width="171px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="style1">Rango de Edad&nbsp;</TD>
											<TD class="style2">
									<asp:dropdownlist id="ddlRangoEdad" runat="server" Width="232px" 
                                                    DataValueField="CodElemento" DataTextField="NomElemento"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>&nbsp;</TD>
								<TD vAlign="top">
									<TABLE class="tabla" id="Table2" style="WIDTH: 295px; HEIGHT: 219px" cellSpacing="0" cellPadding="0"
										width="295" border="1" borderColor="#cccccc">
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 27px" bgColor="#f5f5f5">
												<asp:label id="Label5" runat="server" Width="88px">Ingreso a B.D.</asp:label></TD>
											<TD style="WIDTH: 207px; HEIGHT: 27px" bgColor="#f5f5f5">
												<asp:Label id="lblFchsys" runat="server" CssClass="dato" Width="156px"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 26px">Dirección</TD>
											<TD style="WIDTH: 207px; HEIGHT: 26px">
												<asp:textbox id="txtDireccion" runat="server" Width="184px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 18px" bgColor="#f5f5f5">Ciudad</TD>
											<TD style="WIDTH: 207px; HEIGHT: 18px" bgColor="#f5f5f5">
												<asp:textbox id="txtCiudad" runat="server" Width="184px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px" bgColor="#f5f5f5">Estado</TD>
											<TD style="WIDTH: 207px" bgColor="#f5f5f5">
												<asp:textbox id="txtEstado" runat="server" Width="184px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 13px" bgColor="#f5f5f5">Código postal</TD>
											<TD style="WIDTH: 207px; HEIGHT: 13px" bgColor="#f5f5f5">
												<asp:textbox id="txtCodigoPostal" runat="server" Width="184px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px">Pais</TD>
											<TD style="WIDTH: 207px">
												<asp:dropdownlist id="ddlpais" runat="server" Width="184px" DataTextField="NomPais"
													DataValueField="CodPais"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 20px" bgColor="#f5f5f5">Contacto</TD>
											<TD style="WIDTH: 207px; HEIGHT: 20px" bgColor="#f5f5f5">
												<asp:textbox id="txtContacto" runat="server" Width="184px" Height="22px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px">Tf. contacto</TD>
											<TD style="WIDTH: 207px">
												<asp:textbox id="txtTelefonoContacto" runat="server" Width="184px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 110px; HEIGHT: 14px">E-mail contacto</TD>
											<TD style="WIDTH: 207px; HEIGHT: 14px">
												<asp:textbox id="txtEmailContacto" runat="server" Width="184px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" class="subtitulo">Preferencias</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
						<TABLE class="tabla" id="Table8" style="WIDTH: 648px; HEIGHT: 82px" cellSpacing="0" cellPadding="0"
							width="648" border="0" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 87px">
									Idioma</TD>
								<TD><asp:radiobutton id="rbingles" runat="server" GroupName="grupo2" Text="Inglés"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbespañol" runat="server" GroupName="grupo2" Text="Español"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbportugues" runat="server" GroupName="grupo2" Text="Portugues"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px">Categoria&nbsp; Alojamiento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD><asp:radiobutton id="rbe" runat="server" GroupName="grupo4" Text="Económico"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbs" runat="server" GroupName="grupo4" Text="Standard"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbsu" runat="server" GroupName="grupo4" Text="Superior"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbd" runat="server" GroupName="grupo4" Text="De Luxe"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px">Clase Tour</TD>
								<TD><asp:radiobutton id="rbprivado" runat="server" GroupName="grupo3" Text="Privado"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rbsib" runat="server" GroupName="grupo3" Text="SIB"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 139px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 648px; HEIGHT: 133px" cellSpacing="0" cellPadding="0"
							width="648" border="0">
							<TR>
								<TD style="WIDTH: 90px">Tipo Tour</TD>
								<TD><asp:checkbox id="cbarqu" runat="server" Text="Arqueológico"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbecoMozart" runat="server" Text="EcoMozart"></asp:checkbox></TD>
								<TD style="WIDTH: 95px"><asp:checkbox id="cbaventura" runat="server" Text="Aventura"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbmistico" runat="server" Text="Místico"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px"></TD>
								<TD></TD>
								<TD></TD>
								<TD style="WIDTH: 95px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px; HEIGHT: 21px">Especiales</TD>
								<TD style="HEIGHT: 21px"><asp:checkbox id="cbComida" runat="server" Width="139px" Text="Comida Vegetariana"></asp:checkbox></TD>
								<TD style="HEIGHT: 21px"><asp:checkbox id="cbTerceraEdad" runat="server" Width="105px" Text="Tercera Edad"></asp:checkbox></TD>
								<TD style="WIDTH: 95px; HEIGHT: 21px"><asp:checkbox id="cbGolf" runat="server" Width="83px" Text="Golf"></asp:checkbox></TD>
								<TD style="HEIGHT: 21px"><asp:checkbox id="cbShopping" runat="server" Width="93px" Text="Shopping"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px"></TD>
								<TD><asp:checkbox id="cbTourGastronomico" runat="server" Text="Tour Gastronómico"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbPlayas" runat="server" Text="Playas/Surf"></asp:checkbox></TD>
								<TD style="WIDTH: 95px"><asp:checkbox id="cbYates" runat="server" Text="Yates"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbAndinismo" runat="server" Text="Andinismo"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px"></TD>
								<TD><asp:checkbox id="cbMozartVivencial" runat="server" Text="Mozart Vivencial"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbTourCaza" runat="server" Text="Tour caza"></asp:checkbox></TD>
								<TD style="WIDTH: 95px"><asp:checkbox id="cbCaballos" runat="server" Text="Caballos"></asp:checkbox></TD>
								<TD><asp:checkbox id="cbBicicleta" runat="server" Text="Bicicleta"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px; HEIGHT: 19px"></TD>
								<TD style="HEIGHT: 19px"><asp:checkbox id="cbAventuraExtrema" runat="server" Text="Aventura Extrema"></asp:checkbox></TD>
								<TD style="HEIGHT: 19px"></TD>
								<TD style="WIDTH: 95px; HEIGHT: 19px"></TD>
								<TD style="HEIGHT: 19px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px"></TD>
								<TD></TD>
								<TD></TD>
								<TD style="WIDTH: 95px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px" class="subtitulo">Agencia</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">
						<TABLE class="tabla" id="Table4" style="WIDTH: 648px; HEIGHT: 68px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="648" border="0">
							<TR>
								<TD style="WIDTH: 104px">Sigla</TD>
								<TD>
									<asp:TextBox id="txtSigla" runat="server" Width="240px" MaxLength="20"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px">Vendedor
								</TD>
								<TD>
									<asp:dropdownlist id="ddlVendedor" tabIndex="6" runat="server" Width="240px" DataTextField="NomVendedor"
										DataValueField="CodVendedor"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 104px; HEIGHT: 16px">Plan Tarifario</TD>
								<TD style="HEIGHT: 16px">
									<asp:dropdownlist id="ddlPlanTarifario" tabIndex="6" runat="server" Width="432px" DataTextField="NomPlanTarifario"
										DataValueField="CodPlanTarifario"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdGrabar" runat="server" Width="80px" Text="Grabar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdEliminar" runat="server" Width="80px" Text="Eliminar"></asp:Button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">&nbsp;</TD>
				</TR>
			</TABLE>
			<P>
			</P>
		</FORM>
</body>
</html>
