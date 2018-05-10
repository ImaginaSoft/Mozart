Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionDias
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("DesVersion") = Request.Params("DesVersion")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("StsVersion") = Request.Params("StsVersion")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Modificar dias Versión N° " & Viewstate("NroVersion")

            CargaData()

            If Viewstate("FlagEdita") = "N" Or Viewstate("FlagEdita") = "E" Then
                cmdInserta.Visible = False
                cmdElimina.Visible = False
                If Viewstate("FlagEdita") = "N" Then
                    lblMsg.Text = "La versión es modelo antiguo, no se puede modificar"
                Else
                    lblMsg.Text = "La versión es de otra empresa, no se puede modificar"
                End If
                lblMsg.CssClass = "Msg"
                Return
            End If

            If Viewstate("StsVersion") = "V" Then
                cmdInserta.Visible = False
                cmdElimina.Visible = False
                lblMsg.Text = "La versión ya está vendido, no se puede modificar"
                lblMsg.CssClass = "Msg"
                Return
            End If
            If Viewstate("StsVersion") = "F" Then
                cmdInserta.Visible = False
                cmdElimina.Visible = False
                lblMsg.Text = "La versión ya está facturado, no se puede modificar"
                lblMsg.CssClass = "Msg"
                Return
            End If

            If Viewstate("FlagPublica") = "S" Then
                cmdInserta.Visible = False
                cmdElimina.Visible = False
                lblMsg.Text = "La Versión está publicada, no se puede modificar"
                lblMsg.CssClass = "msg"
            End If

        End If
    End Sub

    Private Sub LeeNroVersion()
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_VersionNroVersion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ViewState("DesVersion") = dr.GetValue(dr.GetOrdinal("DesVersion"))


            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionServicio_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()
    End Sub


    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionDias_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@DiaIni", SqlDbType.Int).Value = txtDiaIni.Text
        cd.Parameters.Add("@DiaFin", SqlDbType.Int).Value = txtDiaFin.Text
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
            Me.CargaData()
        End If
    End Sub

    Private Sub cmdInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInserta.Click
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionDias_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@DiaInicio", SqlDbType.Int).Value = txtDiaInicio.Text
        cd.Parameters.Add("@CantDias", SqlDbType.Int).Value = txtCantDias.Text
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
            Me.CargaData()
        End If
    End Sub

End Class
