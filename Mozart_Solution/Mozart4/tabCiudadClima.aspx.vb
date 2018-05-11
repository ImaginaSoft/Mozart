Imports cmpTabla
Imports System.Data

Partial Class tabCiudadClima
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objCiudad As New clsCiudad
    Dim objCiudadClima As New clsCiudadClima

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCiudad") = Request.Params("CodCiudad")
            lblTitulo.Text = "Clima - "

            lblMsg.Text = objCiudad.Editar(Viewstate("CodCiudad"))
            If lblMsg.Text.Trim = "OK" Then
                lblTitulo.Text = lblTitulo.Text & " " & objCiudad.NomCiudad
            End If
            CargaDatos()

        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objCiudadClima.Cargar(Viewstate("CodCiudad"))
        dglista.DataKeyField = "NroMes"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objCiudadClima.CodCiudad = Viewstate("CodCiudad")
        objCiudadClima.NroMes = txtNroMes.Text
        objCiudadClima.TempMinima = txtTempMinima.Text
        objCiudadClima.TempMaxima = txtTempMaxima.Text
        objCiudadClima.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objCiudadClima.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        lblMsg.Text = objCiudadClima.Borrar(Viewstate("CodCiudad"), dglista.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dglista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dglista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub dglista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtNroMes.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtTempMinima.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim
        txtTempMaxima.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim
    End Sub


End Class
