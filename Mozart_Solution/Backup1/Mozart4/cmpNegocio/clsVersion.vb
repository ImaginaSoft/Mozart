Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsVersion
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private iNroPedido As Integer
    Private iNroPropuesta As Integer
    Private iNroVersion As Integer
    Private iCodCliente As Integer
    Private sCodZonaVta As String
    Private sFlagEdita As String
    Private sFlagPublica As String
    Private sStsVersion As String
    Private sDesVersion As String
    Private sCodUsuario As String

    'Campos tarea
    Private iNroTarea As Integer
    Private sFchTarea As String
    Private sDesTarea As String
    Private sStsTarea As String
    Private sCodVendedor As String
    Private sFlagFchRevision As String

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

    Property CodCliente() As Integer
        Get
            Return iCodCliente
        End Get
        Set(ByVal Value As Integer)
            iCodCliente = (Value)
        End Set
    End Property

    Property CodZonaVta() As String
        Get
            Return sCodZonaVta
        End Get
        Set(ByVal Value As String)
            sCodZonaVta = CStr(Value)
        End Set
    End Property

    Property FlagEdita() As String
        Get
            Return sFlagEdita
        End Get
        Set(ByVal Value As String)
            sFlagEdita = CStr(Value)
        End Set
    End Property
    Property FlagPublica() As String
        Get
            Return sFlagPublica
        End Get
        Set(ByVal Value As String)
            sFlagPublica = CStr(Value)
        End Set
    End Property
    Property StsVersion() As String
        Get
            Return sStsVersion
        End Get
        Set(ByVal Value As String)
            sStsVersion = CStr(Value)
        End Set
    End Property
    Property DesVersion() As String
        Get
            Return sDesVersion
        End Get
        Set(ByVal Value As String)
            sDesVersion = CStr(Value)
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


    ' Campos Tarea
    Property NroTarea() As Integer
        Get
            Return iNroTarea
        End Get
        Set(ByVal Value As Integer)
            iNroTarea = (Value)
        End Set
    End Property

    Property FchTarea() As String
        Get
            Return sFchTarea
        End Get
        Set(ByVal Value As String)
            sFchTarea = CStr(Value)
        End Set
    End Property

    Property DesTarea() As String
        Get
            Return sDesTarea
        End Get
        Set(ByVal Value As String)
            sDesTarea = CStr(Value)
        End Set
    End Property

    Property StsTarea() As String
        Get
            Return sStsTarea
        End Get
        Set(ByVal Value As String)
            sStsTarea = CStr(Value)
        End Set
    End Property

    Property CodVendedor() As String
        Get
            Return sCodVendedor
        End Get
        Set(ByVal Value As String)
            sCodVendedor = CStr(Value)
        End Set
    End Property

    Property FlagFchRevision() As String
        Get
            Return sFlagFchRevision
        End Get
        Set(ByVal Value As String)
            sFlagFchRevision = CStr(Value)
        End Set
    End Property

    Function CargarVersionServicios(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionServicio_S", arParms)
        Return (ds)
    End Function


    Function CargarVersionesFacturada(ByVal pCodZonaVta As String, ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(1).Value = pFechaInicio
        arParms(2) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(2).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionFacturada_S", arParms)
        Return (ds)
    End Function

    Function CargarVersionesFacturada(ByVal pCodVendedor As String, ByVal pCodZonaVta As String, ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(0).Value = pCodVendedor
        arParms(1) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(1).Value = pCodZonaVta
        arParms(2) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(2).Value = pFechaInicio
        arParms(3) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(3).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionFacturadaVendedor_S", arParms)
        Return (ds)
    End Function

    Function CargarVersionesFacturadaIdioma(ByVal pCodZonaVta As String, ByVal pIdioma As String, ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        arParms(2) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(2).Value = pFechaInicio
        arParms(3) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(3).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionFacturadaIdioma_S", arParms)
        Return (ds)
    End Function


    Function CargarVersionesFacturadaIdioma(ByVal pCodVendedor As String, ByVal pCodZonaVta As String, ByVal pIdioma As String, ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(0).Value = pCodVendedor
        arParms(1) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(1).Value = pCodZonaVta
        arParms(2) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(2).Value = pIdioma
        arParms(3) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(3).Value = pFechaInicio
        arParms(4) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(4).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionFacturadaVendedorIdioma_S", arParms)
        Return (ds)
    End Function



    Function ProveedorReservasPendientes(ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ReservasPendientesProveedor_S", arParms)
        Return (ds)
    End Function

    Function ReservasPendientes(ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ReservasPendientes_S", arParms)
        Return (ds)
    End Function

    Function ReservasPendientes(ByVal pFechaInicio As String, ByVal pFechaFin As String, ByVal pCodProveedor As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        arParms(2) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(2).Value = pCodProveedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ReservasPendientesCodProveedor_S", arParms)
        Return (ds)
    End Function

    Function ReservasPendientes(ByVal pFechaInicio As String, ByVal pFechaFin As String, ByVal pCodProveedor As Integer, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        arParms(2) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(2).Value = pCodProveedor
        arParms(3) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(3).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ReservasPendientesProvVend_S", arParms)
        Return (ds)
    End Function

    Function ReservasPendientesVend(ByVal pFechaInicio As String, ByVal pFechaFin As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_ReservasPendientesVendedor_S", arParms)
        Return (ds)
    End Function

    Function CierrePeriodoVentas(ByVal pCodUsuario As String, ByVal pFchIniPeriodo As String, ByVal pFchFinPeriodo As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionFacturadaCierre_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@FchIniPeriodo", SqlDbType.Char, 8).Value = pFchIniPeriodo
        cd.Parameters.Add("@FchFinPeriodo", SqlDbType.Char, 8).Value = pFchFinPeriodo
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
        cn.Close()
        Return (sMsg)
    End Function


    Function GrabaTareas() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Tarea_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@DesTarea", SqlDbType.VarChar, 50).Value = sDesTarea
        cd.Parameters.Add("@FchTarea", SqlDbType.Char, 8).Value = sFchTarea
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = iNroVersion
        cd.Parameters.Add("@CodVendedor", SqlDbType.Char, 15).Value = sCodVendedor
        cd.Parameters.Add("@FlagFchRevision", SqlDbType.Char, 1).Value = sFlagFchRevision
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

    Function ActualizaStsTarea() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_TareaSts_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroTarea", SqlDbType.SmallInt).Value = iNroTarea
        cd.Parameters.Add("@StsTarea", SqlDbType.Char, 1).Value = sStsTarea
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = iNroVersion
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
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

    Function Editar(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As String
        sMsg = "No existe registro " & sCodUsuario

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim dr As SqlDataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "VTA_VersionNroVersion_S", arParms)
        While dr.Read()
            sCodZonaVta = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
            sFlagEdita = dr.GetValue(dr.GetOrdinal("FlagEdita"))
            sFlagPublica = dr.GetValue(dr.GetOrdinal("FlagPublica"))
            sStsVersion = dr.GetValue(dr.GetOrdinal("CodStsVersion"))
            sDesVersion = dr.GetValue(dr.GetOrdinal("DesVersion"))
            iCodCliente = dr.GetValue(dr.GetOrdinal("CodCliente"))
            sCodVendedor = dr.GetValue(dr.GetOrdinal("CodVendedor"))
            sMsg = "OK"
        End While
        Return (sMsg)
    End Function

    Function Borrar(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As String
        Dim objRutina As New clsRutinas

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Version_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = pNroVersion
        sMsg = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = objRutina.fncErroresSQL(ex1.Errors)
            If sMsg = "547" Then
                sMsg = "Si desea eliminar la Versión, primero debe eliminar todos los servicios y links"
            End If
        Catch ex2 As System.Exception
            sMsg = "Error General: " & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)

    End Function

    Function Copia(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionCopia_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = pNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = pNroVersion
        sMsg = ""
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error General: " & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)

    End Function

End Class
