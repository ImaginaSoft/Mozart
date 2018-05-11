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
Partial Class vtaVersionBoletoVtaStk
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim CodForma As String
            Dim CodProveedor As Integer = 94 'Proveedor BSP Default

            'Recepción de Parametros
            ViewState("CodCliente") = Request.Params("CodCliente")
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            ViewState("StsVersion") = Request.Params("StsVersion")

            txtporigv.Text = Session("PIGV")
            txtporcom1.Text = objRutina.LeeParametroNumero("PComision1")
            txtporcom2.Text = objRutina.LeeParametroNumero("PComision2")

            'Tipo Pasajero
            CargaProveedor(CodProveedor)

            CargaLineaAerea("")
            CargaBoletosPasajeros()
            '            EditaBoleto()
            CargaTipoPasajero("Adulto")
        End If
    End Sub

    Private Sub CargaTipoPasajero(ByVal ptipo As String)
        ddlTipoPasajero.Items.Clear()
        ddlTipoPasajero.Items.Insert(0, New ListItem("Elegir Tipo"))
        ddlTipoPasajero.Items.Insert(1, New ListItem("Adulto"))
        ddlTipoPasajero.Items.Insert(2, New ListItem("Niño"))
        ddlTipoPasajero.Items.Insert(3, New ListItem("Infante"))

        '        ddlTipoPasajero.Items.FindByValue("Elegir Tipo").Selected = False
        '       ddlTipoPasajero.Items.FindByValue("Adulto").Selected = False
        '      ddlTipoPasajero.Items.FindByValue("Niño").Selected = False
        '     ddlTipoPasajero.Items.FindByValue("Infante").Selected = False

        If ptipo <> " " Then
            ddlTipoPasajero.Items.FindByValue(ptipo).Selected = True
        End If

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
    End Sub
    Private Sub CargaLineaAerea(ByVal pcodlinea As String)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
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

    Private Sub EditaBoleto()
        Dim wForma, wTipoDocumento, wStsUbica As String
        Dim wCodProveedor, wserie, wcupon As Integer
        Dim wformapago As Integer
        Dim wtipoboleto, westadoboleto, wnombre, wcodlineaA, wTipoPasajero As String
        Dim wExiste As Boolean

        wTipoDocumento = ""
        wTipoPasajero = ""
        wcodlineaA = ""
        westadoboleto = ""
        wForma = txtForma.Text
        wExiste = False


        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "BOL_BoletoCupon_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = ddlProveedor.SelectedItem.Value
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = txtForma.Text
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = txtSerie.Text
        cd.Parameters.Add("@Cupon", SqlDbType.TinyInt).Value = txtCupon.Text
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
                ElseIf wformapago = 2 Then
                    rbContado.Checked = False
                    rbCredito.Checked = True
                Else
                    rbContado.Checked = True
                    rbCredito.Checked = False
                End If

                wtipoboleto = dr.GetValue(dr.GetOrdinal("TipoBoleto"))
                If Mid(wtipoboleto, 1, 1) = "P" Then
                    rbPrincipal.Checked = True
                    rbconexion.Checked = False
                ElseIf Mid(wtipoboleto, 1, 1) = "C" Then
                    rbPrincipal.Checked = False
                    rbconexion.Checked = True
                Else
                    rbPrincipal.Checked = True
                    rbconexion.Checked = False
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

        CargaTipoPasajero(wTipoPasajero)
        CargaLineaAerea(wcodlineaA)

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
        End If

        'cmdGrabar.Enabled = True
        '        If wStsUbica = "C" Then
        '       lblmsg.Text = "Boleto " & wserie.Trim & " esta en el Stock de Comprados"
        '      cmdGrabar.Enabled = False
        '     ElseIf wTipoDocumento = "RE" Then
        '        lblmsg.Text = "Boleto " & wserie.Trim & " fue reportado"
        '       cmdGrabar.Enabled = False
        '  End If
    End Sub
    Private Sub CargaBoletosPasajeros()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionBoletosVtaStk_S"
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
        lblmsg.Text = ""
        CargaProveedor(dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(11).Text)
        txtForma.Text = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(3).Text
        txtSerie.Text = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(4).Text
        txtCupon.Text = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(5).Text
        txtNomPasajero.Text = dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(1).Text

        EditaBoleto()

        If ddlLineaAerea.Items.Count > 0 Then
            CargaLineaAerea(dgPasajeros.Items(dgPasajeros.SelectedIndex).Cells(2).Text)
        End If

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wtipobol, wTPasajero As String
        Dim wformPago As Integer
        Dim wcom2, wcom1, wpcom2, wpcom1, wigv, wtarifa, wpigv, wotros As Double

        If ddlProveedor.Items.Count = 0 Then
            lblmsg.Text = "Proveedor es obligatorio"
            Return
        End If
        If txtForma.Text.Trim.Length = 0 Then
            lblmsg.Text = "Forma es obligatorio"
            Return
        End If
        If txtSerie.Text.Trim.Length = 0 Then
            lblmsg.Text = "Serie es obligatorio"
            Return
        ElseIf (Not IsNumeric(txtSerie.Text)) Then
            lblmsg.Text = "Serie es dato númerico"
            Return
        End If

        If txtCupon.Text.Trim.Length = 0 Then
            lblmsg.Text = "Nro Cupon es obligatorio"
            Return
        ElseIf (Not IsNumeric(txtCupon.Text)) Then
            lblmsg.Text = "Nro Cupon es númerico"
            Return
        End If

        'Forma de Pago
        If rbContado.Checked Then
            wformPago = 1
        ElseIf rbCredito.Checked Then
            wformPago = 2
        End If

        'Tipo Boleto
        If rbPrincipal.Checked Then
            wtipobol = "P"
        ElseIf rbconexion.Checked Then
            wtipobol = "C"
        End If

        'Linea Aerea
        If ddlLineaAerea.Items.Count = 0 Then
            lblmsg.Text = "Linea Aérea es obligatorio"
            Return
        End If

        'Tipo Pasajero
        If ddlTipoPasajero.SelectedItem.Value = "Adulto" Then
            wTPasajero = "A"
        ElseIf ddlTipoPasajero.SelectedItem.Value = "Niño" Then
            wTPasajero = "N"
        ElseIf ddlTipoPasajero.SelectedItem.Value = "Infante" Then
            wTPasajero = "I"
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
        ElseIf (IsNumeric(txttarifa.Text)) Then
            wtarifa = CDbl(txttarifa.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en Tarifa"
            Return
        End If

        'IGV
        If txtIGV.Text.Trim.Length = 0 Then
            wigv = 0
        ElseIf (IsNumeric(txtIGV.Text)) Then
            wigv = CDbl(txtIGV.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en IGV"
            Return
        End If

        '% Comisión 1
        If txtporcom1.Text.Trim.Length = 0 Then
            wpcom1 = 0
        ElseIf (IsNumeric(txtporcom1.Text)) Then
            wpcom1 = CDbl(txtporcom1.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en % comisión1"
            Return
        End If

        '% Comisión 2
        If txtporcom2.Text.Trim.Length = 0 Then
            wpcom2 = 0
        ElseIf (IsNumeric(txtporcom2.Text)) Then
            wpcom2 = CDbl(txtporcom2.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en % comisión2"
            Return
        End If

        'Comisión 1
        If txtcom1.Text.Trim.Length = 0 Then
            wcom1 = 0
        ElseIf (IsNumeric(txtcom1.Text)) Then
            wcom1 = CDbl(txtcom1.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en la comisión1"
            Return
        End If

        'Comision 2
        If txtcom2.Text.Trim.Length = 0 Then
            wcom2 = 0
        ElseIf (IsNumeric(txtcom2.Text)) Then
            wcom2 = CDbl(txtcom2.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en la comisión2"
            Return
        End If

        'Otros Impuestos
        If txtotros.Text.Trim.Length = 0 Then
            wotros = 0
        ElseIf (IsNumeric(txtotros.Text)) Then
            wotros = CDbl(txtotros.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en otros Impuestos"
            Return
        End If

        'Porcentaje de IGV
        If txtporigv.Text.Trim.Length = 0 Then
            wpigv = 0
        ElseIf (IsNumeric(txtporigv.Text)) Then
            wpigv = CDbl(txtporigv.Text)
        Else
            lblmsg.Text = "Ingrese un dato numérico en la comisión2"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BOL_Boleto_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor ", SqlDbType.Int).Value = ddlProveedor.SelectedItem.Value
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = txtForma.Text
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = txtSerie.Text
        cd.Parameters.Add("@Cupon", SqlDbType.Int).Value = txtCupon.Text
        cd.Parameters.Add("@StsUbica", SqlDbType.Char, 1).Value = "C"  'Stock Comprados
        cd.Parameters.Add("@StsBoleto", SqlDbType.Char, 1).Value = "V" 'Vendido
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
        End If
    End Sub

    Private Sub dgPasajeros_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPasajeros.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionBoletosVtaStk_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor ", SqlDbType.Int).Value = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 1, 8)
        cd.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 9, 4)
        cd.Parameters.Add("@Serie", SqlDbType.Int).Value = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 13, 10)
        cd.Parameters.Add("@Cupon", SqlDbType.Int).Value = Mid(dgPasajeros.DataKeys(e.Item.ItemIndex).ToString, 23, 1)
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

    Private Sub dgPasajeros_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPasajeros.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "Comprado" Then
                e.Item.ForeColor = Color.Red
            End If
        End If
    End Sub


End Class
