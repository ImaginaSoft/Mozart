Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaPropuestaDias
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("DesPropuesta") = Request.Params("DesPropuesta")
            Viewstate("StsPropuesta") = Request.Params("StsPropuesta")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            lbltitulo.Text = "Modificar dias Propuesta N° " & Viewstate("NroPropuesta")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PropuestaServicio_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")

        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()

        If Viewstate("FlagEdita") = "N" Then
            cmdInserta.Visible = False
            cmdElimina.Visible = False
            lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
            Return
        End If

        If Viewstate("StsPropuesta") = "V" Then
            cmdInserta.Visible = False
            cmdElimina.Visible = False
            lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
            Return
        End If

        If Viewstate("FlagPublica") = "S" Then
            cmdInserta.Visible = False
            cmdElimina.Visible = False
            lblMsg.Text = "La Propuesta está publicada, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
        End If
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
        Dim cd As New SqlCommand
        Dim servicio, dia, orden As String

        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaDias_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
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
            CargaData()
        End If
    End Sub

    Private Sub cmdInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInserta.Click
        Dim cd As New SqlCommand
        Dim servicio, dia, orden As String

        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaDias_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
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
            CargaData()
        End If
    End Sub

End Class
