Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoServicio
    Private sCodTipoServicio As String
    Private sTipoServicio As String
    Private sStsTipoServicio As String
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

    Property TipoServicio() As String
        Get
            Return sTipoServicio
        End Get
        Set(ByVal Value As String)
            sTipoServicio = CStr(Value)
        End Set
    End Property

    Property StsTipoServicio() As String
        Get
            Return sStsTipoServicio
        End Get
        Set(ByVal Value As String)
            sStsTipoServicio = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoServicio_S")
        Return (ds)
    End Function

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoServicioActivo_S")
        Return (ds)
    End Function

    Function CargaTiposServicio(ByVal pCodProveedor As Integer, ByVal pCodCiudad As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoServicioxCiudad_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        If Not IsNumeric(sCodTipoServicio) Then
            Return ("Código es numerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoServicio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        cd.Parameters.Add("@TipoServicio", SqlDbType.VarChar, 50).Value = sTipoServicio
        cd.Parameters.Add("@StsTipoServicio", SqlDbType.Char, 1).Value = sStsTipoServicio
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
        cd.CommandText = "TAB_TipoServicio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = sCodTipoServicio
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        Return (sMsg)
    End Function
End Class