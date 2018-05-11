Imports cmpSeguridad
Imports cmpTabla
Imports cmpBlog
Imports System.Data
Imports System.Drawing

Partial Class blogRevisaExp
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVendedor As New clsVendedor
    Dim objExperiencia As New clsExperiencia
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            If Request.Params("Recarga") = "S" Then
                CargaVendedor(Session("IdReg"))
                txtFchInicial.Text = Request.Params("FchIni")
                txtFchFinal.Text = Request.Params("FchFin")
                CargaPedidos()
            Else
                CargaVendedor(Session("CodUsuario"))
                txtFchInicial.Text = objRutina.fechaddmmyyyy(-7)
                txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            End If
        End If
    End Sub

    Private Sub CargaVendedor(ByVal pCodVendedor As String)
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        Try
            ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
        Catch ex As Exception
            ddlVendedor.Items.FindByValue("Todos").Selected = True
        End Try
    End Sub

    Private Sub CargaPedidos()
        Dim ds As New DataSet
        If ddlVendedor.SelectedItem.Value.Trim = "Todos" Then
            ds = objExperiencia.CargaExperiencias(objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
        Else
            ds = objExperiencia.CargaExperiencias(ddlVendedor.SelectedItem.Value, objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text), Session("CodUsuario"))
        End If
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPedidos.DataSource = dv
        dgPedidos.DataBind()

        If dgPedidos.Rows.Count = 0 Then
            ButtonMarcar.Visible = False
        Else
            ButtonMarcar.Visible = True
        End If

        lblmsg.Text = CStr(dgPedidos.Rows.Count) + " Experiencia(s)"
    End Sub


    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        'CargaPedidos()
        Session("IdReg") = ddlVendedor.SelectedItem.Value
        Response.Redirect("blogRevisaExp.aspx" & _
            "?Recarga=" & "S" & _
            "&FchIni=" & txtFchInicial.Text & _
            "&FchFin=" & txtFchFinal.Text)

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
        'lblmsg.CssClass = "Error"
        Dim wCheck As Boolean
        Dim wMes As String
        Dim wano As Integer

        Dim iNP As Integer = 0
        Dim iNE As Integer = 0


        wCheck = False
        Session("IdReg") = CStr(Now)
        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgPedidos.Rows.Count - 1
            Dim cb As CheckBox = CType(dgPedidos.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then

                iNP = Convert.ToInt32(dgPedidos.DataKeys(index).Values("NroPedido"))
                iNE = Convert.ToInt32(dgPedidos.DataKeys(index).Values("NroExp"))
                lblmsg.Text = objExperiencia.ActualizaFlagCaptacion(iNP, iNE, "S", Session("CodUsuario"))
                If lblmsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next
        If lblmsg.Text.Trim = "OK" Then
            Session("IdReg") = ddlVendedor.SelectedItem.Value
            Response.Redirect("blogRevisaExp.aspx" & _
                "?Recarga=" & "S" & _
                "&FchIni=" & txtFchInicial.Text & _
                "&FchFin=" & txtFchFinal.Text)
        End If
    End Sub
End Class
