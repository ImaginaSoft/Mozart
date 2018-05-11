<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaPedidoTareas.aspx.vb" Inherits="VtaPedidoTareas" %>

<%@ Register src="ucPedido.ascx" tagname="ucPedido" tagprefix="uc1" %>

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
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 611px; POSITION: absolute; TOP: 8px; HEIGHT: 280px"
				cellSpacing="0" cellPadding="1" width="611" border="0" class="form">
				<TR>
					<TD>
						<P class="Titulo">&nbsp; Tareas del Pedido</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucPedido ID="ucPedido1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD></TD>
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
														<TD>&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="chbFchRevision" runat="server" 
                                                                Width="344px" Text="Programar fecha revisión de la Versión (operaciones)" 
                                                                Visible="False"></asp:checkbox></TD>
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
									</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblerror" runat="server" Width="571px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgTarea" runat="server" Height="24px" Width="728px" CssClass="Grid" BorderColor="CadetBlue"
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
								<asp:TemplateField HeaderText="Tarea">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DesTarea")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"URL")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
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
