Imports cmpSeguridad
Imports System.Data

Partial Class SegPerfil
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim objPerfil As New clsPerfil

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
        ds = objPerfil.Cargar
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTabla.DataSource = dv
        dgTabla.DataBind()
    End Sub

    Private Sub dgTabla_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTabla.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub dgTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTabla.SelectedIndexChanged
        Response.Redirect("segPerfilFicha.aspx" & _
            "?CodPerfil=" & dgTabla.Items(dgTabla.SelectedIndex).Cells(1).Text)
    End Sub

    Private Sub lbtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevo.Click
        Response.Redirect("segPerfilNuevo.aspx?Opcion=Nuevo")
    End Sub


End Class
