Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTipoDocumento
    Private sTipoSistema As String
    Private sTipoDocumento As String
    Private sNomDocumento As String
    Private sTipoOperacion As String
    Private sAfectaCaja As String
    Private sTipoDocSunat As String
    Private sDocSunat As String
    Private sStsTipoDocumento As String
    Private sFlagComisionTC As String
    Private sCodProveedorTC As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property TipoSistema() As String
        Get
            Return sTipoSistema
        End Get
        Set(ByVal Value As String)
            sTipoSistema = CStr(Value)
        End Set
    End Property

    Property TipoDocumento() As String
        Get
            Return sTipoDocumento
        End Get
        Set(ByVal Value As String)
            sTipoDocumento = CStr(Value)
        End Set
    End Property

    Property NomDocumento() As String
        Get
            Return sNomDocumento
        End Get
        Set(ByVal Value As String)
            sNomDocumento = CStr(Value)
        End Set
    End Property

    Property TipoOperacion() As String
        Get
            Return sTipoOperacion
        End Get
        Set(ByVal Value As String)
            sTipoOperacion = CStr(Value)
        End Set
    End Property

    Property AfectaCaja() As String
        Get
            Return sAfectaCaja
        End Get
        Set(ByVal Value As String)
            sAfectaCaja = CStr(Value)
        End Set
    End Property

    Property StsTipoDocumento() As String
        Get
            Return sStsTipoDocumento
        End Get
        Set(ByVal Value As String)
            sStsTipoDocumento = CStr(Value)
        End Set
    End Property

    Property TipoDocSunat() As String
        Get
            Return sTipoDocSunat
        End Get
        Set(ByVal Value As String)
            sTipoDocSunat = CStr(Value)
        End Set
    End Property

    Property DocSunat() As String
        Get
            Return sDocSunat
        End Get
        Set(ByVal Value As String)
            sDocSunat = CStr(Value)
        End Set
    End Property

    Property FlagComisionTC() As String
        Get
            Return sFlagComisionTC
        End Get
        Set(ByVal Value As String)
            sFlagComisionTC = CStr(Value)
        End Set
    End Property

    Property CodProveedorTC() As String
        Get
            Return sCodProveedorTC
        End Get
        Set(ByVal Value As String)
            sCodProveedorTC = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoDocumentoT_S")
        Return (ds)
    End Function

    Function CargaTipoDocSunat(ByVal pTipoSistema As String, ByVal pTipoOperacion As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@TipoSistema", SqlDbType.Char, 1)
        arParms(0).Value = pTipoSistema
        arParms(1) = New SqlParameter("@TipoOperacion", SqlDbType.Char, 1)
        arParms(1).Value = pTipoOperacion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoDocumentoCodSunat_S", arParms)
        Return (ds)
    End Function

    Function CargaTipoDocSunatyNC(ByVal pTipoSistema As String, ByVal pTipoOperacion As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@TipoSistema", SqlDbType.Char, 1)
        arParms(0).Value = pTipoSistema
        arParms(1) = New SqlParameter("@TipoOperacion", SqlDbType.Char, 1)
        arParms(1).Value = pTipoOperacion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoDocumentoCodSunatyNC_S", arParms)
        Return (ds)
    End Function


    Function CargaTipoDocOperacion(ByVal pTipoSistema As String, ByVal pTipoOperacion As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@TipoSistema", SqlDbType.Char, 1)
        arParms(0).Value = pTipoSistema
        arParms(1) = New SqlParameter("@TipoOperacion", SqlDbType.Char, 1)
        arParms(1).Value = pTipoOperacion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoDocumentoOperacion_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        If sCodProveedorTC.Trim.Length = 0 Then
            sCodProveedorTC = 0
        ElseIf Not IsNumeric(sCodProveedorTC) Then
            Return ("Error: código de proveedor TC es númerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TipoDocumento_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""

        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = sTipoSistema
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = sTipoDocumento
        cd.Parameters.Add("@NomDocumento", SqlDbType.VarChar, 50).Value = sNomDocumento
        cd.Parameters.Add("@TipoOperacion", SqlDbType.Char, 1).Value = sTipoOperacion
        cd.Parameters.Add("@AfectaCaja", SqlDbType.Char, 1).Value = sAfectaCaja
        cd.Parameters.Add("@StsTipoDocumento", SqlDbType.Char, 1).Value = sStsTipoDocumento
        cd.Parameters.Add("@TipoDocSunat", SqlDbType.Char, 1).Value = sTipoDocSunat
        cd.Parameters.Add("@DocSunat", SqlDbType.Char, 2).Value = sDocSunat
        cd.Parameters.Add("@FlagComisionTC", SqlDbType.Char, 1).Value = sFlagComisionTC
        cd.Parameters.Add("@CodProveedorTC", SqlDbType.Int).Value = sCodProveedorTC
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
        cd.CommandText = "TAB_TipoDocumento_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = sTipoSistema
        cd.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = sTipoDocumento
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