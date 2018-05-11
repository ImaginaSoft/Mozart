Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cpcPedidoLiquidacionBoleta
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            'Recibe Datos en general
            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("CodMoneda") = Request.Params("CodMoneda")
            lbltotal.Text = Request.Params("Total")
            CargaTipoDocumento("C", "A")
            EditaCorrelativo()
            txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
            txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))
            EditaCliente()
            lbltitulo.Text = "Registrar Comprobante de Ventas"
            txtGlosa.Text = "PROGRAMA EN PERU"
            EditaPendientesPago()
        End If
    End Sub
    Private Sub EditaCorrelativo()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader

        cd.Connection = cn
        cd.CommandText = "CPC_EditaPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchDocumento.Text = String.Format("{0:dd-MM-yyyy}", (dr.GetValue(dr.GetOrdinal("FchTermino"))))

                If IsNumeric(dr.GetValue(dr.GetOrdinal("Correlativo"))) Then
                    If dr.GetValue(dr.GetOrdinal("Correlativo")) > 0 Then
                        btnGrabar.Enabled = False
                    Else
                        btnGrabar.Enabled = True
                    End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub EditaCliente()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpc_ClienteCodCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNomCliente.Text = dr.GetValue(dr.GetOrdinal("NomCliente"))
                lblRuc.Text = dr.GetValue(dr.GetOrdinal("DocPersonal"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub EditaPendientesPago()
        If Viewstate("CodMoneda") = "D" Then
            If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotal.Text) Then
                lblIgv.Text = (lbltotal.Text * txtPorIGV.Text) / (100 + txtPorIGV.Text)
                lblSubtotal.Text = lbltotal.Text - lblIgv.Text
                lblIgv.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgv.Text))
                lblSubtotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotal.Text))
                lblIgvS.Text = 0
                lblSubtotalS.Text = 0
                lblIgvS.Text = 0
                lblSubtotalS.Text = 0
                lbltotalS.Text = 0
            End If
        Else
            If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotalS.Text) Then
                lblIgv.Text = 0
                lblSubtotal.Text = 0
                lblIgv.Text = 0
                lblSubtotal.Text = 0
                lbltotal.Text = 0

                lblIgvS.Text = (lbltotalS.Text * txtPorIGV.Text) / (100 + txtPorIGV.Text)
                lblSubtotalS.Text = lbltotalS.Text - lblIgvS.Text
                lblIgvS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgvS.Text))
                lblSubtotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotalS.Text))
            End If
        End If
    End Sub
    Private Sub CargaTipoDocumento(ByVal wTipoSistema As String, ByVal wTipoOperacion As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumentoCodSunat_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = wTipoSistema
        da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = wTipoOperacion
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub
    Private Sub CalculaMontos(ByVal wInafectos As String, ByVal wMoneda As String)
        If wMoneda = "$" Then
            If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotal.Text) Then
                If CDbl(wInafectos) <= CDbl(lbltotal.Text) Then
                    lblIgv.Text = ((CDbl(lbltotal.Text) - CDbl(wInafectos)) * CDbl(txtPorIGV.Text)) / (100 + CDbl(txtPorIGV.Text))
                    lblSubtotal.Text = CDbl(lbltotal.Text) - CDbl(wInafectos) - CDbl(lblIgv.Text)
                    lblIgv.Text = ToString.Format("{0:###,###,###,###.00}", CDbl(lblIgv.Text))
                    lblSubtotal.Text = ToString.Format("{0:###,###,###,###.00}", CDbl(lblSubtotal.Text))
                    lblmsg.Visible = False
                Else
                    lblmsg.Text = "Error: Los Inafectos US$, no pueden superar el total"
                    lblmsg.Visible = True
                    Return
                End If
            End If
        End If
        If wMoneda = "S/" Then
            If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotalS.Text) Then
                If CDbl(wInafectos) <= CDbl(lbltotalS.Text) Then
                    lblIgvS.Text = ((CDbl(lbltotalS.Text) - CDbl(wInafectos)) * CDbl(txtPorIGV.Text)) / (100 + CDbl(txtPorIGV.Text))
                    lblSubtotalS.Text = CDbl(lbltotalS.Text) - CDbl(wInafectos) - CDbl(lblIgvS.Text)
                    lblIgvS.Text = ToString.Format("{0:###,###,###,###.00}", CDbl(lblIgvS.Text))
                    lblSubtotalS.Text = ToString.Format("{0:###,###,###,###.00}", CDbl(lblSubtotalS.Text))
                    lblmsg.Visible = False
                Else
                    lblmsg.Text = "Error: Los Inafectos S/, no pueden superar el total"
                    lblmsg.Visible = True
                    Return
                End If
            End If
        End If

    End Sub
    Private Sub txtInafectos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInafectos.TextChanged
        If txtInafectos.Text.Length = 0 Then
            CalculaMontos(0, "$")
        Else
            If IsNumeric(txtInafectos.Text) Then
                CalculaMontos(txtInafectos.Text.Trim, "$")
            End If
        End If
    End Sub
    Private Sub txtInafectosS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInafectosS.TextChanged
        If txtInafectosS.Text.Length = 0 Then
            CalculaMontos(0, "S/")
        Else
            If IsNumeric(txtInafectosS.Text) Then
                CalculaMontos(txtInafectosS.Text.Trim, "S/")
            End If
        End If
    End Sub
    Private Sub cbCombierteSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCombierteSoles.CheckedChanged
        If cbCombierteSoles.Checked Then
            If txtTipoCambio.Text.Trim.Length > 0 Then
                If IsNumeric(txtTipoCambio.Text) Then
                    If lblSubtotal.Text.Trim.Length > 0 Then
                        lblSubtotalS.Text = CDbl(lblSubtotal.Text) * CDbl(txtTipoCambio.Text)
                        lblSubtotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotalS.Text))
                    End If
                    If lblIgv.Text.Trim.Length > 0 Then
                        lblIgvS.Text = CDbl(lblIgv.Text) * CDbl(txtTipoCambio.Text)
                        lblIgvS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgvS.Text))
                    End If
                    If lbltotal.Text.Trim.Length > 0 Then
                        lbltotalS.Text = CDbl(lbltotal.Text) * CDbl(txtTipoCambio.Text)
                        lbltotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lbltotalS.Text))
                    End If
                    If txtInafectos.Text.Trim.Length > 0 Then
                        txtInafectosS.Text = CDbl(txtInafectos.Text) * CDbl(txtTipoCambio.Text)
                        txtInafectosS.Text = ToString.Format("{0:###,##0.00}", CDbl(txtInafectosS.Text))
                    End If
                End If
            End If
        Else
            lblSubtotalS.Text = 0
            lblIgvS.Text = 0
            txtInafectosS.Text = 0
            lbltotalS.Text = 0
        End If
    End Sub
    Private Sub txtTipoCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged
        'Se efectuo cambios a soles
        If cbCombierteSoles.Checked Then
            If txtTipoCambio.Text.Trim.Length > 0 Then
                If IsNumeric(txtTipoCambio.Text) Then
                    If lblSubtotal.Text.Trim.Length > 0 Then
                        lblSubtotalS.Text = CDbl(lblSubtotal.Text) * CDbl(txtTipoCambio.Text)
                        lblSubtotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotalS.Text))
                    End If
                    If lblIgv.Text.Trim.Length > 0 Then
                        lblIgvS.Text = CDbl(lblIgv.Text) * CDbl(txtTipoCambio.Text)
                        lblIgvS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgvS.Text))
                    End If
                    If lbltotal.Text.Trim.Length > 0 Then
                        lbltotalS.Text = CDbl(lbltotal.Text) * CDbl(txtTipoCambio.Text)
                        lbltotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lbltotalS.Text))
                    End If
                    If txtInafectos.Text.Trim.Length > 0 Then
                        txtInafectosS.Text = CDbl(txtInafectos.Text) * CDbl(txtTipoCambio.Text)
                        txtInafectosS.Text = ToString.Format("{0:###,##0.00}", CDbl(txtInafectosS.Text))
                    End If
                End If
            End If
        End If
        'Se efectuo cambio a dolares
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If IsNumeric(lbltotal.Text) And IsNumeric(txtInafectos.Text) Then
            If CDbl(txtInafectos.Text) > CDbl(lbltotal.Text) Then
                lblmsg.Text = "Error: Los Inafectos US$, no pueden superar el total"
                lblmsg.Visible = True
                Return
            End If
        End If

        If IsNumeric(lbltotalS.Text) And IsNumeric(txtInafectosS.Text) Then
            If CDbl(txtInafectosS.Text) > CDbl(lbltotalS.Text) Then
                lblmsg.Text = "Error: Los Inafectos S/, no pueden superar el total"
                lblmsg.Visible = True
                Return
            End If
        End If

        If Not IsNumeric(txtPorIGV.Text) Then
            lblmsg.Visible = True
            lblmsg.Text = "Error: Porcentaje de IGV, es un dato numérico"
            Return
        End If

        If txtInafectos.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtInafectos.Text) Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Inafectos, es un dato numérico"
                Return
            End If
        End If
        If txtInafectosS.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtInafectosS.Text) Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Inafectos, es un dato numérico"
                Return
            End If
        End If
        If Not IsNumeric(txtTipoCambio.Text) Then
            lblmsg.Visible = True
            lblmsg.Text = "Error: Tipo de cambio, es un dato numérico"
            Return
        End If
        GrabaComprobante()
    End Sub
    Private Sub GrabaComprobante()
        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "CPC_ClienteComprobante_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = txtNroDocumento.Text
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 20).Value = lblRuc.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = lblNomCliente.Text
        If txtGlosa.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@Glosa", SqlDbType.VarChar, 50).Value = ""
        Else
            cd.Parameters.Add("@Glosa", SqlDbType.VarChar, 50).Value = txtGlosa.Text
        End If

        If Viewstate("CodMoneda") = "D" Then
            cd.Parameters.Add("@Total", SqlDbType.Money).Value = lbltotal.Text
        Else
            cd.Parameters.Add("@Total", SqlDbType.Money).Value = lbltotalS.Text
        End If
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Viewstate("CodMoneda") 'Moneda del sistema
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtPorIGV.Text
        'Caso Moneda en Dolares y no se efectuo cambios
        If Viewstate("CodMoneda") = "D" And cbCombierteSoles.Checked = False Then
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = lblSubtotal.Text
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = lblIgv.Text
            If txtInafectos.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtInafectos.Text
            End If
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = lbltotal.Text
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = CDbl(lblSubtotal.Text) * CDbl(txtTipoCambio.Text)
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = CDbl(lblIgv.Text) * CDbl(txtTipoCambio.Text)
            If txtInafectos.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = CDbl(txtInafectos.Text) * CDbl(txtTipoCambio.Text)
            End If
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = CDbl(lbltotal.Text) * CDbl(txtTipoCambio.Text)
        End If
        'Caso Moneda en Dolares y  se efectuo cambio a Soles
        If Viewstate("CodMoneda") = "D" And cbCombierteSoles.Checked = True Then
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = lblSubtotalS.Text
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
            If txtInafectosS.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
            End If
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = lbltotalS.Text
        End If
        'Caso Moneda en Soles y no se efectuo cambios
        If Viewstate("CodMoneda") = "S" And cbCombierteSoles.Checked = False Then
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = 0
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = lblSubtotalS.Text
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
            cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = lbltotalS.Text
        End If

        cd.Parameters.Add("@StsComprobante", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")

        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Visible = True
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Visible = True
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblmsg.Text) = "OK" Then
            If Viewstate("Opcion") = "Directo" Then
                Response.Redirect("cpcPedidoLiquidacion.aspx" & _
                                        "?NroPedido=" & Viewstate("NroPedido") & _
                                        "&CodMoneda=" & Viewstate("CodMoneda"))
            Else
                Response.Redirect("cpcClientePedidoRegVentas.aspx")
            End If
        Else
            lblmsg.Visible = True
        End If

    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub txtPorIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorIGV.TextChanged
        If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotal.Text) Then
            lblIgv.Text = (lbltotal.Text * txtPorIGV.Text) / (100 + txtPorIGV.Text)
            lblSubtotal.Text = lbltotal.Text - lblIgv.Text
            lblIgv.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgv.Text))
            lblSubtotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotal.Text))
        End If
        If IsNumeric(txtPorIGV.Text) And IsNumeric(lbltotalS.Text) Then
            lblIgvS.Text = (lbltotalS.Text * txtPorIGV.Text) / (100 + txtPorIGV.Text)
            lblSubtotalS.Text = lbltotalS.Text - lblIgvS.Text
            lblIgvS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgvS.Text))
            lblSubtotalS.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotalS.Text))
        End If

        If txtInafectos.Text.Length > 0 Then
            If IsNumeric(txtInafectos.Text) Then
                CalculaMontos(txtInafectos.Text.Trim, "$")
            End If
        End If

        If txtInafectosS.Text.Length > 0 Then
            If IsNumeric(txtInafectosS.Text) Then
                CalculaMontos(txtInafectosS.Text.Trim, "S/")
            End If
        End If
    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        If ddlTipoDocumento.SelectedItem.Value = "FA" Then
            txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
        Else
            txtPorIGV.Text = 0
        End If
    End Sub

    Private Sub txtFchDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFchDocumento.TextChanged
        txtTipoCambio.Text = txtFchDocumento.Text
    End Sub

    Private Sub lbtTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTC.Click
        txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))
    End Sub

End Class
