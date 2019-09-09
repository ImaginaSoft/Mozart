Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports cmpSeguridad
Imports System.Drawing

Partial Class VtaPropuestaFicha
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT031005") = "X" Then
                lbtPlantilla.Visible = True
            End If

            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            lblTitulo.Text = "Ficha de la Propuesta N° " & CStr(Viewstate("NroPropuesta"))
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PropuestaServicio_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Viewstate("NroPedido"))
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = CInt(Viewstate("NroPropuesta"))
        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()

        'lblMsg.Text = CStr(nReg) + " Servicios(s) encontrado(s)"

    End Sub

    Private Sub lbtServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicio.Click
        Response.Redirect("VtaPropuestaServicio.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & ucPropuesta1.NroPropuesta & _
                "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
                "&StsPropuesta=" & ucPropuesta1.StsPropuesta & _
                "&FlagPublica=" & ucPropuesta1.FlagPublica & _
                "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub


    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        If ucPropuesta1.FlagEdita = "E" Then
            lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagEdita = "N" Then
            lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar"
            Return
        End If

        If ucPropuesta1.FlagPublica = "S" Then
            lblMsg.Text = "La Propuesta está publicada, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagPublica = "V" Then
            lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Propuesta_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = ViewState("NroPropuesta")
        lblMsg.Text = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If Trim(lblMsg.Text) = "547" Then
                lblMsg.Text = "Mensaje: Si desea eliminar la Propuesta, primero debe eliminar todos los servicios y links"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error General: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPedidoFicha.aspx" & _
                              "?NroPedido=" & ViewState("NroPedido") & _
                             "&CodCliente=" & ViewState("CodCliente"))
        End If
    End Sub

    Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
        Response.Redirect("VtaPropuestaNueva.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
        "&CodCliente=" & ucPropuesta1.CodCliente)
    End Sub

    Private Sub lbtRevisarVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRevisarVersion.Click
        Response.Redirect("VtaVersion.aspx" & _
        "?CodCliente=" & ucPropuesta1.CodCliente & _
        "&NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub lbtGenerarVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtGenerarVersion.Click
        If ucPropuesta1.FlagEdita = "E" Then
            lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagEdita = "N" Then
            lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionPropuesta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroVersionOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = ucPropuesta1.CodCliente
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        lblMsg.Text = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
            lblMsg.CssClass = "error"
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
        Catch ex2 As System.Exception
            lblMsg.Text = "Error General: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaVersion.aspx" & _
            "?CodCliente=" & ucPropuesta1.CodCliente & _
            "&NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta"))
        End If
    End Sub

    Private Sub lbtPublica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPublica.Click
        Response.Redirect("VtaPropuestaPublica.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

    Private Sub lbtHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistorial.Click
        Response.Redirect("VtaPropuestaHistorial.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&CodCliente=" & ucPropuesta1.CodCliente)
    End Sub

    Private Sub lbtEnviaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEnviaEmail.Click
        Response.Redirect("VtaPropuestaEmail.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&CodCliente=" & ucPropuesta1.CodCliente)
    End Sub

    Private Sub lbtTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTareas.Click
        Response.Redirect("VtaPropuestaTareas.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&CodCliente=" & ucPropuesta1.CodCliente)
    End Sub

    Private Sub lbtPaginaPublicada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPaginaPublicada.Click
        'PRODUCCION Actual
        'O = Origen es Mozart, se pasa este parametro para no grabar log
        'ID= Identificador de cliente, se pasa para no pedir clave

        Dim URL_perutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_perutourism")
        Dim URL_chiletourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_chiletourism")
        Dim URL_galapagostourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_galapagostourism")
        Dim URL_gayperutourism As String = System.Configuration.ConfigurationManager.AppSettings("URL_gayperutourism")
        Dim URL_latajourneys As String = System.Configuration.ConfigurationManager.AppSettings("URL_latajourneys")

        If ucPropuesta1.CodZonaVta = "PER" Then

            'Response.Redirect(URL_perutourism & "/ilogin.aspx?O=M&ID=" & ucPropuesta1.IDCliente)

            Dim URL As String = URL_perutourism & "/" & ucPropuesta1.IDCliente
            Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")


            'Response.Redirect("http://penta/peru4me/ilogin.aspx?ID=" & ucPropuesta1.IDCliente)
        ElseIf ucPropuesta1.CodZonaVta = "ECU" Then
            'Response.Redirect(URL_galapagostourism & "/ilogin.aspx?O=M&ID=" & ucPropuesta1.IDCliente)

            'Dim URL As String = URL_galapagostourism & "/" & ucPropuesta1.IDCliente
            Dim URL As String = URL_perutourism & "/" & ucPropuesta1.IDCliente
            Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

            'Response.Redirect("http://penta/ecua4me/ilogin.aspx?ID=" & ucPropuesta1.IDCliente)
        ElseIf ucPropuesta1.CodZonaVta = "CHL" Then
            'Response.Redirect(URL_chiletourism & "/ilogin.aspx?O=M&ID=" & ucPropuesta1.IDCliente)

            'Dim URL As String = URL_galapagostourism & "/" & ucPropuesta1.IDCliente
            Dim URL As String = URL_perutourism & "/" & ucPropuesta1.IDCliente

            Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

            'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucPropuesta1.IDCliente)
        ElseIf ucPropuesta1.CodZonaVta = "GAY" Then
            'Response.Redirect(URL_gayperutourism & "/ilogin.aspx?O=M&ID=" & ucPropuesta1.IDCliente)

            'Dim URL As String = URL_gayperutourism & "/" & ucPropuesta1.IDCliente
            Dim URL As String = URL_perutourism & "/" & ucPropuesta1.IDCliente

            Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

            'Response.Redirect("http://penta/chile4me/ilogin.aspx?ID=" & ucPropuesta1.IDCliente)
        ElseIf ucPropuesta1.CodZonaVta = "LAJ" Then

            'Dim URL As String = URL_latajourneys & "/" & ucPropuesta1.IDCliente
            Dim URL As String = URL_perutourism & "/" & ucPropuesta1.IDCliente

            Response.Write("<script type='text/javascript'>detailedresults=window.open('" & URL & "');</script>")

            'Response.Redirect(URL_latajourneys & "/ilogin.aspx?O=M&ID=" & ucPropuesta1.IDCliente)
        End If
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            'FlagPrecio=S , Precio del servicio es obligatorio
            If e.Item.Cells(14).Text.Trim = "S" Then
                e.Item.ForeColor = Color.Red
            End If

            If e.Item.Cells(12).Text.Trim = "OK" Then
                e.Item.Cells(12).ForeColor = Color.Blue
            Else
                e.Item.Cells(12).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub lbtPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPlantilla.Click
        If ucPropuesta1.FlagEdita = "E" Then
            lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagEdita = "N" Then
            lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaPropuesta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPlantillaOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")

        lblMsg.Text = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error General: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPlantillaFicha.aspx" & _
            "?NroPlantilla=" & cd.Parameters("@NroPlantillaOut").Value)
        End If
    End Sub

    Private Sub lbtResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResumen.Click
        Response.Redirect("VtaPropuestaResumen.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
        "&StsPropuesta=" & ucPropuesta1.StsPropuesta & _
        "&FlagPublica=" & ucPropuesta1.FlagPublica & _
        "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

    Private Sub lbtDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDias.Click
        Response.Redirect("VtaPropuestaDias.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
        "&StsPropuesta=" & ucPropuesta1.StsPropuesta & _
        "&FlagPublica=" & ucPropuesta1.FlagPublica & _
        "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

    Private Sub lbkLimpiaResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbkLimpiaResumen.Click
        If ucPropuesta1.FlagEdita = "N" Then
            lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagPublica = "S" Then
            lblMsg.Text = "La Propuesta está publicada, no se puede modificar"
            Return
        End If
        If ucPropuesta1.FlagPublica = "V" Then
            lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaResumenLimpia_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
        Catch ex2 As System.Exception
            lblMsg.Text = "Error General: " & ex2.Message
        End Try
        cn.Close()

        If Trim(lblMsg.Text()) = "OK" Then
            Response.Redirect("VtaPropuestaFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta"))
        End If
    End Sub

    Private Sub lbtHistProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtHistProveedor.Click
        Response.Redirect("VtaPedidoHistProveedor.aspx" & _
           "?NroPedido=" & Viewstate("NroPedido") & _
           "&CodCliente=" & ucPropuesta1.CodCliente & _
           "&opcion=1")
    End Sub

    Private Sub lbtReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReserva.Click
        Response.Redirect("VtaPropuestaReserva.aspx" & _
                "?CodCliente=" & ucPropuesta1.CodCliente & _
                "&NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub lbtValorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtValorizacion.Click
        Response.Redirect("VtaPropuestaPrecio.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & ucPropuesta1.NroPropuesta & _
                "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
                "&StsPropuesta=" & ucPropuesta1.StsPropuesta & _
                "&FlagPublica=" & ucPropuesta1.FlagPublica & _
                "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

    Private Sub lbtCambiarHotel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCambiarHotel.Click
        Response.Redirect("VtaPropuestaCambiarHotel.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & ucPropuesta1.NroPropuesta & _
        "&DesPropuesta=" & ucPropuesta1.DesPropuesta & _
        "&StsPropuesta=" & ucPropuesta1.StsPropuesta & _
        "&FlagPublica=" & ucPropuesta1.FlagPublica & _
        "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

    Private Sub lbtLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLink.Click
        Response.Redirect("VtaPropuestaLink.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & ucPropuesta1.NroPropuesta)
    End Sub

    Private Sub lbtEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEspecificacion.Click
        Response.Redirect("VtaPropuestaEspeci.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & ucPropuesta1.NroPropuesta & _
        "&FlagEdita=" & ucPropuesta1.FlagEdita)
    End Sub

End Class
