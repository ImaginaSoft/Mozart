Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration

Public Class clsAlbum
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sWebBlogIng As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogIng"))
    Dim sWebBlogEsp As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogEsp"))

    Function CargaFotos(ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaFotos_S", arParms)
        Return (ds)
    End Function

    Function CargaFotos(ByVal pCodVendedor As String, ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaFotosVendedor_S", arParms)
        Return (ds)
    End Function

End Class
