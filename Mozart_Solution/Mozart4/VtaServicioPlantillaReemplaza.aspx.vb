Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaServicioPlantillaReemplaza
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaProveedor("O")
            CargaCiudad("O", ddlProveedor.SelectedItem.Value)
            CargaTipoServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value)
            CargaServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value, ddltiposervicio.SelectedItem.Value)

            CargaProveedor("D")
            CargaCiudad("D", ddlProveedor2.SelectedItem.Value)
            CargaTipoServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value)
            CargaServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value, ddlTipoServicio2.SelectedItem.Value)

            lblNroServicioActual.Text = ddlServicio.SelectedItem.Value
            Try
                lblNroServicioNuevo.Text = ddlServicio2.SelectedItem.Value
            Catch ex As Exception
                'error
            End Try
        End If
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        If ddlServicio.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione servicio actual"
            Return
        End If

        If ddlServicio2.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione nuevo servicio"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioPlantilla_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicioActual", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
        cd.Parameters.Add("@NroServicioNuevo", SqlDbType.Int).Value = ddlServicio2.SelectedItem.Value
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaServicioPlantilla.aspx")
        End If
    End Sub


    Private Sub CargaProveedor(ByVal pTipo As String)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If pTipo = "O" Then
            da.SelectCommand.CommandText = "VTA_ProveedorServicioDPla_S"
            da.Fill(ds, "Proveedor")
            ddlProveedor.DataSource = ds.Tables("Proveedor")
            ddlProveedor.DataBind()
        Else
            da.SelectCommand.CommandText = "VTA_ProveedorServicio_S"
            da.Fill(ds, "Proveedor2")
            ddlProveedor2.DataSource = ds.Tables("Proveedor2")
            ddlProveedor2.DataBind()
        End If
    End Sub

    Private Sub CargaCiudad(ByVal pTipo As String, ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pCodProveedor
        If pTipo = "O" Then
            da.SelectCommand.CommandText = "VTA_CiudadxProveedorDPla_S"
            da.Fill(ds, "Ciudad")
            ddlCiudad.DataSource = ds.Tables("Ciudad")
            ddlCiudad.DataBind()
        Else
            da.SelectCommand.CommandText = "VTA_CiudadxProveedor_S"
            da.Fill(ds, "Ciudad2")
            ddlCiudad2.DataSource = ds.Tables("Ciudad2")
            ddlCiudad2.DataBind()
        End If
    End Sub

    Private Sub CargaTipoServicio(ByVal pTipo As String, ByVal pCodProveedor As Integer, ByVal pCodCiudad As String)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pCodProveedor
        da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = pCodCiudad
        If pTipo = "O" Then
            da.SelectCommand.CommandText = "VTA_TipoServicioxCiudadDPla_S"
            da.Fill(ds, "TipoServicio")
            ddltiposervicio.DataSource = ds.Tables("TipoServicio")
            ddltiposervicio.DataBind()
        Else
            da.SelectCommand.CommandText = "VTA_TipoServicioxCiudad_S"
            da.Fill(ds, "TipoServicio2")
            ddlTipoServicio2.DataSource = ds.Tables("TipoServicio2")
            ddlTipoServicio2.DataBind()
        End If
    End Sub

    Private Sub CargaServicio(ByVal pTipo As String, ByVal pCodProveedor As Integer, ByVal pCodCiudad As String, ByVal pCodTipoServicio As Integer)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pCodProveedor
        da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = pCodCiudad
        da.SelectCommand.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = pCodTipoServicio
        If pTipo = "O" Then
            da.SelectCommand.CommandText = "VTA_ServicioxCodTipoServicioDPla_S"
            da.Fill(ds, "MSERVICIO")
            ddlServicio.DataSource = ds.Tables("MSERVICIO")
            ddlServicio.DataBind()
        Else
            da.SelectCommand.CommandText = "VTA_ServicioActivoxCodTipoServicio_S"
            da.Fill(ds, "MSERVICIO2")
            ddlServicio2.DataSource = ds.Tables("MSERVICIO2")
            ddlServicio2.DataBind()
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaCiudad("O", ddlProveedor.SelectedItem.Value)
        CargaTipoServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value)
        CargaServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value, ddltiposervicio.SelectedItem.Value)
        lblNroServicioActual.Text = ddlServicio.SelectedItem.Value
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value)
        CargaServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value, ddltiposervicio.SelectedItem.Value)
        lblNroServicioActual.Text = ddlServicio.SelectedItem.Value
    End Sub

    Private Sub ddltiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltiposervicio.SelectedIndexChanged
        CargaServicio("O", ddlProveedor.SelectedItem.Value, ddlCiudad.SelectedItem.Value, ddltiposervicio.SelectedItem.Value)
        lblNroServicioActual.Text = ddlServicio.SelectedItem.Value
    End Sub

    Private Sub ddlProveedor2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor2.SelectedIndexChanged
        CargaCiudad("D", ddlProveedor2.SelectedItem.Value)
        CargaTipoServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value)
        CargaServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value, ddlTipoServicio2.SelectedItem.Value)
        Try
            lblNroServicioNuevo.Text = ddlServicio2.SelectedItem.Value
        Catch ex As Exception
            'Error
        End Try
    End Sub

    Private Sub ddlCiudad2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad2.SelectedIndexChanged
        CargaTipoServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value)
        CargaServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value, ddlTipoServicio2.SelectedItem.Value)
        Try
            lblNroServicioNuevo.Text = ddlServicio2.SelectedItem.Value
        Catch ex As Exception
            'Error
        End Try
    End Sub

    Private Sub ddlTipoServicio2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoServicio2.SelectedIndexChanged
        CargaServicio("D", ddlProveedor2.SelectedItem.Value, ddlCiudad2.SelectedItem.Value, ddlTipoServicio2.SelectedItem.Value)
        Try
            lblNroServicioNuevo.Text = ddlServicio2.SelectedItem.Value
        Catch ex As Exception
            'error
        End Try
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        lblNroServicioActual.Text = ddlServicio.SelectedItem.Value
    End Sub

    Private Sub ddlServicio2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio2.SelectedIndexChanged
        Try
            lblNroServicioNuevo.Text = ddlServicio2.SelectedItem.Value
        Catch ex As Exception
            'error
        End Try
    End Sub


End Class
