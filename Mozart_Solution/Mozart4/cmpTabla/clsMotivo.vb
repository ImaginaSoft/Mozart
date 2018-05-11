Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsMotivo
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Private sMsg As String

    Private iCodMotivo As Integer
    Private sNomMotivo As String
    Private sStsMotivo As String
    Private iNroOrden As Integer
    Private sCodUsuario As String

    Property CodMotivo() As Integer
        Get
            Return iCodMotivo
        End Get
        Set(ByVal Value As Integer)
            iCodMotivo = Value
        End Set
    End Property

    Property NomMotivo() As String
        Get
            Return sNomMotivo
        End Get
        Set(ByVal Value As String)
            sNomMotivo = CStr(Value)
        End Set
    End Property

    Property StsMotivo() As String
        Get
            Return sStsMotivo
        End Get
        Set(ByVal Value As String)
            sStsMotivo = CStr(Value)
        End Set
    End Property

    Property NroOrden() As Integer
        Get
            Return iNroOrden
        End Get
        Set(ByVal Value As Integer)
            iNroOrden = Value
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Motivo_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(iNroOrden) Then
            iNroOrden = 0
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Motivo_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodMotivo", SqlDbType.TinyInt).Value = iCodMotivo
        cd.Parameters.Add("@NomMotivo", SqlDbType.VarChar, 50).Value = sNomMotivo
        cd.Parameters.Add("@StsMotivo", SqlDbType.Char, 1).Value = sStsMotivo
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
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
        cd.CommandText = "TAB_Motivo_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodMotivo", SqlDbType.TinyInt).Value = iCodMotivo
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