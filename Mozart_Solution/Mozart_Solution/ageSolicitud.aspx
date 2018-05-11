<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ageSolicitud.aspx.vb" Inherits="ageSolicitud" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 728px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="0" cellPadding="1" width="728" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:Label id="lblTitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:LinkButton id="lbtCreaPedido" runat="server">Crea Pedido</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="form" id="Table2" style="WIDTH: 728px; HEIGHT: 1px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="728" border="1">
							<TR>
								<TD style="WIDTH: 171px">Nombre</TD>
								<TD style="HEIGHT: 18px">
									<asp:Label id="lblNombre" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Pais</TD>
								<TD>
									<asp:Label id="lblNomPais" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Pasajeros</TD>
								<TD>
									<asp:Label id="lblCantPasa" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px; HEIGHT: 17px">Habitaciones</TD>
								<TD style="HEIGHT: 17px">
									<asp:Label id="lblCantHab" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Cantidad dias</TD>
								<TD>
									<asp:Label id="lblCantDias" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px; HEIGHT: 16px">Mes y año de viaje</TD>
								<TD style="HEIGHT: 16px">
									<asp:Label id="lblMesAno" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Categoria hotel</TD>
								<TD style="HEIGHT: 23px">
									<asp:checkbox id="cbHotelEconomico" runat="server" CssClass="dato" Text="Econ&amp;oacutemico"></asp:checkbox>&nbsp;
									<asp:checkbox id="cbHotelStandard" runat="server" CssClass="dato" Text="Standard"></asp:checkbox>&nbsp;
									<asp:checkbox id="cbHotelSuperior" runat="server" CssClass="dato" Text="Superior"></asp:checkbox>&nbsp;&nbsp;&nbsp; 
									&nbsp;
									<asp:checkbox id="cbHotelDeluxe" runat="server" CssClass="dato" Text="Deluxe"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Tipo de tour</TD>
								<TD>
									<asp:checkbox id="cbTourCultural" runat="server" CssClass="dato" Text="Cultural"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:checkbox id="cbTourAventura" runat="server" CssClass="dato" Text="Aventura"></asp:checkbox>&nbsp;&nbsp;
									<asp:checkbox id="cbTourNaturaleza" runat="server" CssClass="dato" Text="Naturaleza"></asp:checkbox>&nbsp;
									<asp:checkbox id="cbTourVivencial" runat="server" CssClass="dato" Text="Vivencial"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px">Destinos</TD>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 600px; HEIGHT: 50px" height="50" width="600"
										border="0">
										<TR>
											<TD class="style11" style="WIDTH: 166px" width="166"><LABEL>
													<asp:checkbox id="cbDestCuzco" runat="server" Width="168px" CssClass="dato" Text="Cuzco / Machu Picchu"></asp:checkbox></LABEL></TD>
											<TD class="style11" width="24%" height="19">
												<asp:checkbox id="cbDestTiticaca" runat="server" CssClass="dato" Text="Lago Titicaca"></asp:checkbox></TD>
											<TD class="style11" width="24%" height="19">
												<asp:checkbox id="cbDestColca" runat="server" CssClass="dato" Text="Ca&amp;ntildeon del Colca"></asp:checkbox></TD>
											<TD class="style11" width="25%" height="19">
												<asp:checkbox id="cbDestSelva" runat="server" CssClass="dato" Text="Selva Amaz&amp;oacutenica"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD class="style11" style="WIDTH: 166px">
												<asp:checkbox id="cbDestManu" runat="server" CssClass="dato" Text="Reserva del Manu"></asp:checkbox></TD>
											<TD class="style11">
												<asp:checkbox id="cbDestLima" runat="server" CssClass="dato" Text="Lima"></asp:checkbox></TD>
											<TD class="style11">
												<asp:checkbox id="cbDestSipan" runat="server" CssClass="dato" Text="Se&amp;ntildeor de Sip&amp;aacuten"></asp:checkbox></TD>
											<TD class="style11">
												<asp:checkbox id="cbDestNazca" runat="server" CssClass="dato" Text="L&amp;iacuteneas de Nazca"></asp:checkbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 171px"><SPAN id="Label6">Requerimientos Adicionales </SPAN>
								</TD>
								<TD>
									<asp:Label id="lblComentario" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px">&nbsp;
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
