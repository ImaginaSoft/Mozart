Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPais
    Private sCodPais As String
    Private sNomPais As String
    Private sNomPaisIngles As String
    Private sStsPais As String
    Private sTollFree As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodPais() As String
        Get
            Return sCodPais
        End Get
        Set(ByVal Value As String)
            sCodPais = CStr(Value)
        End Set
    End Property

    Property NomPais() As String
        Get
            Return sNomPais
        End Get
        Set(ByVal Value As String)
            sNomPais = CStr(Value)
        End Set
    End Property

    Property NomPaisIngles() As String
        Get
            Return sNomPaisIngles
        End Get
        Set(ByVal Value As String)
            sNomPaisIngles = CStr(Value)
        End Set
    End Property

    Property StsPais() As String
        Get
            Return sStsPais
        End Get
        Set(ByVal Value As String)
            sStsPais = CStr(Value)
        End Set
    End Property

    Property TollFree() As String
        Get
            Return sTollFree
        End Get
        Set(ByVal Value As String)
            sTollFree = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PaisG_S")
        Return (ds)
    End Function

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Pais_S")
        Return (ds)
    End Function

    Function Grabar(ByVal pDocReqEsp As String, ByVal pDocReqIng As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Pais_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPais", SqlDbType.Char, 3).Value = sCodPais
        cd.Parameters.Add("@NomPais", SqlDbType.VarChar, 50).Value = sNomPais
        cd.Parameters.Add("@StsPais", SqlDbType.Char, 1).Value = sStsPais
        cd.Parameters.Add("@NomPaisIngles", SqlDbType.VarChar, 50).Value = sNomPaisIngles
        cd.Parameters.Add("@DocReqEsp", SqlDbType.Text).Value = pDocReqEsp
        cd.Parameters.Add("@DocReqIng", SqlDbType.Text).Value = pDocReqIng
        cd.Parameters.Add("@TollFree", SqlDbType.Char, 50).Value = sTollFree
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
        cd.CommandText = "TAB_Pais_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPais", SqlDbType.Char, 3).Value = sCodPais
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