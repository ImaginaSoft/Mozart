Imports cmpTabla
Imports cmpRutinas
Imports cmpNegocio
Imports System.Data

Partial Class comRegCompras
    Inherits System.Web.UI.Page

    Private dv As DataView
    Dim objRutina As New clsRutinas
    Dim objComprobante As New clsComprobante

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim wNow As String
            Dim wmes, wano As Integer
            'Obtenemos la Fecha Inicial
            wNow = ObjRutina.fechayyyymmdd(ObjRutina.fechaddmmyyyy(0))
            wmes = CInt(Mid(wNow, 5, 2))
            wano = CInt(Mid(wNow, 1, 4))
            txtano.Text = wano
            CargaMes(wmes)
            CargaDocumentos()
        End If
    End Sub

    Private Sub CargaMes(ByVal pmes As String)
        Dim objTablaElemento As New clsTablaElemento
        ddlMes.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(9, "E")
        ddlMes.DataBind()
        Try
            ddlMes.Items.FindByValue(pmes).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub

    Private Sub CargaDocumentos()
        Dim ds As New DataSet
        ds = objComprobante.MesDeclarado("P", txtano.Text, ddlMes.SelectedValue)
        dgDocumento.DataKeyField = "Correlativo"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()

        If objComprobante.CierreMes(txtano.Text, ddlMes.SelectedValue) Then
            dgDocumento.Columns(14).Visible = False
            lblmsg.Text = "Mes cerrado con " & CStr(dgDocumento.Items.Count) + " Documento(s) "
        Else
            dgDocumento.Columns(14).Visible = True
            lblmsg.Text = CStr(dgDocumento.Items.Count) + " Documento(s)"
        End If
    End Sub
    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        If dgDocumento.Items(dgDocumento.SelectedIndex).Cells(15).Text.Trim = "RH" Then
            Response.Redirect("comComprobanteComprasRH.aspx" & _
                      "?Opcion=" & "Modifica" & _
                      "&Correlativo=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text)
        Else
            Response.Redirect("comComprobanteCompras.aspx" & _
                      "?Opcion=" & "Modifica" & _
                      "&Correlativo=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text)
        End If
    End Sub
    Private Sub lnkNuevoComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNuevoComprobante.Click
        Response.Redirect("comComprobanteCompras.aspx" & _
        "?Opcion=" & "Nuevo")
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub dgDocumento_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDocumento.DeleteCommand
        lblmsg.Text = objComprobante.Borrar(dgDocumento.DataKeys(e.Item.ItemIndex), "", "", Session("CodUsuario"))
        If lblmsg.Text.Trim = "OK" Then
            lblmsg.CssClass = "msg"
            CargaDocumentos()
        Else
            lblmsg.CssClass = "error"
        End If
    End Sub

    Private Sub lbtNuevoRH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoRH.Click
        Response.Redirect("comComprobanteComprasRH.aspx" & _
        "?Opcion=" & "Nuevo")
    End Sub

    Private Sub dgDocumento_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgDocumento.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

End Class
