Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas
Public Class clsTipoCambio
    Dim sMsg As String

    Private sFecha As String
    Private sTipoCambioVta As String
    Private sCodUsuario As String
    Dim objRutina As New clsRutinas
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Property Fecha() As String
        Get
            Return sFecha
        End Get
        Set(ByVal Value As String)
            sFecha = CStr(Value)
        End Set
    End Property

    Property TipoCambioVta() As String
        Get
            Return sTipoCambioVta
        End Get
        Set(ByVal Value As String)
            sTipoCambioVta = CStr(Value)
        End Set
    End Property

    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    Function CargaxMesAno(ByVal pAno As Integer, ByVal pMes As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Ano", SqlDbType.Int)
        arParms(0).Value = pAno
        arParms(1) = New SqlParameter("@Mes", SqlDbType.Int)
        arParms(1).Value = pMes
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoCambioxAnoMes_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        If sFecha.Trim = "" Then
            Return ("Fecha es obligatorio")
        End If
        If sTipoCambioVta.Trim = "" Then
            Return ("Tipo cambio es obligatorio")
        End If
        If Not IsNumeric(sTipoCambioVta) Then
            Return ("Tipo cambio es dato númerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoCambio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = sFecha
        cd.Parameters.Add("@TipoCambioVta", SqlDbType.Money).Value = sTipoCambioVta
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
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

    Function Borrar(ByVal pFecha As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoCambio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = pFecha
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