Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoLink
    Private sCodTipoLink As String
    Private sTipoLink As String
    Private sStsTipoLink As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodTipoLink() As String
        Get
            Return sCodTipoLink
        End Get
        Set(ByVal Value As String)
            sCodTipoLink = CStr(Value)
        End Set
    End Property


    Property TipoLink() As String
        Get
            Return sTipoLink
        End Get
        Set(ByVal Value As String)
            sTipoLink = CStr(Value)
        End Set
    End Property

    Property StsTipoLink() As String
        Get
            Return sStsTipoLink
        End Get
        Set(ByVal Value As String)
            sStsTipoLink = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoLink_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(sCodTipoLink) Then
            Return ("Código es numerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoLink_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoLink", SqlDbType.SmallInt).Value = sCodTipoLink
        cd.Parameters.Add("@TipoLink", SqlDbType.VarChar, 50).Value = sTipoLink
        cd.Parameters.Add("@StsTipoLink", SqlDbType.Char, 1).Value = sStsTipoLink
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
        cd.CommandText = "TAB_TipoLink_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoLink", SqlDbType.TinyInt).Value = sCodTipoLink
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