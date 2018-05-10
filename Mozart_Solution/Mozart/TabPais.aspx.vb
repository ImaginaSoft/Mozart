Imports cmpTabla
Imports System.Data
Partial Class TabPais
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objPais As New clsPais

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
        ds = objPais.Cargar
        dgPais.DataKeyField = "CodPais"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPais.DataSource = dv
        dgPais.DataBind()
        lblMsg.Text = CStr(dgPais.Items.Count) + " Paises"
    End Sub

    Private Sub dgPais_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPais.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub


    Private Sub dgPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPais.SelectedIndexChanged
        Response.Redirect("tabPaisNuevo.aspx" & _
                     "?CodPais=" & dgPais.Items(dgPais.SelectedIndex).Cells(1).Text.Trim & _
                     "&Opcion=" & "Modifica")
    End Sub

    Private Sub dgPais_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPais.DeleteCommand
        objPais.CodPais = dgPais.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objPais.Borrar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub lblNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNuevo.Click
        Response.Redirect("tabPaisNuevo.aspx" & _
                 "?Opcion=" & "Nuevo")
    End Sub

End Class
