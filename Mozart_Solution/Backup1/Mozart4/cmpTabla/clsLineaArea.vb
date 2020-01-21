Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsLineaArea
    Private sCodLinea As String
    Private sNomLinea As String
    Private sCodProveedor As String
    Private sStsLinea As String
    Private sRuc As String
    Private sCodProReembolso As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodLinea() As String
        Get
            Return sCodLinea
        End Get
        Set(ByVal Value As String)
            sCodLinea = CStr(Value)
        End Set
    End Property

    Property NomLinea() As String
        Get
            Return sNomLinea
        End Get
        Set(ByVal Value As String)
            sNomLinea = CStr(Value)
        End Set
    End Property

    Property CodProveedor() As String
        Get
            Return sCodProveedor
        End Get
        Set(ByVal Value As String)
            sCodProveedor = CStr(Value)
        End Set
    End Property

    Property StsLinea() As String
        Get
            Return sStsLinea
        End Get
        Set(ByVal Value As String)
            sStsLinea = CStr(Value)
        End Set
    End Property

    Property Ruc() As String
        Get
            Return sRuc
        End Get
        Set(ByVal Value As String)
            sRuc = CStr(Value)
        End Set
    End Property

    Property CodProReembolso() As String
        Get
            Return sCodProReembolso
        End Get
        Set(ByVal Value As String)
            sCodProReembolso = CStr(Value)
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

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Linea_S")
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Linea_I"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodLinea", SqlDbType.Char, 3).Value = sCodLinea
        cd.Parameters.Add("@NomLinea", SqlDbType.VarChar, 50).Value = sNomLinea
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = sCodProveedor
        cd.Parameters.Add("@Ruc", SqlDbType.Char, 15).Value = sRuc
        cd.Parameters.Add("@StsLinea", SqlDbType.Char, 1).Value = sStsLinea
        cd.Parameters.Add("@CodProReembolso", SqlDbType.Int).Value = sCodProReembolso
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
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Linea_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodLinea", SqlDbType.Char, 3).Value = sCodLinea
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