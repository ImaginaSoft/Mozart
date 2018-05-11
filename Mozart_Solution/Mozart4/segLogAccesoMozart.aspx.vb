Imports cmpSeguridad
Imports cmpRutinas
Imports System.Data
Imports System.Drawing

Partial Class segLogAccesoMozart
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objRutina As New clsRutinas


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            CargaUsuario()
            CargaLog()
        End If
    End Sub
    Private Sub CargaUsuario()
        Dim objUsuario As New clsUsuario
        Dim ds As New DataSet
        ds = objUsuario.Cargar
        ddlUsuario.DataSource = ds
        ddlUsuario.DataBind()
        ddlUsuario.Items.FindByValue(Session("CodUsuario")).Selected = True

        objUsuario.CodUsuario = Session("CodUsuario")
        objUsuario.Editar()
        If objUsuario.FlagLogAcceso = "P" Then
            ddlUsuario.Enabled = False
        Else
            ddlUsuario.Items.Insert(0, New ListItem("Todos"))
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        If txtFchInicial.Text.Trim.Length = 0 Then
            lblmsg.Text = "Fecha inicio es obligatorio"
            Return
        End If
        If txtFchFinal.Text.Trim.Length = 0 Then
            lblmsg.Text = "Fecha final es obligatorio"
            Return
        End If
        CargaLog()
    End Sub

    Private Sub CargaLog()
        Dim objUsuario As New clsUsuario
        Dim ds As New DataSet
        If ddlUsuario.SelectedItem.Value = "Todos" Then
            If rbtTodos.Checked Then
                ds = objUsuario.CargarLog(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            ElseIf rbtLocal.Checked Then
                ds = objUsuario.CargarLogLocal(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            Else
                ds = objUsuario.CargarLogExterno(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
            End If
        Else
            If rbtTodos.Checked Then
                ds = objUsuario.CargarLog(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlUsuario.SelectedItem.Value)
            ElseIf rbtLocal.Checked Then
                ds = objUsuario.CargarLogLocal(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlUsuario.SelectedItem.Value)
            Else
                ds = objUsuario.CargarLogExterno(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), ddlUsuario.SelectedItem.Value)
            End If
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLog.DataSource = dv
        dgLog.DataBind()

        lblmsg.Text = CStr(dgLog.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgLog_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLog.SortCommand
        'ViewState permite grabar valores a nivel de página
        ViewState("Campo") = e.SortExpression()
        CargaLog()
    End Sub

    Private Sub dgLog_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLog.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "R" Then
                e.Item.ForeColor = Color.Red
            ElseIf e.Item.Cells(5).Text.Trim = "E" Then
                e.Item.ForeColor = Color.Blue
            End If
        End If
    End Sub
End Class
