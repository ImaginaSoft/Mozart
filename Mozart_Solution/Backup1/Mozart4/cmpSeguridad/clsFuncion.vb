Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsFuncion
    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function Cargar(ByVal pCodSistema As String, ByVal pCodPerfil As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodSistema", SqlDbType.Char, 3)
        arParms(0).Value = pCodSistema
        arParms(1) = New SqlParameter("@CodPerfil", SqlDbType.Char, 10)
        arParms(1).Value = pCodPerfil
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_Funcion_S", arParms)
        Return (ds)
    End Function

End Class