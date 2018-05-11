Imports System.Data.SqlClient
Imports System.Data

Partial Class ucLinea
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wCodLinea As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CargaLinea()
        End If
    End Sub
    Private Sub CargaLinea()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_LineaActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        da.Fill(ds, "Linea")
        ddlLinea.DataSource = ds.Tables("Linea")
        ddlLinea.DataBind()

        'Para setear default Linea
        If wCodLinea.Trim.Length > 0 Then
            ddlLinea.Items.FindByValue(wCodLinea).Selected = True
        End If
    End Sub

    'Obtener el Linea
    Public Property CodLinea() As String
        Get
            Return ddlLinea.SelectedItem.Value
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    'Pasar el default linea
    Public Property pCodLinea() As String
        Get
        End Get
        Set(ByVal Value As String)
            wCodLinea = Value
        End Set
    End Property

End Class
