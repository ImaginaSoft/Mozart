Imports cmpSeguridad
Imports cmpTabla
Imports cmpBlog
Imports System.Data
Imports System.Drawing

Partial Class blogCaptacionExp
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Dim objExperiencia As New clsExperiencia
    Dim iNroPedido As Integer = 0
    Dim iNroExp As Integer = 0

    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaPedidos()
        End If
    End Sub

    Private Sub CargaPedidos()
        Dim ds As New DataSet
        ds = objExperiencia.Captacion(Session("CodUsuario"))
        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()

        If dgPedidos.Rows.Count = 0 Then
            ButtonMarcar.Visible = False
            ButtonOrden.Visible = False
            lblmsg.Text = "No existe Experiencia marcadas para Web Captación"
        Else
            ButtonMarcar.Visible = True
            ButtonOrden.Visible = True
            lblmsg.Text = CStr(dgPedidos.Rows.Count) + " Experiencia(s)"
        End If
    End Sub


    Protected Sub dgPedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgPedidos.RowDataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgPedidos.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgPedidos.Rows
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



    Protected Sub dgPedidos_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgPedidos.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaPedidos()
    End Sub

    Protected Sub ButtonMarcar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMarcar.Click
        Dim wCheck As Boolean
        Dim wMes As String
        Dim wano As Integer

        wCheck = False
        Session("IdReg") = CStr(Now)
        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgPedidos.Rows.Count - 1
            Dim cb As CheckBox = CType(dgPedidos.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then

                iNroPedido = Convert.ToInt32(dgPedidos.DataKeys(index).Values("NroPedido"))
                iNroExp = Convert.ToInt32(dgPedidos.DataKeys(index).Values("NroExp"))
                lblmsg.Text = objExperiencia.ActualizaFlagCaptacion(iNroPedido, iNroExp, "", Session("CodUsuario"))
                If lblmsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next
        If lblmsg.Text.Trim = "OK" Then
            Response.Redirect("blogCaptacionExp.aspx")
        End If
    End Sub

    Protected Sub ButtonOrden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOrden.Click
        Dim sOrden As String

        For Each oItem As GridViewRow In dgPedidos.Rows
            'sOrden = CType(oItem.FindControl("OrdenCaptacion"), TextBox).Text
            Dim tb As TextBox = DirectCast(oItem.FindControl("OrdenCaptacion"), TextBox)
            sOrden = tb.Text

            If IsNumeric(sOrden.Trim) Then

                iNroPedido = Convert.ToInt32(dgPedidos.DataKeys(oItem.RowIndex).Values("NroPedido"))
                iNroExp = Convert.ToInt32(dgPedidos.DataKeys(oItem.RowIndex).Values("NroExp"))


                lblmsg.Text = objExperiencia.ActualizaOrdenCaptacion(iNroPedido, iNroExp, sOrden, Session("CodUsuario"))
            End If
        Next

        Response.Redirect("blogCaptacionExp.aspx")
    End Sub

End Class
