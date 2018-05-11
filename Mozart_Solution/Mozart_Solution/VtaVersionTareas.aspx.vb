Imports cmpNegocio
Imports cmpTabla
Imports System.Drawing
Imports System.Data

Partial Class VtaVersionTareas
    Inherits System.Web.UI.Page
    Dim objPedido As New clsPedido
    Dim objVersion As New clsVersion
    Dim objVendedor As New clsVendedor

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("CodVendedor") = Request.Params("CodVendedor")
            CargaVendedor()
            'carga doble proproblema del checkbox
            CargaTareas()
            CargaTareas()
        End If
    End Sub

    Private Sub CargaTareas()
        Dim ds As New DataSet
        ds = objPedido.CargaTareas(Viewstate("NroPedido"))
        dgTarea.DataSource = ds
        dgTarea.DataBind()
        'dgTarea.DataKeyField = "KeyReg"
        lblmsg.Text = CStr(dgTarea.Rows.Count) + " Tareas(s) encontrada(s)"
    End Sub

    Private Sub CargaVendedor()
        Dim ds As New DataSet
        ds = objVendedor.CargarActivo
        ddlVendedor.DataSource = ds
        ddlVendedor.DataBind()
        If Trim(Viewstate("CodVendedor")).Length > 0 Then
            Try
                ddlVendedor.Items.FindByValue(Viewstate("CodVendedor")).Selected = True
            Catch ex As Exception
                lblmsg.Text = "Vendedor " & Viewstate("CodVendedor") & " esta inactivo."
            End Try
        End If
    End Sub


    Private Sub cmdCompletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompletar.Click

        Dim i As Integer = 0

        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgTarea.Rows.Count - 1
            Dim cb As CheckBox = CType(dgTarea.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                objVersion.NroPedido = Mid(dgTarea.DataKeys(index).Value, 1, 10)
                objVersion.NroTarea = Mid(dgTarea.DataKeys(index).Value, 11, 4)
                objVersion.StsTarea = "C"
                objVersion.NroPropuesta = ViewState("NroPropuesta")
                objVersion.NroVersion = ViewState("NroVersion")
                objVersion.CodCliente = ViewState("CodCliente")
                objVersion.CodUsuario = Session("CodUsuario")
                lblmsg.Text = objVersion.ActualizaStsTarea
            End If
        Next
        CargaTareas()
    End Sub

    Private Sub cmdGrabrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabrar.Click
        lblerror.Text = ""
        If txtDesTarea.Text.Trim.Length = 0 Then
            lblerror.Text = "Descripción de la tarea es obligatorio"
            Return
        End If

        If txtFchTarea.Text.Trim.Length = 0 Then
            lblerror.Text = "Falta elegir fecha de tarea"
            Return
        End If

        Dim wHoy, wFchTarea As String
        Dim wAno As String = Year(Now)
        Dim wMes As String = Month(Now)
        Dim wDia As String = Day(Now)

        If ((wMes).Trim).Length = 1 Then
            wMes = "0" + wMes
        End If
        If ((wDia).Trim).Length = 1 Then
            wDia = "0" + wDia
        End If

        wHoy = wAno & wMes & wDia
        wFchTarea = txtFchTarea.Text.Substring(6, 4) + txtFchTarea.Text.Substring(3, 2) + txtFchTarea.Text.Substring(0, 2)
        If wFchTarea < wHoy Then
            lblerror.Text = "Fecha de la tarea debe ser mayor o igual al día de hoy"
            Return
        End If

        Dim sFlagFchRevision As String = ""
        If chbFchRevision.Checked Then
            sFlagFchRevision = "U"  'Flag actualizar fecha revision de la version
        End If

        objVersion.NroPedido = Viewstate("NroPedido")
        objVersion.DesTarea = txtDesTarea.Text
        objVersion.FchTarea = wFchTarea
        objVersion.NroPropuesta = Viewstate("NroPropuesta")
        objVersion.NroVersion = Viewstate("NroVersion")
        objVersion.CodVendedor = ddlVendedor.SelectedItem.Value
        objVersion.FlagFchRevision = sFlagFchRevision
        objVersion.CodUsuario = Session("CodUsuario")
        lblerror.Text = objVersion.GrabaTareas
        If lblerror.Text.Trim = "OK" Then
            txtFchTarea.Text = ""
            txtDesTarea.Text = ""
            CargaTareas()
        End If
    End Sub

    Protected Sub dgTarea_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTarea.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgTarea.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgTarea.Rows
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

    Protected Sub dgTarea_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgTarea.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(5).Text = "V" Then
                e.Row.ForeColor = Color.Green
            ElseIf e.Row.Cells(5).Text = "R" Then
                e.Row.ForeColor = Color.Red
            ElseIf e.Row.Cells(5).Text = "A" Then
                e.Row.ForeColor = Color.Blue
            ElseIf e.Row.Cells(5).Text = "G" Then
                e.Row.ForeColor = Color.DarkGray
            End If
        End If
    End Sub
End Class
