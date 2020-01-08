Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpTabla

Partial Class cpcClienteNuevoP
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim Rutina As New cmpRutinas.clsRutinas
    Dim objPais As New clsPais
    Dim objVendedor As New clsVendedor
    Dim objPlanTarifario As New clsPlanTarifario
    Dim objTablaElemento As New clsTablaElemento

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")


            If ViewState("Opcion") = "N" Then
                cmdEliminar.Visible = False
                cmdGrabar.Visible = True
                lblTitulo.Text = "Nuevo Cliente"
                lblFchsys.Text = " "

                rbingles.Checked = True
                rbtPersona.Checked = True
                rbprivado.Checked = True
                rbe.Checked = True
                CargaPais("")
                CargaVendedor("")
                CargaPlanTarifario(0)
                CargaRangoEdad(0)
            End If
            If Viewstate("Opcion") = "A" Then
                lblTitulo.Text = "Actualizar Cliente"
                Viewstate("CodCliente") = Request.Params("CodCliente")
                cmdEliminar.Visible = False
                cmdGrabar.Visible = True
                CargaDatos()
            End If
            If Viewstate("Opcion") = "E" Then
                lblTitulo.Text = "Eliminar Cliente"
                Viewstate("CodCliente") = Request.Params("CodCliente")
                cmdEliminar.Visible = True
                cmdGrabar.Visible = False
                CargaDatos()
            End If
        End If
    End Sub

    Private Sub CargaRangoEdad(ByVal pCodRangoEdad As Integer)
        'Dim ds As New DataSet
        'ds = objTablaElemento.CargaTablaEleNumxNroOrden(20, "E")
        ddlRangoEdad.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(20, "E")
        ddlRangoEdad.DataBind()
        Try
            ddlRangoEdad.Items.FindByValue(pCodRangoEdad).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaPais(ByVal pCodPais As String)
        ddlpais.DataSource = objPais.CargarActivo
        ddlpais.DataBind()
        Try
            ddlpais.Items.FindByValue(pCodPais).Selected = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargaVendedor(ByVal pCodVendedor As String)
        ddlVendedor.DataSource = objVendedor.CargarActivo
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem(" "))
        Try
            ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargaPlanTarifario(ByVal pCodPlanTarifario As Integer)
        ddlPlanTarifario.DataSource = objPlanTarifario.CargaDDL(pCodPlanTarifario)
        ddlPlanTarifario.DataBind()
        ddlPlanTarifario.Items.Insert(0, New ListItem(" "))
        Try
            ddlPlanTarifario.Items.FindByValue(pCodPlanTarifario).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim wEstado As String
        Dim wtipotour, wcodpais, sCodVendedor, wfecha, wpreferencia As String
        Dim iCodPlanTarifario As Integer
        Dim iCodRangoEdad As Integer

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpc_ClienteCodCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = CInt(ViewState("CodCliente"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtnombre.Text = RTrim(dr.GetValue(dr.GetOrdinal("Nombre")))
                txtpaterno.Text = RTrim(dr.GetValue(dr.GetOrdinal("Paterno")))
                txtmaterno.Text = RTrim(dr.GetValue(dr.GetOrdinal("Materno")))
                txtfono.Text = RTrim(dr.GetValue(dr.GetOrdinal("Telefono")))
                txtemail.Text = RTrim(dr.GetValue(dr.GetOrdinal("Email")))

                'Tipo Cliente
                If dr.GetValue(dr.GetOrdinal("TipoCliente")) = "A" Then
                    rbtAgencia.Checked = True
                Else
                    rbtPersona.Checked = True
                End If

                'Idioma
                If dr.GetValue(dr.GetOrdinal("TipoIdioma")) = "I" Then
                    rbingles.Checked = True
                ElseIf dr.GetValue(dr.GetOrdinal("TipoIdioma")) = "E" Then
                    rbespañol.Checked = True
                ElseIf dr.GetValue(dr.GetOrdinal("TipoIdioma")) = "P" Then
                    rbportugues.Checked = True
                End If
                txtFchNacimiento.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchNacimiento")))
                wEstado = CStr(dr.GetValue(dr.GetOrdinal("StsCliente")))
                'Clase tour
                If dr.GetValue(dr.GetOrdinal("ClaseTour")) = "P" Then
                    rbsib.Checked = False
                    rbprivado.Checked = True
                Else
                    rbprivado.Checked = False
                    rbsib.Checked = True
                End If

                wtipotour = CStr(dr.GetValue(dr.GetOrdinal("TipoTour")))

                'CATEGORIA ALOJAMIENTO    
                If dr.GetValue(dr.GetOrdinal("CateAlojamiento")) = "E" Then
                    rbe.Checked = True
                ElseIf dr.GetValue(dr.GetOrdinal("CateAlojamiento")) = "S" Then
                    rbs.Checked = True
                ElseIf dr.GetValue(dr.GetOrdinal("CateAlojamiento")) = "U" Then
                    rbsu.Checked = True
                ElseIf dr.GetValue(dr.GetOrdinal("CateAlojamiento")) = "L" Then
                    rbd.Checked = True
                End If

                wpreferencia = dr.GetValue(dr.GetOrdinal("PrefEspecial"))
                txtDocPersonal.Text = RTrim(dr.GetValue(dr.GetOrdinal("docpersonal")))
                txtDireccion.Text = RTrim(dr.GetValue(dr.GetOrdinal("direccion")))
                txtCiudad.Text = RTrim(dr.GetValue(dr.GetOrdinal("ciudad")))
                txtEstado.Text = RTrim(dr.GetValue(dr.GetOrdinal("estado")))
                txtCodigoPostal.Text = RTrim(dr.GetValue(dr.GetOrdinal("codigopostal")))
                txtContacto.Text = RTrim(dr.GetValue(dr.GetOrdinal("contacto")))
                txtTelefonoContacto.Text = RTrim(dr.GetValue(dr.GetOrdinal("Telefonocontacto")))
                txtEmailContacto.Text = RTrim(dr.GetValue(dr.GetOrdinal("Emailcontacto")))
                txtClaveCliente.Text = RTrim(dr.GetValue(dr.GetOrdinal("ClaveCliente")))
                txtSigla.Text = RTrim(dr.GetValue(dr.GetOrdinal("Sigla")))
                lblFchsys.Text = dr.GetValue(dr.GetOrdinal("fchAct"))

                wcodpais = dr.GetValue(dr.GetOrdinal("CodPais"))
                sCodVendedor = dr.GetValue(dr.GetOrdinal("CodVendedor"))
                iCodPlanTarifario = dr.GetValue(dr.GetOrdinal("CodPlantarifario"))
                iCodRangoEdad = dr.GetValue(dr.GetOrdinal("CodRangoEdad"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaPais(wcodpais)
        CargaVendedor(sCodVendedor)
        CargaPlanTarifario(iCodPlanTarifario)
        CargaRangoEdad(iCodRangoEdad)

        txtClaveCliente.Text = txtClaveCliente.Text.Trim

        'TIPO TOURS
        If Trim(Mid(wtipotour, 1, 1)) = "A" Then
            cbarqu.Checked = True ' Arqueologico
        End If
        If Trim(Mid(wtipotour, 2, 1)) = "E" Then
            cbecoMozart.Checked = True ' EcoMozart
        End If
        If Trim(Mid(wtipotour, 3, 1)) = "A" Then
            cbaventura.Checked = True ' Aventura
        End If
        If Trim(Mid(wtipotour, 4, 1)) = "M" Then
            cbmistico.Checked = True ' Mistico
        End If

        'PREFERENCIA ESPECIAL
        If Trim(Mid(wpreferencia, 1, 1)) = "C" Then
            cbComida.Checked = True ' Comida Vegetariana
        End If
        If Trim(Mid(wpreferencia, 2, 1)) = "T" Then
            cbTerceraEdad.Checked = True ' Tercera Edad
        End If
        If Trim(Mid(wpreferencia, 3, 1)) = "G" Then
            cbGolf.Checked = True ' Golf
        End If

        If Trim(Mid(wpreferencia, 4, 1)) = "S" Then
            cbShopping.Checked = True ' Shopping
        End If
        If Trim(Mid(wpreferencia, 5, 1)) = "T" Then
            cbTourGastronomico.Checked = True ' Tour Gastronomico
        End If
        If Trim(Mid(wpreferencia, 6, 1)) = "P" Then
            cbPlayas.Checked = True ' Playas
        End If
        If Trim(Mid(wpreferencia, 7, 1)) = "Y" Then
            cbYates.Checked = True ' Yates
        End If

        If Trim(Mid(wpreferencia, 8, 1)) = "A" Then
            cbAndinismo.Checked = True ' Andinismo
        End If
        If Trim(Mid(wpreferencia, 9, 1)) = "T" Then
            cbMozartVivencial.Checked = True ' Mozart Vivencial
        End If
        If Trim(Mid(wpreferencia, 10, 1)) = "T" Then
            cbTourCaza.Checked = True ' Tour Caza
        End If
        If Trim(Mid(wpreferencia, 11, 1)) = "C" Then
            cbCaballos.Checked = True ' Caballos
        End If
        If Trim(Mid(wpreferencia, 12, 1)) = "B" Then
            cbBicicleta.Checked = True ' Bicicleta
        End If
        If Trim(Mid(wpreferencia, 13, 1)) = "A" Then
            cbAventuraExtrema.Checked = True ' Aventura Extrema
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wIdioma, wcategoria, wtour, wnombrec As String
        Dim wTipoCliente As String
        Dim wtipotour, wpreferencia, sCodVendedor As String
        Dim wCodCliente, iCodPlanTarifario As Integer
        'INICIAMOS VARIABLES
        wIdioma = ""
        wcategoria = ""
        wpreferencia = ""
        wtipotour = ""
        wnombrec = ""

        lbln.Text = ""
        lblp.Text = ""

        If ddlVendedor.SelectedItem.Text = " " Then
            sCodVendedor = ""
        Else
            sCodVendedor = ddlVendedor.SelectedValue
        End If
        If ddlPlanTarifario.SelectedItem.Text = " " Then
            iCodPlanTarifario = 0
        Else
            iCodPlanTarifario = ddlPlanTarifario.SelectedValue
        End If

        'TIPO CLIENTE
        If rbtAgencia.Checked Then
            wTipoCliente = "A"
            If txtnombre.Text.Trim.Length = 0 Then
                lblError.Text = "Nombre es dato obligatorio"
                lbln.Text = "obligatorio"
                Return
            End If
            If txtSigla.Text.Trim = "" Then
                lblError.Text = "Para tipo de cliente agencia es obligatorio la sigla"
                Return
            End If


            If sCodVendedor = "" Then
                lblError.Text = "Para tipo de cliente agencia es obligatorio el vendedor"
                Return
            End If
            If iCodPlanTarifario = 0 Then
                lblError.Text = "Para tipo de cliente agencia es obligatorio el plan tarifario"
                Return
            End If

            wnombrec = txtnombre.Text.Trim
            If txtpaterno.Text.Trim.Length > 0 Then
                wnombrec = Trim(wnombrec) + " " + txtpaterno.Text.Trim
            End If
            If txtmaterno.Text.Trim.Length > 0 Then
                wnombrec = Trim(wnombrec) + " " + txtmaterno.Text.Trim
            End If
        Else
            wTipoCliente = "P"
            If txtnombre.Text.Trim.Length = 0 Then
                lblError.Text = "Nombre de cliente es dato obligatorio"
                lbln.Text = "obligatorio"
                Return
            End If
            If txtpaterno.Text.Trim.Length = 0 Then
                lblError.Text = "Apellido paterno es dato obligatorio"
                lblp.Text = "obligatorio"
                Return
            End If

            wnombrec = txtpaterno.Text.Trim
            If txtmaterno.Text.Trim.Length > 0 Then
                wnombrec = Trim(wnombrec) + " " + txtmaterno.Text.Trim
            End If
            wnombrec = Trim(wnombrec) + " " + txtnombre.Text.Trim
        End If

        'IDIOMA
        If rbingles.Checked Then
            wIdioma = "I" 'Ingles
        ElseIf rbespañol.Checked Then
            wIdioma = "E" ' Español
        ElseIf rbportugues.Checked Then
            wIdioma = "P" ' Portugues
        End If
        'CATEGORIA ALOJAMIENTO
        If rbe.Checked Then
            wcategoria = "E" 'Ecnomico
        ElseIf rbs.Checked Then
            wcategoria = "S" ' Standard
        ElseIf rbsu.Checked Then
            wcategoria = "U" ' Superior
        ElseIf rbd.Checked Then
            wcategoria = "L" ' De Lujo
        End If

        'TOUR
        If rbprivado.Checked Then
            wtour = "P" ' Privado
        Else
            wtour = "S" ' SIB
        End If

        'TIPO TOURS
        If cbarqu.Checked Then
            wtipotour = wtipotour + "A" ' Arqueologico
        Else
            wtipotour = wtipotour + " "
        End If

        If cbecoMozart.Checked Then
            wtipotour = wtipotour + "E" ' EcoMozart
        Else
            wtipotour = wtipotour + " "
        End If
        If cbaventura.Checked Then
            wtipotour = wtipotour + "A" ' Aventura
        Else
            wtipotour = wtipotour + " "
        End If
        If cbmistico.Checked Then
            wtipotour = wtipotour + "M" ' Mistico
        Else
            wtipotour = wtipotour + " "
        End If

        'PREFERENCIA ESPECIAL
        If cbComida.Checked Then
            wpreferencia = wpreferencia & "C"   'Comida Vegetariana
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbTerceraEdad.Checked Then
            wpreferencia = wpreferencia & "T" ' Tercera Edad
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbGolf.Checked Then
            wpreferencia = wpreferencia & "G" ' Golf
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbShopping.Checked Then
            wpreferencia = wpreferencia & "S" ' Shopping
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbTourGastronomico.Checked Then
            wpreferencia = wpreferencia & "T" ' Tour Gastronomico
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbPlayas.Checked Then
            wpreferencia = wpreferencia & "P" ' Playas/Surf 
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbYates.Checked Then
            wpreferencia = wpreferencia & "Y" ' Yates
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbAndinismo.Checked Then
            wpreferencia = wpreferencia & "A" 'Andinismo
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbMozartVivencial.Checked Then
            wpreferencia = wpreferencia & "T" ' Mozart Vivencial
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbTourCaza.Checked Then
            wpreferencia = wpreferencia & "T" ' Tour Caza
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbCaballos.Checked Then
            wpreferencia = wpreferencia & "C" ' Caballos
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbBicicleta.Checked Then
            wpreferencia = wpreferencia & "B" ' Bicicleta
        Else
            wpreferencia = wpreferencia & " "
        End If
        If cbAventuraExtrema.Checked Then
            wpreferencia = wpreferencia & "A" ' Aventura Extrema
        Else
            wpreferencia = wpreferencia & " "
        End If

        If Viewstate("Opcion") = "N" Then
            wCodCliente = 0
        Else
            wCodCliente = CInt(Viewstate("CodCliente"))
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_Cliente_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@CodClienteOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = wCodCliente
        cd.Parameters.Add("@TipoCliente", SqlDbType.Char, 1).Value = wTipoCliente
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 40).Value = txtnombre.Text
        cd.Parameters.Add("@Paterno", SqlDbType.VarChar, 25).Value = txtpaterno.Text
        cd.Parameters.Add("@Materno", SqlDbType.VarChar, 25).Value = txtmaterno.Text
        cd.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50).Value = wnombrec
        cd.Parameters.Add("@Telefono", SqlDbType.Char, 15).Value = txtfono.Text
        cd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtemail.Text.Trim
        cd.Parameters.Add("@TipoPersona", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@TipoIdioma", SqlDbType.Char, 1).Value = wIdioma
        cd.Parameters.Add("@CodPais", SqlDbType.Char, 3).Value = ddlpais.SelectedItem.Value
        cd.Parameters.Add("@FchNacimiento", SqlDbType.Char, 8).Value = Rutina.fechayyyymmdd(txtFchNacimiento.Text)
        cd.Parameters.Add("@StsCliente", SqlDbType.Char, 1).Value = "A"
        cd.Parameters.Add("@ClaseTour", SqlDbType.Char, 1).Value = wtour
        cd.Parameters.Add("@TipoTour", SqlDbType.Char, 10).Value = wtipotour
        cd.Parameters.Add("@CateAlojamiento", SqlDbType.Char, 1).Value = wcategoria
        cd.Parameters.Add("@PrefEspecial", SqlDbType.Char, 20).Value = wpreferencia
        cd.Parameters.Add("@DocPersonal", SqlDbType.Char, 20).Value = txtDocPersonal.Text.Trim
        cd.Parameters.Add("@Direccion", SqlDbType.Char, 50).Value = txtDireccion.Text.Trim
        cd.Parameters.Add("@Ciudad", SqlDbType.Char, 50).Value = txtCiudad.Text.Trim
        cd.Parameters.Add("@Estado", SqlDbType.Char, 50).Value = txtEstado.Text.Trim
        cd.Parameters.Add("@CodigoPostal", SqlDbType.Char, 50).Value = txtCodigoPostal.Text.Trim
        cd.Parameters.Add("@Contacto", SqlDbType.Char, 50).Value = txtContacto.Text.Trim
        cd.Parameters.Add("@TelefonoContacto", SqlDbType.Char, 50).Value = txtTelefonoContacto.Text.Trim
        cd.Parameters.Add("@EmailContacto", SqlDbType.Char, 50).Value = txtEmailContacto.Text.Trim
        cd.Parameters.Add("@ClaveCliente", SqlDbType.Char, 30).Value = txtClaveCliente.Text.Trim
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = sCodVendedor
        cd.Parameters.Add("@CodPlanTarifario", SqlDbType.Int).Value = iCodPlanTarifario
        cd.Parameters.Add("@Sigla", SqlDbType.Char, 20).Value = txtSigla.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        cd.Parameters.Add("@CodRangoEdad", SqlDbType.Int).Value = ddlRangoEdad.SelectedValue
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblError.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblError.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblError.Text = "Error: " & ex2.Message
        End Try
        cn.Close()

        If lblError.Text.Trim = "OK" Then
            If Viewstate("Opcion") = "N" Then
                Response.Redirect("CpcClienteFicha.aspx" & _
                "?CodCliente=" & cd.Parameters("@CodClienteOut").Value)
            Else
                Response.Redirect("CpcClienteFicha.aspx" & _
                "?CodCliente=" & Viewstate("CodCliente"))
            End If
        End If
    End Sub

    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click
        Dim codigo As Integer

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_Cliente_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        codigo = CInt(Viewstate("CodCliente"))
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = codigo
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblError.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblError.Text = Rutina.fncErroresSQL(ex1.Errors)
            If lblError.Text = "547" Then
                lblError.Text = "Mensaje: Si desea eliminar al Cliente, primero debe eliminar los Pedidos,Tareas,Historial, Documentos Cargo y Abono"
            End If
        Catch ex2 As System.Exception
            lblError.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblError.Text) = "OK" Then
            Response.Redirect("CPCClienteBusca.aspx?CodCliente=" & 0)
        End If
    End Sub


End Class
