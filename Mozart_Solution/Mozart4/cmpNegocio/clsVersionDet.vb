Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsVersionDet
    Private iNroPedido As Integer
    Private iNroPropuesta As Integer
    Private iNroVersion As Integer
    Private iNroDia As Integer
    Private iNroOrden As Integer
    Private sHoraServicio As String
    Private iNroServicio As Integer
    Private iCodTipoServicio As Integer
    Private iCodTipoAcomodacion As Integer
    Private iNroDiaAnt As Integer
    Private iNroOrdAnt As Integer
    Private iNroSerAnt As Integer
    Private iCodTipoAcomAnt As Integer
    Private iCantAduSGL As Integer
    Private iCantAduDBL As Integer
    Private iCantAduTPL As Integer
    Private iCantAduCDL As Integer
    Private iCantNinSGL As Integer
    Private iCantNinDBL As Integer
    Private iCantNinTPL As Integer
    Private iCantNinCDL As Integer
    Private dMontoFijo As Double
    Private iRangoTarifa As Integer
    Private sOpcion As String

    Private sCodStsReserva As String
    Private sFchEmision As String
    Private sCodReserva As String
    Private sAerolinea As String
    Private sNroVuelo As String
    Private sFchVuelo As String
    Private sRutaVuelo As String
    Private sHoraLlegada As String
    Private sHoraSalida As String
    Private sCodUsuario As String
    ' otros campos
    Private iNroAlternativo As Integer
    Private sDesIncidencia As String

    ' solo para leer
    Private sFchSys As Date
    Private iCodProveedor As Integer
    Private sCodCiudad As String
    Private sCodSolicita As String

	Private sFchAdicional As String

	Private sFchRecordatorio As String

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

    Property NroDia() As Integer
        Get
            Return iNroDia
        End Get
        Set(ByVal Value As Integer)
            iNroDia = (Value)
        End Set
    End Property

    Property NroOrden() As Integer
        Get
            Return iNroOrden
        End Get
        Set(ByVal Value As Integer)
            iNroOrden = (Value)
        End Set
    End Property

    Property HoraServicio() As String
        Get
            Return sHoraServicio
        End Get
        Set(ByVal Value As String)
            sHoraServicio = CStr(Value)
        End Set
    End Property

    Property NroServicio() As Integer
        Get
            Return iNroServicio
        End Get
        Set(ByVal Value As Integer)
            iNroServicio = (Value)
        End Set
    End Property

    Property CodTipoServicio() As Integer
        Get
            Return iCodTipoServicio
        End Get
        Set(ByVal Value As Integer)
            iCodTipoServicio = (Value)
        End Set
    End Property

    Property CodTipoAcomodacion() As Integer
        Get
            Return iCodTipoAcomodacion
        End Get
        Set(ByVal Value As Integer)
            iCodTipoAcomodacion = (Value)
        End Set
    End Property

    Property NroDiaAnt() As Integer
        Get
            Return iNroDiaAnt
        End Get
        Set(ByVal Value As Integer)
            iNroDiaAnt = (Value)
        End Set
    End Property

    Property NroOrdAnt() As Integer
        Get
            Return iNroOrdAnt
        End Get
        Set(ByVal Value As Integer)
            iNroOrdAnt = (Value)
        End Set
    End Property

    Property NroSerAnt() As Integer
        Get
            Return iNroSerAnt
        End Get
        Set(ByVal Value As Integer)
            iNroSerAnt = (Value)
        End Set
    End Property

    Property CodTipoAcomAnt() As Integer
        Get
            Return iCodTipoAcomAnt
        End Get
        Set(ByVal Value As Integer)
            iCodTipoAcomAnt = (Value)
        End Set
    End Property

    Property CantAduSGL() As Integer
        Get
            Return iCantAduSGL
        End Get
        Set(ByVal Value As Integer)
            iCantAduSGL = (Value)
        End Set
    End Property

    Property CantAduDBL() As Integer
        Get
            Return iCantAduDBL
        End Get
        Set(ByVal Value As Integer)
            iCantAduDBL = (Value)
        End Set
    End Property

    Property CantAduTPL() As Integer
        Get
            Return iCantAduTPL
        End Get
        Set(ByVal Value As Integer)
            iCantAduTPL = (Value)
        End Set
    End Property

    Property CantAduCDL() As Integer
        Get
            Return iCantAduCDL
        End Get
        Set(ByVal Value As Integer)
            iCantAduCDL = (Value)
        End Set
    End Property


    Property CantNinSGL() As Integer
        Get
            Return iCantNinSGL
        End Get
        Set(ByVal Value As Integer)
            iCantNinSGL = (Value)
        End Set
    End Property

    Property CantNinDBL() As Integer
        Get
            Return iCantNinDBL
        End Get
        Set(ByVal Value As Integer)
            iCantNinDBL = (Value)
        End Set
    End Property

    Property CantNinTPL() As Integer
        Get
            Return iCantNinTPL
        End Get
        Set(ByVal Value As Integer)
            iCantNinTPL = (Value)
        End Set
    End Property

    Property CantNinCDL() As Integer
        Get
            Return iCantNinCDL
        End Get
        Set(ByVal Value As Integer)
            iCantNinCDL = (Value)
        End Set
    End Property

    Property MontoFijo() As Double
        Get
            Return dMontoFijo
        End Get
        Set(ByVal Value As Double)
            dMontoFijo = (Value)
        End Set
    End Property

    Property RangoTarifa() As Integer
        Get
            Return iRangoTarifa
        End Get
        Set(ByVal Value As Integer)
            iRangoTarifa = (Value)
        End Set
    End Property

    Property Opcion() As String
        Get
            Return sOpcion
        End Get
        Set(ByVal Value As String)
            sOpcion = CStr(Value)
        End Set
    End Property


    Property CodStsReserva() As String
        Get
            Return sCodStsReserva
        End Get
        Set(ByVal Value As String)
            sCodStsReserva = CStr(Value)
        End Set
    End Property

    Property FchEmision() As String
        Get
            Return sFchEmision
        End Get
        Set(ByVal Value As String)
            sFchEmision = CStr(Value)
        End Set
    End Property

    Property CodReserva() As String
        Get
            Return sCodReserva
        End Get
        Set(ByVal Value As String)
            sCodReserva = CStr(Value)
        End Set
    End Property

    Property Aerolinea() As String
        Get
            Return sAerolinea
        End Get
        Set(ByVal Value As String)
            sAerolinea = CStr(Value)
        End Set
    End Property

    Property NroVuelo() As String
        Get
            Return sNroVuelo
        End Get
        Set(ByVal Value As String)
            sNroVuelo = CStr(Value)
        End Set
    End Property

    Property FchVuelo() As String
        Get
            Return sFchVuelo
        End Get
        Set(ByVal Value As String)
            sFchVuelo = CStr(Value)
        End Set
    End Property

    Property RutaVuelo() As String
        Get
            Return sRutaVuelo
        End Get
        Set(ByVal Value As String)
            sRutaVuelo = CStr(Value)
        End Set
    End Property

    Property HoraLlegada() As String
        Get
            Return sHoraLlegada
        End Get
        Set(ByVal Value As String)
            sHoraLlegada = CStr(Value)
        End Set
    End Property

    Property HoraSalida() As String
        Get
            Return sHoraSalida
        End Get
        Set(ByVal Value As String)
            sHoraSalida = CStr(Value)
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

    ' otros campos
    Property NroAlternativo() As Integer
        Get
            Return iNroAlternativo
        End Get
        Set(ByVal Value As Integer)
            iNroAlternativo = (Value)
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

    Property CodCiudad() As String
        Get
            Return sCodCiudad
        End Get
        Set(ByVal Value As String)
            sCodCiudad = CStr(Value)
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

	Property DesIncidencia() As String
		Get
			Return sDesIncidencia
		End Get
		Set(ByVal Value As String)
			sDesIncidencia = CStr(Value)
		End Set
	End Property

	Property FchAdicional() As String
		Get
			Return sFchAdicional
		End Get
		Set(ByVal Value As String)
			sFchAdicional = CStr(Value)
		End Set
	End Property

	Property FchRecordatorio() As String
		Get
			Return sFchRecordatorio
		End Get
		Set(ByVal Value As String)
			sFchRecordatorio = CStr(Value)
		End Set
	End Property

	Function Grabar() As String
		Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
		Dim cd As New SqlCommand
		cd.Connection = cn
		cd.CommandText = "VTA_VersionServicio_I"
		cd.CommandType = CommandType.StoredProcedure

		Dim pa As New SqlParameter
		pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
		pa.Direction = ParameterDirection.Output
		pa.Value = ""
		cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
		cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
		cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
		cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
		cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
		cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = sHoraServicio
		cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
		cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = iCodTipoServicio
		cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = iCodTipoAcomodacion
		cd.Parameters.Add("@NroDiaAnt", SqlDbType.SmallInt).Value = iNroDiaAnt
		cd.Parameters.Add("@NroOrdenAnt", SqlDbType.SmallInt).Value = iNroOrdAnt
		cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = iNroSerAnt
		cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = iCantAduSGL
		cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = iCantAduDBL
		cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = iCantAduTPL
		cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = iCantAduCDL
		cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = iCantNinSGL
		cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = iCantNinDBL
		cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = iCantNinTPL
		cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = iCantNinCDL
		cd.Parameters.Add("@MontoFijo", SqlDbType.Money).Value = dMontoFijo
		cd.Parameters.Add("@RangoTarifa", SqlDbType.TinyInt).Value = iRangoTarifa
		cd.Parameters.Add("@Opcion", SqlDbType.Char, 1).Value = sOpcion
		cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
		cd.Parameters.Add("@HoraSalida", SqlDbType.Char, 8).Value = sHoraSalida
		cd.Parameters.Add("@HoraLlegada", SqlDbType.Char, 8).Value = sHoraLlegada
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

	Function Editar(ByVal pNroServicio As Integer, ByVal pEstado As String) As String
        sMsg = "No existe registro " & sCodUsuario

        pEstado = "N"

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "peru4me_new.VTA_ServicioNroServicio_S_NEW"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = pNroServicio
        cd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = pEstado

        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sCodCiudad = dr.GetValue(dr.GetOrdinal("CodCiudad"))
                iCodProveedor = dr.GetValue(dr.GetOrdinal("CodProveedor"))
                iCodTipoServicio = dr.GetValue(dr.GetOrdinal("CodTipoServicio"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function


    Function CargaServicios(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
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

    Function CargaServicios(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer, ByVal pCodProveedor As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        arParms(3) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(3).Value = pCodProveedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionServicioCodProveedor_S", arParms)
        Return (ds)
    End Function

    Function CargarBoletos(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionBoletoReserva_S", arParms)
        Return (ds)
    End Function


    Function CargarBoletosTerrestre(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionBoletoTerrestre_S", arParms)
        Return (ds)
    End Function

    Function CargarHotel(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionHotelReserva_S", arParms)
        Return (ds)
    End Function

    Function CargaHotelAlternativo(ByVal pCodProveedor As Integer, ByVal pCodCiudad As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionHotelAlternativo_S", arParms)
        Return (ds)
    End Function

    Function GrabarBoletoReserva() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionBoletoReserva_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDia", SqlDbType.TinyInt).Value = iNroDia
        cd.Parameters.Add("@NroOrden", SqlDbType.TinyInt).Value = iNroOrden
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodStsReserva", SqlDbType.Char, 2).Value = sCodStsReserva
        cd.Parameters.Add("@FchEmision", SqlDbType.Char, 8).Value = sFchEmision
        cd.Parameters.Add("@CodReserva", SqlDbType.Char, 10).Value = sCodReserva
        cd.Parameters.Add("@Aerolinea", SqlDbType.VarChar, 25).Value = sAerolinea
        cd.Parameters.Add("@NroVuelo", SqlDbType.Char, 10).Value = sNroVuelo
        cd.Parameters.Add("@FchVuelo", SqlDbType.Char, 8).Value = sFchVuelo
        cd.Parameters.Add("@RutaVuelo", SqlDbType.VarChar, 25).Value = sRutaVuelo
        cd.Parameters.Add("@HoraLlegada", SqlDbType.Char, 5).Value = sHoraLlegada
        cd.Parameters.Add("@HoraSalida", SqlDbType.Char, 5).Value = sHoraSalida
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

    Function GrabarHotelReserva() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionLink_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodStsReserva", SqlDbType.Char, 2).Value = sCodStsReserva
        cd.Parameters.Add("@NroAlternativo", SqlDbType.Int).Value = iNroAlternativo
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


    Function GrabarCambioHotel() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionCambiarHotel_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
        cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = iNroSerAnt
        cd.Parameters.Add("@CodTipoAcomodacionAnt", SqlDbType.SmallInt).Value = iCodTipoAcomAnt
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = iCodTipoAcomodacion
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


    Function GrabarCambioHora() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionCambiarHora_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = sHoraServicio
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


    Function GrabarCambioOrden() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionCambiarOrden_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDiaAnt", SqlDbType.SmallInt).Value = iNroDiaAnt
        cd.Parameters.Add("@NroOrdAnt", SqlDbType.SmallInt).Value = iNroOrdAnt
        cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = sHoraServicio
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
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
        cn.Close()
        Return (sMsg)
    End Function

    Function CargaServiciosHotel(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionServicioHotel_S", arParms)
        Return (ds)
    End Function

    Function CargaProveedores(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionProveedoresDDL_S", arParms)
        Return (ds)
    End Function

    Function CargaProveedoresReserva(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = pNroPedido
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = pNroPropuesta
        arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
        arParms(2).Value = pNroVersion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionProveedoresReserva_S", arParms)
        Return (ds)
    End Function


    Function GrabarCambioStsReserva() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionReservaConfirma_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
        cd.Parameters.Add("@CodSolicita", SqlDbType.Char, 1).Value = sCodSolicita
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


    Function GrabarCambioStsServicio() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionOF_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDia", SqlDbType.TinyInt).Value = iNroDia
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodStsReserva", SqlDbType.Char, 2).Value = sCodStsReserva
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


    Function GrabarIncidencia() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionIncidencia_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@DesIncidencia", SqlDbType.Char, 100).Value = sDesIncidencia
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


    Function CargaIncidencia(ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_IncidenciaxFchReserva_S", arParms)
        Return (ds)
    End Function

    Function CargaIncidencia(ByVal pFechaInicio As String, ByVal pFechaFin As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FechaInicio", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FechaFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_IncidenciaxCodVendedor_S", arParms)
        Return (ds)
    End Function


    Function CargaClienteEnTour(ByVal pFechaInicio As String, ByVal pFechaFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClienteEnTour_S", arParms)
        Return (ds)
    End Function

    Function CargaClienteEnTour(ByVal pFechaInicio As String, ByVal pFechaFin As String, ByVal pCodVendedor As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFechaInicio
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFechaFin
        arParms(2) = New SqlParameter("@CodVendedor", SqlDbType.Char, 15)
        arParms(2).Value = pCodVendedor
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClienteEnTourxCodVendedor_S", arParms)
        Return (ds)
    End Function

	Function CargaServiciosAdicional(ByVal pNroPedido As Integer, ByVal pNroPropuesta As Integer, ByVal pNroVersion As Integer) As DataSet
		Dim arParms() As SqlParameter = New SqlParameter(2) {}
		arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
		arParms(0).Value = pNroPedido
		arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
		arParms(1).Value = pNroPropuesta
		arParms(2) = New SqlParameter("@NroVersion", SqlDbType.Int)
		arParms(2).Value = pNroVersion
		Dim ds As New DataSet
		ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_VersionServicioAd_S", arParms)
		Return (ds)
	End Function

	Function GrabarAD() As String
		Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
		Dim cd As New SqlCommand
		cd.Connection = cn
		cd.CommandText = "VTA_VersionServicioAD_I"
		cd.CommandType = CommandType.StoredProcedure

		Dim pa As New SqlParameter
		pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
		pa.Direction = ParameterDirection.Output
		pa.Value = ""
		cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
		cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
		cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = iNroVersion
		cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = iNroDia
		cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
		cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = sHoraServicio
		cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
		cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = iCodTipoServicio
		cd.Parameters.Add("@CodTipoAcomodacion", SqlDbType.SmallInt).Value = iCodTipoAcomodacion
		cd.Parameters.Add("@NroDiaAnt", SqlDbType.SmallInt).Value = iNroDiaAnt
		cd.Parameters.Add("@NroOrdenAnt", SqlDbType.SmallInt).Value = iNroOrdAnt
		cd.Parameters.Add("@NroServicioAnt", SqlDbType.Int).Value = iNroSerAnt
		cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = iCantAduSGL
		cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = iCantAduDBL
		cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = iCantAduTPL
		cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = iCantAduCDL
		cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = iCantNinSGL
		cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = iCantNinDBL
		cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = iCantNinTPL
		cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = iCantNinCDL
		cd.Parameters.Add("@MontoFijo", SqlDbType.Money).Value = dMontoFijo
		cd.Parameters.Add("@RangoTarifa", SqlDbType.TinyInt).Value = iRangoTarifa
		cd.Parameters.Add("@Opcion", SqlDbType.Char, 1).Value = sOpcion
		cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
		cd.Parameters.Add("@HoraSalida", SqlDbType.Char, 8).Value = sHoraSalida
		cd.Parameters.Add("@HoraLlegada", SqlDbType.Char, 8).Value = sHoraLlegada
		cd.Parameters.Add("@FchAdServ", SqlDbType.Char, 8).Value = sFchAdicional
		cd.Parameters.Add("@FchRecord", SqlDbType.Char, 8).Value = sFchRecordatorio
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