Imports cmpTabla
Imports System.Data

Partial Class TabTarea
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTarea As New clsTarea

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ddlDatoBase.Items.Insert(0, New ListItem("Fecha Pedido"))
            CargaDatoBase("Fecha Pedido")
            CargaArea("")
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTarea.Cargar()
        dgTarea.DataKeyField = "NroTarea"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTarea.DataSource = dv
        dgTarea.DataBind()
        lblMsg.Text = CStr(dgTarea.Items.Count) + " Tarea(s)"
    End Sub

    Private Sub CargaDatoBase(ByVal pDatoBase As String)
        Dim objDatoBase As New clsDatoBase
        Dim ds As New DataSet
        ds = objDatoBase.Cargar()
        ddlDatoBase.DataSource = ds
        ddlDatoBase.DataBind()
        Try
            ddlDatoBase.Items.FindByText(pDatoBase).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaArea(ByVal pCodArea As String)
        Dim objArea As New clsArea
        Dim ds As New DataSet
        ds = objArea.Cargar()
        ddlArea.DataSource = ds
        ddlArea.DataBind()
        If pCodArea.Trim.Length > 0 Then
            ddlArea.Items.FindByValue(pCodArea).Selected = True
        End If
    End Sub

    Private Sub dgTarea_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTarea.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objTarea.StsTarea = "A"
        Else
            objTarea.StsTarea = "I"
        End If

        objTarea.NroTarea = txtCodigo.Text
        objTarea.DesTarea = txtDescripcion.Text
        objTarea.NroDias = txtDias.Text
        objTarea.DatoBase = ddlDatoBase.SelectedItem.Text
        objTarea.CodArea = ddlArea.SelectedItem.Value
        objTarea.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTarea.Grabar
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

    Private Sub dgTarea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTarea.SelectedIndexChanged
        Dim wdatobase As String
        txtCodigo.Text = dgTarea.Items(dgTarea.SelectedIndex).Cells(1).Text.Trim
        txtDescripcion.Text = dgTarea.Items(dgTarea.SelectedIndex).Cells(2).Text.Trim
        txtDias.Text = dgTarea.Items(dgTarea.SelectedIndex).Cells(3).Text.Trim
        wdatobase = dgTarea.Items(dgTarea.SelectedIndex).Cells(4).Text

        If dgTarea.Items(dgTarea.SelectedIndex).Cells(5).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
        CargaDatoBase(wdatobase)
        CargaArea(dgTarea.Items(dgTarea.SelectedIndex).Cells(6).Text)
    End Sub

    Private Sub dgTarea_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTarea.DeleteCommand
        objTarea.NroTarea = dgTarea.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objTarea.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub


End Class
