Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cpcVisitasPendReprograma
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("TipoVisita") = Request.Params("TipoVisita")
            Viewstate("FchIni") = Request.Params("FchIni")
            Viewstate("FchFin") = Request.Params("FchFin")

            If Viewstate("Opcion") = "Reprograma" Or Viewstate("Opcion") = "Consulta" Then
                lblTitulo.Text = "Reprogramar Visita"
                Viewstate("CodVendedor") = Request.Params("CodVendedor")
            Else
                lblTitulo.Text = "Programar Visita"
            End If
            EditaVisita()
            If rbno.Checked = True Then
                ddlEvaluacion.Enabled = True
            Else
                ddlEvaluacion.Enabled = False
            End If
        End If
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

        If pFind Then
            ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
        End If
    End Sub
    Private Sub EditaVisita()
        Dim wResponsable, wStsVisita, wObservacion, wCodVendedor As String
        Dim wCodEvaluacion As String

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
                lblPax.Text = CStr(dr.GetValue(dr.GetOrdinal("CantPasajeros")))
                If (CStr(dr.GetValue(dr.GetOrdinal("TipoVisita"))) = "E") Then
                    lblTipo.Text = "Entrada"
                Else
                    lblTipo.Text = "Salida"
                End If
                txtFchVisita.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchVisita")))
                txtHoraVisita.Text = Trim(CStr(dr.GetValue(dr.GetOrdinal("HoraVisita"))))
                wResponsable = CStr(dr.GetValue(dr.GetOrdinal("CodResponsable")))
                wStsVisita = CStr(dr.GetValue(dr.GetOrdinal("StsVisita")))
                wCodVendedor = CStr(dr.GetValue(dr.GetOrdinal("CodVendedor")))
                wCodEvaluacion = CStr(dr.GetValue(dr.GetOrdinal("CodEvaluacion")))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        CargaEvaluacion(wCodEvaluacion, "N")

        If wResponsable.Trim.Length > 0 Then
            CargaVendedor(wResponsable, True)
        Else
            CargaVendedor(wCodVendedor, True)
        End If
        If wStsVisita.Trim.Length > 0 Then
            If wStsVisita = "P" Then
                rbsi.Checked = True
                rbno.Checked = False
            Else
                If wStsVisita = "N" Then
                    rbno.Checked = True
                    rbsi.Checked = False
                End If
            End If
        End If
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbsi.Checked Then
            If ddlVendedor.SelectedItem.Value = "Elegir Vendedor" Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Elija un Responsable"
                Return
            End If

            If txtHoraVisita.Text.Trim.Length = 0 Then
                lblmsg.Visible = True
                lblmsg.Text = "Error: Ingrese la Hora de visita"
                Return
            End If
        End If


        Dim wEstado As String
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
        cd.Parameters.Add("@HoraVisita", SqlDbType.Char, 5).Value = txtHoraVisita.Text
        cd.Parameters.Add("@Meridiano", SqlDbType.Char, 1).Value = ""
        If ddlVendedor.Items.Count > 0 Then
            If ddlVendedor.SelectedItem.Value = "Elegir Vendedor" Then
                cd.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ""
            Else
                cd.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value()
            End If
        Else
            cd.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ""
        End If
        If rbsi.Checked Then
            cd.Parameters.Add("@StsVisita", SqlDbType.Char, 1).Value = "G"
        Else
            cd.Parameters.Add("@StsVisita", SqlDbType.Char, 1).Value = "N"
        End If
        If rbno.Checked = True Then
            cd.Parameters.Add("@CodEvaluacion", SqlDbType.Char, 3).Value = ddlEvaluacion.SelectedItem.Value
        Else
            cd.Parameters.Add("@CodEvaluacion", SqlDbType.Char, 3).Value = ""
        End If
        cd.Parameters.Add("@CantPasajeros", SqlDbType.TinyInt).Value = lblPax.Text
        cd.Parameters.Add("@Opcion", SqlDbType.VarChar, 50).Value = "N"
        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = ""
        cd.Parameters.Add("@FlagDesLog", SqlDbType.Char, 1).Value = "N" ' N=No Actualizar deslog
        cd.Parameters.Add("@CantDiaLibre", SqlDbType.SmallMoney).Value = 0
        cd.Parameters.Add("@CodUsuario", SqlDbType.Text, 15).Value = Session("CodUsuario")
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
            If Viewstate("Opcion") = "Consulta" Then
                Response.Redirect("cpcVisitasConsulta.aspx" & _
                "?TipoVisita=" & Viewstate("TipoVisita") & _
                "&CodVendedor=" & Viewstate("CodVendedor") & _
                "&FchIni=" & Viewstate("FchIni") & _
                "&FchFin=" & Viewstate("FchFin") & _
                "&Opcion=" & Viewstate("Opcion"))
            Else
                Response.Redirect("cpcVisitasPend.aspx" & _
                "?TipoVisita=" & Viewstate("TipoVisita") & _
                "&CodVendedor=" & Viewstate("CodVendedor") & _
                "&FchIni=" & Viewstate("FchIni") & _
                "&FchFin=" & Viewstate("FchFin") & _
                "&Opcion=" & Viewstate("Opcion"))
            End If
        End If
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub rbno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbno.CheckedChanged
        ddlEvaluacion.Enabled = True
    End Sub

    Private Sub rbsi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsi.CheckedChanged
        ddlEvaluacion.Enabled = False
    End Sub

End Class
