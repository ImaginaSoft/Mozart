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

Partial Class comRegVentas
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
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
        ddlCalendario.Items.Clear()
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
        Dim wMesCerrado As Boolean = False

        If Mes(ddlCalendario.SelectedItem.Value) < 10 Then
            wMes = "0" & CStr(Mes(ddlCalendario.SelectedItem.Value))
        Else
            wMes = CStr(Mes(ddlCalendario.SelectedItem.Value))
        End If

        ' Verifica si Mes Esta Cerrado
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_CierreMesProcesado_S"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@NroDocs", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = Trim(wMes)
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@NroDocs").Value > 0 Then
                wMesCerrado = True
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()


        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "COM_ComprobanteMes_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = "C" 'Anteriores "P"
        da.SelectCommand.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
        da.SelectCommand.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = Trim(wMes)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgDocumento.DataKeyField = "Correlativo"

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()

        If wMesCerrado Then
            dgDocumento.Columns(15).Visible = False
            lblmsg.Text = "Mes cerrado con " & CStr(nReg) + " Documento(s) "
        Else
            dgDocumento.Columns(15).Visible = True
            lblmsg.Text = CStr(nReg) + " Documento(s)"
        End If

        If nReg = 0 Then
            lnkNomPais.Visible = False
        Else
            lnkNomPais.Visible  = True
        End If

    End Sub
    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        Response.Redirect("comComprobanteVentas.aspx" & _
                   "?Opcion=" & "Modifica" & _
                   "&Correlativo=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(14).Text)
    End Sub
    Private Sub lnkNuevoComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNuevoComprobante.Click
        Response.Redirect("comComprobanteVentas.aspx" & _
        "?Opcion=" & "Nuevo")
    End Sub


    Private Sub InitializeComponent()

    End Sub

    Private Sub dgDocumento_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDocumento.DeleteCommand
        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "COM_Comprobante_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = dgDocumento.DataKeys(e.Item.ItemIndex)
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = ""
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = ""
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

        If lblmsg.Text.Trim = "OK" Then
            lblmsg.CssClass = "msg"
            CargaDocumentos()
        Else
            lblmsg.CssClass = "error"
        End If
    End Sub

    Private Sub dgDocumento_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgDocumento.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

    Protected Sub lnkNomPais_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNomPais.Click
        Dim wMes As String

        If Mes(ddlCalendario.SelectedItem.Value) < 10 Then
            wMes = "0" & CStr(Mes(ddlCalendario.SelectedItem.Value))
        Else
            wMes = CStr(Mes(ddlCalendario.SelectedItem.Value))
        End If

        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "COM_ComprobanteMesNomPais_U"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 2).Value = "C"
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = txtano.Text
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = wMes
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

        If lblmsg.Text.Trim = "OK" Then
            lblmsg.CssClass = "msg"
            CargaDocumentos()
        Else
            lblmsg.CssClass = "error"
        End If

    End Sub
End Class
