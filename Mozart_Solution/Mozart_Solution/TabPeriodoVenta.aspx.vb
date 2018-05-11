Imports cmpTabla
Imports cmpRutinas
Imports System.Data
Imports System.Drawing

Partial Class TabPeriodoVenta
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objPeriodoVta As New clsPeriodoVta
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaAno()
            CargaDatos()
        End If
    End Sub

    Private Sub CargaAno()
        Dim objAnoProceso As New clsAnoProceso
        Dim ds As New DataSet
        ds = objAnoProceso.Consulta()
        ddlAno.DataSource = ds
        ddlAno.DataBind()
        Try
            ddlAno.Items.FindByValue(Year(DateTime.Now)).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaDatos()
        lblMsg.Text = ""
        Dim ds As New DataSet
        ds = objPeriodoVta.Cargar(ddlAno.SelectedValue)
        dgLista.DataKeyField = "FchIniPeriodo"
        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        'lblMsg.Text = CStr(dgLista.Items.Count()) + " Fecha(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.CssClass = "Error"
        If txtFchInicial.Text.Trim.Length = 0 Then
            lblMsg.Text = " Fecha inicial es obligatorio"
            Return
        End If
        If txtFchFinal.Text.Trim.Length = 0 Then
            lblMsg.Text = " Fecha termino es obligatorio"
            Return
        End If
        lblMsg.CssClass = "Msg"

        If rbtIngresado.Checked Then
            objPeriodoVta.StsPeriodo = "I"
        ElseIf rbtAbierto.Checked Then
            objPeriodoVta.StsPeriodo = "A"
        Else
            objPeriodoVta.StsPeriodo = "C"
        End If

        objPeriodoVta.cFchIniPeriodo = objRutina.fechayyyymmdd(txtFchInicial.Text)
        objPeriodoVta.cFchFinPeriodo = objRutina.fechayyyymmdd(txtFchFinal.Text)
        objPeriodoVta.Trimestre = ddlTrim.SelectedValue
        objPeriodoVta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPeriodoVta.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        lblMsg.Text = ""
        txtFchInicial.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text.Trim
        txtFchFinal.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim

        If dgLista.Items(dgLista.SelectedIndex).Cells(7).Text.Trim = "I" Then
            Ingresado()
        ElseIf dgLista.Items(dgLista.SelectedIndex).Cells(7).Text.Trim = "A" Then
            Abierto()
        Else
            Cerrado()
        End If

        'trimestre
        Try
            ddlTrim.ClearSelection()
            ddlTrim.Items.FindByValue(dgLista.Items(dgLista.SelectedIndex).Cells(8).Text.Trim).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objPeriodoVta.Borrar(objRutina.fechayyyymmdd(String.Format("{0:dd-MM-yyyy}", CDate(dgLista.DataKeys(e.Item.ItemIndex)))))
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub rbtIngresado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtIngresado.CheckedChanged
        Ingresado()
    End Sub

    Private Sub rbtAbierto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Abierto()
    End Sub

    Private Sub rbtCerrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cerrado()
    End Sub

    Private Sub Ingresado()
        rbtIngresado.Checked = True
        rbtAbierto.Checked = False
        rbtCerrado.Checked = False
    End Sub
    Private Sub Abierto()
        rbtIngresado.Checked = False
        rbtAbierto.Checked = True
        rbtCerrado.Checked = False
    End Sub
    Private Sub Cerrado()
        rbtIngresado.Checked = False
        rbtAbierto.Checked = False
        rbtCerrado.Checked = True
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Trim(e.Item.Cells(7).Text) = "C" Then
                e.Item.ForeColor = Color.DarkGray
            ElseIf e.Item.Cells(7).Text.Trim = "A" Then
                e.Item.ForeColor = Color.Blue
            End If
        End If
    End Sub

    Protected Sub ddlAno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAno.SelectedIndexChanged
        CargaDatos()
    End Sub
End Class
