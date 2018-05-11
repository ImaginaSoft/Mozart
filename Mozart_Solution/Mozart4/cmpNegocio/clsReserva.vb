Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsReserva
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Private iNroPedido As Integer
    Private iNroPropuesta As Integer
    Private iNroVersion As Integer
    Private iCodProveedor As Integer
    Private dPrecioRpta As Double
    Private sNroFile As String
    Private sDeslog As String
    Private iCantDesLog As Integer

    Private sCodSolicita As String
    Private sDesRpta As String
    Private sCodUsuario As String
    Dim sMsg As String


    Property NroPedido() As Integer
        Get
            Return iNroPedido
        End Get
        Set(ByVal Value As Integer)
            iNroPedido = (Value)
        End Set
    End Property

    Property NroPropuesta() As Integer
        Get
            Return iNroPropuesta
        End Get
        Set(ByVal Value As Integer)
            iNroPropuesta = (Value)
        End Set
    End Property

    Property NroVersion() As Integer
        Get
            Return iNroVersion
        End Get
        Set(ByVal Value As Integer)
            iNroVersion = (Value)
        End Set
    End Property

    Property CodProveedor() As Integer
        Get
            Return iCodProveedor
        End Get
        Set(ByVal Value As Integer)
            iCodProveedor = (Value)
        End Set
    End Property

    Property PrecioRpta() As Double
        Get
            Return dPrecioRpta
        End Get
        Set(ByVal Value As Double)
            dPrecioRpta = (Value)
        End Set
    End Property

    Property NroFile() As String
        Get
            Return sNroFile
        End Get
        Set(ByVal Value As String)
            sNroFile = CStr(Value)
        End Set
    End Property

    Property CantDesLog() As Integer
        Get
            Return iCantDesLog
        End Get
        Set(ByVal Value As Integer)
            iCantDesLog = (Value)
        End Set
    End Property

    Property Deslog() As String
        Get
            Return sDeslog
        End Get
        Set(ByVal Value As String)
            sDeslog = CStr(Value)
        End Set
    End Property


    Property CodSolicita() As String
        Get
            Return sCodSolicita
        End Get
        Set(ByVal Value As String)
            sCodSolicita = CStr(Value)
        End Set
    End Property
    Property DesRpta() As String
        Get
            Return sDesRpta
        End Get
        Set(ByVal Value As String)
            sDesRpta = CStr(Value)
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

    Function EditarCodSolicita(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer, ByVal pCodProveedor As Integer) As String
        sMsg = "No se hizo reservas al Proveedor"

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_ReservaCodSolicita_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = pNroVersion
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = pCodProveedor
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sCodSolicita = dr.GetValue(dr.GetOrdinal("CodSolicita"))
                sDesRpta = dr.GetValue(dr.GetOrdinal("DesRpta"))
                sNroFile = dr.GetValue(dr.GetOrdinal("NroFile"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

    Function ConfirmaDeMozart() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "OPE_VersionReservaOK_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
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
        cn.Close()
        Return (sMsg)
    End Function

    Function Confirma() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "OPE_VersionReserva_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@DesLogOut", SqlDbType.VarChar, 8000)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
        cd.Parameters.Add("@PrecioRpta", SqlDbType.Money).Value = dPrecioRpta
        cd.Parameters.Add("@NroFile", SqlDbType.VarChar, 315).Value = sNroFile
        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = sDeslog
        cd.Parameters.Add("@CantDesLog", SqlDbType.Int).Value = iCantDesLog
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
        cn.Close()
        Return (sMsg)
    End Function

    Function Anula() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "OPE_VersionReservaAnula_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@DesLogOut", SqlDbType.VarChar, 8000)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
        cd.Parameters.Add("@DesLog", SqlDbType.Text).Value = sDeslog
        cd.Parameters.Add("@CantDesLog", SqlDbType.Int).Value = iCantDesLog
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
        cn.Close()
        Return (sMsg)
    End Function

End Class
