<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cppProveedorBusca.aspx.vb" Inherits="cppProveedorBusca" %>

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
			<TABLE class="form" id="Table2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD 
					<P class="Titulo" >Buscar Proveedor</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 352px; HEIGHT: 57px" cellSpacing="0" cellPadding="0" width="352" border="1" bgColor="#cccccc">
							<TR>
								<TD style="WIDTH: 268px; HEIGHT: 29px"><asp:label id="Label3" runat="server" Width="56px">Nombre</asp:label></TD>
								<TD style="WIDTH: 298px; HEIGHT: 29px"><asp:textbox id="txtNomProveedor" runat="server" Width="271px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 268px; HEIGHT: 9px">&nbsp;</TD>
								<TD style="WIDTH: 298px; HEIGHT: 9px">
									<asp:Button id="cmdBuscar" runat="server" Text="Buscar"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">
						<asp:label id="lblMsg" runat="server"  Width="488px" CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px; HEIGHT: 1px">
						<asp:datagrid id="dgProveedor" runat="server" Height="25px" Width="464px" CellPadding="3" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None" CssClass="Grid" BorderColor="CadetBlue" AllowSorting="True">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Ficha" HeaderText="Proveedor" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodProveedor" SortExpression="CodProveedor" HeaderText="C&#243;digo" FooterText="CodProveedor"></asp:BoundColumn>
								<asp:BoundColumn DataField="NomProveedor" SortExpression="NomProveedor" HeaderText="Nombre" FooterText="NomProveedor"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
