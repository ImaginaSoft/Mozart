Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaServicioPlantilla
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        '        Dim ds As New DataSet
        '       Dim da As New SqlDataAdapter
        '      Dim pCodProveedor, pCodTServicio As Integer
        '     Dim pCodCiudad As String

        If Not Page.IsPostBack Then
            CargaProveedor()
            CargaCiudad()
            CargaTipoServicio()
        End If
    End Sub

    Private Sub CargaProveedor()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn

        da.SelectCommand.CommandText = "VTA_ProveedorServicio_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Proveedor")
        ddlProveedor.DataSource = ds.Tables("Proveedor")
        ddlProveedor.DataBind()
    End Sub

    Private Sub CargaCiudad()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_CiudadxProveedor_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@CodProveedor", System.Data.SqlDbType.Int)
        pa.Direction = System.Data.ParameterDirection.Input
        If ddlProveedor.Items.Count > 0 Then
            pa.Value = ddlProveedor.SelectedItem.Value
        Else
            pa.Value = 0
        End If
        da.SelectCommand.Parameters.Add(pa)

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()

    End Sub

    Private Sub CargaTipoServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_TipoServicioxCiudad_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@CodProveedor", System.Data.SqlDbType.Int)
        pa.Direction = System.Data.ParameterDirection.Input
        If ddlProveedor.Items.Count > 0 Then
            pa.Value = ddlProveedor.SelectedItem.Value
        Else
            pa.Value = 0
        End If
        da.SelectCommand.Parameters.Add(pa)
        pa = New SqlParameter("@CodCiudad", System.Data.SqlDbType.Char, 10)
        pa.Direction = System.Data.ParameterDirection.Input
        If ddlCiudad.Items.Count() > 0 Then
            pa.Value = ddlCiudad.SelectedItem.Value
        Else
            pa.Value = " "
        End If
        da.SelectCommand.Parameters.Add(pa)

        Dim ds As New DataSet
        da.Fill(ds, "TipoServicio")
        ddltiposervicio.DataSource = ds.Tables("TipoServicio")
        ddltiposervicio.DataBind()
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblMsg.Text = ""
        CargaServicio()
    End Sub

    Private Sub CargaServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_ServicioxCodTipoServicioPla_S"
        If ddlProveedor.Items.Count > 0 Then
            da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ddlProveedor.SelectedItem.Value
        Else
            da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = 0
        End If
        If ddlCiudad.Items.Count() > 0 Then
            da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.VarChar).Value = ddlCiudad.SelectedItem.Value
        Else
            da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.VarChar).Value = ""
        End If
        If ddltiposervicio.Items.Count() > 0 Then
            da.SelectCommand.Parameters.Add("@CodTipoServicio", SqlDbType.Int).Value = ddltiposervicio.SelectedItem.Value
        Else
            da.SelectCommand.Parameters.Add("@CodTipoServicio", SqlDbType.Int).Value = 0
        End If

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataKeyField = "NroServicio"
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()

        lblMsg.Text = CStr(nReg) + " Servicio(s) encontrado(s)"

    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        Response.Redirect("VtaServicioPlantillaLista.aspx" & _
                    "?NroServicio=" & dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text & _
                    "&Titulo=" & dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text)
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
              e.Item.ItemType = ListItemType.AlternatingItem Then
            If Trim(e.Item.Cells(5).Text) = "Inactivo" Then
                e.Item.ForeColor = Color.Red
            End If
            If e.Item.Cells(6).Text.Trim = "0" Then
                e.Item.Cells(0).Text = ""
            End If
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaCiudad()
        CargaTipoServicio()
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio()
    End Sub

    Private Sub lbtPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPlantilla.Click
        Response.Redirect("VtaServicioPlantillaReemplaza.aspx")
    End Sub

End Class
