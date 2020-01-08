Imports cmpNegocio
Imports cmpTabla
Imports cmpSeguridad

Partial Class VtaServicioCopia
    Inherits System.Web.UI.Page
    Dim objServicio As New clsServicio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT030505") = "X" Then
                cmbGrabar.Visible = True
            End If

            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodCiudad") = Request.Params("CodCiudad")
            Viewstate("CodTipoServicio") = Request.Params("CodTipoServicio")
            lblDesProveedor.Text = Request.Params("DesProveedor")
            Viewstate("NroServicio") = Request.Params("NroServicio")
            lblTitulo.Text = "Crear Servicio a partir de Nro. " & CStr(Viewstate("NroServicio"))

            CargaProveedor()
            CargaCiudad()
            CargaTipoServicio()
        End If
    End Sub

    Private Sub CargaProveedor()
        Dim objProveedor As New clsProveedor
        ddlProveedor.DataSource = objProveedor.CargarActivoDDL
        ddlProveedor.DataBind()
        Try
            ddlProveedor.Items.FindByValue(Viewstate("CodProveedor")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaCiudad()
        Dim objCiudad As New clsCiudad
        ddlCiudad.DataSource = objCiudad.CargarActivo
        ddlCiudad.DataBind()
        Try
            ddlCiudad.Items.FindByValue(Viewstate("CodCiudad")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaTipoServicio()
        Dim objTipoServicio As New clsTipoServicio
        ddlTipoServicio.DataSource = objTipoServicio.CargarActivo
        ddlTipoServicio.DataBind()
        Try
            ddlTipoServicio.Items.FindByValue(Viewstate("CodTipoServicio")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        objServicio.NroServicio = Viewstate("NroServicio")
        objServicio.CodProveedor = ddlProveedor.SelectedItem.Value
        objServicio.CodCiudad = ddlCiudad.SelectedItem.Value
        objServicio.CodTipoServicio = ddlTipoServicio.SelectedItem.Value
        objServicio.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objServicio.Copiar
        If Mid(lblMsg.Text.Trim, 1, 2) = "OK" Then
            Response.Redirect("VtaServicioBusca.aspx" & _
                "?Opcion=" & "NuevoServicio" & _
                "&NroServicio=" & Mid(lblMsg.Text.Trim, 3, 10) & _
                "&CodProveedor=" & ddlProveedor.SelectedItem.Value & _
                "&CodCiudad=" & ddlCiudad.SelectedItem.Value & _
                "&CodTipoServicio=" & ddltiposervicio.SelectedItem.Value)
        End If
    End Sub


End Class
