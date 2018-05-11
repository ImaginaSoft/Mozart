Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPerfilRestriccion
    Private sCodPerfil As String
    Private sStsCaptacionActual As String
    Private sStsCaptacionNuevo As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodPerfil() As String
        Get
            Return sCodPerfil
        End Get
        Set(ByVal Value As String)
            sCodPerfil = CStr(Value)
        End Set
    End Property

    Property StsCaptacionActual() As String
        Get
            Return sStsCaptacionActual
        End Get
        Set(ByVal Value As String)
            sStsCaptacionActual = CStr(Value)
        End Set
    End Property

    Property StsCaptacionNuevo() As String
        Get
            Return sStsCaptacionNuevo
        End Get
        Set(ByVal Value As String)
            sStsCaptacionNuevo = CStr(Value)
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

    Function Cargar(ByVal pCodPerfil As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_PefilStsCapta_S", New SqlParameter("@CodPerfil", pCodPerfil))
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "SEG_PerfilStsCaptacion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char, 10).Value = sCodPerfil
        cd.Parameters.Add("@StsCaptacionActual", SqlDbType.Char, 1).Value = sStsCaptacionActual
        cd.Parameters.Add("@StsCaptacionNuevo", SqlDbType.Char, 1).Value = sStsCaptacionNuevo
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
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
        cd.CommandText = "SEG_PerfilStsCapta_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char, 10).Value = sCodPerfil
        cd.Parameters.Add("@StsCaptacionActual", SqlDbType.Char, 1).Value = sStsCaptacionActual
        cd.Parameters.Add("@StsCaptacionNuevo", SqlDbType.Char, 1).Value = sStsCaptacionNuevo
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function
End Class