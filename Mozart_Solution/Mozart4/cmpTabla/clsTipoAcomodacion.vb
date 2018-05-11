Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoAcomodacion
    Private sCodTipoServicio As String
    Private sCodTipoAcomodacion As String
    Private sTipoAcomodacion As String
    Private sAbrTipoAcomodacion As String
    Private sNroOrden As String
    Private sStsTipoAcomodacion As String
    Private sCodUsuario As String
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

    Property CodTipoAcomodacion() As String
        Get
            Return sCodTipoAcomodacion
        End Get
        Set(ByVal Value As String)
            sCodTipoAcomodacion = CStr(Value)
        End Set
    End Property

    Property TipoAcomodacion() As String
        Get
            Return sTipoAcomodacion
        End Get
        Set(ByVal Value As String)
            sTipoAcomodacion = CStr(Value)
        End Set
    End Property

    Property AbrTipoAcomodacion() As String
        Get
            Return sAbrTipoAcomodacion
        End Get
        Set(ByVal Value As String)
            sAbrTipoAcomodacion = CStr(Value)
        End Set
    End Property

    Property NroOrden() As String
        Get
            Return sNroOrden
        End Get
        Set(ByVal Value As String)
            sNroOrden = CStr(Value)
        End Set
    End Property

    Property StsTipoAcomodacion() As String
        Get
            Return sStsTipoAcomodacion
        End Get
        Set(ByVal Value As String)
            sStsTipoAcomodacion = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoAcomodacionG_S", New SqlParameter("@CodTipoServicio", sCodTipoServicio))
        Return (ds)
    End Function

    Function CargarDDL(ByVal pCodTipoServicio As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoAcomodacion_S", New SqlParameter("@CodTipoServicio", pCodTipoServicio))
        Return (ds)
    End Function

    Function CargarxNroServicio(ByVal pNroServicio As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoAcomodacionxServicio_S", New SqlParameter("@NroServicio", pNroServicio))
        Return (ds)
    End Function


    Function Grabar() As String
        If Not IsNumeric(sCodTipoAcomodacion) Then
            Return ("Código tipo acomodación es numerico")
        End If
        If Not IsNumeric(sNroOrden) Then
            Return ("Número orden es numerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoAcomodacion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = sCodTipoAcomodacion
        cd.Parameters.Add("@TipoAcomodacion", SqlDbType.VarChar, 50).Value = sTipoAcomodacion
        cd.Parameters.Add("@abrTipoAcomodacion", SqlDbType.VarChar, 50).Value = sAbrTipoAcomodacion
        cd.Parameters.Add("@StsTipoAcomodacion", SqlDbType.Char, 1).Value = sStsTipoAcomodacion
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = sNroOrden
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
        cd.CommandText = "TAB_TipoAcomodacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = sCodTipoAcomodacion
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