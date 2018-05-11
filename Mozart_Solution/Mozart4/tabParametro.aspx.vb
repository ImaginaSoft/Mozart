Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class tabParametro
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaLista()
        End If
    End Sub
    Private Sub CargaLista()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_ControlLista_S")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count) + " Parametros(s)"
    End Sub
    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Response.Redirect("tabParametroDetalle.aspx" & _
                   "?DescCampo=" & dgLista.Items(dgLista.SelectedIndex).Cells(1).Text & _
                   "&ValorCampo=" & dgLista.Items(dgLista.SelectedIndex).Cells(2).Text & _
                   "&NomCampo=" & dgLista.Items(dgLista.SelectedIndex).Cells(7).Text)

        '           "&TextoCampo=" & dgLista.Items(dgLista.SelectedIndex).Cells(3).Text & _

    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text = "A" Then
                e.Item.Cells(0).Text = ""
            Else
                e.Item.ForeColor = Color.DarkBlue
            End If
        End If
    End Sub

End Class
