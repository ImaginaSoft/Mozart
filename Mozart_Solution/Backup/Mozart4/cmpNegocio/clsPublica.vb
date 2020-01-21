
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPublica
    Dim sMsg As String

    Function GrabaFchRpta(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPublicaRpta_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = pNroPropuesta
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function GrabaFchRpta(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionPublicaRpta_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = pNroVersion
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function
End Class