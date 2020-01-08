Imports cmpNegocio
Imports cmpRutinas
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionServicio
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objVersionDet As New clsVersionDet
    Dim objProveedor As New clsProveedor
    Dim objServicio As New clsServicio

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("DesVersion") = Request.Params("DesVersion")
            Viewstate("StsVersion") = Request.Params("StsVersion")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Servicios Versión N° " & Viewstate("NroVersion")

            Dim wCodProveedor As Integer = objRutina.LeeParametroNumero("DefaultCodProveedor")

            CargaProveedorS(wCodProveedor)
            CargaCiudad("")
            CargaTipoServicio(0)
            CargaServicio(0)
            CargaTipoAcomodacion(0)
            CargaData()
            PaxHab("")
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet
        ds = objVersionDet.CargaServicios(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        dgServicio.DataKeyField = "KeyReg"
        dgServicio.DataSource = ds
        dgServicio.DataBind()
        Dim nReg As Integer = dgServicio.Items.Count

        If Viewstate("FlagEdita") = "N" Or Viewstate("FlagEdita") = "E" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            If Viewstate("FlagEdita") = "N" Then
                lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar los Servicios"
            Else
                lblMsg.Text = "La Versión es de otra empresa, no se puede modificar los Servicios"
            End If
            lblMsg.CssClass = "msg"
            Return
        Else
            lblMsg.Text = CStr(nReg) + " Servicio(s) encontrado(s)"
        End If

        If Viewstate("StsPropuesta") = "V" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            lblMsg.Text = "La Versión esta aprobado, está pendiente de facturar"
            lblMsg.CssClass = "msg"
            Return
        End If

        If Viewstate("FlagPublica") = "S" Then
            cmdGrabar.Visible = False
            dgServicio.Columns(0).Visible = False
            dgServicio.Columns(13).Visible = False
            lblMsg.Text = "La Versión está publicada, no se puede modificar los Servicios"
            lblMsg.CssClass = "msg"
        Else
            lblMsg.Text = CStr(nReg) + " Servicio(s) encontrado(s)"
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

        Dim wHoraServicio As String
        If txtHoraSalida.Text.Trim.Length <> 0 Then
            wHoraServicio = txtHoraSalida.Text
        Else
            wHoraServicio = txtHoraLlegada.Text
        End If

        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.NroDia = Textdia.Text
        objVersionDet.NroOrden = Textorden.Text
        objVersionDet.HoraServicio = wHoraServicio
        objVersionDet.NroServicio = ddlServicio.SelectedItem.Value
        objVersionDet.CodTipoServicio = ddltiposervicio.SelectedItem.Value
        objVersionDet.CodTipoAcomodacion = wCodTipoAcomodacion
        objVersionDet.NroDiaAnt = wDiaAnt
        objVersionDet.NroOrdAnt = wOrdAnt
        objVersionDet.NroSerAnt = wSerAnt
        objVersionDet.CantAduSGL = iAS
        objVersionDet.CantAduDBL = iAD
        objVersionDet.CantAduTPL = iAT
        objVersionDet.CantAduCDL = iAC
        objVersionDet.CantNinSGL = iNS
        objVersionDet.CantNinDBL = iND
        objVersionDet.CantNinTPL = iNT
        objVersionDet.CantNinCDL = iNC
        objVersionDet.MontoFijo = wMontoFijo
        objVersionDet.RangoTarifa = wRangoTarifa
        If rbtUpdate.Checked Then
            objVersionDet.Opcion = "U" ' Update reg. en DVERSION
        Else
            objVersionDet.Opcion = "I" ' Insert reg. en DVERSION, siempre que no exista
        End If
        objVersionDet.HoraSalida = txtHoraSalida.Text
        objVersionDet.HoraLlegada = txtHoraLlegada.Text
        objVersionDet.CodUsuario = Session("CodUsuario")

        lblMsg.Text = objVersionDet.Grabar
        If lblMsg.Text.Trim = "OK" Then
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
        PaxHab("")
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
        txtHoraSalida.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(18).Text.Trim
        txtHoraLlegada.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(19).Text.Trim
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

        lblMsg.Text = objVersionDet.Editar(wNroServicio, "")
        If lblMsg.Text.Trim = "OK" Then
            wCodCiudad = objversiondet.CodCiudad
            wCodProveedor = objversiondet.CodProveedor
            wCodTipoServicio = objversiondet.CodTipoServicio
        End If

        ' Carga Pax, Habitaciones y Rango Tarifa
        Dim cd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        cd2.Connection = cn
        cd2.CommandText = "VTA_VersionServicioPaxHab_S"
        cd2.CommandType = CommandType.StoredProcedure
        cd2.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd2.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd2.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
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
                    'Hotel - Adultos y tipo hab
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
                    'Hotel - Niños y tipo hab
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

        PaxHab("")
    End Sub

    Private Sub CargaProveedorS(ByVal pCodProveedor As Integer)
        Dim ds As New DataSet
        ds = objProveedor.CargaProveedores
        ddlProveedor.DataSource = ds
        ddlProveedor.DataBind()
        Try
            If pCodProveedor > 0 Then
                ddlProveedor.Items.FindByValue(pCodProveedor).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe proveedor..continuar
        End Try
    End Sub

    Private Sub CargaCiudad(ByVal pCodCiudad As String)
        Dim ds As New DataSet
        Dim wCodProveedor As Integer = 0
        If ddlProveedor.Items.Count > 0 Then
            wCodProveedor = ddlProveedor.SelectedItem.Value
        End If
        ds = objProveedor.CargaCiudad(wCodProveedor)
        ddlCiudad.DataSource = ds
        ddlCiudad.DataBind()
        Try
            If pCodCiudad.Trim.Length > 0 Then
                ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe ciudad..continuar
        End Try
    End Sub

    Private Sub CargaTipoServicio(ByVal pCodTipoServicio As Integer)
        Dim ds As New DataSet
        Dim wCodProveedor As Integer = 0
        Dim wCodCiudad As String = " "
        If ddlProveedor.Items.Count > 0 Then
            wCodProveedor = ddlProveedor.SelectedItem.Value
        End If
        If ddlCiudad.Items.Count() > 0 Then
            wCodCiudad = ddlCiudad.SelectedItem.Value
        End If

        ds = objProveedor.CargaTipoServicio(wCodProveedor, wCodCiudad)
        ddltiposervicio.DataSource = ds
        ddltiposervicio.DataBind()
        Try
            If pCodTipoServicio > 0 Then
                ddltiposervicio.Items.FindByValue(pCodTipoServicio).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaServicio(ByVal pNroServicio As Integer)
        Dim ds As New DataSet
        Dim wCodProveedor As Integer = 0
        Dim wCodCiudad As String = " "
        Dim wCodTipoServicio As Integer = 0
        If ddlProveedor.Items.Count > 0 Then
            wCodProveedor = ddlProveedor.SelectedItem.Value
        End If
        If ddlCiudad.Items.Count() > 0 Then
            wCodCiudad = ddlCiudad.SelectedItem.Value
        End If
        If ddltiposervicio.Items.Count() > 0 Then
            wCodTipoServicio = ddltiposervicio.SelectedItem.Value
        End If

        ds = objProveedor.CargaServicio(wCodProveedor, wCodCiudad, wCodTipoServicio)
        ddlServicio.DataSource = ds
        ddlServicio.DataBind()
        Try
            If pNroServicio > 0 Then
                ddlServicio.Items.FindByValue(pNroServicio).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaTipoAcomodacion(ByVal pCodTipoAcomodacion As Integer)
        Dim ds As New DataSet
        Dim wNroServicio As Integer = 0
        If ddlServicio.Items.Count() > 0 Then
            wNroServicio = ddlServicio.SelectedItem.Value
        End If
        ds = objServicio.CargaTipoAcomodacion(wNroServicio)
        ddlTipoAcomodacion.DataSource = ds
        ddlTipoAcomodacion.DataBind()
        Try
            If pCodTipoAcomodacion > 0 Then
                ddlTipoAcomodacion.Items.FindByValue(pCodTipoAcomodacion).Selected = True
            End If
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub ddlCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCiudad.SelectedIndexChanged
        CargaTipoServicio(0)
        CargaServicio(0)
        CargaTipoAcomodacion(0)
        PaxHab("")
    End Sub

    Private Sub ddltiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltiposervicio.SelectedIndexChanged
        CargaServicio(0)
        CargaTipoAcomodacion(0)
        PaxHab("")
    End Sub

    Private Sub PaxHab(ByVal pEstado As String)
        'Flag Valoriza
        lblMontoFijo.Visible = False
        txtMontoFijo.Visible = False
        txtFlagValoriza.Text = ""

        pEstado = "N"

        If ddlServicio.Items.Count > 0 Then
            Dim cd As New SqlCommand
            Dim dr As SqlDataReader
            cd.Connection = cn
            cd.CommandText = "peru4me_new.VTA_ServicioNroServicio_S_NEW"
            cd.CommandType = CommandType.StoredProcedure
            cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = ddlServicio.SelectedValue
            cd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = pEstado

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
        cd.CommandText = "VTA_VersionServicio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 13, 2)
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 15, 2)
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Mid(dgServicio.DataKeys(e.Item.ItemIndex), 17, 8)
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

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(17).Text.Trim = "S" Then
                e.Item.ForeColor = Color.Red
            ElseIf e.Item.Cells(15).Text = "2" Then ' Hotel
                e.Item.ForeColor = Color.DarkBlue
            End If
        End If
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaTipoAcomodacion(0)
        PaxHab("")
    End Sub

    Private Sub lbtPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPrecio.Click
        Response.Redirect("VtaVersionPrecio.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion") & _
        "&DesPropuesta=" & Viewstate("DesPropuesta"))
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

End Class
