Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTarifa
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Private sMsg As String

    Private iNroServicio As Integer
    Private iCodTipoAcomodacion As Integer
    Private sCodTipoPasajero As String
    Private sCodSubTipo As String
    Private iCodTarifa As Integer
    Private iRangoTarifa As Integer
    Private dTarifaNeta As Double
    Private iCodTipoServicio As Integer
    Private sCodUsuario As String

    Private iRangoTarifaIni As Integer
    Private iRangoTarifaFin As Integer

    Property NroServicio() As Integer
        Get
            Return iNroServicio
        End Get
        Set(ByVal Value As Integer)
            iNroServicio = Value
        End Set
    End Property

    Property CodTipoAcomodacion() As Integer
        Get
            Return iCodTipoAcomodacion
        End Get
        Set(ByVal Value As Integer)
            iCodTipoAcomodacion = Value
        End Set
    End Property

    Property CodTipoPasajero() As String
        Get
            Return sCodTipoPasajero
        End Get
        Set(ByVal Value As String)
            sCodTipoPasajero = Value
        End Set
    End Property

    Property CodSubTipo() As String
        Get
            Return sCodSubTipo
        End Get
        Set(ByVal Value As String)
            sCodSubTipo = CStr(Value)
        End Set
    End Property

    Property CodTarifa() As Integer
        Get
            Return iCodTarifa
        End Get
        Set(ByVal Value As Integer)
            iCodTarifa = Value
        End Set
    End Property

    Property RangoTarifa() As Integer
        Get
            Return iRangoTarifa
        End Get
        Set(ByVal Value As Integer)
            iRangoTarifa = Value
        End Set
    End Property

    Property TarifaNeta() As Double
        Get
            Return dTarifaNeta
        End Get
        Set(ByVal Value As Double)
            dTarifaNeta = Value
        End Set
    End Property

    Property CodTipoServicio() As Integer
        Get
            Return iCodTipoServicio
        End Get
        Set(ByVal Value As Integer)
            iCodTipoServicio = Value
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

    Property RangoTarifaIni() As Integer
        Get
            Return iRangoTarifaIni
        End Get
        Set(ByVal Value As Integer)
            iRangoTarifaIni = Value
        End Set
    End Property

    Property RangoTarifaFin() As Integer
        Get
            Return iRangoTarifaFin
        End Get
        Set(ByVal Value As Integer)
            iRangoTarifaFin = Value
        End Set
    End Property

    Function Carga(ByVal pNroServicio As Integer, ByVal pCodTarifa As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
        arParms(0).Value = pNroServicio
        arParms(1) = New SqlParameter("@CodTarifa", SqlDbType.Int)
        arParms(1).Value = pCodTarifa
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_DTarifa_S", arParms)
        Return (ds)
    End Function

    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_DTarifa_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = iCodTipoAcomodacion
        cd.Parameters.Add("@CodTipoPasajero", SqlDbType.Char, 1).Value = sCodTipoPasajero
        cd.Parameters.Add("@CodSubTipo", SqlDbType.Char, 1).Value = sCodSubTipo
        cd.Parameters.Add("@CodTarifa", SqlDbType.SmallInt).Value = iCodTarifa
        cd.Parameters.Add("@RangoTarifaIni", SqlDbType.SmallInt).Value = iRangoTarifaIni
        cd.Parameters.Add("@RangoTarifaFin", SqlDbType.SmallInt).Value = iRangoTarifaFin
        cd.Parameters.Add("@TarifaNeta", SqlDbType.Money).Value = dTarifaNeta
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = iCodTipoServicio
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
        cd.CommandText = "VTA_DTarifa_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.Char).Value = iCodTipoAcomodacion
        cd.Parameters.Add("@CodTipoPasajero", SqlDbType.Char).Value = sCodTipoPasajero
        cd.Parameters.Add("@CodSubTipo", SqlDbType.Char, 1).Value = sCodSubTipo
        cd.Parameters.Add("@CodTarifa", SqlDbType.SmallInt).Value = iCodTarifa
        cd.Parameters.Add("@RangoTarifa", SqlDbType.SmallInt).Value = iRangoTarifa
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

    Function BorrarAll() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_DTarifaAll_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodTarifa", SqlDbType.SmallInt).Value = iCodTarifa
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

    Function CopiaTarifas(ByVal pNroServicioOrigen As Integer, ByVal pCodTarifaOrigen As Integer, ByVal pNroServicioDestino As Integer, ByVal pCodTarifaDestino As Integer, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_TarifaPeriodoCopia_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicioOrigen", SqlDbType.Int).Value = pNroServicioOrigen
        cd.Parameters.Add("@CodTarifaOrigen", SqlDbType.SmallInt).Value = pCodTarifaOrigen
        cd.Parameters.Add("@NroServicioDestino", SqlDbType.Int).Value = pNroServicioDestino
        cd.Parameters.Add("@CodTarifaDestino", SqlDbType.SmallInt).Value = pCodTarifaDestino
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
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