Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Partial Class VtaPlantillaLink
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            Viewstate("DesPlantilla") = Request.Params("DesPlantilla")
            lblTitulo.Text = "Plantilla Nro. " & Viewstate("NroPlantilla") & " - " & Viewstate("DesPlantilla")

            CargaPlantillaLink()
            CargaTipoLink()
            CargaCiudad()
            CargaLink()
        End If
    End Sub

    Private Sub CargaPlantillaLink()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PlantillaLink_S"
        da.SelectCommand.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = Viewstate("NroPlantilla")

        Dim nReg As Integer = da.Fill(ds, "DPLANTILLALINK")
        dgLink.DataKeyField = "CodLink"
        dgLink.DataSource = ds.Tables("DPLANTILLALINK")
        dgLink.DataBind()

        lblMsg.Text = CStr(nReg) + " Link(s) encontrado(s)"
    End Sub

    Private Sub CargaTipoLink()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_TipoLinkActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Tipolink")
        ddlTipoLink.DataSource = ds.Tables("TipoLink")
        ddlTipoLink.DataBind()
    End Sub

    Private Sub CargaCiudad()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_CiudadxTipoLink_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@CodTipoLink", System.Data.SqlDbType.SmallInt)
        pa.Direction = System.Data.ParameterDirection.Input
        If ddlTipoLink.Items.Count() > 0 Then
            pa.Value = ddlTipoLink.SelectedItem.Value
        Else
            pa.Value = 0
        End If
        da.SelectCommand.Parameters.Add(pa)

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()
    End Sub

    Private Sub CargaLink()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_MlinkxCiudad_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@CodTipoLink", System.Data.SqlDbType.SmallInt)
        pa.Direction = System.Data.ParameterDirection.Input
        If ddlTipoLink.Items.Count() > 0 Then
            pa.Value = ddlTipoLink.SelectedItem.Value
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
        da.Fill(ds, "Mlink")
        ddlLink.DataSource = ds.Tables("Mlink")
        ddlLink.DataBind()
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If ddlLink.Items.Count = 0 Then
            lblMsg.Text = "Error: Link es obligatorio"
            Return
        End If

        Dim wEstado As String
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = CInt(Viewstate("NroPlantilla"))
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = CInt(ddlLink.SelectedItem.Value)
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        lblMsg.Text = ""
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

        If lblMsg.Text.Trim = "OK" Then
            CargaPlantillaLink()
        End If
    End Sub

    Private Sub ddlTipoLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoLink.SelectedIndexChanged
        CargaCiudad()
        CargaLink()
    End Sub
    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaLink()
    End Sub

    Private Sub dgLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLink.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaLink_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = Viewstate("NroPlantilla")
        cd.Parameters.Add("@CodLink", SqlDbType.Int).Value = dgLink.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = ""
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
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaPlantillaLink()
        End If
    End Sub

    Private Sub dgLink_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLink.ItemDataBound
        If Trim(e.Item.Cells(6).Text) = "Inactivo" Then
            e.Item.ForeColor = Color.Red
        End If
    End Sub

End Class
