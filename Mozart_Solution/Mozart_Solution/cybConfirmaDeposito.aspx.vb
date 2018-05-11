Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybConfirmaDeposito
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim dMontoDeposito As Double = 0
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("IdReg") = Request.Params("IdReg")
            ViewState("CodMoneda") = Request.Params("CodMoneda")
            txtFchEmision.Text = objRutina.fechaddmmyyyy(0)

            lblAcciones1.Text = "1. Para cada movimiento seleccionado se confirma la operación de Cargo/Abono.<br>" & _
                    "2. Por cada monto de comisión se genera una deuda con el proveedor (DC). <br>" & _
                    "3. Comisión se paga con efectivo (EF) usando la cta MO/TO PENTA y se liquida ambos documentos. <br>" & _
                    "4. Registro de salida de la cta MO/TO PENTA por el monto del depósito <br>" & _
                    "5. Registro de ingreso a la cta selecciona por el monto del depósito<br>" & _
                    "6. Disminución de la provisión por Tarjeta de crédito en Proveedor(91)<br>"
            CargaPagos()
            Dim sCodBanco As String = objRutina.LeeParametroTexto("IngTCCodBanco")
            CargaBanco(sCodBanco)
        End If
    End Sub
    Private Sub CargaPagos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CYB_ConfirmaDeposito_S"
        da.SelectCommand.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdReg")
        Dim nReg As Integer = da.Fill(ds, "Pagos")
        dgPagos.DataSource = ds.Tables("Pagos")
        dgPagos.DataBind()
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
            Try
                ddlBanco.Items.FindByValue(pCodBanco).Selected = True
            Catch ex As Exception
                lblmsg.Text = "Banco default " & pCodBanco & " no existe en la lista"
            End Try
        End If

        If ddlBanco.Items.Count > 0 Then
            CargaNroCuenta(ddlBanco.SelectedItem.Value, objRutina.LeeParametroTexto("IngTCSecBanco"), Viewstate("CodMoneda"))
        Else
            CargaNroCuenta(" ", " ", Viewstate("CodMoneda"))
        End If
    End Sub

    Private Sub CargaNroCuenta(ByVal pcodBanco As String, _
                                ByVal psecBanco As String, _
                                ByVal pDocMoneda As String)

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BancoCuenta_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = pcodBanco
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = pDocMoneda
        da.Fill(ds, "TBancoCuenta")
        ddlNroCuenta.DataSource = ds.Tables("TBancoCuenta")
        ddlNroCuenta.DataBind()

        If psecBanco.Trim.Length > 0 Then
            Try
                ddlNroCuenta.Items.FindByValue(psecBanco).Selected = True
            Catch ex As Exception
                lblmsg.Text = "Nro Cuenta default " & psecBanco & " no existe en la lista"
            End Try
        End If
    End Sub

    Private Sub dgPagos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPagos.SelectedIndexChanged
        Response.Redirect("cybConfirmaPago.aspx" & _
        "?TipoDocumento=" & dgPagos.Items(dgPagos.SelectedIndex).Cells(2).Text & _
        "&NroDocumento=" & dgPagos.Items(dgPagos.SelectedIndex).Cells(3).Text & _
        "&Opcion=C")
    End Sub

    Private Sub dgPagos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPagos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            dMontoDeposito = dMontoDeposito + e.Item.Cells(6).Text
            If e.Item.Cells(6).Text >= 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
            End If
        ElseIf e.Item.ItemType = ListItemType.Footer Then

            If dMontoDeposito >= 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
            End If
            e.Item.Cells(6).Text = String.Format("{0:###,###,###,###.00}", dMontoDeposito)
            lblDeposito.Text = String.Format("{0:###,###,###,###.00}", dMontoDeposito)
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlBanco.Items.Count = 0 Then
            lblmsg.Text = "No existe Banco"
            Return
        End If
        If ddlNroCuenta.Items.Count = 0 Then
            lblmsg.Text = "No existe Nro. Cuenta"
            Return
        End If
        If lblDeposito.Text < 0 Then
            lblmsg.Text = "Monto del deposito debe ser positivo"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CYB_ConfirmaDeposito_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdReg")
        cd.Parameters.Add("@FchDepositoTC", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@CodBancoDeposito", SqlDbType.Char, 3).Value = ddlBanco.SelectedItem.Value
        cd.Parameters.Add("@SecBancoDeposito", SqlDbType.Char, 2).Value = ddlNroCuenta.SelectedItem.Value
        cd.Parameters.Add("@CodMonedaDeposito", SqlDbType.Char, 1).Value = Viewstate("CodMoneda")
        cd.Parameters.Add("@TotalDeposito", SqlDbType.Money).Value = lblDeposito.Text
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
            Response.Redirect("cybConfirma.aspx")
        End If
    End Sub


End Class
