Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Partial Class VtaPedidoPasajero
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            CargaPais("")
            CargaTipoPasajero("")
            CargaDatos()
        End If

    End Sub
    Private Sub CargaPais(ByVal pCodPais As String)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "peru4me_new.TAB_Pais_S")
        ddlpais.DataSource = ds
        ddlpais.DataBind()
        If pCodPais.Trim.Length > 0 Then
            If ddlpais.Items.FindByValue(pCodPais) IsNot Nothing Then
                ddlpais.Items.FindByValue(pCodPais).Selected = True
            Else

                ddlpais.Items.FindByValue("999").Selected = True

            End If
            ' ddlpais.Items.FindByValue(pCodPais).Selected = True
        End If
    End Sub
    Private Sub CargaTipoPasajero(ByVal pCodTipoPasajero As String)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoPasajero_S")
        ddltipopasajero.DataSource = ds
        ddltipopasajero.DataBind()
        If pCodTipoPasajero.Trim.Length > 0 Then
            ddltipopasajero.Items.FindByValue(pCodTipoPasajero).Selected = True
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "peru4me_new.VTA_PasajeroNroPedido_S", New SqlParameter("@NroPedido", ViewState("NroPedido")))
        dgPasajero.DataKeyField = "NroPasajero"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgPasajero.DataSource = dv
        dgPasajero.DataBind()
        dgPasajero.SelectedItemStyle.Reset()
        lblMsg.Text = CStr(dgPasajero.Items.Count) + " Pasajeros(s)"
    End Sub
    Private Sub dgPasajero_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wpais, wpasajero As String

        If ddlpais.Items.Count = 0 Then
            wpais = ""
        Else
            wpais = ddlpais.SelectedItem.Value
        End If
        If ddltipopasajero.Items.Count = 0 Then
            wpasajero = ""
        Else
            wpasajero = ddltipopasajero.SelectedItem.Value
        End If

        Dim wNroPasajero As Integer
        If IsNumeric(lblCodigo.Text) Then
            wNroPasajero = lblCodigo.Text
        Else
            wNroPasajero = 0
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Pasajero_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPedidoOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPasajero", SqlDbType.SmallInt).Value = wNroPasajero
        cd.Parameters.Add("@NomPasajero", SqlDbType.VarChar, 50).Value = txtNombre.Text
        cd.Parameters.Add("@ApPasajero", SqlDbType.VarChar, 50).Value = txtApellido.Text
        cd.Parameters.Add("@Pasaporte", SqlDbType.VarChar, 30).Value = txtPasaporte.Text
        cd.Parameters.Add("@Nacionalidad", SqlDbType.Char, 3).Value = wpais
        cd.Parameters.Add("@FchNacimiento", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchNacimiento.Text())
        cd.Parameters.Add("@TipoPasajero", SqlDbType.Char, 1).Value = wpasajero
        cd.Parameters.Add("@Observacion", SqlDbType.VarChar, 80).Value = txtObservaciones.Text
        'cd.Parameters.Add("@CodReserva", SqlDbType.Char, 10).Value = "" 'txtCodReserva.Text
        'cd.Parameters.Add("@Paterno", SqlDbType.VarChar, 25).Value = "" 'txtPaterno.Text
        cd.Parameters.Add("@Acomodacion", SqlDbType.VarChar, 2).Value = txtAcomodacion.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        cd.Parameters.Add("@CodGenero", SqlDbType.Char, 1).Value = ddlGenero.SelectedValue
        cd.Parameters.Add("@DesIdioma", SqlDbType.VarChar, 50).Value = txtDesIdioma.Text
        cd.Parameters.Add("@DesHabitacion", SqlDbType.VarChar, 50).Value = txtDesHabitacion.Text
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
            CargaDatos()
            lblCodigo.Text = cd.Parameters("@NroPedidoOut").Value()
            NuevoPasajero()
        End If
    End Sub

    Private Sub dgPasajero_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPasajero.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Pasajero_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPasajero", SqlDbType.SmallInt).Value = dgPasajero.DataKeys(e.Item.ItemIndex)
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If lblMsg.Text = "547" Then
                lblMsg.Text = "Mensaje: Si desea eliminar Pais, primero debe eliminar todos los Clientes asociados"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgPasajero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPasajero.SelectedIndexChanged
        Dim wcospais, wtipopasajero, wfecha As String

        lblCodigo.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(1).Text
        txtNombre.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(2).Text
        txtApellido.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(3).Text

        If txtApellido.Text.Trim.Equals("&nbsp;") Then
            txtApellido.Text = ""
        End If


        txtAcomodacion.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(5).Text
        txtObservaciones.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(6).Text
        txtPasaporte.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(7).Text
        wfecha = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(9).Text
        'txtCodReserva.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(9).Text
        'txtPaterno.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(12).Text



        txtDesIdioma.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(16).Text
        If txtDesIdioma.Text.Trim.Equals("&nbsp;") Then
            txtDesIdioma.Text = ""
        End If

        txtDesHabitacion.Text = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(17).Text
        If txtDesHabitacion.Text.Trim.Equals("&nbsp;") Then
            txtDesHabitacion.Text = ""
        End If

        If Len(Trim(wfecha)) = 10 Then
            txtFchNacimiento.Text = wfecha
        Else
            txtFchNacimiento.Text = ""
        End If

        If txtAcomodacion.Text.Trim.Equals("&nbsp;") Then
            txtAcomodacion.Text = ""
        End If

        If txtPasaporte.Text.Trim.Equals("&nbsp;") Then
            txtPasaporte.Text = ""
        End If

        If txtObservaciones.Text.Trim.Equals("&nbsp;") Then
            txtObservaciones.Text = ""
        End If

        'If txtPaterno.Text.Trim.Equals("&nbsp;") Then
        'txtPaterno.Text = ""
        'End If

        wtipopasajero = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(10).Text
        'wcospais = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(11).Text

        wcospais = dgPasajero.Items(dgPasajero.SelectedIndex).Cells(12).Text

        CargaPais(wcospais)
        CargaTipoPasajero(wtipopasajero)

        'genero
        ddlGenero.ClearSelection()
        Try
            ddlGenero.Items.FindByValue(dgPasajero.Items(dgPasajero.SelectedIndex).Cells(15).Text.Trim).Selected = True
        Catch ex As Exception

        End Try



    End Sub

    Private Sub NuevoPasajero()
        lblCodigo.Text = "0"
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtPasaporte.Text = ""
        txtFchNacimiento.Text = ""
        txtObservaciones.Text = ""
        'txtCodReserva.Text = ""
        txtAcomodacion.Text = ""
        txtDesIdioma.Text = ""
        txtDesHabitacion.Text = ""
        CargaPais("")
        CargaTipoPasajero("")
    End Sub

    Private Sub btnlimpiafecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlimpiafecha.Click
        txtFchNacimiento.Text = ""
    End Sub

    Protected Sub txtObservaciones1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesHabitacion.TextChanged

    End Sub
End Class
