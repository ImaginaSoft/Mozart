<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPropuestaTareas.aspx.vb" Inherits="VtaPropuestaTareas" %>

<%@ Register src="ucPropuesta.ascx" tagname="ucPropuesta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 12px;
            width: 174px;
        }
    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 8px; HEIGHT: 169px"
				cellSpacing="0" cellPadding="1" width="600"  border="0"
				class="TABLA">
				<TR>
					<TD>
						<P class="Titulo">
							&nbsp; Tareas del Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucPropuesta ID="ucPropuesta1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table5" style="WIDTH: 669px; HEIGHT: 84px" cellSpacing="1" cellPadding="1"
							border="1" class="tabla">
							<TR>
								<TD style="HEIGHT: 22px">Nueva Tarea</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 606px; HEIGHT: 29px" 
                                        cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD style="WIDTH: 44px; HEIGHT: 12px">Fecha</TD>
											<TD class="style1">
												<asp:textbox id="txtFchTarea" runat="server" AutoPostBack="True" CssClass="fd" 
													Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchTarea" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchTarea',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchTarea"></TD>
											<TD style="WIDTH: 36px; HEIGHT: 12px">Tarea</TD>
											<TD style="WIDTH: 417px; HEIGHT: 12px">
												<asp:TextBox id="txtDesTarea" tabIndex="1" runat="server" Width="389px" MaxLength="50"></asp:TextBox></TD>
										</TR>
									</TABLE>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:Button id="cmdGrabrar" tabIndex="2" runat="server" Width="86px" Text="Grabar"></asp:Button>&nbsp;
									<asp:Label id="lblerror" runat="server" CssClass="error"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblmsg" runat="server" Width="571px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgTarea" runat="server" Height="24px" Width="728px" CellPadding="3" BorderWidth="1px"
							CssClass="Grid" BorderColor="CadetBlue" AutoGenerateColumns="False" BorderStyle="None" DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:BoundField DataField="FchTarea" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>
								<asp:BoundField DataField="DesTarea" SortExpression="NroReporte" HeaderText="Tarea"></asp:BoundField>
								<asp:BoundField DataField="StsTarea" HeaderText="Estado"></asp:BoundField>
								<asp:BoundField DataField="color" HeaderText="color">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundField>
								<asp:BoundField DataField="CodUsuario" HeaderText="Usuario"></asp:BoundField>
								<asp:BoundField DataField="FchAct" HeaderText="Actualizado"></asp:BoundField>
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="cmdCompletar" runat="server" Text="Completar tareas marcadas" Width="185px"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>
		</form>
</body>
</html>
