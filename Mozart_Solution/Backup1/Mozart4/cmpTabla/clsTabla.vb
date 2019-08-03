Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTabla

    Private sCodTabla As String
    Private sNomTabla As String
    Private sStsTabla As String
    Private sCodEleLong As String
    Private sFlagModifica As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodTabla() As String
        Get
            Return sCodTabla
        End Get
        Set(ByVal Value As String)
            sCodTabla = CStr(Value)
        End Set
    End Property

    Property NomTabla() As String
        Get
            Return sNomTABLA
        End Get
        Set(ByVal Value As String)
            sNomTABLA = CStr(Value)
        End Set
    End Property

    Property StsTabla() As String
        Get
            Return sStsTabla
        End Get
        Set(ByVal Value As String)
            sStsTabla = CStr(Value)
        End Set
    End Property

    Property CodEleLong() As String
        Get
            Return sCodEleLong
        End Get
        Set(ByVal Value As String)
            sCodEleLong = CStr(Value)
        End Set
    End Property

    Property FlagModifica() As String
        Get
            Return sFlagModifica
        End Get
        Set(ByVal Value As String)
            sFlagModifica = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Tabla_S")
        Return (ds)
    End Function


    Function Grabar() As String
        If sCodTabla.Trim.Length = 0 Then
            Return ("Código es dato obligatorio")
        End If
        If Not IsNumeric(sCodTabla) Then
            Return ("Código de la tabla númerico")
        End If
        If sNomTabla.Trim.Length = 0 Then
            Return ("Nombre es dato obligatorio")
        End If
        If Not IsNumeric(sCodEleLong) Then
            sCodEleLong = "0"
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Tabla_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTabla", SqlDbType.SmallInt).Value = sCodTabla
        cd.Parameters.Add("@NomTabla", SqlDbType.VarChar, 100).Value = sNomTabla
        cd.Parameters.Add("@StsTabla", SqlDbType.Char, 1).Value = sStsTabla
        cd.Parameters.Add("@CodEleLong", SqlDbType.TinyInt).Value = sCodEleLong
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error1:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error2:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function

    Function Borrar(ByVal pCodTabla As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Tabla_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTabla", SqlDbType.SmallInt).Value = pCodTabla
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error1:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error2:" & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function Editar(ByVal pCodtabla As Integer) As String
        sMsg = "No existe registro " & sCodUsuario

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_TablaLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodTabla", SqlDbType.Char, 10).Value = pCodtabla
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sNomTabla = dr.GetValue(dr.GetOrdinal("NomTabla"))
                sFlagModifica = dr.GetValue(dr.GetOrdinal("FlagModifica"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function
End Class