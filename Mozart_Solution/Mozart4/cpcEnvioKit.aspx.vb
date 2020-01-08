Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpTabla
Imports cmpNegocio
Imports System.Drawing

Partial Class cpcEnvioKit
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objPedido As New clsPedido
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchIni.Text = objRutina.fechaddmmyyyy(0)
            txtFchFin.Text = objRutina.fechaddmmyyyy(120)
            CargaStsEnvio()
            CargaDocumentos()
        End If
    End Sub

    Private Sub CargaStsEnvio()
        Dim objTablaElemento As New clsTablaElemento
        ddlStsEnvio.DataSource = objTablaElemento.CargaTablaElexCodEle(15, "E")
        ddlStsEnvio.DataBind()
        ddlStsEnvio.Items.FindByValue("P").Selected = True
    End Sub

    Private Sub CargaDocumentos()
        lblmsg.Text = ""
        lblmsg.CssClass = "Msg"
        Dim objPedido As New clsPedido
        Dim ds As DataSet
        ds = objPedido.CargaEnvioKit(objRutina.fechayyyymmdd(txtFchIni.Text), objRutina.fechayyyymmdd(txtFchFin.Text), ddlStsEnvio.SelectedValue)
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        lblmsg.Text = CStr(dgLista.Rows.Count) + " Pedido(s)"
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        lblmsg.CssClass = "Error"
        Dim wCheck As Boolean
        Dim wMes As String
        Dim wano As Integer

        wCheck = False
        Session("IdReg") = CStr(Now)
        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgLista.Rows.Count - 1
            Dim cb As CheckBox = CType(dgLista.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                lblmsg.Text = objPedido.ActualizaFchEnvioKit(dgLista.DataKeys(index).Value, objRutina.fechayyyymmdd(txtFchEnvioKit.Text), "P", Session("CodUsuario"))
                If lblmsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next
        If lblmsg.Text.Trim = "OK" Then
            CargaDocumentos()
        End If
    End Sub


    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        txtFchEnvioKit.Text = ""
    End Sub


    Protected Sub dgLista_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLista.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgLista.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgLista.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next

        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"


    End Sub

    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(13).Text.Trim = "P" Then
                e.Row.Cells(9).ForeColor = Color.Red
                e.Row.Cells(10).ForeColor = Color.Red
                e.Row.Cells(11).ForeColor = Color.Red
            End If
        End If
    End Sub

    Protected Sub dgLista_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgLista.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub
End Class
