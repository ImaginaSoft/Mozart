Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsCierreVersion
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String
    Function SaldosTot(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoTot_S", arParms)
        Return (ds)
    End Function

    Function SaldosTot(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoTotxZonaVta_S", arParms)
        Return (ds)
    End Function

    Function SaldosTot(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodZonaVta As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        arParms(3) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(3).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoTotxZonaVtaVen_S", arParms)
        Return (ds)
    End Function

    Function SaldosTotVen(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoTotxVen_S", arParms)
        Return (ds)
    End Function


    Function SaldosDet(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoDet_S", arParms)
        Return (ds)
    End Function


    Function SaldosDet(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoDetxZonaVta_S", arParms)
        Return (ds)
    End Function

    Function SaldosDet(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodZonaVta As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        arParms(3) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(3).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoDetxZonaVtaVen_S", arParms)
        Return (ds)
    End Function

    Function SaldosDetVen(ByVal pNroPeriodoVtaIni As Integer, ByVal pNroPeriodoVtaFin As Integer, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPeriodoVtaIni", SqlDbType.Int)
        arParms(0).Value = pNroPeriodoVtaIni
        arParms(1) = New SqlParameter("@NroPeriodoVtaFin", SqlDbType.Int)
        arParms(1).Value = pNroPeriodoVtaFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_SaldosCierrePeriodoDetxVen_S", arParms)
        Return (ds)
    End Function

End Class
