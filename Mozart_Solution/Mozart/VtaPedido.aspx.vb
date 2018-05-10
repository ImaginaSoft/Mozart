Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpTabla

Partial Class VtaPedido
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objZonaVta As New clsZonaVta
    Dim objIdioma As New clsIdioma
    Dim objTablaElemento As New clsTablaElemento

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            If Len(Trim(Request.Params("NroPedido"))) > 0 Then
                EditaPedido()
            Else
                CargaZonaVta("")
                CargaOrigenPedido(0)
                CargaFlagComentario("")
                txtFchPedido.Text = objRutina.fechaddmmyyyy(0)
                CargaStsCaptacion("")
                If Request.Params("NroSolicitud") > 0 Then
                    Viewstate("NroSolicitud") = Request.Params("NroSolicitud")
                    EditaSolicitud()
                Else
                    Viewstate("NroSolicitud") = 0
                    DefaultTipoPasajero()
                    CargaAno("Año", False)
                    CargaVendedor(" ", False)
                    txtAdultos.Text = "1"
                End If
            End If
        End If
    End Sub

    Private Sub DefaultTipoPasajero()
        Dim sIdioma As String = "I"
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

    Private Sub CargaZonaVta(ByVal pCodZonaVta As String)
        Dim ds As New DataSet
        ds = objZonaVta.Cargar(Session("CodUsuario"))
        ddlZonaVta.DataSource = ds
        ddlZonaVta.DataBind()
        If pCodZonaVta.Trim.Length > 0 Then
            Try
                ddlZonaVta.Items.FindByValue(pCodZonaVta).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CargaOrigenPedido(ByVal pOrigenPedido As Integer)
        Dim ds As New DataSet
        ds = objTablaElemento.CargaTablaEleNumxNroOrden(17, "E")
        ddlOrigenPedido.DataSource = ds
        ddlOrigenPedido.DataBind()
        If pOrigenPedido > 0 Then
            Try
                ddlOrigenPedido.Items.FindByValue(pOrigenPedido).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CargaFlagComentario(ByVal pFlagComentario As String)
        Dim ds As New DataSet
        ds = objTablaElemento.CargaTablaElexCodEle(18, "E")
        ddlFlagComentario.DataSource = ds
        ddlFlagComentario.DataBind()

        If pFlagComentario <> "" Then
            Try
                ddlFlagComentario.Items.FindByValue(pFlagComentario).Selected = True
            Catch ex As Exception

            End Try
        End If
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


    Private Sub EliminaPedido()
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Pedido_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        lblMsg.Text = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = objRutina.fncErroresSQL(ex1.Errors)
            If lblMsg.Text = "547" Then
                lblMsg.Text = "Mensaje: Si desea eliminar Pedido, primero debe eliminar las propuestas, Tareas y Historial"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("WebClienteFicha.aspx" & _
                     "?CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Private Sub EditaPedido()
        Dim wCodVendedor, wAno, wStsCaptacion, sFlagComentario As String
        Dim wCodZonaVta As String = ""
        Dim sIdioma As String = ""
        Dim iOrigenPedido As Integer
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoNroPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wCodVendedor = dr.GetValue(dr.GetOrdinal("CodVendedor"))
                txtAdultos.Text = dr.GetValue(dr.GetOrdinal("CantAdultos"))
                txtNinos.Text = dr.GetValue(dr.GetOrdinal("CantNinos"))
                txtDesc.Text = dr.GetValue(dr.GetOrdinal("DesPedido"))
                txtFchPedido.Text = ToString.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchPedido")))

                If dr.GetValue(dr.GetOrdinal("anoatencion")) = 0 Then
                    wAno = "Año"
                Else
                    wAno = dr.GetValue(dr.GetOrdinal("anoatencion"))
                End If

                ddlMes.Items.FindByValue(dr.GetValue(dr.GetOrdinal("mesatencion"))).Selected = True
                lblStsPedido.Text = dr.GetValue(dr.GetOrdinal("StsPedido"))
                If dr.GetValue(dr.GetOrdinal("CodStsPedido")) <> "S" And _
                   dr.GetValue(dr.GetOrdinal("CodStsPedido")) <> "N" Then
                    cmdGrabar.Enabled = False
                End If
                wStsCaptacion = dr.GetValue(dr.GetOrdinal("StsCaptacion"))
                wCodZonaVta = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
                iOrigenPedido = dr.GetValue(dr.GetOrdinal("OrigenPedido"))
                sFlagComentario = dr.GetValue(dr.GetOrdinal("FlagComentario"))

                sIdioma = dr.GetValue(dr.GetOrdinal("Idioma"))
                If dr.GetValue(dr.GetOrdinal("OrigenComprador")) = "E" Then
                    rbtExtranjero.Checked = True
                Else
                    rbtPeruano.Checked = True
                End If
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        lblNroPedido.Text = CStr(ViewState("NroPedido"))
        CargaVendedor(wCodVendedor, True)
        CargaAno(wAno, True)
        CargaStsCaptacion(wStsCaptacion)
        CargaZonaVta(wCodZonaVta)
        CargaOrigenPedido(iOrigenPedido)
        CargaFlagComentario(sFlagComentario)
        CargaIdioma(sIdioma)
    End Sub

    Private Sub EditaSolicitud()
        Dim wCodVendedor, wAno As String
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "AGE_SolicitudNroSolicitud_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroSolicitud", SqlDbType.Int).Value = Viewstate("NroSolicitud")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                txtAdultos.Text = dr.GetValue(dr.GetOrdinal("CantAdultos"))
                txtNinos.Text = dr.GetValue(dr.GetOrdinal("CantNinos"))
                If dr.GetValue(dr.GetOrdinal("anoatencion")) = 0 Then
                    wAno = "Año"
                Else
                    wAno = dr.GetValue(dr.GetOrdinal("anoatencion"))
                End If

                ddlMes.Items.FindByValue(dr.GetValue(dr.GetOrdinal("mesatencion"))).Selected = True
                wCodVendedor = dr.GetValue(dr.GetOrdinal("CodVendedor"))

            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        CargaVendedor(wCodVendedor, True)
        CargaAno(wAno, True)
    End Sub

    Private Sub CargaVendedor(ByVal pCodVendedor As String, ByVal pFind As Boolean)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_VendedorActivo_S")
        ddlVendedor.DataSource = ds.Tables(0)
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Elegir Vendedor"))
        If pFind Then
            Try
                ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
            Catch ex As Exception
                lblMsg.Text = pCodVendedor + ", Vendedor está inactivo"
            End Try
        Else
            ddlVendedor.Items.FindByValue("Elegir Vendedor").Selected = True
        End If
    End Sub

    Private Sub CargaAno(ByVal pAno As String, ByVal pFind As Boolean)
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_AnoProceso_S")
        ddlAno.DataSource = ds.Tables(0)
        ddlAno.DataBind()
        ddlAno.Items.Insert(0, New ListItem("Año"))
        If pFind Then
            ddlAno.Items.FindByValue(pAno).Selected = True
        End If
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

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblerror1.Text = ""
        If ddlVendedor.SelectedItem.Value = "Elegir Vendedor" Then
            lblerror1.Text = "Dato obligatorio"
            Return
        End If

        Dim wCantAdultos As Integer
        If txtAdultos.Text.Trim.Length = 0 Then
            wCantAdultos = 0
        ElseIf IsNumeric(txtAdultos.Text) Then
            wCantAdultos = CInt(txtAdultos.Text)
        Else
            lblMsg.Text = "Error : Cantidad adultos es dato númerico"
            Return
        End If

        Dim wCantNinos As Integer
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

        Dim wAno As Integer
        If ddlAno.SelectedItem.Value = "Año" Then
            wAno = 0
        Else
            wAno = ddlAno.SelectedItem.Value
        End If

        Dim wNroPedido As Integer
        If Len(Trim(lblNroPedido.Text)) = 0 Then
            wNroPedido = 0
            lblStsPedido.Text = "Negociacion"
        Else
            wNroPedido = CInt(lblNroPedido.Text)
        End If

        Dim sOrigenComprador As String
        If rbtExtranjero.Checked Then
            sOrigenComprador = "E"
        Else
            sOrigenComprador = "P"
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
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = wNroPedido
        cd.Parameters.Add("@DesPedido", SqlDbType.VarChar, 100).Value = Trim(txtDesc.Text)
        cd.Parameters.Add("@FchPedido", SqlDbType.Char, 8).Value = txtFchPedido.Text.Substring(6, 4) + txtFchPedido.Text.Substring(3, 2) + txtFchPedido.Text.Substring(0, 2)
        cd.Parameters.Add("@StsPedido", SqlDbType.Char, 1).Value = Mid(lblStsPedido.Text, 1, 1)
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value
        cd.Parameters.Add("@CantAdultos", SqlDbType.TinyInt).Value = wCantAdultos
        cd.Parameters.Add("@CantNinos", SqlDbType.TinyInt).Value = wCantNinos
        cd.Parameters.Add("@MesAtencion", SqlDbType.TinyInt).Value = ddlMes.SelectedItem.Value
        cd.Parameters.Add("@AnoAtencion", SqlDbType.SmallInt).Value = wAno
        cd.Parameters.Add("@StsCaptacion", SqlDbType.Char, 1).Value = ddlStsCaptacion.SelectedItem.Value
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = ddlZonaVta.SelectedItem.Value
        cd.Parameters.Add("@TipoIdioma", SqlDbType.Char, 1).Value = ddlIdioma.SelectedValue
        cd.Parameters.Add("@OrigenComprador", SqlDbType.Char, 1).Value = sOrigenComprador
        cd.Parameters.Add("@NroSolicitud", SqlDbType.Int).Value = Viewstate("NroSolicitud")
        cd.Parameters.Add("@OrigenPedido", SqlDbType.SmallInt).Value = ddlOrigenPedido.SelectedItem.Value
        cd.Parameters.Add("@FlagComentario", SqlDbType.Char, 1).Value = ddlFlagComentario.SelectedItem.Value
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
            Response.Redirect("VtaPedidoFicha.aspx" & _
                              "?NroPedido=" & cd.Parameters("@NroPedidoOut").Value & _
                              "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub


End Class
