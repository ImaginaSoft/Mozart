Imports cmpTabla
Imports System.Data

Partial Class TabPasajeroHabitacion
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objPasajeroHabitacion As New clsPasajeroHabitacion

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblTitulo.Text = "Combinaciones para cotizar desde Peru4all"
            CargaDatos()
        End If

    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objPasajeroHabitacion.CargaxCant(txtCantAdultos.Text, txtCantNinos.Text)
        dglista.DataKeyField = "KeyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Registro(s)"
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objPasajeroHabitacion.CantAdultos = txtADT.Text
        objPasajeroHabitacion.CantNinos = txtCHD.Text
        objPasajeroHabitacion.CantSimple = txtSGL.Text
        objPasajeroHabitacion.CantDoble = txtDBL.Text
        objPasajeroHabitacion.CantTriple = txtTPL.Text
        objPasajeroHabitacion.CantCuadruple = txtCDL.Text
        objPasajeroHabitacion.AduSGL = txtAduSGL.Text
        objPasajeroHabitacion.AduDBL = txtAduDBL.Text
        objPasajeroHabitacion.AduTPL = txtAduTPL.Text
        objPasajeroHabitacion.AduCDL = txtAduCDL.Text
        objPasajeroHabitacion.NinSGL = txtNinSGL.Text
        objPasajeroHabitacion.NinDBL = txtNinDBL.Text
        objPasajeroHabitacion.NinTPL = txtNinTPL.Text
        objPasajeroHabitacion.NinCDL = txtNinCDL.Text
        objPasajeroHabitacion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPasajeroHabitacion.Grabar
        If lblMsg.Text.Trim = "OK" Then
            txtCantAdultos.Text = txtADT.Text
            txtCantNinos.Text = txtCHD.Text
            CargaDatos()
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        objPasajeroHabitacion.CantAdultos = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 1, 4)
        objPasajeroHabitacion.CantNinos = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 5, 4)
        objPasajeroHabitacion.CantSimple = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 9, 4)
        objPasajeroHabitacion.CantDoble = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 13, 4)
        objPasajeroHabitacion.CantTriple = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 17, 4)
        objPasajeroHabitacion.CantCuadruple = Mid(dglista.DataKeys(e.Item.ItemIndex).ToString, 21, 4)

        lblMsg.Text = objPasajeroHabitacion.Borrar()
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dglista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtADT.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtCHD.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtSGL.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim
        txtDBL.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim
        txtTPL.Text = dglista.Items(dglista.SelectedIndex).Cells(5).Text.Trim
        txtCDL.Text = dglista.Items(dglista.SelectedIndex).Cells(6).Text.Trim

        txtAduSGL.Text = dglista.Items(dglista.SelectedIndex).Cells(7).Text.Trim
        txtAduDBL.Text = dglista.Items(dglista.SelectedIndex).Cells(8).Text.Trim
        txtAduTPL.Text = dglista.Items(dglista.SelectedIndex).Cells(9).Text.Trim
        txtAduCDL.Text = dglista.Items(dglista.SelectedIndex).Cells(10).Text.Trim
        txtNinSGL.Text = dglista.Items(dglista.SelectedIndex).Cells(11).Text.Trim
        txtNinDBL.Text = dglista.Items(dglista.SelectedIndex).Cells(12).Text.Trim
        txtNinTPL.Text = dglista.Items(dglista.SelectedIndex).Cells(13).Text.Trim
        txtNinCDL.Text = dglista.Items(dglista.SelectedIndex).Cells(14).Text.Trim
    End Sub

    Private Sub cmdBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBusca.Click
        CargaDatos()
    End Sub

End Class
