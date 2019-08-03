Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsExperiencia
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sWebBlogIng As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogIng"))
    Dim sWebBlogEsp As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogEsp"))
    Dim sMsg As String

    Function CargaExperiencias(ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFchIni
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin
        arParms(2) = New SqlParameter("@WebBlogIng", SqlDbType.VarChar, 50)
        arParms(2).Value = sWebBlogIng
        arParms(3) = New SqlParameter("@WebBlogEsp", SqlDbType.VarChar, 50)
        arParms(3).Value = sWebBlogEsp
        arParms(4) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(4).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaExperiencia_S", arParms)
        Return (ds)
    End Function

    Function CargaExperiencias(ByVal pCodVendedor As String, ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
        ' Dim sWebBlog As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlog"))

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(0).Value = pCodVendedor
        arParms(1) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(1).Value = pFchIni
        arParms(2) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(2).Value = pFchFin
        arParms(3) = New SqlParameter("@WebBlogIng", SqlDbType.VarChar, 50)
        arParms(3).Value = sWebBlogIng
        arParms(4) = New SqlParameter("@WebBlogEsp", SqlDbType.VarChar, 50)
        arParms(4).Value = sWebBlogEsp
        arParms(5) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(5).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaExperienciaVendedor_S", arParms)
        Return (ds)
    End Function

    Function ActualizaFlagCaptacion(ByVal pNroPedido As Integer, ByVal pNroExp As Integer, ByVal pFlagCaptacion As String, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_ExperienciaCaptacion_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroExp", SqlDbType.Int).Value = pNroExp
        cd.Parameters.Add("@FlagCaptacion", SqlDbType.Char, 1).Value = pFlagCaptacion
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
        Catch ex2 As System.Exception
            sMsg = ex2.Message
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function


    Function ActualizaOrdenCaptacion(ByVal pNroPedido As Integer, ByVal pNroExp As Integer, ByVal pOrdenCaptacion As Integer, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_ExperienciaOrden_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroExp", SqlDbType.Int).Value = pNroExp
        cd.Parameters.Add("@OrdenCaptacion", SqlDbType.Int).Value = pOrdenCaptacion
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
        Catch ex2 As System.Exception
            sMsg = ex2.Message
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function

    Function Captacion(ByVal pCodUsuario As String) As DataSet
        'Dim sWebBlog As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlog"))

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@WebBlogIng", SqlDbType.VarChar, 50)
        arParms(0).Value = sWebBlogIng
        arParms(1) = New SqlParameter("@WebBlogEsp", SqlDbType.VarChar, 50)
        arParms(1).Value = sWebBlogEsp
        arParms(2) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(2).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_ExperienciaCaptacion_S", arParms)
        Return (ds)
    End Function


End Class
