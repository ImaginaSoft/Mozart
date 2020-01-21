Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTarifaPeriodo
    Private iNroServicio As Integer
    Private sCodTarifa As String
    Private sFchIniTarifa As String
    Private sFchFinTarifa As String
    Private sDesTarifa As String
    Private sCodUsuario As String

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property NroServicio() As Integer
        Get
            Return iNroServicio
        End Get
        Set(ByVal Value As Integer)
            iNroServicio = Value
        End Set
    End Property

    Property CodTarifa() As String
        Get
            Return sCodTarifa
        End Get
        Set(ByVal Value As String)
            sCodTarifa = CStr(Value)
        End Set
    End Property


    Property FchIniPeriodo() As String
        Get
            Return sFchIniTarifa
        End Get
        Set(ByVal Value As String)
            sFchIniTarifa = CStr(Value)
        End Set
    End Property

    Property FchFinPeriodo() As String
        Get
            Return sFchFinTarifa
        End Get
        Set(ByVal Value As String)
            sFchFinTarifa = CStr(Value)
        End Set
    End Property

    Property DesTarifa() As String
        Get
            Return sDesTarifa
        End Get
        Set(ByVal Value As String)
            sDesTarifa = CStr(Value)
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

    Function CargarDDL(ByVal pNroServicio As Integer, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
        arParms(0).Value = pNroServicio
        arParms(1) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(1).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TarifaPeriodoVigente_S", arParms)
        Return (ds)
    End Function

    Function Cargar(ByVal pNroServicio As Integer, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
        arParms(0).Value = pNroServicio
        arParms(1) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(1).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TarifaPeriodo_S", arParms)
        Return (ds)
    End Function

    Function Grabar() As String
        If sFchIniTarifa.Trim.Length = 0 Then
            Return ("Fecha inicial es obligatorio")
        End If
        If sFchFinTarifa.Trim.Length = 0 Then
            Return ("Fecha termino es obligatorio")
        End If
        If sDesTarifa.Trim.Length = 0 Then
            Return ("Descripción de tarifa es obligatorio")
        End If
        If sCodTarifa.Trim.Length = 0 Then
            Return ("Código de tarifa es obligatorio")
        End If
        If Not IsNumeric(sCodTarifa) Then
            Return ("Código de tarifa es númerico")
        End If
        If sFchIniTarifa > sFchFinTarifa Then
            Return ("Fecha final de tarifa debe ser mayor a la fecha inicio")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_TarifaPeriodo_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodTarifa", SqlDbType.SmallInt).Value = sCodTarifa
        cd.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = sFchIniTarifa
        cd.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = sFchFinTarifa
        cd.Parameters.Add("@DesTarifa", SqlDbType.VarChar, 50).Value = sDesTarifa
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char).Value = sCodUsuario
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

    Function Borrar(ByVal pNroServicio As Integer, ByVal pCodTarifa As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_TarifaPeriodo_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = pNroServicio
        cd.Parameters.Add("@CodTarifa", SqlDbType.SmallInt).Value = pCodTarifa
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