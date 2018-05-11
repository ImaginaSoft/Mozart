Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cybDBancosDetalle
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then

            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("TipoDocumento2") = Request.Params("TipoDocumento2")
            Viewstate("NroDocumento2") = Request.Params("NroDocumento2")

            If (Viewstate("NroDocumento") > 0) Then
                CargaDocumento()
                CargaDocumentoReferencia()
            Else
                CargaDocumento()
            End If

            If Mid(lblEstado.Text, 1, 1) = "A" Then
                cmdModifDoc.Enabled = False
                cmdAnularDoc.Enabled = False
            End If

        End If

    End Sub

    Public Sub CargaDocumento()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = ViewState("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblTipoDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("TipoDocumento")))
                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblNumeroDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NroDocumento")))
                lblCodigoBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("NomBanco")))
                lblNumeroCuenta.Text = CStr(dr.GetValue(dr.GetOrdinal("NroCuenta")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lbltotal.Text = CStr(dr.GetValue(dr.GetOrdinal("Total")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
                lblEstado.Text = CStr(dr.GetValue(dr.GetOrdinal("StsDocumento")))
                txtFchEmision.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Public Sub CargaDocumentoReferencia()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CYB_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento2")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = ViewState("NroDocumento2")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblTipoDoc2.Text = CStr(dr.GetValue(dr.GetOrdinal("TipoDocumento")))
                lblNomDoc2.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblNumDoc2.Text = CStr(dr.GetValue(dr.GetOrdinal("NroDocumento")))
                lblCodigoBanco2.Text = CStr(dr.GetValue(dr.GetOrdinal("NomBanco")))
                lblEstadoRef.Text = CStr(dr.GetValue(dr.GetOrdinal("StsDocumento")))
                lblNumeroCuenta2.Text = CStr(dr.GetValue(dr.GetOrdinal("NroCuenta")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cmdAnularDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularDoc.Click

        If (Viewstate("NroDocumento2") > 0) Then
            AnulaDocumentoTransferencia(Viewstate("TipoDocumento"), Viewstate("NroDocumento"), Viewstate("TipoDocumento2"), Viewstate("NroDocumento2"))
        Else
            AnulaDocumentoIngresoSalida(Viewstate("TipoDocumento"), Viewstate("NroDocumento"))
        End If
    End Sub

    Private Sub AnulaDocumentoIngresoSalida(ByVal cTipo As String, ByVal cNumero As Integer)
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CYB_AnulaDocumentoBanco_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = cTipo
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = cNumero
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
            Response.Redirect("cybDocumentoBancos.aspx" & _
            "?Fecha=" & txtFchEmision.Text)
        End If
    End Sub
    Private Sub AnulaDocumentoTransferencia(ByVal cTipo As String, ByVal cNumero As Integer, ByVal cTipo2 As String, ByVal cNumero2 As Integer)
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CYB_AnulaDocumentoBancoTransf_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = cTipo
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = cNumero
        cd.Parameters.Add("@TipoDocumento2", SqlDbType.Char, 2).Value = cTipo2
        cd.Parameters.Add("@NroDocumento2", SqlDbType.Int).Value = cNumero2
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
            Response.Redirect("cybDocumentoBancos.aspx" & _
            "?Fecha=" & txtFchEmision.Text)
        End If
    End Sub

    Private Sub cmdModifDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifDoc.Click
        Dim NroDocOrigen, NroDocDestino As Integer
        Dim TipoDocOrigen, TipoDocDestino As String

        If Len(Trim(lblNumDoc2.Text)) = 0 Then
            Response.Redirect("cybIngresoSalida.aspx" & _
                              "?NroDocumento=" & Viewstate("NroDocumento") & _
                              "&TipoDocumento=" & Viewstate("TipoDocumento"))
        Else

            If Viewstate("TipoDocumento") = "TS" Then
                NroDocOrigen = Viewstate("NroDocumento")
                TipoDocOrigen = Viewstate("TipoDocumento")
                NroDocDestino = Viewstate("NroDocumento2")
                TipoDocDestino = Viewstate("TipoDocumento2")
            Else
                NroDocOrigen = Viewstate("NroDocumento2")
                TipoDocOrigen = Viewstate("TipoDocumento2")
                NroDocDestino = Viewstate("NroDocumento")
                TipoDocDestino = Viewstate("TipoDocumento")
            End If

            Response.Redirect("cybTransferencia.aspx" & _
                "?NroDocumento=" & NroDocOrigen & _
                "&TipoDocumento=" & TipoDocOrigen & _
                "&NroDocumento2=" & NroDocDestino & _
                "&TipoDocumento2=" & TipoDocDestino)
        End If
    End Sub

End Class
