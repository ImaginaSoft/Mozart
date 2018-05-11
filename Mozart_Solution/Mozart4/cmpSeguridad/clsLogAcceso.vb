Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsLogAcceso
    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function CargaPeru4me(ByVal pFechaInicial As String, ByVal pFechaFinal As String, ByVal pEmail As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFinal
        arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(2).Value = pEmail
        arParms(3) = New SqlParameter("@CodVendedor", SqlDbType.VarChar, 15)
        arParms(3).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogAcceso_S", arParms)
        Return (ds)
    End Function

    Function CargaPeru4all(ByVal pFechaInicial As String, ByVal pFechaFinal As String, ByVal pEmail As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFinal
        arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(2).Value = pEmail
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogAccesoAge_S", arParms)
        Return (ds)
    End Function

    Function CargaVisa(ByVal pFechaInicial As String, ByVal pFechaFinal As String, ByVal pEmail As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFinal
        arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(2).Value = pEmail
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VISA_LogAcceso_S", arParms)
        Return (ds)
    End Function

    Function CargaMC(ByVal pFechaInicial As String, ByVal pFechaFinal As String, ByVal pEmail As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFinal
        arParms(2) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(2).Value = pEmail
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "MC_LogAcceso_S", arParms)
        Return (ds)
    End Function

End Class