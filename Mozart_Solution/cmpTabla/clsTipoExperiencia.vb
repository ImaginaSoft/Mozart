Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoExperiencia
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private iCodTipoExp As String
    Private sNomTipoExp As String
    Private sFlagIdioma As String
    Private sStsTipoExp As String
    Private sCodUsuario As String

    Property CodTipoExp() As String
        Get
            Return iCodTipoExp
        End Get
        Set(ByVal Value As String)
            iCodTipoExp = CStr(Value)
        End Set
    End Property

    Property NomTipoExp() As String
        Get
            Return sNomTipoExp
        End Get
        Set(ByVal Value As String)
            sNomTipoExp = CStr(Value)
        End Set
    End Property

    Property FlagIdioma() As String
        Get
            Return sFlagIdioma
        End Get
        Set(ByVal Value As String)
            sFlagIdioma = CStr(Value)
        End Set
    End Property

    Property StsTipoExp() As String
        Get
            Return sStsTipoExp
        End Get
        Set(ByVal Value As String)
            sStsTipoExp = CStr(Value)
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

    Function CargaxIdioma(ByVal pFlagIdioma As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_TipoExperiencia_S", New SqlParameter("@FlagIdioma", pFlagIdioma))
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_TipoExperiencia_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoExp", SqlDbType.Int).Value = iCodTipoExp
        cd.Parameters.Add("@NomTipoExp", SqlDbType.VarChar, 100).Value = sNomTipoExp
        cd.Parameters.Add("@FlagIdioma", SqlDbType.Char, 1).Value = sFlagIdioma
        cd.Parameters.Add("@StsTipoExp", SqlDbType.Char, 1).Value = sStsTipoExp
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

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_TipoExperiencia_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoExp", SqlDbType.Int).Value = iCodTipoExp
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