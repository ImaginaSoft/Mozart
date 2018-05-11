
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsTourPlantilla
    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private sCodTour As String
    Private sNroPlantilla As String
    Private sCodUsuario As String

    Private sAsigna As String

    Property CodTour() As String
        Get
            Return sCodTour
        End Get
        Set(ByVal Value As String)
            sCodTour = CStr(Value)
        End Set
    End Property

    Property NroPlantilla() As String
        Get
            Return sNroPlantilla
        End Get
        Set(ByVal Value As String)
            sNroPlantilla = CStr(Value)
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

    Property Asigna() As String
        Get
            Return sAsigna
        End Get
        Set(ByVal Value As String)
            sAsigna = CStr(Value)
        End Set
    End Property

    Function Cargar(ByVal pCodTour As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PLA_TourPlantilla_S", New SqlParameter("@CodTour", pCodTour))
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_TourPlantilla_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTour", SqlDbType.SmallInt).Value = sCodTour
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = sNroPlantilla
        cd.Parameters.Add("@Asigna", SqlDbType.Char, 1).Value = sAsigna
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function Borrar(ByVal pCodTour As Integer, ByVal pNroPlantilla As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_TourPlantilla_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTour", SqlDbType.SmallInt).Value = pCodTour
        cd.Parameters.Add("@NroPlantilla", SqlDbType.SmallInt).Value = pNroPlantilla
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        Return (sMsg)
    End Function
End Class