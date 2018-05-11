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

Partial Class cybConfirmaPago
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "R" Then
                lblTitulo.Text = "Registra comisión por Tarjeta de Crédito"
            Else
                lblTitulo.Text = "Confirma ingreso a la Cuenta"
            End If
            CargaDocumento()
        End If
    End Sub
    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If Viewstate("Opcion") = "R" Then
            RegistraComision()
        Else
            ConfirmaIngreso()
        End If
    End Sub

    Private Sub RegistraComision()
        If txtComisionTC.Text.Trim.Length = 0 Then
            lblmsg.Text = "Comisión es dato obligatorio"
            Return
        End If
        If Not IsNumeric(txtComisionTC.Text.Trim.Length) Then
            lblmsg.Text = "Comisión es dato numérico"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CYB_ConfirmaComision_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@ComisionTC", SqlDbType.Money).Value = txtComisionTC.Text
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

    Private Sub ConfirmaIngreso()
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CYB_ConfirmaPago_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
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

        If lblmsg.Text.Trim = "OK" Then
            Response.Redirect("cybConfirma.aspx")
        End If
    End Sub

    Private Sub CargaDocumento()
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
                lblDocumento.Text = dr.GetValue(dr.GetOrdinal("TipoDocumento")) & " " & _
                                    dr.GetValue(dr.GetOrdinal("NroDocumento")) & "&nbsp;&nbsp;&nbsp;" & _
                                    dr.GetValue(dr.GetOrdinal("NomDocumento"))
                lblFchEmision.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                lblTotal.Text = ToString.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("Total")))
                lblReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                lblGlosaDocumento.Text = dr.GetValue(dr.GetOrdinal("GlosaDocumento"))
                lblCodAutoriza.Text = Request.Params("CodAutoriza")
                lblBanco.Text = dr.GetValue(dr.GetOrdinal("NomBanco"))
                lblCuenta.Text = dr.GetValue(dr.GetOrdinal("NroCuenta"))
                lblMoneda.Text = dr.GetValue(dr.GetOrdinal("CodMoneda"))
                txtComisionTC.Text = ToString.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("ComisionTC")))

                If ViewState("Opcion") = "R" Then
                    If dr.GetValue(dr.GetOrdinal("FlagComisionTC")) = "S" Then
                        lblComision.Visible = True
                        txtComisionTC.Visible = True
                        cmbGrabar.Visible = True
                    End If
                Else
                    'If dr.GetValue(dr.GetOrdinal("FlagComisionTC")) <> "S" Then
                    cmbGrabar.Visible = True
                    'End If
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

End Class
