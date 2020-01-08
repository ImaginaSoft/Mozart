Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class VtaPropuestaCambiarHotel
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
            Viewstate("StsPropuesta") = Request.Params("StsPropuesta")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lbltitulo.Text = "Cambiar Hotel Propuesta N° " & Viewstate("NroPropuesta")
            CargaData()

            If Viewstate("FlagEdita") = "N" Or Viewstate("StsPropuesta") = "V" Or Viewstate("FlagPublica") = "S" Then
                cmdGrabar.Visible = False
                dgServicio.Columns(0).Visible = False
                lblMsg.CssClass = "msg"

                If Viewstate("FlagEdita") = "N" Then
                    lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar los Servicios"
                ElseIf Viewstate("StsPropuesta") = "V" Then
                    lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar los Servicios"
                ElseIf Viewstate("FlagPublica") = "S" Then
                    lblMsg.Text = "La Propuesta está publicada, no se puede modificar los Servicios"
                End If
            End If
        End If
    End Sub

    Private Sub CargaData()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaCambiarHotel_S", arParms)
        dgServicio.DataSource = ds
        dgServicio.DataBind()
        lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If lblNroServicio.Text = "" Then
            lblMsg.Text = "Falta elegir el hotel que desea cambiar"
            Return
        End If

        If ddlServicio.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Servicio"
            Return
        End If

        Dim wCodTipoAcomodacion As Integer
        If ddlTipoAcomodacion.Items.Count() = 0 Then
            wCodTipoAcomodacion = 0
        Else
            wCodTipoAcomodacion = ddlTipoAcomodacion.SelectedItem.Value
        End If


        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaCambiarHotel_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = lblNroServicio.Text
        cd.Parameters.Add("@NroServicioNew", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = wCodTipoAcomodacion
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
            lblNroServicio.Text = ""
            CargaData()
        End If
    End Sub
    Private Sub CargaProveedor()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedorHotel_S", New SqlParameter("@CodCiudad", lblCodCiudad.Text))
        Try
            ddlProveedor.DataSource = ds
            ddlProveedor.DataBind()
            If lblCodProveedor.Text > 0 Then
                ddlProveedor.Items.FindByValue(lblCodProveedor.Text).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe proveedor..continuar
        End Try
    End Sub

    Private Sub CargaServicio()
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        If ddlProveedor.Items.Count = 0 Then
            arParms(0).Value = 0
        Else
            arParms(0).Value = ddlProveedor.SelectedItem.Value
        End If
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = lblCodCiudad.Text
        arParms(2) = New SqlParameter("@CodTipoServicio", SqlDbType.SmallInt)
        arParms(2).Value = 2

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioActivoxCodTipoServicio_S", arParms)
        Try
            ddlServicio.DataSource = ds
            ddlServicio.DataBind()
            If lblNroServicio.Text > 0 Then
                ddlServicio.Items.FindByValue(lblNroServicio.Text).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe servicio..continuar
        End Try
    End Sub

    Private Sub CargaTipoAcomodacion(ByVal pCodTipoAcomodacion As Integer)
        Dim ds As New DataSet
        If ddlServicio.Items.Count() > 0 Then
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoAcomodacionxServicio_S", New SqlParameter("@NroServicio", ddlServicio.SelectedItem.Value))
        Else
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoAcomodacionxServicio_S", New SqlParameter("@NroServicio", 0))
        End If
        Try
            ddlTipoAcomodacion.DataSource = ds
            ddlTipoAcomodacion.DataBind()
            If pCodTipoAcomodacion > 0 Then
                ddlTipoAcomodacion.Items.FindByValue(pCodTipoAcomodacion).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe servicio..continuar
        End Try
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaTipoAcomodacion(0)
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(5).Text
        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text

        lblCodProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text
        lblCodCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(9).Text
        lblCodTipoAcomodacion.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text
        lblNroServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblMsg.Text = ""

        CargaProveedor()
        CargaServicio()

        If dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text = "C" Then
            CargaTipoAcomodacion(lblCodTipoAcomodacion.Text)
        Else
            CargaTipoAcomodacion(0)
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaServicio()
        CargaTipoAcomodacion(0)
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(12).Text.Trim = "Falta" Then
                e.Item.Cells(3).ForeColor = Color.Red
                e.Item.Cells(12).ForeColor = Color.Red
            End If
        End If
    End Sub

End Class
