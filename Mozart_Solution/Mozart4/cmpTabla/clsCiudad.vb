Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class clsCiudad
    Private sCodCiudad As String
    Private sNomCiudad As String
    Private sStsCiudad As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodCiudad() As String
        Get
            Return sCodCiudad
        End Get
        Set(ByVal Value As String)
            sCodCiudad = CStr(Value)
        End Set
    End Property

    Property NomCiudad() As String
        Get
            Return sNomCiudad
        End Get
        Set(ByVal Value As String)
            sNomCiudad = CStr(Value)
        End Set
    End Property

    Property StsCiudad() As String
        Get
            Return sStsCiudad
        End Get
        Set(ByVal Value As String)
            sStsCiudad = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Ciudad_S")
        Return (ds)
    End Function

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_CiudadActivo_S")
        Return (ds)
    End Function

    Function CargaCiudad(ByVal pCodProveedor As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_CiudadxProveedor_S", New SqlParameter("@CodProveedor", pCodProveedor))
        Return (ds)
    End Function

    Function CargaUnaCiudad(ByVal pCodCiudad As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_CiudadLee_S", New SqlParameter("@CodCiudad", pCodCiudad))
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Ciudad_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = sCodCiudad
        cd.Parameters.Add("@NomCiudad", SqlDbType.VarChar, 50).Value = sNomCiudad
        cd.Parameters.Add("@StsCiudad", SqlDbType.Char, 1).Value = sStsCiudad
        cd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = sCodUsuario
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
        cd.CommandText = "TAB_Ciudad_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = sCodCiudad
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

    Function Editar(ByVal pCodCiudad As String) As String
        sMsg = "No existe registro " & sCodUsuario

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_CiudadLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = pCodCiudad
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sNomCiudad = dr.GetValue(dr.GetOrdinal("NomCiudad"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function
End Class