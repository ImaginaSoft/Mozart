Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsRecordatorio
    Private sCodZonaVta As String
    Private sIdioma As String
    Private sNroRecordatorio As String
    Private sDesRecordatorio As String
    Private sNroDias As String
    Private sDatoBase As String
    Private sStsRecordatorio As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodZonaVta() As String
        Get
            Return sCodZonaVta
        End Get
        Set(ByVal Value As String)
            sCodZonaVta = CStr(Value)
        End Set
    End Property

    Property Idioma() As String
        Get
            Return sIdioma
        End Get
        Set(ByVal Value As String)
            sIdioma = CStr(Value)
        End Set
    End Property

    Property NroRecordatorio() As String
        Get
            Return sNroRecordatorio
        End Get
        Set(ByVal Value As String)
            sNroRecordatorio = CStr(Value)
        End Set
    End Property

    Property DesRecordatorio() As String
        Get
            Return sDesRecordatorio
        End Get
        Set(ByVal Value As String)
            sDesRecordatorio = CStr(Value)
        End Set
    End Property

    Property NroDias() As String
        Get
            Return sNroDias
        End Get
        Set(ByVal Value As String)
            sNroDias = CStr(Value)
        End Set
    End Property

    Property DatoBase() As String
        Get
            Return sDatoBase
        End Get
        Set(ByVal Value As String)
            sDatoBase = CStr(Value)
        End Set
    End Property

    Property StsRecordatorio() As String
        Get
            Return sStsRecordatorio
        End Get
        Set(ByVal Value As String)
            sStsRecordatorio = CStr(Value)
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


    Function CargaxZonaVtaIdioma(ByVal pCodZonaVta As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_RecordatorioZonaVtaIdioma_S", arParms)
        Return (ds)
    End Function



    Function Grabar() As String
        If sNroRecordatorio = 0 Then
            Return ("Número de redcordatorio es obligatorio")
        End If
        If Not IsNumeric(sNroRecordatorio) Then
            Return ("Número de redcordatorio es numérico")
        End If

        If sNroDias.Trim.Length = 0 Then
            sNroDias = 0
        ElseIf Not IsNumeric(sNroDias) Then
            Return ("El día es un dato numérico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Recordatorio_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = sCodZonaVta
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = sIdioma
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.SmallInt).Value = sNroRecordatorio
        cd.Parameters.Add("@DesRecordatorio", SqlDbType.VarChar, 100).Value = sDesRecordatorio
        cd.Parameters.Add("@NroDias", SqlDbType.SmallInt).Value = sNroDias
        cd.Parameters.Add("@DatoBase", SqlDbType.VarChar, 50).Value = sDatoBase
        cd.Parameters.Add("@StsRecordatorio", SqlDbType.Char, 1).Value = sStsRecordatorio
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
        cd.CommandText = "TAB_Recordatorio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = sCodZonaVta
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = sIdioma
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = sNroRecordatorio
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