Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionTrasladoBoleto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            lblTitulo.Text = "Traslado de Boletos Aereos - Versión Nro. " & ViewState("NroVersion")

            CargaVersion()
            CargaBoletos()
        End If
    End Sub



    Private Sub CargaVersion()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_Version_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@NroPedido", System.Data.SqlDbType.Int)
        pa.Value = ViewState("NroPedido")
        da.SelectCommand.Parameters.Add(pa)
        da.Fill(ds, "VERSION")
        ddlVersion.DataSource = ds.Tables("VERSION")
        ddlVersion.DataBind()

        If ddlVersion.Items.Count = 0 Then
            cmdGrabar.Visible = False
        Else
            cmdGrabar.Visible = True
        End If

    End Sub

    Private Sub CargaBoletos()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionTrasladoBoleto_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Campo")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlVersion.Items.Count = 0 Then
            lblMsg.Text = "Versión es obligatorio"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionTrasladoBoleto_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = ViewState("NroVersion")
        cd.Parameters.Add("@NroVersionNew", SqlDbType.Int).Value = ddlVersion.SelectedItem.Value
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblMsg.Text) = "OK" Then
            CargaBoletos()
        End If
    End Sub

 


    Private Sub lbtFichaVersion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion1.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & ViewState("NroPedido") & _
            "&NroPropuesta=" & ViewState("NroPropuesta") & _
            "&NroVersion=" & ViewState("NroVersion"))
    End Sub


End Class
