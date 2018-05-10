Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpTabla

Partial Class VtaPedidoRapido
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim objZonaVta As New clsZonaVta
    Dim objTablaElemento As New clsTablaElemento
    Dim objIdioma As New clsIdioma

    Dim wCodCliente As Integer
    Dim wCantAdultos As Integer
    Dim wCantNinos As Integer
    Dim wTipoIdioma As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtnombre.Style.Add("width", "244px")
            txtpaterno.Style.Add("width", "244px")
            txtEmail.Style.Add("width", "344px")
            txtDesc.Style.Add("width", "344px")

            txtFchPedido.Style.Add("width", "75px")
            ddlMes.Style.Add("width", "123px")
            ddlAno.Style.Add("width", "72px")

            ddlVendedor.Style.Add("width", "229px")
            txtAdultos.Style.Add("width", "35px")
            txtNinos.Style.Add("width", "35px")


            wCodCliente = 0
            txtFchPedido.Text = ObjRutina.fechaddmmyyyy(0)
            txtAdultos.Text = "2"
            DefaultTipoPasajero()
            CargaVendedor(" ", False)
            CargaAno(0, False)
            CargaStsCaptacion("")
            CargaZonaVta()
            CargaOrigenPedido()
            CargaFlagComentario()
            CargaRangoEdad()
        End If

    End Sub

    Private Sub DefaultTipoPasajero()
        Dim sIdioma As String = ""
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_DefaullTipoIdioma_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                sIdioma = dr.GetValue(dr.GetOrdinal("TipoIdioma"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaIdioma(sIdioma)
    End Sub

    Private Sub CargaStsCaptacion(ByVal pStsCaptacion As String)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_StsCaptacion_S")
        ddlStsCaptacion.DataSource = ds.Tables(0)
        ddlStsCaptacion.DataBind()
        If pStsCaptacion.Trim.Length > 0 Then
            ddlStsCaptacion.Items.FindByValue(pStsCaptacion).Selected = True
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim ds As New DataSet
        ds = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()
    End Sub

    Private Sub CargaOrigenPedido()
        Dim ds As New DataSet
        ds = objTablaElemento.CargaTablaEleNumxNroOrden(17, "E")
        ddlOrigenPedido.DataSource = ds
        ddlOrigenPedido.DataBind()
    End Sub

    Private Sub CargaFlagComentario()
        Dim ds As New DataSet
        ds = objTablaElemento.CargaTablaElexCodEle(18, "E")
        ddlFlagComentario.DataSource = ds
        ddlFlagComentario.DataBind()
    End Sub

    Private Sub CargaRangoEdad()
        Dim ds As New DataSet
        ds = objTablaElemento.CargaTablaEleNumxNroOrden(20, "E")
        ddlRangoEdad.DataSource = ds
        ddlRangoEdad.DataBind()
    End Sub

    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
        If pIdioma.Trim.Length > 0 Then
            Try
                ddlIdioma.Items.FindByValue(pIdioma).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblVendedor.Text = ""
        If ddlVendedor.SelectedItem.Value = "Elegir Vendedor" Then
            lblVendedor.Text = "Dato Obligatorio"
            Return
        End If

        If txtAdultos.Text.Trim.Length = 0 Then
            wCantAdultos = 0
        ElseIf IsNumeric(txtAdultos.Text) Then
            wCantAdultos = CInt(txtAdultos.Text)
        Else
            lblMsg.Text = "Error : Cantidad adultos es dato númerico"
            Return
        End If

        If txtNinos.Text.Trim.Length = 0 Then
            wCantNinos = 0
        ElseIf IsNumeric(txtNinos.Text) Then
            wCantNinos = CInt(txtNinos.Text)
        Else
            lblMsg.Text = "Error : Cantidad Niños es dato númerico"
            Return
        End If

        If wCantAdultos = 0 And wCantNinos = 0 Then
            lblMsg.Text = "Error: Ingrese por lo menos un Tipo de Pasajero"
            Return
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
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@TipoCliente", SqlDbType.Char, 1).Value = "P"
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 40).Value = txtnombre.Text
        cd.Parameters.Add("@Paterno", SqlDbType.VarChar, 25).Value = txtpaterno.Text
        cd.Parameters.Add("@Materno", SqlDbType.VarChar, 25).Value = ""
        cd.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50).Value = Trim(txtpaterno.Text) + " " + Trim(txtnombre.Text)
        cd.Parameters.Add("@Telefono", SqlDbType.Char, 15).Value = ""
        cd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text
        cd.Parameters.Add("@TipoPersona", SqlDbType.Char, 1).Value = "E" ' Extrajera 
        cd.Parameters.Add("@TipoIdioma", SqlDbType.Char, 1).Value = ddlIdioma.SelectedValue
        cd.Parameters.Add("@CodPais", SqlDbType.Char, 3).Value = "999"
        cd.Parameters.Add("@FchNacimiento", SqlDbType.Char, 8).Value = ""
        cd.Parameters.Add("@StsCliente", SqlDbType.Char, 1).Value = "A"
        cd.Parameters.Add("@ClaseTour", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@TipoTour", SqlDbType.Char, 10).Value = ""
        cd.Parameters.Add("@CateAlojamiento", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@PrefEspecial", SqlDbType.Char, 20).Value = ""
        cd.Parameters.Add("@DocPersonal", SqlDbType.Char, 20).Value = ""
        cd.Parameters.Add("@Direccion", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@Ciudad", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@Estado", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@CodigoPostal", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@Contacto", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@TelefonoContacto", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@EmailContacto", SqlDbType.Char, 50).Value = ""
        cd.Parameters.Add("@ClaveCliente", SqlDbType.VarChar, 30).Value = "" 'txtpaterno.Text.Trim
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ""
        cd.Parameters.Add("@CodPlanTarifario", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@Sigla", SqlDbType.Char, 20).Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        cd.Parameters.Add("@CodRangoEdad", SqlDbType.Int).Value = ddlRangoEdad.SelectedValue
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
        If lblMsg.Text.Trim = "OK" Then
            wCodCliente = CInt(cd.Parameters("@CodClienteOut").Value())
            lblMsg.Text = CStr(wCodCliente)
            GrabaPedido()
        End If
    End Sub

    Private Sub GrabaPedido()
        Dim wAno As Integer
        If ddlAno.SelectedItem.Value = "Año" Then
            wAno = 0
        Else
            wAno = ddlAno.SelectedItem.Value
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Pedido_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPedidoOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@DesPedido", SqlDbType.VarChar, 100).Value = Trim(txtDesc.Text)
        cd.Parameters.Add("@FchPedido", SqlDbType.Char, 8).Value = txtFchPedido.Text.Substring(6, 4) + txtFchPedido.Text.Substring(3, 2) + txtFchPedido.Text.Substring(0, 2)
        cd.Parameters.Add("@StsPedido", SqlDbType.Char, 1).Value = "N"
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = wCodCliente
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = CStr(ddlVendedor.SelectedItem.Value)
        cd.Parameters.Add("@CantAdultos", SqlDbType.TinyInt).Value = wCantAdultos
        cd.Parameters.Add("@CantNinos", SqlDbType.TinyInt).Value = wCantNinos
        cd.Parameters.Add("@MesAtencion", SqlDbType.TinyInt).Value = ddlMes.SelectedItem.Value
        cd.Parameters.Add("@AnoAtencion", SqlDbType.SmallInt).Value = wAno
        cd.Parameters.Add("@StsCaptacion", SqlDbType.Char, 1).Value = ddlStsCaptacion.SelectedItem.Value
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta.SelectedItem.Value
        cd.Parameters.Add("@TipoIdioma", SqlDbType.Char, 1).Value = ddlIdioma.SelectedValue
        cd.Parameters.Add("@OrigenComprador", SqlDbType.Char, 1).Value = "E" 'Extranjero
        cd.Parameters.Add("@OrigenPedido", SqlDbType.SmallInt).Value = ddlOrigenPedido.SelectedItem.Value
        cd.Parameters.Add("@FlagComentario", SqlDbType.Char, 1).Value = ddlFlagComentario.SelectedItem.Value
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

        If lblMsg.Text.Trim = "OK" Then
            Session("CodCliente") = wCodCliente
            Response.Redirect("CpcClienteFicha.aspx" & _
                     "?CodCliente=" & wCodCliente)
        End If
    End Sub

    Private Sub CargaVendedor(ByVal pCodVendedor As String, ByVal pFind As Boolean)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_VendedorActivo_S")
        ddlVendedor.DataSource = ds.Tables(0)
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Elegir Vendedor"))
        ddlVendedor.Items.FindByValue("Elegir Vendedor").Selected = True
        If pFind Then
            ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
        End If
    End Sub

    Private Sub CargaAno(ByVal pAno As Integer, ByVal pFind As Boolean)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_AnoProcesoActivo_S")
        ddlAno.DataSource = ds.Tables(0)
        ddlAno.DataBind()
        ddlAno.Items.Insert(0, New ListItem("Año"))
        ddlAno.Items.FindByValue("Año").Selected = True
        If pFind Then
            ddlAno.Items.FindByValue(pAno).Selected = True
        End If
    End Sub

    Private Sub txtpaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpaterno.TextChanged
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_ClienteDuplicado_S"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Nombre", SqlDbType.VarChar, 40).Value = txtnombre.Text
        cd.Parameters.Add("@Paterno", SqlDbType.VarChar, 25).Value = txtpaterno.Text
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If Trim(cd.Parameters("@MsgTrans").Value) = "OK" Then
                lblMsg.Text = ""
                setFocus(txtEmail)
            Else
                lblMsg.Text = cd.Parameters("@MsgTrans").Value
                setFocus(txtpaterno)
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
    End Sub

    Private Sub setFocus(ByVal ctrl As System.Web.UI.Control)
        Dim s As String = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ID + "').focus() </SCRIPT>"
        RegisterStartupScript("focus", s)
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_ClienteDuplicadoEmail_S"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = 0
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If Trim(cd.Parameters("@MsgTrans").Value) = "OK" Then
                lblMsg.Text = ""
                'If rbtIngles.Checked Then
                '    setFocus(rbtIngles)
                'Else
                '    setFocus(rbtEspanol)
                'End If
            Else
                lblMsg.Text = cd.Parameters("@MsgTrans").Value
                setFocus(txtEmail)
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
    End Sub

End Class
