Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class comComprobanteVentasImprime
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim wmes, wano, wdia As Integer
            Dim wnommes As String
            Viewstate("Fecha") = Request.Params("Fecha")
            lblNombre.Text = Request.Params("Nombre")
            lblGlosa.Text = Request.Params("Glosa")
            lblDNI.Text = Request.Params("DNI")
            lblTotal.Text = Request.Params("Total")
            lblTotal1.Text = Request.Params("Total")
            lblAno.Text = Mid(Viewstate("Fecha"), 3, 2)
            wmes = CInt(Mid(Viewstate("Fecha"), 5, 2))
            lblDia.Text = Mid(Viewstate("Fecha"), 7, 2)
            lblMes.Text = Mes(wmes)
        End If
    End Sub

    Private Function Mes(ByVal pMes As Integer) As String
        If pMes = 0 Then
            Return ""
        End If
        If pMes = 1 Then
            Return "Enero"
        End If
        If pMes = 2 Then
            Return "Febrero"
        End If
        If pMes = 3 Then
            Return "Marzo"
        End If
        If pMes = 4 Then
            Return "Abril"
        End If
        If pMes = 5 Then
            Return "Mayo"
        End If
        If pMes = 6 Then
            Return "Junio"
        End If
        If pMes = 7 Then
            Return "Julio"
        End If
        If pMes = 8 Then
            Return "Agosto"
        End If
        If pMes = 9 Then
            Return "Setiembre"
        End If
        If pMes = 10 Then
            Return "Octubre"
        End If
        If pMes = 11 Then
            Return "Noviembre"
        End If
        If pMes = 12 Then
            Return "Diciembre"
        End If

    End Function

    Private Sub InitializeComponent()

    End Sub

End Class
