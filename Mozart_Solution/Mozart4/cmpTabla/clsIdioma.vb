Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsIdioma
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Private sMsg As String


    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_IdiomaDDL_S")
        Return (ds)
    End Function
End Class