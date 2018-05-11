<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cybDBancosDetalle.aspx.vb" Inherits="cybDBancosDetalle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            width: 100%;
            margin-bottom: 0px;
        }
        .style2
        {
            width: 166px;
        }
    </style>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" 
				cellSpacing="0" cellPadding="1" width="499" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Detalle Banco</P>
					</TD>
				</TR>
				
				
				<TR>
					<TD>
					
			<TABLE class="tabla" id="Table2" 
				cellSpacing="1" cellPadding="1" width="500" border="1" borderColor="#cccccc"	>
				<TR>
					<TD class="subtitulo" style="WIDTH: 161px">Documento</TD>
					<TD><asp:label id="txtFchEmision" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Tipo Documento</TD>
					<TD><asp:label id="lblTipoDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:label id="lblNomDocumento" runat="server" CssClass="Dato"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px; HEIGHT: 20px">
						&nbsp;Nro Documento</TD>
					<TD style="HEIGHT: 20px"><asp:label id="lblNumeroDocumento" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px; HEIGHT: 20px">&nbsp;Banco</TD>
					<TD style="HEIGHT: 20px"><asp:label id="lblCodigoBanco" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px; HEIGHT: 20px">&nbsp;Nro de Cuenta</TD>
					<TD style="HEIGHT: 20px"><asp:label id="lblNumeroCuenta" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Referencia
					</TD>
					<TD><asp:label id="lblReferencia" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Total</TD>
					<TD><asp:label id="lbltotal" runat="server" CssClass="Dato"></asp:label>&nbsp;
						<asp:label id="lblMoneda" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Estado</TD>
					<TD><asp:label id="lblEstado" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD class="subTitulo" style="WIDTH: 161px">Documento Relacionado</TD>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Tipo Documento</TD>
					<TD><asp:label id="lblTipoDoc2" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblNomDoc2" runat="server" CssClass="Dato" Width="170px"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px; HEIGHT: 19px">&nbsp;Nro Documento</TD>
					<TD style="HEIGHT: 19px">
						<asp:label id="lblNumDoc2" runat="server" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Banco</TD>
					<TD>
						<asp:label id="lblCodigoBanco2" runat="server" Width="194px" CssClass="Dato"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Nro de Cuenta</TD>
					<TD><asp:label id="lblNumeroCuenta2" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">&nbsp;Estado</TD>
					<TD><asp:label id="lblEstadoRef" runat="server" CssClass="Dato"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
					</TD>
				</TR>


				<TR>
					<TD>


			<asp:label id="lblmsg" 
                 runat="server"
				CssClass="msg" Width="491px"></asp:label>
					</TD>
				</TR>


				<TR>
					<TD>
					</TD>
				</TR>


				<TR>
					<TD>
                        <table cellpadding="0" class="style1">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style2">
                        &nbsp;<asp:button id="cmdAnularDoc"
				runat="server" Text="Anular Documento" Width="134px" Height="24px"></asp:button>
                                    </td>
                                <td>&nbsp;</td>
                                <td>
                        <asp:button id="cmdModifDoc" 
				runat="server" Text="Modificar Documento" Width="150px"></asp:button>

                                    </td>
                            </tr>
                        </table>

					</TD>
				</TR>

			</TABLE>
		</form>
</body>
</html>
