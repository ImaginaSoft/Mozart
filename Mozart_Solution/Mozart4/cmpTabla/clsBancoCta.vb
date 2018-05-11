Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsBancoCta
    Private sCodBanco As String
    Private sSecBanco As String
    Private sTipoCuenta As String
    Private sNroCuenta As String
    Private sCodMoneda As String
    Private sFlagCtaDeposito As String
    Private sStsCuenta As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodBanco() As String
        Get
            Return sCodBanco
        End Get
        Set(ByVal Value As String)
            sCodBanco = CStr(Value)
        End Set
    End Property

    Property SecBanco() As String
        Get
            Return sSecBanco
        End Get
        Set(ByVal Value As String)
            sSecBanco = CStr(Value)
        End Set
    End Property

    Property TipoCuenta() As String
        Get
            Return sTipoCuenta
        End Get
        Set(ByVal Value As String)
            sTipoCuenta = CStr(Value)
        End Set
    End Property

    Property NroCuenta() As String
        Get
            Return sNroCuenta
        End Get
        Set(ByVal Value As String)
            sNroCuenta = CStr(Value)
        End Set
    End Property

    Property CodMoneda() As String
        Get
            Return sCodMoneda
        End Get
        Set(ByVal Value As String)
            sCodMoneda = CStr(Value)
        End Set
    End Property

    Property FlagCtaDeposito() As String
        Get
            Return sFlagCtaDeposito
        End Get
        Set(ByVal Value As String)
            sFlagCtaDeposito = CStr(Value)
        End Set
    End Property

    Property StsCuenta() As String
        Get
            Return sStsCuenta
        End Get
        Set(ByVal Value As String)
            sStsCuenta = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_BancoCuentaCodBanco_S", New SqlParameter("@CodBanco", sCodBanco))
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_DBancoCuenta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = sCodBanco
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = sSecBanco
        cd.Parameters.Add("@TipoCuenta", SqlDbType.Char, 20).Value = sTipoCuenta
        cd.Parameters.Add("@NroCuenta", SqlDbType.VarChar, 50).Value = sNroCuenta
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = sCodMoneda
        cd.Parameters.Add("@FlagCtaDeposito", SqlDbType.Char, 1).Value = sFlagCtaDeposito
        cd.Parameters.Add("@StsCuenta", SqlDbType.Char, 1).Value = sStsCuenta
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
        cd.CommandText = "TAB_DBancoCuenta_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = sCodBanco
        cd.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = sSecBanco
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