Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpNegocio
Imports cmpTabla
Imports System.Drawing

Partial Class VtaPlantillaServicio
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objServicio As New clsServicio
    Dim objPlantilla As New clsPlantilla
    Dim objProveedor As New clsProveedor

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            Viewstate("DesPlantilla") = Request.Params("DesPlantilla")
            lblTitulo.Text = "Plantilla Nro. " & Viewstate("NroPlantilla") & " - " & Viewstate("DesPlantilla")

            CargaProveedorS(0)
            CargaCiudad("")
            CargaTipoServicio(0)
            CargaServicio(0)
            CargaTipoAcomodacion(0)
            CargaData()

        End If
    End Sub

    Private Sub CargaData()
        dgPlanilla.DataKeyField = "KeyReg"
        dgPlanilla.DataSource = objPlantilla.CargaServicios(Request.Params("NroPlantilla"))
        dgPlanilla.DataBind()
        lblMsg.Text = CStr(dgPlanilla.Items.Count) + " Servicio(s)"
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblMsg.Text = ""

        If ddlProveedor.Items.Count() = 0 Then
            lblMsg.Text = "Error: Seleccione Proveedor"
            Return
        End If
        If ddlCiudad.Items.Count() = 0 Then
            lblMsg.Text = "Error: Seleccione Ciudad"
            Return
        End If
        If ddltiposervicio.Items.Count() = 0 Then
            lblMsg.Text = "Error: Seleccione Tipo de Servicio"
            Return
        End If
        If ddlServicio.Items.Count() = 0 Then
            lblMsg.Text = "Error: Seleccione Servicio"
            Return
        End If
        If Len(Trim(Textdia.Text)) = 0 Then
            lblMsg.Text = "Error: Nro día es obligatorio"
            Return
        End If
        If Len(Trim(Textorden.Text)) = 0 Then
            lblMsg.Text = "Error: Nro orden es obligatorio"
            Return
        End If
        GrabaDatos()
    End Sub

    Private Sub GrabaDatos()
        Dim CodLink As Integer

        Dim wCodTipoAcomodacion As Integer
        If ddlTipoAcomodacion.Items.Count() = 0 Then
            wCodTipoAcomodacion = 0
        Else
            wCodTipoAcomodacion = ddlTipoAcomodacion.SelectedItem.Value
        End If

        Dim wDiaAnt, wOrdAnt, wServicioAnt, wCodTipoAcomodacionAnt As Integer
        If Len(Trim(txtDiaAnt.Text)) = 0 Then
            wDiaAnt = 0
        Else
            wDiaAnt = txtDiaAnt.Text
        End If
        If Len(Trim(txtOrdenAnt.Text)) = 0 Then
            wOrdAnt = 0
        Else
            wOrdAnt = txtOrdenAnt.Text
        End If
        If Len(Trim(txtNroServicioAnt.Text)) = 0 Then
            wServicioAnt = 0
        Else
            wServicioAnt = txtNroServicioAnt.Text
        End If
        If Len(Trim(txtCodTipoAcomodacionAnt.Text)) = 0 Then
            wCodTipoAcomodacionAnt = 0
        Else
            wCodTipoAcomodacionAnt = txtCodTipoAcomodacionAnt.Text
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaServicio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = Viewstate("NroPlantilla")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Textdia.Text
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Textorden.Text
        cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = txtHoraServicio.Text
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
        cd.Parameters.Add("@CodTiposervicio", SqlDbType.TinyInt).Value = ddltiposervicio.SelectedItem.Value
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = wCodTipoAcomodacion
        cd.Parameters.Add("@NroDiaAnt", SqlDbType.SmallInt).Value = wDiaAnt
        cd.Parameters.Add("@NroOrdenAnt", SqlDbType.SmallInt).Value = wOrdAnt
        cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = wServicioAnt
        cd.Parameters.Add("@CodTipoAcomodacionAnt", SqlDbType.SmallInt).Value = wCodTipoAcomodacionAnt
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
            txtDiaAnt.Text = ""
            txtOrdenAnt.Text = ""
            txtNroServicioAnt.Text = ""
            Me.CargaData()
        End If
    End Sub

    Private Sub dgPlanilla_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPlanilla.DeleteCommand
        Dim cd As New SqlCommand

        Dim wDia, wOrden, wNroServicio, wCodTipoAcomodacion As Integer

        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaServicio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        wNroServicio = Mid(dgPlanilla.DataKeys(e.Item.ItemIndex), 1, 6)
        wCodTipoAcomodacion = Mid(dgPlanilla.DataKeys(e.Item.ItemIndex), 7, 5)
        wDia = Mid(dgPlanilla.DataKeys(e.Item.ItemIndex), 12, 2)
        wOrden = Mid(dgPlanilla.DataKeys(e.Item.ItemIndex), 14, 2)

        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = Viewstate("NroPlantilla")
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = wNroServicio
        cd.Parameters.Add("@NroDia", SqlDbType.Int).Value = wDia
        cd.Parameters.Add("@NroOrdenServicio", SqlDbType.SmallInt).Value = wOrden
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

        If Trim(lblMsg.Text) = "OK" Then
            Me.CargaData()
        End If

    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaCiudad("")
        CargaTipoServicio(0)
        CargaServicio(0)
        CargaTipoAcomodacion(0)
    End Sub

    Private Sub dgPlanilla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPlanilla.SelectedIndexChanged
        If dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(10).Text = "Inactivo" Then
            lblMsg.Text = "Servico esta inactivo, solo puede eliminar"
            Return
        End If
        Dim wDia, wOrden, wNroServicio, wCodTipoAcomodacion As Integer
        Dim wCodProveedor, wCodTipoServicio As Integer
        Dim wCodCiudad As String

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        wDia = dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(2).Text
        wOrden = dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(3).Text
        txtHoraServicio.Text = dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(6).Text.Trim
        wNroServicio = dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(4).Text
        wCodTipoAcomodacion = dgPlanilla.Items(dgPlanilla.SelectedIndex).Cells(13).Text

        ObjServicio.Editar(wNroServicio)
        wCodCiudad = ObjServicio.CodCiudad
        wCodProveedor = ObjServicio.CodProveedor
        wCodTipoServicio = ObjServicio.CodTipoServicio

        CargaProveedorS(wCodProveedor)
        CargaCiudad(wCodCiudad)
        CargaTipoServicio(wCodTipoServicio)
        CargaServicio(wNroServicio)
        CargaTipoAcomodacion(wCodTipoAcomodacion)

        Textdia.Text = wDia
        Textorden.Text = wOrden

        txtDiaAnt.Text = wDia
        txtOrdenAnt.Text = wOrden
        txtNroServicioAnt.Text = wNroServicio
        txtCodTipoAcomodacionAnt.Text = wCodTipoAcomodacion
    End Sub

    Private Sub CargaProveedorS(ByVal pCodProveedor As Integer)
        ddlProveedor.DataSource = objProveedor.CargaProveedores()
        ddlProveedor.DataBind()
        If pCodProveedor > 0 Then
            Try
                ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
            Catch ex As Exception
                lblMsg.Text = "No se puede editar servicio porque el Proveedor tiene estado inactivo"
            End Try
        End If
    End Sub

    Private Sub CargaCiudad(ByVal pCodCiudad As String)
        Dim iCodProveedor As Integer = 0
        If ddlProveedor.Items.Count() > 0 Then
            iCodProveedor = ddlProveedor.SelectedItem.Value
        End If

        Dim objCiudad As New clsCiudad
        ddlCiudad.DataSource = objCiudad.CargaCiudad(iCodProveedor)
        ddlCiudad.DataBind()
        If pCodCiudad.Trim.Length > 0 Then
            Try
                ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub CargaTipoServicio(ByVal pCodTipoServicio As Integer)
        Dim iCodProveedor As Integer = 0
        If ddlProveedor.Items.Count() > 0 Then
            iCodProveedor = ddlProveedor.SelectedItem.Value
        End If

        Dim sCodCiudad As String = ""
        If ddlCiudad.Items.Count() > 0 Then
            sCodCiudad = ddlCiudad.SelectedItem.Value
        End If

        Dim objTipoServicio As New clsTipoServicio
        ddltiposervicio.DataSource = objTipoServicio.CargaTiposServicio(iCodProveedor, sCodCiudad)
        ddltiposervicio.DataBind()
        Try
            ddltiposervicio.Items.FindByValue(pCodTipoServicio).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaServicio(ByVal pNroServicio As Integer)
        Dim iCodProveedor As Integer = 0
        If ddlProveedor.Items.Count() > 0 Then
            iCodProveedor = ddlProveedor.SelectedItem.Value
        End If

        Dim sCodCiudad As String = ""
        If ddlCiudad.Items.Count() > 0 Then
            sCodCiudad = ddlCiudad.SelectedItem.Value
        End If

        Dim iCodTipoServicio As Integer = 0
        If ddltiposervicio.Items.Count() > 0 Then
            iCodTipoServicio = ddltiposervicio.SelectedItem.Value
        End If

        Dim objServicio As New clsServicio
        ddlServicio.DataSource = objServicio.CargaxTipoServicio(iCodProveedor, sCodCiudad, iCodTipoServicio)
        ddlServicio.DataBind()
        If pNroServicio > 0 Then
            Try
                ddlServicio.Items.FindByValue(pNroServicio).Selected = True
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub CargaTipoAcomodacion(ByVal pCodTipoAcomodacion As Integer)
        Dim iNroServicio As Integer = 0
        If ddlServicio.Items.Count() > 0 Then
            iNroServicio = ddlServicio.SelectedItem.Value
        End If

        Dim objTipoAcomodacion As New clsTipoAcomodacion
        ddlTipoAcomodacion.DataSource = objTipoAcomodacion.CargarxNroServicio(iNroServicio)
        ddlTipoAcomodacion.DataBind()
        Try
            ddlTipoAcomodacion.Items.FindByValue(pCodTipoAcomodacion).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio(0)
        CargaServicio(0)
        CargaTipoAcomodacion(0)
    End Sub

    Private Sub ddltiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltiposervicio.SelectedIndexChanged
        CargaServicio(0)
        CargaTipoAcomodacion(0)
    End Sub

    Private Sub dgPlanilla_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlanilla.ItemDataBound
        If Trim(e.Item.Cells(10).Text) = "Inactivo" Then
            e.Item.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaTipoAcomodacion(0)
        If txtHoraServicio.Text.Trim.Length = 0 Then
            Try
                objServicio.Editar(ddlServicio.SelectedItem.Value)
                txtHoraServicio.Text = objServicio.HoraInicioServicio
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicios.Click
        Response.Redirect("VtaPlantillaFicha.aspx" & _
                          "?NroPlantilla=" & Viewstate("NroPlantilla"))
    End Sub


End Class
