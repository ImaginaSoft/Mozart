Imports System
Imports System.Data
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Data.SqlClient

Partial Class VtaPropuestaResumen
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Resumen Propuesta N° " & Request.Params("NroPropuesta")
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("StsPropuesta") = Request.Params("StsPropuesta")
            ViewState("FlagPublica") = Request.Params("FlagPublica")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            Try
                Dim da As New SqlDataAdapter
                da.SelectCommand = New SqlCommand
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "VTA_PropuestaResumen_S"
                da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
                da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
                dsEdit.Clear()
                da.Fill(dsEdit, "tblRTB")
                FreeTextBox1.DataBind()

            Catch eLoad As System.Exception
                lblmsg.Text = eLoad.Message()
            End Try

            If ViewState("FlagEdita") = "N" Then
                btnSave.Visible = False
                lblmsg.Text = "La Propuesta es modelo antiguo, no se puede modificar precios"
                Return
            End If
            If ViewState("StsPropuesta") = "V" Then
                btnSave.Visible = False
                lblmsg.Text = "La Propuesta ya tiene versión, no se puede modificar precios"
                Return
            End If

            If ViewState("FlagPublica") = "S" Then
                btnSave.Visible = False
                lblmsg.Text = "La Propuesta está publicada, no se puede modificar los precios"
                Return
            End If


        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaResumen_U"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@Resumen", SqlDbType.Text).Value = FreeTextBox1.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Text, 15).Value = Session("CodUsuario")
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
            Response.Redirect("VtaPropuestaFicha.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta"))
        End If
    End Sub
End Class
