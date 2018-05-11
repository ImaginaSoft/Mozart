Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Data.SqlClient

Partial Class VtaPropuestaDesItem
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
            Viewstate("NroDia") = Mid(Request.Params("KeyReg"), 11, 2)
            Viewstate("NroOrden") = Mid(Request.Params("KeyReg"), 13, 2)
            Viewstate("NroServicio") = Mid(Request.Params("KeyReg"), 15, 8)

            lblTitulo.Text = "Actualiza descripción del Servicio N° " & Trim(CStr(Viewstate("NroDia"))) + "-" + Trim(CStr(Viewstate("NroOrden"))) + "-" + Trim(CStr(Viewstate("NroServicio")))

            EditaDesServicio()
            LeeNroPropuesta()
        End If
    End Sub

    Private Sub EditaDesServicio()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PropuestaDesItem_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Viewstate("NroDia")
        da.SelectCommand.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Viewstate("NroOrden")
        da.SelectCommand.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Viewstate("NroServicio")
        dsEdit.Clear()
        da.Fill(dsEdit, "DPROPUESTA")
        FreeTextBox1.DataBind()
        txtDesServicio.DataBind()
        lblDesProveedor.DataBind()
    End Sub

    Private Sub LeeNroPropuesta()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                ViewState("DesPropuesta") = dr.GetValue(dr.GetOrdinal("DesPropuesta"))
                ViewState("FlagPublica") = dr.GetValue(dr.GetOrdinal("FlagPublica"))
                ViewState("FlagEdita") = dr.GetValue(dr.GetOrdinal("FlagEdita"))
                ViewState("StsPropuesta") = dr.GetValue(dr.GetOrdinal("StsPropuesta"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If txtDesServicio.Text.Trim.Length = 0 Then
            lblmsg.Text = "Descripción es obligatorio"
            Return
        End If


        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaDesItem_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = Viewstate("NroDia")
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = Viewstate("NroOrden")
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = Viewstate("NroServicio")
        cd.Parameters.Add("@DesServicio", SqlDbType.VarChar, 800).Value = txtDesServicio.Text
        cd.Parameters.Add("@DesServicioDet", SqlDbType.Text).Value = FreeTextBox1.Text
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
            PantallaAnterior()
        End If
    End Sub

    Private Sub PantallaAnterior()
        Response.Redirect("VtaPropuestaServicio.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&DesPropuesta=" & Viewstate("DesPropuesta") & _
            "&FlagPublica=" & Viewstate("FlagPublica") & _
            "&FlagEdita=" & Viewstate("FlagEdita") & _
            "&StsPropuesta=" & Viewstate("StsPropuesta"))
    End Sub

    Private Sub lbtServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PantallaAnterior()
    End Sub
End Class
