Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ucCliente
    Inherits System.Web.UI.UserControl
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Len(Trim(Request.Params("CodCliente"))) > 0 Then
                Viewstate("CodCliente") = Request.Params("CodCliente")
            Else
                Viewstate("CodCliente") = Session("CodCliente")
            End If
            CargaData()
            'InscritoPrograma()
        End If
    End Sub

    Private Sub CargaData()
        Dim wNombre, WPaterno, wMaterno As String

        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpc_ClienteCodCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = CInt(Viewstate("CodCliente"))
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblNombre.Text = ViewState("CodCliente") & " " & _
                                 dr.GetValue(dr.GetOrdinal("NomCliente"))
                '                             dr.GetValue(dr.GetOrdinal("Nombre")) & " " & _
                '                            dr.GetValue(dr.GetOrdinal("Paterno")) & " " & _
                '                           dr.GetValue(dr.GetOrdinal("Materno"))
                lblEmail.Text = dr.GetValue(dr.GetOrdinal("Email"))

                ' If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchNacimiento"))) Then
                ' lblFecha.Text = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchNacimiento")))
                'End If

                lblFono.Text = dr.GetValue(dr.GetOrdinal("Telefono"))
                lblPais.Text = dr.GetValue(dr.GetOrdinal("NomPais"))
                lblNomVendedor.Text = dr.GetValue(dr.GetOrdinal("NomVendedor"))
                lblClaveCliente.Text = dr.GetValue(dr.GetOrdinal("ClaveCliente"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try

        Cod.Text = ViewState("CodCliente")
    End Sub

    'Private Sub InscritoPrograma()
    '    Dim cd As New SqlCommand
    '    cd.Connection = cn
    '    cd.CommandText = "P4I_LeeFichaCliente_S"
    '    cd.CommandType = CommandType.StoredProcedure'

    '        Dim pa As New SqlParameter

    '       pa = cd.Parameters.Add("@nreg", SqlDbType.Int)
    '      pa.Direction = ParameterDirection.Output
    '     pa.Value = 0
    '    cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
    '    Try
    '       cn.Open()
    '      cd.ExecuteNonQuery()
    '     If cd.Parameters("@nreg").Value = 1 Then
    '        lblFecha.Text = "SI"
    '            Else
    '               lblFecha.Text = "NO"
    '          End If
    '     Catch ex1 As System.Data.SqlClient.SqlException
    '        lblFecha.Text = "NO"
    '   Catch ex2 As System.Exception
    '      lblFecha.Text = "NO"
    ' End Try
    '   cn.Close()
    'End Sub


    Public Property Nombre() As String
        Get
            Return CStr(Trim(lblNombre.Text))
        End Get
        Set(ByVal Value As String)
            lblNombre.Text = CStr(Value)
        End Set
    End Property

    Public Property CodCliente() As Integer
        Get
            Return CInt(Cod.Text)
        End Get
        Set(ByVal Value As Integer)
            Cod.Text = CStr(Value)
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return lblPais.Text
        End Get
        Set(ByVal Value As String)
            lblPais.Text = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return lblFono.Text
        End Get
        Set(ByVal Value As String)
            lblFono.Text = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return lblEmail.Text
        End Get
        Set(ByVal Value As String)
            lblEmail.Text = Value
        End Set
    End Property

End Class
