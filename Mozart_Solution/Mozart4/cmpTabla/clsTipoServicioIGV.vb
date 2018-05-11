Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoServicioIGV
    Private sCodTipoServicio As String
    Private sTipoPersona As String
    Private sFlagIGV As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodTipoServicio() As String
        Get
            Return sCodTipoServicio
        End Get
        Set(ByVal Value As String)
            sCodTipoServicio = CStr(Value)
        End Set
    End Property

    Property TipoPersona() As String
        Get
            Return sTipoPersona
        End Get
        Set(ByVal Value As String)
            sTipoPersona = CStr(Value)
        End Set
    End Property

    Property FlagIGV() As String
        Get
            Return sFlagIGV
        End Get
        Set(ByVal Value As String)
            sFlagIGV = CStr(Value)
        End Set
    End Property

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoServicioIGV_S")
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoServicioIGV_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        cd.Parameters.Add("@TipoPersona", SqlDbType.Char, 1).Value = sTipoPersona
        cd.Parameters.Add("@FlagIGV", SqlDbType.Char, 1).Value = sFlagIGV
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
        cd.CommandText = "TAB_TipoServicioIGV_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        cd.Parameters.Add("@TipoPersona", SqlDbType.Char, 1).Value = sTipoPersona
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