Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpSeguridad

Partial Class VtaServicioLink
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT030505") <> "OK" Then
                cmbGrabar.Visible = False
                dgLink.Columns(4).Visible = False
            End If

            Viewstate("NroServicio") = Request.Params("NroServicio")
            LeeServicio("")

            CargaData()
            CargaLinkxTipoLink()
        End If
    End Sub

    Private Sub LeeServicio(ByVal pEstado As String)
        lblCodCiudad.Text = ""
        txtCiudad.Text = ""

        pEstado = "N"

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioNroServicio_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = CInt(ViewState("NroServicio"))
        cd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = pEstado

        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblCodCiudad.Text = dr.GetValue(dr.GetOrdinal("CodCiudad"))
                txtCiudad.Text = dr.GetValue(dr.GetOrdinal("NomCiudad"))
                lblTitulo.Text = Request.Params("NroServicio") & " " & dr.GetValue(dr.GetOrdinal("DesProveedor"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CargaData()
        '   Cargamos los Links
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_TipoLinkCodCiudad_S"
        da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = lblCodCiudad.Text
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "TipoLink")
        ddlTLink.DataSource = ds.Tables("TipoLink")
        ddlTLink.DataBind()


        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_ServicioLinkNroServicio_S"
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = CInt(Viewstate("NroServicio"))

        Dim nReg As Integer = da.Fill(ds, "DSERVICIOLINK")
        dgLink.DataKeyField = "CodLink"
        dgLink.DataSource = ds.Tables("DSERVICIOLINK")
        dgLink.DataBind()

        lblMsg.Text = CStr(nReg) + " Servicios (s) encontrada(s)"


    End Sub

    Private Sub CargaLinkxTipoLink()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_LinkCodTipoLink_S"
        If ddlTLink.Items.Count = 0 Then
            da.SelectCommand.Parameters.Add("@CodTipoLink", SqlDbType.SmallInt).Value = 0
        Else
            da.SelectCommand.Parameters.Add("@CodTipoLink", SqlDbType.SmallInt).Value = ddlTLink.SelectedItem.Value
        End If
        da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = lblCodCiudad.Text

        Dim ds As New DataSet
        da.Fill(ds, "Mlink")
        ddlLink.DataSource = ds.Tables("Mlink")
        ddlLink.DataBind()
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblMsg.Text = ""
        If ddlTLink.Items.Count = 0 Then
            lblMsg.Text = "Error: Tipo Link es dato obligatorio"
            Return
        End If
        If ddlLink.Items.Count = 0 Then
            lblMsg.Text = "Error: Link es dato obligatorio"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = CInt(Viewstate("NroServicio"))
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = ddlLink.SelectedItem.Value
        cd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
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

    Private Sub dgLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLink.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioLink_D"
        cd.CommandType = CommandType.StoredProcedure
        lblMsg.Text = ""
        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = CInt(Viewstate("NroServicio"))
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
            CargaData()
        End If
    End Sub

    Private Sub ddlTLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTLink.SelectedIndexChanged
        CargaLinkxTipoLink()
    End Sub

End Class
