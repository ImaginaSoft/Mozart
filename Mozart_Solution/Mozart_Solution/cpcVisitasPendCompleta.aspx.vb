Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cpcVisitasPendCompleta
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("TipoVisita") = Request.Params("TipoVisita")
            Viewstate("CodResponsable") = Request.Params("CodResponsable")
            Viewstate("CodVendedor") = Request.Params("CodVendedor")
            Viewstate("FchIni") = Request.Params("FchIni")
            Viewstate("FchFin") = Request.Params("FchFin")

            If Viewstate("CodResponsable") <> "" Then
                CargaVendedor(Viewstate("CodResponsable"), True)
            Else
                CargaVendedor(" ", False)
            End If
            EditaVisita()
            EditaDetalleVisita()
        End If

        With cmdGrabar
            .Attributes.Add("onClick", "getHTML()")
        End With

    End Sub
    Private Sub CargaEvaluacion(ByVal pcodVisita As String, ByVal ptipoVisita As String)
        'Bancos Activos
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_EvaluacionTipo_S"
        da.SelectCommand.Parameters.Add("@TipoEvaluacion", SqlDbType.Char, 1).Value = ptipoVisita
        da.Fill(ds, "TBancoOrigen")
        ddlEvaluacion.DataSource = ds.Tables("TBancoOrigen")
        ddlEvaluacion.DataBind()
        If pcodVisita.Trim.Length > 0 Then
            ddlEvaluacion.Items.FindByValue(pcodVisita).Selected = True
        End If
    End Sub
    Private Sub CargaVendedor(ByVal pCodVendedor As String, ByVal pFind As Boolean)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_VendedorActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Vendedor")
        ddlVendedor.DataSource = ds.Tables("Vendedor")
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Elegir Vendedor"))
        If pFind Then
            Try
                ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub EditaVisita()
        Dim wResponsable As String
        Dim wStsVisita, wCodEvaluacion As String

        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_Visita_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = Viewstate("TipoVisita")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNroPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("NroPedido")))
                lblDesPedido.Text = CStr(dr.GetValue(dr.GetOrdinal("DesPedido")))
                lblNomCliente.Text = CStr(dr.GetValue(dr.GetOrdinal("NomCliente")))
                lblNomVendedor.Text = CStr(dr.GetValue(dr.GetOrdinal("NomVendedor")))
                txtPax.Text = CStr(dr.GetValue(dr.GetOrdinal("CantPasajeros"))).Trim
                If (CStr(dr.GetValue(dr.GetOrdinal("TipoVisita"))) = "E") Then
                    lblTipo.Text = "Entrada"
                Else
                    lblTipo.Text = "Salida"
                End If
                txtFchVisita.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchVisita")))
                txtHoraVisita.Text = CStr(dr.GetValue(dr.GetOrdinal("HoraVisita"))).Trim
                wCodEvaluacion = CStr(dr.GetValue(dr.GetOrdinal("CodEvaluacion")))
                wResponsable = CStr(dr.GetValue(dr.GetOrdinal("CodResponsable")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        If ViewState("TipoVisita") = "E" Then
            lblTipo.Text = "Entrada"
        Else
            If ViewState("TipoVisita") = "S" Then
                lblTipo.Text = "Salida"
            End If
        End If

        If lblTipo.Text = "Entrada" Then
            CargaEvaluacion(wCodEvaluacion, "E")
        Else
            If lblTipo.Text = "Salida" Then
                CargaEvaluacion(wCodEvaluacion, "S")
            End If
        End If
    End Sub

    Private Sub EditaDetalleVisita()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_VisitaDesLog_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = Viewstate("TipoVisita")
        dsEdit.Clear()
        da.Fill(dsEdit, "DVISITA")
        txtRTB.DataBind()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If Not IsNumeric(txtPax.Text) Then
            lblmsg.Text = "Error: Nº de Pax es dato numerico"
            Return
        End If

        If txtHoraVisita.Text.Trim = "" Then
            lblmsg.Text = "Error: Hora Visita es dato obligatorio"
            Return
        End If
        If txtCantDiaLibre.Text.Trim = "" Then
            lblmsg.Text = "Error: Cantidad de día libre es obligatorio, Rango válido de [0 , 1.4]"
            Return
        End If

        If Not IsNumeric(txtCantDiaLibre.Text) Then
            lblmsg.Text = "Error: Cantidad de día libre es dato numerico"
            Return
        End If

        If CDbl(txtCantDiaLibre.Text) < 0 Or CDbl(txtCantDiaLibre.Text) > 1.4 Then
            lblmsg.Text = "Error: Rango válido para cantidad de día libre es [0 , 1.4]"
            Return
        End If


        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_Visita_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = Viewstate("TipoVisita")
        cd.Parameters.Add("@FchVisita", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchVisita.Text)
        cd.Parameters.Add("@HoraVisita", SqlDbType.Char, 6).Value = txtHoraVisita.Text
        cd.Parameters.Add("@Meridiano", SqlDbType.Char, 1).Value = ""
        If ddlVendedor.Items.Count > 0 Then
            cd.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value()
        Else
            cd.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ""
        End If
        cd.Parameters.Add("@StsVisita", SqlDbType.Char, 1).Value = "E"
        If ddlEvaluacion.Items.Count > 0 Then
            cd.Parameters.Add("@CodEvaluacion", SqlDbType.Char, 3).Value = ddlEvaluacion.SelectedItem.Value
        Else
            cd.Parameters.Add("@CodEvaluacion", SqlDbType.Char, 3).Value = ""
        End If
        cd.Parameters.Add("@CantPasajeros", SqlDbType.TinyInt).Value = txtPax.Text
        cd.Parameters.Add("@Opcion", SqlDbType.Char, 1).Value = "C"
        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = txtRTB.Text
        cd.Parameters.Add("@FlagDesLog", SqlDbType.Char, 1).Value = "S" ' S=Actualizar deslog
        cd.Parameters.Add("@CantDiaLibre", SqlDbType.SmallMoney).Value = txtCantDiaLibre.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Text, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Visible = True
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Visible = True
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If lblmsg.Text.Trim = "OK" Then
            lblmsg.Visible = False
            Response.Redirect("cpcVisitasPend.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&CodVendedor=" & Viewstate("CodVendedor") & _
            "&TipoVisita=" & Viewstate("TipoVisita") & _
            "&FchIni=" & Viewstate("FchIni") & _
            "&FchFin=" & Viewstate("FchFin") & _
            "&Opcion=" & Viewstate("Opcion"))
        End If
    End Sub

End Class
