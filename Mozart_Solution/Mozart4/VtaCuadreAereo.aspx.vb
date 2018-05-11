Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Class VtaCuadreAereo
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-30)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaPedidos()
    End Sub

    Private Sub CargaPedidos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wtipodoc As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_CuadreAereo_S"
        da.SelectCommand.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta1.CodZonaVta
        da.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)

        Dim nReg As Integer = da.Fill(ds, "Movtos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgVersiones.DataKeyField = "KeyReg"
        dgVersiones.DataSource = dv
        dgVersiones.DataBind()

        lblmsg.Text = CStr(nReg) + " Version(es)"
    End Sub


    Private Sub dgVersiones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgVersiones.SelectedIndexChanged
        Session("CodCliente") = dgVersiones.Items(dgVersiones.SelectedIndex).Cells(11).Text

        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(1).Text & _
        "&NroPropuesta=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(10).Text & _
        "&NroVersion=" & dgVersiones.Items(dgVersiones.SelectedIndex).Cells(2).Text)
    End Sub

    Private Sub dgVersiones_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVersiones.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(7).Text = e.Item.Cells(8).Text Then
                e.Item.ForeColor = Color.Gray
            ElseIf e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgVersiones_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVersiones.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Private Sub dgVersiones_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVersiones.EditCommand
        Response.Redirect("VtaCuadreAereoDet.aspx" & _
            "?NroPedido=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 11, 10) & _
            "&NroPropuesta=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 21, 2) & _
            "&NroVersion=" & Mid(dgVersiones.DataKeys(e.Item.ItemIndex), 23, 2))
    End Sub

End Class
