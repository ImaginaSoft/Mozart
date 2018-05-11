<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VtaVersion.aspx.vb" Inherits="VtaVersion" %>

<%@ Register src="ucPropuesta.ascx" tagname="ucPropuesta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 653px; POSITION: absolute; TOP: 8px; HEIGHT: 70px"
				cellSpacing="1" cellPadding="1" width="653" border="0">
				<TR>
					<TD>
						<TABLE id="Table4" style="WIDTH: 651px; HEIGHT: 21px" cellSpacing="0" cellPadding="1" width="651"
							border="0">
							<TR>
								<TD>
									<P class="Titulo">&nbsp;Versiones de la Propuesta</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucPropuesta ID="ucPropuesta1" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblMsg" runat="server" Width="549px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgVersion" runat="server" BorderStyle="None" AutoGenerateColumns="False" CssClass="Grid"
							BorderColor="CadetBlue" Width="648px" Height="17px" BorderWidth="1px" CellPadding="3">
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="GridAlterna"></AlternatingItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Editar" HeaderText="Versi&#243;n" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="NroVersion" SortExpression="NroPropuesta" HeaderText="Nro"></asp:BoundColumn>
								<asp:BoundColumn DataField="DesVersion" SortExpression="DesPropuesta" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="FchVersion" SortExpression="FchPropuesta" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="StsVersion" SortExpression="StsPropuesta" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
								<asp:BoundColumn DataField="CantAdultos" HeaderText="CantAdultos">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAdultos" HeaderText="CantNinos">
    									 <ItemStyle CssClass="Hide" />
                                         <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
