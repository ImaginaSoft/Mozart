Imports cmpNegocio
Imports cmpTabla
Imports cmpRutinas
Imports cmpSeguridad
Imports System.Data
Imports System.Drawing

Partial Class VtaServicioBusca
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim wCodProveedor As Integer
    Dim wCodCiudad As String
    Dim wCodTipoServicio As Integer
    Dim wEstado As String
    Dim wEstado2 As String

    Dim objRutina As New clsRutinas
    Dim objServicio As New clsServicio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT030505") <> "OK" Then
                lbtNuevoServicio.Visible = False
                dgServicio.Columns(8).Visible = False
            End If

            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("NroServicio") = Request.Params("NroServicio")

            If Viewstate("Opcion") = "NuevoServicio" Or Viewstate("Opcion") = "Lista" Then

                Viewstate("CodProveedor") = Request.Params("CodProveedor")
                Viewstate("CodCiudad") = Request.Params("CodCiudad")
                Viewstate("CodTipoServicio") = Request.Params("CodTipoServicio")

                CargaProveedorS(Viewstate("CodProveedor"))
                CargaCiudad(Viewstate("CodCiudad"))
                CargaTipoServicio(Viewstate("CodTipoServicio"))

                If Viewstate("Opcion") = "NuevoServicio" Then
                    lblBoton.Text = "B"
                    txtNroServicio.Text = Viewstate("NroServicio")
                Else
                    lblBoton.Text = "A"
                    lblStsServicio.Text = "A"
                End If
                CargaServicio()
            Else
                Dim wCodProveedor As Integer = objRutina.LeeParametroNumero("DefaultCodProveedor")

                CargaProveedorS(wCodProveedor)
                CargaCiudad(" ")
                CargaTipoServicio(0)
            End If
        End If
    End Sub

    Private Sub CargaProveedorS(ByVal pCodProveedor As Integer)
        Dim objProveedor As New clsProveedor
        ddlProveedor.DataSource = objProveedor.CargaProveedores
        ddlProveedor.DataBind()
        If pCodProveedor > 0 Then
            Try
                ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
            Catch ex As Exception
                'No existe proveedor..continuar
            End Try
        End If

        ddlProveedor2.DataSource = objProveedor.CargaProveedores
        ddlProveedor2.DataBind()
        ddlProveedor2.Items.Insert(0, New ListItem("Todos"))
        ddlProveedor2.Items.FindByValue("Todos").Selected = True
    End Sub

    Private Sub CargaCiudad(ByVal pCodCiudad As String)
        Dim objCiudad As New clsCiudad
        Dim ds As New DataSet
        If ddlProveedor.Items.Count > 0 Then
            ds = objCiudad.CargaCiudad(ddlProveedor.SelectedItem.Value)
        Else
            ds = objCiudad.CargaCiudad(0)
        End If
        ddlCiudad.DataSource = ds
        ddlCiudad.DataBind()
        If pCodCiudad.Trim.Length > 0 Then
            Try
                ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
            Catch ex As Exception
                'No existe ciudad..continuar
            End Try
        End If
    End Sub

    Private Sub CargaTipoServicio(ByVal pCodTipoServicio As Integer)
        Dim wCodProveedor As Integer = 0
        Dim wCodCiudad As String = " "
        If ddlProveedor.Items.Count > 0 Then
            wCodProveedor = ddlProveedor.SelectedItem.Value
        End If
        If ddlCiudad.Items.Count > 0 Then
            wCodCiudad = ddlCiudad.SelectedItem.Value
        End If

        Dim objTipoServicio As New clsTipoServicio
        ddltiposervicio.DataSource = objTipoServicio.CargaTiposServicio(wCodProveedor, wCodCiudad)
        ddltiposervicio.DataBind()
        If pCodTipoServicio > 0 Then
            Try
                ddltiposervicio.Items.FindByValue(pCodTipoServicio).Selected = True
            Catch ex As Exception
                'No existe tipo servicio...continuar
            End Try
        End If
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblStsServicio.Text = "A"
        lblBoton.Text = "A"
        CargaServicio()
    End Sub

    Private Sub CargaServicio()
        If lblBoton.Text = "B" And txtNroServicio.Text.Trim.Length < 3 Then
            lblMsg.Text = "Ingrese el N° o Descripción del Servicio, para buscar por descripción ingrese por lo menos 3 caracteres."
            Return
        End If

        Dim ds As New DataSet
        If lblBoton.Text = "A" Or lblBoton.Text = "I" Then
            AsignaCodigo()
            ds = objServicio.CargaServicios(wCodProveedor, wCodCiudad, wCodTipoServicio, wEstado)
            'ds = objServicio.CargaServicios(wCodProveedor, wCodCiudad, wCodTipoServicio, lblStsServicio.Text)
        ElseIf lblBoton.Text = "B" And IsNumeric(txtNroServicio.Text) Then
            AsignaCodigo()
            ds = objServicio.CargaNroServicio(txtNroServicio.Text, wEstado2)
        ElseIf lblBoton.Text = "B" And txtNroServicio.Text.Trim.Length >= 3 And ddlProveedor2.SelectedItem.Value = "Todos" Then
            AsignaCodigo()
            ds = objServicio.CargaxDesServicio(txtNroServicio.Text, wEstado2)
        ElseIf lblBoton.Text = "B" And txtNroServicio.Text.Trim.Length >= 3 And ddlProveedor2.SelectedItem.Value <> "Todos" Then
            ds = objServicio.CargaxDesServicio(txtNroServicio.Text, ddlProveedor2.SelectedItem.Value)
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgServicio.DataKeyField = "NroServicio"
        dgServicio.DataSource = dv
        dgServicio.DataBind()
        lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
    End Sub

    Private Sub dgServicio_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgServicio.EditCommand
        'MODIFICA SERVICIO
        Response.Redirect("VtaServicioNuevo.aspx" & _
                           "?Opcion=" & "Modificar" & _
                           "&NroServicio=" & dgServicio.DataKeys(e.Item.ItemIndex) & _
                            "&CodProveedor=" & ddlProveedor.SelectedItem.Value & _
                            "&CodCiudad=" & ddlCiudad.SelectedItem.Value & _
                            "&CodTipoServicio=" & ddltiposervicio.SelectedItem.Value)
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        'TARIFAS
        Response.Redirect("VtaServicioTarifa.aspx" & _
                    "?NroServicio=" & dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text & _
                    "&OpcionLink=S")
    End Sub

    Private Sub dgServicio_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgServicio.CancelCommand
        Response.Redirect("VtaServicioLink.aspx" & _
                    "?NroServicio=" & dgServicio.DataKeys(e.Item.ItemIndex))
    End Sub

    Private Sub dgServicio_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgServicio.DeleteCommand
        lblMsg.Text = objServicio.Borrar(dgServicio.DataKeys(e.Item.ItemIndex))
        If lblMsg.Text.Trim = "OK" Then
            CargaServicio()
        End If
    End Sub

    Private Sub lbtNuevoServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoServicio.Click
        AsignaCodigo()
        Response.Redirect("VtaServicioNuevo.aspx" & _
            "?Opcion=" & "Nuevo" & _
            "&CodProveedor=" & wCodProveedor & _
            "&CodCiudad=" & wCodCiudad & _
            "&CodTipoServicio=" & wCodTipoServicio)
    End Sub

    Private Sub AsignaCodigo()
        wCodProveedor = 0
        wCodCiudad = ""
        wCodTipoServicio = 0
        wEstado = ""
        wEstado2 = ""

        If ddlProveedor.Items.Count > 0 Then
            wCodProveedor = ddlProveedor.SelectedItem.Value
        End If
        If ddlCiudad.Items.Count() > 0 Then
            wCodCiudad = ddlCiudad.SelectedItem.Value
        End If
        If ddltiposervicio.Items.Count() > 0 Then
            wCodTipoServicio = ddltiposervicio.SelectedItem.Value
        End If
        If ddlEstado2.Items.Count() > 0 Then
            wEstado2 = ddlEstado2.SelectedItem.Value
        End If
        If ddlEstados.Items.Count() > 0 Then
            wEstado = ddlEstados.SelectedItem.Value
        End If
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            If Trim(e.Item.Cells(7).Text) = "Inactivo" Then
                e.Item.ForeColor = Color.Red
            End If

            If e.Item.Cells(20).Text > 0 Then
                e.Item.Cells(3).BackColor = Color.PaleGreen
            End If
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaCiudad(" ")
        CargaTipoServicio(0)
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio(0)
    End Sub

    Private Sub dgServicio_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgServicio.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaServicio()
    End Sub

    Private Sub cmdInactivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInactivos.Click
        lblStsServicio.Text = "I"
        lblBoton.Text = "I"
        CargaServicio()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        lblBoton.Text = "B"
        CargaServicio()
    End Sub


    Private Sub cmbBuscaServ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBuscaServ.Click
        If ddlEstados.SelectedValue = "A" Then
            lblStsServicio.Text = "A"
            lblBoton.Text = "A"

        Else
            lblStsServicio.Text = "I"
            lblBoton.Text = "I"
        End If

        CargaServicio()
    End Sub
End Class
