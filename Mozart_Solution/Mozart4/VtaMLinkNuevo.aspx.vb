Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaMLinkNuevo
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            If Viewstate("Opcion") = "Modificar" Then
                Titulo.Text = "Modificar Link"
                ViewState("CodLink") = Request.Params("CodLink")
                ViewState("CodCiudad") = ""
                ViewState("CodTipoLink") = 0

                'Viewstate("NomPagina") = Request.Params("NomPagina")
                'Viewstate("TiTulo") = Request.Params("TiTulo")
                'Viewstate("Estado") = Request.Params("Estado")
                'Viewstate("Telefono1") = Request.Params("Telefono1")

                EditaLink()
            Else
                Titulo.Text = "Nuevo Link"
                CargaCiudadS("", False)
                CargaLinkS("", False)
            End If
        End If

    End Sub

    Private Sub EditaLink()
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_MLink_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = ViewState("CodLink")
        Try
            lblcodigo.Text = ViewState("CodLink")

            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()

                txtNombre.Text = dr.GetValue(dr.GetOrdinal("NomPagina"))
                txtTitulo.Text = dr.GetValue(dr.GetOrdinal("Titulo"))
                txtTelefono1.Text = dr.GetValue(dr.GetOrdinal("Telefono1"))

                ViewState("CodCiudad") = dr.GetValue(dr.GetOrdinal("CodCiudad"))
                ViewState("CodTipoLink") = dr.GetValue(dr.GetOrdinal("CodTipoLink"))
                If dr.GetValue(dr.GetOrdinal("StsLink")) = "A" Then
                    rbActivo.Checked = True
                    rbInactivo.Checked = False
                Else
                    rbActivo.Checked = False
                    rbInactivo.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaCiudadS(ViewState("CodCiudad"), True)
        CargaLinkS(ViewState("CodTipoLink"), True)


    End Sub


    Private Sub CargaCiudadS(ByVal pCodCiudad As String, ByVal pFind As Boolean)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_CiudadActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()
        If pFind Then
            Try
                ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub CargaLinkS(ByVal pCodLink As String, ByVal pFind As Boolean)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_LinkActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet
        da.Fill(ds, "Links")
        ddlTipoLink.DataSource = ds.Tables("Links")
        ddlTipoLink.DataBind()
        If pFind Then
            Try
                ddlTipoLink.Items.FindByValue(pCodLink).Selected = True
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wciudad, wEstado As String
        Dim wlink As Double

        If ddlCiudad.Items.Count = 0 Then
            wciudad = 0
        Else
            wciudad = ddlCiudad.SelectedItem.Value
        End If
        If ddlTipoLink.Items.Count = 0 Then
            wlink = 0
        Else
            wlink = ddlTipoLink.SelectedItem.Value
        End If
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_MLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = lblcodigo.Text
        cd.Parameters.Add("@NomPagina", SqlDbType.VarChar, 150).Value = txtNombre.Text
        cd.Parameters.Add("@CodTipoLink", SqlDbType.SmallInt).Value = wlink
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = wciudad
        cd.Parameters.Add("@Titulo", SqlDbType.VarChar, 100).Value = txtTitulo.Text
        cd.Parameters.Add("@StsLinK", SqlDbType.Char, 1).Value = wEstado
        cd.Parameters.Add("@Telefono1", SqlDbType.VarChar, 25).Value = txtTelefono1.Text
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
            Response.Redirect("VtaMLink.aspx")
        End If
    End Sub
End Class
