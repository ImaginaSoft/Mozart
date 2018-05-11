<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="VtaVersionResumen.aspx.vb" Inherits="VtaVersionResumen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<!-- script for Rich Text Box -->
		<style type="text/css">.advertisement { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 12px; VERTICAL-ALIGN: middle; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: verdana, tahoma; TEXT-ALIGN: center; arial: }
	.cbtn { BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; BORDER-BOTTOM: buttonface 1px solid }
	.tblToolbar { BORDER-RIGHT: 1px outset; PADDING-RIGHT: 1px; BORDER-TOP: 1px outset; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px outset; COLOR: menutext; PADDING-TOP: 1px; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: buttonface }
	.raiseme { BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset }
	.raisemeleft { BORDER-LEFT: 2px groove }
	.codedisplay { FONT-SIZE: 10px; FONT-FAMILY: courier; TEXT-ALIGN: left }
	.selects { FONT-SIZE: 10px; FONT-FAMILY: tahoma, verdana, arial, courier, serif }
	.txtbtn { FONT-SIZE: 70%; COLOR: menutext; FONT-FAMILY: tahoma, verdana, arial, courier, serif }
	.DivMenu { BORDER-RIGHT: buttonface 1px groove; BORDER-TOP: buttonface 1px groove; Z-INDEX: 100; LEFT: -200px; BORDER-LEFT: buttonface 1px groove; WIDTH: 125px; BORDER-BOTTOM: buttonface 1px groove; POSITION: absolute; TOP: -1000px; BACKGROUND-COLOR: buttonface }
	.TDMenu { FONT-SIZE: 70%; WIDTH: 100%; CURSOR: default; COLOR: buttonface; font-familt: verdana }
		</style>
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
	<body MS_POSITIONING="GridLayout" onload="LoadDiv()">
		<table width="532" height="467" border="1" style="Z-INDEX:101; LEFT:8px; POSITION:absolute; TOP:32px; HEIGHT:467px; BACKGROUND-COLOR:white"
			align="center">
			<tr class="tblToolbar" bgcolor="darkgray">
				<td width="701" align="center" style="HEIGHT: 30px">
					<table width="433" cellspacing="1" cellpadding="0" id="TopToolBar" align="center" style="WIDTH: 433px; HEIGHT: 28px">
						<tr>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('bold')" onmouseout="button_out(this);"><IMG alt="Bold" hspace="1" src="images/Bold.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('italic')" onmouseout="button_out(this);"><img alt="Italic" hspace="1" src="images/Italic.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('underline')" onmouseout="button_out(this);"><img alt="Underline" hspace="1" src="images/Under.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><select onchange="EditorOnStyle(this);" class="Selects" style="WIDTH: 71px"><option selected>Style</option>
									<option value="Normal">Normal</option>
									<option value="Formatted">Formatted</option>
									<option value="Address">Address</option>
									<option value="Heading 1">Heading 1</option>
									<option value="Heading 2">Heading 2</option>
									<option value="Heading 3">Heading 3</option>
									<option value="Heading 4">Heading 4</option>
									<option value="Heading 5">Heading 5</option>
									<option value="Heading 6">Heading 6</option>
									<option value="Numbered List">Numbered List</option>
									<option value="Bulleted List">Bulleted List</option>
									<option value="Directory List">Directory List</option>
									<option value="Menu List">Menu List</option>
									<option value="Definition Term">Definition Term</option>
									<option value="Definition">Definition</option>
								</select>
							</td>
							<td>
								<select class="Selects" onchange="EditorOnFont(this);" style="WIDTH: 73px">
									<option selected>Font</option>
									<option value="Arial">Arial</option>
									<option value="Arial Black">Arial Black</option>
									<option value="Arial Narrow">Arial Narrow</option>
									<option value="Comic Sans MS">Comic Sans MS</option>
									<option value="Courier New">Courier New</option>
									<option value="System">System</option>
									<option value="Tahoma">Tahoma</option>
									<option value="Times New Roman">Times New Roman</option>
									<option value="Verdana">Verdana</option>
									<option value="Wingdings">Wingdings</option>
								</select>
							</td>
							<td>
								<select onchange="EditorOnSize(this);" class="Selects" style="WIDTH: 65px">
									<option selected>Size</option>
									<option value="1">1, 10px, 7pt</option>
									<option value="2">2, 12px, 10pt</option>
									<option value="3">3, 16px, 12pt</option>
									<option value="4">4, 18px, 14pt</option>
									<option value="5">5, 24px, 18pt</option>
									<option value="6">6, 32px, 24pt</option>
									<option value="7">7, 48px, 36pt</option>
								</select>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('strikethrough')" onmouseout="button_out(this);"><img alt="Strike Through" hspace="1" src="images/Strikethrough.gif" align="absMiddle"
										vspace="0"></div>
							</td>
							<td valign="middle"><input type="checkbox" onclick="setMode(this.checked)" id="checkbox2" name="checkbox2"></td>
							<td style="FONT:8pt verdana,arial,sans-serif" valign="middle" nowrap>Edit HTML
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr class="tblToolbar" bgcolor="darkgray">
				<td width="701" align="center" style="HEIGHT: 30px">
					<table width="391" cellpadding="0" cellspacing="0" id="BottomToolBar" style="WIDTH: 391px; HEIGHT: 32px">
						<tr>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('cut')" onmouseout="button_out(this);"><img alt="Cut" hspace="1" src="images/Cut.gif" align="absMiddle" vspace="0">
								</div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('copy')" onmouseout="button_out(this);"><img alt="Copy" hspace="1" src="images/Copy.gif" align="absMiddle" vspace="0">
								</div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('paste')" onmouseout="button_out(this);"><img alt="Paste" hspace="1" src="images/Paste.gif" align="absMiddle" vspace="0">
								</div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyleft')" onmouseout="button_out(this);"><img alt="Left Align" hspace="1" src="images/Left.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifycenter')" onmouseout="button_out(this);"><img alt="Center" hspace="1" src="images/Center.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyright')" onmouseout="button_out(this);"><img alt="Right Align" hspace="1" src="images/Right.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('justifyfull')" onmouseout="button_out(this);"><img alt="Justify" hspace="1" src="images/justify.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('insertorderedlist')" onmouseout="button_out(this);"><img alt="Ordered List" hspace="2" src="images/numlist.GIF" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('insertunorderedlist')" onmouseout="button_out(this);"><img alt="Unordered List" hspace="2" src="images/bullist.GIF" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('outdent')" onmouseout="button_out(this);"><img alt="Decrease Indent" hspace="2" src="images/deindent.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('indent')" onmouseout="button_out(this);"><img alt="Increase Indent" hspace="2" src="images/inindent.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="callColorDlg('ForeColor');" onmouseout="button_out(this);"><img alt="Font Color" hspace="1" src="images/tpaint.gif" align="absMiddle" vspace="0"></div>
							</td>
							<td><div onmouseup="button_up(this);" class="cbtn" onmousedown="button_down(this);" onmouseover="button_over(this);"
									onclick="cmdExec('inserthorizontalrule')" onmouseout="button_out(this);"><img alt="Horizontal Rule" hspace="2" src="images/hr.gif" align="absMiddle" vspace="0"></div>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td style="HEIGHT: 180px"><div id="TextEditor" contenteditable="true" height="250" indicateeditable="true" style="OVERFLOW: auto;WIDTH: 520px;HEIGHT: 360px;WORD-WRAP: break-word"></div>
				</td>
			</tr>
		</table>
		<OBJECT classid="clsid:5220cb21-c88d-11cf-b347-00aa00a28331">
		</OBJECT>
		<OBJECT id="dlgHelper" height="0px" width="0px" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b">
		</OBJECT>
		<OBJECT id="cDialog" codeBase="http://activex.microsoft.com/controls/vb5/comdlg32.cab" height="0px"
			width="0px" classid="CLSID:F9043C85-F6F2-101A-A3C9-08002B2F49FB">
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
		<form id="frmRTB" method="post" runat="server">
			<table width="528" border="0" align="center" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 528px; POSITION: absolute; TOP: 528px; HEIGHT: 30px"
				class="form">
				<TR> <!-- This is the textbox that will hold the info from the RTB --> <!-- to save to the database. -->
					<TD style="WIDTH: 18px">
						<asp:TextBox id=txtRTB runat="server" Text='<%# DataBinder.Eval(ds,"Tables[tblRTB].DefaultView.[0].Resumen") %>' Width="1px" Height="1px">
						</asp:TextBox></TD> <!-- Saves the data to the database -->
					<TD align="left">&nbsp;
						<asp:Button id="btnSave" runat="server" Text="Grabar" ToolTip="This will save the data in the Rich Text Box to the database."></asp:Button>
						<asp:Label id="lblmsg" runat="server"></asp:Label></TD>
				</TR>
			</table>
			<TABLE id="Table3" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				cellSpacing="0" cellPadding="1" width="536" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp;
							<asp:label id="lblTitulo" runat="server"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
