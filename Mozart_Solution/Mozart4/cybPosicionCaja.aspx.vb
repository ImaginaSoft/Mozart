Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybPosicionCaja
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wdolares As Double

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lbltc.Text = objRutina.LeeParametroNumero("TipoCambio")
            MuestraPosicion()
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MuestraPosicion()
    End Sub

    Private Sub MuestraPosicion()
        If lbltc.Text <= 0 Then
            lblmsg.Text = "Actualize el Tipo de Cambio"
            Return
        End If
        'lblmsg.Text = "Posición al " & txtFchEmision.Text
        CargaCajaBanco()
        CargaStkBolComprados()
        CargaPendientes()
        CargaCuentasCobrar()
        CargaCuentasPagar()
        CargaSaldoPersonal()
        CargaProvision()
        CargaFondoPandero()

        Dim MontoTotal As Double
        Dim NetoCaja As Double
        MontoTotal = CDbl(BancoDolar.Text) + _
                     CDbl(StkComDolar.Text) + _
                     CDbl(PendDolar.Text) + _
                     CDbl(CobrarDolar.Text) + _
                     CDbl(PagarDolar.Text) + _
                     CDbl(PersonalDolar.Text) + _
                     CDbl(ProvisionDolar.Text) _
                  + (CDbl(CobrarSoles.Text) / CDbl(lbltc.Text)) _
                  + (CDbl(PagarSoles.Text) / CDbl(lbltc.Text)) _
                  + (CDbl(PendSoles.Text) / CDbl(lbltc.Text)) _
                  + (CDbl(StkComSoles.Text) / CDbl(lbltc.Text)) _
                  + (CDbl(PersonalSoles.Text) / CDbl(lbltc.Text)) _
                  + (CDbl(ProvisionSoles.Text) / CDbl(lbltc.Text))

        Total.Text = String.Format("{0:###,###,###,##0.00}", MontoTotal)

        'restar el fondo pandero
        NetoCaja = MontoTotal - CDbl(PanderoDolar.Text)
        NetoDolar.Text = String.Format("{0:###,###,###,##0.00}", NetoCaja)
    End Sub


    Private Sub CargaCajaBanco()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CYB_PCBanco_S"
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "CajaBancos")
        dgPosicionCaja.DataSource = ds.Tables("CajaBancos")
        dgPosicionCaja.DataBind()
    End Sub

    Private Sub CargaStkBolComprados()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCStkBolComprados_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                StkComSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                StkComDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub CargaPendientes()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCPendiente_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                PendSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                PendDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub CargaCuentasCobrar()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        '        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                CobrarSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                CobrarDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaCuentasPagar()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCProveedor_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                PagarSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                PagarDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaSaldoPersonal()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCSaldosPersonal_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                PersonalSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                PersonalDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaProvision()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCProvision_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ProvisionSoles.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Soles")))
                ProvisionDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaFondoPandero()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_PCFondoPandero_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                PanderoDolar.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Dolares")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub dgPosicionCaja_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPosicionCaja.ItemDataBound
        If Trim(e.Item.Cells(1).Text) = "SubTotal Dolares" Then

            wdolares = CDbl(e.Item.Cells(3).Text)
            e.Item.Cells(3).ForeColor = Color.Black
            e.Item.Cells(3).Font.Bold = True
        Else
            If Trim(e.Item.Cells(1).Text) = "SubTotal Nuevos Soles" Then

                wdolares = wdolares + CDbl(e.Item.Cells(3).Text)
                e.Item.Cells(2).ForeColor = Color.Black
                e.Item.Cells(2).Font.Bold = True
            End If
        End If
        BancoDolar.Text = String.Format("{0:###,###,###,##0.00}", wdolares)
    End Sub

End Class
