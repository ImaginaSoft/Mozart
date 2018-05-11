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

Partial Class comCierreMes
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Dim ObjRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            'Carga de Mes
            Dim wNow As String
            Dim wmes, wano As Integer
            'Obtenemos la Fecha Inicial
            wNow = ObjRutina.fechayyyymmdd(ObjRutina.fechaddmmyyyy(0))
            wmes = CInt(Mid(wNow, 5, 2))
            wano = CInt(Mid(wNow, 1, 4))
            txtano.Text = wano
            CargaMes(wmes)
            CargaDocumentos()
        End If
    End Sub
    Private Sub CargaMes(ByVal pMes As Integer)
        ddlCalendario.Items.Insert(0, New ListItem("Enero"))
        ddlCalendario.Items.Insert(1, New ListItem("Febrero"))
        ddlCalendario.Items.Insert(2, New ListItem("Marzo"))
        ddlCalendario.Items.Insert(3, New ListItem("Abril"))
        ddlCalendario.Items.Insert(4, New ListItem("Mayo"))
        ddlCalendario.Items.Insert(5, New ListItem("Junio"))
        ddlCalendario.Items.Insert(6, New ListItem("Julio"))
        ddlCalendario.Items.Insert(7, New ListItem("Agosto"))
        ddlCalendario.Items.Insert(8, New ListItem("Setiembre"))
        ddlCalendario.Items.Insert(9, New ListItem("Octubre"))
        ddlCalendario.Items.Insert(10, New ListItem("Noviembre"))
        ddlCalendario.Items.Insert(11, New ListItem("Diciembre"))

        If pMes = 1 Then
            ddlCalendario.Items.FindByValue("Enero").Selected = True
        End If
        If pMes = 2 Then
            ddlCalendario.Items.FindByValue("Febrero").Selected = True
        End If
        If pMes = 3 Then
            ddlCalendario.Items.FindByValue("Marzo").Selected = True
        End If
        If pMes = 4 Then
            ddlCalendario.Items.FindByValue("Abril").Selected = True
        End If

        If pMes = 5 Then
            ddlCalendario.Items.FindByValue("Mayo").Selected = True
        End If
        If pMes = 6 Then
            ddlCalendario.Items.FindByValue("Junio").Selected = True
        End If
        If pMes = 7 Then
            ddlCalendario.Items.FindByValue("Julio").Selected = True
        End If
        If pMes = 8 Then
            ddlCalendario.Items.FindByValue("Agosto").Selected = True
        End If
        If pMes = 9 Then
            ddlCalendario.Items.FindByValue("Setiembre").Selected = True
        End If
        If pMes = 10 Then
            ddlCalendario.Items.FindByValue("Octubre").Selected = True
        End If
        If pMes = 11 Then
            ddlCalendario.Items.FindByValue("Noviembre").Selected = True
        End If
        If pMes = 12 Then
            ddlCalendario.Items.FindByValue("Diciembre").Selected = True
        End If
    End Sub
    Private Function Mes(ByVal pMes As String) As Integer
        If pMes = "Enero" Then
            Return 1
        End If
        If pMes = "Febrero" Then
            Return 2
        End If
        If pMes = "Marzo" Then
            Return 3
        End If
        If pMes = "Abril" Then
            Return 4
        End If
        If pMes = "Mayo" Then
            Return 5
        End If
        If pMes = "Junio" Then
            Return 6
        End If
        If pMes = "Julio" Then
            Return 7
        End If
        If pMes = "Agosto" Then
            Return 8
        End If
        If pMes = "Setiembre" Then
            Return 9
        End If
        If pMes = "Octubre" Then
            Return 10
        End If
        If pMes = "Noviembre" Then
            Return 11
        End If
        If pMes = "Diciembre" Then
            Return 12
        End If

    End Function
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub
    Private Sub CargaDocumentos()

        Dim wMes As String
        If Mes(ddlCalendario.SelectedItem.Value) < 10 Then
            wMes = "0" & CStr(Mes(ddlCalendario.SelectedItem.Value))
        Else
            wMes = CStr(Mes(ddlCalendario.SelectedItem.Value))
        End If

        lblMesCierre.Text = wMes
        lblAnoCierre.Text = txtano.Text

        'Revisa si Año-Mes fue cerrado
        Dim wStsCierre As String

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_CierreMesProcesado_S"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@NroDocs", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = lblAnoCierre.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = lblMesCierre.Text
        Try
            cn.Open()
            cd.ExecuteNonQuery()
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
            Return
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
            Return
        End Try
        cn.Close()

        lblmsg.Text = ""
        If cd.Parameters("@NroDocs").Value > 0 Then
            'Mes Cerrado
            wStsCierre = "C"
            'cmdCierre.Text = Trim(ddlCalendario.SelectedItem.Text) & " " & txtano.Text & " esta Cerrado"
            cmdCierre.Enabled = False
            lblmsg.Text = Trim(ddlCalendario.SelectedItem.Text) & " " & txtano.Text & " esta Cerrado"
        Else
            'Mes Pendiente de Cierre
            wStsCierre = "P"
            cmdCierre.Text = "Procesa Cierre de " & Trim(ddlCalendario.SelectedItem.Text) & " " & txtano.Text
            cmdCierre.Enabled = True
        End If


        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "COM_CierreMes_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C"
        da.SelectCommand.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = lblAnoCierre.Text
        da.SelectCommand.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = lblMesCierre.Text
        da.SelectCommand.Parameters.Add("@StsCierre", SqlDbType.Char, 1).Value = wStsCierre
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Ventas")
        dgVentas.DataSource = ds
        dgVentas.DataBind()

        Dim da2 As New SqlDataAdapter
        da2.SelectCommand = New SqlCommand
        da2.SelectCommand.Connection = cn
        da2.SelectCommand.CommandType = CommandType.StoredProcedure
        da2.SelectCommand.CommandText = "COM_CierreMes_S"
        da2.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "P"
        da2.SelectCommand.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = lblAnoCierre.Text
        da2.SelectCommand.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = lblMesCierre.Text
        da2.SelectCommand.Parameters.Add("@StsCierre", SqlDbType.Char, 1).Value = wStsCierre
        Dim ds2 As New DataSet
        Dim nReg2 As Integer = da2.Fill(ds2, "Compras")
        dgCompras.DataSource = ds2
        dgCompras.DataBind()


    End Sub

    Private Sub cmdCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCierre.Click

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_CierreMes_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = lblAnoCierre.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = lblMesCierre.Text
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
            lblmsg.Text = "Proceso de cierre de mes termino OK."
        End If

    End Sub

End Class
