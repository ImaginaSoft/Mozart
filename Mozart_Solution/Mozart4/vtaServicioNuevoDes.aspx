<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="vtaServicioNuevoDes.aspx.vb" Inherits="vtaServicioNuevoDes" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	<style type="text/css">
        .style1
        {
            height: 10px;
            width: 618px;
        }
        .style2
        {
            font-weight: bold;
            font-size: 13pt;
            color: white;
            font-family: Arial, Verdana, Helvetica, sans-serif;
            background-color: #6699cc;
            height: 1px;
            width: 618px;
        }
        .style3
        {
            width: 618px;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 618px;
            height: 15px;
        }
    </style>
	</HEAD>
	<body  MS_POSITIONING="GridLayout">

		<form id="frmRTB" method="post" runat="server" enctype="multipart/form-data">
		
			<TABLE class="form" id="Table1" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD class="style2">
					    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>

					<TD class="style3">&nbsp;&nbsp; &nbsp;&nbsp; 
						&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>

				</TR>
				<TR>
					<TD class="style3">
					    <table class="style4">
                            <tr>
                                <td>
                                    <asp:linkbutton id="lbtResEspanol" runat="server">Resumen Español</asp:linkbutton>
                                </td>
                                <td>
						<asp:linkbutton id="lbtResIngles" runat="server">Resumen Ingles</asp:linkbutton>
                                </td>
                                <td>
						<asp:linkbutton id="lbtRes3" runat="server">Resumen Portugues</asp:linkbutton>
                                </td>
                                <td>
						<asp:linkbutton id="lbtServicios" runat="server">Buscar Servicio</asp:linkbutton>
					            </td>
                            </tr>
                            <tr>
                                <td>
						<asp:linkbutton id="lbtDetEspanol" runat="server">Detalle Español</asp:linkbutton>
                                </td>
                                <td>
						<asp:linkbutton id="lbtDetIngles" runat="server">Detalle Ingles</asp:linkbutton>
                                </td>
                                <td>
						<asp:linkbutton id="lbtDet3" runat="server">Detalle Portugues</asp:linkbutton>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </TD>

				</TR>

				<TR>
					<TD class="style3">
					    &nbsp;&nbsp;</TD>

				</TR>

				<TR>
					<TD class="style1">
							<P>Click edit HTML, reemplazar&nbsp;las etiquetas &lt;P&gt; por &lt;div&gt; y 
							&lt;/P&gt; por &lt;/div&gt;, desmarcar edit HTML y grabar.</P>

					</TD>
				</TR>

				<TR>
					<TD class="style3">
                        <asp:label id="lblmsg" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="style3">
			</asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="style3">
			            <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text='<%# DataBinder.Eval(dsEdit, "Tables[Servicio].DefaultView.[0].DesServicio") %>'>
                        </FTB:FreeTextBox>
                        
                        
					</TD>
				</TR>
				<TR>
					<TD align="center" class="style3">
                        	<asp:button id="cmdGrabar" 
				            runat="server" Width="184px" Visible="False">
                		    </asp:button>

					</TD>
				</TR>
				<TR>
					<TD align="left" class="style5">
					<asp:label id="lblpie" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD align="left" class="style3">
					    &nbsp;</TD>
				</TR>
				<TR>
					<TD align="left" class="style3">
					    &nbsp; Imagen 1&nbsp;: &nbsp;<asp:FileUpload ID="btnImportar" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD align="left" class="style3">
					    &nbsp;&nbsp;Imagen 2 :&nbsp;                         <asp:FileUpload ID="btnImportar2" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD align="left" class="style3">
					    &nbsp;&nbsp;Imagen 3 :&nbsp; <asp:FileUpload ID="btnImportar3" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD align="left" class="style3">
					    &&nbsp;&nbsp;<asp:GridView ID="dlgImg" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="Imagen2">
                                    <ItemTemplate>
                                        <img alt="" height="200px"  
                                            width="200px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </TD>
				</TR>
			</TABLE>
		
		


			
			
		</form>
</body>
</html>
