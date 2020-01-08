Imports cmpTabla
Imports cmpSeguridad
Imports System.Data
Imports System.Drawing

Partial Class segLogAccesoPeru4me
    Inherits System.Web.UI.Page
    Dim objVendedor As New clsVendedor
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objLogAcceso As New cmpSeguridad.clsLogAcceso
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = objRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()

        Dim objUsuario As New clsUsuario
        objUsuario.CodUsuario = Session("CodUsuario")
        objUsuario.Editar()
        If objUsuario.FlagVtaAcceso = "P" Then
            Try
                ddlVendedor.Items.FindByValue(Session("CodUsuario")).Selected = True
            Catch ex As Exception
                ddlVendedor.Items.Insert(0, New ListItem("Usuario sin Cod.Vendedor"))
            End Try
            ddlVendedor.Enabled = False
        Else
            ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        End If

    End Sub

    Private Sub CargaLog()
        Dim ds As New DataSet
        If rbtPeru4me.Checked Then
            dgLog.Columns(4).Visible = True
            dgLog.Columns(5).Visible = True
            dgLog.Columns(8).Visible = True
            ds = objLogAcceso.CargaPeru4me(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), RTrim(txtemail.Text) + "%", ddlVendedor.SelectedValue)
        Else
            dgLog.Columns(4).Visible = False
            dgLog.Columns(5).Visible = False
            dgLog.Columns(8).Visible = False
            ds = objLogAcceso.CargaPeru4all(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), "Age:")
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLog.DataSource = dv
        dgLog.DataBind()
        lblmsg.Text = CStr(dgLog.Items.Count) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaLog()
    End Sub

    Private Sub dgLog_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLog.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaLog()
    End Sub

    Private Sub dgLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLog.SelectedIndexChanged
        Response.Redirect("VtaPedidoFicha.aspx" & _
                  "?NroPedido=" & dgLog.Items(dgLog.SelectedIndex).Cells(4).Text & _
                 "&CodCliente=" & dgLog.Items(dgLog.SelectedIndex).Cells(11).Text)
    End Sub

    Private Sub dgLog_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLog.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            If IsNumeric(e.Item.Cells(4).Text) Then
                If CInt(e.Item.Cells(4).Text) = 0 Then
                    e.Item.Cells(0).Text = " "
                End If
            Else
                e.Item.Cells(0).Text = " "
            End If

            If Trim(e.Item.Cells(2).Text) = "Error" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

End Class
