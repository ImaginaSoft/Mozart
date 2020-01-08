Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPeriodoGasto
    Private sFchIniPeriodo As String
    Private sFchFinPeriodo As String
    Private sStsPeriodo As String
    Private mTipoCambio As Double
    Private sCodUsuario As String

    'Solo consultas 
    Private dFchIniPeriodo As Date
    Private dFchFinPeriodo As Date

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property cFchIniPeriodo() As String
        Get
            Return sFchIniPeriodo
        End Get
        Set(ByVal Value As String)
            sFchIniPeriodo = CStr(Value)
        End Set
    End Property

    Property cFchFinPeriodo() As String
        Get
            Return sFchFinPeriodo
        End Get
        Set(ByVal Value As String)
            sFchFinPeriodo = CStr(Value)
        End Set
    End Property

    Property StsPeriodo() As String
        Get
            Return sStsPeriodo
        End Get
        Set(ByVal Value As String)
            sStsPeriodo = CStr(Value)
        End Set
    End Property

    Property TipoCambio() As Double
        Get
            Return mTipoCambio
        End Get
        Set(ByVal Value As Double)
            mTipoCambio = Value
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

    ' Solo consultas
    Property FchIniPeriodo() As Date
        Get
            Return dFchIniPeriodo
        End Get
        Set(ByVal Value As Date)
            dFchIniPeriodo = Value
        End Set
    End Property

    Property FchFinPeriodo() As Date
        Get
            Return dFchFinPeriodo
        End Get
        Set(ByVal Value As Date)
            dFchFinPeriodo = Value
        End Set
    End Property


    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PeriodoGasto_S")
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PeriodoGasto_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FchIniPeriodo", SqlDbType.Char).Value = sFchIniPeriodo
        cd.Parameters.Add("@FchFinPeriodo", SqlDbType.Char).Value = sFchFinPeriodo
        cd.Parameters.Add("@StsPeriodo", SqlDbType.Char, 1).Value = sStsPeriodo
        cd.Parameters.Add("@TipoCambio", SqlDbType.Money).Value = mTipoCambio
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

    Function Borrar(ByVal pFchIniPeriodo As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PeriodoGasto_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FchIniPeriodo", SqlDbType.Char).Value = pFchIniPeriodo
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