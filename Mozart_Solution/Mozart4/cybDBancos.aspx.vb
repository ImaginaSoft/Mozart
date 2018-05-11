Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cybDBancos
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            CargaDocumento()
        End If

    End Sub
    Public Sub CargaDocumento()
        Dim wPIGV As Double = 0

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cyb_DBancoNroDoc_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblTipoDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("TipoDocumento")))
                lblNomDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NomDocumento")))
                lblNumeroDocumento.Text = CStr(dr.GetValue(dr.GetOrdinal("NroDocumento")))
                lblCodigoBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("CodBanco"))) & "  " & CStr(dr.GetValue(dr.GetOrdinal("NomBanco")))
                lblSecBanco.Text = CStr(dr.GetValue(dr.GetOrdinal("SecBanco")))
                lblReferencia.Text = CStr(dr.GetValue(dr.GetOrdinal("Referencia")))
                lbltotal.Text = CStr(dr.GetValue(dr.GetOrdinal("Total")))
                lblMoneda.Text = CStr(dr.GetValue(dr.GetOrdinal("CodMoneda")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cmdAnularDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnularDoc.Click
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CYB_AnulaDocumentoBanco_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
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
            lblmsg.Text = "Se anulo el documento " & "número " & Viewstate("NroDocumento") & " de tipo" & Viewstate("TipoDocumento")
        End If
    End Sub

    Private Sub cmdModifDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifDoc.Click
        If Trim(lblTipoDocumento.Text) = "IN" Or Trim(lblTipoDocumento.Text) = "SA" Then

        Else
            Response.Redirect("cybIngresoSalida.aspx" & _
                    "?NroDocumento=" & Viewstate("NroDocumento") & _
                    "&TipoDocumento=" & Viewstate("TipoDocumento"))
        End If
    End Sub

End Class
