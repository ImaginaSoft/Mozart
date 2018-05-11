Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybConfirma
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaPagos()
        End If
    End Sub
    Private Sub CargaPagos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CYB_Confirma_S"
        Dim nReg As Integer = da.Fill(ds, "Pagos")
        'dgPagos.DataKeyField = "KeyReg"
        dgPagos.DataSource = ds.Tables("Pagos")
        dgPagos.DataBind()
        lblmsg.Text = CStr(nReg) + " Registro(s) "
    End Sub

    Protected Sub dgPagos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPagos.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgPagos.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgPagos.Rows
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

    Protected Sub dgPagos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgPagos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(14).Text.Trim = "A" Then 'ABONO (pago del cliente)
                e.Row.Cells(5).ForeColor = Color.Blue
            Else
                e.Row.ForeColor = Color.Red 'CARGO (reembolso al cliente)
            End If

            If e.Row.Cells(16).Text.Trim = "S" Then 'FlagCtaDeposito
                e.Row.Cells(0).Text = ""
            End If
        End If

    End Sub

    Private Sub dgPagos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPagos.SelectedIndexChanged
        Response.Redirect("cybConfirmaPago.aspx" & _
        "?TipoDocumento=" & dgPagos.Rows(dgPagos.SelectedIndex).Cells(2).Text & _
        "&NroDocumento=" & dgPagos.Rows(dgPagos.SelectedIndex).Cells(3).Text & _
        "&Opcion=C")
    End Sub

    Private Sub lbtDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDeposito.Click
        Dim i As Integer = 0
        Dim sCodMoneda As String = " "
        Dim iCantMoneda As Integer = 0

        Dim sTipoDocumento As String = " "
        Dim iCantTipoDoc As Integer = 0

        Dim iCantSelec As Integer = 0
        lblmsg.Text = ""

        Dim currentRowsFilePath As String
        For index As Integer = 0 To dgPagos.Rows.Count - 1
            Dim cb As CheckBox = CType(dgPagos.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                iCantSelec = iCantSelec + 1
                If sCodMoneda <> Mid(dgPagos.DataKeys(index).Value, 13, 1) Then
                    iCantMoneda = iCantMoneda + 1
                    sCodMoneda = Mid(dgPagos.DataKeys(index).Value, 13, 1)
                End If
                If "A" = Mid(dgPagos.DataKeys(index).Value, 15, 1) Then
                    If sTipoDocumento <> Mid(dgPagos.DataKeys(index).Value, 1, 2) Then
                        iCantTipoDoc = iCantTipoDoc + 1
                        sTipoDocumento = Mid(dgPagos.DataKeys(index).Value, 1, 2)
                    End If
                End If
                If "S" <> Mid(dgPagos.DataKeys(index).Value, 14, 1) Then
                    lblmsg.Text = "Seleccione documentos de pago con tarjeta de crédito o reembolso."
                    lblmsg.CssClass = "error"
                    Return
                End If
            End If
        Next

        If iCantSelec = 0 Then
            lblmsg.Text = "Falta seleccionar documentos."
        ElseIf iCantMoneda > 1 Then
            lblmsg.Text = "Los documentos seleccionados debe ser en una sola moneda."
        ElseIf iCantTipoDoc > 1 Then
            lblmsg.Text = "Los documentos seleccionados debe ser del mismo tipo de tarjeta."
        End If
        If lblmsg.Text.Trim.Length <> 0 Then
            lblmsg.CssClass = "error"
            Return
        End If

        'Cargando la Tabla Temporal
        Dim sIdReg As String = Mid(CStr(Now) & " " & Session("CodUsuario"), 1, 25)

        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)
        For index As Integer = 0 To dgPagos.Rows.Count - 1
            Dim cb As CheckBox = CType(dgPagos.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CYB_ConfirmaDeposito_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
                cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Mid(dgPagos.DataKeys(index).Value, 1, 2)
                cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Mid(dgPagos.DataKeys(index).Value, 3, 10))
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()
                If lblmsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next
        If Trim(lblmsg.Text) <> "OK" And Len(Trim(lblmsg.Text)) <> 0 Then
            Return
        End If

        Response.Redirect("cybConfirmaDeposito.aspx?IdReg=" & sIdReg & "&CodMoneda=" & sCodMoneda)
    End Sub

End Class
