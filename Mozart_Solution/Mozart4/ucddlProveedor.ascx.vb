Imports System.Data.SqlClient
Imports System.Data

Partial Class ucddlProveedor
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wCodProveedor As Integer = 0
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CargaProveedor()
        End If
    End Sub
    Private Sub CargaProveedor()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "CPP_Proveedor_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        da.Fill(ds, "Proveedor")
        ddlProveedor.DataSource = ds.Tables("Proveedor")
        ddlProveedor.DataBind()

        'Para setear default Linea
        If wCodProveedor > 0 Then
            ddlProveedor.Items.FindByValue(wCodProveedor).Selected = True
        End If
    End Sub

    'Obtener el Proveedor
    Public Property CodProveedor() As Integer
        Get
            Return ddlProveedor.SelectedItem.Value
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property

    'Pasar el default Proveedor
    Public Property pCodProveedor() As Integer
        Get
        End Get
        Set(ByVal Value As Integer)
            wCodProveedor = Value
        End Set
    End Property


End Class
