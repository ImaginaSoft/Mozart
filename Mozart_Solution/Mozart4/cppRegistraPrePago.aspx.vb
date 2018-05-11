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

Partial Class cppRegistraPrePago
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim sIdReg As String
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                txtEstado.Visible = True
                lblEstado.Visible = True
                EditaNroDocumento()
            Else
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtEstado.Visible = False
                lblEstado.Visible = False
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
                CargaTipoDocumento(True)
                CargaBanco(" ")
            End If
            CargaAbonos()
        End If

    End Sub

    Private Sub EditaNroDocumento()
        txtNroDocumento.Text = Viewstate("NroDocumento")

        CargaTipoDocumento(False)

        Dim wcodbanco, wsecbanco As String
        Dim wnropedido As Integer
        Dim tipoCambio As Double

        Dim cd As New SqlCommand
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
                txtImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("DocMonto")))
                If dr.GetValue(dr.GetOrdinal("DocMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If

                tipoCambio = CDbl(dr.GetValue(dr.GetOrdinal("tipocambio")))
                If tipoCambio = 0 Then
                    txtTipoCambio.Text = ""
                Else
                    txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("tipocambio"))
                End If
                txtPagoCliente.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    lblSimbolo.Text = "Dolares"
                Else
                    lblSimbolo.Text = "Soles"
                End If

                wcodbanco = dr.GetValue(dr.GetOrdinal("codbanco"))
                wsecbanco = dr.GetValue(dr.GetOrdinal("secbanco"))
                wnropedido = dr.GetValue(dr.GetOrdinal("nropedido"))
                txtEstado.Text = dr.GetValue(dr.GetOrdinal("StsDocumento"))

                If txtEstado.Text.Equals("L") Then
                    cmdGrabar.Enabled = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaBanco(wcodbanco)
        CargaNroCuenta(wcodbanco)
    End Sub
    Private Sub CargaTipoDocumento(ByVal pTodos As Boolean)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If pTodos Then
            da.SelectCommand.CommandText = "TAB_TipoDocumentoAfectaCaja_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = "C"
            da.SelectCommand.Parameters.Add("@AfectaCaja", SqlDbType.Char, 1).Value = "S"
        Else
            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        End If
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub

    Private Sub CargaBanco(ByVal pCodBanco As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoActivo_S"
        da.Fill(ds, "TBanco")
        ddlBanco.DataSource = ds.Tables("TBanco")
        ddlBanco.DataBind()
        If pCodBanco.Trim.Length > 0 Then
            ddlBanco.Items.FindByValue(pCodBanco).Selected = True
        End If

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value)
        Else
            CargaNroCuenta(" ")
        End If
    End Sub


    Private Sub CargaAbonos()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_AbonosProveedor_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documento")
        dgDocumento.DataKeyField = "KeyReg"
        dgDocumento.DataSource = ds.Tables("Documento")
        dgDocumento.DataBind()
        lblmsg.Text = CStr(nReg) + " Documento(s) encontrado(s)"
    End Sub
    Private Sub CargaNroCuenta(ByVal pcodBanco As String)
        Dim wDocMoneda As String
        If rbdolar.Checked Then
            wDocMoneda = "D"
        Else
            wDocMoneda = "S"
        End If

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoCuenta_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wDocMoneda
        da.Fill(ds, "TBancoCuenta")
        ddlNroCuenta.DataSource = ds.Tables("TBancoCuenta")
        ddlNroCuenta.DataBind()
    End Sub

    Private Sub CalculaImporte()

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
                '  txtTipoCambio.Text = Math.Round(CDbl(txtTipoCambio.Text), 2)
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
        Dim wpcodBanco As String

        rbsoles.Checked = False
        rbdolar.Checked = True
        CalculaImporte()

        If ddlBanco.Items.Count > 0 Then
            wpcodBanco = ddlBanco.SelectedItem.Value
            CargaNroCuenta(wpcodBanco)
        End If

    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        Dim wpcodBanco, wMoneda As String

        rbsoles.Checked = True
        rbdolar.Checked = False
        CalculaImporte()

        If ddlBanco.Items.Count > 0 Then
            wpcodBanco = ddlBanco.SelectedItem.Value
            CargaNroCuenta(wpcodBanco)
        End If

    End Sub


    Private Sub ddlBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBanco.SelectedIndexChanged
        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value)
        Else
            CargaNroCuenta(" ")
        End If

    End Sub


    Private Sub txtTipoCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged
        CalculaImporte()
    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblmsg.Text = ""
    End Sub

    Private Sub txtFchEmision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblmsg.Text = " "
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        CalculaImporte()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblMsg.Text = "Ingrese correctamente el importe, es un dato numerico"
            Return
        End If

        Dim wMoneda, wdescripcion, wMonedaCom As String
        wMonedaCom = Trim(lblSimbolo.Text)
        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        If wMoneda = "D" Then
            wdescripcion = "dolares"
        Else
            wdescripcion = "soles"
        End If
        If wMonedaCom = "Dolares" Then
            wdescripcion = "dolares"
            wMonedaCom = "D"
        Else
            wdescripcion = "soles"
            wMonedaCom = "S"
        End If


        lblMsg.Text = ""
        lblMsg.CssClass = "error"
        Dim dTotPago As Double = 0.0
        Dim dPago As Double = 0.0
        Dim dSaldo As Double = 0.0
        Dim sCodMoneda, sTipoDocumento, sPago As String
        Dim iNroDocumento As Integer
        Dim objItem As DataGridItem

        For Each objItem In dgDocumento.Items
            If objItem.ItemType <> ListItemType.Header And objItem.ItemType <> ListItemType.Footer And objItem.ItemType <> ListItemType.Pager Then
                sPago = CType(objItem.Cells(7).FindControl("txtPago"), TextBox).Text
                sCodMoneda = CType(objItem.Cells(6).FindControl("Moneda"), Label).Text.Substring(0, 1)
                If IsNumeric(sPago) Then
                    dPago = sPago
                    dSaldo = CType(objItem.Cells(5).FindControl("Saldo"), Label).Text
                    dTotPago = dTotPago + dPago
                    If wMonedaCom <> sCodMoneda Then
                        lblMsg.Text = "Error, Realice Pre-Pagos en servicios con el tipo de moneda en " & wdescripcion
                        Return
                    End If
                    If dPago > dSaldo Then
                        lblMsg.Text = "Error, monto del Pre-Pago=" & CStr(dPago) & " debe ser menor o igual al Saldo=" & CStr(dSaldo)
                        Return
                    End If
                End If
            End If
        Next
        dTotPago = Math.Round(dTotPago, 5)
        If dTotPago > CDbl(txtImporte.Text) Then
            lblMsg.Text = "Error, la suma de los Pre-Pagos=" & CStr(dTotPago) & " debe ser menor o igual al Importe Pago=" & txtImporte.Text
        End If
        If Len(lblMsg.Text.Trim()) <> 0 Then
            Return
        End If

        'Cargando la Tabla Temporal
        sIdReg = Mid(CStr(Now) & Session("CodUsuario"), 1, 25)
        For Each objItem In dgDocumento.Items
            If objItem.ItemType <> ListItemType.Header And objItem.ItemType <> ListItemType.Footer And objItem.ItemType <> ListItemType.Pager Then
                sTipoDocumento = CType(objItem.Cells(1).FindControl("TipoDocumento"), Label).Text
                iNroDocumento = CType(objItem.Cells(2).FindControl("NroDocumento"), Label).Text
                sPago = CType(objItem.Cells(7).FindControl("txtPago"), TextBox).Text
                If IsNumeric(sPago) Then
                    dPago = sPago
                    If dPago > 0 Then
                        Dim MsgTrans As String
                        Dim cd As New SqlCommand
                        cd.Connection = cn
                        cd.CommandText = "CPP_AbonosconSaldo_I"
                        cd.CommandType = CommandType.StoredProcedure

                        Dim pa As New SqlParameter
                        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                        pa.Direction = ParameterDirection.Output
                        pa.Value = ""
                        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
                        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = sTipoDocumento
                        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = iNroDocumento
                        cd.Parameters.Add("@Pago", SqlDbType.Money).Value = dPago
                        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
                        cn.Open()
                        cd.ExecuteNonQuery()
                        lblMsg.Text = cd.Parameters("@MsgTrans").Value
                        cn.Close()
                        If lblMsg.Text.Trim <> "OK" Then
                            Return
                        End If
                    End If
                End If
            End If
        Next

        If lblMsg.Text.Trim <> "OK" Then
            Return
        End If

        GrabaPagos()

        txtFchEmision.Text = objRutina.fechaddmmyyyy(0)
    End Sub

    Private Sub GrabaPagos()
        Dim wMoneda, wMoneda1 As String
        Dim wNroDoc As String
        Dim wCambio As Double

        Dim wNroDocumento As Integer
        If Viewstate("NroDocumento") > 0 Then
            wNroDocumento = Viewstate("NroDocumento")
        Else
            wNroDocumento = 0
        End If
        Dim WNroPedido As String

        WNroPedido = 0

        If (WNroPedido.Equals("Elegir Pedido")) Then
            WNroPedido = "0"
        End If
        If lblSimbolo.Text = "Dolares" Then
            wMoneda1 = "D"
        Else
            wMoneda1 = "S"
        End If

        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        If Len(Trim(txtTipoCambio.Text)) = 0 Then
            wCambio = 0
        Else
            wCambio = CDbl(txtTipoCambio.Text)
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_RegistraPrePagos_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = ddlBanco.SelectedItem.Value
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = ddlNroCuenta.SelectedItem.Value
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = txtFchEmision.Text.Substring(6, 4) + txtFchEmision.Text.Substring(3, 2) + txtFchEmision.Text.Substring(0, 2)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda1
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtPagoCliente.Text
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = wCambio
        cd.Parameters.Add("@DocMoneda", SqlDbType.Char, 1).Value = wMoneda
        cd.Parameters.Add("@DocMonto", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = WNroPedido
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
            CargaAbonos()
            txtReferencia.Text = ""
            txtImporte.Text = ""
            txtFchEmision.Text = ""
            lblmsg.Text = "Se grabo correctamente Documento " & ddlTipoDocumento.SelectedItem.Value & " " & wNroDoc
            Response.Redirect("cppDocumento.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor"))
        End If
    End Sub

End Class
