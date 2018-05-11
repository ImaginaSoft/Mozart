Imports cmpSeguridad
Imports System.Drawing
Imports System.Data

Partial Class segLogAccesoMC
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objLogAcceso As New cmpSeguridad.clsLogAcceso
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
        End If
    End Sub
    Private Sub CargaLog()
        Dim ds As New DataSet
        ds = objLogAcceso.CargaMC(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), txtemail.Text.Trim + "%")
        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
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
        Session("CodCliente") = dgLog.Items(dgLog.SelectedIndex).Cells(17).Text
        Response.Redirect("VtaPedidoFicha.aspx" & _
                  "?NroPedido=" & dgLog.Items(dgLog.SelectedIndex).Cells(4).Text & _
                 "&CodCliente=" & dgLog.Items(dgLog.SelectedIndex).Cells(17).Text)
    End Sub

    Private Sub dgLog_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLog.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "Aceptada" Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
            End If
        End If
    End Sub
End Class
