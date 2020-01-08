Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cppCuadreUnComprobante
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            'Recibe Datos en general
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodMoneda") = Request.Params("CodMoneda")
            Viewstate("Origen") = Request.Params("Origen")
            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("Opcion1") = Request.Params("Opcion1")
            txtFchDocumento.Text = ObjRutina.fechaddmmyyyy(0)
            Viewstate("CodMonedaPedidos") = Request.Params("CodMonedaPedidos")
            txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
            txtTipoCambio.Text = "0"
            EditaProveedor()
            If Viewstate("Opcion1") = "Cuadre" Then
                Viewstate("NroPedido") = Request.Params("NroPedido")
            End If
            'Comprobante a modificar
            If Viewstate("Opcion") = "Modificar" Then
                lbltitulo.Text = "Modificar Pre-Comprobante de Compras"
                btnGrabar.Text = "Registrar"
                Viewstate("IdRegPend") = Request.Params("IdRegPend")
                Viewstate("IdRegComp") = Request.Params("IdRegComp")
                Viewstate("NroMonto") = Request.Params("NroMonto")
                Viewstate("NroDoc") = Request.Params("NroDoc")
                Viewstate("CodMonedaPedidos") = Request.Params("CodMonedaPedidos")
                EditaPendientesPago2()
                ViewState("Opcion1") = Request.Params("Opcion1")
            Else
                'Comprobante Nuevo
                CargaTipoDocumento("P", "A", "")

                ViewState("IdReg") = Request.Params("IdReg")
                lbltitulo.Text = "Registrar Comprobante de Compras"
                btnGrabar.Text = "Grabar"
                EditaPendientesPago()
                If ViewState("CodMoneda") = "D" Then
                    cbCombierteSoles.Visible = True
                End If
                If ViewState("CodMoneda") = "S" Then
                    cbCombierteDolares.Visible = True
                End If

            End If
        End If
    End Sub
    Private Sub EditaProveedor()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_ProveedorCodProveedor_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNomProveedor.Text = dr.GetValue(dr.GetOrdinal("RazonSocial"))
                lblRuc.Text = dr.GetValue(dr.GetOrdinal("RUC"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub EditaPendientesPago()

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_PendientesAcumula_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdReg")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ViewState("CodMoneda") = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                If ViewState("CodMoneda") = "D" Then
                    lbltotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("Total")))
                    txtInafectos.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("Otros")))
                Else
                    lbltotalS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("Total")))
                    txtInafectosS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("Otros")))
                End If

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If ViewState("CodMoneda") = "D" Then
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

    Private Sub CargaTipoDocumento(ByVal wTipoSistema As String, ByVal wTipoOperacion As String, ByVal wTipoComprobante As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumentoOperacionNC_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = wTipoSistema
        da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = wTipoOperacion
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()

        If wTipoComprobante <> "" Then
            Try
                ddlTipoDocumento.Items.FindByValue(wTipoComprobante).Selected = True
            Catch ex As Exception
                'salir
            End Try
        End If

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If IsNumeric(lbltotal.Text) And IsNumeric(txtInafectos.Text) And ddlTipoDocumento.SelectedItem.Value <> "NC" Then
            If CDbl(txtInafectos.Text) > CDbl(lbltotal.Text) Then
                lblmsg.Text = "Error: Los Inafectos US$, no pueden superar el total"
                lblmsg.Visible = True
                Return
            End If
        End If

        If IsNumeric(lbltotalS.Text) And IsNumeric(txtInafectosS.Text) And ddlTipoDocumento.SelectedItem.Value <> "NC" Then
            If CDbl(txtInafectosS.Text) > CDbl(lbltotalS.Text) Then
                lblmsg.Text = "Error: Los Inafectos S/, no pueden superar el total"
                lblmsg.Visible = True
                Return
            End If
        End If

        If lblRuc.Text.Trim.Length = 0 Then
            lblmsg.Visible = True
            lblmsg.Text = "Error: Falta actualizar #Ruc en la ficha proveedor"
            Return
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

        If Viewstate("Opcion") = "Modificar" Then
            ActualizaComprobante()
        Else
            GrabaComprobante()
        End If
    End Sub
    Private Sub GrabaComprobante()
        Dim dComisionDescontada As Double = 0
        If IsNumeric(txtComisionDescontada.Text) Then
            dComisionDescontada = txtComisionDescontada.Text
        End If


        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_CuadreComprobante_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdReg")
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = txtNroDocumento.Text
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 15).Value = lblRuc.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = lblNomProveedor.Text

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
        If Viewstate("CodMoneda") = "S" And cbCombierteDolares.Checked = False Then
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
        'Caso Moneda en Soles y  se efectuo cambio a Dolares
        If Viewstate("CodMoneda") = "S" And cbCombierteDolares.Checked = True Then
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = lblSubtotal.Text
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = lblIgv.Text
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtInafectos.Text
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = lbltotal.Text
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = lblSubtotalS.Text
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
            cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = lbltotalS.Text
        End If

        cd.Parameters.Add("@StsComprobante", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@Origen", SqlDbType.Char, 1).Value = Viewstate("Origen")
        cd.Parameters.Add("@ComisionDescontada", SqlDbType.Money).Value = dComisionDescontada
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
            If Viewstate("Opcion1") = "Cuadre" Then
                Response.Redirect("cpcPedidoLiquidacion.aspx" & _
                                  "?NroPedido=" & Viewstate("NroPedido") & _
                                  "&CodMoneda=" & Viewstate("CodMoneda"))
            Else
                Response.Redirect("cppCuadreObligaciones.aspx" & _
                                  "?CodProveedor=" & Viewstate("CodProveedor"))
            End If
        Else
            lblmsg.Visible = True
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
    Private Sub cbCombierteDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCombierteDolares.CheckedChanged
        If cbCombierteDolares.Checked Then
            If txtTipoCambio.Text.Trim.Length > 0 Then
                If IsNumeric(txtTipoCambio.Text) Then
                    If lblSubtotalS.Text.Trim.Length > 0 Then
                        lblSubtotal.Text = CDbl(lblSubtotalS.Text) / CDbl(txtTipoCambio.Text)
                        lblSubtotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotal.Text))
                    End If
                    If lblIgvS.Text.Trim.Length > 0 Then
                        lblIgv.Text = CDbl(lblIgvS.Text) / CDbl(txtTipoCambio.Text)
                        lblIgv.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgv.Text))
                    End If
                    If lbltotalS.Text.Trim.Length > 0 Then
                        lbltotal.Text = CDbl(lbltotalS.Text) / CDbl(txtTipoCambio.Text)
                        lbltotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lbltotal.Text))
                    End If
                    If txtInafectosS.Text.Trim.Length > 0 Then
                        txtInafectos.Text = CDbl(txtInafectosS.Text) / CDbl(txtTipoCambio.Text)
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", CDbl(txtInafectos.Text))
                    End If
                End If
            End If
        Else
            lblSubtotal.Text = 0
            lblIgv.Text = 0
            txtInafectos.Text = 0
            lbltotal.Text = 0
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
        If cbCombierteDolares.Checked Then
            If txtTipoCambio.Text.Trim.Length > 0 Then
                If IsNumeric(txtTipoCambio.Text) Then
                    If lblSubtotalS.Text.Trim.Length > 0 Then
                        lblSubtotal.Text = CDbl(lblSubtotalS.Text) / CDbl(txtTipoCambio.Text)
                        lblSubtotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lblSubtotal.Text))
                    End If
                    If lblIgvS.Text.Trim.Length > 0 Then
                        lblIgv.Text = CDbl(lblIgvS.Text) / CDbl(txtTipoCambio.Text)
                        lblIgv.Text = ToString.Format("{0:###,##0.00}", CDbl(lblIgv.Text))
                    End If
                    If lbltotalS.Text.Trim.Length > 0 Then
                        lbltotal.Text = CDbl(lbltotalS.Text) / CDbl(txtTipoCambio.Text)
                        lbltotal.Text = ToString.Format("{0:###,##0.00}", CDbl(lbltotal.Text))
                    End If
                    If txtInafectosS.Text.Trim.Length > 0 Then
                        txtInafectos.Text = CDbl(txtInafectosS.Text) / CDbl(txtTipoCambio.Text)
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", CDbl(txtInafectos.Text))
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub EditaPendientesPago2()
        Dim wtiposis, wflag As String
        Dim wTipoComprobante As String = ""

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_WComprobantes_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdRegComp")
        cd.Parameters.Add("@NroMonto", SqlDbType.Int).Value = Viewstate("NroMonto")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wtiposis = dr.GetValue(dr.GetOrdinal("TipoSistema"))
                wtipocomprobante = dr.GetValue(dr.GetOrdinal("TipoComprobante"))
                wflag = dr.GetValue(dr.GetOrdinal("Flag"))
                txtNroDocumento.Text = Trim(dr.GetValue(dr.GetOrdinal("NroComprobante")))
                txtFchDocumento.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchComprobante")))
                'Es la 1 vez que se editara el documento
                If Trim(ViewState("NroDoc")) = "" Then

                    'Los tipos de cambio
                    If ViewState("CodMoneda") = "D" Then
                        cbCombierteSoles.Visible = True
                        cbCombierteDolares.Visible = False
                        'cbCombierteDolares.Checked = True
                    End If
                    If ViewState("CodMoneda") = "S" Then
                        cbCombierteDolares.Visible = True
                        cbCombierteSoles.Visible = False
                        'cbCombierteSoles.Checked = True
                    End If

                    'Llenamos Dolares o Soles dependiendo de la moneda
                    If ViewState("CodMoneda") = "D" Then
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                        lbltotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DTotal")))
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                        txtInafectosS.Text = 0
                        lbltotalS.Text = 0
                        txtInafectosS.Text = 0
                    Else
                        txtInafectos.Text = 0
                        lbltotal.Text = 0
                        txtInafectos.Text = 0
                        txtInafectosS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("SInafecto")))
                        lbltotalS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("STotal")))
                        txtInafectosS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("SInafecto")))
                    End If
                    'Completamos los datos
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
                Else
                    'Edita documento ya insetado
                    txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("TipoCambio"))
                    If wflag = "D" Then
                        cbCombierteDolares.Visible = True
                        cbCombierteDolares.Checked = True
                        cbCombierteSoles.Visible = False
                        cbCombierteSoles.Checked = False
                    End If
                    If wflag = "S" Then
                        cbCombierteDolares.Visible = False
                        cbCombierteDolares.Checked = False
                        cbCombierteSoles.Visible = True
                        cbCombierteSoles.Checked = True
                    End If
                    If Trim(wflag) = "" Then
                        If ViewState("CodMoneda") = "D" Then
                            cbCombierteSoles.Visible = True
                        End If
                        If ViewState("CodMoneda") = "S" Then
                            cbCombierteDolares.Visible = True
                        End If
                    End If

                    If ViewState("CodMoneda") = "D" And Trim(wflag) = "" Then
                        lblSubtotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DSubTotal")))
                        lblIgv.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DIGV")))
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                        lbltotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DTotal")))
                        lblSubtotalS.Text = 0
                        lblIgvS.Text = 0
                        txtInafectosS.Text = 0
                        lbltotalS.Text = 0
                    Else
                        lblSubtotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DSubTotal")))
                        lblIgv.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DIGV")))
                        txtInafectos.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                        lbltotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("DTotal")))
                        lblSubtotalS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("SSubTotal")))
                        lblIgvS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("SIGV")))
                        txtInafectosS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("SInafecto")))
                        lbltotalS.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("STotal")))
                    End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaTipoDocumento("P", "A", wTipoComprobante)


    End Sub
    Private Sub ActualizaComprobante()
        Dim wMoneda, wflag As String
        wflag = ""

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_CuadreVComprobantes_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdRegComp")
        cd.Parameters.Add("@NroMonto", SqlDbType.Char, 25).Value = Viewstate("NroMonto")
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 15).Value = txtNroDocumento.Text
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 15).Value = lblRuc.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = lblNomProveedor.Text
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = lbltotal.Text 'Este dato no se actualiza
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Viewstate("CodMoneda") 'Este dato no se actualiza
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtPorIGV.Text
        If (Viewstate("CodMoneda") = "D") And (cbCombierteSoles.Checked = True) Then
            wflag = "S"
        End If
        If (Viewstate("CodMoneda") = "S") And (cbCombierteDolares.Checked = True) Then
            wflag = "D"
        End If
        cd.Parameters.Add("@Flag", SqlDbType.Char, 1).Value = wflag

        If Viewstate("CodMoneda") = "D" Then
            If cbCombierteSoles.Checked = True Then
                wMoneda = "S"
            Else
                wMoneda = "D"
            End If
        End If
        If Viewstate("CodMoneda") = "S" Then
            If cbCombierteDolares.Checked = True Then
                wMoneda = "D"
            Else
                wMoneda = "S"
            End If
        End If
        cd.Parameters.Add("@Moneda", SqlDbType.Char, 1).Value = wMoneda
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
        'Caso Moneda en Dolares y no se efectuo cambios
        If Viewstate("CodMoneda") = "D" And cbCombierteSoles.Checked = False Then
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

        Else
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = lblSubtotal.Text
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = lblIgv.Text
            If txtInafectos.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtInafectos.Text
            End If
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = lbltotal.Text

            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = lblSubtotalS.Text
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
            If txtInafectosS.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
            End If
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
            If Viewstate("Opcion1") = "Cuadre" Then
                Response.Redirect("cppCuadreVComprobanteLista.aspx" & _
                   "?IdRegPend=" & Viewstate("IdRegPend") & _
                   "&IdRegComp=" & Viewstate("IdRegComp") & _
                   "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                   "&NroPedido=" & Viewstate("NroPedido") & _
                   "&Opcion1=" & Viewstate("Opcion1") & _
                   "&Origen=" & Viewstate("Origen") & _
                   "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos"))
            Else
                Response.Redirect("cppCuadreVComprobanteLista.aspx" & _
                                   "?IdRegPend=" & Viewstate("IdRegPend") & _
                                   "&IdRegComp=" & Viewstate("IdRegComp") & _
                                   "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
                                   "&Origen=" & Viewstate("Origen") & _
                                   "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos"))
            End If
        Else
            lblmsg.Visible = True
            Return
        End If
    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        If ddlTipoDocumento.SelectedItem.Value = "FA" Then
            txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
        Else
            txtPorIGV.Text = 0
        End If
        CalculaIGV()
    End Sub

    Private Sub txtPorIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorIGV.TextChanged
        CalculaIGV()
    End Sub

    Private Sub CalculaIGV()
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
    End Sub

    Private Sub lbtTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTC.Click
        txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))
    End Sub
End Class
