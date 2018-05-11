Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class VtaPropuestaServicio
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("DesPropuesta") = Request.Params("DesPropuesta")
            ViewState("StsPropuesta") = Request.Params("StsPropuesta")
            ViewState("FlagPublica") = Request.Params("FlagPublica")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Servicios Propuesta N° " & ViewState("NroPropuesta")

            Dim wCodProveedor As Integer = objRutina.LeeParametroNumero("DefaultCodProveedor")

            CargaProveedorS(wCodProveedor)
            CargaCiudad("")
            CargaTipoServicio(0)
            CargaServicio(0)
            CargaTipoAcomodacion(0)
            CargaData()
            PaxHab()
        End If
    End Sub

    Private Sub CargaData()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaServicio_S", arParms)
        dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds
        dgServicio.DataBind()

        If Viewstate("FlagEdita") = "N" Or Viewstate("FlagEdita") = "E" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            If Viewstate("FlagEdita") = "N" Then
                lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar los Servicios"
            Else
                lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar los Servicios"
            End If
            lblMsg.CssClass = "msg"
            Return
        Else
            lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
        End If

        If Viewstate("StsPropuesta") = "V" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            lblMsg.Text = "La Propuesta ya tiene versión, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
            Return
        End If

        If Viewstate("FlagPublica") = "S" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            lblMsg.Text = "La Propuesta está publicada, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
        Else
            lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        If ddlProveedor.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Proveedor"
            Return
        End If
        If ddlCiudad.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Ciudad"
            Return
        End If
        If ddltiposervicio.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Tipo de Servicio"
            Return
        End If
        If ddlServicio.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Servicio"
            Return
        End If

        If Textdia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Dia es dato obligatorio"
            Return
        ElseIf Not IsNumeric(Textdia.Text) Then
            lblMsg.Text = "Error: Dia es dato númerico"
            Return
        End If

        If Textorden.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Orden es dato obligatorio"
            Return
        ElseIf Not IsNumeric(Textorden.Text) Then
            lblMsg.Text = "Error: Orden es dato númerico"
            Return
        End If

        Dim wRangoTarifa As Integer = 0
        If txtFlagValoriza.Text.Trim = "C" Then
            If txtRangoTarifa.Text.Trim.Length = 0 Then
                lblMsg.Text = "Error: Rango Tarifa es dato obligatorio"
                Return
            ElseIf Not IsNumeric(txtRangoTarifa.Text) Then
                lblMsg.Text = "Error: Rango Tarifa es dato númerico"
                Return
            End If
            wRangoTarifa = txtRangoTarifa.Text
        End If

        If txtDiaAnt.Text.Trim.Length = 0 And rbtUpdate.Checked Then
            lblMsg.Text = "Error: Falta editar el servicio que desea reemplazar"
            Return
        End If

        Dim iAS As Integer = objRutina.ConvierteEntero(txtAS.Text)
        Dim iAD As Integer = objRutina.ConvierteEntero(txtAD.Text)
        Dim iAT As Integer = objRutina.ConvierteEntero(txtAT.Text)
        Dim iAC As Integer = objRutina.ConvierteEntero(txtAC.Text)

        Dim iNS As Integer = objRutina.ConvierteEntero(txtNS.Text)
        Dim iND As Integer = objRutina.ConvierteEntero(txtND.Text)
        Dim iNT As Integer = objRutina.ConvierteEntero(txtNT.Text)
        Dim iNC As Integer = objRutina.ConvierteEntero(txtNC.Text)

        If iAS + iAD + iAT + iAC + iNS + iND + iNT + iNC = 0 Then
            lblMsg.Text = "Error: Ingrese por los menos 1 tipo de pasajero"
            Return
        End If

        Dim wMontoFijo As Double
        If txtMontoFijo.Text.Trim.Length = 0 Then
            wMontoFijo = 0
        ElseIf IsNumeric(txtMontoFijo.Text) Then
            wMontoFijo = CDbl(txtMontoFijo.Text)
        Else
            wMontoFijo = 0
            Return
        End If

        Dim wEstado, wDiaAnt, wOrdAnt, wSerAnt As String
        Dim CodLink As Integer

        If Len(Trim(txtDiaAnt.Text)) = 0 Or rbtNuevo.Checked Then
            wDiaAnt = 0
        Else
            wDiaAnt = CInt(txtDiaAnt.Text)
        End If

        If Len(Trim(txtOrdenAnt.Text)) = 0 Or rbtNuevo.Checked Then
            wOrdAnt = 0
        Else
            wOrdAnt = CInt(txtOrdenAnt.Text)
        End If

        If Len(Trim(txtNroServicioAnt.Text)) = 0 Or rbtNuevo.Checked Then
            wSerAnt = 0
        Else
            wSerAnt = CInt(txtNroServicioAnt.Text)
        End If

        Dim wCodTipoAcomodacion As Integer
        If ddlTipoAcomodacion.Items.Count() = 0 Then
            wCodTipoAcomodacion = 0
        Else
            wCodTipoAcomodacion = ddlTipoAcomodacion.SelectedItem.Value
        End If

        Dim wOpcion As String
        If rbtUpdate.Checked Then
            wOpcion = "U" ' Update reg. en DPROPUESTA
        Else
            wOpcion = "I" ' Insert reg. en DPROPUESTA, siempre que no exista
        End If


        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaServicio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Textdia.Text
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Textorden.Text
        cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = txtHoraServicio.Text
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedItem.Value
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = ddltiposervicio.SelectedItem.Value
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = wCodTipoAcomodacion
        cd.Parameters.Add("@NroDiaAnt", SqlDbType.SmallInt).Value = wDiaAnt
        cd.Parameters.Add("@NroOrdenAnt", SqlDbType.SmallInt).Value = wOrdAnt
        cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = wSerAnt
        cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = iAS
        cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = iAD
        cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = iAT
        cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = iAC
        cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = iNS
        cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = iND
        cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = iNT
        cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = iNC
        cd.Parameters.Add("@MontoFijo", SqlDbType.Money).Value = wMontoFijo
        cd.Parameters.Add("@RangoTarifa", SqlDbType.TinyInt).Value = wRangoTarifa
        cd.Parameters.Add("@Opcion", SqlDbType.Char, 1).Value = wOpcion
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
            'Registro grabado pasa como anterior
            txtDiaAnt.Text = Textdia.Text
            txtOrdenAnt.Text = Textorden.Text
            txtNroServicioAnt.Text = ddlServicio.SelectedItem.Value

            CargaData()
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaCiudad("")
        CargaTipoServicio(0)
        CargaServicio(0)
        CargaTipoAcomodacion(0)
        PaxHab()
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        ' Datos del Servicio
        Dim wCodCiudad As String
        Dim wCodProveedor, wCodTipoServicio As Integer
        Dim wNroServicio, wCodTipoAcomodacion As Integer
        Dim wRangoTarifa As Integer = 0

        wCodTipoAcomodacion = dgServicio.Items(dgServicio.SelectedIndex).Cells(15).Text

        Textdia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text.Trim
        Textorden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text.Trim
        txtHoraServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text.Trim
        txtMontoFijo.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text.Trim

        txtDiaAnt.Text = Textdia.Text
        txtOrdenAnt.Text = Textorden.Text
        txtNroServicioAnt.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        wNroServicio = txtNroServicioAnt.Text

        txtFlagValoriza.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(10).Text

        If txtFlagValoriza.Text.Trim = "C" Then
            lblMontoFijo.Visible = False
            txtMontoFijo.Visible = False
        Else
            lblMontoFijo.Visible = True
            txtMontoFijo.Visible = True
        End If

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioNroServicio_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = wNroServicio
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wCodCiudad = dr.GetValue(dr.GetOrdinal("CodCiudad"))
                wCodProveedor = dr.GetValue(dr.GetOrdinal("CodProveedor"))
                wCodTipoServicio = dr.GetValue(dr.GetOrdinal("CodTipoServicio"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        ' Carga Pax, Habitaciones y Rango Tarifa
        Dim cd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        cd2.Connection = cn
        cd2.CommandText = "VTA_ServicioPaxHab_S"
        cd2.CommandType = CommandType.StoredProcedure
        cd2.Parameters.Add("@NroPedido", SqlDbType.Int).Value = ViewState("NroPedido")
        cd2.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = ViewState("NroPropuesta")
        cd2.Parameters.Add("@NroDia", SqlDbType.TinyInt).Value = Textdia.Text
        cd2.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Textorden.Text
        cd2.Parameters.Add("@NroServicio", SqlDbType.Int).Value = wNroServicio

        txtAS.Text = ""
        txtAD.Text = ""
        txtAT.Text = ""
        txtAC.Text = ""

        txtNS.Text = ""
        txtND.Text = ""
        txtNT.Text = ""
        txtNC.Text = ""

        txtRangoTarifa.Text = ""
        Try
            cn.Open()
            dr2 = cd2.ExecuteReader
            Do While dr2.Read()
                txtRangoTarifa.Text = ToString.Format("{0:###}", dr2.GetValue(dr2.GetOrdinal("RangoTarifa")))

                If dr2.GetValue(dr2.GetOrdinal("CodGrupoServicio")) = "O" Then
                    'Terrestres
                    If dr2.GetValue(dr2.GetOrdinal("CodTipoPasajero")) = "A" Then
                        txtAS.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodTipoPasajero")) = "N" Then
                        txtNS.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                ElseIf dr2.GetValue(dr2.GetOrdinal("CodTipoPasajero")) = "A" Then
                    'Naves - Adultos y tipo hab
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "S" Then
                        txtAS.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "D" Then
                        txtAD.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "T" Then
                        txtAT.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "C" Then
                        txtAC.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If

                ElseIf dr2.GetValue(dr2.GetOrdinal("CodTipoPasajero")) = "N" Then
                    'Naves - Niños y tipo hab
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "S" Then
                        txtNS.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "D" Then
                        txtND.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "T" Then
                        txtNT.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                    If dr2.GetValue(dr2.GetOrdinal("CodSubTipo")) = "C" Then
                        txtNC.Text = dr2.GetValue(dr2.GetOrdinal("CantPersonas"))
                    End If
                End If
            Loop
            dr2.Close()
        Finally
            cn.Close()
        End Try


        ' Carga Dropdownlist
        CargaProveedorS(wCodProveedor)
        CargaCiudad(wCodCiudad)
        CargaTipoServicio(wCodTipoServicio)
        CargaServicio(wNroServicio)

        If txtFlagValoriza.Text = "C" Or txtFlagValoriza.Text = "T" Then
            CargaTipoAcomodacion(wCodTipoAcomodacion)
        Else
            CargaTipoAcomodacion(0)
        End If

        PaxHab()
    End Sub

    Private Sub CargaProveedorS(ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedorServicio_S")
        Try
            ddlProveedor.DataSource = ds
            ddlProveedor.DataBind()
            If pCodProveedor > 0 Then
                ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe proveedor..continuar
        End Try
    End Sub

    Private Sub CargaCiudad(ByVal pCodCiudad As String)
        Dim ds As New DataSet
        If ddlProveedor.Items.Count > 0 Then
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_CiudadxProveedor_S", New SqlParameter("@CodProveedor", ddlProveedor.SelectedItem.Value))
        Else
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_CiudadxProveedor_S", New SqlParameter("@CodProveedor", 0))
        End If

        Try
            ddlCiudad.DataSource = ds
            ddlCiudad.DataBind()
            If pCodCiudad.Trim.Length > 0 Then
                ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe ciudado..continuar
        End Try
    End Sub


    Private Sub CargaTipoServicio(ByVal pCodTipoServicio As Integer)
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        If ddlProveedor.Items.Count > 0 Then
            arParms(0).Value = ddlProveedor.SelectedItem.Value
        Else
            arParms(0).Value = 0
        End If

        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        If ddlCiudad.Items.Count() > 0 Then
            arParms(1).Value = ddlCiudad.SelectedItem.Value
        Else
            arParms(1).Value = " "
        End If

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoServicioxCiudad_S", arParms)
        Try
            ddltiposervicio.DataSource = ds
            ddltiposervicio.DataBind()
            If pCodTipoServicio > 0 Then
                ddltiposervicio.Items.FindByValue(pCodTipoServicio).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe tiposervicio..continuar
        End Try
    End Sub

    Private Sub CargaServicio(ByVal pNroServicio As Integer)
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        If ddlProveedor.Items.Count > 0 Then
            arParms(0).Value = ddlProveedor.SelectedItem.Value
        Else
            arParms(0).Value = 0
        End If

        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        If ddlCiudad.Items.Count() > 0 Then
            arParms(1).Value = ddlCiudad.SelectedItem.Value
        Else
            arParms(1).Value = " "
        End If

        arParms(2) = New SqlParameter("@CodTipoServicio", SqlDbType.SmallInt)
        If ddltiposervicio.Items.Count() > 0 Then
            arParms(2).Value = ddltiposervicio.SelectedItem.Value
        Else
            arParms(2).Value = 0
        End If

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioActivoxCodTipoServicio_S", arParms)
        Try
            ddlServicio.DataSource = ds
            ddlServicio.DataBind()
            If pNroServicio > 0 Then
                ddlServicio.Items.FindByValue(pNroServicio).Selected = True
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

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio(0)
        CargaServicio(0)
        CargaTipoAcomodacion(0)
        PaxHab()
    End Sub

    Private Sub ddltiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltiposervicio.SelectedIndexChanged
        CargaServicio(0)
        CargaTipoAcomodacion(0)
        PaxHab()
    End Sub

    Private Sub PaxHab()
        'Flag Valoriza
        lblMontoFijo.Visible = False
        txtMontoFijo.Visible = False
        txtFlagValoriza.Text = ""

        If ddlServicio.Items.Count > 0 Then
            Dim cd As New SqlCommand
            Dim dr As SqlDataReader
            cd.Connection = cn
            cd.CommandText = "VTA_ServicioNroServicio_S"
            cd.CommandType = CommandType.StoredProcedure
            cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedValue
            Try
                cn.Open()
                dr = cd.ExecuteReader
                Do While dr.Read()
                    txtFlagValoriza.Text = dr.GetValue(dr.GetOrdinal("FlagValoriza"))
                    If dr.GetValue(dr.GetOrdinal("FlagValoriza")) = "M" Or _
                       dr.GetValue(dr.GetOrdinal("FlagValoriza")) = "A" Then
                        lblMontoFijo.Visible = True
                        txtMontoFijo.Visible = True
                    End If

                    If dr.GetValue(dr.GetOrdinal("CodTipoServicio")) = 2 Then
                        txtRangoTarifa.Text = 1
                    End If
                Loop
                dr.Close()
            Finally
                cn.Close()
            End Try
        End If

        'Tipo Acomodacion y Rango Tarifa
        If txtFlagValoriza.Text.Trim = "C" Then  'Por Cantidad de pasajero o habitaciones (tarifa por Pasajero o Habitacion)
            lblTipoAcomodacion.Visible = True
            ddlTipoAcomodacion.Visible = True
            lblRangoTarifa.Visible = True
            txtRangoTarifa.Visible = True
        Else
            lblRangoTarifa.Visible = False
            txtRangoTarifa.Visible = False
            If txtFlagValoriza.Text.Trim = "T" Then 'Por Persona (Tarifa TipoHab-TipoPasajero)
                lblTipoAcomodacion.Visible = True
                ddlTipoAcomodacion.Visible = True
            Else
                lblTipoAcomodacion.Visible = False  'Por Monto o Ajuste
                ddlTipoAcomodacion.Visible = False
            End If
        End If

        If ddltiposervicio.SelectedValue = 2 Then
            lblAdultos.Visible = True
            lblNinos.Visible = True
            lblHabSimple.Visible = True
            lblHabDoble.Visible = True
            lblHabTriple.Visible = True
            lblHabCuadruple.Visible = True
            txtAS.Visible = True
            txtAD.Visible = True
            txtAT.Visible = True
            txtAC.Visible = True
            txtNS.Visible = True
            txtND.Visible = True
            txtNT.Visible = True
            txtNC.Visible = True
        Else
            lblAdultos.Visible = True
            lblNinos.Visible = True
            lblHabSimple.Visible = False
            lblHabDoble.Visible = False
            lblHabTriple.Visible = False
            lblHabCuadruple.Visible = False
            txtAS.Visible = True
            txtAD.Visible = False
            txtAT.Visible = False
            txtAC.Visible = False
            txtNS.Visible = True
            txtND.Visible = False
            txtNT.Visible = False
            txtNC.Visible = False

            txtAD.Text = ""
            txtAT.Text = ""
            txtAC.Text = ""

            txtND.Text = ""
            txtNT.Text = ""
            txtNC.Text = ""
        End If
    End Sub

    Private Sub dgServicio_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgServicio.DeleteCommand
        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaServicio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 11, 2)
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 13, 2)
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 15, 8)
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
            CargaData()
        End If
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(17).Text.Trim = "S" Then ' Falta precio
                e.Item.ForeColor = Color.Red
            ElseIf e.Item.Cells(16).Text = "2" Then ' Hotel
                e.Item.ForeColor = Color.DarkBlue
            End If
        End If
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaTipoAcomodacion(0)
        PaxHab()
    End Sub

    Private Sub lbtPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrecio.Click
        Response.Redirect("VtaPropuestaPrecio.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&DesPropuesta=" & Viewstate("DesPropuesta"))
    End Sub

End Class
