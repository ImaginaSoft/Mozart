Imports cmpNegocio
Imports cmpRutinas
Imports cmpTabla
Imports cmpSeguridad
Imports System.Windows.Forms
Imports System.IO
Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data

Partial Class VtaServicioNuevo
    Inherits System.Web.UI.Page
    Dim objServicio As New clsServicio
    Dim objRutina As New clsRutinas
    Dim gg As String
    Dim gg2 As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim objAutoriza As New clsAutoriza
            If objAutoriza.AccesoOk(Session("CodPerfil"), "GPT030505") = "X" Then
                cmbGrabar.Visible = True
            End If

            CargaTipoServicio()
            CargaCiudad()
            CargarGrid()

            ViewState("Opcion") = Request.Params("Opcion")
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            ViewState("CodCiudad") = Request.Params("CodCiudad")
            ViewState("CodTipoServicio") = Request.Params("CodTipoServicio")

            rbActivo.Checked = True
            If ViewState("Opcion") = "Modificar" Then
                ViewState("NroServicio") = Request.Params("NroServicio")
                lblTitulo.Text = "Modificar Servicio Nro. " & CStr(ViewState("NroServicio"))
                ModificaServicio()
                ddlProveedor.Enabled = False
                'ddlCiudad.Enabled = False
                'ddltiposervicio.Enabled = False
            Else
                lblTitulo.Text = "Nuevo Servicio"
                CargaProveedor()
            End If
        End If

    End Sub


    'Private Sub CargarGrid()
    '    Dim ds As New DataSet
    '    ds = objServicio.CargaImg2("10445")
    '    'Dim base64String As String = Convert.ToBase64String(ds.i, 0, servicio.Imagen.Length)
    'End Sub





    Private Sub CargarGrid()
        Dim ListaIMG As List(Of clsServicio) = clsServicio.CargaImg("21111")

        Dim Items As clsServicio

        Dim ColImage As New DataGridViewImageColumn

        Dim tabla As New DataTable

        tabla.Columns.Add(New DataColumn("Img"))

        For Each Items In ListaIMG
            ColImage = New DataGridViewImageColumn
            ColImage.HeaderText = "Img"
            ColImage.ImageLayout = DataGridViewImageCellLayout.Stretch
            ColImage.Image = clsServicio.ConvertirImagen(Items.Imagen3)

            fotox.ImageUrl = "data:image/jpeg;base64," & clsServicio.ConvertirImagen1(Items.Imagen3)

            tabla.Rows.Add(ColImage)
        Next


        dlgImg.DataSource = tabla
        dlgImg.DataBind()
    End Sub



    Protected Sub dlgImg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlgImg.Load

    End Sub

    Private Sub CargaProveedor()
        Dim objProveedor As New clsProveedor
        ddlProveedor.DataSource = objProveedor.CargarActivoDDL
        ddlProveedor.DataBind()
        Try
            ddlProveedor.Items.FindByValue(ViewState("CodProveedor")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaCiudad()
        Dim objCiudad As New clsCiudad
        ddlCiudad.DataSource = objCiudad.CargarActivo
        ddlCiudad.DataBind()
        Try
            ddlCiudad.Items.FindByValue(ViewState("CodCiudad")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaTipoServicio()
        Dim objTipoServicio As New clsTipoServicio
        ddltiposervicio.DataSource = objTipoServicio.CargarActivo
        ddltiposervicio.DataBind()
        Try
            ddltiposervicio.Items.FindByValue(ViewState("CodTipoServicio")).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub ModificaServicio()
        lblMsg.Text = objServicio.Editar(ViewState("NroServicio"), "")
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            'lblfchPedido.Text = ToString.Format("{0:dd-MM-yyyy}", objPedido.FchPedido)


            If objServicio.DesProveedor IsNot Nothing Then
                txtDesProveedor.Text = objServicio.DesProveedor.Trim

            End If

            If objServicio.DesObservacion IsNot Nothing Then
                TxtObservaciones.Text = objServicio.DesObservacion.Trim
            End If

            'TxtObservaciones.Text = objServicio.DesObservacion.Trim

            txtCodStsReserva.Text = objServicio.CodStsReservaIni.Trim

            'txtMontoFijo.Enabled = False
            If objServicio.FlagValoriza = "C" Then
                rbtPasajero.Checked = True ' P=Tarifa Neta x Cantidad de Pasajeros
            ElseIf objServicio.FlagValoriza = "T" Then
                rbtTipoHabPasajero.Checked = True 'T=Tarifa Neta de TipoHabTipoPasajero x Cantidad de Pasajeros
            ElseIf objServicio.FlagValoriza = "M" Then
                'txtMontoFijo.Enabled = True
                rbtMonto.Checked = True 'M=Asigna Monto Fijo
                txtMontoFijo.Text = objServicio.MontoFijo
            ElseIf objServicio.FlagValoriza = "A" Then
                rbtAjuste.Checked = True 'A=Ajuste a la utilidad
            ElseIf objServicio.FlagValoriza = "P" Then
                'txtPorcen.Enabled = True
                rbtPorcen.Checked = True 'P=Porcentaje
                txtPorcen.Text = objServicio.MontoFijo
            End If

            If objServicio.FlagItinerario = "S" Then
                rbtSI.Checked = True ' S=Si muestra en itinerario cliente
            Else
                rbtNo.Checked = True ' N=No muestra en itinerario cliente
            End If

            If objServicio.FlagItiProveedor = "S" Then
                rbtSIP.Checked = True ' S=Si muestra en itinerario proveedor
            Else
                rbtNOP.Checked = True ' N=No muestra en itinerario proveedor
            End If

            If objServicio.StsServicio = "A" Then
                rbActivo.Checked = True
            Else
                rbInactivo.Checked = True
            End If

            If objServicio.FlagPrecio = "S" Then
                rbtFlagPrecioSI.Checked = True ' S=Al momento de cotizar precio obligatorio
            Else
                rbtFlagPrecioNO.Checked = True ' N=Precio no obligatorio
            End If

            If objServicio.TipoRecorrido = "C" Then
                rbtTipoRecorridoCorto.Checked = True
            ElseIf objServicio.TipoRecorrido = "L" Then
                rbtTipoRecorridoLargo.Checked = True
            Else 'N=No Aplica
                rbtTipoRecorridoNO.Checked = True
            End If

            If objServicio.FlagDesayuno = "S" Then
                chkDesayuno.Checked = True
            End If

            If objServicio.FlagAlmuerzo = "S" Then
                chkAlmuerzo.Checked = True
            End If

            If objServicio.FlagCena = "S" Then
                chkCena.Checked = True
            End If

            If objServicio.FlagBoxLunch = "S" Then

                chkBoxL.Checked = True

            End If

            If objServicio.FlagBoxBreakfast = "S" Then

                chkBoxB.Checked = True

            End If

            If objServicio.FlagPicnic = "S" Then

                chkPicnic.Checked = True

            End If

            If objServicio.FlagServicioAge = "S" Then
                CheckBoxFlagServicioAge.Checked = True
            End If

            txtCaraEspeServicio.Text = objServicio.CaraEspeServicio.Trim
            txtCaraEspeServicio2.Text = objServicio.CaraEspeServicio2.Trim
            txtCaraEspeServicio3.Text = objServicio.CaraEspeServicio3.Trim
            txtHoraInicioReserva.Text = objServicio.HoraInicioServicio.Trim

            txtDireccion.Text = objServicio.DireccionHTL.Trim
            txtTelefono.Text = objServicio.Telefono.Trim

            txtNombreHTL.Text = objServicio.NombreHTL.Trim

            'If objServicio.Imagen IsNot Nothing Then
            '    txtImagen01.Text = objServicio.Imagen
            'End If

            'If objServicio.Imagen IsNot Nothing Then
            '    txtImagen02.Text = objServicio.Imagen2.ToString
            'End If

            'If objServicio.Imagen IsNot Nothing Then
            '    txtImagen03.Text = objServicio.Imagen3.ToString
            'End If

            ddlValor.Text = objServicio.Valoracion.Trim

            Dim objProveedor As New clsProveedor
            ddlProveedor.DataSource = objProveedor.CargarProveedor(objServicio.CodProveedor)
            ddlProveedor.DataBind()

            Try
                ddltiposervicio.Items.FindByValue(objServicio.CodTipoServicio).Selected = True
            Catch ex As Exception
                lblMsg.Text = "Tipo servicio inactivo"
            End Try

            Try
                ddlCiudad.Items.FindByValue(objServicio.CodCiudad).Selected = True
            Catch ex As Exception
                lblMsg.Text = "Ciudad inactivo"
            End Try
        End If
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If txtDesProveedor.Text.Trim.Length = 0 Then
            lblMsg.Text = "Descripcion servicio proveedor es obligatorio"
            Return
        End If

        If txtCodStsReserva.Text.Trim.Length <> 0 And txtCodStsReserva.Text.Trim <> "RQ" Then
            lblMsg.Text = "Solicitar reserva status en RQ o blanco"
            Return
        End If

        Dim wNroServicio As Integer
        If ViewState("Opcion") = "Modificar" Then
            objServicio.NroServicio = ViewState("NroServicio")
        Else
            objServicio.NroServicio = 0
        End If

        If rbActivo.Checked Then
            objServicio.StsServicio = "A"
        Else
            objServicio.StsServicio = "I"
        End If

        objServicio.MontoFijo = 0
        If rbtPasajero.Checked Then
            objServicio.FlagValoriza = "C" ' Cantidad Pasajeros/Tipo Habitación
        ElseIf rbtTipoHabPasajero.Checked Then
            objServicio.FlagValoriza = "T" ' Cantidad TipoHabitacion-TipoPasajero
        ElseIf rbtMonto.Checked Then
            objServicio.FlagValoriza = "M" ' Monto Fijo
            If IsNumeric(txtMontoFijo.Text) Then
                objServicio.MontoFijo = txtMontoFijo.Text
            End If
        ElseIf rbtPorcen.Checked Then
            objServicio.FlagValoriza = "P" ' Porcentaje de la venta total
            If IsNumeric(txtPorcen.Text) Then
                objServicio.MontoFijo = txtPorcen.Text
            End If
        Else
            objServicio.FlagValoriza = "A" 'Ajuste Utilidad
        End If

        If rbtTipoRecorridoNO.Checked Then
            objServicio.TipoRecorrido = "N" ' No es servicio transporte
        ElseIf rbtTipoRecorridoLargo.Checked Then
            objServicio.TipoRecorrido = "L" ' Recorrido Largo (avion, bus,barco,etc)
        Else
            objServicio.TipoRecorrido = "C" ' Recorrido Corto (taxi,etc)
        End If

        objServicio.FlagDesayuno = " "
        If chkDesayuno.Checked Then
            objServicio.FlagDesayuno = "S" ' Servicio incluye desayuno
        End If

        objServicio.FlagAlmuerzo = " "
        If chkAlmuerzo.Checked Then
            objServicio.FlagAlmuerzo = "S" ' Servicio incluye almuerzo
        End If

        objServicio.FlagCena = " "
        If chkCena.Checked Then
            objServicio.FlagCena = "S" ' Servicio incluye cena
        End If

        objServicio.FlagBoxLunch = ""
        If chkBoxL.Checked Then

            objServicio.FlagBoxLunch = "S"

        End If


        objServicio.FlagBoxBreakfast = ""
        If chkBoxB.Checked Then

            objServicio.FlagBoxBreakfast = "S"

        End If

        objServicio.FlagPicnic = ""
        If chkPicnic.Checked Then

            objServicio.FlagPicnic = "S"

        End If


        If btnImportar.HasFile Then
            Using reader As New BinaryReader(btnImportar.PostedFile.InputStream)
                Dim image As Byte() = reader.ReadBytes(btnImportar.PostedFile.ContentLength)
                objServicio.Imagen = image
                objServicio.FlagImg01 = 1
            End Using

        Else

            objServicio.Imagen = Nothing
            objServicio.FlagImg01 = Nothing

        End If


        If btnImportar2.HasFile Then
            Using reader2 As New BinaryReader(btnImportar2.PostedFile.InputStream)
                Dim image2 As Byte() = reader2.ReadBytes(btnImportar2.PostedFile.ContentLength)
                objServicio.Imagen2 = image2
                objServicio.FlagImg02 = ""
            End Using

        Else

            objServicio.Imagen2 = Nothing
            objServicio.FlagImg02 = ""

        End If


        If btnImportar3.HasFile Then
            Using reader3 As New BinaryReader(btnImportar3.PostedFile.InputStream)
                Dim image3 As Byte() = reader3.ReadBytes(btnImportar3.PostedFile.ContentLength)
                objServicio.Imagen3 = image3
                objServicio.FlagImg03 = 1
            End Using

        Else

            objServicio.Imagen3 = Nothing
            objServicio.FlagImg03 = ""

        End If


        objServicio.FlagServicioAge = ""
        If CheckBoxFlagServicioAge.Checked Then
            objServicio.FlagServicioAge = "S"
        End If


        objServicio.CodProveedor = ddlProveedor.SelectedItem.Value
        objServicio.CodCiudad = ddlCiudad.SelectedItem.Value
        objServicio.CodTipoServicio = ddltiposervicio.SelectedItem.Value
        objServicio.DesProveedor = txtDesProveedor.Text
        objServicio.DesObservacion = TxtObservaciones.Text
        objServicio.FlagItinerario = objRutina.SINO(rbtSI.Checked)
        objServicio.FlagItiProveedor = objRutina.SINO(rbtSIP.Checked)
        objServicio.FlagPrecio = objRutina.SINO(rbtFlagPrecioSI.Checked)
        objServicio.CodStsReservaIni = txtCodStsReserva.Text
        objServicio.CaraEspeServicio = txtCaraEspeServicio.Text
        objServicio.CaraEspeServicio2 = txtCaraEspeServicio2.Text
        objServicio.CaraEspeServicio3 = txtCaraEspeServicio3.Text
        objServicio.HoraInicioServicio = txtHoraInicioReserva.Text
        objServicio.CodUsuario = Session("CodUsuario")

        'objServicio.Estrella1 = objRutina.SINO(chkEstrella1.Checked)
        'objServicio.Estrella2 = objRutina.SINO(chkEstrella2.Checked)
        'objServicio.Estrella3 = objRutina.SINO(chkEstrella3.Checked)
        'objServicio.Estrella4 = objRutina.SINO(chkEstrella4.Checked)
        'objServicio.Estrella5 = objRutina.SINO(chkEstrella5.Checked)

        objServicio.DireccionHTL = txtDireccion.Text
        objServicio.Telefono = txtTelefono.Text


        objServicio.Valoracion = ddlValor.Text
        objServicio.NombreHTL = txtNombreHTL.Text

        lblMsg.Text = objServicio.Grabar
        If Mid(lblMsg.Text.Trim, 1, 2) = "OK" Then
            Response.Redirect("VtaServicioBusca.aspx" & _
                "?Opcion=" & "NuevoServicio" & _
                "&NroServicio=" & Mid(lblMsg.Text.Trim, 3, 10) & _
                "&CodProveedor=" & ddlProveedor.SelectedItem.Value & _
                "&CodCiudad=" & ddlCiudad.SelectedItem.Value & _
                "&CodTipoServicio=" & ddltiposervicio.SelectedItem.Value)
        End If


    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInactivo.CheckedChanged
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbtPasajero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPasajero.CheckedChanged
        'rbtMonto.Checked = False
        'rbtPasajero.Checked = True
        'rbtTipoHabPasajero.Checked = False
        'rbtAjuste.Checked = False
        'txtMontoFijo.Text = " "
        'txtMontoFijo.Enabled = False
        'txtPorcen.Text = " "
        'txtPorcen.Enabled = False
    End Sub

    Private Sub rbtMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMonto.CheckedChanged
        'rbtMonto.Checked = True
        'txtMontoFijo.Enabled = True
        'rbtPasajero.Checked = False
        'rbtTipoHabPasajero.Checked = False
        'rbtAjuste.Checked = False
    End Sub

    Private Sub rbtSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSI.CheckedChanged
        rbtSI.Checked = True
        rbtNo.Checked = False
    End Sub

    Private Sub rbtNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNo.CheckedChanged
        rbtSI.Checked = False
        rbtNo.Checked = True
    End Sub

    Private Sub rbtAjuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAjuste.CheckedChanged
        'rbtMonto.Checked = False
        'rbtPasajero.Checked = False
        'rbtTipoHabPasajero.Checked = False
        'rbtAjuste.Checked = True
        'txtMontoFijo.Text = " "
        'txtMontoFijo.Enabled = False
        'txtPorcen.Text = " "
        'txtPorcen.Enabled = False
    End Sub

    Private Sub lbtDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Modifica detalle en español
        Response.Redirect("VtaServicioDet.aspx" & _
                           "?NroServicio=" & ViewState("NroServicio") & _
                            "&CodProveedor=" & ViewState("CodProveedor") & _
                            "&CodCiudad=" & ViewState("CodCiudad") & _
                            "&CodTipoServicio=" & ViewState("CodTipoServicio"))
    End Sub


    Private Sub rbtTipoRecorridoNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoRecorridoNO.CheckedChanged
        rbtTipoRecorridoNO.Checked = True
        rbtTipoRecorridoLargo.Checked = False
        rbtTipoRecorridoCorto.Checked = False
    End Sub

    Private Sub rbtTipoRecorridoLargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbtTipoRecorridoNO.Checked = False
        rbtTipoRecorridoLargo.Checked = True
        rbtTipoRecorridoCorto.Checked = False

    End Sub

    Private Sub rbtTipoRecorridoCorto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbtTipoRecorridoNO.Checked = False
        rbtTipoRecorridoLargo.Checked = False
        rbtTipoRecorridoCorto.Checked = True
    End Sub

    Private Sub lbtCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCopia.Click
        Response.Redirect("VtaServicioCopia.aspx" & _
                           "?NroServicio=" & ViewState("NroServicio") & _
                            "&TipoServicio=" & ddltiposervicio.SelectedItem.Text & _
                            "&DesProveedor=" & txtDesProveedor.Text & _
                            "&CodProveedor=" & ddlProveedor.SelectedItem.Value & _
                            "&CodCiudad=" & ddlCiudad.SelectedItem.Value & _
                            "&CodTipoServicio=" & ddltiposervicio.SelectedItem.Value)
    End Sub

    Private Sub rbtTipoHabPasajero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoHabPasajero.CheckedChanged
        'rbtMonto.Checked = False
        'rbtPasajero.Checked = False
        'rbtTipoHabPasajero.Checked = True
        'rbtAjuste.Checked = False
        'txtMontoFijo.Text = " "
        'txtMontoFijo.Enabled = False
        'txtPorcen.Text = " "
        'txtPorcen.Enabled = False
    End Sub

    Private Sub rbtPorcen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPorcen.CheckedChanged
        'txtMontoFijo.Enabled = False
        'txtMontoFijo.Text = " "
        'txtMontoFijo.Enabled = False
    End Sub
End Class
