Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class bolStockComprado
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim wTarifaSum As Double = 0
    Dim wProvSum As Double = 0
    Dim sIdReg As String
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaBoletos()
        End If
    End Sub

    Private Sub CargaBoletos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_StockComprado_S"

        Dim nReg As Integer = da.Fill(ds, "Campo")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        'dgBoleto.DataKeyField = "KeyReg"
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()

        lblMsg.Text = CStr(nReg) & " boleto(s)"
    End Sub
    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTarifa As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PagoBoleto"))
            wTarifaSum += wTarifa

            Dim wProv As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Provision"))
            wProvSum += wProv

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(2).Text = "Total: "
            e.Item.Cells(2).Font.Bold = True
            e.Item.Cells(3).Text = String.Format("{0:###,###,###.00}", wTarifaSum)
            e.Item.Cells(3).Font.Bold = True
            e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(4).Text = String.Format("{0:###,###,###.00}", wProvSum)
            e.Item.Cells(4).Font.Bold = True
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right

            lblNota.Text = "Total stock boletos comprados sin uso = " & String.Format("{0:###,###,###.00}", wTarifaSum - wProvSum)
        End If
    End Sub


    '    Private Sub dgBoleto_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgBoleto.SortCommand
    '   End Sub

    Private Sub lbtRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRemision.Click
        lblMsg.Text = "Falta selecionar boletos para Remisión"
        InsertaBoletos()

        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("bolStockCompradoRemision.aspx" & _
                            "?IdReg=" & sIdReg)
        End If
    End Sub

    Private Sub InsertaBoletos()
        Dim iNroPedido As Integer = 0
        Dim iPedidos As Integer = 0
        Dim iboletosVtaStk As Integer = 0

        'declaro un objeto de tipo ColumnaCheckBox la vinculo a la primera del datagrid respectivamente
        'Dim MiChkBox As ColumnaCheckBox = CType(dgBoleto.Columns(0), ColumnaCheckBox)
        Dim currentRowsFilePath As String

        Dim i As Integer = 0
        'declaro un objeto del tipo Seleccion (una estructura que contiene la llave primaria y el valor checked del checkbox)
        'Dim MiSeleccion As Seleccion
        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)

        'Cargando la Tabla Temporal
        'Session("IdReg") = CStr(Now)
        Dim wFchSys As Date = objRutina.FchSys
        sIdReg = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

        For index As Integer = 0 To dgBoleto.Rows.Count - 1
            'Programmatically access the CheckBox from the TemplateField
            Dim cb As CheckBox = CType(dgBoleto.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)

            If cb.Checked Then
                If Mid(dgBoleto.DataKeys(index).Value, 25, 10) <> iNroPedido Then
                    iPedidos = iPedidos + 1
                    iNroPedido = Mid(dgBoleto.DataKeys(index).Value, 25, 10)
                End If
                If Mid(dgBoleto.DataKeys(index).Value, 35, 1) <> 0 Then
                    iboletosVtaStk = iboletosVtaStk + 1
                End If

                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "BOL_StockCompradoSelec_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
                cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Mid(dgBoleto.DataKeys(index).Value, 1, 10)
                cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = Mid(dgBoleto.DataKeys(index).Value, 11, 4)
                cd.Parameters.Add("@Serie", SqlDbType.Int).Value = Mid(dgBoleto.DataKeys(index).Value, 15, 10)
                cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = Mid(dgBoleto.DataKeys(index).Value, 35, 1)
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblMsg.Text = cd.Parameters("@MsgTrans").Value
                Catch ex1 As System.Data.SqlClient.SqlException
                    lblMsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblMsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()
                If lblMsg.Text.Trim <> "OK" Then
                    Return
                End If
            End If
        Next

        lblNroPedido.Text = iNroPedido
        lblPedidos.Text = iPedidos
        lblBoletosVtaStk.Text = iboletosVtaStk
    End Sub

    Private Sub lbtConReembolso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtConReembolso.Click
        lblMsg.Text = "Falta selecionar boletos para Confirmar Reembolso"
        InsertaBoletos()

        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("bolStockCompradoReembolso.aspx" & _
                            "?IdReg=" & sIdReg)
        End If
    End Sub

    Private Sub lbtCambioVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambioVersion.Click
        lblMsg.Text = "Falta selecionar boletos para Cambiar de Versión"
        InsertaBoletos()

        If lblPedidos.Text > 1 Then
            lblMsg.Text = "Error, solo esta permitido seleccionar boletos de un Pedido"
            Return
        End If
        If lblBoletosVtaStk.Text > 0 Then
            lblMsg.Text = "Error, solo esta permitido seleccionar boletos con Cupon=0"
            Return
        End If
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("bolStockCompradoVersion.aspx" & _
                            "?IdReg=" & sIdReg & _
                            "&NroPedido=" & lblNroPedido.Text)
        End If
    End Sub

    Private Sub lbtSolReembolso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtSolReembolso.Click
        lblMsg.Text = "Falta selecionar boletos para hacer solicitud de Reembolso"
        InsertaBoletos()

        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("bolStockCompradoSolicitud.aspx" & _
                            "?IdReg=" & sIdReg)
        End If
    End Sub

    '    Private Sub dgBoleto_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgBoleto.ItemDataBound
    '       If e.Item.ItemType = ListItemType.Item Or _
    '         e.Item.ItemType = ListItemType.AlternatingItem Then
    '         If e.Item.Cells(11).Text.Trim = "S" Then
    '            e.Item.ForeColor = Color.Blue
    '       End If
    '    End If
    'End Sub


   

    Protected Sub dgBoleto_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBoleto.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgBoleto.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgBoleto.Rows
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

    Protected Sub dgBoleto_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgBoleto.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaBoletos()
    End Sub
End Class
