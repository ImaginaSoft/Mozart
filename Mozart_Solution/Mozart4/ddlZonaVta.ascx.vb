Imports System.Data.SqlClient
Imports System.Data

Partial Class ddlZonaVta
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim sCodZonaVta As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CargaZonaVta()
        End If
    End Sub

    Private Sub CargaZonaVta()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_ZonaVtaxUsuario_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Dim ds As New DataSet
        da.Fill(ds, "ZonaVta")
        ddlZonaVta.DataSource = ds.Tables("ZonaVta")
        ddlZonaVta.DataBind()

        'Para setear Default Zona de Venta
        If sCodZonaVta <> "" Then
            ddlZonaVta.Items.FindByValue(sCodZonaVta).Selected = True
        End If
    End Sub

    'Obtener la Zona Vta
    Public Property CodZonaVta() As String
        Get
            Return ddlZonaVta.SelectedItem.Value
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    'Pasar el default Zona Vta
    Public Property pCodZonaVta() As String
        Get
        End Get
        Set(ByVal Value As String)
            sCodZonaVta = Value
        End Set
    End Property

End Class
