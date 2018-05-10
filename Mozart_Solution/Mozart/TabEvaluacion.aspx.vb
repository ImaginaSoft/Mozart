Imports cmpTabla
Imports System.Data

Partial Class TabEvaluacion
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objEvaluacionVisita As New clsEvaluacionVisita

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objEvaluacionVisita.Cargar()
        dgEvaluacion.DataKeyField = "keyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgEvaluacion.DataSource = dv
        dgEvaluacion.DataBind()
        lblMsg.Text = CStr(dgEvaluacion.Items.Count) + " Evaluacion(es)"
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbEntrada.Checked Then
            objEvaluacionVisita.TipoEvaluacion = "E"
        ElseIf rbSalida.Checked Then
            objEvaluacionVisita.TipoEvaluacion = "S"
        Else
            objEvaluacionVisita.TipoEvaluacion = "N"
        End If

        objEvaluacionVisita.CodEvaluacion = txtCodigo.Text
        objEvaluacionVisita.NomEvaluacion = txtNombre.Text
        objEvaluacionVisita.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objEvaluacionVisita.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub
    Private Sub dgEvaluacion_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgEvaluacion.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub
    Private Sub dgEvaluacion_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgEvaluacion.DeleteCommand
        objEvaluacionVisita.CodEvaluacion = Mid(dgEvaluacion.DataKeys(e.Item.ItemIndex).ToString, 1, 3)
        lblMsg.Text = objEvaluacionVisita.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub
    Private Sub dgEvaluacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEvaluacion.SelectedIndexChanged
        Dim wEstado As String
        txtCodigo.Text = dgEvaluacion.Items(dgEvaluacion.SelectedIndex).Cells(1).Text
        txtNombre.Text = dgEvaluacion.Items(dgEvaluacion.SelectedIndex).Cells(2).Text
        wEstado = Trim(dgEvaluacion.Items(dgEvaluacion.SelectedIndex).Cells(5).Text)

        If wEstado = "E" Then
            rbEntrada.Checked = True
            rbSalida.Checked = False
            rbNo.Checked = False
        ElseIf wEstado = "S" Then
            rbEntrada.Checked = False
            rbSalida.Checked = True
            rbNo.Checked = False
        Else
            rbEntrada.Checked = False
            rbSalida.Checked = False
            rbNo.Checked = True
        End If
    End Sub

End Class
