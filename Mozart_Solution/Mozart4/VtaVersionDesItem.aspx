﻿<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaVersionDesItem.aspx.vb" Inherits="VtaVersionDesItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<!-- Style for the Rich Text Box -->
		<style type="text/css">.advertisement { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 12px; VERTICAL-ALIGN: middle; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: verdana, tahoma; TEXT-ALIGN: center; arial: }
	.tblToolbar { BORDER-RIGHT: 1px outset; PADDING-RIGHT: 1px; BORDER-TOP: 1px outset; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px outset; COLOR: menutext; PADDING-TOP: 1px; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: buttonface }
	.raiseme { BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset }
	.raisemeleft { BORDER-LEFT: 2px groove }
	.cbtn { BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; BORDER-BOTTOM: buttonface 1px solid }
	.codedisplay { FONT-SIZE: 10px; FONT-FAMILY: courier; TEXT-ALIGN: left }
	.selects { FONT-SIZE: 10px; FONT-FAMILY: tahoma, verdana, arial, courier, serif }
	.txtbtn { FONT-SIZE: 70%; COLOR: menutext; FONT-FAMILY: tahoma, verdana, arial, courier, serif }
	.DivMenu { BORDER-RIGHT: buttonface 1px groove; BORDER-TOP: buttonface 1px groove; Z-INDEX: 100; LEFT: -200px; BORDER-LEFT: buttonface 1px groove; WIDTH: 125px; BORDER-BOTTOM: buttonface 1px groove; POSITION: absolute; TOP: -1000px; BACKGROUND-COLOR: buttonface }
	.TDMenu { FONT-SIZE: 70%; WIDTH: 100%; CURSOR: default; COLOR: buttonface; font-familt: verdana }
		</style>
		<!-- script for Rich Text Box -->
		<script language="jscript">
		
		window.onload="doInit"; 
		
		// For EmotIcon Menu
		var isViewEmotIconMenu = false;
		
		function doInit()
		{
			for (i=0; i<document.all.length; i++) 
			document.all(i).unselectable = "on";
			TextEditor.unselectable = "off";
			TextEditor.focus();
		} 
		
		var isHTMLMode = false;
		var bShow = false;
		var sPersistValue;
		
		// button over effect
		function button_over(eButton)
		{
			eButton.style.backgroundColor = "#B5BDD6";
			eButton.style.borderColor = "darkblue darkblue darkblue darkblue";
		} 
		
		// go back to normal
		function button_out(eButton) 
		{
			eButton.style.backgroundColor = "threedface";
			eButton.style.borderColor = "threedface";
		} 
		
		// button down effect
		function button_down(eButton)
		{
			eButton.style.backgroundColor = "#8494B5";
			eButton.style.borderColor = "darkblue darkblue darkblue darkblue";
		} 
		
		// back to normal
		function button_up(eButton) 
		{
			eButton.style.backgroundColor = "#B5BDD6";
			eButton.style.borderColor = "darkblue darkblue darkblue darkblue";
			eButton = null;
		} 
		
		// Resets Style to default after selection
		function EditorOnStyle(select)
		{
			cmdExec("formatBlock", select[select.selectedIndex].value);
			select.selectedIndex = 0;
		}
		
		// Resets Font to default after selection
		function EditorOnFont(select)
		{
			cmdExec("fontname", select[select.selectedIndex].value);
			select.selectedIndex = 0;
		}
		
		// Resets Size to default after selection
		function EditorOnSize(select)
		{
			cmdExec("fontsize", select[select.selectedIndex].value);
			select.selectedIndex = 0;
		}
		
		// execute command and enter the HTML in the RTB
		function cmdExec(cmd,opt)
		{
			if (isHTMLMode){alert("Please uncheck 'Edit HTML'");return;}
			
			TextEditor.focus();
			TextEditor.document.execCommand(cmd,bShow,opt);
			bShow=false;
		} 
		
		// sets the mode for HTML or Text
		function setMode(bMode)
		{
				
			var sTmp;
  			isHTMLMode = bMode;
  			if (isHTMLMode)
			{
				sTmp=TextEditor.innerHTML;
				TextEditor.innerText=sTmp;
			} 
			else 
			{
				sTmp=TextEditor.innerText;
				TextEditor.innerHTML=sTmp;
			}
  			TextEditor.focus();
		}
		
		// Insert Image
		function insertImage()
		{
			if (isHTMLMode){alert("Please uncheck 'Edit HTML'");return;}
			bShow=true;
			cmdExec("InsertImage");
		} 
			
		// Insert Horizontal Rule
		function insertRuler()
		{
			if (isHTMLMode){alert("Please uncheck 'Edit HTML'");return;}
			cmdExec("InsertHorizontalRule","");
		} 
		
		// sets everything to vertical mode
		function VerticalMode()
		{
			if (TextEditor.style.writingMode == 'tb-rl') TextEditor.style.writingMode = 'lr-tb';
			else TextEditor.style.writingMode = 'tb-rl';
		} 
		
		// calls the color object
		function callColorDlg(sColorType)
		{
			var sColor = dlgHelper.ChooseColorDlg();sColor = sColor.toString(16);
			if (sColor.length < 6) 
			{
				var sTempString = "000000".substring(0,6-sColor.length);
				sColor = sTempString.concat(sColor);
			}
			cmdExec(sColorType, sColor);	
		} 
		
		// sets the text in the Div to a textbox which you can pull the 
		// data from to save in the database
		function getHTML()
		{
			var String = TextEditor;  // The TextEditor DIV can not be in a form or the Java error out
			frmRTB.txtRTB.value = String.innerHTML;   //you can't make the text box invisible or the Java will error out
		}
		
		// Load RTB info from the database into the DIV field on the web.
		// so one can edit the database info in the Rich Text Box.
		function LoadDiv()
		{
			var String = frmRTB.txtRTB.value;
			TextEditor.innerHTML = String;   // set the innerHTML of the DIV to the text of the textbox
		}
		</script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="LoadDiv()" MS_POSITIONING="GridLayout">
		<TABLE id="Table2" style="Z-INDEX: 104; LEFT: 8px; WIDTH: 546px; POSITION: absolute; TOP: 170px; HEIGHT: 380px; BACKGROUND-COLOR: white"
			height="380" width="546" align="center" border="1">
			<TR class="tblToolbar" bgColor="darkgray">
				<TD style="HEIGHT: 28px" align="center" width="701">
					<TABLE id="TopToolBar" style="WIDTH: 433px; HEIGHT: 28px" cellSpacing="1" cellPadding="0"
						width="433" align="center">
						<TR>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('bold')" onmouseout="button_out(this);"><IMG alt="Bold" hspace="1" src="images/Bold.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('italic')" onmouseout="button_out(this);"><IMG alt="Italic" hspace="1" src="images/Italic.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('underline')" onmouseout="button_out(this);"><IMG alt="Underline" hspace="1" src="images/Under.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD><SELECT class="Selects" style="WIDTH: 71px" onchange="EditorOnStyle(this);"><OPTION selected>Style</OPTION>
									<OPTION value="Normal">Normal</OPTION>
									<OPTION value="Formatted">Formatted</OPTION>
									<OPTION value="Address">Address</OPTION>
									<OPTION value="Heading 1">Heading 1</OPTION>
									<OPTION value="Heading 2">Heading 2</OPTION>
									<OPTION value="Heading 3">Heading 3</OPTION>
									<OPTION value="Heading 4">Heading 4</OPTION>
									<OPTION value="Heading 5">Heading 5</OPTION>
									<OPTION value="Heading 6">Heading 6</OPTION>
									<OPTION value="Numbered List">Numbered List</OPTION>
									<OPTION value="Bulleted List">Bulleted List</OPTION>
									<OPTION value="Directory List">Directory List</OPTION>
									<OPTION value="Menu List">Menu List</OPTION>
									<OPTION value="Definition Term">Definition Term</OPTION>
									<OPTION value="Definition">Definition</OPTION>
								</SELECT>
							</TD>
							<TD><SELECT class="Selects" style="WIDTH: 73px" onchange="EditorOnFont(this);">
									<OPTION selected>Font</OPTION>
									<OPTION value="Arial">Arial</OPTION>
									<OPTION value="Arial Black">Arial Black</OPTION>
									<OPTION value="Arial Narrow">Arial Narrow</OPTION>
									<OPTION value="Comic Sans MS">Comic Sans MS</OPTION>
									<OPTION value="Courier New">Courier New</OPTION>
									<OPTION value="System">System</OPTION>
									<OPTION value="Tahoma">Tahoma</OPTION>
									<OPTION value="Times New Roman">Times New Roman</OPTION>
									<OPTION value="Verdana">Verdana</OPTION>
									<OPTION value="Wingdings">Wingdings</OPTION>
								</SELECT>
							</TD>
							<TD><SELECT class="Selects" style="WIDTH: 65px" onchange="EditorOnSize(this);">
									<OPTION selected>Size</OPTION>
									<OPTION value="1">1, 10px, 7pt</OPTION>
									<OPTION value="2">2, 12px, 10pt</OPTION>
									<OPTION value="3">3, 16px, 12pt</OPTION>
									<OPTION value="4">4, 18px, 14pt</OPTION>
									<OPTION value="5">5, 24px, 18pt</OPTION>
									<OPTION value="6">6, 32px, 24pt</OPTION>
									<OPTION value="7">7, 48px, 36pt</OPTION>
								</SELECT>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('strikethrough')" onmouseout="button_out(this);"><IMG alt="Strike Through" hspace="1" src="images/Strikethrough.gif" align="absMiddle"
										vspace="0"></DIV>
							</TD>
							<TD vAlign="middle"><INPUT id="checkbox2" onclick="setMode(this.checked)" type="checkbox" name="checkbox2"></TD>
							<TD style="FONT: 8pt verdana,arial,sans-serif" vAlign="middle" noWrap>Edit HTML
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR class="tblToolbar" bgColor="darkgray">
				<TD style="HEIGHT: 12px" align="center" width="701">
					<TABLE id="BottomToolBar" style="WIDTH: 391px; HEIGHT: 32px" cellSpacing="0" cellPadding="0"
						width="391">
						<TR>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('cut')" onmouseout="button_out(this);"><IMG alt="Cut" hspace="1" src="images/Cut.gif" align="absMiddle" vspace="0">
								</DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('copy')" onmouseout="button_out(this);"><IMG alt="Copy" hspace="1" src="images/Copy.gif" align="absMiddle" vspace="0">
								</DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('paste')" onmouseout="button_out(this);"><IMG alt="Paste" hspace="1" src="images/Paste.gif" align="absMiddle" vspace="0">
								</DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyleft')" onmouseout="button_out(this);"><IMG alt="Left Align" hspace="1" src="images/Left.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifycenter')" onmouseout="button_out(this);"><IMG alt="Center" hspace="1" src="images/Center.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyright')" onmouseout="button_out(this);"><IMG alt="Right Align" hspace="1" src="images/Right.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyfull')" onmouseout="button_out(this);"><IMG alt="Justify" hspace="1" src="images/justify.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('insertorderedlist')" onmouseout="button_out(this);"><IMG alt="Ordered List" hspace="2" src="images/numlist.GIF" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('insertunorderedlist')" onmouseout="button_out(this);"><IMG alt="Unordered List" hspace="2" src="images/bullist.GIF" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('outdent')" onmouseout="button_out(this);"><IMG alt="Decrease Indent" hspace="2" src="images/deindent.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('indent')" onmouseout="button_out(this);"><IMG alt="Increase Indent" hspace="2" src="images/inindent.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="callColorDlg('ForeColor');" onmouseout="button_out(this);"><IMG alt="Font Color" hspace="1" src="images/tpaint.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
							<TD>
								<DIV onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('inserthorizontalrule')" onmouseout="button_out(this);"><IMG alt="Horizontal Rule" hspace="2" src="images/hr.gif" align="absMiddle" vspace="0"></DIV>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD style="HEIGHT: 180px">
					<DIV id="TextEditor" contentEditable="true" style="OVERFLOW: auto; WIDTH: 535px; HEIGHT: 265px; WORD-WRAP: break-word"
						height="250" indicateeditable="true"></DIV>
				</TD>
			</TR>
		</TABLE>
		<asp:radiobutton id="rbtDetPub" style="Z-INDEX: 108; LEFT: 480px; POSITION: absolute; TOP: 528px"
			Visible="False" Checked="True" GroupName="G1" Text="DetPublicado" runat="server"></asp:radiobutton>
		<asp:radiobutton id="rbtRes1" 
    style="Z-INDEX: 107; LEFT: 280px; POSITION: absolute; TOP: 528px; width: 75px;" runat="server"
			Text="Resumen" GroupName="G1" Visible="False"></asp:radiobutton>
		<asp:radiobutton id="rbtDet1" 
    style="Z-INDEX: 106; LEFT: 392px; POSITION: absolute; TOP: 528px; right: 297px;" runat="server"
			Text="Detalle " GroupName="G1" Visible="False"></asp:radiobutton>
		<OBJECT id="dlgHelper" height="0px" width="0px" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b">
		</OBJECT>
		<OBJECT id="cDialog" style="Z-INDEX: 102; LEFT: 574px; WIDTH: 1px; POSITION: absolute; TOP: 98px; HEIGHT: 1px"
			codeBase="http://activex.microsoft.com/controls/vb5/comdlg32.cab" height="0px" width="0px"
			classid="CLSID:F9043C85-F6F2-101A-A3C9-08002B2F49FB">
			<PARAM NAME="_ExtentX" VALUE="847">
			<PARAM NAME="_ExtentY" VALUE="847">
			<PARAM NAME="_Version" VALUE="393216">
			<PARAM NAME="CancelError" VALUE="0">
			<PARAM NAME="Color" VALUE="0">
			<PARAM NAME="Copies" VALUE="1">
			<PARAM NAME="DefaultExt" VALUE="">
			<PARAM NAME="DialogTitle" VALUE="">
			<PARAM NAME="FileName" VALUE="">
			<PARAM NAME="Filter" VALUE="">
			<PARAM NAME="FilterIndex" VALUE="0">
			<PARAM NAME="Flags" VALUE="0">
			<PARAM NAME="FontBold" VALUE="0">
			<PARAM NAME="FontItalic" VALUE="0">
			<PARAM NAME="FontName" VALUE="">
			<PARAM NAME="FontSize" VALUE="8">
			<PARAM NAME="FontStrikeThru" VALUE="0">
			<PARAM NAME="FontUnderLine" VALUE="0">
			<PARAM NAME="FromPage" VALUE="0">
			<PARAM NAME="HelpCommand" VALUE="0">
			<PARAM NAME="HelpContext" VALUE="0">
			<PARAM NAME="HelpFile" VALUE="">
			<PARAM NAME="HelpKey" VALUE="">
			<PARAM NAME="InitDir" VALUE="">
			<PARAM NAME="Max" VALUE="0">
			<PARAM NAME="Min" VALUE="0">
			<PARAM NAME="MaxFileSize" VALUE="260">
			<PARAM NAME="PrinterDefault" VALUE="1">
			<PARAM NAME="ToPage" VALUE="0">
			<PARAM NAME="Orientation" VALUE="1">
		</OBJECT>
		<OBJECT style="Z-INDEX: 103; LEFT: 552px; WIDTH: 8px; POSITION: absolute; TOP: 534px; HEIGHT: 2px"
			classid="clsid:5220cb21-c88d-11cf-b347-00aa00a28331">
		</OBJECT>
		<form id="frmRTB" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 544px; POSITION: absolute; TOP: 8px; HEIGHT: 21px"
				cellSpacing="0" cellPadding="1" width="544" border="0" class="form">
				<TR>
					<TD style="HEIGHT: 16px">
						<P class="Titulo"><asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" class="opciones">
						<asp:linkbutton id="lbtResumen" runat="server">Resumen</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:linkbutton id="lbtDetalle" runat="server">Detalle</asp:linkbutton>&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:linkbutton id="lbtDetallePublicado" runat="server">Detalle Publicado</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lbtFicha" runat="server">Version-Servicos</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 18px">
						<asp:TextBox id=txtRTB runat="server" Text='<%# DataBinder.Eval(dsEdit,"Tables[DVERSION].DefaultView.[0].DesServicioDet") %>' Width="1px" Height="1px">
						</asp:TextBox></TD> <!-- Saves the data to the database -->
				</TR>
				<TR>
					<TD style="HEIGHT: 5px">
						<asp:Label id="lblDesProveedor" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[DVERSION].DefaultView.[0].DesProveedor") %>' >
						</asp:Label>&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px">
						<asp:label id="lblmsg" runat="server" Width="392px" CssClass="error"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="cmdGrabar" Text="Grabar" runat="server" Width="188px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 536px" runat="server"></asp:Label>
		</form>

</body>
</html>
