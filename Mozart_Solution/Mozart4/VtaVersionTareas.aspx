<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersionTareas.aspx.vb" Inherits="VtaVersionTareas" %>

<%@ Register src="ucVersion.ascx" tagname="ucVersion" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 544px; POSITION: absolute; TOP: 8px; HEIGHT: 327px"
				cellSpacing="0" cellPadding="1" width="544" border="0">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Tareas del&nbsp;Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD>
                        <uc1:ucVersion ID="ucVersion1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table5" style="WIDTH: 568px; HEIGHT: 171px" cellSpacing="1" cellPadding="1"
							width="568" border="1">
							<TR>
								<TD style="HEIGHT: 22px">Nueva Tarea</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="tabla" id="Table3" style="WIDTH: 560px; HEIGHT: 124px" cellSpacing="1" cellPadding="1"
										width="560" border="0">
										<TR>
											<TD style="WIDTH: 62px; HEIGHT: 42px">Fecha</TD>
											<TD style="WIDTH: 129px; HEIGHT: 42px">
												<TABLE class="tabla" id="Table1" style="WIDTH: 431px; HEIGHT: 25px" cellSpacing="0" cellPadding="0"
													width="431" border="0">
													<TR>
														<TD style="WIDTH: 184px"><asp:textbox id="txtFchTarea" runat="server" AutoPostBack="True" CssClass="fd" 
																Width="75px"></asp:textbox><INPUT class="fd" id="cmdFchTarea" style="WIDTH: 33px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchTarea',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
																tabIndex="2" type="button" value="..." name="cmdFchTarea"></TD>
														<TD>&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="chbFchRevision" runat="server" Width="344px" Text="Programar fecha revisión de la Versión (operaciones)"></asp:checkbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px; HEIGHT: 12px">Tarea</TD>
											<TD style="WIDTH: 129px; HEIGHT: 12px"><asp:textbox id="txtDesTarea" tabIndex="1" runat="server" Width="464px" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px; HEIGHT: 12px">Vendedor</TD>
											<TD style="WIDTH: 129px; HEIGHT: 12px"><asp:dropdownlist id="ddlVendedor" runat="server" Width="331px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px; HEIGHT: 12px"></TD>
											<TD style="WIDTH: 129px; HEIGHT: 12px"><asp:button id="cmdGrabrar" tabIndex="2" runat="server" Width="86px" Text="Grabar"></asp:button></TD>
										</TR>
									</TABLE>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblerror" runat="server" CssClass="error"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblmsg" runat="server" CssClass="msg" Width="571px" Height="9px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgTarea" runat="server" CssClass="Grid" Width="728px" Height="24px" BorderColor="CadetBlue"
							CellPadding="3" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None" DataKeyNames="KeyReg">
                            <SelectedRowStyle CssClass="GridSelect" />
						    <AlternatingRowStyle CssClass="GridAlterna" />
   			                <RowStyle  CssClass="GridData" />
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
								<asp:BoundField DataField="CodVendedor" HeaderText="Resposable"></asp:BoundField>
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
					<TD><asp:button id="cmdCompletar" runat="server" Width="185px" Text="Completar tareas marcadas"></asp:button></TD>
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
