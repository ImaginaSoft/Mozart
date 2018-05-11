Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPeriodoVta
    Dim sMsg As String

    Private sFchIniPeriodo As String
    Private sFchFinPeriodo As String
    Private sTrimestre As String
    Private sStsPeriodo As String
    Private sCodUsuario As String
    ' solo para consulta
    Private dFchIniPeriodo As Date
    Private dFchFinPeriodo As Date

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")


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

    Property Trimestre() As String
        Get
            Return sTrimestre
        End Get
        Set(ByVal Value As String)
            sTrimestre = CStr(Value)
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

    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    ' solo para consulta
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

    Function PeriodosVtas(ByVal pAno As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Ano ", SqlDbType.Int)
        arParms(0).Value = pAno
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PeriodoVtaxAnoDDL_S", arParms)
        Return (ds)
    End Function

    Function CargaxNroReg(ByVal pNroReg As Integer, ByVal pStsPeriodo As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroReg ", SqlDbType.Int)
        arParms(0).Value = pNroReg
        arParms(1) = New SqlParameter("@StsPeriodo", SqlDbType.Char, 1)
        arParms(1).Value = pStsPeriodo
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PeriodoVentaxNroReg_S", arParms)
        Return (ds)
    End Function

    Function Cargar(ByVal pAno As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@Ano ", SqlDbType.Int)
        arParms(0).Value = pAno
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PeriodoVentaxAno_S", arParms)
        Return (ds)
    End Function

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PeriodoVenta_S")
        Return (ds)
    End Function


    Function EditarPeriodoAbierto() As String
        sMsg = "No existe periodo de ventas abierto " & sCodUsuario

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_PeriodoVtaAbierto_S"
        cd.CommandType = CommandType.StoredProcedure
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                dFchIniPeriodo = dr.GetValue(dr.GetOrdinal("FchIniPeriodo"))
                dFchFinPeriodo = dr.GetValue(dr.GetOrdinal("FchFinPeriodo"))
                sTrimestre = dr.GetValue(dr.GetOrdinal("Trimestre"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PeriodoVenta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FchIniPeriodo", SqlDbType.Char).Value = sFchIniPeriodo
        cd.Parameters.Add("@FchFinPeriodo", SqlDbType.Char).Value = sFchFinPeriodo
        cd.Parameters.Add("@Trimestre", SqlDbType.Int).Value = Trimestre
        cd.Parameters.Add("@StsPeriodo", SqlDbType.Char, 1).Value = sStsPeriodo
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
        cd.CommandText = "TAB_PeriodoVenta_D"
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