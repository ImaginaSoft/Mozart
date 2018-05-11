Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaPropuestaLink
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
            lblTitulo.Text = "Link Propuesta Nro. " & Viewstate("NroPropuesta")

            CargaPropuestaLink()
            CargaCiudad()
            CargaServicio()
            CargaLink()
        End If
    End Sub

    Private Sub CargaPropuestaLink()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PropuestaLink_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")

        Dim nReg As Integer = da.Fill(ds, "DPROPUESTALINK")
        dgLink.DataKeyField = "CodLink"
        dgLink.DataSource = ds.Tables("DPROPUESTALINK")
        dgLink.DataBind()

        lblMsg.Text = CStr(nReg) & " links"
    End Sub

    Private Sub CargaCiudad()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_CiudadxNroPropuesta_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()
    End Sub

    Private Sub CargaServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_ServicioxNroPropuesta_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
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
        cd.CommandText = "VTA_PropuestaLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
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
            CargaPropuestaLink()
        End If
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaServicio()
        CargaLink()
    End Sub

    Private Sub dgLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLink.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaLink_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
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
            Me.CargaPropuestaLink()
        End If
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaLink()
    End Sub


End Class
