<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cpcClienteBusca.aspx.vb" Inherits="cpcClienteBusca" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript">
<!--
//función en JavaScript que captura el evento de [Enter] = 13 y hace una u otra 
      //funcionalidad de acuerdo a lo que queramos, la funcionalidad que asemos es para
      //cada textbox... cambiar el default button para submit.	
      
      //Esta función es invocada con el metodo SetDefaultButton, en el code-behind. 
      //Esto agregará un atributo para el evento "onkeydown" de cada control que necesites 
      //y ejecutará la función javascript para configurar 
	   function fnTrapKD(btn,event){
		if(document.all){
			if(event.keyCode==13){
				event.returnValue=false;
				event.cancel=true;
				btn.click();
			}
		}
		else if(document.getElementById){
			if(event.wich==13){
				event.returnValue=false;
				event.cancel=true;
				btn.click();	
			}
		}
		else if(document.layers){
			if(event.wich==13){
				event.returnValue=false;
				event.cancel=true;
				btn.click();	
			}
		}
	}		
//-->
		</script>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 136px"
				cellSpacing="0" cellPadding="0" width="600" border="0">
				<TR>
					<TD class="Titulo" style="HEIGHT: 20px">Busca Cliente</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 86px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 464px; HEIGHT: 106px" cellSpacing="0" cellPadding="0"
							width="464" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 222px; HEIGHT: 26px">
									<asp:RadioButton id="rbtApellidos" runat="server" Width="176px" Text="Por Apellidos y Nombres" Checked="True"
										GroupName="g1"></asp:RadioButton></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px"><asp:textbox id="txtNomCliente" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 222px; HEIGHT: 26px">
									<asp:RadioButton id="rbtEmail" runat="server" Width="176px" Text="Por E-mail " GroupName="g1"></asp:RadioButton></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px">
									<asp:textbox id="txtEmail" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 222px; HEIGHT: 26px">
									<asp:RadioButton id="rbtPasajero" runat="server" GroupName="g1" Text="Por Nombre Pasajero" Width="176px"></asp:RadioButton></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px">
									<asp:textbox id="txtNomPasajero" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 222px; HEIGHT: 26px">
									<asp:RadioButton id="rbtTelefono" runat="server" GroupName="g1" Text="Por Teléfono" Width="176px"></asp:RadioButton></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px">
									<asp:textbox id="txtTelefono" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 222px; HEIGHT: 26px">
									<asp:RadioButton id="rbtCodCliente" runat="server" GroupName="g1" 
                                        Text="Por Código Cliente" Width="176px"></asp:RadioButton></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px">
									<asp:textbox id="txtCodCliente" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="cmdBusca" runat="server" Text="Buscar"></asp:Button>&nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" CssClass="Msg" Width="488px"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgCliente" runat="server" CssClass="Grid" Height="25px" 
                            Width="731px" BorderColor="CadetBlue"
							CellPadding="3" BorderWidth="1px" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodCliente" SortExpression="CodCliente" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomCliente" SortExpression="NomCliente" HeaderText="Apellidos y Nombres"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodPais" HeaderText="País"></asp:BoundColumn>
								<asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="EmailContacto" HeaderText="Email Contacto"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomPasajero" HeaderText="Pasajero"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
