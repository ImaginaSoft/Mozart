Imports cmpTabla
Imports System.Data

Partial Class VtaServicioInf
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objTipoInformacion As New clsTipoInformacion
    Dim objInformacion As New clsInformacion
    Dim objServicioInf As New clsServicioInf

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroServicio") = Request.Params("NroServicio")
            lblTitulo.Text = "Información - N° " & Viewstate("NroServicio") & " " & Viewstate("DesProveedor")

            CargaTipoInformacion()
            CargaInformacion()
            CargaDatos()

        End If
    End Sub

    Private Sub CargaTipoInformacion()
        Dim ds As New DataSet
        ds = objTipoInformacion.Cargar()
        ddlTipoInformacion.DataSource = ds
        ddlTipoInformacion.DataBind()
    End Sub

    Private Sub CargaInformacion()
        Dim sNivelInf As String = ""
        If rbZonaVta.Checked Then
            sNivelInf = "Z"
        ElseIf rbCiudad.Checked Then
            sNivelInf = "C"
        Else
            sNivelInf = "S"
        End If
        Dim ds As New DataSet
        ds = objInformacion.CargarxNivelInf(ddlTipoInformacion.SelectedItem.Value, sNivelInf)
        ddlInformacion.DataSource = ds
        ddlInformacion.DataBind()
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objInformacion.CargarxServicio(Viewstate("NroServicio"))
        dglista.DataKeyField = "NroInformacion"
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
        If ddlInformacion.Items.Count = 0 Then
            lblMsg.Text = "Falta seleccionar información"
            Return
        End If
        objServicioInf.NroServicio = Viewstate("NroServicio")
        objServicioInf.NroInformacion = ddlInformacion.SelectedItem.Value
        objServicioInf.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objServicioInf.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        lblMsg.Text = objServicioInf.Borrar(Viewstate("NroServicio"), dglista.DataKeys(e.Item.ItemIndex))
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

    Private Sub ddlTipoInformacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoInformacion.SelectedIndexChanged
        CargaInformacion()
    End Sub

    Private Sub rbZonaVta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbZonaVta.CheckedChanged
        CargaInformacion()
    End Sub

    Private Sub rbCiudad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCiudad.CheckedChanged
        CargaInformacion()
    End Sub

    Private Sub rbServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbServicio.CheckedChanged
        CargaInformacion()
    End Sub

End Class
