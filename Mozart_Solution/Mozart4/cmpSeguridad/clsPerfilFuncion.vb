Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPerfilFuncion
    Private sCodPerfil As String
    Private sCodFuncion As String
    Private sCodUsuario As String

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

    Property CodFuncion() As String
        Get
            Return sCodFuncion
        End Get
        Set(ByVal Value As String)
            sCodFuncion = CStr(Value)
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

    Function Cargar(ByVal pCodSistema As String, ByVal pCodPerfil As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodSistema", SqlDbType.Char, 3)
        arParms(0).Value = pCodSistema
        arParms(1) = New SqlParameter("@CodPerfil", SqlDbType.Char, 10)
        arParms(1).Value = pCodPerfil
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_PerfilFuncion_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "SEG_PerfilFuncion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char).Value = sCodPerfil
        cd.Parameters.Add("@CodFuncion", SqlDbType.Char).Value = sCodFuncion
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
        cd.CommandText = "SEG_PerfilFuncion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char).Value = sCodPerfil
        cd.Parameters.Add("@CodFuncion", SqlDbType.Char).Value = sCodFuncion
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
End Class