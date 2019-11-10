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
Imports System.Transactions


Partial Class cppRegistraCredito
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            ViewState("CodCliente") = Request.Params("CodCliente")
            ViewState("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("FlagLiqDoc") = "N"  'Doc de periodos anteriores solo liq

            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                txtNroDocumento.Text = Viewstate("NroDocumento")
                EditaNroDocumento()
            Else
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            End If
            If Viewstate("NroVersion") > 0 Then
                Viewstate("TipoDocumento") = "NC"
                CargaTipoDocumento(False)
                txtPedido.Text = "Ajuste Pedido # " & CStr(Viewstate("NroPedido")) & " Version " & CStr(Viewstate("NroVersion"))
                CargaAbonos("P")
            Else
                cmdPedido.Visible = False
                CargaTipoDocumento(True)
                CargaAbonos("T")
            End If
        End If
    End Sub

    Private Sub EditaNroDocumento()
        CargaTipoDocumento(False)

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_NroDocumento_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtImporte.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If

                ' Si documento es de periodos anterios , solo puede liquidar
                If dr.GetValue(dr.GetOrdinal("FlagModifica")) = "N" Then
                    ViewState("FlagLiqDoc") = "S"
                    txtFchEmision.Enabled = False
                    txtReferencia.Enabled = False
                    txtImporte.Enabled = False
                    rbdolar.Enabled = False
                    rbsoles.Enabled = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub CargaTipoDocumento(ByVal ptodos As Boolean)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ptodos Then
            da.SelectCommand.CommandText = "TAB_TipoDocumentoAfectaCaja_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@AfectaCaja", SqlDbType.Char, 1).Value = "N"
        Else
            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        End If
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub
    Private Sub CargaAbonos(ByVal pOpcion As String)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If pOpcion = "T" Then
            da.SelectCommand.CommandText = "CPP_AbonosProveedor_S"
        Else
            da.SelectCommand.CommandText = "CPP_AbonosProveedorPedido_S"
            da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        End If
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documento")
        'dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds.Tables("Documento")
        dgServicio.DataBind()
        lblmsg.Text = CStr(nReg) + " Documento(s) encontrado(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click

        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = "Ingrese correctamente el Importe, es un dato numerico"
            Return
        End If
        CargaTempoAbono()
    End Sub

    Private Sub CargaTempoAbono()
        Dim i As Integer = 0
        Dim wMoneda, descripcion As String

        'Validacionde moneda
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        If wMoneda = "D" Then
            descripcion = "dolares"
        Else
            descripcion = "soles"
        End If

        lblmsg.Text = ""
        Dim currentRowsFilePath As String






        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                If wMoneda <> Mid(dgServicio.DataKeys(index).Value, 3, 1) Then
                    lblmsg.Text = "Seleccione Servicios con el  Tipo de moneda en " & descripcion
                    Return
                End If
            End If

        Next

        If Len(lblmsg.Text.Trim()) <> 0 Then
            Return
        End If

        'Cargando la Tabla Temporal

        Session("IdReg") = CStr(Now)
        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)

        For index As Integer = 0 To dgServicio.Rows.Count - 1
            Dim cb As CheckBox = CType(dgServicio.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd As New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPP_AbonosconSaldo_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Mid(dgServicio.DataKeys(index).Value, 1, 2)
                cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Mid(dgServicio.DataKeys(index).Value, 4, 9))
                cd.Parameters.Add("@Pago", SqlDbType.Money).Value = 0
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
            End If
        Next
        GrabaCredito()
    End Sub

    Private Sub GrabaCredito()




        Dim procesado As Boolean = False
        Dim sMensajeError As String = ""
        Dim sResultado As String = ""

        Using transScope As New TransactionScope

            Try

                Dim cd As New SqlCommand

                '-----------------------------------------------------
                'Validaciones (si esta facturado y si pertenece a un periodo anterior, si de vuelve ok en los 4 botones no debe dejar procesar)
                '-----------------------------------------------------
                cd.Connection = cn
                cd.CommandType = CommandType.StoredProcedure
                cd.CommandText = "SYS_ValidarFacturacion_S"

                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
                cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
                cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
                cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
                cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

                cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    sResultado = cd.Parameters("@MsgTrans").Value
                Catch ex1 As SqlException
                    sResultado = "Error: " & ex1.Message
                Catch ex2 As Exception
                    sResultado = "Error: " & ex2.Message
                Finally
                    cn.Close()
                End Try

                If sResultado.Trim().Equals("OK") Then
                    Throw New Exception("Error: El pedido pertecene a un periodo anterior y no puede aplicarse eta operación, primero tiene que migrar el pedido al periodo actual.")
                End If

                '-----------------------------------------------------
                'Procesar ajuste
                '-----------------------------------------------------

                Dim wMoneda As String
                Dim MsgTrans As String
                Dim wNroDoc As String

                Dim wNroDocumento As Integer
                If ViewState("NroDocumento") > 0 Then
                    wNroDocumento = ViewState("NroDocumento")
                Else
                    wNroDocumento = 0
                End If

                Dim wNroPedido, wNroPro, wNroVer As Integer
                If ViewState("NroVersion") > 0 Then
                    wNroPedido = ViewState("NroPedido")
                    wNroPro = ViewState("NroPropuesta")
                    wNroVer = ViewState("NroVersion")
                Else
                    wNroPedido = 0
                    wNroPro = 0
                    wNroVer = 0
                End If
                If rbdolar.Checked Then
                    wMoneda = "D"
                Else
                    wMoneda = "S"
                End If


                cd = New SqlCommand
                cd.Connection = cn
                cd.CommandText = "CPP_RegistraCredito_I"
                cd.CommandType = CommandType.StoredProcedure

                Dim pa As New SqlParameter
                pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa.Direction = ParameterDirection.Output
                pa.Value = ""
                pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
                pa.Direction = ParameterDirection.Output
                pa.Value = 0

                cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ViewState("CodProveedor")
                cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
                cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
                cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
                cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
                cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
                cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
                cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtImporte.Text
                cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
                cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = wNroPro
                cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = wNroVer
                cd.Parameters.Add("@RegistraND", SqlDbType.Char, 1).Value = "S" 'Registra automaticamente ND para Liq.
                cd.Parameters.Add("@FlagLiqDoc", SqlDbType.Char, 1).Value = ViewState("FlagLiqDoc") 'Indica que solo va hacer liquidacion de documento
                cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                Try
                    cn.Open()
                    cd.ExecuteNonQuery()
                    lblmsg.Text = cd.Parameters("@MsgTrans").Value
                    wNroDoc = cd.Parameters("@NroDoc").Value
                Catch ex1 As System.Data.SqlClient.SqlException
                    lblmsg.Text = "Error:" & ex1.Message
                Catch ex2 As System.Exception
                    lblmsg.Text = "Error:" & ex2.Message
                End Try
                cn.Close()

                If Trim(lblmsg.Text) = "OK" Then
                    transScope.Complete()
                    procesado = True
                Else
                    Throw New Exception(lblmsg.Text)
                End If

                'If Trim(lblmsg.Text) = "OK" Then
                '    Response.Redirect("cppDocumento.aspx" &
                '            "?CodProveedor=" & ViewState("CodProveedor"))
                'End If



            Catch ex As Exception
                transScope.Dispose()
                procesado = False
                sMensajeError = ex.Message
            End Try



        End Using



        If (procesado) Then
            Response.Redirect("cppDocumento.aspx" & "?CodProveedor=" & ViewState("CodProveedor"))

        Else
            Response.Write(String.Format("<script type='text/javascript'>alert('{0}');</script>", sMensajeError))
        End If




        'Dim wMoneda As String
        'Dim MsgTrans As String
        'Dim wNroDoc As String

        'Dim wNroDocumento As Integer
        'If ViewState("NroDocumento") > 0 Then
        '    wNroDocumento = ViewState("NroDocumento")
        'Else
        '    wNroDocumento = 0
        'End If

        'Dim wNroPedido, wNroPro, wNroVer As Integer
        'If ViewState("NroVersion") > 0 Then
        '    wNroPedido = ViewState("NroPedido")
        '    wNroPro = ViewState("NroPropuesta")
        '    wNroVer = ViewState("NroVersion")
        'Else
        '    wNroPedido = 0
        '    wNroPro = 0
        '    wNroVer = 0
        'End If
        'If rbdolar.Checked Then
        '    wMoneda = "D"
        'Else
        '    wMoneda = "S"
        'End If


        'Dim cd As New SqlCommand
        'cd.Connection = cn
        'cd.CommandText = "CPP_RegistraCredito_I"
        'cd.CommandType = CommandType.StoredProcedure

        'Dim pa As New SqlParameter
        'pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        'pa.Direction = ParameterDirection.Output
        'pa.Value = ""
        'pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        'pa.Direction = ParameterDirection.Output
        'pa.Value = 0

        'cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        'cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ViewState("CodProveedor")
        'cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        'cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        'cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
        'cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        'cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
        'cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        'cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtImporte.Text
        'cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
        'cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = wNroPro
        'cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = wNroVer
        'cd.Parameters.Add("@RegistraND", SqlDbType.Char, 1).Value = "S" 'Registra automaticamente ND para Liq.
        'cd.Parameters.Add("@FlagLiqDoc", SqlDbType.Char, 1).Value = ViewState("FlagLiqDoc") 'Indica que solo va hacer liquidacion de documento
        'cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        'Try
        '    cn.Open()
        '    cd.ExecuteNonQuery()
        '    lblmsg.Text = cd.Parameters("@MsgTrans").Value
        '    wNroDoc = cd.Parameters("@NroDoc").Value
        'Catch ex1 As System.Data.SqlClient.SqlException
        '    lblmsg.Text = "Error:" & ex1.Message
        'Catch ex2 As System.Exception
        '    lblmsg.Text = "Error:" & ex2.Message
        'End Try
        'cn.Close()
        'If Trim(lblmsg.Text) = "OK" Then
        '    Response.Redirect("cppDocumento.aspx" &
        '            "?CodProveedor=" & ViewState("CodProveedor"))
        'End If
    End Sub

    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        rbsoles.Checked = False
        rbdolar.Checked = True
    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        rbsoles.Checked = True
        rbdolar.Checked = False
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        If IsNumeric(txtImporte.Text) Then
            txtImporte.Text = Math.Round(CDbl(txtImporte.Text), 2)
        End If
    End Sub

    Private Sub cmdTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTodos.Click
        CargaAbonos("T")
    End Sub

    Private Sub cmdPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPedido.Click
        CargaAbonos("P")
    End Sub



    Protected Sub dgServicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicio.DataBound
        Dim ArrayValues As New List(Of String)

        Try
            Dim cbHeader As CheckBox = CType(dgServicio.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))
        Catch ex As Exception

        End Try

        For Each gvr As GridViewRow In dgServicio.Rows
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
End Class
