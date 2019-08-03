Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsAnoProceso
    Private sAnoProceso As String
    Private sStsAnoProceso As String
    Private sStsConsulta As String

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property AnoProceso() As String
        Get
            Return sAnoProceso
        End Get
        Set(ByVal Value As String)
            sAnoProceso = CStr(Value)
        End Set
    End Property

    Property StsAnoProceso() As String
        Get
            Return sStsAnoProceso
        End Get
        Set(ByVal Value As String)
            sStsAnoProceso = CStr(Value)
        End Set
    End Property

    Property StsConsulta() As String
        Get
            Return sStsConsulta
        End Get
        Set(ByVal Value As String)
            sStsConsulta = CStr(Value)
        End Set
    End Property

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_AnoProceso_S")
        Return (ds)
    End Function

    Function Consulta() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_AnoProcesoConsulta_S")
        Return (ds)
    End Function


    Function Grabar() As String
        If Not IsNumeric(sAnoProceso) Then
            Return ("Año Proceso es númerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_AnoProceso_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoProceso", SqlDbType.Int).Value = sAnoProceso
        cd.Parameters.Add("@StsAnoProceso", SqlDbType.Char, 1).Value = sStsAnoProceso
        cd.Parameters.Add("@StsConsulta", SqlDbType.Char, 1).Value = sStsConsulta
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

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_AnoProceso_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoProceso", SqlDbType.Int).Value = sAnoProceso
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