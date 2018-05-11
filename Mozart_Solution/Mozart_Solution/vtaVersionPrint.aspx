<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaVersionPrint.aspx.vb" Inherits="vtaVersionPrint" %>

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
			<TABLE class="form" id="Table2" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 584px; POSITION: absolute; TOP: 8px; HEIGHT: 161px"
				cellSpacing="0" cellPadding="0" width="584" border="0">
				<TR>
					<TD class="Titulo" style="WIDTH: 490px">&nbsp;Itinerario Personalizado</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">
						<TABLE class="tabla" id="Table1" style="WIDTH: 576px; HEIGHT: 62px" cellSpacing="0" cellPadding="0"
							width="576" bgColor="#cccccc" border="1">
							<TR>
								<TD style="WIDTH: 90px; HEIGHT: 29px">Nombre Cliente</TD>
								<TD style="WIDTH: 298px; HEIGHT: 29px"><asp:textbox id="txtCliente" runat="server" Width="421px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 90px; HEIGHT: 9px">&nbsp;</TD>
								<TD style="WIDTH: 298px; HEIGHT: 9px"><asp:button id="cmdImprime" runat="server" Text="Imprime Pagina"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px"><asp:label id="lblMsg" runat="server" Width="488px" 
                            CssClass="Msg"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px; HEIGHT: 1px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 490px">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
