Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsComentario
    Dim sWebBlogIng As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogIng"))
    Dim sWebBlogEsp As New String(System.Configuration.ConfigurationManager.AppSettings("WebBlogEsp"))

    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private iNroPedido As Integer
    Private iNroExp As Integer
    Private iNroComentario As Integer
    Private sCodUsuario As String

    'datos para enviar e-mail
    Private sEmailCliente As String
    Private sClaveCliente As String
    Private sEmailOrigen As String
    Private sAsunto As String
    Private sDetalle As String

    Property NroPedido() As Integer
        Get
            Return iNroPedido
        End Get
        Set(ByVal Value As Integer)
            iNroPedido = (Value)
        End Set
    End Property

    Property NroExp() As Integer
        Get
            Return iNroExp
        End Get
        Set(ByVal Value As Integer)
            iNroExp = (Value)
        End Set
    End Property

    Property NroComentario() As Integer
        Get
            Return iNroComentario
        End Get
        Set(ByVal Value As Integer)
            iNroComentario = (Value)
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

    'Lee datos para e-mail
    Property EmailCliente() As String
        Get
            Return sEmailCliente
        End Get
        Set(ByVal Value As String)
            sEmailCliente = CStr(Value)
        End Set
    End Property

    Property ClaveCliente() As String
        Get
            Return sClaveCliente
        End Get
        Set(ByVal Value As String)
            sClaveCliente = CStr(Value)
        End Set
    End Property


    Property EmailOrigen() As String
        Get
            Return sEmailOrigen
        End Get
        Set(ByVal Value As String)
            sEmailOrigen = CStr(Value)
        End Set
    End Property

    Property Asunto() As String
        Get
            Return sAsunto
        End Get
        Set(ByVal Value As String)
            sAsunto = CStr(Value)
        End Set
    End Property

    Property Detalle() As String
        Get
            Return sDetalle
        End Get
        Set(ByVal Value As String)
            sDetalle = CStr(Value)
        End Set
    End Property

    Function ActualizaFlagRevisado() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_Comentario_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroExp", SqlDbType.Int).Value = iNroExp
        cd.Parameters.Add("@NroComentario", SqlDbType.Int).Value = iNroComentario
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
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

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "BLOG_Comentario_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroExp", SqlDbType.Int).Value = iNroExp
        cd.Parameters.Add("@NroComentario", SqlDbType.Int).Value = iNroComentario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
        Catch ex2 As System.Exception
            sMsg = ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function


    Function CargaComentario(ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaComentario_S", arParms)
        Return (ds)
    End Function

    Function CargaComentario(ByVal pCodVendedor As String, ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaComentarioVendedor_S", arParms)
        Return (ds)
    End Function

    Function ComentarioPendiente(ByVal pFlagComentario As String, ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@FlagComentario", SqlDbType.Char, 1)
        arParms(0).Value = pFlagComentario
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaComentarioSts_S", arParms)
        Return (ds)
    End Function

    Function ComentarioPendiente(ByVal pCodVendedor As String, ByVal pFlagComentario As String, ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(0).Value = pCodVendedor
        arParms(1) = New SqlParameter("@FlagComentario", SqlDbType.Char, 1)
        arParms(1).Value = pFlagComentario
        arParms(2) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(2).Value = pFchIni
        arParms(3) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(3).Value = pFchFin
        arParms(4) = New SqlParameter("@WebBlogIng", SqlDbType.VarChar, 50)
        arParms(4).Value = sWebBlogIng
        arParms(5) = New SqlParameter("@WebBlogEsp", SqlDbType.VarChar, 50)
        arParms(5).Value = sWebBlogEsp
        arParms(6) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(6).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "BLOG_RevisaComentarioVendedorSts_S", arParms)
        Return (ds)
    End Function

    Function DatosParaEmail() As String
        sMsg = "No existe Datos " & CStr(iNroPedido)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "BLOG_LeeDatosParaEmail_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroExp", SqlDbType.Int).Value = iNroExp
        cd.Parameters.Add("@NroComentario", SqlDbType.Int).Value = iNroComentario
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sEmailCliente = dr.GetValue(dr.GetOrdinal("Email"))
                sClaveCliente = dr.GetValue(dr.GetOrdinal("ClaveCliente"))
                sEmailOrigen = dr.GetValue(dr.GetOrdinal("EmailOrigen"))
                sAsunto = dr.GetValue(dr.GetOrdinal("Asunto"))
                sDetalle = dr.GetValue(dr.GetOrdinal("Detalle"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

End Class
