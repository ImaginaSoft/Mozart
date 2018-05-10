Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpNegocio

Partial Class cpcClienteContacto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objContacto As New clsClienteContacto
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NomCliente") = Request.Params("NomCliente")
            lblTitulo.Text = "Contactos - " & Viewstate("NomCliente")
            rbActivo.Checked = True
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objContacto.Cargar(Viewstate("CodCliente"))
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataKeyField = "KeyReg"
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count) + " Contacto(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objContacto.StsContacto = "A"
        Else
            objContacto.StsContacto = "I"
        End If
        If CheckBoxFlagExperto.Checked Then
            objContacto.FlagExperto = "S"
        Else
            objContacto.FlagExperto = ""
        End If

        objContacto.CodCliente = Viewstate("CodCliente")
        objContacto.CodContacto = txtCodigo.Text
        objContacto.NomContacto = txtNombre.Text
        objContacto.EmailContacto = txtEmail.Text
        objContacto.Telefono1 = txtTelefono.Text
        objContacto.NroOrden = txtNroOrden.Text
        objContacto.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objContacto.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        txtCodigo.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text
        txtNombre.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text
        txtEmail.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text
        txtTelefono.Text = dgLista.Items(dgLista.SelectedIndex).Cells(5).Text

        txtNroOrden.Text = dgLista.Items(dgLista.SelectedIndex).Cells(7).Text
        If dgLista.Items(dgLista.SelectedIndex).Cells(8).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
        If dgLista.Items(dgLista.SelectedIndex).Cells(6).Text.Trim = "SI" Then
            CheckBoxFlagExperto.Checked = True
        Else
            CheckBoxFlagExperto.Checked = False
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objContacto.Borrar(Viewstate("CodCliente"), Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 15))
        If Trim(lblMsg.Text) = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgLista_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.CancelCommand
        Response.Redirect("cpcClienteContactoClave.aspx" & _
                  "?CodCliente=" & Viewstate("CodCliente") & _
                  "&NomCliente=" & Viewstate("NomCliente") & _
                  "&CodContacto=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 15) & _
                  "&NomContacto=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 16, 50))
    End Sub

    Private Sub dgLista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

End Class
