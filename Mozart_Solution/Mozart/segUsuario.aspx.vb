Imports cmpSeguridad
Imports System.Data
Imports System.Drawing

Partial Class segUsuario
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim ObjUsuario As New clsUsuario


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = ObjUsuario.Cargar
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTabla.DataSource = dv
        dgTabla.DataBind()
        lblMsg.Text = CStr(dgTabla.Items.Count) & " registro(s)"
    End Sub

    Protected Sub dgTabla_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTabla.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(3).Text.Trim = "I" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If

    End Sub
    Private Sub dgTabla_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTabla.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub lbtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevo.Click
        Response.Redirect("SegUsuarioNuevo.aspx" & _
                                          "?Opcion=" & "Nuevo")
    End Sub

    Private Sub dgTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla.SelectedIndexChanged
        Response.Redirect("SegUsuarioFicha.aspx" & _
                    "?CodUsuario=" & dgTabla.Items(dgTabla.SelectedIndex).Cells(1).Text)
    End Sub
End Class
