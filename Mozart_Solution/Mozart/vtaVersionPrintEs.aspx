<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaVersionPrintEs.aspx.vb" Inherits="vtaVersionPrintEs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="StylesPeru4me.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body ms_positioning="GridLayout">
		<TABLE height="257" cellSpacing="0" cellPadding="0" width="659" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="8" height="8"></TD>
				<TD width="651"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="249"></TD>
				<TD>
					<TABLE height="248" cellSpacing="0" cellPadding="0" width="650" border="0" mm_noconvert="TRUE">
						<TR>
							<TD colSpan="2" height="8">
								<DIV align="center"><SPAN class="style16"><asp:label id="lblNomCliente" runat="server"></asp:label></DIV>
								</SPAN></TD>
						</TR>
						<TR>
							<TD colSpan="2" height="15"></TD>
						</TR>
						<TR>
							<TD class="style12" colSpan="2" height="15"><asp:label id="lblPeriodo" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD colSpan="2" height="11"><asp:datagrid id="dgItinerary" runat="server" ItemStyle-CssClass="Grid" Width="648px" AutoGenerateColumns="False"
									GridLines="None">
									<HeaderStyle CssClass="GridHeader" BackColor="LightGray"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="Dia" HeaderText="FECHA">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FchInicio" HeaderText="FECHA" DataFormatString="{0:ddd dd}">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Ciudad" HeaderText="DESTINO">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" ForeColor="#CC3300" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="HoraServicio" HeaderText="HORA">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Servicio" HeaderText="SERVICIO">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FlagColor" HeaderText="FlagColor">
        									 <ItemStyle CssClass="Hide" />
                                             <HeaderStyle CssClass="Hide" />
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD colSpan="2" height="15">&nbsp;</TD>
						</TR>
						<TR>
							<TD class="style10" colSpan="2" height="1">
								<TABLE height="54" cellSpacing="0" cellPadding="0" width="648" border="0">
									<TR class="style10" bgColor="lightgrey">
										<TD width="359" colSpan="3" height="24">
											<DIV align="center"><STRONG>CARACTERISTICAS ESPECIALES </STRONG>
											</DIV>
										</TD>
										<TD borderColor="#888672" borderColorLight="#888672" borderColorDark="#888672" colSpan="2"
											height="24">
											<DIV align="center"><STRONG>HOTELES SELECCIONADOS </STRONG>
											</DIV>
										</TD>
									</TR>
									<TR class="style10">
										<TD width="359" colSpan="3">
											<DIV align="left"><asp:label id="lblResumen" runat="server"></asp:label></DIV>
										</TD>
										<TD vAlign="top" borderColor="#888672" borderColorLight="#888672" borderColorDark="#888672"
											colSpan="2">&nbsp;
											<asp:label id="lblHotel" runat="server" Width="200px"></asp:label>
											<DIV></DIV>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2" height="1">
								<br>
								<br>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2" height="1" align="center"><SPAN class="style14">
								Fin de nuestros servicios ...<br>
								...Que tenga un buen viaje !!!</SPAN>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
</body>
</html>
