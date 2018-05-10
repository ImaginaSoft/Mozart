Imports cmpTabla
Imports System.Data
Partial Class tabIGVxTipoServicio
    Inherits System.Web.UI.Page
    Dim objTipoServicioIGV As New clsTipoServicioIGV
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            rbPeru.Checked = True
            rbSi.Checked = True
            CargaTipoServicio(0)
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTipoServicioIGV.Cargar
        dgDtiposervicio.DataKeyField = "KeyReg"
        dgDtiposervicio.DataSource = ds
        dgDtiposervicio.DataBind()
        lblMsg.Text = CStr(dgDtiposervicio.Items.Count) + " Registro(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objTipoServicioIGV.CodTipoServicio = ddltiposervicio.SelectedItem.Value
        If rbPeru.Checked Then
            objTipoServicioIGV.TipoPersona = "P"
        Else
            objTipoServicioIGV.TipoPersona = "E"
        End If

        If rbSi.Checked Then
            objTipoServicioIGV.FlagIGV = "S"
        Else
            objTipoServicioIGV.FlagIGV = "N"
        End If
        lblMsg.Text = objTipoServicioIGV.Grabar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgDtiposervicio_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDtiposervicio.DeleteCommand
        objTipoServicioIGV.CodTipoServicio = Mid(dgDtiposervicio.DataKeys(e.Item.ItemIndex), 1, 2)
        objTipoServicioIGV.TipoPersona = Mid(dgDtiposervicio.DataKeys(e.Item.ItemIndex), 3, 1)
        lblMsg.Text = objTipoServicioIGV.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub rbPeru_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeru.CheckedChanged
        rbExt.Checked = False
        rbPeru.Checked = True
    End Sub

    Private Sub rbExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbExt.CheckedChanged
        rbPeru.Checked = False
        rbExt.Checked = True
    End Sub

    Private Sub rbSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSi.CheckedChanged
        rbNo.Checked = False
        rbSi.Checked = True
    End Sub

    Private Sub rbNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNo.CheckedChanged
        rbSi.Checked = False
        rbNo.Checked = True
    End Sub

    Private Sub dgDtiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDtiposervicio.SelectedIndexChanged
        CargaTipoServicio(dgDtiposervicio.Items(dgDtiposervicio.SelectedIndex).Cells(6).Text.Trim)

        If dgDtiposervicio.Items(dgDtiposervicio.SelectedIndex).Cells(2).Text.Trim = "Peruano" Then
            rbExt.Checked = False
            rbPeru.Checked = True
        Else
            rbPeru.Checked = False
            rbExt.Checked = True
        End If
        If dgDtiposervicio.Items(dgDtiposervicio.SelectedIndex).Cells(3).Text.Trim = "Sí" Then
            rbSi.Checked = True
            rbNo.Checked = False
        Else
            rbSi.Checked = False
            rbNo.Checked = True
        End If
    End Sub

    Private Sub CargaTipoServicio(ByVal pCodTServicio As Integer)
        Dim objTipoServicio As New clsTipoServicio
        Dim ds As New DataSet
        ds = objTipoServicio.CargarActivo
        ddltiposervicio.DataSource = ds
        ddltiposervicio.DataBind()
        If pCodTServicio > 0 Then
            ddltiposervicio.Items.FindByValue(pCodTServicio).Selected = True
        End If
    End Sub


End Class
