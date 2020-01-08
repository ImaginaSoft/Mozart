Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports cmpTabla

Partial Class comComprobanteComprasRH
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New clsRutinas


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim wNow As String
            Dim wmes, wano As Integer
            'Obtenemos la Fecha Inicial
            wNow = objRutina.fechayyyymmdd(objRutina.fechaddmmyyyy(0))

            Viewstate("Opcion") = Request.Params("Opcion")
            If Viewstate("Opcion") = "Nuevo" Then
                Viewstate("Correlativo") = 0
                txtFchDocumento.Text = objRutina.fechaddmmyyyy(0)
                txtPorIGV.Text = objRutina.LeeParametroNumero("Retencion")
                txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))

                lbltitulo.Text = "Registrar Comprobante de Compras"
                CargaTipoDocumento("P", "A", "RH")
                wano = CInt(Mid(wNow, 1, 4))
                wmes = CInt(Mid(wNow, 5, 2))
                CargaMes(wmes)
                If wano = 0 Then
                    txtano.Text = ""
                Else
                    txtano.Text = wano
                End If
            Else
                lbltitulo.Text = "Modificar Comprobante de Compras"
                Viewstate("Correlativo") = Request.Params("Correlativo")
                EditaComprobante()
            End If
        End If
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
        ddlTipoDocumento.DataSource = objTipoDocumento.CargaTipoDocSunat(wTipoSistema, wTipoOperacion)
        ddlTipoDocumento.DataBind()
        Try
            ddlTipoDocumento.Items.FindByValue(wTipoDoc).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EditaComprobante()
        Dim wtipodoc As String
        Dim wmes As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "COM_ClienteComprobante_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Viewstate("Correlativo")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wtipodoc = dr.GetValue(dr.GetOrdinal("TipoComprobante"))
                txtNroDocumento.Text = Trim(dr.GetValue(dr.GetOrdinal("NroComprobante")))
                txtFchDocumento.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchComprobante")))
                lblNomProveedor.Text = Trim(dr.GetValue(dr.GetOrdinal("Nombre")))
                lblRuc.Text = Trim(dr.GetValue(dr.GetOrdinal("Ruc")))
                txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("TipoCambio"))
                txtSubtotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DSubTotal")))
                lblIgv.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DIGV")))
                'txtInafectos.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DInafecto")))
                lbltotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("DTotal")))
                txtSubtotalS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SSubTotal")))
                lblIgvS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SIGV")))
                ' txtInafectosS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("SInafecto")))
                lbltotalS.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("STotal")))
                txtPorIGV.Text = dr.GetValue(dr.GetOrdinal("PIGV"))
                txtano.Text = dr.GetValue(dr.GetOrdinal("AnoDeclara"))
                wmes = CStr(dr.GetValue(dr.GetOrdinal("MesDeclara")))
                lblOrigen.Text = dr.GetValue(dr.GetOrdinal("Origen"))

                If dr.GetValue(dr.GetOrdinal("StsCierre")) = "C" Then
                    btnGrabar.Enabled = False
                End If
                If dr.GetValue(dr.GetOrdinal("DSubTotal")) > 0 And dr.GetValue(dr.GetOrdinal("SSubTotal")) > 0 Then
                    cbCombierteSoles.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If Len(Trim(wtipodoc)) > 0 Then
            CargaTipoDocumento("P", "A", wtipodoc)
        End If
        CargaMes(wmes)
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
            If IsNumeric(txtTipoCambio.Text) Then
                wTipoCambio = txtTipoCambio.Text
            End If
            If IsNumeric(txtSubtotal.Text) Then
                wSubTotal = txtSubtotal.Text
            End If

            txtSubtotalS.Text = ToString.Format("{0:###,###,###,##0.00}", wSubTotal * wTipoCambio)
        Else
            txtSubtotalS.Text = ""
        End If
        CalculaIGVs()
        CalculaTotals()
    End Sub



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

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
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = txtNroDocumento.Text
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@NomPais", SqlDbType.VarChar, 50).Value = ""
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 20).Value = lblRuc.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = lblNomProveedor.Text
        cd.Parameters.Add("@Glosa", SqlDbType.VarChar, 50).Value = ""
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtPorIGV.Text
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
        If txtSubtotal.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = txtSubtotal.Text
        End If
        If lblIgv.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = lblIgv.Text
        End If
        '        If txtInafectos.Text.Trim.Length = 0 Then
        cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
        '      Else
        '           cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtInafectos.Text
        '     End If
        If lbltotal.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = lbltotal.Text
        End If
        If txtSubtotalS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = txtSubtotalS.Text
        End If
        If lblIgvS.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = 0
        Else
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = lblIgvS.Text
        End If
        'If txtInafectosS.Text.Trim.Length = 0 Then
        cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
        'Else
        '   cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtInafectosS.Text
        'End If
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
            Response.Redirect("comRegCompras.aspx")
        Else
            lblmsg.Visible = True
        End If
    End Sub


    Private Sub InitializeComponent()

    End Sub

    Private Sub lbtTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTC.Click
        txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))

        ConversionSoles()
    End Sub

    Private Sub txtSubtotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtotal.TextChanged
        CalculaIGV()
        CalculaTotal()
        ConversionSoles()
    End Sub

    Private Sub CalculaIGV()
        Dim wSubTotal, wPorIGV As Double
        If IsNumeric(txtSubtotal.Text) Then
            wSubTotal = txtSubtotal.Text
        Else
            wSubTotal = 0
        End If

        If IsNumeric(txtPorIGV.Text) Then
            wPorIGV = txtPorIGV.Text
        Else
            wPorIGV = 0
        End If
        lblIgv.Text = ToString.Format("{0:###,###,##0.00}", (wSubTotal * wPorIGV) / 100)
    End Sub

    Private Sub CalculaTotal()
        Dim wSubTotal, wIGV As Double
        If IsNumeric(txtSubtotal.Text) Then
            wSubTotal = txtSubtotal.Text
        Else
            wSubTotal = 0
        End If

        If IsNumeric(lblIgv.Text) Then
            wIGV = lblIgv.Text
        Else
            wIGV = 0
        End If
        lbltotal.Text = ToString.Format("{0:###,###,##0.00}", wSubTotal - wIGV)
    End Sub

    Private Sub txtSubtotalS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtotalS.TextChanged
        CalculaIGVs()
        CalculaTotals()
    End Sub

    Private Sub CalculaIGVs()
        Dim wSubTotal, wPorIGV As Double
        If IsNumeric(txtSubtotalS.Text) Then
            wSubTotal = txtSubtotalS.Text
        Else
            wSubTotal = 0
        End If

        If IsNumeric(txtPorIGV.Text) Then
            wPorIGV = txtPorIGV.Text
        Else
            wPorIGV = 0
        End If
        lblIgvS.Text = ToString.Format("{0:###,###,##0.00}", (wSubTotal * wPorIGV) / 100)
    End Sub

    Private Sub CalculaTotals()
        Dim wSubTotal, wIGV As Double
        If IsNumeric(txtSubtotalS.Text) Then
            wSubTotal = txtSubtotalS.Text
        Else
            wSubTotal = 0
        End If

        If IsNumeric(lblIgvS.Text) Then
            wIGV = lblIgvS.Text
        Else
            wIGV = 0
        End If
        lbltotalS.Text = ToString.Format("{0:###,###,##0.00}", wSubTotal - wIGV)
    End Sub

    Private Sub txtPorIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorIGV.TextChanged
        CalculaIGV()
        CalculaTotal()
        CalculaIGVs()
        CalculaTotals()
    End Sub

End Class
