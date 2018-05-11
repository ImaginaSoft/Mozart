Imports cmpTabla
Imports cmpNegocio
Imports System.Drawing
Imports System.Data

Partial Class ageSolicitudxFchIngreso
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objSolicitud As New clsSolicitud
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = objRutina.fechaddmmyyyy(-7)
            txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            CargaSolicitudes()
        End If
    End Sub

    Private Sub CargaSolicitudes()
        Dim ds As New DataSet
        ds = objSolicitud.CargaxFchIngreso(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblmsg.Text = CStr(dgLista.Items.Count) + " Solicitud(es)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaSolicitudes()
    End Sub

    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Response.Redirect("VtaPedido.aspx" & _
                "?CodCliente=" & dgLista.Items(dgLista.SelectedIndex).Cells(9).Text & _
                "&NroSolicitud=" & dgLista.Items(dgLista.SelectedIndex).Cells(10).Text)
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaSolicitudes()
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Trim(e.Item.Cells(8).Text) = "P" Then
                'e.Item.ForeColor = Color.Red
                e.Item.Cells(5).ForeColor = Color.Red
            Else
                e.Item.Cells(0).Text = ""
            End If
        End If
    End Sub

End Class
