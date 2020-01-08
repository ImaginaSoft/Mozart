<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionAjuste.aspx.vb" Inherits="VtaVersionAjuste" %>

<%@ Register src="ucCliente.ascx" tagname="ucCliente" tagprefix="uc1" %>

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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 100; LEFT: 15px; WIDTH: 496px; POSITION: absolute; TOP: 7px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="0" width="496" border="0" class="form">
				<TR>
					<TD style="HEIGHT: 21px">
						<P class="Titulo">&nbsp;
							<asp:Label id="lbltitulo" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucCliente ID="ucCliente1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD class="SubTitulo">Ingrese dato para 
						busqueda:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table1" style="WIDTH: 408px; HEIGHT: 61px" cellSpacing="0" cellPadding="0"
							width="408" border="1" borderColor="#cccccc">
							<TR>
								<TD style="WIDTH: 158px; HEIGHT: 26px"><asp:label id="Label3" runat="server" Width="112px">Nombre Proveedor</asp:label></TD>
								<TD style="WIDTH: 298px; HEIGHT: 26px"><asp:textbox id="txtNomProveedor" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 158px; HEIGHT: 9px">&nbsp;</TD>
								<TD style="WIDTH: 298px; HEIGHT: 9px"><asp:button id="cmdBuscar" runat="server" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" CssClass="Msg" Width="513px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgProveedor" runat="server" CssClass="Grid" Width="511px" Height="25px" BorderColor="CadetBlue"
							BorderStyle="None" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="3">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodProveedor" SortExpression="CodProveedor" HeaderText="C&#243;digo"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Nombre"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
