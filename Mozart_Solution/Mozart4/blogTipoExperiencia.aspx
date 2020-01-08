<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogTipoExperiencia.aspx.vb" Inherits="blogTipoExperiencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="form" id="Table1" style="Z-INDEX: 100; LEFT: 8px; WIDTH: 530px; POSITION: absolute; TOP: 8px; HEIGHT: 264px"
				cellSpacing="0" cellPadding="0" width="530" border="0">
				<TR>
					<TD>
						<P class="Titulo">
							Tabla Tipos de Experiencia</P>
					</TD>
				</TR>
				<TR>
					<TD class="opciones" style="HEIGHT: 15px">&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table3" style="WIDTH: 528px; HEIGHT: 60px" borderColor="#cccccc"
							cellSpacing="0" cellPadding="0" width="528" border="1">
							<TR>
								<TD style="WIDTH: 49px" bgColor="#f5f5f5">&nbsp;Código</TD>
								<TD bgColor="#f5f5f5">
									<asp:textbox id="txtCodTipoExp" runat="server" Width="61px" MaxLength="5"></asp:textbox>&nbsp;(dato 
									en blanco adiciona registro)</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 49px" bgColor="#f5f5f5">&nbsp;Nombre
								</TD>
								<TD style="WIDTH: 207px" bgColor="#f5f5f5">
									<asp:textbox id="txtNomTipoExp" runat="server" Width="448px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 49px; HEIGHT: 21px">&nbsp;Idioma</TD>
								<TD style="WIDTH: 207px; HEIGHT: 21px">
									<asp:RadioButton id="rbtInglesEdit" runat="server" Text="Ingles" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="rbtEspanolEdita" runat="server" Text="Español" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 49px"></TD>
								<TD style="WIDTH: 207px">
									<asp:Button id="btnGrabar" runat="server" Text="Grabar"></asp:Button></TD>
							</TR>
						</TABLE>
						<asp:label id="lblerror" runat="server" Width="424px" Height="17px" CssClass="msg" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tabla" id="Table2" style="WIDTH: 232px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
							width="232" border="1">
							<TR>
								<TD style="WIDTH: 82px"><FONT size="2">&nbsp;Lista idioma</FONT></TD>
								<TD>
									<asp:RadioButton id="rbtIngles" runat="server" Text="Ingles" GroupName="g1" Checked="True" AutoPostBack="True"></asp:RadioButton>&nbsp;
									<asp:RadioButton id="rbtEspanol" runat="server" Text="Español" GroupName="g1" AutoPostBack="True"></asp:RadioButton>&nbsp;</TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px"><asp:label id="lblMsg" runat="server" Height="17px" Width="512px" CssClass="msg"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgTipoExp" runat="server" Height="17px" Width="528px" CssClass="Grid" AllowSorting="True"
							AutoGenerateColumns="False" BorderColor="CadetBlue" BorderWidth="1px" CellPadding="2" >
							<SelectedItemStyle CssClass="GridSelect"></SelectedItemStyle>
							<ItemStyle CssClass="GridData"></ItemStyle>
							<HeaderStyle CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Elegir" CommandName="select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CodTipoExp" SortExpression="CodTipoExp" HeaderText="C&#243;digo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomTipoExp" SortExpression="NomTipoExp" HeaderText="Nombre">
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RankingExp" SortExpression="RankingExp" HeaderText="Ranking">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Eliminar" CommandName="delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="FlagIdioma" HeaderText="FlagIdioma">
									 <ItemStyle CssClass="Hide" />
                                     <HeaderStyle CssClass="Hide" />
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
