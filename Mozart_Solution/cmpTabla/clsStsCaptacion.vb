Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsStsCaptacion
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_StsCaptacion_S")
        Return (ds)
    End Function
End Class
