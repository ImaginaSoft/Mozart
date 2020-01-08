Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsVendedor
    Private sCodVendedor As String
    Private sNomVendedor As String
    Private sEmail As String
    Private sTfEmergencia As String
    Private sStsVendedor As String
    Private sCodArea As String
    Private sCodVendedorOpe As String

    Private iNroOrdenStaff As String
    Private sCargoEsp As String
    Private sCargoIng As String
    Private sCodVendedorAlt1 As String
    Private sCodVendedorAlt2 As String
    Private sBlogVendedor As String

    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationSettings.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodVendedor() As String
        Get
            Return sCodVendedor
        End Get
        Set(ByVal Value As String)
            sCodVendedor = CStr(Value)
        End Set
    End Property

    Property NomVendedor() As String
        Get
            Return sNomVendedor
        End Get
        Set(ByVal Value As String)
            sNomVendedor = CStr(Value)
        End Set
    End Property

    Property Email() As String
        Get
            Return sEmail
        End Get
        Set(ByVal Value As String)
            sEmail = CStr(Value)
        End Set
    End Property

    Property TfEmergencia() As String
        Get
            Return sTfEmergencia
        End Get
        Set(ByVal Value As String)
            sTfEmergencia = CStr(Value)
        End Set
    End Property

    Property StsVendedor() As String
        Get
            Return sStsVendedor
        End Get
        Set(ByVal Value As String)
            sStsVendedor = CStr(Value)
        End Set
    End Property

    Property CodArea() As String
        Get
            Return sCodArea
        End Get
        Set(ByVal Value As String)
            sCodArea = CStr(Value)
        End Set
    End Property

    Property CodVendedorOpe() As String
        Get
            Return sCodVendedorOpe
        End Get
        Set(ByVal Value As String)
            sCodVendedorOpe = CStr(Value)
        End Set
    End Property

    Property NroOrdenStaff() As String
        Get
            Return iNroOrdenStaff
        End Get
        Set(ByVal Value As String)
            iNroOrdenStaff = CStr(Value)
        End Set
    End Property

    Property CargoEsp() As String
        Get
            Return sCargoEsp
        End Get
        Set(ByVal Value As String)
            sCargoEsp = CStr(Value)
        End Set
    End Property

    Property CargoIng() As String
        Get
            Return sCargoIng
        End Get
        Set(ByVal Value As String)
            sCargoIng = CStr(Value)
        End Set
    End Property

    Property CodVendedorAlt1() As String
        Get
            Return sCodVendedorAlt1
        End Get
        Set(ByVal Value As String)
            sCodVendedorAlt1 = CStr(Value)
        End Set
    End Property

    Property CodVendedorAlt2() As String
        Get
            Return sCodVendedorAlt2
        End Get
        Set(ByVal Value As String)
            sCodVendedorAlt2 = CStr(Value)
        End Set
    End Property

    Property BlogVendedor() As String
        Get
            Return sBlogVendedor
        End Get
        Set(ByVal Value As String)
            sBlogVendedor = CStr(Value)
        End Set
    End Property


    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_VendedorActivo_S")
        Return (ds)
    End Function

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Vendedor_S")
        Return (ds)
    End Function

    Function CargarTodos() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_VendedorTodos_S")
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Vendedor_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = sCodVendedor
        cd.Parameters.Add("@NomVendedor", SqlDbType.VarChar, 50).Value = sNomVendedor
        cd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = sEmail
        cd.Parameters.Add("@TfEmergencia", SqlDbType.VarChar, 50).Value = sTfEmergencia
        cd.Parameters.Add("@StsVendedor", SqlDbType.Char, 1).Value = sStsVendedor
        cd.Parameters.Add("@CodArea", SqlDbType.Char, 3).Value = sCodArea
        cd.Parameters.Add("@NroOrdenStaff", SqlDbType.TinyInt).Value = iNroOrdenStaff
        cd.Parameters.Add("@CargoEsp", SqlDbType.VarChar, 50).Value = sCargoEsp
        cd.Parameters.Add("@CargoIng", SqlDbType.VarChar, 50).Value = sCargoIng
        cd.Parameters.Add("@CodVendedorAlt1", SqlDbType.Char, 15).Value = sCodVendedorAlt1
        cd.Parameters.Add("@CodVendedorAlt2", SqlDbType.Char, 15).Value = sCodVendedorAlt2
        cd.Parameters.Add("@CodVendedorOpe", SqlDbType.Char, 15).Value = sCodVendedorOpe
        cd.Parameters.Add("@BlogVendedor", SqlDbType.VarChar, 50).Value = sBlogVendedor
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Vendedor_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = sCodVendedor
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function
End Class