Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Partial Class vtaVersionBoletoVta
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim CodForma As String
            Dim CodProveedor As Integer = 94 'Proveedor BSP Default

            'Recepción de Parametros
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("StsVersion") = Request.Params("StsVersion")

            txtporigv.Text = Session("PIGV")
            Viewstate("Comision1") = objRutina.LeeParametroNumero("PComision1")
            Viewstate("Comision2") = objRutina.LeeParametroNumero("PComision2")

            'Estado del Boleto
            ddlEstadoBoleto.Items.Insert(0, New ListItem("STOCK"))
            ddlEstadoBoleto.Items.Insert(1, New ListItem("VENDIDO"))
            ddlEstadoBoleto.Items.Insert(2, New ListItem("VOID"))
            ddlEstadoBoleto.Items.Insert(3, New ListItem("DEVUELTO"))
            'Tipo Pasajero
            ddlTipoPasajero.Items.Insert(0, New ListItem("Elegir Tipo"))
            ddlTipoPasajero.Items.Insert(1, New ListItem("Adulto"))
            ddlTipoPasajero.Items.Insert(2, New ListItem("Niño"))
            ddlTipoPasajero.Items.Insert(3, New ListItem("Infante"))

            'Cargamos Proveedor
            CargaProveedor(CodProveedor)
            'Cargamos la Forma
            If ddlProveedor.Items.Count > 0 Then
                '                ddlProveedor.Items.FindByValue(CodProveedor).Selected = True
                'CodProveedor = ddlProveedor.SelectedItem.Value
                CargaForma(CodProveedor, "")
            End If
            'Cargamos la Serie
            If ddlForma.Items.Count > 0 Then
                CodForma = ddlForma.SelectedItem.Value
                CargaSerie(CodProveedor, CodForma, 0)
            End If
            'Cargamos la Linea Aerea
            CargaLineaAerea("")
            'Cargamos el Pasajero
            CargaPasajeros("")
            'Carga de la Grilla
            CargaBoletosPasajeros()
            'Cargo de Toda la data de DBanco
            CargaDataGeneral()
            CargaEstadoBoleto("VENDIDO")
            CargaTipoPasajero("Adulto")
            CargaPagoConRemision()
        End If
    End Sub
    Private Sub CargaPagoConRemision()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "BOL_PagoConRemision_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lbtPagoConRemision.Text = "Pago con Remisión " & ToString.Format("{0:###,###,###,##0.00}", dr.GetValue(dr.GetOrdinal("MontoRemision")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return
    End Sub

    Private Sub CargaEstadoBoleto(ByVal pestado As String)
        ddlEstadoBoleto.Items.FindByValue("STOCK").Selected = False
        ddlEstadoBoleto.Items.FindByValue("VENDIDO").Selected = False
        ddlEstadoBoleto.Items.FindByValue("VOID").Selected = False
        ddlEstadoBoleto.Items.FindByValue("DEVUELTO").Selected = False
        ddlEstadoBoleto.Items.FindByValue(pestado).Selected = True

    End Sub
    Private Sub CargaTipoPasajero(ByVal ptipo As String)

        ddlTipoPasajero.Items.FindByValue("Elegir Tipo").Selected = False
        ddlTipoPasajero.Items.FindByValue("Adulto").Selected = False
        ddlTipoPasajero.Items.FindByValue("Niño").Selected = False
        ddlTipoPasajero.Items.FindByValue("Infante").Selected = False
        ddlTipoPasajero.Items.FindByValue(ptipo).Selected = True
    End Sub
    Private Sub CargaProveedor(ByVal pcodProveedor As Integer)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_Proveedor_S"
        da.Fill(ds, "TipoDocumento")
        ddlProveedor.DataSource = ds.Tables("TipoDocumento")
        ddlProveedor.DataBind()

        If pcodProveedor > 0 Then
            ddlProveedor.Items.FindByValue(pcodProveedor).Selected = True
        End If

        If ddlProveedor.Items.Count > 0 Then
            txtProveedor.Text = ddlProveedor.SelectedItem.Value
        Else
            txtProveedor.Text = ""
        End If
        CargaForma(txtProveedor.Text, "")
    End Sub
    Private Sub CargaForma(ByVal pcodProveedor As Integer, ByVal pcodforma As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wpcodBanco As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BoletoCodForma_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pcodProveedor
        da.Fill(ds, "TBancoCuenta")
        ddlForma.DataSource = ds.Tables("TBancoCuenta")
        ddlForma.DataBind()

        If pcodforma.Trim.Length > 0 Then
            ddlForma.Items.FindByValue(pcodforma).Selected = True
        End If

        If ddlForma.Items.Count > 0 Then
            txtForma.Text = ddlForma.SelectedItem.Value
        Else
            txtForma.Text = ""
        End If

        CargaSerie(CInt(txtProveedor.Text), txtForma.Text, 0)

    End Sub
    Private Sub CargaSerie(ByVal pcodProveedor As Integer, ByVal pcodforma As String, ByVal pcodSerie As Integer)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wpcodBanco As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_BoletoSerie_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pcodProveedor
        da.SelectCommand.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = pcodforma
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        da.Fill(ds, "Serie")
        ddlSerie.DataSource = ds.Tables("Serie")
        ddlSerie.DataBind()

        If pcodSerie > 0 Then
            ddlSerie.Items.FindByValue(pcodSerie).Selected = True
        End If
        If ddlSerie.Items.Count > 0 Then
            txtSerie.Text = ddlSerie.SelectedItem.Value
        Else
            txtSerie.Text = ""
        End If
    End Sub
    Private Sub CargaLineaAerea(ByVal pcodlinea As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_LineaActivo_S"
        da.Fill(ds, "TLINEA")
        ddlLineaAerea.DataSource = ds.Tables("TLINEA")
        ddlLineaAerea.DataBind()
        ddlLineaAerea.Items.Insert(0, New ListItem("Elegir Linea"))
        If pcodlinea.Trim.Length > 0 Then
            ddlLineaAerea.Items.FindByValue(pcodlinea).Selected = True
        Else
            ddlLineaAerea.Items.FindByValue("Elegir Linea").Selected = True
        End If
    End Sub

    Private Sub CargaPasajeros(ByVal pcodPasajero As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim wpcodBanco As String

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_DPasajeroNroPedido_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.Fill(ds, "DPasajero")
        ddlPasajero.DataSource = ds.Tables("DPasajero")
        ddlPasajero.DataBind()

        If pcodPasajero.Trim.Length > 0 Then
            ddlPasajero.Items.FindByValue(pcodPasajero).Selected = True
        End If
    End Sub
    Private Sub CargaDataGeneral()
        Dim wForma, wTipoDocumento, wStsUbica As String
        Dim wSerie2, wCodProveedor As Integer
        
        Dim wformapago As Integer
        Dim wtipoboleto, wserie, westadoboleto, wnombre, wcodlineaA, wTipoPasajero As String
        Dim wExiste As Boolean

        wTipoDocumento = ""
        wTipoPasajero = ""
        wcodlineaA = ""
        westadoboleto = ""
        wForma = txtForma.Text
        wExiste = False
        'CodProveedor
        If txtProveedor.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtProveedor.Text) Then
                lblmsg.Text = "El Codigo Proveedor es un número"
                Return
            Else
                wCodProveedor = CInt(txtProveedor.Text)
            End If
        Else
            wCodProveedor = 0
        End If
        'Serie
        If txtSerie.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtSerie.Text) Then
                lblmsg.Text = "La serie es un número"
                Return
            Else
                wserie = CInt(txtSerie.Text)
            End If
        Else
            wserie = 0
        End If


        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "BOL_BoletoCupon_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = wCodProveedor
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = wForma
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = wserie
        cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = 0 'Boleto de 4 cupones
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wExiste = True

                If dr.GetValue(dr.GetOrdinal("StsUbica")) = "U" Then
                    txtporigv.Text = dr.GetValue(dr.GetOrdinal("PIGV"))
                    txtporcom1.Text = dr.GetValue(dr.GetOrdinal("PComision1"))
                    txtporcom2.Text = dr.GetValue(dr.GetOrdinal("PComision2"))
                Else
                    txtporigv.Text = Session("PIGV")
                    txtporcom1.Text = ViewState("Comision1")
                    txtporcom2.Text = ViewState("Comision2")
                End If
                txtFchEmision.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchEmision")))
                txtruta.Text = dr.GetValue(dr.GetOrdinal("Ruta"))
                txtobserv.Text = dr.GetValue(dr.GetOrdinal("Observacion"))
                txttarifa.Text = dr.GetValue(dr.GetOrdinal("Tarifa"))
                txtIGV.Text = dr.GetValue(dr.GetOrdinal("IGV"))
                txtotros.Text = dr.GetValue(dr.GetOrdinal("Impuesto"))
                txtcom1.Text = dr.GetValue(dr.GetOrdinal("Comision1"))
                txtcom2.Text = dr.GetValue(dr.GetOrdinal("Comision2"))
                wformapago = dr.GetValue(dr.GetOrdinal("FormaPago"))
                wnombre = dr.GetValue(dr.GetOrdinal("NomPasajero"))
                txtNomPasajero.Text = wnombre

                If wformapago = 1 Then
                    rbContado.Checked = True
                    rbCredito.Checked = False
                Else
                    If wformapago = 2 Then
                        rbContado.Checked = False
                        rbCredito.Checked = True
                    Else
                        rbContado.Checked = True
                        rbCredito.Checked = False

                    End If
                End If

                wtipoboleto = dr.GetValue(dr.GetOrdinal("TipoBoleto"))
                If Mid(wtipoboleto, 1, 1) = "P" Then
                    rbPrincipal.Checked = True
                    rbconexion.Checked = False
                Else
                    If Mid(wtipoboleto, 1, 1) = "C" Then
                        rbPrincipal.Checked = False
                        rbconexion.Checked = True
                    Else
                        rbPrincipal.Checked = True
                        rbconexion.Checked = False
                    End If

                End If

                westadoboleto = dr.GetValue(dr.GetOrdinal("StsBoleto"))
                wTipoPasajero = dr.GetValue(dr.GetOrdinal("TipoPasajero"))
                wcodlineaA = dr.GetValue(dr.GetOrdinal("CodLinea"))

                wTipoDocumento = dr.GetValue(dr.GetOrdinal("TipoDocumento"))
                wStsUbica = dr.GetValue(dr.GetOrdinal("StsUbica"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If wTipoPasajero = "A" Then
            wTipoPasajero = "Adulto"
        End If
        If wTipoPasajero = "N" Then
            wTipoPasajero = "Niño"
        End If
        If wTipoPasajero = "I" Then
            wTipoPasajero = "Infante"
        End If
        If wcodlineaA.Trim.Length = 0 Then
            wcodlineaA = "Elegir Linea"
        End If
        If wTipoPasajero.Trim.Length = 0 Then
            wTipoPasajero = "Elegir Tipo"
        End If

        If westadoboleto = "S" Or westadoboleto.Trim.Length = 0 Then
            westadoboleto = "STOCK"
        End If
        If westadoboleto = "V" Then
            westadoboleto = "VENDIDO"
        End If
        If westadoboleto = "O" Then
            westadoboleto = "VOID"
        End If
        If westadoboleto = "D" Then
            westadoboleto = "DEVUELTO"
        End If

        CargaTipoPasajero(wTipoPasajero)
        CargaLineaAerea(wcodlineaA)
        CargaEstadoBoleto(westadoboleto)

        If Not wExiste Then
            txtFchEmision.Text = ""
            txtruta.Text = ""
            txtobserv.Text = ""
            txttarifa.Text = ""
            txtIGV.Text = ""
            txtotros.Text = ""
            txtcom1.Text = ""
            txtcom2.Text = ""
            txtNomPasajero.Text = ""
            txtporigv.Text = Session("PIGV")
            txtporcom1.Text = ViewState("Comision1")
            txtporcom2.Text = ViewState("Comision2")
            rbContado.Checked = False
            rbCredito.Checked = False
            rbPrincipal.Checked = False
            rbconexion.Checked = False
            lblmsg.Text = "Este boleto no existe"
        End If

        cmdGrabar.Enabled = True
        If wStsUbica = "C" Then
            lblmsg.Text = "Boleto " & wserie.Trim & " esta en el Stock de Comprados"
            cmdGrabar.Enabled = False
        ElseIf wTipoDocumento = "RE" Then
            lblmsg.Text = "Boleto " & wserie.Trim & " fue reportado"
            cmdGrabar.Enabled = False
        End If
    End Sub
    Private Sub CargaBoletosPasajeros()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionBoletosVta_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        Dim ds As New DataSet
        dgPasajeros.DataKeyField = "keyReg"
        Dim nReg As Integer = da.Fill(ds, "Boleto")
        dgPasajeros.DataSource = ds.Tables("Boleto")
        dgPasajeros.DataBind()

        If Viewstate("StsVersion") = "A" Then
            dgPasajeros.Columns(9).Visible = False
        End If
    End Sub
    Private Sub dgPasajeros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPasajeros.SelectedIndexChanged
        Dim wCodProveedor, wcodlinea, wForma, wnompasajero As String
        Dim wSerie As Integer

        lblmsg.Text = ""
        wCodProveedor = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(11).Text
        wForma = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(3).Text
        wSerie = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(4).Text
        txtProveedor.Text = wCodProveedor
        txtForma.Text = wForma
        txtSerie.Text = wSerie

        wnompasajero = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(1).Text
        wcodlinea = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(2).Text

        txtNomPasajero.Text = wnompasajero

        'cargo de linea aere venta
        If ddlLineaAerea.Items.Count > 0 Then
            CargaLineaAerea(wcodlinea)
        End If

        CargaDataGeneral()
    End Sub
    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        Dim wCodLinea, wCodForma, wSerie As String

        lblmsg.Text = ""
        If ddlProveedor.Items.Count > 0 Then
            wCodLinea = ddlProveedor.SelectedItem.Value
            CargaForma(wCodLinea, "")
            txtProveedor.Text = wCodLinea
        End If

        CargaSerie(wCodLinea, txtForma.Text, 0)

        CargaDataGeneral()
    End Sub
    Private Sub ddlForma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlForma.SelectedIndexChanged
        Dim wCodLinea As String

        lblmsg.Text = ""
        'Cargamos la Serie
        If ddlForma.Items.Count > 0 Then
            wCodLinea = txtProveedor.Text
            txtForma.Text = ddlForma.SelectedItem.Value
            CargaSerie(wCodLinea, txtForma.Text, 0)
        End If

        CargaDataGeneral()
    End Sub
    Private Sub ddlSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSerie.SelectedIndexChanged
        If ddlSerie.Items.Count > 0 Then
            txtSerie.Text = ddlSerie.SelectedItem.Value
        End If
        lblmsg.Text = ""
        CargaDataGeneral()
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wtipobol, wlineaerea, wEboleto, wTPasajero As String
        Dim wformPago As Integer
        Dim wcom2, wcom1, wpcom2, wpcom1, wigv, wtarifa, wpigv, wotros As Double
        Dim wforma As String
        Dim wproveedor, wserie As Integer

        'Inicialisamos los Pk
        If txtForma.Text.Trim.Length > 0 Then
            wforma = txtForma.Text
        Else
            lblmsg.Text = "Ingrese la Forma"
            Return
        End If

        If txtProveedor.Text.Trim.Length = 0 Then
            wproveedor = 0
            lblmsg.Text = "Ingrese código proveedor"
            Return
        Else
            If (IsNumeric(txtProveedor.Text)) Then
                wproveedor = CDbl(txtProveedor.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en código proveedor"
                Return
            End If
        End If

        If txtSerie.Text.Trim.Length = 0 Then
            wserie = 0
            lblmsg.Text = "Ingrese Serie del Boleto"
            Return
        Else
            If (IsNumeric(txtSerie.Text)) Then
                wserie = CDbl(txtSerie.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en la serie"
                Return
            End If
        End If

        'Forma de Pago
        If rbContado.Checked Then
            wformPago = 1
        End If
        If rbCredito.Checked Then
            wformPago = 2
        End If

        'Tipo Boleto
        If rbPrincipal.Checked Then
            wtipobol = "P"
        End If
        If rbconexion.Checked Then
            wtipobol = "C"
        End If

        'Linea Aerea
        If ddlLineaAerea.Items.Count > 0 Then
            wlineaerea = ddlLineaAerea.SelectedItem.Value
        End If

        'Estado Boleto
        If ddlEstadoBoleto.SelectedItem.Value = "STOCK" Then
            wEboleto = "S"
        End If
        If ddlEstadoBoleto.SelectedItem.Value = "VENDIDO" Then
            wEboleto = "V"
        End If
        If ddlEstadoBoleto.SelectedItem.Value = "VOID" Then
            wEboleto = "O"
        End If
        If ddlEstadoBoleto.SelectedItem.Value = "DEVUELTO" Then
            wEboleto = "D"
        End If

        'Tipo Pasajero
        If ddlTipoPasajero.SelectedItem.Value = "Adulto" Then
            wTPasajero = "A"
        End If
        If ddlTipoPasajero.SelectedItem.Value = "Niño" Then
            wTPasajero = "N"
        End If
        If ddlTipoPasajero.SelectedItem.Value = "Infante" Then
            wTPasajero = "I"
        End If

        'Restricciones Segun las Condiciones

        If wtipobol = "C" Then
            If Len(Trim(txtruta.Text)) = 0 Then
                lblmsg.Text = "Ingrese la Ruta"
                Return
            End If
        End If

        'Valido Fecha Emisión
        If Len(Trim(txtFchEmision.Text)) = 0 Then
            lblmsg.Text = "Ingrese la Fecha de Emisión"
            Return
        End If
        'Valido Nombre Pasajero
        If Len(Trim(txtNomPasajero.Text)) = 0 Then
            lblmsg.Text = "Ingrese Nombre del Pasajero"
            Return
        End If
        'Valido Tipo Pasajero
        If Trim(ddlTipoPasajero.SelectedItem.Value) = "Elegir Tipo" Then
            lblmsg.Text = "Seleccione Tipo Pasajero"
            Return
        End If
        'Valido Línea Aerea
        If Trim(ddlLineaAerea.SelectedItem.Value) = "Elegir Linea" Then
            lblmsg.Text = "Seleccione Linea Aerea"
            Return
        End If
        'Valido Forma de Pago    
        If rbContado.Checked = False And rbCredito.Checked = False Then
            lblmsg.Text = "Seleccione Forma de Pago"
            Return
        End If
        'Valido Tipo Boleto
        If rbPrincipal.Checked = False And rbconexion.Checked = False Then
            lblmsg.Text = "Seleccione Tipo Boleto"
            Return
        End If

        'Verificamos las Tarifas

        'Tarifa
        If txttarifa.Text.Trim.Length = 0 Then
            wtarifa = 0
        Else
            If (IsNumeric(txttarifa.Text)) Then
                wtarifa = CDbl(txttarifa.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en Tarifa"
                Return
            End If
        End If

        'IGV
        If txtIGV.Text.Trim.Length = 0 Then
            wigv = 0
        Else
            If (IsNumeric(txtIGV.Text)) Then
                wigv = CDbl(txtIGV.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en IGV"
                Return
            End If
        End If

        '% Comisión 1
        If txtporcom1.Text.Trim.Length = 0 Then
            wpcom1 = 0
        Else
            If (IsNumeric(txtporcom1.Text)) Then
                wpcom1 = CDbl(txtporcom1.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en % comisión1"
                Return
            End If
        End If

        '% Comisión 2
        If txtporcom2.Text.Trim.Length = 0 Then
            wpcom2 = 0
        Else
            If (IsNumeric(txtporcom2.Text)) Then
                wpcom2 = CDbl(txtporcom2.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en % comisión2"
                Return
            End If
        End If

        'Comisión 1
        If txtcom1.Text.Trim.Length = 0 Then
            wcom1 = 0
        Else
            If (IsNumeric(txtcom1.Text)) Then
                wcom1 = CDbl(txtcom1.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en la comisión1"
                Return
            End If
        End If

        'Comision 2
        If txtcom2.Text.Trim.Length = 0 Then
            wcom2 = 0
        Else
            If (IsNumeric(txtcom2.Text)) Then
                wcom2 = CDbl(txtcom2.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en la comisión2"
                Return
            End If
        End If


        'Otros Impuestos
        If txtotros.Text.Trim.Length = 0 Then
            wotros = 0
        Else
            If (IsNumeric(txtotros.Text)) Then
                wotros = CDbl(txtotros.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en otros Impuestos"
                Return
            End If
        End If

        'Porcentaje de IGV
        If txtporigv.Text.Trim.Length = 0 Then
            wpigv = 0
        Else
            If (IsNumeric(txtporigv.Text)) Then
                wpigv = CDbl(txtporigv.Text)
            Else
                lblmsg.Text = "Ingrese un dato numérico en la comisión2"
                Return
            End If
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_Boleto_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor ", SqlDbType.Int).Value = wproveedor
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = wforma
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = wserie
        cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = 0 ' Boleto de 4 cupones
        cd.Parameters.Add("@StsUbica", SqlDbType.Char, 1).Value = "U"
        cd.Parameters.Add("@StsBoleto", SqlDbType.Char, 1).Value = wEboleto
        cd.Parameters.Add("@CodLinea", SqlDbType.Char, 3).Value = ddlLineaAerea.SelectedItem.Value
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        cd.Parameters.Add("@Tarifa", SqlDbType.Money).Value = wtarifa
        cd.Parameters.Add("@PIGV", SqlDbType.SmallMoney).Value = wpigv
        cd.Parameters.Add("@IGV", SqlDbType.Money).Value = wigv
        cd.Parameters.Add("@Impuesto", SqlDbType.Money).Value = wotros
        cd.Parameters.Add("@PComision1", SqlDbType.SmallMoney).Value = wpcom1
        cd.Parameters.Add("@PComision2", SqlDbType.SmallMoney).Value = wpcom2
        cd.Parameters.Add("@Comision1", SqlDbType.Money).Value = wcom1
        cd.Parameters.Add("@Comision2", SqlDbType.Money).Value = wcom2
        cd.Parameters.Add("@Ruta", SqlDbType.VarChar, 39).Value = txtruta.Text
        cd.Parameters.Add("@Observacion", SqlDbType.VarChar, 30).Value = txtobserv.Text
        cd.Parameters.Add("@NomPasajero", SqlDbType.VarChar, 30).Value = txtNomPasajero.Text
        cd.Parameters.Add("@TipoPasajero", SqlDbType.Char, 1).Value = wTPasajero
        cd.Parameters.Add("@FormaPago", SqlDbType.TinyInt).Value = wformPago
        cd.Parameters.Add("@TipoBoleto", SqlDbType.Char, 1).Value = wtipobol
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = ""
        cd.Parameters.Add("@NroDocumento", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblmsg.Text) = "OK" Then
            CargaBoletosPasajeros()
            CargaSerie(ddlProveedor.SelectedItem.Value, ddlForma.SelectedItem.Value, 0)
            lblmsg.Text = "Se Actualizo el Boleto"
        End If
    End Sub

    Private Sub dgPasajeros_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPasajeros.DeleteCommand
        Dim wcodproveedor As Integer = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 1, 8)
        Dim wforma As String = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 9, 4)
        Dim wserie As Integer = CInt(Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 13, 10))

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_DevolverStock_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor ", SqlDbType.Int).Value = wcodproveedor
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = wforma
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = wserie
        cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = 0 ' Boleto de 4 cupones
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If lblmsg.Text = "547" Then
                lblmsg.Text = "Mensaje: Si desea eliminar Pais, primero debe eliminar todos los Clientes asociados"
            End If
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblmsg.Text) = "OK" Then
            Me.CargaBoletosPasajeros()
            CargaSerie(ddlProveedor.SelectedItem.Value, ddlForma.SelectedItem.Value, 0)
            Me.CargaDataGeneral()
            lblmsg.Text = "El Boleto se Actualizo"
        End If
    End Sub
    Private Sub txtporigv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtporigv.TextChanged
        Dim wIGV As Double

        If IsNumeric(txtporigv.Text) And IsNumeric(txttarifa.Text) Then
            wIGV = (CDbl(txtporigv.Text) * CDbl(txttarifa.Text)) / 100
            txtIGV.Text = ToString.Format("{0:###,##0.00}", wIGV)
        Else
            txtIGV.Text = 0
        End If

    End Sub
    Private Sub txtporcom1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtporcom1.TextChanged
        Dim wc1 As Double
        If IsNumeric(txtporcom1.Text) And IsNumeric(txttarifa.Text) Then
            wc1 = (CDbl(txtporcom1.Text) * CDbl(txttarifa.Text)) / 100
            txtcom1.Text = ToString.Format("{0:###,##0.00}", wc1)
        Else
            txtporcom1.Text = 0
        End If

    End Sub
    Private Sub txtporcom2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtporcom2.TextChanged
        Dim wc2 As Double
        If IsNumeric(txtporcom2.Text) And IsNumeric(txttarifa.Text) Then
            wc2 = (CDbl(txtporcom2.Text) * CDbl(txttarifa.Text)) / 100
            txtcom2.Text = ToString.Format("{0:###,##0.00}", wc2)
        Else
            txtporcom2.Text = 0
        End If

    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        lblmsg.Text = ""
        CargaDataGeneral()
    End Sub
    Private Sub txttarifa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttarifa.TextChanged
        Dim wIGV, wc1, wc2 As Double

        If IsNumeric(txttarifa.Text) Then
            If IsNumeric(txtporigv.Text) Then
                wIGV = (CDbl(txtporigv.Text) * CDbl(txttarifa.Text)) / 100
                txtIGV.Text = ToString.Format("{0:###,##0.00}", wIGV)
            End If
            If IsNumeric(txtporcom1.Text) Then
                wc1 = (CDbl(txtporcom1.Text) * CDbl(txttarifa.Text)) / 100
                txtcom1.Text = ToString.Format("{0:###,##0.00}", wc1)
            End If
            If IsNumeric(txtporcom2.Text) Then
                wc2 = (CDbl(txtporcom2.Text) * CDbl(txttarifa.Text)) / 100
                txtcom2.Text = ToString.Format("{0:###,##0.00}", wc2)
            End If
        End If
    End Sub
    Private Sub ddlPasajero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPasajero.SelectedIndexChanged
        txtNomPasajero.Text = ddlPasajero.SelectedItem.Value
    End Sub
    Private Sub ddlEstadoBoleto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEstadoBoleto.SelectedIndexChanged
        Dim wEstado As String

        If ddlEstadoBoleto.Items.Count > 0 Then
            wEstado = ddlEstadoBoleto.SelectedItem.Value
            If Trim(wEstado) = "VOID" Then

                txtporigv.Text = ""
                txtporcom1.Text = ""
                txtporcom2.Text = ""
                txtFchEmision.Text = ""
                txtruta.Text = ""
                txtobserv.Text = "VOID"
                txttarifa.Text = ""
                txtIGV.Text = ""
                txtotros.Text = ""
                txtcom1.Text = ""
                txtcom2.Text = ""
                txtNomPasajero.Text = ""
                txtporigv.Text = Session("PIGV")
                txtporcom1.Text = Viewstate("Comision1")
                txtporcom2.Text = Viewstate("Comision2")
                '  rbContado.Checked = False
                rbCredito.Checked = False
                ' rbPrincipal.Checked = False
                rbconexion.Checked = False
            End If
        End If

    End Sub

    Private Sub dgPasajeros_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPasajeros.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "Comprado" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub lbtPagoConRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPagoConRemision.Click
        Response.Redirect("VtaCuadreAereoDet.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub lbkStkComprados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbkStkComprados.Click
        Response.Redirect("vtaVersionBoletoVtaStk.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion") & _
        "&CodCliente=" & Viewstate("CodCliente") & _
        "&StsVersion=" & Viewstate("StsVersion"))
    End Sub


End Class
