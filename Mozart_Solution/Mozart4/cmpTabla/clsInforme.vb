Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsInforme
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Function PYG(ByVal pCodInforme As Integer, ByVal pAnoProceso As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodInforme", SqlDbType.Int)
        arParms(0).Value = pCodInforme
        arParms(1) = New SqlParameter("@AnoProceso", SqlDbType.Int)
        arParms(1).Value = pAnoProceso

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPP_PYG_S", arParms)
        Return (ds)
    End Function

    'solo muestra 10 Ingresos y 20 Gastos operativos
    Function PYGparcial(ByVal pCodInforme As Integer, ByVal pAnoProceso As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodInforme", SqlDbType.Int)
        arParms(0).Value = pCodInforme
        arParms(1) = New SqlParameter("@AnoProceso", SqlDbType.Int)
        arParms(1).Value = pAnoProceso

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPP_PYGparcial_S", arParms)
        Return (ds)
    End Function

    Function Actualiza(ByVal pFechaInicio As String, ByVal pFechaFin As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_CierreMesInforme_S"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = pFechaInicio
        cd.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = pFechaFin
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