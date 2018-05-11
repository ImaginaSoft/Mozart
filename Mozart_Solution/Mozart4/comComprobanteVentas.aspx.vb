Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports cmpTabla

Partial Class comComprobanteVentas
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New clsRutinas


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim wNow As String
            Dim wmes, wano As Integer
            'Obtenemos la Fecha Inicial
            wNow = objRutina.fechayyyymmdd(objRutina.fechaddmmyyyy(0))

            ViewState("Opcion") = Request.Params("Opcion")
            If ViewState("Opcion") = "Nuevo" Then
                ViewState("Correlativo") = 0
                lblCodRelacion.Text = "0"
                txtFchDocumento.Text = objRutina.fechaddmmyyyy(0)
                txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
                txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))

                lbltitulo.Text = "Registrar Comprobante de Ventas"
                CargaTipoDocumento("C", "A", "")
                wano = CInt(Mid(wNow, 1, 4))
                wmes = CInt(Mid(wNow, 5, 2))
                CargaMes(wmes)
                If wano = 0 Then
                    txtano.Text = ""
                Else
                    txtano.Text = wano
                End If
            Else
                btnImprimir.Enabled = True
                lbltitulo.Text = "Modificar Comprobante de Ventas"
                ViewState("Correlativo") = Request.Params("Correlativo")
                EditaComprobante()
            End If
        End If
    End Sub

    Private Sub EditaComprobante()
        Dim wtipodoc As String
        Dim wmes As String

        lblCodRelacion.Text = "0"

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "COM_ClienteComprobante_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = ViewState("Correlativo")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wtipodoc = dr.GetValue(dr.GetOrdinal("TipoComprobante"))
                txtNroDocumento.Text = Trim(dr.GetValue(dr.GetOrdinal("NroComprobante")))
                txtFchDocumento.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchComprobante")))
                lblNomProveedor.Text = Trim(dr.GetValue(dr.GetOrdinal("Nombre")))
                If IsDBNull(dr.GetValue(dr.GetOrdinal("NomPais"))) Then
                    txtNomPais.Text = ""
                Else
                    txtNomPais.Text = Trim(dr.GetValue(dr.GetOrdinal("NomPais")))
                End If
                lblRuc.Text = Trim(dr.GetValue(dr.GetOrdinal("Ruc")))
                txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("TipoCambio"))
                txtGlosa.Text = dr.GetValue(dr.GetOrdinal("Glosa"))
                lblSubtotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DSubTotal")))
                lblIgv.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DIGV")))
                txtInafectos.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                lbltotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DTotal")))
                lblSubtotalS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SSubTotal")))
                lblIgvS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SIGV")))
                txtInafectosS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SInafecto")))
                lbltotalS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("STotal")))
                txtPorIGV.Text = dr.GetValue(dr.GetOrdinal("PIGV"))
                txtano.Text = dr.GetValue(dr.GetOrdinal("AnoDeclara"))
                wmes = dr.GetValue(dr.GetOrdinal("MesDeclara"))
                lblOrigen.Text = dr.GetValue(dr.GetOrdinal("Origen"))

                If dr.GetValue(dr.GetOrdinal("StsCierre")) = "C" Then
                    btnGrabar.Enabled = False
                End If

                'mantener codcliente
                lblCodRelacion.Text = dr.GetValue(dr.GetOrdinal("CodRelacion"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If Len(Trim(wtipodoc)) > 0 Then
            CargaTipoDocumento("C", "A", wtipodoc)
        End If
        CargaMes(CInt(wmes))
    End Sub

    Private Sub CargaMes(ByVal pmes As String)
        Dim objTablaElemento As New clsTablaElemento
        ddlMes.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(9, "E")
        ddlMes.DataBind()
        Try
            ddlMes.Items.FindByValue(pmes).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaTipoDocumento(ByVal wTipoSistema As String, ByVal wTipoOperacion As String, ByVal wTipoDoc As String)
        Dim objTipoDocumento As New clsTipoDocumento
        ddlTipoDocumento.DataSource = objTipoDocumento.CargaTipoDocSunatyNC(wTipoSistema, wTipoOperacion)
        ddlTipoDocumento.DataBind()

        Try
            ddlTipoDocumento.Items.FindByValue(wTipoDoc).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbCombierteSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCombierteSoles.CheckedChanged
        ConversionSoles()
    End Sub

    Private Sub txtTipoCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged
        ConversionSoles()
    End Sub

    Private Sub ConversionSoles()
        If cbCombierteSoles.Checked Then
            Dim wTipoCambio As Double = 0
            Dim wSubTotal As Double = 0
            Dim wIGV As Double = 0
            Dim wInafectos As Double = 0
            Dim wTotal As Double = 0

            If IsNumeric(txtTipoCambio.Text) Then
                wTipoCambio = txtTipoCambio.Text
            End If
            If IsNumeric(lblSubtotal.Text) Then
                wSubTotal = lblSubtotal.Text
            End If
            If IsNumeric(lblIgvS.Text) Then
                wIGV = lblIgv.Text
            End If
            If IsNumeric(txtInafectos.Text) Then
                wInafectos = txtInafectos.Text
            End If
            If IsNumeric(lbltotal.Text) Then
                wTotal = lbltotal.Text
            End If

            lblSubtotalS.Text = ToString.Format("{0:###,###,###,##0.00}", wSubTotal * wTipoCambio)
            lblIgvS.Text = ToString.Format("{0:###,###,###,##0.00}", wIGV * wTipoCambio)
            txtInafectosS.Text = ToString.Format("{0:###,###,###,##0.00}", wInafectos * wTipoCambio)
            lbltotalS.Text = ToString.Format("{0:###,###,###,##0.00}", wTotal * wTipoCambio)
        Else
            lblSubtotalS.Text = ""
            lblIgvS.Text = ""
            txtInafectosS.Text = ""
            lbltotalS.Text = ""
        End If
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

        If txtano.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtano.Text) Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Año es dato numerico o vacio"
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
        cd.CommandText = "COM_ClienteComprobante_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Viewstate("Correlativo")
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = txtNroDocumento.Text
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = lblCodRelacion.Text
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@NomPais", SqlDbType.VarChar, 50).Value = txtNomPais.Text
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 20).Value = lblRuc.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = lblNomProveedor.Text
        If txtGlosa.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@Glosa", SqlDbType.VarChar, 50).Value = ""
        Else
            cd.Parameters.Add("@Glosa", SqlDbType.VarChar, 50).Value = txtGlosa.Text
        End If
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtPorIGV.Text
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
        If lblSubtotal.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = lblSubtotal.Text
        End If
        If lblIgv.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = lblIgv.Text
        End If
        If txtInafectos.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtInafectos.Text
        End If
        If lbltotal.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = lbltotal.Text
        End If
        If lblSubtotalS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = lblSubtotalS.Text
        End If
        If lblIgvS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
        End If
        If txtInafectosS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
        End If
        If lbltotalS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = lbltotalS.Text
        End If
        If Viewstate("Opcion") = "Nuevo" Then
            cd.Parameters.Add("@Origen", SqlDbType.Char, 1).Value = "M"
        Else
            cd.Parameters.Add("@Origen", SqlDbType.Char, 1).Value = lblOrigen.Text.Trim
        End If
        cd.Parameters.Add("@StsComprobante", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = ddlMes.SelectedValue
        cd.Parameters.Add("@ComisionDescontada", SqlDbType.Money).Value = 0
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
            Response.Redirect("comRegVentas.aspx")
        Else
            lblmsg.Visible = True
        End If

    End Sub

    Private Sub lbltotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltotal.TextChanged
        CalculaMontoDolares()
    End Sub

    Private Sub CalculaMontoDolares()
        Dim wPorIGV As Double = 0
        Dim wIGV As Double = 0
        Dim wInafectos As Double = 0
        Dim wTotal As Double = 0

        If IsNumeric(txtPorIGV.Text) Then
            wPorIGV = txtPorIGV.Text
        End If
        If IsNumeric(lblIgv.Text) Then
            wIGV = lblIgv.Text
        End If
        If IsNumeric(txtInafectos.Text) Then
            wInafectos = txtInafectos.Text
        End If
        If IsNumeric(lbltotal.Text) Then
            wTotal = lbltotal.Text
        End If

        lblIgv.Text = ((wTotal - wInafectos) * wPorIGV) / (100 + wPorIGV)
        lblSubtotal.Text = wTotal - wInafectos - CDbl(lblIgv.Text)

        lblIgv.Text = ToString.Format("{0:###,###,###,##0.00}", CDbl(lblIgv.Text))
        lblSubtotal.Text = ToString.Format("{0:###,###,###,##0.00}", CDbl(lblSubtotal.Text))
    End Sub

    Private Sub txtInafectosS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInafectosS.TextChanged
        CalculaMontoSoles()
    End Sub


    Private Sub lbltotalS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltotalS.TextChanged
        CalculaMontoSoles()
    End Sub

    Private Sub CalculaMontoSoles()
        Dim wPorIGV As Double = 0
        Dim wIGV As Double = 0
        Dim wInafectos As Double = 0
        Dim wTotal As Double = 0

        If IsNumeric(txtPorIGV.Text) Then
            wPorIGV = txtPorIGV.Text
        End If
        If IsNumeric(lblIgvS.Text) Then
            wIGV = lblIgvS.Text
        End If
        If IsNumeric(txtInafectosS.Text) Then
            wInafectos = txtInafectosS.Text
        End If
        If IsNumeric(lbltotalS.Text) Then
            wTotal = lbltotalS.Text
        End If

        lblIgvS.Text = ((wTotal - wInafectos) * wPorIGV) / (100 + wPorIGV)
        lblSubtotalS.Text = wTotal - wInafectos - CDbl(lblIgvS.Text)
        lblIgvS.Text = ToString.Format("{0:###,###,##0.00}", CDbl(lblIgvS.Text))
        lblSubtotalS.Text = ToString.Format("{0:###,###,##0.00}", CDbl(lblSubtotalS.Text))
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If txtGlosa.Text.Trim.Length = 0 Then
            lblmsg.Text = "Error: Glosa es un dato obligatorio"
            lblmsg.Visible = True
            Return
        End If
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

        If txtano.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtano.Text) Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Año es dato numerico o vacio"
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
        Response.Redirect("comComprobanteVentasImprime.aspx" & _
                          "?Fecha=" & objRutina.fechayyyymmdd(txtFchDocumento.Text) & _
                          "&Nombre=" & lblNomProveedor.Text & _
                          "&DNI=" & lblRuc.Text & _
                          "&Glosa=" & txtGlosa.Text & _
                          "&Total=" & lbltotal.Text)
    End Sub

    Private Sub txtInafectos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInafectos.TextChanged
        CalculaMontoDolares()
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        If ddlTipoDocumento.SelectedItem.Value = "FA" Or ddlTipoDocumento.SelectedItem.Value = "NC" Then
            txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
        Else
            txtPorIGV.Text = 0
        End If
    End Sub

    Private Sub lbtTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTC.Click
        txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))
    End Sub

    Private Sub txtPorIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorIGV.TextChanged
        CalculaMontoDolares()
    End Sub

End Class
