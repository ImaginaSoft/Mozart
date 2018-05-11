Imports cmpTabla
Imports System.Data

Partial Class TabAnoProceso
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objAnoProceso As New clsAnoProceso

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objAnoProceso.Cargar
        dgLista.DataKeyField = "AnoProceso"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count()) + " Año(s) encontrado(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objAnoProceso.AnoProceso = txtAnoProceso.Text
        objAnoProceso.StsAnoProceso = ddlEstado.SelectedValue
        objAnoProceso.StsConsulta = ddlconsulta.SelectedValue
        lblMsg.Text = objAnoProceso.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        txtAnoProceso.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text.Trim

        'estado
        Try
            ddlEstado.ClearSelection()
            ddlEstado.Items.FindByValue(dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim).Selected = True
        Catch ex As Exception
        End Try

        'consulta
        Try
            ddlConsulta.ClearSelection()
            ddlConsulta.Items.FindByValue(dgLista.Items(dgLista.SelectedIndex).Cells(4).Text.Trim).Selected = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        objAnoProceso.AnoProceso = dgLista.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objAnoProceso.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

End Class
