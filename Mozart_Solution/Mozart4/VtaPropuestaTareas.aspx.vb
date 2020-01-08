Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Partial Class VtaPropuestaTareas
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            CargaTareas()
        End If
    End Sub

    Private Sub CargaTareas()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PedidoTareas_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Tareas")
        'dgTarea.DataKeyField = "KeyReg"
        dgTarea.DataSource = ds.Tables("Tareas")
        dgTarea.DataBind()
        lblmsg.Text = CStr(nReg) + " Tareas(s) encontrada(s)"
    End Sub


    Private Sub cmdCompletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompletar.Click
        Dim i As Integer = 0
        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgTarea.Rows.Count - 1
            Dim cb As CheckBox = CType(dgTarea.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim MsgTrans As String
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "VTA_TareaSts_U"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Mid(dgTarea.DataKeys(index).Value, 1, 10)
                cd.Parameters.Add("@NroTarea", SqlDbType.SmallInt).Value = Mid(dgTarea.DataKeys(index).Value, 11, 4)
                cd.Parameters.Add("@StsTarea", SqlDbType.Char, 1).Value = "C"
                cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = CInt(ViewState("NroPropuesta"))
                cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = CInt(ViewState("NroVersion"))
                cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = CInt(ViewState("CodCliente"))
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                cn.Open()
                cd.ExecuteNonQuery()
                lblmsg.Text = cd.Parameters("@MsgTrans").Value
                cn.Close()
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

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Tarea_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@DesTarea", SqlDbType.VarChar, 50).Value = txtDesTarea.Text
        cd.Parameters.Add("@FchTarea", SqlDbType.Char, 8).Value = wFchTarea
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = 0
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ""
        cd.Parameters.Add("@FlagFchRevision", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblerror.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblerror.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblerror.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

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
            If e.Row.Cells(4).Text = "V" Then
                e.Row.ForeColor = Color.Green
            ElseIf e.Row.Cells(4).Text = "R" Then
                e.Row.ForeColor = Color.Red
            ElseIf e.Row.Cells(4).Text = "A" Then
                e.Row.ForeColor = Color.Blue
            ElseIf e.Row.Cells(4).Text = "G" Then
                e.Row.ForeColor = Color.DarkGray
            End If
        End If
    End Sub
End Class
