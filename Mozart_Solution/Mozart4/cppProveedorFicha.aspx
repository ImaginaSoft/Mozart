<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppProveedorFicha.aspx.vb" Inherits="cppProveedorFicha" %>

<%@ Register src="ucProveedor.ascx" tagname="ucProveedor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table2" style="Z-INDEX: 105; LEFT: 10px; WIDTH: 575px; POSITION: absolute; TOP: 15px; HEIGHT: 120px"
				cellSpacing="0" cellPadding="0" width="575" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;Atención al Proveedor</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucProveedor ID="ucProveedor1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 131px">
						<TABLE class="tabla" id="Table4" style="WIDTH: 567px; HEIGHT: 8px" cellSpacing="1" cellPadding="1"
							width="567" border="0">
							<TR>
								<TD class="SubTitulo" style="WIDTH: 190px">Opciones</TD>
								<TD class="SubTitulo" style="WIDTH: 166px"></TD>
								<TD class="SubTitulo"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 190px">
									<asp:linkbutton id="lbtNuevoProveedor" runat="server" Width="172px">• Nuevo Proveedor</asp:linkbutton></TD>
								<TD style="WIDTH: 166px"><asp:linkbutton id="lbtRegistraPago" runat="server" Width="172px">• Registra Pago</asp:linkbutton></TD>
								<TD>
									<asp:linkbutton id="lbtPendientesCuadre" runat="server" Width="207px">• Obligación pendiente de cuadre</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 190px; HEIGHT: 17px">
									<asp:linkbutton id="lbtActualizaCliente" runat="server" Width="172px">• Actualiza Proveedor</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 17px">
									<asp:linkbutton id="lbtRegistraPrePago" runat="server" Width="172px">• Registra Pre-Pago</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px">
									<asp:linkbutton id="lbtRegistraGastos" runat="server" Width="172px">• Registro de Gastos</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 190px; HEIGHT: 17px">
									<asp:linkbutton id="lbtEliminarCliente" runat="server" Width="172px">• Elimina  Proveedor</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 17px">
									<asp:linkbutton id="lbtDocumentos" runat="server" Width="172px">• Consulta Documentos</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px">
									<asp:linkbutton id="lbtRegistraCredito" runat="server" Width="145px">• Registro  Nota  Crédito</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 190px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 166px; HEIGHT: 17px"><asp:linkbutton id="lbtCtacte" runat="server" Width="172px">• Consulta Ctacte</asp:linkbutton></TD>
								<TD style="HEIGHT: 17px">
									<asp:linkbutton id="lkbRegistraDebito" runat="server" Width="145px">• Registro  Nota  Débito</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 190px; HEIGHT: 17px">
									<asp:linkbutton id="lbtContacto" runat="server" Width="172px">• Contactos</asp:linkbutton></TD>
								<TD style="WIDTH: 166px; HEIGHT: 17px"></TD>
								<TD style="HEIGHT: 17px">
									<asp:linkbutton id="LbtRegistroHonorarios" runat="server" Width="194px">• Registro Recibo por Honorarios</asp:linkbutton></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" CssClass="Msg" Width="573px"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
