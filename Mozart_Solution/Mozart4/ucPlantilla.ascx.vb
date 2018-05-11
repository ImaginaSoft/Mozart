Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucPlantilla
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Len(Trim(Request.Params("NroPlantilla"))) > 0 Then
                Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            Else
                Viewstate("NroPlantilla") = Session("NroPlantilla")
            End If
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        lblNroPlantilla.Text = Viewstate("NroPlantilla")

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaNroPlantilla_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = CInt(Viewstate("NroPlantilla"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblDesPlantilla.Text = dr.GetValue(dr.GetOrdinal("DesPlantilla"))
                lblCodZonaVta.Text = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
                lblStsPlantilla.Text = dr.GetValue(dr.GetOrdinal("StsPlantilla"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub

    Public Property NroPlantilla() As Integer
        Get
            Return CInt(lblNroPlantilla.Text)
        End Get
        Set(ByVal Value As Integer)
            lblNroPlantilla.Text = CStr(Value)
        End Set
    End Property
    Public Property DesPlantilla() As String
        Get
            Return lblDesPlantilla.Text
        End Get
        Set(ByVal Value As String)
            lblDesPlantilla.Text = Value
        End Set
    End Property
    Public Property CodZonaVta() As String
        Get
            Return lblCodZonaVta.Text
        End Get
        Set(ByVal Value As String)
            lblCodZonaVta.Text = Value
        End Set
    End Property

    Public Property StsPlantilla() As String
        Get
            Return lblStsPlantilla.Text
        End Get
        Set(ByVal Value As String)
            lblStsPlantilla.Text = Value
        End Set
    End Property

End Class
