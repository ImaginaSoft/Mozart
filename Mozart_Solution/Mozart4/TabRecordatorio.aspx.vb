Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class TabRecordatorio
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim objRecordatorio As New clsRecordatorio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaZonaVta("")
            CargaDatos()
        End If
    End Sub

    Private Sub CargaZonaVta(ByVal pCodZonVta As String)
        Dim objZonaVta As New clsZonaVta
        Dim ds As New DataSet
        ds = objZonaVta.CargarActivo()
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()
        Try
            ddlZonaVta.Items.FindByValue(pCodZonVta).Selected = True
        Catch ex As Exception
        End Try

        ddlListaZonaVta.DataSource = ds
        ddlListaZonaVta.DataBind()
    End Sub

    Private Sub CargaDatos()
        Dim sIdioma As String
        If rbtListaIng.Checked Then
            sIdioma = "I"
        Else
            sIdioma = "E"
        End If
        Dim ds As New DataSet
        ds = objRecordatorio.CargaxZonaVtaIdioma(ddlListaZonaVta.SelectedItem.Value, sIdioma)
        dgLista.DataKeyField = "KeyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count) + " Recordatorio(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlZonaVta.Items.Count = 0 Then
            lblMsg.Text = "Zona Venta es dato obligatorio"
            Return
        End If

        If rbtIngles.Checked Then
            objRecordatorio.Idioma = "I"
        Else
            objRecordatorio.Idioma = "E"
        End If

        If rbActivo.Checked Then
            objRecordatorio.StsRecordatorio = "A"
        Else
            objRecordatorio.StsRecordatorio = "I"
        End If

        objRecordatorio.CodZonaVta = ddlZonaVta.SelectedItem.Value
        objRecordatorio.NroRecordatorio = txtCodigo.Text
        objRecordatorio.DesRecordatorio = txtDescripcion.Text
        objRecordatorio.NroDias = txtDias.Text
        objRecordatorio.DatoBase = "Fch.Ult.Envio"
        objRecordatorio.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objRecordatorio.Grabar
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
        lblMsg.Text = ""
        CargaZonaVta(dgLista.Items(dgLista.SelectedIndex).Cells(1).Text)

        If dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim = "Ingles" Then
            rbtIngles.Checked = True
            rbtEspanol.Checked = False
        Else
            rbtIngles.Checked = False
            rbtEspanol.Checked = True
        End If

        txtCodigo.Text = dgLista.Items(dgLista.SelectedIndex).Cells(3).Text.Trim
        txtDescripcion.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text.Trim
        txtDias.Text = dgLista.Items(dgLista.SelectedIndex).Cells(6).Text.Trim

        If dgLista.Items(dgLista.SelectedIndex).Cells(8).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        objRecordatorio.CodZonaVta = Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 3)
        objRecordatorio.Idioma = Mid(dgLista.DataKeys(e.Item.ItemIndex), 4, 1)
        objRecordatorio.NroRecordatorio = Mid(dgLista.DataKeys(e.Item.ItemIndex), 5, 3)
        lblMsg.Text = objRecordatorio.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub rbtIngles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtIngles.CheckedChanged
        rbtIngles.Checked = True
        rbtEspanol.Checked = False
    End Sub

    Private Sub rbtEspanol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEspanol.CheckedChanged
        rbtIngles.Checked = False
        rbtEspanol.Checked = True
    End Sub

    Private Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        Response.Redirect("TabRecordatorioDet.aspx" & _
                "?CodZonaVta=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 3) & _
                "&Idioma=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 4, 1) & _
                "&NroRecordatorio=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 5, 3))
    End Sub

    Private Sub ddlListaZonaVta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlListaZonaVta.SelectedIndexChanged
        CargaDatos()
    End Sub

    Private Sub rbtListaIng_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtListaIng.CheckedChanged
        rbtListaIng.Checked = True
        rbtListaEsp.Checked = False
        CargaDatos()
    End Sub

    Private Sub rbtListaEsp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtListaEsp.CheckedChanged
        rbtListaIng.Checked = False
        rbtListaEsp.Checked = True
        CargaDatos()
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(8).Text.Trim = "Inactivo" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

End Class
