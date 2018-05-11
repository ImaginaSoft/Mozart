Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsCiudadClima
    Dim sMsg As String

    Private sCodCiudad As String
    Private iNroMes As String
    Private sTempMinima As String
    Private sTempMaxima As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Property CodCiudad() As String
        Get
            Return sCodCiudad
        End Get
        Set(ByVal Value As String)
            sCodCiudad = CStr(Value)
        End Set
    End Property

    Property NroMes() As String
        Get
            Return iNroMes
        End Get
        Set(ByVal Value As String)
            iNroMes = CStr(Value)
        End Set
    End Property

    Property TempMinima() As String
        Get
            Return sTempMinima
        End Get
        Set(ByVal Value As String)
            sTempMinima = CStr(Value)
        End Set
    End Property

    Property TempMaxima() As String
        Get
            Return sTempMaxima
        End Get
        Set(ByVal Value As String)
            sTempMaxima = CStr(Value)
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

    Function Cargar(ByVal pCodCiudad As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_CiudadClima_S", New SqlParameter("@CodCiudad", pCodCiudad))
        Return (ds)
    End Function


    Function Grabar() As String
        If IsNumeric(iNroMes) Then
            If iNroMes < 0 Or iNroMes > 12 Then
                Return ("Mes está en el rango [1,12]")
            End If
        Else
            Return ("Mes es dato númerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_CiudadClima_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = sCodCiudad
        cd.Parameters.Add("@NroMes", SqlDbType.TinyInt).Value = iNroMes
        cd.Parameters.Add("@TempMinima", SqlDbType.VarChar, 30).Value = sTempMinima
        cd.Parameters.Add("@TempMaxima", SqlDbType.VarChar, 30).Value = sTempMaxima
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

    Function Borrar(ByVal pCodCiudad As String, ByVal pNroMes As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_CiudadClima_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = pCodCiudad
        cd.Parameters.Add("@NroMes", SqlDbType.Int).Value = pNroMes
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