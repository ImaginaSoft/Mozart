
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsPedido
    Private iNroPedido As Integer
    Private sDesPedido As String
    Private dFchPedido As Date
    Private sStsPedido As String
    Private iCodCliente As Integer
    Private sIdioma As String
    Private sNroRecordatorio As String
    Private sFchUltEnvio As String
    Private iCodMotivo As Integer
    Private iAdultos As Integer
    Private iNinos As Integer
    Private iAnoAtencion As Integer
    Private iMesAtencion As Integer
    Private sCodZonaVta As String
    Private sCodUsuario As String

    ' solo para leer
    Private sNomVendedor As String
    Private sFchSys As Date
    Private sStsPedidoAnterior As String
    Private dFchAtencion As Date
    Private dFchUltEnvio As Date

    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property NroPedido() As Integer
        Get
            Return iNroPedido
        End Get
        Set(ByVal Value As Integer)
            iNroPedido = (Value)
        End Set
    End Property

    Property DesPedido() As String
        Get
            Return sDesPedido
        End Get
        Set(ByVal Value As String)
            sDesPedido = CStr(Value)
        End Set
    End Property

    Property FchPedido() As Date
        Get
            Return dFchPedido
        End Get
        Set(ByVal Value As Date)
            dFchPedido = Value
        End Set
    End Property

    Property StsPedido() As String
        Get
            Return sStsPedido
        End Get
        Set(ByVal Value As String)
            sStsPedido = CStr(Value)
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

    Property FchUltEnvio() As String
        Get
            Return sFchUltEnvio
        End Get
        Set(ByVal Value As String)
            sFchUltEnvio = CStr(Value)
        End Set
    End Property

    Property CodMotivo() As Integer
        Get
            Return iCodMotivo
        End Get
        Set(ByVal Value As Integer)
            iCodMotivo = (Value)
        End Set
    End Property

    Property Adultos() As Integer
        Get
            Return iAdultos
        End Get
        Set(ByVal Value As Integer)
            iAdultos = (Value)
        End Set
    End Property

    Property Ninos() As Integer
        Get
            Return iNinos
        End Get
        Set(ByVal Value As Integer)
            iNinos = (Value)
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

    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    Property FchSys() As Date
        Get
            Return sFchSys
        End Get
        Set(ByVal Value As Date)
            sFchSys = Value
        End Set
    End Property

    Property NomVendedor() As String
        Get
            Return sNomVendedor
        End Get
        Set(ByVal Value As String)
            sNomVendedor = CStr(Value)
        End Set
    End Property

    Property StsPedidoAnterior() As String
        Get
            Return sStsPedidoAnterior
        End Get
        Set(ByVal Value As String)
            sStsPedidoAnterior = CStr(Value)
        End Set
    End Property

    Property FchAtencion() As Date
        Get
            Return dFchAtencion
        End Get
        Set(ByVal Value As Date)
            dFchAtencion = Value
        End Set
    End Property

    Property FechaUltEnvio() As Date
        Get
            Return dFchUltEnvio
        End Get
        Set(ByVal Value As Date)
            dFchUltEnvio = Value
        End Set
    End Property

    Function CargaxFchIngreso(ByVal pCodZonaVta As String, ByVal pFechainicio As String, ByVal pFechaFin As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(1).Value = pFechainicio
        arParms(2) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(2).Value = pFechaFin
        arParms(3) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(3).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_RevisionPedido_S", arParms)
        Return (ds)
    End Function

    Function CargaxFchIngreso(ByVal pCodZonaVta As String, ByVal pStsPedido As String, ByVal pFechainicio As String, ByVal pFechaFin As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@StsPedido", SqlDbType.Char, 1)
        arParms(1).Value = pStsPedido
        arParms(2) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(2).Value = pFechainicio
        arParms(3) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(3).Value = pFechaFin
        arParms(4) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(4).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_RevisionPedidoSts_S", arParms)
        Return (ds)
    End Function

    Function CargaxFchIngresoVendedor(ByVal pCodZonaVta As String, ByVal pCodVendedor As String, ByVal pFechainicio As String, ByVal pFechaFin As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(1).Value = pCodVendedor
        arParms(2) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(2).Value = pFechainicio
        arParms(3) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(3).Value = pFechaFin
        arParms(4) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(4).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_RevisionPedidoVendedor_S", arParms)
        Return (ds)
    End Function

    Function CargaxFchIngresoVendedor(ByVal pCodZonaVta As String, ByVal pCodVendedor As String, ByVal pStsPedido As String, ByVal pFechainicio As String, ByVal pFechaFin As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(1).Value = pCodVendedor
        arParms(2) = New SqlParameter("@StsPedido", SqlDbType.Char, 1)
        arParms(2).Value = pStsPedido
        arParms(3) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(3).Value = pFechainicio
        arParms(4) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(4).Value = pFechaFin
        arParms(5) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(5).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_RevisionPedidoVendedorSts_S", arParms)
        Return (ds)
    End Function


    Function CargaxFchSolicita(ByVal pCodCliente As Integer, ByVal pFechainicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodCliente", SqlDbType.Int)
        arParms(0).Value = pCodCliente
        arParms(1) = New SqlParameter("@Fechainicio", SqlDbType.Char, 8)
        arParms(1).Value = pFechainicio
        arParms(2) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(2).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoxFchSolicita_S", arParms)
        Return (ds)
    End Function

    Function CargarAtencion(ByVal pCodZonaVta As String, ByVal pMesIni As Integer, ByVal pAnoIni As Integer, ByVal pMesFin As Integer, ByVal pAnoFin As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@MesIni", SqlDbType.Int)
        arParms(1).Value = pMesIni
        arParms(2) = New SqlParameter("@AnoIni", SqlDbType.Int)
        arParms(2).Value = pAnoIni
        arParms(3) = New SqlParameter("@MesFin", SqlDbType.Int)
        arParms(3).Value = pMesFin
        arParms(4) = New SqlParameter("@AnoFin", SqlDbType.Int)
        arParms(4).Value = pAnoFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoAtencion_S", arParms)
        Return (ds)
    End Function

    Function CargarAtencion(ByVal pCodZonaVta As String, ByVal pMesIni As Integer, ByVal pAnoIni As Integer, ByVal pMesFin As Integer, ByVal pAnoFin As Integer, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@MesIni", SqlDbType.Int)
        arParms(1).Value = pMesIni
        arParms(2) = New SqlParameter("@AnoIni", SqlDbType.Int)
        arParms(2).Value = pAnoIni
        arParms(3) = New SqlParameter("@MesFin", SqlDbType.Int)
        arParms(3).Value = pMesFin
        arParms(4) = New SqlParameter("@AnoFin", SqlDbType.Int)
        arParms(4).Value = pAnoFin
        arParms(5) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(5).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoAtencionVendedor_S", arParms)
        Return (ds)
    End Function

    Function CargaPasajeroCumpleanos(ByVal pMes As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PasajeroCumpleanos_S", New SqlParameter("@Mes", pMes))
        Return (ds)
    End Function


    Function CargaTareas(ByVal pNroPedido As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoTareas_S", New SqlParameter("@NroPedido", pNroPedido))
        Return (ds)
    End Function

    Function CargaEnvioKit(ByVal pFchini As String, ByVal pFchFin As String, ByVal pStsEnvioKit As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Fchini", SqlDbType.Char, 8)
        arParms(0).Value = pFchini
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin
        arParms(2) = New SqlParameter("@StsEnvioKit", SqlDbType.Char, 1)
        arParms(2).Value = pStsEnvioKit
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_EnvioKitxSts_S", arParms)
        Return (ds)
    End Function

    Function CargaEnvioKitProgramado() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_EnvioKitProgramado_S")
        Return (ds)
    End Function

    Function CargarCierrePeriodoVentas(ByVal pNroPedido As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoCierrePeriodo_S", arParms)
        Return (ds)
    End Function

    Function GrabarStsPedido() As String
        Dim rutina As New clsRutinas

        Dim objRutina As New clsRutinas
        If sNroRecordatorio.Trim.Length = 0 Then
            sNroRecordatorio = 0
        Else
            If Not IsNumeric(sNroRecordatorio) Then
                Return ("Error: Nro. Recordatorio es númerico")
            ElseIf Not objRutina.LeeRecordatorio(sIdioma, sNroRecordatorio) Then
                Return ("Error: No existe número de Recordatorio ")
            ElseIf sFchUltEnvio.Trim.Length = 0 Then
                Return ("Error: Fecha de envio del último Recordatorio es obligatorio")
            ElseIf Not IsDate(sFchUltEnvio.Trim) Then
                Return ("Error: la fecha de envio del último Recordatorio es incorrecta")
            End If
        End If

        If sStsPedidoAnterior = "S" Then
            If sStsPedido = "S" Or sStsPedido = "A" Or sStsPedido = "N" Then
                'OK
            Else
                Return ("Error: De SOLICITADO puede pasar a NEGOCIACION o ANULADO")
            End If
        End If
        If sStsPedidoAnterior = "N" Then
            If sStsPedido = "S" Or sStsPedido = "A" Or sStsPedido = "N" Then
                'OK
            Else
                Return ("Error: De NEGOCIACION puede pasar a SOLICITADO o ANULADO")
            End If
        End If
        If sStsPedidoAnterior = "A" Then
            If sStsPedido = "S" Or sStsPedido = "N" Then
                'OK
            Else
                Return ("Error: De ANULADO puede pasar a SOLICITADO o NEGOCIACION")
            End If
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoStsPedido_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@StsPedido", SqlDbType.Char, 1).Value = sStsPedido
        cd.Parameters.Add("@NroRecordatorio", SqlDbType.Int).Value = sNroRecordatorio
        cd.Parameters.Add("@FchUltEnvio", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(sFchUltEnvio)
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = sIdioma
        cd.Parameters.Add("@CodMotivo", SqlDbType.TinyInt).Value = iCodMotivo
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function Editar() As String
        sMsg = "No existe Pedido " & CStr(iNroPedido)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PedidoNroPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido

        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                iNroPedido = dr.GetValue(dr.GetOrdinal("NroPedido"))
                sDesPedido = dr.GetValue(dr.GetOrdinal("DesPedido"))
                dFchPedido = dr.GetValue(dr.GetOrdinal("FchPedido"))
                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchUltEnvio"))) Then
                    dFchUltEnvio = dr.GetValue(dr.GetOrdinal("FchUltEnvio"))
                End If
                sNomVendedor = dr.GetValue(dr.GetOrdinal("NomVendedor"))
                sStsPedido = dr.GetValue(dr.GetOrdinal("CodStsPedido"))
                sIdioma = dr.GetValue(dr.GetOrdinal("Idioma"))
                sNroRecordatorio = dr.GetValue(dr.GetOrdinal("NroRecordatorio"))
                iCodMotivo = dr.GetValue(dr.GetOrdinal("CodMotivo"))
                iAdultos = dr.GetValue(dr.GetOrdinal("CantAdultos"))
                iNinos = dr.GetValue(dr.GetOrdinal("CantNinos"))
                sCodZonaVta = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
                If dr.GetValue(dr.GetOrdinal("MesAtencion")) > 0 And dr.GetValue(dr.GetOrdinal("AnoAtencion")) > 0 Then
                    If dr.GetValue(dr.GetOrdinal("MesAtencion")) > 0 Then
                        If dr.GetValue(dr.GetOrdinal("MesAtencion")) < 10 Then
                            dFchAtencion = CDate("01/0" & CStr(dr.GetValue(dr.GetOrdinal("MesAtencion"))) & "/" & CStr(dr.GetValue(dr.GetOrdinal("AnoAtencion"))))
                        Else
                            dFchAtencion = CDate("01/" & CStr(dr.GetValue(dr.GetOrdinal("MesAtencion"))) & "/" & CStr(dr.GetValue(dr.GetOrdinal("AnoAtencion"))))
                        End If
                    End If
                End If
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

    Function Borrar(ByVal pNroPedido As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Pedido_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
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

    Function TotalPagoCliente(ByVal pNroPedido As Integer, ByVal pCodMoneda As String) As Double
        Dim Total As Double = 0

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_EditaTotal_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = pCodMoneda
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                Total = dr.GetValue(dr.GetOrdinal("Total"))
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (Total)
    End Function

    Function ReembolsoAlCliente(ByVal pNroPedido As Integer, ByVal pCodMoneda As String) As Double
        Dim Total As Double = 0

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_EditaReembolso_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = pCodMoneda
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                Total = dr.GetValue(dr.GetOrdinal("Total"))
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (Total)
    End Function
    'Uso del seguro de cancelacion de viaje
    Function SeguroCancelacionViaje(ByVal pNroPedido As Integer, ByVal pCodMoneda As String) As Double
        Dim Total As Double = 0

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_EditaSeguroCancelacion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = pCodMoneda
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                Total = dr.GetValue(dr.GetOrdinal("Total"))
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (Total)
    End Function

    Function EditaCorrelativo(ByVal pNroPedido As Integer) As Integer
        Dim correlativo As Integer = 0

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "CPC_EditaPedido_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                correlativo = dr.GetValue(dr.GetOrdinal("Correlativo"))
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (correlativo)
    End Function


    Function LiqPedidoDocRevisado(ByVal pNroPedido As Integer, ByVal pCodMoneda As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@CodMoneda", SqlDbType.Char, 1)
        arParms(1).Value = pCodMoneda
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_PendRegistroVentasDetalle_S", arParms)
        Return (ds)
    End Function

    Function LiqPedidoDocPendCuadre(ByVal pNroPedido As Integer, ByVal pCodMoneda As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@CodMoneda", SqlDbType.Char, 1)
        arParms(1).Value = pCodMoneda
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_PendientesCuadre_S", arParms)
        Return (ds)
    End Function

    Function LiqPedidoSinBoleta(ByVal pNroPedido As Integer, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_PedidoLiquida_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function ActualizaFchEnvioKit(ByVal pNroPedido As Integer, ByVal pFchEnvioKit As String, ByVal pStsEnvioKit As String, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_EnvioKitFch_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@FchEnvioKit", SqlDbType.Char, 8).Value = pFchEnvioKit
        cd.Parameters.Add("@StsEnvioKit", SqlDbType.Char, 1).Value = pStsEnvioKit
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function

    Function ActualizaObsEnvioKit(ByVal pNroPedido As Integer, ByVal pObsEnvioKit As String, ByVal pStsEnvioKit As String, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_EnvioKitObs_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido
        cd.Parameters.Add("@ObsEnvioKit", SqlDbType.VarChar, 100).Value = pObsEnvioKit
        cd.Parameters.Add("@StsEnvioKit", SqlDbType.Char, 1).Value = pStsEnvioKit
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)
    End Function


    Function VentaPeriodoxVen(ByVal pFchFinPerido As String, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchFinPeriodo", SqlDbType.Char, 8)
        arParms(0).Value = pFchFinPerido
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "EST_VentaPeriodoxVen_S", arParms)
        Return (ds)
    End Function


    Function VentaTrimestrexVen(ByVal pAno As Integer, ByVal pTrim As Integer, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Ano", SqlDbType.Int)
        arParms(0).Value = pAno
        arParms(1) = New SqlParameter("@Trim", SqlDbType.Int)
        arParms(1).Value = pTrim
        arParms(2) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(2).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "EST_VentaTrimxVen_S", arParms)
        Return (ds)
    End Function

    Function VentaAnualxVen(ByVal pAno As Integer, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Ano", SqlDbType.Int)
        arParms(0).Value = pAno
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "EST_VentaAnualxVen_S", arParms)
        Return (ds)
    End Function

End Class