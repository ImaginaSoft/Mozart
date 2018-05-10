Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpTabla
Imports System.Drawing

Partial Class cppRegistraGasto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objCuenta As New clsCuenta

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            EditaProveedor()
            lblPIGV.Text = objRutina.LeeParametroNumero("PorIGV")
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "Modifica" Then
                Viewstate("NroDocumento") = Request.Params("NroDocumento")
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                Viewstate("Correlativo") = Request.Params("Correlativo")
                lblDocProveedor.Visible = True
                lblNº.Visible = True
                lblDocProveedor.Text = Viewstate("NroDocumento")
                CargaTipoDocumento("P", "A", Viewstate("TipoDocumento"))
                ddlTipoDocumento.Enabled = False
                ddlTipoDocumento.BackColor = Color.LightCyan
                lblDocProveedor.Visible = True
                EditaNroDocumento()
            Else
                txtFchDocumento.Text = ObjRutina.fechaddmmyyyy(0)
                CargaTipoDocumento("P", "A", "")
                CargaTipoGasto("")
                If ddlTipoGasto.Items.Count > 0 Then
                    CargaCuentaGasto(ddlTipoGasto.SelectedItem.Value, "")
                End If
                TipoCambio()
                txtPorIGV.Text = objRutina.LeeParametroNumero("PorIGV")
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
                txtNomProveedor.Text = dr.GetValue(dr.GetOrdinal("RazonSocial"))
                txtRUC.Text = dr.GetValue(dr.GetOrdinal("RUC"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub CargaTipoDocumento(ByVal wTipoSistema As String, ByVal wTipoOperacion As String, ByVal wTipoDocumento As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumentoOperacion_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = wTipoSistema
        da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = wTipoOperacion
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
        If wTipoDocumento.Trim.Length > 0 Then
            ddlTipoDocumento.Items.FindByValue(wTipoDocumento).Selected = True
        End If
    End Sub
    Private Sub CargaTipoGasto(ByVal pCodGasto As String)
        ddlTipoGasto.DataSource = objCuenta.CargarCuenta2("G")
        ddlTipoGasto.DataBind()
        If pCodGasto.Trim.Length > 0 Then
            ddlTipoGasto.Items.FindByValue(pCodGasto).Selected = True
        End If
    End Sub
    Private Sub CargaCuentaGasto(ByVal pCodGasto2 As String, ByVal pCodGasto4 As String)
        ddlCuentaGasto.DataSource = objCuenta.CargarCuenta4(pCodGasto2)
        ddlCuentaGasto.DataBind()
        If pCodGasto4.Trim.Length > 0 Then
            ddlCuentaGasto.Items.FindByValue(pCodGasto4).Selected = True
        End If
    End Sub
    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        rbsoles.Checked = False
        rbdolar.Checked = True
        TipoCambio()
    End Sub
    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        rbsoles.Checked = True
        rbdolar.Checked = False
        txtTipoCambio.Text = ""
    End Sub
    Private Sub ddlTipoGasto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoGasto.SelectedIndexChanged
        If ddlTipoGasto.Items.Count > 0 Then
            CargaCuentaGasto(ddlTipoGasto.SelectedItem.Value, "")
        End If
    End Sub
    Private Sub CalculaMontos()
        Dim wTotal As Double
        'Obtenemos el Total
        If txtTotal.Text.Trim.Length > 0 Then
            If IsNumeric(txtTotal.Text) Then
                'Verificamos que aya Inafectos
                If txtOtros.Text.Trim.Length > 0 Then
                    If IsNumeric(txtOtros.Text) Then
                        wTotal = CDbl(txtTotal.Text) - CDbl(txtOtros.Text)
                    End If
                Else 'No existe inafectos
                    wTotal = CDbl(txtTotal.Text)
                End If
            End If
        End If
        'Dividimos entre el subtotal y el Impuesto
        txtIGV.Text = Math.Round(((wTotal * txtPorIGV.Text) / (100 + txtPorIGV.Text)), 2)
        txtSubTotal.Text = Math.Round((wTotal - txtIGV.Text), 2)
        txtIGV.Text = ToString.Format("{0:###,###,##0.00}", CDbl(txtIGV.Text))
        txtSubTotal.Text = ToString.Format("{0:###,###,##0.00}", CDbl(txtSubTotal.Text))
    End Sub
    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        If txtTotal.Text.Trim.Length > 0 Then
            If IsNumeric(txtTotal.Text) Then
                If txtTotal.Text > 0 Then
                    CalculaMontos()
                End If
            End If
        End If
    End Sub
    Private Sub txtOtros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtros.TextChanged
        If txtTotal.Text.Trim.Length > 0 Then
            If IsNumeric(txtTotal.Text) Then
                If txtTotal.Text > 0 Then
                    CalculaMontos()
                End If
            End If
        End If
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblmsg.Visible = True
        If txtOtros.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtOtros.Text) Then
                lblmsg.Text = "Error: Inafectos es dato numérico"
                Return
            End If
        End If
        If txtTotal.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtTotal.Text) Then
                lblmsg.Text = "Error: Monto Total es dato numérico"
                Return
            End If
        End If
        If rbdolar.Checked = True Then
            If txtTipoCambio.Text.Trim.Length = 0 Then
                lblmsg.Text = "Error: Tipo de cambio es obligatorio, cuando total esta  en US $"
                Return
            Else
                If Not IsNumeric(txtTipoCambio.Text) Then
                    lblmsg.Text = "Error: Tipo Cambio es dato numérico"
                    Return
                End If
            End If
        End If
        If ddlTipoGasto.Items.Count = 0 Then
            lblmsg.Text = "Error: Tipo gasto, es dato obligatorio"
            Return
        End If
        If ddlCuentaGasto.Items.Count = 0 Then
            lblmsg.Text = "Error: Cuenta de  gasto, es dato obligatorio"
            Return
        End If
        lblmsg.Visible = False
        GrabaDocumento()
    End Sub
    Private Sub GrabaDocumento()
        'Definiciòn de variables
        Dim cd As New SqlCommand
        Dim wCodMoneda As String

        If rbdolar.Checked Then
            wCodMoneda = "D"
        Else
            wCodMoneda = "S"
        End If

        cd.Connection = cn
        cd.CommandText = "CPP_RegistraGasto_I"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        If Viewstate("Opcion") = "Modifica" Then
            cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Else
            cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = 0
        End If
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = txtNroDocumento.Text
        If Viewstate("Opcion") = "Modifica" Then
            cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Viewstate("Correlativo")
        Else
            cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = 0
        End If

        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchDocumento.Text)
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 15).Value = txtRUC.Text
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = txtNomProveedor.Text
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = txtPorIGV.Text
        If txtTipoCambio.Text.Trim.Length = 0 Then
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = 0
        Else
            cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
        End If
        If rbdolar.Checked = True Then
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = txtSubTotal.Text
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = txtIGV.Text
            If txtOtros.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = txtOtros.Text
            End If
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = txtTotal.Text
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = CDbl(txtSubTotal.Text) * CDbl(txtTipoCambio.Text)
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = CDbl(txtIGV.Text) * CDbl(txtTipoCambio.Text)
            If txtOtros.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = CDbl(txtOtros.Text) * CDbl(txtTipoCambio.Text)
            End If
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = CDbl(txtTotal.Text) * CDbl(txtTipoCambio.Text)
        Else
            cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
            cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = txtSubTotal.Text
            cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = txtIGV.Text
            If txtOtros.Text.Trim.Length = 0 Then
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
            Else
                cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = txtOtros.Text
            End If
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = txtTotal.Text
        End If
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = ddlCuentaGasto.SelectedItem.Value
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
            Response.Redirect("cppDocumento.aspx" & _
                    "?CodProveedor=" & Viewstate("CodProveedor"))
        Else
            lblmsg.Visible = True
        End If

    End Sub
    Private Sub EditaNroDocumento()
        Dim wTipoGasto, wCuentaGasto As String

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
                txtNroDocumento.Text = Trim(dr.GetValue(dr.GetOrdinal("NroComprobante")))
                txtFchDocumento.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = Trim(dr.GetValue(dr.GetOrdinal("Referencia")))
                txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("TipoCambio"))
                wTipoGasto = dr.GetValue(dr.GetOrdinal("TipoGasto"))
                wCuentaGasto = dr.GetValue(dr.GetOrdinal("CodCuenta"))
                txtSubTotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Importe")))
                txtPorIGV.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("PIGV")))
                txtIGV.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("IGV")))
                txtOtros.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Otros")))
                If CDbl(txtOtros.Text) = 0 Then
                    txtOtros.Text = ""
                End If
                If CDbl(txtTipoCambio.Text) = 0 Then
                    txtTipoCambio.Text = ""
                End If
                txtTotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If

                If dr.GetValue(dr.GetOrdinal("StsDocumento")) = "A" Then
                    cmdGrabar.Enabled = False
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaTipoGasto(wTipoGasto)
        If ddlTipoGasto.Items.Count > 0 Then
            CargaCuentaGasto(wTipoGasto, wCuentaGasto)
        End If

    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        If ddlTipoDocumento.SelectedItem.Value = "FA" Or ddlTipoDocumento.SelectedItem.Value = "RB" Then
            txtPorIGV.Text = lblPIGV.Text
        Else
            txtPorIGV.Text = 0
        End If
        CalculaMontos()
    End Sub

    Private Sub txtPorIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorIGV.TextChanged
        If Not IsNumeric(txtPorIGV.Text) Then
            lblmsg.Visible = True
            lblmsg.Text = "Error: % IGV  es dato numérico"
            Return
        End If

        CalculaMontos()
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub lbtTipoCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTipoCambio.Click
        TipoCambio()
    End Sub

    Private Sub TipoCambio()
        txtTipoCambio.Text = ""
        If rbdolar.Checked = True Then
            txtTipoCambio.Text = objRutina.LeeTipoCambioVta(objRutina.fechayyyymmdd(txtFchDocumento.Text))
        End If
    End Sub

End Class
