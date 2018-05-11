Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpNegocio
Imports cmpTabla

Partial Class VtaPlantillaNueva
    Inherits System.Web.UI.Page

    Dim objPlantilla As New clsPlantilla
    Dim objZonaVta As New clsZonaVta
    Dim objTablaElemento As New clsTablaElemento
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            If Viewstate("NroPlantilla") = 0 Then
                lbltitulo.Text = "Nueva Plantilla"
                CargaZonaVta("")
                CargaTipoPlantilla(0)
                CargaCateTour(0)
            Else
                lbltitulo.Text = "Modificar Plantilla Nro. " & Viewstate("NroPlantilla")
                EditaPlantilla()
            End If
        End If
    End Sub

    Private Sub EditaPlantilla()
        lblMsg.Text = objPlantilla.Editar(Viewstate("NroPlantilla"))
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            txtTitulo.Text = objPlantilla.DesPlantilla
            CargaZonaVta(objPlantilla.CodZonaVta)
            CargaTipoPlantilla(objPlantilla.CodTipoPlantilla)
            CargaCateTour(objPlantilla.CodCateTour)
            If RTrim(objPlantilla.StsPlantilla) = "A" Then
                rbtActivo.Checked = True
                rbtInactivo.Checked = False
            Else
                rbtActivo.Checked = False
                rbtInactivo.Checked = True
            End If

            If objPlantilla.FlagUsoAge = "S" Then
                CheckBoxFlagUsoAge.Checked = True
            End If
        End If
    End Sub

    Private Sub CargaZonaVta(ByVal pCodZonaVta As String)
        ddlZonaVta.DataSource = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataBind()
        Try
            ddlZonaVta.Items.FindByValue(pCodZonaVta).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaTipoPlantilla(ByVal pCodTipoPlantilla As Integer)
        ddlTipoPlantilla.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(7, "E")
        ddlTipoPlantilla.DataBind()
        Try
            ddlTipoPlantilla.Items.FindByValue(pCodTipoPlantilla).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaCateTour(ByVal pCodCateTour As Integer)
        ddlCateTour.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(8, "E")
        ddlCateTour.DataBind()
        Try
            ddlCateTour.Items.FindByValue(pCodCateTour).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If txtTitulo.Text.Trim.Length = 0 Then
            lblMsg.Text = "Titulo es dato obligatorio"
            Return
        End If
        Dim sStsPlantilla As String
        If rbtActivo.Checked Then
            sStsPlantilla = "A"
        Else
            sStsPlantilla = "I"
        End If
        Dim sFlagUsoAge As String = ""
        If CheckBoxFlagUsoAge.Checked Then
            sFlagUsoAge = "S"
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Plantilla_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPlantillaOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = Viewstate("NroPlantilla")
        cd.Parameters.Add("@DesPlantilla", SqlDbType.VarChar, 80).Value = txtTitulo.Text
        cd.Parameters.Add("@StsPlantilla", SqlDbType.Char, 1).Value = sStsPlantilla
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta.SelectedValue
        cd.Parameters.Add("@CodTipoPlantilla", SqlDbType.Int).Value = ddlTipoPlantilla.SelectedValue
        cd.Parameters.Add("@Codcatetour", SqlDbType.Int).Value = ddlCateTour.SelectedValue
        cd.Parameters.Add("@FlagUsoAge", SqlDbType.Char, 1).Value = sFlagUsoAge
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
            Response.Redirect("VtaPlantillaFicha.aspx" & _
                        "?NroPlantilla=" & cd.Parameters("@NroPlantillaOut").Value)
        End If
    End Sub

    Private Sub rbtActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtActivo.CheckedChanged
        rbtActivo.Checked = True
        rbtInactivo.Checked = False
    End Sub

    Private Sub rbtInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtInactivo.CheckedChanged
        rbtActivo.Checked = False
        rbtInactivo.Checked = True
    End Sub

End Class
