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

Partial Class cppDocumentoDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("Nombre") = Request.Params("Nombre")
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("Tabla") = Request.Params("Tabla")
            Viewstate("TipoOperacion") = Request.Params("TipoOperacion")
            Viewstate("estado") = Request.Params("estado")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("Correlativo") = Request.Params("Correlativo")
            Viewstate("CodCuenta") = Request.Params("CodCuenta")
            Viewstate("Origen") = Request.Params("Origen")

            'cargamos Data
            If Viewstate("TipoDocumento") = "RH" Then
                lblNomIgv.Text = "Retención"
            Else
                lblNomIgv.Text = "IGV"
            End If
            lblNroComprobante.Text = Request.Params("NroComprobante")
            lblTipoDocumento.Text = Viewstate("TipoDocumento")
            lblNumeroDocumento.Text = Viewstate("NroDocumento")
            lblNombre.Text = Viewstate("Nombre")
            CargaGasto()
            If Viewstate("Tabla") = "P" Then
                CargaDocumentoProveedor()
                ' cmdLiquida.Visible = False
            Else
                If Viewstate("Tabla") = "B" Then
                    CargaDocumentoBanco()
                    'cmdLiquida.Visible = True
                End If
            End If
            If Viewstate("TipoOperacion") = "Abono" Or _
               Viewstate("TipoOperacion") = "A" Then
                ' si estamos editado un abono (deuda) se cargan los pagos
                CargaPagos()
            Else
                If Viewstate("TipoOperacion") = "Cargo" Or _
                   Viewstate("TipoOperacion") = "C" Then
                    ' si estamos editado un cargo (pago) se cargan las deudas
                    CargaDeudas()
                End If
            End If

            If Mid(lblStsDoc.Text, 1, 1) = "A" Then
                cmdAnularLiqu.Visible = True
                cmdLiquida.Visible = False
                cmdModifDoc.Visible = True
                cmdAnularDoc.Visible = True

                cmdAnularLiqu.Enabled = False
                cmdModifDoc.Enabled = False
                cmdAnularDoc.Enabled = False

                lblmsg.Text = "El documento esta Anulado"
            Else
                'V=Ventas   D=Deposito TC   N=Notas Credito/Debito LAN
                If Viewstate("Origen") = "V" Or _
                   Viewstate("Origen") = "D" Or _
                   Viewstate("Origen") = "N" Then
                    cmdAnularLiqu.Visible = False
                    cmdLiquida.Visible = False
                    cmdModifDoc.Visible = False
                    cmdAnularDoc.Visible = False

                    cmdAnularLiqu.Enabled = False
                    cmdModifDoc.Enabled = False
                    cmdAnularDoc.Enabled = False

                    If Viewstate("Origen") = "V" Then
                        lblmsg.Text = "Documento fue generado en Ventas, no se puede modificar"
                    ElseIf Viewstate("Origen") = "D" Then
                        lblmsg.Text = "Documento fue generado en Deposito TC, no se puede modificar"
                    ElseIf Viewstate("Origen") = "N" Then
                        lblmsg.Text = "Documento fue generado para liquidar saldos Proveedor LAN, no se puede modificar"
                    End If
                End If
            End If
        End If


        If Viewstate("estado") = "Anulado" Or Viewstate("estado") = "A" Then

            cmdAnularLiqu.Visible = True
            cmdLiquida.Visible = False
            cmdModifDoc.Visible = True
            cmdAnularDoc.Visible = True

            cmdAnularLiqu.Enabled = False
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False

            lblmsg.Text = "Este Documento esta anulado"
            Return
        End If

        If Viewstate("TipoDocumento") = "RE" Then
            'no se puede modificar un reporte de ventas
            cmdModifDoc.Visible = False
            cmdModifDoc.Enabled = False
        End If

    End Sub
    Private Sub CargaDeudas()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CargaDeudas_S"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        da.SelectCommand.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "Deudas")
        If nReg = 0 Then
            cmdAnularLiqu.Visible = False
            cmdModifDoc.Visible = True
            cmdAnularDoc.Visible = True
            dgDocumentos.Visible = False
            lblmsg.Text = " "
        Else
            dgDocumentos.DataSource = ds.Tables("Deudas")
            dgDocumentos.DataBind()
            cmdAnularLiqu.Visible = True
            cmdModifDoc.Visible = False
            cmdAnularDoc.Visible = False
            dgDocumentos.Visible = True
            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If
    End Sub
    Private Sub CargaPagos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CargaPagos_S"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        da.SelectCommand.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "Pagos")
        If nReg = 0 Then
            cmdAnularLiqu.Visible = False
            cmdModifDoc.Visible = True
            cmdAnularDoc.Visible = True
            dgDocumentos.Visible = False
            lblmsg.Text = " "
        Else
            dgDocumentos.DataSource = ds.Tables("Pagos")
            dgDocumentos.DataBind()
            cmdAnularLiqu.Visible = True
            cmdModifDoc.Visible = False
            cmdAnularDoc.Visible = False
            dgDocumentos.Visible = True
            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If
    End Sub
    Private Sub CargaGasto()
        If Viewstate("CodCuenta") = "" Then
            Return
        End If

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_CuentaEdita_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = Viewstate("CodCuenta")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblCodGasto.Text = ViewState("CodCuenta") & " " & dr.GetValue(dr.GetOrdinal("NomCuenta"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub CargaDocumentoBanco()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpp_BancoDocProveedorDet_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Trim(Viewstate("TipoDocumento"))
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Viewstate("NroDocumento"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()

                lblFchSys.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("DesPedido")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lblImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("DocMonto")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("DocMoneda")))
                lblMoneda5.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
                lblTipoCambio.Text = CStr(dr.GetValue(dr.GetOrdinal("TipoCambio")))
                lblTotal.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total")))
                lblSaldo.Text = ToString.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Saldo")))
                lblStsDoc.Text = CStr(dr.GetValue(dr.GetOrdinal("StsDocumento")))
                lblNomBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("NomBanco")))
                lblNroCuenta.Text = CStr(dr.GetValue(dr.GetOrdinal("NroCuenta")))
                lblFlagBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("FlagBanco")))
                If dr.GetValue(dr.GetOrdinal("TipoCambio")) = 0 Then
                    lblTipoCambio.Visible = True
                    lblTipoCambio.Visible = True
                End If

                If dr.GetValue(dr.GetOrdinal("Saldo")) = 0 Then
                    cmdLiquida.Visible = False
                Else
                    cmdLiquida.Visible = True
                End If

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub CargaDocumentoProveedor()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpp_ProveedorDocDet_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Trim(Viewstate("TipoDocumento"))
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Viewstate("NroDocumento"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblFchSys.Text = CStr(dr.GetValue(dr.GetOrdinal("FchEmision")))
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("DesPedido")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lblImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Importe")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("Moneda")))
                lblMoneda5.Text = CStr(dr.GetValue(dr.GetOrdinal("Moneda")))
                IGV.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("IGV")))
                lblOtros.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Otros")))
                lblTotal.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total")))
                lblSaldo.Text = ToString.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Saldo")))
                lblStsDoc.Text = CStr(dr.GetValue(dr.GetOrdinal("DesStsDocumento")))

                If dr.GetValue(dr.GetOrdinal("Saldo")) > 0 And dr.GetValue(dr.GetOrdinal("TipoOperacion")) = "C" Then
                    cmdLiquida.Visible = True
                Else
                    cmdLiquida.Visible = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If Math.Round(CDbl(lblSaldo.Text), 0) = 0 Then
            cmdLiquida.Visible = False
        End If
    End Sub
    Private Sub cmdAnularLiqu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularLiqu.Click
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CPP_AnulaLiquidacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = Viewstate("TipoOperacion")
        cd.Parameters.Add("@Tabla", SqlDbType.Char, 1).Value = Trim(Viewstate("Tabla"))
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
            Response.Redirect("cppDocumentoDet.aspx" & _
            "?CodProveedor=" & Viewstate("CodProveedor") & _
            "&Nombre=" & Viewstate("Nombre") & _
            "&TipoDocumento=" & Viewstate("TipoDocumento") & _
            "&NroDocumento=" & Viewstate("NroDocumento") & _
            "&Tabla=" & Viewstate("Tabla") & _
            "&TipoOperacion=" & Viewstate("TipoOperacion") & _
            "&NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion") & _
            "&Correlativo=" & Viewstate("Correlativo") & _
            "&CodCuenta=" & Viewstate("CodCuenta"))
        End If
    End Sub
    Private Sub cmdModifDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifDoc.Click
        If Viewstate("Tabla") = "B" Then
            Response.Redirect("cppRegistraPago.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                    "&NroDocumento=" & Viewstate("NroDocumento"))

        ElseIf Viewstate("TipoOperacion") = "Abono" Or Viewstate("TipoOperacion") = "A" Then

            If lblTipoDocumento.Text = "RH" Then
                Response.Redirect("cppRegistraRH.aspx" & _
                "?CodProveedor=" & Viewstate("CodProveedor") & _
                "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                "&NroDocumento=" & Viewstate("NroDocumento") & _
                "&Correlativo=" & Viewstate("Correlativo") & _
                "&Opcion=" & "Modifica")
            ElseIf lblCodGasto.Text.Trim.Length > 0 Then
                Response.Redirect("cppRegistraGasto.aspx" & _
                "?CodProveedor=" & Viewstate("CodProveedor") & _
                "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                "&NroDocumento=" & Viewstate("NroDocumento") & _
                "&Correlativo=" & Viewstate("Correlativo") & _
                "&Opcion=" & "Modifica")
            Else
                Response.Redirect("cppRegistraDebito.aspx" & _
                        "?CodProveedor=" & Viewstate("CodProveedor") & _
                        "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                        "&NroDocumento=" & Viewstate("NroDocumento") & _
                         "&NroPedido=" & Viewstate("NroPedido") & _
                         "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                         "&NroVersion=" & Viewstate("NroVersion"))
            End If
        End If

        If Viewstate("TipoOperacion") = "Cargo" Or Viewstate("TipoOperacion") = "C" Then
            Response.Redirect("cppRegistraCredito.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                    "&NroDocumento=" & Viewstate("NroDocumento") & _
                    "&NroPedido=" & Viewstate("NroPedido") & _
                    "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                    "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub
    Private Sub cmdAnularDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularDoc.Click
        If Viewstate("Tabla") = "P" Then
            AnulaProveedor()
            lblStsDoc.Text = "Anulado"
            cmdLiquida.Visible = False
            cmdAnularLiqu.Visible = False
            cmdModifDoc.Visible = False
            cmdAnularDoc.Visible = False
            'cmdModifDoc.Enabled = False
            'cmdAnularDoc.Enabled = False
        End If
        If Viewstate("Tabla") = "B" Then
            AnulaBanco()
            lblStsDoc.Text = "Anulado"
            cmdAnularLiqu.Visible = False
            cmdLiquida.Visible = False
            cmdModifDoc.Visible = False
            cmdAnularDoc.Visible = False
            'cmdModifDoc.Enabled = False
            'cmdAnularDoc.Enabled = False
        End If
    End Sub
    Private Sub AnulaProveedor()
        Dim cd2 As New SqlCommand
        cd2.Connection = cn
        cd2.CommandText = "CPP_AnulaDocumentoOK_S"
        cd2.CommandType = CommandType.StoredProcedure

        Dim pa2 As New SqlParameter
        pa2 = cd2.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa2.Direction = ParameterDirection.Output
        pa2.Value = ""
        cd2.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd2.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd2.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd2.ExecuteNonQuery()
            lblmsg.Text = cd2.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblmsg.Text) <> "OK" Then
            Return
        End If


        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_AnulaDocumento_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
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

        If Trim(lblmsg.Text) = "OK" Then
            lblmsg.Text = "Se anulo el documento " & "número " & Viewstate("NroDocumento") & " de tipo" & Viewstate("TipoDocumento")
        End If
    End Sub
    Private Sub AnulaBanco()
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CYB_AnulaPagoProveedor_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
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

        If Trim(lblmsg.Text) = "OK" Then
            lblmsg.Text = "Se anulo el documento " & "número " & Viewstate("NroDocumento") & " de tipo" & Viewstate("TipoDocumento")
        End If
    End Sub
    Private Sub cmdLiquida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiquida.Click
        '    If Viewstate("Tabla") = "B" Then
        Response.Redirect("cppRegistraLiq.aspx" & _
                "?CodProveedor=" & Viewstate("CodProveedor") & _
                "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                "&NroDocumento=" & Viewstate("NroDocumento") & _
                "&Tabla=" & Viewstate("Tabla"))
        '   Else
        '      lblmsg.Text = "Liquida Pendiente, solo documentos de pago"
        ' End If
    End Sub
End Class
