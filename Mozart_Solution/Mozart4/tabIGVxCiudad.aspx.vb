Imports cmpTabla
Imports System.Data

Partial Class tabIGVxCiudad
    Inherits System.Web.UI.Page
    Dim objCiudadIGV As New clsCiudadIGV

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            rbSi.Checked = True
            CargaTipoServicio("")
            CargaCiudad("")
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objCiudadIGV.Cargar()
        dgDCiudad.DataKeyField = "KeyReg"
        dgDCiudad.DataSource = ds
        dgDCiudad.DataBind()
        lblMsg.Text = CStr(dgDCiudad.Items.Count) + " Registro(s)"
    End Sub

    Private Sub rbSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSi.CheckedChanged
        rbNo.Checked = False
        rbSi.Checked = True
    End Sub

    Private Sub rbNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNo.CheckedChanged
        rbSi.Checked = False
        rbNo.Checked = True
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wresp As String
        If rbSi.Checked Then
            wresp = "S"
        Else
            wresp = "N"
        End If
        objCiudadIGV.CodCiudad = ddlCiudad.SelectedItem.Value
        objCiudadIGV.CodTipoServicio = ddltiposervicio.SelectedItem.Value
        objCiudadIGV.FlagIGV = wresp
        lblMsg.Text = objCiudadIGV.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgDCiudad_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDCiudad.DeleteCommand
        objCiudadIGV.CodCiudad = Mid(dgDCiudad.DataKeys(e.Item.ItemIndex), 1, 10)
        objCiudadIGV.CodTipoServicio = Mid(dgDCiudad.DataKeys(e.Item.ItemIndex), 11, 2)
        lblMsg.Text = objCiudadIGV.Borrar()
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgDCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDCiudad.SelectedIndexChanged
        Dim wCodCiudad As String
        Dim valor As Integer

        wCodCiudad = CStr(dgDCiudad.Items(dgDCiudad.SelectedIndex).Cells(7).Text)
        valor = CInt(dgDCiudad.Items(dgDCiudad.SelectedIndex).Cells(6).Text)
        CargaTipoServicio(valor)
        CargaCiudad(wCodCiudad)

        If dgDCiudad.Items(dgDCiudad.SelectedIndex).Cells(3).Text.Trim = "Sí" Then
            rbSi.Checked = True
            rbNo.Checked = False
        Else
            rbSi.Checked = False
            rbNo.Checked = True
        End If
    End Sub

    Private Sub CargaTipoServicio(ByVal pCodTServicio As String)
        Dim objTipoServicio As New clsTipoServicio
        Dim ds As New DataSet
        ds = objtiposervicio.Cargar
        ddltiposervicio.DataSource = ds
        ddltiposervicio.DataBind()
        If pCodTServicio.Trim.Length > 0 Then
            ddltiposervicio.Items.FindByValue(pCodTServicio).Selected = True
        End If
    End Sub

    Private Sub CargaCiudad(ByVal pCodCiudad As String)
        Dim objCiudad As New clsCiudad
        Dim ds As New DataSet
        ds = objCiudad.CargarActivo
        ddlCiudad.DataSource = ds
        ddlCiudad.DataBind()
        If pCodCiudad.Trim.Length > 0 Then
            ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
        End If
    End Sub


End Class
