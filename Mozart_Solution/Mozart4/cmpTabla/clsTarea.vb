Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTarea
    Private sNroTarea As String
    Private sDesTarea As String
    Private sNrodias As String
    Private sDatoBase As String
    Private sStsTarea As String
    Private sCodArea As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property NroTarea() As String
        Get
            Return sNroTarea
        End Get
        Set(ByVal Value As String)
            sNroTarea = CStr(Value)
        End Set
    End Property

    Property DesTarea() As String
        Get
            Return sDesTarea
        End Get
        Set(ByVal Value As String)
            sDesTarea = CStr(Value)
        End Set
    End Property

    Property NroDias() As String
        Get
            Return sNrodias
        End Get
        Set(ByVal Value As String)
            sNrodias = CStr(Value)
        End Set
    End Property

    Property DatoBase() As String
        Get
            Return sDatoBase
        End Get
        Set(ByVal Value As String)
            sDatoBase = CStr(Value)
        End Set
    End Property

    Property StsTarea() As String
        Get
            Return sStsTarea
        End Get
        Set(ByVal Value As String)
            sStsTarea = CStr(Value)
        End Set
    End Property

    Property CodArea() As String
        Get
            Return sCodArea
        End Get
        Set(ByVal Value As String)
            sCodArea = CStr(Value)
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

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Tarea_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(sNroTarea) Then
            Return ("Nro de Tarea es numérico")
        End If
        If Not IsNumeric(sNrodias) Then
            Return ("Nro de días es numérico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Tarea_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroTarea", SqlDbType.SmallInt).Value = sNroTarea
        cd.Parameters.Add("@DesTarea", SqlDbType.VarChar, 50).Value = sDesTarea
        cd.Parameters.Add("@NroDias", SqlDbType.SmallInt).Value = sNrodias
        cd.Parameters.Add("@DatoBase", SqlDbType.VarChar, 50).Value = sDatoBase
        cd.Parameters.Add("@CodArea", SqlDbType.Char, 3).Value = sCodArea
        cd.Parameters.Add("@StsTarea", SqlDbType.Char, 1).Value = sStsTarea
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

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Tarea_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroTarea", SqlDbType.Char, 15).Value = sNroTarea
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

    Function CargaTareaVencida(ByVal pFchInicial As String, ByVal pFchFinal As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TareasPendiente_S", arParms)
        Return (ds)
    End Function

    Function CargaTareaVencida(ByVal pFchInicial As String, ByVal pFchFinal As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TareasPendientexVendedor_S", arParms)
        Return (ds)
    End Function

End Class