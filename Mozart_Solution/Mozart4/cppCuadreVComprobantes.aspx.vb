Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cppCuadreVComprobantes
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("IdReg") = Request.Params("IdReg")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodMonedaPedidos") = Request.Params("CodMoneda")
            Viewstate("Origen") = Request.Params("Origen")
            EditaPendientesPago()
            Viewstate("Opcion1") = Request.Params("Opcion1")
            If Viewstate("Opcion1") = "Cuadre" Then
                Viewstate("NroPedido") = Request.Params("NroPedido")
            End If
        End If
    End Sub
    Private Sub EditaPendientesPago()

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_PendientesAcumula_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = Viewstate("IdReg")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblTotal.Text = ToString.Format("{0:###,##0.00}", dr.GetValue(dr.GetOrdinal("Total")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        txtMonto1.Text = ToString.Format("{0:###,##0.00}", CDbl(lblTotal.Text) * 0.3)
        txtMonto2.Text = ToString.Format("{0:###,##0.00}", CDbl(lblTotal.Text) - CDbl(txtMonto1.Text))
        lblSuma.Text = Total()
    End Sub
    Private Sub btnCompletaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompletaDatos.Click
        Dim wIdReg2 As String
        Dim wTotal, wDif As Double

        wIdReg2 = CStr(Now)

        'Valida si son nùmeros
        If txtMonto1.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtMonto1.Text) Then
                lblmsg.Text = "Error: Monto 1 es numèrico"
                lblmsg.Visible = True
                Return
            Else
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto1.Text))
            End If
        End If
        If txtMonto2.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtMonto2.Text) Then
                lblmsg.Text = "Error: Monto 2 es numèrico"
                lblmsg.Visible = True
                Return
            End If
        End If
        If txtMonto3.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtMonto3.Text) Then
                lblmsg.Text = "Error: Monto 3 es numèrico"
                lblmsg.Visible = True
                Return
            End If
        End If
        If txtMonto4.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtMonto4.Text) Then
                lblmsg.Text = "Error: Monto 4 es numèrico"
                lblmsg.Visible = True
                Return

            End If
        End If
        If txtMonto5.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtMonto5.Text) Then
                lblmsg.Text = "Error: Monto 5 es numèrico"
                lblmsg.Visible = True
                Return
            End If
        End If

        'Validamos que el acumulado sea el total
        wDif = ToString.Format("{0:###,##0.00}", CDbl(lblTotal.Text) - CDbl(lblSuma.Text))

        If wDif <> 0 Then
            lblmsg.Text = "Error: La suma de montos no igualan al Monto total a distribuir."
            lblmsg.Visible = True
            Return
        End If


        If txtMonto1.Text.Trim.Length > 0 Then
            InsertaComprobante(wIdReg2, txtMonto1.Text, 1)
        End If
        If txtMonto2.Text.Trim.Length > 0 Then
            InsertaComprobante(wIdReg2, txtMonto2.Text, 2)
        End If
        If txtMonto3.Text.Trim.Length > 0 Then
            InsertaComprobante(wIdReg2, txtMonto3.Text, 3)
        End If
        If txtMonto4.Text.Trim.Length > 0 Then
            InsertaComprobante(wIdReg2, txtMonto4.Text, 4)
        End If
        If txtMonto5.Text.Trim.Length > 0 Then
            InsertaComprobante(wIdReg2, txtMonto5.Text, 5)
        End If


        If Viewstate("Opcion1") = "Cuadre" Then
            Response.Redirect("cppCuadreVComprobanteLista.aspx" & _
            "?IdRegComp=" & wIdReg2 & _
            "&IdRegPend=" & Viewstate("IdReg") & _
            "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
            "&NroPedido=" & Viewstate("NroPedido") & _
            "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos") & _
            "&Origen=" & Viewstate("Origen") & _
            "&Opcion1=" & Viewstate("Opcion1"))
        Else
            Response.Redirect("cppCuadreVComprobanteLista.aspx" & _
            "?IdRegComp=" & wIdReg2 & _
            "&IdRegPend=" & Viewstate("IdReg") & _
            "&CodProveedor=" & CInt(Viewstate("CodProveedor")) & _
            "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos") & _
            "&Origen=" & Viewstate("Origen"))
        End If


    End Sub
    Public Sub InsertaComprobante(ByVal wIdReg As String, ByVal wmonto As Double, ByVal wNumMonto As Integer)
        Dim cd As New SqlCommand()

        cd.Connection = cn
        cd.CommandText = "CPP_CuadreVComprobantes_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = wIdReg
        cd.Parameters.Add("@NroMonto", SqlDbType.Char, 25).Value = wNumMonto
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@TipoComprobante", SqlDbType.Char, 2).Value = ""
        cd.Parameters.Add("@NroComprobante", SqlDbType.Char, 20).Value = ""
        cd.Parameters.Add("@CodRelacion", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@FchComprobante", SqlDbType.Char, 8).Value = ""
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 15).Value = ""
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = ""
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = wmonto
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Viewstate("CodMonedaPedidos")
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = 0
        cd.Parameters.Add("@Flag", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@Moneda", SqlDbType.Char, 1).Value = Viewstate("CodMonedaPedidos")
        cd.Parameters.Add("@TipoCambio", SqlDbType.SmallMoney).Value = 0
        cd.Parameters.Add("@DSubTotal", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@DIGV", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@DInafecto", SqlDbType.Money).Value = 0
        If Viewstate("CodMonedaPedidos") = "D" Then
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = wmonto
        Else
            cd.Parameters.Add("@DTotal", SqlDbType.Money).Value = 0
        End If
        cd.Parameters.Add("@SSubTotal", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@SIGV", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@SInafecto", SqlDbType.Money).Value = 0
        If Viewstate("CodMonedaPedidos") = "S" Then
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = wmonto
        Else
            cd.Parameters.Add("@STotal", SqlDbType.Money).Value = 0
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
        If Trim(lblmsg.Text) <> "OK" Then
            lblmsg.Visible = True
        End If
    End Sub
    Public Function Total() As Double
        Dim wTotal As Double

        wTotal = 0
        'Valida si son nùmeros
        If txtMonto1.Text.Trim.Length > 0 Then
            If IsNumeric(txtMonto1.Text) Then
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto1.Text))
            End If
        End If
        If txtMonto2.Text.Trim.Length > 0 Then
            If IsNumeric(txtMonto2.Text) Then
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto2.Text))
            End If
        End If
        If txtMonto3.Text.Trim.Length > 0 Then
            If IsNumeric(txtMonto3.Text) Then
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto3.Text))
            End If
        End If
        If txtMonto4.Text.Trim.Length > 0 Then
            If IsNumeric(txtMonto4.Text) Then
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto4.Text))
            End If
        End If
        If txtMonto5.Text.Trim.Length > 0 Then
            If IsNumeric(txtMonto5.Text) Then
                wTotal = wTotal + ToString.Format("{0:###,##0.00}", CDbl(txtMonto5.Text))
            End If
        End If
        Return wTotal
    End Function
    Private Sub txtMonto1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto1.TextChanged
        lblSuma.Text = Total()
    End Sub
    Private Sub txtMonto2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto2.TextChanged
        lblSuma.Text = Total()
    End Sub
    Private Sub txtMonto3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto3.TextChanged
        lblSuma.Text = Total()
    End Sub
    Private Sub txtMonto4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto4.TextChanged
        lblSuma.Text = Total()
    End Sub
    Private Sub txtMonto5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto5.TextChanged
        lblSuma.Text = Total()
    End Sub
End Class
