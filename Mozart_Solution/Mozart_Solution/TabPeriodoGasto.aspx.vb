Imports cmpTabla
Imports cmpRutinas
Imports System.Data
Imports System.Drawing

Partial Class TabPeriodoGasto
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objPeriodoGasto As New clsPeriodoGasto
    Dim objRutina As New clsRutinas

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
        ds = objPeriodoGasto.Cargar
        dgLista.DataKeyField = "FchIniPeriodo"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblMsg.Text = CStr(dgLista.Items.Count()) + " Fecha(s)"
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
        If txtTipoCambio.Text.Trim.Length = 0 Then
            lblMsg.Text = " Tipo Cambio es obligatorio"
            Return
        ElseIf Not IsNumeric(txtTipoCambio.Text) Then
            lblMsg.Text = " Tipo Cambio es númerico"
            Return
        End If
        lblMsg.CssClass = "Msg"

        If rbtIngresado.Checked Then
            objPeriodoGasto.StsPeriodo = "I"
        ElseIf rbtAbierto.Checked Then
            objPeriodoGasto.StsPeriodo = "A"
        Else
            objPeriodoGasto.StsPeriodo = "C"
        End If

        objPeriodoGasto.cFchIniPeriodo = objRutina.fechayyyymmdd(txtFchInicial.Text)
        objPeriodoGasto.cFchFinPeriodo = objRutina.fechayyyymmdd(txtFchFinal.Text)
        objPeriodoGasto.TipoCambio = txtTipoCambio.Text
        objPeriodoGasto.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPeriodoGasto.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        txtFchInicial.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text.Trim
        txtFchFinal.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text.Trim
        txtTipoCambio.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text.Trim
        If dgLista.Items(dgLista.SelectedIndex).Cells(8).Text.Trim = "I" Then
            Ingresado()
        ElseIf dgLista.Items(dgLista.SelectedIndex).Cells(8).Text.Trim = "A" Then
            Abierto()
        Else
            Cerrado()
        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        lblMsg.Text = objPeriodoGasto.Borrar(objRutina.fechayyyymmdd(String.Format("{0:dd-MM-yyyy}", dgLista.DataKeys(e.Item.ItemIndex))))
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub rbtIngresado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtIngresado.CheckedChanged
        Ingresado()
    End Sub

    Private Sub rbtAbierto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAbierto.CheckedChanged
        Abierto()
    End Sub

    Private Sub rbtCerrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCerrado.CheckedChanged
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
            If Trim(e.Item.Cells(8).Text) = "C" Then
                e.Item.ForeColor = Color.DarkGray
            ElseIf e.Item.Cells(8).Text.Trim = "A" Then
                e.Item.ForeColor = Color.Blue
            End If
        End If
    End Sub
End Class
