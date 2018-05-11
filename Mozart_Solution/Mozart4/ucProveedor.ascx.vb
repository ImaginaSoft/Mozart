Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucProveedor
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            If Len(Trim(Request.Params("CodProveedor"))) > 0 Then
                Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Else
                Viewstate("CodProveedor") = Session("CodProveedor")
            End If
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()

        'Viewstate("NroServicio")
        Dim wNombre, wcontacto, wfono, wemail As String
        Dim wdate As Date

        'CARGAMOS LA DATA CON UN QUERY
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPP_ProveedorContacto1_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                wNombre = dr.GetValue(dr.GetOrdinal("NomProveedor"))
                wcontacto = dr.GetValue(dr.GetOrdinal("Contacto1"))
                wfono = dr.GetValue(dr.GetOrdinal("Telefono1"))
                wemail = dr.GetValue(dr.GetOrdinal("Email1"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        lblCod.Text = Trim(ViewState("CodProveedor"))
        lblNombre.Text = wNombre
        lblContacto.Text = wcontacto
        lblTelefono.Text = wfono
        lblEmail.Text = wemail
    End Sub

    Public Property Codigo() As String
        Get
            Return CInt(Trim(Viewstate("CodProveedor")))
        End Get
        Set(ByVal Value As String)
            lblCod.Text = CStr(Value)
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return lblNombre.Text
        End Get
        Set(ByVal Value As String)
            lblNombre.Text = CStr(Value)
        End Set
    End Property


End Class
