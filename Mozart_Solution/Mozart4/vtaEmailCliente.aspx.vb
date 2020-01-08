Imports cmpRutinas
Imports cmpNegocio
Imports cmpTabla
Imports cmpSeguridad
Imports System.Data
Imports System.Drawing

Partial Class vtaEmailCliente
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objLog As New clsLog
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicio.Text = objRutina.fechaddmmyyyy(-3)
            txtFchFin.Text = objRutina.fechaddmmyyyy(0)
            CargaVendedor()
        End If
    End Sub

    Private Sub CargaVendedor()
        Dim objVendedor As New clsVendedor
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()

        Dim objUsuario As New clsUsuario
        objUsuario.CodUsuario = Session("CodUsuario")
        objUsuario.Editar()
        If objUsuario.FlagEmailAcceso = "P" Then
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
        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            ds = objLog.LogEmailCliente(objRutina.fechayyyymmdd(txtFchInicio.Text), objRutina.fechayyyymmdd(txtFchFin.Text))
        Else
            ds = objLog.LogEmailCliente(objRutina.fechayyyymmdd(txtFchInicio.Text), objRutina.fechayyyymmdd(txtFchFin.Text), ddlVendedor.SelectedItem.Value)
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLog.DataSource = dv
        dgLog.DataBind()
        lblmsg.Text = CStr(dgLog.Items.Count) + " Registro(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        If txtFchInicio.Text.Trim.Length = 0 Then
            lblmsg.Text = "Fecha de inicio es obligatorio"
            Return
        End If
        If txtFchFin.Text.Trim.Length = 0 Then
            lblmsg.Text = "Fecha de termino es obligatorio"
            Return
        End If

        CargaLog()
    End Sub

    Private Sub dgLog_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLog.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaLog()
    End Sub

    Private Sub dgLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLog.SelectedIndexChanged
        lblmsg.Text = objLog.CambiarTipoLog(dgLog.Items(dgLog.SelectedIndex).Cells(8).Text, "7", Session("CodUsuario"))
        If lblmsg.Text.Trim = "OK" Then
            lblmsg.Text = ""
            Session("CodCliente") = dgLog.Items(dgLog.SelectedIndex).Cells(6).Text
            Response.Redirect("cpcClienteFicha.aspx" & _
                "?CodCliente=" & Session("CodCliente"))
        End If
    End Sub

    Private Sub dgLog_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLog.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(7).Text.Trim = "3" Then
                e.Item.ForeColor = Color.Blue
            ElseIf e.Item.Cells(7).Text.Trim = "8" Then
                e.Item.ForeColor = Color.Sienna
            End If
        End If
    End Sub


End Class
