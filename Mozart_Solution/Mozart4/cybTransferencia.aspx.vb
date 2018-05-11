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

Partial Class cybTransferencia
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim wpcodBanco, wpcodBancod As String
            'Recepcion de Datos
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("TipoDocumento2") = Request.Params("TipoDocumento2")
            Viewstate("NroDocumento2") = Request.Params("NroDocumento2")
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)

            CargaBancoOrigen("")
            CargaBancoDestino("")

            wpcodBanco = ddlBanco.SelectedItem.Value
            wpcodBancod = ddlBancoDestino.SelectedItem.Value

            If Len(Trim(wpcodBanco)) <> 0 Then
                CargaNroCuentaOrigen(wpcodBanco, "")
            Else
                Return
            End If

            If Len(Trim(wpcodBancod)) <> 0 Then
                CargaNroCuentaDestino(wpcodBancod, "")
            Else
                Return
            End If

            If Viewstate("NroDocumento") > 0 Then
                CargaDocumentoOrigen()
                CargaDocumentoDestino()
            End If
        End If
    End Sub
    Private Sub CargaBancoOrigen(ByVal pcodBanco As String)
        'Bancos Activos
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoActivo_S"
        da.Fill(ds, "TBancoOrigen")
        ddlBanco.DataSource = ds.Tables("TBancoOrigen")
        ddlBanco.DataBind()
        If pcodBanco.Trim.Length > 0 Then
            ddlBanco.Items.FindByValue(pcodBanco).Selected = True
        End If

    End Sub
    Private Sub CargaBancoDestino(ByVal pcodBanco As String)
        'Banco Destino
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoActivo_S"
        da.Fill(ds, "TBancoDestino")
        ddlBancoDestino.DataSource = ds.Tables("TBancoDestino")
        ddlBancoDestino.DataBind()

        If pcodBanco.Trim.Length > 0 Then
            ddlBancoDestino.Items.FindByValue(pcodBanco).Selected = True
        End If


    End Sub
    Private Sub CargaNroCuentaOrigen(ByVal pcodBanco As String, ByVal psecBanco As String)
        'Cuenta de Bancos

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wpcodBanco As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoCuentaCodBanco_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        da.Fill(ds, "TBancoCuentaOrigen")
        ddlNroCuenta.DataSource = ds.Tables("TBancoCuentaOrigen")
        ddlNroCuenta.DataBind()

        If psecBanco.Trim.Length > 0 Then
            ddlNroCuenta.Items.FindByValue(psecBanco).Selected = True
        End If

        SaldoCuentaBanco(ddlBanco.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "O")
    End Sub

    Private Sub CargaNroCuentaDestino(ByVal pcodBanco As String, ByVal psecBanco As String)
        'Cuenta de Bancos

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wpcodBanco As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoCuentaCodBanco_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        da.Fill(ds, "TBancoCuentaDestino")
        ddlNroCtaDestino.DataSource = ds.Tables("TBancoCuentaDestino")
        ddlNroCtaDestino.DataBind()

        If psecBanco.Trim.Length > 0 Then
            ddlNroCtaDestino.Items.FindByValue(psecBanco).Selected = True
        End If

        SaldoCuentaBanco(ddlBancoDestino.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "D")
    End Sub

    Public Sub CargaDocumentoOrigen()

        lblNumero.Visible = True
        txtNumero.Visible = True
        txtNumero.Text = ViewState("NroDocumento")
        Dim wPIGV As Double = 0
        Dim wCodMoneda, wCodBanco, wSecBanco As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wCodMoneda = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                wCodBanco = dr.GetValue(dr.GetOrdinal("CodBanco"))
                wSecBanco = dr.GetValue(dr.GetOrdinal("SecBanco"))
                txtFchEmision.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtImporte.Text = dr.GetValue(dr.GetOrdinal("Total"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaBancoOrigen(wCodBanco)
        CargaNroCuentaOrigen(wCodBanco, wSecBanco)
    End Sub

    Public Sub CargaDocumentoDestino()
        lblNumero2.Visible = True
        txtNumero2.Visible = True
        txtNumero2.Text = ViewState("NroDocumento2")
        Dim wPIGV As Double = 0
        Dim wCodMoneda, wCodBanco, wSecBanco As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento2")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento2")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wCodMoneda = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                wCodBanco = dr.GetValue(dr.GetOrdinal("CodBanco"))
                wSecBanco = dr.GetValue(dr.GetOrdinal("SecBanco"))
                txtTipoCambio.Text = dr.GetValue(dr.GetOrdinal("TipoCambio"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaBancoDestino(wCodBanco)
        CargaNroCuentaDestino(wCodBanco, wSecBanco)

    End Sub
    Private Sub ddlBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBanco.SelectedIndexChanged
        CargaNroCuentaOrigen(ddlBanco.SelectedItem.Value, "")
        SaldoCuentaBanco(ddlBanco.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "O")
        SaldoCuentaBanco(ddlBancoDestino.SelectedItem.Value, ddlNroCtaDestino.SelectedItem.Value, "D")

    End Sub

    Private Sub ddlBancoDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBancoDestino.SelectedIndexChanged
        CargaNroCuentaDestino(ddlBancoDestino.SelectedItem.Value, "")
        SaldoCuentaBanco(ddlBanco.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "O")
        SaldoCuentaBanco(ddlBancoDestino.SelectedItem.Value, ddlNroCtaDestino.SelectedItem.Value, "D")
    End Sub

    Private Sub ddlNroCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNroCuenta.SelectedIndexChanged
        SaldoCuentaBanco(ddlBanco.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "O")
        SaldoCuentaBanco(ddlBancoDestino.SelectedItem.Value, ddlNroCtaDestino.SelectedItem.Value, "D")
    End Sub

    Private Sub ddlNroCtaDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNroCtaDestino.SelectedIndexChanged
        SaldoCuentaBanco(ddlBancoDestino.SelectedItem.Value, ddlNroCtaDestino.SelectedItem.Value, "D")
        SaldoCuentaBanco(ddlBanco.SelectedItem.Value, ddlNroCuenta.SelectedItem.Value, "O")
    End Sub

    Private Sub SaldoCuentaBanco(ByVal pcodBanco As String, ByVal psecBanco As String, ByVal psalida As String)
        Dim wsaldo As Double = 0

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_SaldoCtaBanco_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = psecBanco
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()

                wsaldo = CDbl(dr.GetValue(dr.GetOrdinal("Saldo")))

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If Trim(psalida).Equals("O") Then
            lblS.Text = wsaldo
        Else
            lblSd.Text = wsaldo
        End If

        CargaMoneda(pcodBanco, psecBanco, psalida)
    End Sub
    Private Sub CargaMoneda(ByVal pcodBanco As String, ByVal psecBanco As String, ByVal psalida As String)
        Dim wcodmoneda As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_BancoSecBanco_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = psecBanco
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wcodmoneda = dr.GetValue(dr.GetOrdinal("CodMoneda"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If Trim(psalida).Equals("O") Then

            If wcodmoneda = "S" Then
                lblMonedaOrigen.Text = "Soles"
            End If
            If wcodmoneda = "D" Then
                lblMonedaOrigen.Text = "Dolares"
            End If

        Else
            If wcodmoneda = "S" Then
                lblMonedaDestino.Text = "Soles"
            End If
            If wcodmoneda = "D" Then
                lblMonedaDestino.Text = "Dolares"
            End If
        End If
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = " El Importe es dato numérico"
            Return
        End If

        If (ddlBanco.SelectedItem.Value = ddlBancoDestino.SelectedItem.Value) And (ddlNroCuenta.SelectedItem.Value = ddlNroCtaDestino.SelectedItem.Value) Then
            lblmsg.Text = "Banco destino no puede ser igual al Banco origen"
            Return
        End If

        Dim wImporteDestino As Double
        If lblMonedaOrigen.Text = lblMonedaDestino.Text Then
            txtTipoCambio.Text = "0"
            wImporteDestino = txtImporte.Text
        Else
            If Len(Trim(txtTipoCambio.Text)) = 0 Then
                lblmsg.Text = "Tipo de Cambio obligatorio"
                Return
            End If

            If Not IsNumeric(txtTipoCambio.Text) Then
                lblmsg.Text = "Tipo de Cambio es numérico"
                Return
            End If
            If txtTipoCambio.Text <= 0 Then
                lblmsg.Text = "Tipo de Cambio es obligatorio"
                Return
            End If

            If lblMonedaOrigen.Text = "Soles" Then
                'dolares
                wImporteDestino = Math.Round(txtImporte.Text / txtTipoCambio.Text, 2)
            Else
                'Soles
                wImporteDestino = Math.Round(txtImporte.Text * txtTipoCambio.Text, 2)
            End If
        End If


        Dim cd As New SqlCommand
        Dim wNroDoc, wNroDocIngreso, wNroDocSalida As Integer
        Dim wcodmoneda1, wcodmoneda2 As String


        If lblMonedaOrigen.Text = "Soles" Then
            wcodmoneda1 = "S"
        Else
            wcodmoneda1 = "D"
        End If
        If lblMonedaDestino.Text = "Soles" Then
            wcodmoneda2 = "S"
        Else
            wcodmoneda2 = "D"
        End If

        If Len(Trim(Viewstate("NroDocumento"))) = 0 Then
            wNroDocIngreso = 0
            wNroDocSalida = 0
        Else
            wNroDocSalida = Viewstate("NroDocumento")
            wNroDocIngreso = Viewstate("NroDocumento2")
        End If

        cd.Connection = cn
        cd.CommandText = "CYB_Transferencia_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroDocSalida", SqlDbType.Int).Value = wNroDocSalida
        cd.Parameters.Add("@NroDocIngreso", SqlDbType.Int).Value = wNroDocIngreso
        cd.Parameters.Add("@CodBancoOrigen", SqlDbType.Char, 3).Value = ddlBanco.SelectedItem.Value
        cd.Parameters.Add("@SecBancoOrigen", SqlDbType.Char, 2).Value = ddlNroCuenta.SelectedItem.Value
        cd.Parameters.Add("@TotalOrigen", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@CodMonedaOrigen", SqlDbType.Char, 1).Value = wcodmoneda1
        cd.Parameters.Add("@CodBancoDestino", SqlDbType.Char, 3).Value = ddlBancoDestino.SelectedItem.Value
        cd.Parameters.Add("@SecBancoDestino", SqlDbType.Char, 2).Value = ddlNroCtaDestino.SelectedItem.Value
        cd.Parameters.Add("@TotalDestino", SqlDbType.Money).Value = wImporteDestino
        cd.Parameters.Add("@CodMonedaDestino", SqlDbType.Char, 1).Value = wcodmoneda2
        cd.Parameters.Add("@TipoCanbioDestino", SqlDbType.SmallMoney).Value = txtTipoCambio.Text
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
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
            Response.Redirect("cybDocumentoBancos.aspx" & _
            "?Fecha=" & txtFchEmision.Text)
        End If
    End Sub

End Class
