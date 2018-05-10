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
Imports Microsoft.ApplicationBlocks.Data

Partial Class cpcRegistraPago
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim wTotalSum As Double = 0


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            CantNotasAbono()
            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                EditaNroDocumento()
            Else
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
                CargaTipoDocumento(True)
                CargaBanco(" ")
                CargaPedido(0)
            End If
            CargaCargos()
        End If
    End Sub

    Private Sub EditaNroDocumento()
        txtNroDocumento.Text = Viewstate("NroDocumento")
        CargaTipoDocumento(False)

        Dim wcodbanco, wsecbanco As String
        Dim wnropedido As Integer

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_NroDocumento_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtGlosa.Text = dr.GetValue(dr.GetOrdinal("GlosaDocumento"))
                txtCodAutoriza.Text = dr.GetValue(dr.GetOrdinal("CodAutoriza"))
                txtImporte.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DocMonto")))
                If dr.GetValue(dr.GetOrdinal("DocMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If

                txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("tipocambio"))
                txtPagoCliente.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    lblSimbolo.Text = "Dolares"
                Else
                    lblSimbolo.Text = "Soles"
                End If

                wcodbanco = dr.GetValue(dr.GetOrdinal("codbanco"))
                wsecbanco = dr.GetValue(dr.GetOrdinal("secbanco"))
                wnropedido = dr.GetValue(dr.GetOrdinal("nropedido"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaBanco(wcodbanco)
        CargaNroCuenta(wcodbanco, wsecbanco)
        CargaPedido(wnropedido)
    End Sub

    Private Sub CargaTipoDocumento(ByVal pTodos As Boolean)
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If pTodos Then
            da.SelectCommand.CommandText = "TAB_TipoDocumentoAfectaCaja_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = "A"
            da.SelectCommand.Parameters.Add("@AfectaCaja", SqlDbType.Char, 1).Value = "S"
        Else
            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        End If
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub

    Private Sub CargaBanco(ByVal pCodBanco As String)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_BancoActivo_S")
        ddlBanco.DataSource = ds.Tables(0)
        ddlBanco.DataBind()
        If pCodBanco.Trim.Length > 0 Then
            ddlBanco.Items.FindByValue(pCodBanco).Selected = True
        End If

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, " ")
        Else
            CargaNroCuenta(" ", " ")
        End If
    End Sub

    Private Sub CargaNroCuenta(ByVal pcodBanco As String, _
                                ByVal psecBanco As String)
        Dim wDocMoneda As String
        If rbdolar.Checked Then
            wDocMoneda = "D"
        Else
            wDocMoneda = "S"
        End If

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodBanco", SqlDbType.Char, 3)
        arParms(0).Value = pcodBanco
        arParms(1) = New SqlParameter("@CodMoneda", SqlDbType.Char, 1)
        arParms(1).Value = wDocMoneda

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_BancoCuenta_S", arParms)
        ddlNroCuenta.DataSource = ds.Tables(0)
        ddlNroCuenta.DataBind()

        If psecBanco.Trim.Length > 0 Then
            ddlNroCuenta.Items.FindByValue(psecBanco).Selected = True
        End If
    End Sub


    Private Sub CargaCargos()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_CargosCliente_S", New SqlParameter("@CodCliente", Viewstate("CodCliente")))
        'dgDocumento.DataKeyField = "KeyReg"
        dgDocumento.DataSource = ds.Tables(0)
        dgDocumento.DataBind()
    End Sub

    Private Sub CargaPedido(ByVal pNroPedido As Integer)
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodCliente", SqlDbType.Int)
        arParms(0).Value = Viewstate("CodCliente")
        arParms(1) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(1).Value = pNroPedido

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_PedidosCliente_S", arParms)
        ddlNumeroPedido.DataSource = ds.Tables(0)
        ddlNumeroPedido.DataBind()
        If pNroPedido = 0 Then
            ddlNumeroPedido.Items.Insert(0, New ListItem("Elegir Pedido"))
            ddlNumeroPedido.Items.FindByValue("Elegir Pedido").Selected = True
        Else
            ddlNumeroPedido.Items.FindByValue(pNroPedido).Selected = True
        End If
    End Sub


    Private Sub CalculaPagoCliente()
        Dim wImporte, wTipoCambio, wTotal As Double

        If Len(Trim(txtImporte.Text)) = 0 Then
            wImporte = 0
        Else
            If IsNumeric(txtImporte.Text) Then
                txtImporte.Text = Math.Round(CDbl(txtImporte.Text), 2)
                wImporte = txtImporte.Text
            Else
                lblmsg.Text = "Importe es dato númerico"
                Return
            End If
        End If

        If Len(Trim(txtTipoCambio.Text)) = 0 Then
            wTipoCambio = 0
        Else
            If IsNumeric(txtTipoCambio.Text) Then
                wTipoCambio = txtTipoCambio.Text
            Else
                lblmsg.Text = "Tipo Cambio es dato númerico"
                Return
            End If
        End If


        If wTipoCambio = 0 Then
            txtPagoCliente.Text = txtImporte.Text
            If rbdolar.Checked Then
                lblSimbolo.Text = "Dolares"
            Else
                lblSimbolo.Text = "Soles"
            End If
        Else
            If rbdolar.Checked Then
                lblSimbolo.Text = "Soles"
                txtPagoCliente.Text = wImporte * wTipoCambio
                txtPagoCliente.Text = Math.Round(CDbl(txtPagoCliente.Text), 2)
            Else
                lblSimbolo.Text = "Dolares"
                txtPagoCliente.Text = wImporte / wTipoCambio
                txtPagoCliente.Text = Math.Round(CDbl(txtPagoCliente.Text), 2)
            End If
        End If
    End Sub


    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        rbsoles.Checked = False
        rbdolar.Checked = True
        CalculaPagoCliente()

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, " ")
        Else
            CargaNroCuenta(" ", " ")
        End If
    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        rbsoles.Checked = True
        rbdolar.Checked = False

        CalculaPagoCliente()

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, " ")
        Else
            CargaNroCuenta(" ", " ")
        End If
    End Sub


    Private Sub ddlBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBanco.SelectedIndexChanged
        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, " ")
        Else
            CargaNroCuenta(" ", " ")
        End If

    End Sub


    Private Sub txtTipoCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged
        CalculaPagoCliente()
    End Sub


    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        CalculaPagoCliente()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = "Importe es un dato numerico"
            Return
        End If

        If ddlNumeroPedido.SelectedItem.Value = "Elegir Pedido" Then
            lblmsg.Text = "Nro. Pedido es obligatorio"
            Return
        End If

        Dim i As Integer = 0
        Dim currentRowsFilePath As String
        lblmsg.Text = ""

        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                If Mid(lblSimbolo.Text, 1, 1) <> Mid(dgDocumento.DataKeys(index).Value, 13, 1) Then
                    lblmsg.Text = "Seleccione Servicios con el  Tipo de moneda en " & lblSimbolo.Text
                    Return
                End If
            End If

        Next
        If Len(lblmsg.Text.Trim()) <> 0 Then
            'error en moneda    
            Return
        End If

        '2) Cargando la Tabla Temporal
        Dim MsgTrans As String

        Session("IdReg") = CStr(Now)
        'itero a traves de todas las llave primarias, y recupero su valor checked (true o false)
        For index As Integer = 0 To dgDocumento.Rows.Count - 1
            Dim cb As CheckBox = CType(dgDocumento.Rows(index).FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked Then
                Dim cd1 As New SqlCommand
                cd1.Connection = cn
                cd1.CommandText = "CPC_CargosconSaldo_I"
                cd1.CommandType = CommandType.StoredProcedure

                Dim pa1 As New SqlParameter
                pa1 = cd1.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                pa1.Direction = ParameterDirection.Output
                pa1.Value = ""
                cd1.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
                cd1.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Mid(dgDocumento.DataKeys(index).Value, 1, 2)
                cd1.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Mid(dgDocumento.DataKeys(index).Value, 3, 10))
                cd1.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                cn.Open()
                cd1.ExecuteNonQuery()
                lblmsg.Text = cd1.Parameters("@MsgTrans").Value
                cn.Close()
            End If
        Next


        '3) Graba el Documento de Pago
        Dim wDocMoneda, wCodMoneda As String
        Dim wNroDoc As String
        Dim wCambio As Double
        Dim WNroPedido As String

        WNroPedido = CStr(ddlNumeroPedido.SelectedItem.Value)

        If rbdolar.Checked Then
            wDocMoneda = "D"
        Else
            wDocMoneda = "S"
        End If

        If lblSimbolo.Text = "Dolares" Then
            wCodMoneda = "D"
        Else
            wCodMoneda = "S"
        End If

        If Len(Trim(txtTipoCambio.Text)) = 0 Then
            wCambio = 0
        Else
            wCambio = CDbl(txtTipoCambio.Text)
        End If

        Dim wNroDocumento As Integer
        If ViewState("NroDocumento") > 0 Then
            wNroDocumento = ViewState("NroDocumento")
        Else
            wNroDocumento = 0
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_RegistraPagos_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Session("IdReg")
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = ddlBanco.SelectedItem.Value
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = ddlNroCuenta.SelectedItem.Value
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = txtFchEmision.Text.Substring(6, 4) + txtFchEmision.Text.Substring(3, 2) + txtFchEmision.Text.Substring(0, 2)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = txtGlosa.Text
        cd.Parameters.Add("@CodAutoriza", SqlDbType.VarChar, 20).Value = txtCodAutoriza.Text
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtPagoCliente.Text
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = wCambio
        cd.Parameters.Add("@DocMoneda", SqlDbType.Char, 1).Value = wDocMoneda
        cd.Parameters.Add("@DocMonto", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(WNroPedido)
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
        If lblmsg.Text.Trim = "OK" Then
            CargaCargos()
            txtReferencia.Text = ""
            txtImporte.Text = ""
            txtFchEmision.Text = ""
            wNroDoc = cd.Parameters("@NroDoc").Value

            Response.Redirect("cpcDocumento.aspx" & _
                "?CodCliente=" & ViewState("CodCliente"))
        End If
    End Sub


    Private Sub CantNotasAbono()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_CantNAxCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNA.Text = "Cliente tiene " & dr.GetValue(dr.GetOrdinal("CantNA")) & " Nota(s) Abono pendiente"
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
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
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Saldo"))
            wTotalSum += wTotal
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).Text = "Total: " & String.Format("{0:###,###,###,###.00}", wTotalSum)
        End If
    End Sub
End Class
