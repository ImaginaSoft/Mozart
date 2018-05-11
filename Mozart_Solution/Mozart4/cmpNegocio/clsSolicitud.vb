Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsSolicitud
    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function CargaxFchIngreso(ByVal pFechainicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(0).Value = pFechainicio
        arParms(1) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "AGE_SolicitudxFchIngreso_S", arParms)
        Return (ds)
    End Function

End Class