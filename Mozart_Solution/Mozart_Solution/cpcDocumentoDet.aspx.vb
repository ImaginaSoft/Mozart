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

Partial Class cpcDocumentoDet
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("Nombre") = Request.Params("Nombre")
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("Tabla") = Request.Params("Tabla")
            Viewstate("TipoOperacion") = Request.Params("TipoOperacion")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("Origen") = Request.Params("Origen")

            'cargamos Data
            lblTipoDocumento.Text = Viewstate("TipoDocumento")
            lblNumeroDocumento.Text = Viewstate("NroDocumento")
            lbltitulo.Text = "Cliente " & Viewstate("Nombre")

            If Viewstate("Tabla") = "C" Then
                CargaDocumentoCliente()
            End If

            If Viewstate("Tabla") = "B" Then
                CargaDocumentoBanco()
            End If

            If Viewstate("TipoOperacion") = "C" Then
                CargaDocumentoDeuda()
            Else
                If Viewstate("TipoOperacion") = "A" Then
                    CargaDocumentoPago()
                End If
            End If
        End If

        If Mid(lblStsDoc.Text, 1, 1) = "A" Then
            cmdAnularLiq.Visible = True
            cmdModifDoc.Visible = True
            cmdAnularDoc.Visible = True

            cmdAnularLiq.Enabled = False
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
            lblmsg.Text = "El documento está anulado"
        Else
            If Viewstate("Origen") = "V" Then
                cmdModifDoc.Visible = True
                cmdAnularDoc.Visible = True

                cmdModifDoc.Enabled = True
                cmdAnularDoc.Enabled = False
                lblmsg.Text = "Documento fue generado en Ventas, solo está permitido modificar fecha de emisión"
            End If
        End If

    End Sub

    Private Sub CargaDocumentoDeuda()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()
        'Envia Data
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_ClienteAplicaDeuda_S"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        da.SelectCommand.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Dim nReg As Integer = da.Fill(ds, "DocumentosDeuda")
        If nReg = 0 Then
            cmdAnularLiq.Visible = False
            cmdModifDoc.Visible = True
            cmdModifDoc.Enabled = True
            cmdAnularDoc.Enabled = True
            dgDocumentos.Visible = False
            lblmsg.Text = " "
        Else
            dgDocumentos.DataSource = ds.Tables("DocumentosDeuda")
            dgDocumentos.DataBind()
            cmdAnularLiq.Visible = True
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
            dgDocumentos.Visible = True
            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If
    End Sub
    Private Sub CargaDocumentoPago()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()
        'Envia Data
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_ClienteAplicaPago_S"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        da.SelectCommand.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Dim nReg As Integer = da.Fill(ds, "DocumentosDeuda")

        If nReg = 0 And lblTotal.Text = lblSaldo.Text Then
            cmdAnularLiq.Visible = False
            cmdModifDoc.Enabled = True
            cmdAnularDoc.Enabled = True
            dgDocumentos.Visible = False
            lblmsg.Text = " "
        Else
            dgDocumentos.DataSource = ds.Tables("DocumentosDeuda")
            dgDocumentos.DataBind()
            cmdAnularLiq.Visible = True
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
            dgDocumentos.Visible = True
            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If
    End Sub
    Private Sub CargaDocumentoBanco()
        'Dim ds As New DataSet()
        'Dim da As New SqlDataAdapter()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader

        cd.Connection = cn
        cd.CommandText = "cpc_BancoDocDet_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = CInt(Viewstate("CodCliente"))
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Trim(Viewstate("TipoDocumento"))
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Viewstate("NroDocumento"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()

                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblFchEmision.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("DesPedido")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lblImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("DocMonto")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("DocMoneda")))
                lblMoneda5.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
                lblTipoCambio.Text = CStr(dr.GetValue(dr.GetOrdinal("TipoCambio")))
                lblTotal.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total")))
                lblSaldo.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Saldo")))
                lblStsDoc.Text = CStr(dr.GetValue(dr.GetOrdinal("StsDocumento")))
                lblNomBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("NomBanco")))
                lblNroCuenta.Text = CStr(dr.GetValue(dr.GetOrdinal("NroCuenta")))
                lblFlagBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("FlagBanco")))
                If (CInt(lblTipoCambio.Text) > 0) Then
                    lblTipoCambio.Visible = True
                    lbltc.Visible = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If lblTotal.Text = lblSaldo.Text And Mid(lblStsDoc.Text, 1, 1) = "P" Then
            cmdAnularLiq.Visible = False
        End If
    End Sub
    Private Sub CargaDocumentoCliente()
        'Dim ds As New DataSet()
        'Dim da As New SqlDataAdapter()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader

        cd.Connection = cn
        cd.CommandText = "cpc_ClienteDocDet_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = CInt(Viewstate("CodCliente"))
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Trim(Viewstate("TipoDocumento"))
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = CInt(Viewstate("NroDocumento"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblFchEmision.Text = CStr(dr.GetValue(dr.GetOrdinal("FchEmision")))
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("DesPedido")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lblImporte.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Importe")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
                lblMoneda5.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
                IGV.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("IGV")))
                lblOtros.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Otros")))
                lblTotal.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Total")))
                lblSaldo.Text = ToString.Format("{0:###,###,###,###.##}", dr.GetValue(dr.GetOrdinal("Saldo")))
                lblStsDoc.Text = CStr(dr.GetValue(dr.GetOrdinal("StsDocumento")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If lblTotal.Text = lblSaldo.Text And Mid(lblStsDoc.Text, 1, 1) = "P" Then
            cmdAnularLiq.Visible = False
        End If
    End Sub


    Private Sub cmdAnularLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularLiq.Click
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CPC_AnulaLiquidacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = Viewstate("TipoOperacion")
        cd.Parameters.Add("@Tabla", SqlDbType.Char, 1).Value = Trim(Viewstate("Tabla"))
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
            Response.Redirect("cpcDocumentoDet.aspx" & _
            "?CodCliente=" & Viewstate("CodCliente") & _
            "&Nombre=" & Viewstate("Nombre") & _
            "&TipoDocumento=" & Viewstate("TipoDocumento") & _
            "&NroDocumento=" & Viewstate("NroDocumento") & _
            "&Tabla=" & Viewstate("Tabla") & _
            "&TipoOperacion=" & Viewstate("TipoOperacion") & _
            "&NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

    Private Sub cmdModifDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifDoc.Click
        If Viewstate("Tabla") = "B" Then
            If Viewstate("TipoOperacion") = "C" Then
                'PC : Reembolso al Cliente por no viaje
                Response.Redirect("cpcRegistraReembolso.aspx" & _
                        "?CodCliente=" & Viewstate("CodCliente") & _
                        "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                        "&NroDocumento=" & Viewstate("NroDocumento"))
            Else
                Response.Redirect("cpcRegistraPago.aspx" & _
                        "?CodCliente=" & Viewstate("CodCliente") & _
                        "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                        "&NroDocumento=" & Viewstate("NroDocumento"))
            End If

        ElseIf Viewstate("TipoOperacion") = "A" Then             ' Abono
            Response.Redirect("cpcRegistraAbono.aspx" & _
                    "?CodCliente=" & Viewstate("CodCliente") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                    "&NroDocumento=" & Viewstate("NroDocumento") & _
                     "&NroPedido=" & Viewstate("NroPedido") & _
                     "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                     "&NroVersion=" & Viewstate("NroVersion"))

        ElseIf Viewstate("Origen") = "V" Then
            'Cargo con origen en Ventas, solo modifica FchEmision
            Response.Redirect("cpcRegistraDC.aspx" & _
                    "?CodCliente=" & Viewstate("CodCliente") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                    "&NroDocumento=" & Viewstate("NroDocumento"))
        Else
            'Cargo con origen en CtaCobrar, modifica documento
            Response.Redirect("cpcRegistraCargo.aspx" & _
                    "?CodCliente=" & Viewstate("CodCliente") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento") & _
                    "&NroDocumento=" & Viewstate("NroDocumento") & _
                     "&NroPedido=" & Viewstate("NroPedido") & _
                     "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                     "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

    Private Sub cmdAnularDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularDoc.Click
        If Viewstate("Tabla") = "C" Then
            AnulaCliente()
            lblStsDoc.Text = "Anulado"
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
        End If
        If Viewstate("Tabla") = "B" Then
            AnulaBanco()
            lblStsDoc.Text = "Anulado"
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
        End If
    End Sub

    Private Sub AnulaCliente()
        Dim cd2 As New SqlCommand
        cd2.Connection = cn
        cd2.CommandText = "CPC_AnulaDocumentoOK_S"
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
        cd.CommandText = "CPC_AnulaDocumento_U"
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
        cd.CommandText = "CYB_AnulaPagoCliente_U"
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

            cmdAnularLiq.Visible = True
            cmdModifDoc.Visible = True
            cmdAnularDoc.Visible = True

            cmdAnularLiq.Enabled = False
            cmdModifDoc.Enabled = False
            cmdAnularDoc.Enabled = False
            lblmsg.Text = "Se anulo el documento " & "número " & Viewstate("NroDocumento") & " de tipo" & Viewstate("TipoDocumento")
        End If
    End Sub

End Class
