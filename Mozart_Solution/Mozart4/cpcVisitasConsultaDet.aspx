<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcVisitasConsultaDet.aspx.vb" Inherits="cpcVisitasConsultaDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 528px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
				cellSpacing="0" cellPadding="0" width="528" border="0" class="Form">
				<TR>
					<TD style="HEIGHT: 19px">
						<P class="Titulo">Consulta detalle de la&nbsp;visita</P>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="form" id="Table3" style="WIDTH: 520px; HEIGHT: 220px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="520" border="1">
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 18px">&nbsp;Nro Pedido</TD>
								<TD style="HEIGHT: 18px">&nbsp;
									<asp:label id="lblNroPedido" runat="server" Width="46px" CssClass="dato"></asp:label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 2px">&nbsp;Descripción</TD>
								<TD style="HEIGHT: 2px">&nbsp;
									<asp:label id="lblDesPedido" runat="server" Width="399px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 2px">&nbsp;Cliente</TD>
								<TD style="HEIGHT: 2px">&nbsp;
									<asp:label id="lblNomCliente" runat="server" Width="368px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Vendedor</TD>
								<TD>&nbsp;
									<asp:label id="lblNomVendedor" runat="server" Width="172px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 18px">&nbsp;Pax</TD>
								<TD style="HEIGHT: 18px">&nbsp;
									<asp:label id="lblPax" runat="server" Width="46px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Tipo Visita</TD>
								<TD>&nbsp;
									<asp:label id="lblTipo" runat="server" Width="171px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Fecha Visita</TD>
								<TD>&nbsp;
									<asp:label id="lblFchVisita" runat="server" Width="171px" CssClass="dato"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 18px">&nbsp;Hora Visita</TD>
								<TD style="HEIGHT: 18px">&nbsp;
									<asp:Label id="lblHoraVisita" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px; HEIGHT: 20px">&nbsp;Responsable</TD>
								<TD style="HEIGHT: 20px">&nbsp;
									<asp:Label id="lblResponsable" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Visita</TD>
								<TD>&nbsp;
									<asp:Label id="lblVisita" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Evaluación</TD>
								<TD>&nbsp;
									<asp:Label id="lblEvaluacion" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 89px">&nbsp;Detalle</TD>
								<TD>&nbsp;
									<asp:Label id="lblDesLog" runat="server" CssClass="dato"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
