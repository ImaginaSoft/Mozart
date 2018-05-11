
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsLog
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Function CambiarTipoLog(ByVal pNroLog As Integer, ByVal pTipoLogNew As String, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_EmailClienteLeido_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroLog", SqlDbType.Int).Value = pNroLog
        cd.Parameters.Add("@TipoLogNew", SqlDbType.Char, 1).Value = pTipoLogNew
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
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



    Function LogEmailCliente(ByVal pFchInicio As String, ByVal pFchFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchInicio", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_EmailCliente_S", arParms)
        Return (ds)
    End Function

    Function LogEmailCliente(ByVal pFchInicio As String, ByVal pFchFin As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicio", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_EmailClienteVendedor_S", arParms)
        Return (ds)
    End Function

End Class