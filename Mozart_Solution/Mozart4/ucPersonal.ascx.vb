Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucPersonal
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("cnMozart"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LeePersonal()
        End If
    End Sub

    Private Sub LeePersonal()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "PER_PersonalCodPersonal_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodPersonal", SqlDbType.Int).Value = Request.Params("CodPersonal")
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                Cod.Text = dr.GetValue(dr.GetOrdinal("CodPersonal"))
                lblNomPersonal.Text = dr.GetValue(dr.GetOrdinal("NomPersonal"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub


    Public Property CodPersonal() As Integer
        Get
            Return CInt(Cod.Text)
        End Get
        Set(ByVal Value As Integer)
            Cod.Text = CStr(Value)
        End Set
    End Property
End Class
