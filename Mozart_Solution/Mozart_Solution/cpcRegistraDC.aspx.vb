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

Partial Class cpcRegistraDC
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("TipoDocumento") = Request.Params("TipoDocumento")
            Viewstate("NroDocumento") = Request.Params("NroDocumento")
            CargaTipoDocumento()
            txtNroDocumento.Text = Viewstate("NroDocumento")
            EditaNroDocumento()

        End If
    End Sub

    Private Sub EditaNroDocumento()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader

        cd.Connection = cn
        cd.CommandText = "CPC_NroDocumento_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = Viewstate("TipoDocumento")
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("fchemision")))
                lblReferencia.Text = dr.GetValue(dr.GetOrdinal("Referencia"))
                lblTotal.Text = String.Format("{0:###,###,###,###.00}", dr.GetValue(dr.GetOrdinal("total")))
                If dr.GetValue(dr.GetOrdinal("CodMoneda")) = "D" Then
                    lblTotal.Text = "US $ " & lblTotal.Text
                Else
                    lblTotal.Text = "S/. " & lblTotal.Text
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaTipoDocumento()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumento_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = "DC"
        da.Fill(ds, "TTipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TTipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_RegistraDC_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ddlTipoDocumento.SelectedItem.Value
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = Viewstate("NroDocumento")
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = txtFchEmision.Text.Substring(6, 4) + txtFchEmision.Text.Substring(3, 2) + txtFchEmision.Text.Substring(0, 2)
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
            Response.Redirect("cpcDocumento.aspx" & _
                            "?CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub


End Class
