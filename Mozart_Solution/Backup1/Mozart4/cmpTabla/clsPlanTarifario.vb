Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPlanTarifario
    Dim sMsg As String

    Private sCodPlanTarifario As String
    Private sNomPlanTarifario As String
    Private sPorUtilidadAnoActual As String
    Private sPorUtilidadSgtesAnos As String
    Private sStsPlanTarifario As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Property CodPlanTarifario() As String
        Get
            Return sCodPlanTarifario
        End Get
        Set(ByVal Value As String)
            sCodPlanTarifario = CStr(Value)
        End Set
    End Property

    Property NomPlanTarifario() As String
        Get
            Return sNomPlanTarifario
        End Get
        Set(ByVal Value As String)
            sNomPlanTarifario = CStr(Value)
        End Set
    End Property

    Property PorUtilidadAnoActual() As String
        Get
            Return sPorUtilidadAnoActual
        End Get
        Set(ByVal Value As String)
            sPorUtilidadAnoActual = CStr(Value)
        End Set
    End Property

    Property PorUtilidadSgtesAnos() As String
        Get
            Return sPorUtilidadSgtesAnos
        End Get
        Set(ByVal Value As String)
            sPorUtilidadSgtesAnos = CStr(Value)
        End Set
    End Property

    Property StsPlanTarifario() As String
        Get
            Return sStsPlanTarifario
        End Get
        Set(ByVal Value As String)
            sStsPlanTarifario = CStr(Value)
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

    Function CargaDDL(ByVal pCodPlanTarifario As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PlanTarifarioDDL_S", New SqlParameter("@CodPlanTarifario", pCodPlanTarifario))
        Return (ds)
    End Function

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PlanTarifario_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(sCodPlanTarifario) Then
            Return ("Código del plan tarifario es númerico y obligatorio")
        End If
        If sNomPlanTarifario.Trim.Length = 0 Then
            Return ("Nombre del plan tarifario es obligatorio")
        End If
        If Not IsNumeric(sPorUtilidadAnoActual) Then
            Return ("%Utilidad año actual es númerico y obligatorio")
        End If
        If Not IsNumeric(sPorUtilidadSgtesAnos) Then
            Return ("%Utilidad sgte. año es númerico y obligatorio")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PlanTarifario_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPlanTarifario", SqlDbType.Int).Value = sCodPlanTarifario
        cd.Parameters.Add("@NomPlanTarifario", SqlDbType.VarChar, 50).Value = sNomPlanTarifario
        cd.Parameters.Add("@PorUtilidadAnoActual", SqlDbType.Money).Value = sPorUtilidadAnoActual
        cd.Parameters.Add("@PorUtilidadSgtesAnos", SqlDbType.Money).Value = sPorUtilidadSgtesAnos
        cd.Parameters.Add("@StsPlanTarifario", SqlDbType.Char, 15).Value = sStsPlanTarifario
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

    Function Borrar(ByVal pCodPlanTarifario As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PlanTarifario_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPlanTarifario", SqlDbType.Int).Value = pCodPlanTarifario
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