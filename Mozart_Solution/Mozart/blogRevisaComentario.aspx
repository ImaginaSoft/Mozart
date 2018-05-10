<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogRevisaComentario.aspx.vb" Inherits="blogRevisaComentario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<SCRIPT language="JavaScript" src="calendario.js" type="text/javascript"></SCRIPT>
		<script language="JavaScript" src="checkbox.js" type="text/javascript"></script>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 752px; POSITION: absolute; TOP: 7px; HEIGHT: 88px"
				cellSpacing="0" cellPadding="0" width="752" border="0">
				<TR>
					<TD class="titulo">
						<P class="Titulo">&nbsp;Revisa Comentarios</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 454px">
									<TABLE class="tabla" id="Table2" style="WIDTH: 456px; HEIGHT: 101px" borderColor="#cccccc"
										cellSpacing="0" cellPadding="0" width="456" border="1">
										<TR>
											<TD style="WIDTH: 129px; HEIGHT: 15px">Vendedor</TD>
											<TD style="WIDTH: 338px; HEIGHT: 15px">
												<asp:dropdownlist id="ddlVendedor" runat="server" Width="298px" DataTextField="NomVendedor" DataValueField="CodVendedor"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 129px">Fecha de ingreso</TD>
											<TD style="WIDTH: 338px">
												<asp:textbox id="txtFchInicial" runat="server" Width="75px" CssClass="fd" DESIGNTIMEDRAGDROP="21"></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchInicial',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchInicial" DESIGNTIMEDRAGDROP="22">
												<asp:requiredfieldvalidator id="rfvFchEmision" runat="server" Width="18px" CssClass="error" DESIGNTIMEDRAGDROP="23"
													ForeColor=" " ControlToValidate="txtFchInicial" Height="8px">*</asp:requiredfieldvalidator>
												<asp:label id="Label2" runat="server" Width="17px" DESIGNTIMEDRAGDROP="24">al</asp:label>&nbsp; 
												&nbsp;
												<asp:textbox id="txtFchFinal" runat="server" Width="75px"  CssClass="fd" DESIGNTIMEDRAGDROP="25"></asp:textbox><INPUT class="fd" id="cmdFchFinal" style="WIDTH: 41px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFinal',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchFinal" DESIGNTIMEDRAGDROP="26">
												<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="18px" CssClass="ERROR" DESIGNTIMEDRAGDROP="27"
													ForeColor=" " ControlToValidate="txtFchFinal" Height="8px">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 129px; HEIGHT: 3px">Estado Comentario</TD>
											<TD style="WIDTH: 338px; HEIGHT: 3px">
												<asp:radiobutton id="rbtTodos" runat="server" GroupName="g1" Text="Todos"></asp:radiobutton>&nbsp;&nbsp;
												<asp:radiobutton id="rbtPendiente" runat="server" GroupName="g1" Text="Pendiente " Checked="True"></asp:radiobutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 129px"></TD>
											<TD style="WIDTH: 338px">
												<asp:button id="cmdConsultar" runat="server" Text="Consultar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<TABLE class="tabla" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="lblaviso" runat="server" Width="248px" Visible="False">Seleccionar con check los comentarios con estado pendiente, para aprobar su contenido y comunicar por e-mail al cliente que tiene  comentario acerca de su experiencia.   </asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 12px" align="center"></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:button id="btnGrabar" runat="server" Width="155px" Text="Aprobar y Enviar Email" Visible="False"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px">&nbsp;<asp:label id="lblmsg" runat="server" Width="169px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD class="msg"></TD>
				</TR>
				<TR>
					<TD><asp:GridView id="dgPedidos" runat="server" Width="800px" CssClass="Grid" Height="17px" AllowSorting="True"
							BorderColor="CadetBlue" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2" ShowFooter="True" DataKeyNames="KeyReg">
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
							
                                <asp:TemplateField>
                                    <ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Target=_blank Text="Blog" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"NavigateUrl")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField  DataField="DesComentario" SortExpression="DesComentario" HeaderText="Comentario"></asp:BoundField >
								<asp:BoundField  DataField="RecibeComentario" SortExpression="RecibeComentario" HeaderText="Recibe Comen.">
									<ItemStyle HorizontalAlign="center"></ItemStyle>
								</asp:BoundField >
								<asp:BoundField  DataField="CodVendedor" SortExpression="CodVendedor" HeaderText="Vendedor">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField >
								<asp:BoundField  DataField="DesRevision" SortExpression="DesRevision" HeaderText="Sts">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundField >
								<asp:ButtonField Text="Eliminar" CommandName="Delete"></asp:ButtonField>
								<asp:BoundField  DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Revisado"></asp:BoundField >
								<asp:BoundField  Visible="False" DataField="NroPedido" HeaderText="NroPedido"></asp:BoundField >
							</Columns>
						</asp:GridView></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblerror" runat="server" Width="410px" CssClass="error" 
                            Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
			
			<p>
                <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>&nbsp;
            </p>

		</FORM>
</body>
</html>
