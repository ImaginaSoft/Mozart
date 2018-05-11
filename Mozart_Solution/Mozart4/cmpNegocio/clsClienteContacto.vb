Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsClienteContacto
    Private iCodCliente As String
    Private sCodContacto As String
    Private sNomContacto As String
    Private sStsContacto As String
    Private sClave As String
    Private sEmailContacto As String
    Private sTelefono1 As String
    Private sNroOrden As String
    Private sFlagExperto As String
    Private sCodUsuario As String

    Private sIPAddress As String

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property CodCliente() As Integer
        Get
            Return iCodCliente
        End Get
        Set(ByVal Value As Integer)
            iCodCliente = Value
        End Set
    End Property

    Property CodContacto() As String
        Get
            Return sCodContacto
        End Get
        Set(ByVal Value As String)
            sCodContacto = CStr(Value)
        End Set
    End Property

    Property NomContacto() As String
        Get
            Return sNomContacto
        End Get
        Set(ByVal Value As String)
            sNomContacto = CStr(Value)
        End Set
    End Property

    Property StsContacto() As String
        Get
            Return sStsContacto
        End Get
        Set(ByVal Value As String)
            sStsContacto = CStr(Value)
        End Set
    End Property

    Property Clave() As String
        Get
            Return sClave
        End Get
        Set(ByVal Value As String)
            sClave = CStr(Value)
        End Set
    End Property

    Property EmailContacto() As String
        Get
            Return sEmailContacto
        End Get
        Set(ByVal Value As String)
            sEmailContacto = CStr(Value)
        End Set
    End Property
    Property Telefono1() As String
        Get
            Return sTelefono1
        End Get
        Set(ByVal Value As String)
            sTelefono1 = CStr(Value)
        End Set
    End Property

    Property NroOrden() As String
        Get
            Return sNroOrden
        End Get
        Set(ByVal Value As String)
            sNroOrden = CStr(Value)
        End Set
    End Property

    Property IPAddress() As String
        Get
            Return sIPAddress
        End Get
        Set(ByVal Value As String)
            sIPAddress = CStr(Value)
        End Set
    End Property
    Property FlagExperto() As String
        Get
            Return sFlagExperto
        End Get
        Set(ByVal Value As String)
            sFlagExperto = CStr(Value)
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

    Function Cargar(ByVal pCodCliente As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ClienteContacto_S", New SqlParameter("@CodCliente", pCodCliente))
        Return (ds)
    End Function


    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_ClienteContacto_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = sCodContacto
        cd.Parameters.Add("@NomContacto", SqlDbType.VarChar, 50).Value = sNomContacto
        cd.Parameters.Add("@EmailContacto", SqlDbType.VarChar, 50).Value = sEmailContacto
        cd.Parameters.Add("@Telefono1", SqlDbType.VarChar, 25).Value = sTelefono1
        cd.Parameters.Add("@StsContacto", SqlDbType.Char, 1).Value = sStsContacto
        cd.Parameters.Add("@NroOrden", SqlDbType.TinyInt).Value = sNroOrden
        cd.Parameters.Add("@FlagExperto", SqlDbType.Char, 1).Value = sFlagExperto
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

    Function Borrar(ByVal pCodCliente As Integer, ByVal pCodContacto As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_ClienteContacto_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = pCodCliente
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = pCodContacto
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

    Function CambiarClave() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_ClienteContactoClave_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = sCodContacto
        cd.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = sClave
        cd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 25).Value = sIPAddress
        cd.Parameters.Add("@CodUsuarioSys", SqlDbType.Char, 15).Value = sCodUsuario
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