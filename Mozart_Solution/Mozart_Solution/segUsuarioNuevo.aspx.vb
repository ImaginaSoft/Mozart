Imports cmpSeguridad
Imports cmpTabla
Imports System.Data

Partial Class segUsuarioNuevo
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objUsuario As New clsUsuario
    Dim objIdioma As New clsIdioma

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            CargaPerfil(" ")

            If Viewstate("Opcion") = "Nuevo" Then
                lblTitulo.Text = "Nuevo Usuario"
                CargaIdioma("")
            Else
                lblTitulo.Text = "Modifica Usuario"
                txtCodigo.Enabled = False
                Viewstate("CodUsuario") = Request.Params("CodUsuario")
                EditaUsuario()
            End If
        End If
    End Sub

    Private Sub CargaPerfil(ByVal pCodPerfil As String)
        Dim objPerfil As New clsPerfil
        Dim ds As New DataSet
        ds = objPerfil.Cargar
        ddlPerfil.DataSource = ds.Tables(0)
        ddlPerfil.DataBind()
        If pCodPerfil.Trim.Length > 0 Then
            ddlPerfil.Items.FindByValue(pCodPerfil).Selected = True
        End If
    End Sub

    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
        If pIdioma.Trim.Length > 0 Then
            Try
                ddlIdioma.Items.FindByValue(pIdioma).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EditaUsuario()
        objUsuario.CodUsuario = Viewstate("CodUsuario")
        lblMsg.Text = objUsuario.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            txtCodigo.Text = objUsuario.CodUsuario
            txtNombre.Text = objUsuario.NomUsuario

            If objUsuario.StsUsuario = "A" Then
                rbActivo.Checked = True
            Else
                rbInactivo.Checked = True
            End If

            CargaIdioma(objUsuario.TipoIdioma)

            Try
                ddlLog.Items.FindByValue(objUsuario.FlagLogAcceso).Selected = True
            Catch ex As Exception
            End Try

            Try
                ddlVentas.Items.FindByValue(objUsuario.FlagVtaAcceso).Selected = True
            Catch ex As Exception
            End Try

            Try
                ddlEmail.Items.FindByValue(objUsuario.FlagEmailAcceso).Selected = True
            Catch ex As Exception
            End Try


            'If objUsuario.FlagLogAcceso = "P" Then 'log Propio
            '    rbtPropio.Checked = True
            'Else
            '    rbtTodos.Checked = True ' T=log de todos los usuarios
            'End If

            'If objUsuario.FlagVtaAcceso = "P" Then 'Ventas Propio
            '    rbtFlagVtaPropia.Checked = True
            'Else
            '    rbtFlagVtaTodos.Checked = True ' T=Ventas de todos los vendedores
            'End If

            If objUsuario.FlagModoTrabajo = "A" Then 'Ambos
                rbtAmbos.Checked = True
            ElseIf objUsuario.FlagModoTrabajo = "L" Then 'Local
                rbtLocal.Checked = True ' L=Local
            Else
                rbtExterno.Checked = True ' E=Externo
            End If
            txtFchInicial.Text = objUsuario.FchIniTarifa
            CargaPerfil(objUsuario.CodPerfil)
        End If
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlPerfil.Items.Count = 0 Then
            lblMsg.Text = "Perfil es obligatorio"
            Return
        End If
        If rbActivo.Checked Then
            objUsuario.StsUsuario = "A"
        Else
            objUsuario.StsUsuario = "I"
        End If

        objUsuario.TipoIdioma = ddlIdioma.SelectedValue

        'If rbtPropio.Checked Then
        '    objUsuario.FlagLogAcceso = "P"
        'Else
        '    objUsuario.FlagLogAcceso = "T"
        'End If

        'If rbtFlagVtaPropia.Checked Then
        '    objUsuario.FlagVtaAcceso = "P"
        'Else
        '    objUsuario.FlagVtaAcceso = "T"
        'End If

        If rbtAmbos.Checked Then
            objUsuario.FlagModoTrabajo = "A"
        ElseIf rbtLocal.Checked Then
            objUsuario.FlagModoTrabajo = "L"
        Else
            objUsuario.FlagModoTrabajo = "E"
        End If

        objUsuario.FlagLogAcceso = ddlLog.SelectedValue
        objUsuario.FlagVtaAcceso = ddlVentas.SelectedValue
        objUsuario.FlagEmailAcceso = ddlEmail.SelectedValue

        objUsuario.CodUsuario = txtCodigo.Text
        objUsuario.NomUsuario = txtNombre.Text
        objUsuario.CodPerfil = ddlPerfil.SelectedItem.Value
        objUsuario.FchIniTarifa = objRutina.fechayyyymmdd(txtFchInicial.Text)
        objUsuario.CodUsuarioSys = Session("CodUsuario")
        lblMsg.Text = objUsuario.Grabar
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("segUsuarioFicha.aspx" & _
            "?CodUsuario=" & txtCodigo.Text)
        End If
    End Sub
    Private Sub lbtRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegresar.Click
        Response.Redirect("segUsuario.aspx")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtFchInicial.Text = ""
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        txtFchInicial.Text = ""
    End Sub

End Class
