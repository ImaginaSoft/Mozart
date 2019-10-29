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
Imports System.Transactions

Partial Class cpcRegistraCargo
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            CargaTipoDocumento()

            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                txtNroDocumento.Text = Viewstate("NroDocumento")
                EditaNroDocumento()
            Else
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
                txtpIGV.Text = Session("PIGV")
            End If

            If Viewstate("NroVersion") > 0 Then
                txtPedido.Text = "Ajuste Pedido # " & CStr(Viewstate("NroPedido")) & " Version " & CStr(Viewstate("NroVersion"))
            End If

        End If
    End Sub

    Private Sub EditaNroDocumento()
        ' Dim ds As New DataSet()
        ' Dim da As New SqlDataAdapter()
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_NroDocumento_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = ViewState("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtpIGV.Text = String.Format("{0:##0.00}", dr.GetValue(dr.GetOrdinal("PIGV")))
                txtImporte.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("Importe")))
                txtIGV.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("IGV")))
                txtTotal.Text = String.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    rbdolar.Checked = True
                    rbsoles.Checked = False
                Else
                    rbdolar.Checked = False
                    rbsoles.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub



    Private Sub CargaTipoDocumento()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = "NC"
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub

    Private Sub LimpiaVentana()
        txtImporte.Text = ""
        txtpIGV.Text = Session("PIGV")
        txtIGV.Text = ""
        txtTotal.Text = ""
        txtFchEmision.Text = ""
    End Sub

    Private Sub rbdolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdolar.CheckedChanged
        rbsoles.Checked = False
        rbdolar.Checked = True
    End Sub

    Private Sub rbsoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsoles.CheckedChanged
        rbsoles.Checked = True
        rbdolar.Checked = False
    End Sub


    Private Sub CalculaTotal()
        Dim wPIGV, wIGV, wTOTAL, wIMPORTE As Double

        If Len(Trim(txtpIGV.Text)) = 0 Then
            wPIGV = 0
        Else
            If Not IsNumeric(Trim(txtpIGV.Text)) Then
                lblmsg.Text = "Porcentaje IGV es dato númerico"
                Return
            Else
                wPIGV = txtpIGV.Text
            End If
        End If
        If Len(Trim(txtImporte.Text)) = 0 Then
            wIMPORTE = 0
        Else
            If Not IsNumeric(Trim(txtImporte.Text)) Then
                lblmsg.Text = "Importe es dato númerico"
                Return
            Else
                wIMPORTE = txtImporte.Text
                wIMPORTE = Math.Round(wIMPORTE, 2)
                txtImporte.Text = wIMPORTE
            End If
        End If
        wIGV = Math.Round(wPIGV * wIMPORTE / 100, 2)
        txtIGV.Text = CStr(wIGV)
        txtTotal.Text = CStr(wIGV + wIMPORTE)
    End Sub


    Private Sub txtIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIGV.TextChanged
        CalculaTotal()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        'Dim sMensajeError As String = ""
        'Dim sResultado As String = ""
        'Using transScope As New TransactionScope
        '    Try
        '        Dim cd As New SqlCommand

        '        '-----------------------------------------------------
        '        'Validaciones(si est afacturado y si pertenece a un periodo anterior, si de vuelve ok en los 4 botyones no debe dehar procesar)
        '        '-----------------------------------------------------

        '        cd.Connection = cn
        '        cd.CommandType = CommandType.StoredProcedure
        '        cd.CommandText = "SYS_ValidarFacturacion_S"

        '        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        '        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        '        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
        '        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ViewState("CodCliente")
        '        cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500).Value = ""

        '        cd.Parameters("@MsgTrans").Direction = ParameterDirection.Output

        '        Try
        '            cn.Open()
        '            cd.ExecuteNonQuery()
        '            sResultado = cd.Parameters("@MsgTrans").Value
        '        Catch ex1 As SqlException
        '            sResultado = "Error: " & ex1.Message
        '        Catch ex2 As Exception
        '            sResultado = "Error: " & ex2.Message
        '        Finally
        '            cn.Close()
        '        End Try

        '        If Not sResultado.Trim().Equals("OK") Then
        '            Throw New Exception(sResultado)
        '        End If


        '    Catch ex As Exception

        '    End Try
        'End Using


        If Len(Trim(txtpIGV.Text)) = 0 Then
            txtpIGV.Text = "0"
        End If

        Dim wCodMoneda As String
        Dim wNroDoc As String

        Dim wNroDocumento As Integer
        If Viewstate("NroDocumento") > 0 Then
            wNroDocumento = Viewstate("NroDocumento")
        Else
            wNroDocumento = 0
        End If

        Dim wNroPedido, wNroPro, wNroVer As Integer
        If Viewstate("NroVersion") > 0 Then
            wNroPedido = Viewstate("NroPedido")
            wNroPro = Viewstate("NroPropuesta")
            wNroVer = Viewstate("NroVersion")
        Else
            wNroPedido = 0
            wNroPro = 0
            wNroVer = 0
        End If
        If rbdolar.Checked Then
            wCodMoneda = "D"
        Else
            wCodMoneda = "S"
        End If

        Dim cd As New SqlCommand()

        cd.Connection = cn
        cd.CommandText = "CPC_RegistraCargos_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = txtFchEmision.Text.Substring(6, 4) + txtFchEmision.Text.Substring(3, 2) + txtFchEmision.Text.Substring(0, 2)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        cd.Parameters.Add("@Importe", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@Otros", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = CDbl(txtpIGV.Text)
        cd.Parameters.Add("@IGV", SqlDbType.Money).Value = CDbl(txtIGV.Text)
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtTotal.Text
        cd.Parameters.Add("@Saldo", SqlDbType.Money).Value = txtTotal.Text
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = wNroPro
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = wNroVer
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
            wNroDoc = cd.Parameters("@NroDoc").Value
            Response.Redirect("cpcDocumento.aspx" & _
                            "?CodCliente=" & Viewstate("CodCliente"))
            '            lblmsg.Text = "Se grabo correctamente Documento " & ddlTipoDocumento.SelectedItem.Value & " " & wNroDoc
        End If
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        CalculaTotal()
    End Sub

    Private Sub txtpIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpIGV.TextChanged
        CalculaTotal()
    End Sub

End Class
