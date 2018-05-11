Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPerfil
    Private sCodPerfil As String
    Private sNomPerfil As String
    Private sStsPerfil As String
    Private sCodUsuario As String
    ' solo para leer
    Private sFchSys As Date
    Private sNomStsPerfil As String

    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property CodPerfil() As String
        Get
            Return sCodPerfil
        End Get
        Set(ByVal Value As String)
            sCodPerfil = CStr(Value)
        End Set
    End Property

    Property NomPerfil() As String
        Get
            Return sNomPerfil
        End Get
        Set(ByVal Value As String)
            sNomPerfil = CStr(Value)
        End Set
    End Property

    Property StsPerfil() As String
        Get
            Return sStsPerfil
        End Get
        Set(ByVal Value As String)
            sStsPerfil = CStr(Value)
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

    Property FchSys() As Date
        Get
            Return sFchSys
        End Get
        Set(ByVal Value As Date)
            sFchSys = Value
        End Set
    End Property

    Property NomStsPerfil() As String
        Get
            Return sNomStsPerfil
        End Get
        Set(ByVal Value As String)
            sNomStsPerfil = CStr(Value)
        End Set
    End Property

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_Perfil_S")
        Return (ds)
    End Function

    Function Cargar(ByVal pCodPerfil As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_PerfilFuncion_S", New SqlParameter("@CodPerfil", pCodPerfil))
        Return (ds)
    End Function

    Function Grabar() As String
        If sCodPerfil.Trim.Length = 0 Then
            Return ("Código perfil es obligatorio")
        End If
        If sNomPerfil.Trim.Length = 0 Then
            Return ("Nombre perfil es obligatorio")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "SEG_PERFIL_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char).Value = sCodPerfil
        cd.Parameters.Add("@NomPerfil", SqlDbType.VarChar).Value = sNomPerfil
        cd.Parameters.Add("@StsPerfil", SqlDbType.Char, 1).Value = sStsPerfil
        cd.Parameters.Add("@CodUsuario", SqlDbType.VarChar, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
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
        cd.CommandText = "SEG_Perfil_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 1000)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char, 10).Value = sCodPerfil
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

    Function Editar() As String
        sMsg = "No existe registro " & sCodPerfil

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_LeePerfil_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char, 10).Value = sCodPerfil
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sCodPerfil = dr.GetValue(dr.GetOrdinal("CodPerfil"))
                sNomPerfil = dr.GetValue(dr.GetOrdinal("NomPerfil"))
                sStsPerfil = dr.GetValue(dr.GetOrdinal("StsPerfil"))
                sNomStsPerfil = dr.GetValue(dr.GetOrdinal("NomStsPerfil"))
                sFchSys = dr.GetValue(dr.GetOrdinal("FchSys"))
                sCodUsuario = dr.GetValue(dr.GetOrdinal("CodUsuario"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function
End Class