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

Partial Class cppCuadreObligaciones
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
            txtNomCliente.Text = Request.Params("NomCliente")

            If Viewstate("Opcion") = "Cuadre" Then
                Viewstate("NroPedido") = Request.Params("NroPedido")
                Viewstate("CodMoneda") = Request.Params("CodMoneda")
                If Viewstate("CodMoneda") = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If
            End If
            CargaDocumentos()
        End If
    End Sub

    Protected Sub dgDocumento_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumento.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgDocumento.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgDocumento.Rows
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

    Protected Sub dgDocumento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgDocumento.RowDataBound
        If IsNumeric(e.Row.Cells(5).Text) Then
            If e.Row.Cells(5).Text > 0 Then
                e.Row.Cells(5).ForeColor = Color.Red
            ElseIf e.Row.Cells(5).Text < 0 Then
                e.Row.Cells(5).ForeColor = Color.Blue
            End If
        End If
        If IsNumeric(e.Row.Cells(6).Text) Then
            If e.Row.Cells(6).Text > 0 Then
                e.Row.Cells(6).ForeColor = Color.Red
            ElseIf e.Row.Cells(6).Text < 0 Then
                e.Row.Cells(6).ForeColor = Color.Blue
            End If
        End If

    End Sub
    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        Response.Redirect("cppCuadreObligacionesDet.aspx" & _
            "?CodProveedor=" & ViewState("CodProveedor") & _
            "&NroPedido=" & dgDocumento.Rows(dgDocumento.SelectedIndex).Cells(1).Text & _
            "&CodMoneda=" & dgDocumento.Rows(dgDocumento.SelectedIndex).Cells(2).Text)
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaDocumentos()
    End Sub
    Private Sub CargaDocumentos()
        Dim wCodMoneda As String

        'Moneda
        If rbsoles.Checked Then
            wCodMoneda = "S"
        Else
            If rbdolar.Checked Then
                wCodMoneda = "D"
            End If
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CuadreObligaciones_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        da.SelectCommand.Parameters.Add("@FechaFinal", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        da.SelectCommand.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50).Value = Trim(txtNomCliente.Text) + "%"
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        'dgDocumento.DataKeyField = "KeyReg"
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()
        lblmsg.Text = CStr(nReg) + " Pendientes(s) de cuadre"

        If nReg > 0 Then
            lblmsg.Visible = True
            dgDocumento.Visible = True
            btnUnComprobante.Visible = True
            btnVariosComprobantes.Visible = True
        Else
            lblmsg.Visible = False
            dgDocumento.Visible = False
            btnUnComprobante.Visible = False
            btnVariosComprobantes.Visible = False
        End If

    End Sub

    Private Sub btnUnComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnComprobante.Click
        Dim wCheck As Boolean

        Dim wCodMoneda As String

        Dim wOrigen As String
        Dim wCantDoc As Integer = 0

        'Moneda
        If rbsoles.Checked Then
            wCodMoneda = "S"
        Else
            If rbdolar.Checked Then
                wCodMoneda = "D"
            End If
        End If

        wCheck = False
        Session("IdReg") = CStr(Now)

        Dim i As Integer = 0
        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then

                Dim MsgTrans As String
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPP_PendientesCuadre_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(ViewState("CodProveedor"))
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(RTrim(Mid(dgDocumento.DataKeys(index).Value, 1, 6)))
                cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Mid(dgDocumento.DataKeys(index).Value, 7, 1)

                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                    If Trim(lblmsg.Text) = "OK" Then

                        wCantDoc = wCantDoc + 1
                        wCheck = True
                    End If

                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()
            End If
        Next

        If wCheck Then
            ' wOrigen= 'A'  DPROVEEDOR 1 doc     --> COMPROBANTE 1 doc
            '               DPROVEEDOR 1 doc     --> COMPROBANTE varios doc
            ' wOrigen= 'V'  DPROVEEDOR Varios doc--> COMPROBANTE 1 doc
            '               DPROVEEDOR Varios doc--> COMPROBANTE varios doc
            If wCantDoc = 1 Then
                wOrigen = "A"
            Else
                wOrigen = "V"
            End If

            If Viewstate("Opcion") = "Cuadre" Then
                Response.Redirect("cppCuadreUnComprobante.aspx" & _
                    "?IdReg=" & Session("IdReg") & _
                    "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                    "&NroPedido=" & Viewstate("NroPedido") & _
                    "&CodMoneda=" & Viewstate("CodMoneda") & _
                    "&Origen=" & wOrigen & _
                    "&Opcion1=" & Viewstate("Opcion"))
            Else
                Response.Redirect("cppCuadreUnComprobante.aspx" & _
                    "?IdReg=" & Session("IdReg") & _
                    "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                    "&CodMoneda=" & wCodMoneda & _
                    "&Origen=" & wOrigen)
            End If
            'Else
            '    lblmsg.Text = "Falta seleccionar por lo menos un pedido"
        End If
    End Sub

    Private Sub btnVariosComprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVariosComprobantes.Click
        Dim wCheck As Boolean

        Dim wOrigen As String
        Dim wCantDoc As Integer = 0

        wCheck = False
        Dim wCodMoneda As String

        'Moneda
        If rbsoles.Checked Then
            wCodMoneda = "S"
        Else
            If rbdolar.Checked Then
                wCodMoneda = "D"
            End If
        End If

        Session("IdReg") = CStr(Now)

        Dim i As Integer = 0
        Dim currentRowsFilePath As String

        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPP_PendientesCuadre_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(ViewState("CodProveedor"))
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Mid(dgDocumento.DataKeys(index).Value, 1, 6))
                cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Mid(dgDocumento.DataKeys(index).Value, 7, 1)
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                    If Trim(lblmsg.Text) = "OK" Then

                        wCantDoc = wCantDoc + 1
                        wCheck = True
                    End If

                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()

            End If
        Next

        If wCheck Then
            ' wOrigen= 'A'  DPROVEEDOR 1 doc     --> COMPROBANTE 1 doc
            '               DPROVEEDOR 1 doc     --> COMPROBANTE varios doc
            ' wOrigen= 'V'  DPROVEEDOR Varios doc--> COMPROBANTE 1 doc
            '               DPROVEEDOR Varios doc--> COMPROBANTE varios doc
            If wCantDoc = 1 Then
                wOrigen = "A"
            Else
                wOrigen = "V"
            End If


            If Viewstate("Opcion") = "Cuadre" Then
                Response.Redirect("cppCuadreVComprobantes.aspx" & _
                    "?IdReg=" & Session("IdReg") & _
                    "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                    "&NroPedido=" & Viewstate("NroPedido") & _
                    "&CodMoneda=" & Viewstate("CodMoneda") & _
                    "&Origen=" & wOrigen & _
                    "&Opcion1=" & Viewstate("Opcion"))
            Else
                Response.Redirect("cppCuadreVComprobantes.aspx" & _
                    "?IdReg=" & Session("IdReg") & _
                    "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                    "&CodMoneda=" & wCodMoneda & _
                    "&Origen=" & wOrigen)
            End If
        Else
            lblmsg.Text = "Falta seleccionar por lo menos un pedido"
        End If
    End Sub

    Protected Sub dgDocumento_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dgDocumento.Sorting
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub
End Class
