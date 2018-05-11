<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vtaVersionPrintIn.aspx.vb" Inherits="vtaVersionPrintIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="StylesPeru4me.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body ms_positioning="GridLayout">
		<TABLE height="271" cellSpacing="0" cellPadding="0" width="650" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="1" height="15"></TD>
				<TD width="649"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="256"></TD>
				<TD>
					<table cellSpacing="0" cellPadding="0" width="648" border="0" mm_noconvert="TRUE" height="255">
						<TR>
							<TD class="style16" align="center" colSpan="2" height="15">
								<asp:label id="lblNomCliente" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD align="left" colSpan="2" height="15">&nbsp;</TD>
						</TR>
						<TR>
							<TD class="style12" colSpan="2" height="15">
								<asp:label id="lblPeriodo" runat="server"></asp:label></TD>
						<TR>
							<TD class="style10" colSpan="2" height="15">
								<asp:datagrid id="dgItinerary" runat="server" Width="648px" ItemStyle-CssClass="Grid" AutoGenerateColumns="False"
									GridLines="None">
									<HeaderStyle CssClass="GridHeader" BackColor="LightGray"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="Dia" HeaderText="DATE">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FchInicio" HeaderText="DATE" DataFormatString="{0:ddd dd}">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Ciudad" HeaderText="DESTINATION">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" ForeColor="#CC3300" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="HoraServicio" HeaderText="TIME">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Servicio" HeaderText="SERVICE">
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
							<TD colSpan="2" height="15">
								<P align="left">&nbsp;&nbsp;</P>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" colSpan="2" height="2">
								<TABLE cellSpacing="0" cellPadding="0" width="648" border="0" height="57">
									<TR class="style10" bgcolor="lightgrey">
										<TD width="359" colSpan="3" height="15"><DIV align="center"><STRONG>SPECIAL FEATURES </STRONG>
											</DIV>
										</TD>
										<TD borderColor="#888672" borderColorLight="#888672" borderColorDark="#888672" colSpan="2"
											height="15">
											<DIV align="center"><STRONG>SELECTED HOTELS </STRONG>
											</DIV>
										</TD>
									</TR>
									<TR class="style10">
										<TD width="359" colSpan="3">
											<DIV align="left" vAlign="top">
												<asp:label id="lblResumen" runat="server"></asp:label></DIV>
										</TD>
										<TD vAlign="top" align="left" borderColor="#888672" borderColorLight="#888672" borderColorDark="#888672"
											colSpan="2">&nbsp;&nbsp;
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
							<TD align="center" colSpan="2" height="2"><SPAN class="style14">End of our 
            services...<BR>...Have a nice trip !!!</SPAN>
							</TD>
						</TR>
					</table>
				</TD>
			</TR>
		</TABLE>

</body>
</html>
