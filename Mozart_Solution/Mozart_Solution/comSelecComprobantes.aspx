<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comSelecComprobantes.aspx.vb" Inherits="comSelecComprobantes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
	<script language="JavaScript" src="calendario.js" type="text/javascript"></script>
	<link  href="Styles.css" type="text/css" rel="stylesheet">
    <script type="text/javascript">
        function ChangeCheckBoxState(id, checkState) {
            var cb = document.getElementById(id);
            if (cb != null)
                cb.checked = checkState;
        }

        function ChangeAllCheckBoxStates(checkState) {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null) {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxState(CheckBoxIDs[i], checkState);
            }
        }

        function ChangeHeaderAsNeeded() {
            // Whenever a checkbox in the GridView is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null) {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++) {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked) {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false);
                        return;
                    }
                }

                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true);
            }
        }
    </script>
		
	
	</head>
	<body >
		<form id="Form1" method="post" runat="server">
		
			<TABLE class="form" id="Table1" 
				cellSpacing="0" cellPadding="0" width="560" border="0">
				<TR>
					<TD class="Titulo">
						Selección de Comprobantes
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
				</TR>
				<TR>
					<TD >
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD>
									<TABLE class="tabla" id="Table5" 
										width="368" border="1" borderColor="#cccccc">
										<TR>
											<TD style="WIDTH: 69px">&nbsp;Fecha del
											</TD>
											<TD><asp:textbox id="txtFchIni" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="cmdFchInicial" style="WIDTH: 29px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchIni',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchInicial">
												<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Width="18px" CssClass="error" Height="8px"
													ControlToValidate="txtFchIni" ForeColor=" ">*</asp:requiredfieldvalidator>al&nbsp;&nbsp;
												<asp:textbox id="txtFchFin" runat="server" Width="75px" CssClass="fd" ></asp:textbox><INPUT class="fd" id="Button1" style="WIDTH: 31px; HEIGHT: 24px" onclick="show_calendar('Form1.txtFchFin',null,null,'DD-MM-YYYY','POPUP','Nav=Yes;SmartNav=Yes;AllowWeekends=Yes');"
													tabIndex="2" type="button" value="..." name="cmdFchFinal">
												<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Width="18px" CssClass="error" Height="8px"
													ControlToValidate="txtFchFin" ForeColor=" ">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 69px">&nbsp;Tipo</TD>
											<TD><asp:radiobutton id="rbcompras" runat="server" Text="Compras" GroupName="GRUPO1" Checked="True"></asp:radiobutton><asp:radiobutton id="rbVentas" runat="server" Text="Ventas" GroupName="GRUPO1"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="middle"><asp:button id="cmdConsultar" runat="server" Width="74px" Text="Buscar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD class="msg">
						<TABLE id="Table4"  cellSpacing="1" cellPadding="1" width="466"
							border="0">
							<TR>
								<TD >
									<asp:Label id="lblmsg" runat="server" CssClass="msg" Width="169px"></asp:Label></TD>
								<TD>
									<TABLE class="form" id="Table3"  cellSpacing="0" cellPadding="0"
										width="410" border="1" borderColor="#cccccc">
										<TR>
											<TD style="WIDTH: 72px">Declaración
											</TD>
											<TD>
												<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0"
													width="230" border="0">
													<TR>
														<TD style="WIDTH: 32px">Año</TD>
														<TD style="WIDTH: 50px">
															<asp:textbox id="txtano" runat="server" Width="37px" MaxLength="4" DESIGNTIMEDRAGDROP="21">2005</asp:textbox>&nbsp;&nbsp;</TD>
														<TD>Mes</TD>
														<TD>
															<asp:dropdownlist id="ddlCalendario" runat="server" Width="105px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
											<TD>
												<asp:button id="btnGrabar" runat="server" Width="74px" Text="Grabar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR><TD>
            <asp:GridView ID="dgDocumento" runat="server"
                CssClass="Grid"  AutoGenerateColumns="False" DataKeyNames="Correlativo" 
                CellPadding="2" BorderWidth="1px" BorderColor="CadetBlue" 
                        UseAccessibleHeader="False" AllowSorting="True">
                
                <FooterStyle BackColor="#990000"  ForeColor="White" />
                <RowStyle  CssClass="GridData" />
                <SelectedRowStyle CssClass="GridSelect" />
                <PagerStyle HorizontalAlign="Center" />
                <HeaderStyle CssClass="GridHeader"   />
                <AlternatingRowStyle CssClass="GridAlterna" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TipoComprobante" SortExpression="TipoComprobante" HeaderText="Tipo" />
                    <asp:BoundField DataField="FchComprobante" SortExpression="FchComprobante" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                    </asp:BoundField>
								<asp:TemplateField SortExpression="Nombre" HeaderText="Cliente/Proveedor">
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Nombre")%>' NavigateUrl='<%# "comSelecAnula.aspx?TipoSistema=" + cstr(DataBinder.Eval(Container.DataItem,"TipoSistema"))+"&NroLiqCom=" + cstr(DataBinder.Eval(Container.DataItem,"NroLiqCom"))%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
					
					
					<asp:BoundField DataField="Ruc" SortExpression="Ruc" HeaderText="Ruc"></asp:BoundField>
					<asp:BoundField DataField="SSubTotal" SortExpression="SSubTotal" HeaderText="SubTotal" DataFormatString="{0:###,###,###,###.00}">
	    				<ItemStyle HorizontalAlign="Right"></ItemStyle>
		            </asp:BoundField>
					<asp:BoundField DataField="SIGV" SortExpression="SIGV" HeaderText="IGV /Ret." DataFormatString="{0:###,###,###,###.00}">
		    			<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="SInafecto" SortExpression="SInafecto" HeaderText="Inafecta" DataFormatString="{0:###,###,###,###.00}">
			    		<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="STotal" SortExpression="STotal" HeaderText="Total" DataFormatString="{0:###,###,###,###.00}">
				    	<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="TipoCambio" SortExpression="TipoCambio" HeaderText="T.C.">
    					<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="AnoDeclara" SortExpression="AnoDeclara" HeaderText="Año">
	    				<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="MesDeclara" SortExpression="MesDeclara" HeaderText="Mes">
		    			<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="CodUsuario" SortExpression="CodUsuario" HeaderText="Usuario"></asp:BoundField>
					<asp:BoundField DataField="fchsys" SortExpression="fchsys" HeaderText="Actualizado">
			    		<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundField>
					
                </Columns>
            </asp:GridView>
            </TD>
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
    
    </form>
</body>
</html>
