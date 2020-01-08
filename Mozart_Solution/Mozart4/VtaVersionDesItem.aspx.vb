Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Data.SqlClient


Partial Class VtaVersionDesItem
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            Viewstate("NroPedido") = Mid(Request.Params("KeyReg"), 1, 8)
            Viewstate("NroPropuesta") = Mid(Request.Params("KeyReg"), 9, 2)
            Viewstate("NroVersion") = Mid(Request.Params("KeyReg"), 11, 2)
            Viewstate("NroDia") = Mid(Request.Params("KeyReg"), 13, 2)
            Viewstate("NroOrden") = Mid(Request.Params("KeyReg"), 15, 2)
            Viewstate("NroServicio") = Mid(Request.Params("KeyReg"), 17, 8)

            lblTitulo.Text = "Actualiza descripción del Servicio N° " & Trim(CStr(Viewstate("NroDia"))) + "-" + Trim(CStr(Viewstate("NroOrden"))) + "-" + Trim(CStr(Viewstate("NroServicio")))
            cmdGrabar.Text = "Grabar Detalle Publicado"

            EditaDesServicio()
            LeeNroVersion()
        End If
        With cmdGrabar
            .Attributes.Add("onClick", "getHTML()")
        End With
    End Sub

    Private Sub EditaDesServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If rbtDetPub.Checked Then
            da.SelectCommand.CommandText = "VTA_VersionDesServicioPub_S"
        ElseIf rbtRes1.Checked Then
            da.SelectCommand.CommandText = "VTA_VersionDesServicio_S"
        ElseIf rbtDet1.Checked Then
            da.SelectCommand.CommandText = "VTA_VersionDesServicioDet_S"
        End If
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        da.SelectCommand.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Viewstate("NroDia")
        da.SelectCommand.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Viewstate("NroOrden")
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Viewstate("NroServicio")
        dsEdit.Clear()
        da.Fill(dsEdit, "DVERSION")
        lblDesProveedor.DataBind()
        txtRTB.DataBind()
    End Sub

    Private Sub LeeNroVersion()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_VersionLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ViewState("DesVersion") = dr.GetValue(dr.GetOrdinal("DesVersion"))
                ViewState("FlagPublica") = dr.GetValue(dr.GetOrdinal("FlagPublica"))
                ViewState("FlagEdita") = dr.GetValue(dr.GetOrdinal("FlagEdita"))
                ViewState("StsVersion") = dr.GetValue(dr.GetOrdinal("StsVersion"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim strRTB As String
        strRTB = txtRTB.Text

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionDesItem_U"
        cd.CommandType = CommandType.StoredProcedure
        If rbtDetPub.Checked Then
            cd.CommandText = "VTA_VersionDesServicioPub_U"
            cd.Parameters.Add("@DesServicioPub", SqlDbType.Text).Value = strRTB
        ElseIf rbtRes1.Checked Then
            cd.CommandText = "VTA_VersionDesServicio_U"
            cd.Parameters.Add("@DesServicio", SqlDbType.VarChar, 800).Value = strRTB
        ElseIf rbtDet1.Checked Then
            cd.CommandText = "VTA_VersionDesServicioDet_U"
            cd.Parameters.Add("@DesServicioDet", SqlDbType.Text).Value = strRTB
        End If


        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Viewstate("NroDia")
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Viewstate("NroOrden")
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Viewstate("NroServicio")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblmsg.Text) = "OK" Then
            '            PantallaAnterior()
        End If
    End Sub

    Private Sub PantallaAnterior()
        Response.Redirect("VtaVersionServicio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion") & _
            "&DesPropuesta=" & Viewstate("DesPropuesta") & _
            "&FlagPublica=" & Viewstate("FlagPublica") & _
            "&FlagEdita=" & Viewstate("FlagEdita") & _
            "&StsVersion=" & Viewstate("StsVersion"))
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PantallaAnterior()
    End Sub

    Private Sub lbtResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtResumen.Click
        cmdGrabar.Text = "Grabar " & lbtResumen.Text
        rbtRes1.Checked = True
        rbtDet1.Checked = False
        rbtDetPub.Checked = False
        EditaDesServicio()
    End Sub

    Private Sub lbtDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetalle.Click
        cmdGrabar.Text = "Grabar " & lbtDetalle.Text
        rbtRes1.Checked = False
        rbtDet1.Checked = True
        rbtDetPub.Checked = False
        EditaDesServicio()

    End Sub

    Private Sub lbtDetallePublicado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDetallePublicado.Click
        cmdGrabar.Text = "Grabar " & lbtDetallePublicado.Text
        rbtRes1.Checked = False
        rbtDet1.Checked = False
        rbtDetPub.Checked = True
        EditaDesServicio()
    End Sub

    Private Sub lbtFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFicha.Click
        PantallaAnterior()
    End Sub



End Class
