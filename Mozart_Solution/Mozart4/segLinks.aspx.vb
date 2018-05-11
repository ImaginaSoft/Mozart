Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpSeguridad

Partial Class segLinks
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim NameServerBD As New String(System.Configuration.ConfigurationManager.AppSettings("NameServerBD"))
    Dim ObjRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            NomServidor()

            Dim objAutoriza As New clsAutoriza
            Dim objOpcion As New clsAutoriza.AutorizaInfo
            For Each objOpcion In objAutoriza.GetAutorizaList(Session("CodUsuario"))
                If Len(Trim(objOpcion.strPage)) = 0 Then
                    Label1.Text = Label1.Text & "<p><font color=crimson face=Arial size=2>" & objOpcion.strName & "</font> <br>"
                Else
                    Label1.Text = Label1.Text & "<a href=" & objOpcion.strPage & " target=main>" & objOpcion.strName & "</a> <br>"
                End If
            Next
        End If

    End Sub

    Private Sub NomServidor()
        ' Servidor Produccion VIVALDI
        Dim sNameServidor As String = ""
        Dim sLetra As String = ""
        Dim I As Integer = 13
        Do While sLetra <> ";" And I < 24
            sLetra = Mid(cn.ConnectionString, I, 1)
            If sLetra <> ";" Then
                sNameServidor = sNameServidor & sLetra
            End If
            I = I + 1
        Loop
        If sNameServidor = NameServerBD Then
            lblNomServidor.Text = ""
        Else
            lblNomServidor.Text = "Servidor " & sNameServidor
        End If
        'Ambiente de trabajo
        lblMandante.Text = Session("Mandante")
    End Sub

End Class
