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

Partial Class cppRegistraDebito
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")

            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")


            If Viewstate("NroDocumento") > 0 Then
                Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
                lblNroDocumento.Visible = True
                txtNroDocumento.Visible = True
                txtNroDocumento.Text = Viewstate("NroDocumento")
                EditaNroDocumento()
            Else
                Viewstate("TipoDocumento") = "ND"
                lblNroDocumento.Visible = False
                txtNroDocumento.Visible = False
                txtFchEmision.Text = objRutina.fechaddmmyyyy(0)
                txtpIGV.Text = 0 'Session("PIGV")
                CargaTipoDocumento(False)
            End If

            If Viewstate("NroVersion") > 0 Then
                Viewstate("TipoDocumento") = "ND"
                txtPedido.Text = "Ajuste Pedido # " & CStr(Viewstate("NroPedido")) & " Version " & CStr(Viewstate("NroVersion"))
                CargaTipoDocumento(False)
            End If
        End If

    End Sub
    Private Sub EditaNroDocumento()
        CargaTipoDocumento(False)

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
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                txtReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                txtpIGV.Text = dr.GetValue(dr.GetOrdinal("PIGV"))
                txtImporte.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Importe")))
                txtIGV.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("IGV")))
                txtOtros.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Otros")))
                txtTotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("total")))
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


    Private Sub CargaTipoDocumento(ByVal ptodos As Boolean)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ptodos Then
            da.SelectCommand.CommandText = "TAB_TipoDocumentoOperacion_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = "A"
        Else
            da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
            da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
            da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        End If
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub


    Private Sub LimpiaVentana()
        txtImporte.Text = ""
        txtpIGV.Text = Session("PIGV")
        txtIGV.Text = ""
        txtOtros.Text = ""
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
        Dim wPIGV, wIGV, wIMPORTE, wOTROS As Double

        If Len(Trim(txtImporte.Text)) = 0 Then
            wIMPORTE = 0
        Else
            If IsNumeric(txtImporte.Text) Then
                txtImporte.Text = Math.Round(CDbl(txtImporte.Text), 2)
                wIMPORTE = CDbl(txtImporte.Text)
            Else
                lblmsg.Text = "EL Importe  es de tipo Númerico"
                Return
            End If
        End If

        If Len(Trim(txtpIGV.Text)) = 0 Then
            wPIGV = 0
        Else
            If IsNumeric(txtpIGV.Text) Then
                wPIGV = CDbl(txtpIGV.Text)
            Else
                lblmsg.Text = "EL IGV  es de tipo Númerico"
                Return
            End If
        End If

        If Len(Trim(txtOtros.Text)) = 0 Then
            wOTROS = 0
        Else
            If IsNumeric(txtOtros.Text) Then
                txtOtros.Text = Math.Round(CDbl(txtOtros.Text), 2)
                wOTROS = CDbl(txtOtros.Text)
            Else
                lblmsg.Text = "Otro Importe es tipo Númerico"
                Return
            End If
        End If

        wIGV = Math.Round(wIMPORTE * wPIGV / 100, 2)
        txtIGV.Text = CStr(wIGV)
        txtTotal.Text = CStr(wIMPORTE + wIGV + wOTROS)
    End Sub


    Private Sub txtIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CalculaTotal()
    End Sub

    Private Sub txtOtros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtros.TextChanged
        CalculaTotal()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtImporte.Text) Then
            lblmsg.Text = "Importe es dato númerico"
            Return
        End If
        If Not IsNumeric(txtOtros.Text) And Len(Trim(txtOtros.Text)) <> 0 Then
            lblmsg.Text = "Importe es dato númerico"
            Return
        End If

        Dim wMoneda, wMoneda1 As String
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
        If Len(Trim(txtOtros.Text)) = 0 Then
            txtOtros.Text = "0"
        End If

        If rbdolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_RegistraDebito_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroDoc", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = wNroDocumento
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = txtFchEmision.Text.Substring(6, 4) + txtFchEmision.Text.Substring(3, 2) + txtFchEmision.Text.Substring(0, 2)
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@GlosaDocumento", SqlDbType.VarChar, 50).Value = " "
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        cd.Parameters.Add("@Importe", SqlDbType.Money).Value = txtImporte.Text
        cd.Parameters.Add("@Otros", SqlDbType.Money).Value = CDbl(txtOtros.Text)
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = CDbl(txtpIGV.Text)
        cd.Parameters.Add("@IGV", SqlDbType.Money).Value = CDbl(txtIGV.Text)
        cd.Parameters.Add("@Total", SqlDbType.Money).Value = txtTotal.Text
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = wNroPro
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = wNroVer
        cd.Parameters.Add("@Saldo", SqlDbType.Money).Value = txtTotal.Text
        cd.Parameters.Add("@RegistraNC", SqlDbType.Char, 1).Value = "S" 'Registra automaticamente NC para Liq.
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
            txtReferencia.Text = ""
            txtImporte.Text = ""
            LimpiaVentana()
            lblmsg.Text = "Se grabo correctamente Documento " & ddlTipoDocumento.SelectedItem.Value & " " & wNroDoc
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)

            Response.Redirect("cppDocumento.aspx" & _
                "?CodProveedor=" & Viewstate("CodProveedor"))

        End If
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        CalculaTotal()
    End Sub

    Private Sub txtpIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpIGV.TextChanged
        CalculaTotal()
    End Sub

End Class
