Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoInformacion

    Private iNroTipoInf As Integer
    Private sNomTipoInfEsp As String
    Private sNomTipoInfIng As String
    Private sNomTipoInfPor As String
    Private sStsTipoInf As String
    Private iNroOrden As Integer
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property NroTipoInf() As String
        Get
            Return iNroTipoInf
        End Get
        Set(ByVal Value As String)
            iNroTipoInf = CStr(Value)
        End Set
    End Property

    Property NomTipoInfEsp() As String
        Get
            Return sNomTipoInfEsp
        End Get
        Set(ByVal Value As String)
            sNomTipoInfEsp = CStr(Value)
        End Set
    End Property

    Property NomTipoInfIng() As String
        Get
            Return sNomTipoInfIng
        End Get
        Set(ByVal Value As String)
            sNomTipoInfIng = CStr(Value)
        End Set
    End Property

    Property NomTipoInfPor() As String
        Get
            Return sNomTipoInfPor
        End Get
        Set(ByVal Value As String)
            sNomTipoInfPor = CStr(Value)
        End Set
    End Property

    Property StsTipoInf() As String
        Get
            Return sStsTipoInf
        End Get
        Set(ByVal Value As String)
            sStsTipoInf = CStr(Value)
        End Set
    End Property

    Property NroOrden() As String
        Get
            Return iNroOrden
        End Get
        Set(ByVal Value As String)
            iNroOrden = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoInformacion_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(iNroTipoInf) Then
            Return ("Número Tipo Información es numerico")
        End If
        If Not IsNumeric(iNroOrden) Then
            Return ("Número Orden es numerico")
        End If

        If iNroTipoInf <= 0 Then
            Return ("Nro Tipo Informacion es mayor a cero")
        End If
        If iNroOrden <= 0 Then
            Return ("Número Orden es mayor a cero")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoInformacion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroTipoInf", SqlDbType.SmallInt).Value = iNroTipoInf
        cd.Parameters.Add("@NomTipoInfEsp", SqlDbType.VarChar, 100).Value = sNomTipoInfEsp
        cd.Parameters.Add("@NomTipoInfIng", SqlDbType.VarChar, 100).Value = sNomTipoInfIng
        cd.Parameters.Add("@NomTipoInfPor", SqlDbType.VarChar, 100).Value = sNomTipoInfPor
        cd.Parameters.Add("@StsTipoInf", SqlDbType.Char, 1).Value = sStsTipoInf
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
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

    Function Borrar(ByVal pNroTipoInf As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoInformacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroTipoInf", SqlDbType.SmallInt).Value = pNroTipoInf
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

    Function Editar(ByVal pNroTipoInf As Integer) As String
        sMsg = "No existe registro " & sCodUsuario

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_TipoInformacionLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroTipoInf", SqlDbType.Int).Value = pNroTipoInf
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sNomTipoInfEsp = dr.GetValue(dr.GetOrdinal("NomTipoInfesp"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function
End Class