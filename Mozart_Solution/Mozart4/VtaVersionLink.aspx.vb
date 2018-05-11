Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionLink
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
            lblTitulo.Text = "Adicionar / Eliminar Link - Versión Nro. " & Viewstate("NroVersion")

            CargaVersionLink()
            CargaCiudad()
            CargaServicio()
            CargaLink()
        End If
    End Sub

    Private Sub CargaVersionLink()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionLink_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "DVERSIONLINK")
        dgLink.DataKeyField = "CodLink"
        dgLink.DataSource = ds.Tables("DVERSIONLINK")
        dgLink.DataBind()

        lblMsg.Text = CStr(nReg) & " links"
    End Sub

    Private Sub CargaCiudad()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_CiudadxNroVersion_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()
    End Sub

    Private Sub CargaServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_ServicioxNroVersion_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        If ddlCiudad.Items.Count() = 0 Then
            da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = ""
        Else
            da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = ddlCiudad.SelectedItem.Value
        End If

        Dim ds As New DataSet
        da.Fill(ds, "Servicio")
        ddlServicio.DataSource = ds.Tables("Servicio")
        ddlServicio.DataBind()
    End Sub


    Private Sub CargaLink()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_LinkxNroServicio_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ddlServicio.Items.Count() = 0 Then
            da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = 0
        Else
            da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
        End If

        Dim ds As New DataSet
        da.Fill(ds, "Mlink")
        ddlLink.DataSource = ds.Tables("Mlink")
        ddlLink.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlLink.Items.Count = 0 Then
            lblMsg.Text = "Link es obligatorio"
            Return
        End If
        If ddlServicio.Items.Count = 0 Then
            lblMsg.Text = "Servicio es obligatorio"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = ddlLink.SelectedItem.Value
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
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
            CargaVersionLink()
        End If
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaServicio()
        CargaLink()
    End Sub


    Private Sub dgLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLink.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionLink_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@CodLink", SqlDbType.Int).Value = dgLink.DataKeys(e.Item.ItemIndex)
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
            Me.CargaVersionLink()
        End If
    End Sub

    Private Sub lbtFichaVersion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion1.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaLink()
    End Sub

End Class
