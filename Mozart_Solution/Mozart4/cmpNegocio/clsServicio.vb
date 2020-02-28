Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsServicio
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private iNroServicio As Integer
    Private iCodProveedor As Integer
    Private sCodCiudad As String
    Private iCodTipoServicio As Integer
    Private sStsServicio As String
    Private sDesProveedor As String
    Private sDesObservacion As String
    Private sFlagValoriza As String
    Private sFlagItinerario As String
    Private sFlagItiProveedor As String
    Private sFlagPrecio As String
    Private dMontoFijo As Double
    Private sFchIngreso As String
    Private sCodSerOperador As String
    Private sTipoRecorrido As String
    Private sCodStsReservaIni As String
    Private sFlagDesayuno As String
    Private sFlagAlmuerzo As String
    Private sFlagCena As String
    Private sFlagBoxLunch As String
    Private sFlagBoxBreakfast As String
    Private sFlagPicnic As String
    Private sCaraEspeServicio As String  ' español
    Private sCaraEspeServicio2 As String ' ingles
    Private sCaraEspeServicio3 As String ' portugués
    Private sHoraInicioServicio As String
	Private sFlagServicioAge As String
	Private sFlagAdicional As String
	Private sCodUsuario As String
    Private m_Imagen As Byte()
    Private m_Imagen2 As Byte()
    Private m_Imagen3 As Byte()

    Private sFlagImg01 As String
    Private sFlagImg02 As String
    Private sFlagImg03 As String

    Private sNomProveedor As String
    Private sNomCiudad As String
    Private sTipoServicio As String

    Private sDireccion As String
    Private sValoracionHTL As String
    Private sNombreHTL As String
    Private sTelefono As String
    Private sDesHTL As String
    Private sDesHTLI As String
    Private sDesHTLP As String

    Property NroServicio() As Integer
        Get
            Return iNroServicio
        End Get
        Set(ByVal Value As Integer)
            iNroServicio = (Value)
        End Set
    End Property

    Public Property Imagen() As Byte()
        Get
            Return m_Imagen
        End Get
        Set(ByVal value As Byte())
            m_Imagen = value
        End Set
    End Property

    Public Property Imagen2() As Byte()
        Get
            Return m_Imagen2
        End Get
        Set(ByVal value As Byte())
            m_Imagen2 = value
        End Set
    End Property

    Public Property Imagen3() As Byte()
        Get
            Return m_Imagen3
        End Get
        Set(ByVal value As Byte())
            m_Imagen3 = value
        End Set
    End Property

    Public Property FlagImg01() As String
        Get
            Return sFlagImg01
        End Get
        Set(ByVal value As String)
            sFlagImg01 = CStr(value)
        End Set
    End Property

    Public Property FlagImg02() As String
        Get
            Return sFlagImg02
        End Get
        Set(ByVal value As String)
            sFlagImg02 = CStr(value)
        End Set
    End Property

    Property FlagImg03() As String
        Get
            Return sFlagImg03
        End Get
        Set(ByVal Value As String)
            sFlagImg03 = CStr(Value)
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

    Property CodTipoServicio() As Integer
        Get
            Return iCodTipoServicio
        End Get
        Set(ByVal Value As Integer)
            iCodTipoServicio = (Value)
        End Set
    End Property

    Property StsServicio() As String
        Get
            Return sStsServicio
        End Get
        Set(ByVal Value As String)
            sStsServicio = CStr(Value)
        End Set
    End Property

    Property DesProveedor() As String
        Get
            Return sDesProveedor
        End Get
        Set(ByVal Value As String)
            sDesProveedor = CStr(Value)
        End Set
    End Property

    Property DesObservacion() As String
        Get
            Return sDesObservacion
        End Get
        Set(ByVal Value As String)
            sDesObservacion = CStr(Value)
        End Set
    End Property

    Property FlagValoriza() As String
        Get
            Return sFlagValoriza
        End Get
        Set(ByVal Value As String)
            sFlagValoriza = CStr(Value)
        End Set
    End Property

    Property FlagItinerario() As String
        Get
            Return sFlagItinerario
        End Get
        Set(ByVal Value As String)
            sFlagItinerario = CStr(Value)
        End Set
    End Property

    Property FlagItiProveedor() As String
        Get
            Return sFlagItiProveedor
        End Get
        Set(ByVal Value As String)
            sFlagItiProveedor = CStr(Value)
        End Set
    End Property

    Property FlagPrecio() As String
        Get
            Return sFlagPrecio
        End Get
        Set(ByVal Value As String)
            sFlagPrecio = CStr(Value)
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

    Property FchIngreso() As String
        Get
            Return sFchIngreso
        End Get
        Set(ByVal Value As String)
            sFchIngreso = CStr(Value)
        End Set
    End Property

    Property CodSerOperador() As String
        Get
            Return sCodSerOperador
        End Get
        Set(ByVal Value As String)
            sCodSerOperador = CStr(Value)
        End Set
    End Property

    Property TipoRecorrido() As String
        Get
            Return sTipoRecorrido
        End Get
        Set(ByVal Value As String)
            sTipoRecorrido = CStr(Value)
        End Set
    End Property

    Property CodStsReservaIni() As String
        Get
            Return sCodStsReservaIni
        End Get
        Set(ByVal Value As String)
            sCodStsReservaIni = CStr(Value)
        End Set
    End Property

    Property FlagDesayuno() As String
        Get
            Return sFlagDesayuno
        End Get
        Set(ByVal Value As String)
            sFlagDesayuno = CStr(Value)
        End Set
    End Property

    Property FlagAlmuerzo() As String
        Get
            Return sFlagAlmuerzo
        End Get
        Set(ByVal Value As String)
            sFlagAlmuerzo = CStr(Value)
        End Set
    End Property

    Property FlagCena() As String
        Get
            Return sFlagCena
        End Get
        Set(ByVal Value As String)
            sFlagCena = CStr(Value)
        End Set
    End Property


    Property FlagBoxLunch() As String
        Get
            Return sFlagBoxLunch
        End Get
        Set(ByVal Value As String)
            sFlagBoxLunch = CStr(Value)
        End Set
    End Property

    Property FlagBoxBreakfast() As String
        Get
            Return sFlagBoxBreakfast
        End Get
        Set(ByVal Value As String)
            sFlagBoxBreakfast = CStr(Value)
        End Set
    End Property

    Property FlagPicnic() As String
        Get
            Return sFlagPicnic
        End Get
        Set(ByVal Value As String)
            sFlagPicnic = CStr(Value)
        End Set
    End Property

    Property CaraEspeServicio() As String
        Get
            Return sCaraEspeServicio
        End Get
        Set(ByVal Value As String)
            sCaraEspeServicio = CStr(Value)
        End Set
    End Property

    Property CaraEspeServicio2() As String
        Get
            Return sCaraEspeServicio2
        End Get
        Set(ByVal Value As String)
            sCaraEspeServicio2 = CStr(Value)
        End Set
    End Property

    Property CaraEspeServicio3() As String
        Get
            Return sCaraEspeServicio3
        End Get
        Set(ByVal Value As String)
            sCaraEspeServicio3 = CStr(Value)
        End Set
    End Property

    Property HoraInicioServicio() As String
        Get
            Return sHoraInicioServicio
        End Get
        Set(ByVal Value As String)
            sHoraInicioServicio = CStr(Value)
        End Set
    End Property

	Property FlagServicioAge() As String
		Get
			Return sFlagServicioAge
		End Get
		Set(ByVal Value As String)
			sFlagServicioAge = CStr(Value)
		End Set
	End Property

	Property FlagAdicional() As String
		Get
			Return sFlagAdicional
		End Get
		Set(ByVal Value As String)
			sFlagAdicional = CStr(Value)
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

    Property NomProveedor() As String
        Get
            Return sNomProveedor
        End Get
        Set(ByVal Value As String)
            sNomProveedor = CStr(Value)
        End Set
    End Property
    Property NomCiudad() As String
        Get
            Return sNomCiudad
        End Get
        Set(ByVal Value As String)
            sNomCiudad = CStr(Value)
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

    Public Property DireccionHTL() As String
        Get
            Return sDireccion
        End Get
        Set(ByVal value As String)
            sDireccion = CStr(value)
        End Set
    End Property

    Public Property Valoracion() As String
        Get
            Return sValoracionHTL
        End Get
        Set(ByVal value As String)
            sValoracionHTL = CStr(value)
        End Set
    End Property

    Public Property NombreHTL() As String
        Get
            Return sNombreHTL
        End Get
        Set(ByVal value As String)
            sNombreHTL = CStr(value)
        End Set
    End Property


    Public Property Telefono() As String
        Get
            Return sTelefono
        End Get
        Set(ByVal value As String)
            sTelefono = CStr(value)
        End Set
    End Property

    Property DesHTL() As String
        Get
            Return sDesHTL
        End Get
        Set(ByVal Value As String)
            sDesHTL = CStr(Value)
        End Set
    End Property

    Property DesHTLI() As String
        Get
            Return sDesHTLI
        End Get
        Set(ByVal Value As String)
            sDesHTLI = CStr(Value)
        End Set
    End Property

    Property DesHTLP() As String
        Get
            Return sDesHTLP
        End Get
        Set(ByVal Value As String)
            sDesHTLP = CStr(Value)
        End Set
    End Property


    Function CargaTipoAcomodacion(ByVal pNroServicio As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoAcomodacionxServicio_S", New SqlParameter("@NroServicio", pNroServicio))
        Return (ds)
    End Function

    Function CargaNroServicio(ByVal pNroServicio As Integer, ByVal pEstado As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
        arParms(0).Value = pNroServicio
        arParms(1) = New SqlParameter("@Estado", SqlDbType.VarChar)
        arParms(1).Value = pEstado
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "peru4me_new.VTA_ServicioNroServicio_S_NEW", arParms)
        Return (ds)
    End Function

    'Function CargaNroServicio(ByVal pNroServicio As Integer, ByVal pCodProveedor As Integer) As DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}
    '    arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
    '    arParms(0).Value = pNroServicio
    '    arParms(1) = New SqlParameter("@CodProveedor", SqlDbType.Int)
    '    arParms(1).Value = pCodProveedor

    '    Dim ds As New DataSet
    '    ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioNroServicioProv_S", arParms)
    '    Return (ds)
    'End Function

    Function CargaxDesServicio(ByVal pDesServicio As String, ByVal pEstado As String) As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@DesServicio", SqlDbType.VarChar)
        arParms(0).Value = pDesServicio
        arParms(1) = New SqlParameter("@Estado", SqlDbType.VarChar)
        arParms(1).Value = pEstado
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioDesServicio_S", arParms)
        Return (ds)

        'Dim ds As New DataSet
        'ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioDesServicio_S", New SqlParameter("@DesServicio", pDesServicio))
        'Return (ds)
    End Function

    Function CargaxDesServicio(ByVal pDesServicio As String, ByVal pCodProveedor As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@DesServicio", SqlDbType.VarChar, 50)
        arParms(0).Value = pDesServicio
        arParms(1) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(1).Value = pCodProveedor

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioDesServicioProv_S", arParms)
        Return (ds)
    End Function

    Function CargaServicios(ByVal pCodProveedor As String, ByVal pCodCiudad As String, ByVal pCodTipoServicio As Integer, ByVal pStsServicio As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        arParms(2) = New SqlParameter("@CodTipoServicio", SqlDbType.Int)
        arParms(2).Value = pCodTipoServicio
        arParms(3) = New SqlParameter("@StsServicio", SqlDbType.Char)
        arParms(3).Value = pStsServicio

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioxCodTipoServicioSts_S", arParms)
        Return (ds)
    End Function


    Function CargaxTipoServicio(ByVal pCodProveedor As String, ByVal pCodCiudad As String, ByVal pCodTipoServicio As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        arParms(2) = New SqlParameter("@CodTipoServicio", SqlDbType.Int)
        arParms(2).Value = pCodTipoServicio
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioxCodTipoServicio_S", arParms)
        Return (ds)
    End Function




    Function Grabar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "peru4me_new.VTA_Servicio_I_new"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 250)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroServicioOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = sCodCiudad
        cd.Parameters.Add("@CodStsServicio", SqlDbType.Char, 1).Value = sStsServicio
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.TinyInt).Value = iCodTipoServicio
        cd.Parameters.Add("@DesProveedor", SqlDbType.VarChar, 300).Value = sDesProveedor
        cd.Parameters.Add("@DesObservacion", SqlDbType.VarChar, 300).Value = sDesObservacion
        cd.Parameters.Add("@FlagValoriza", SqlDbType.Char, 1).Value = sFlagValoriza
        cd.Parameters.Add("@FlagItinerario", SqlDbType.Char, 1).Value = sFlagItinerario
        cd.Parameters.Add("@FlagItiProveedor", SqlDbType.Char, 1).Value = sFlagItiProveedor
        cd.Parameters.Add("@FlagPrecio", SqlDbType.Char, 1).Value = sFlagPrecio
        cd.Parameters.Add("@MontoFijo", SqlDbType.Money).Value = dMontoFijo
        cd.Parameters.Add("@TipoRecorrido", SqlDbType.Char, 1).Value = sTipoRecorrido
        cd.Parameters.Add("@CodStsReservaIni", SqlDbType.Char, 2).Value = sCodStsReservaIni
        cd.Parameters.Add("@FlagDesayuno", SqlDbType.Char, 1).Value = sFlagDesayuno
        cd.Parameters.Add("@FlagAlmuerzo", SqlDbType.Char, 1).Value = sFlagAlmuerzo
        cd.Parameters.Add("@FlagCena", SqlDbType.Char, 1).Value = sFlagCena

        cd.Parameters.Add("@FlagBoxLunch", SqlDbType.Char, 1).Value = sFlagBoxLunch
        cd.Parameters.Add("@FlagBoxBreakFast", SqlDbType.Char, 1).Value = sFlagBoxBreakfast
        cd.Parameters.Add("@FlagPicnic", SqlDbType.Char, 1).Value = sFlagPicnic

        cd.Parameters.Add("@CaraEspeServicio", SqlDbType.VarChar, 250).Value = sCaraEspeServicio
        cd.Parameters.Add("@CaraEspeServicio2", SqlDbType.VarChar, 250).Value = sCaraEspeServicio2
        cd.Parameters.Add("@CaraEspeServicio3", SqlDbType.VarChar, 250).Value = sCaraEspeServicio3
        cd.Parameters.Add("@HoraInicioServicio", SqlDbType.Char, 8).Value = sHoraInicioServicio
        cd.Parameters.Add("@FlagServicioAge", SqlDbType.Char, 1).Value = sFlagServicioAge
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario

        If m_Imagen Is Nothing Then
            cd.Parameters.Add("@Imagen1", SqlDbType.Image).Value = DBNull.Value
            cd.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = ""
        Else
            cd.Parameters.Add("@Imagen1", SqlDbType.Image).Value = m_Imagen
            cd.Parameters.Add("@FlagImg01", SqlDbType.Char, 1).Value = sFlagImg01
        End If

        If m_Imagen2 Is Nothing Then
            cd.Parameters.Add("@Imagen2", SqlDbType.Image).Value = DBNull.Value
            cd.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = ""
        Else
            cd.Parameters.Add("@Imagen2", SqlDbType.Image).Value = m_Imagen2
            cd.Parameters.Add("@FlagImg02", SqlDbType.Char, 1).Value = sFlagImg02
        End If

        If m_Imagen3 Is Nothing Then
            cd.Parameters.Add("@Imagen3", SqlDbType.Image).Value = DBNull.Value
            cd.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = sFlagImg03
        Else
            cd.Parameters.Add("@Imagen3", SqlDbType.Image).Value = m_Imagen3
            cd.Parameters.Add("@FlagImg03", SqlDbType.Char, 1).Value = sFlagImg03
        End If

        cd.Parameters.Add("@DireccionHTL", SqlDbType.VarChar, 250).Value = sDireccion

        cd.Parameters.Add("@Telefono", SqlDbType.VarChar, 250).Value = sTelefono

        cd.Parameters.Add("@ValoracionHTL", SqlDbType.Char, 8).Value = sValoracionHTL

        cd.Parameters.Add("@NombreHTL", SqlDbType.Char, 150).Value = sNombreHTL

        cd.Parameters.Add("@DesHTL", SqlDbType.VarChar).Value = sDesHTL

        cd.Parameters.Add("@DesHTLI", SqlDbType.VarChar).Value = sDesHTLI

        cd.Parameters.Add("@DesHTLP", SqlDbType.VarChar).Value = sDesHTLP

		cd.Parameters.Add("@FlagAdicional", SqlDbType.Char, 1).Value = sFlagAdicional

		Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@MsgTrans").Value = "OK" Then
                sMsg = cd.Parameters("@MsgTrans").Value + CStr(cd.Parameters("@NroServicioOut").Value)
            Else
                sMsg = cd.Parameters("@MsgTrans").Value
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function


    Function Editar(ByVal pNroServicio As Integer, ByVal pEstado As String) As String
        sMsg = "No existe Servicio " & CStr(pNroServicio)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        pEstado = "N"
        cd.Connection = cn
        cd.CommandText = "peru4me_new.VTA_ServicioNroServicio_S_NEW"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = pNroServicio
        cd.Parameters.Add("@Estado", SqlDbType.Char).Value = pEstado
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                iCodProveedor = dr.GetValue(dr.GetOrdinal("CodProveedor"))
                iCodTipoServicio = dr.GetValue(dr.GetOrdinal("CodTipoServicio"))
                sCodCiudad = dr.GetValue(dr.GetOrdinal("CodCiudad"))
                sDesProveedor = dr.GetValue(dr.GetOrdinal("DesProveedor"))

                If IsDBNull(dr.GetValue(dr.GetOrdinal("DesObservacion"))) Then

                    sDesObservacion = ""

                Else
                    sDesObservacion = dr.GetValue(dr.GetOrdinal("DesObservacion"))
                End If

                sFlagValoriza = dr.GetValue(dr.GetOrdinal("FlagValoriza"))
                dMontoFijo = dr.GetValue(dr.GetOrdinal("MontoFijo"))
                sFlagItinerario = dr.GetValue(dr.GetOrdinal("FlagItinerario"))
                sFlagItiProveedor = dr.GetValue(dr.GetOrdinal("FlagItiProveedor"))
                sStsServicio = dr.GetValue(dr.GetOrdinal("StsServicio"))
                sFlagPrecio = dr.GetValue(dr.GetOrdinal("FlagPrecio"))
                sTipoRecorrido = dr.GetValue(dr.GetOrdinal("TipoRecorrido"))
                sCodStsReservaIni = dr.GetValue(dr.GetOrdinal("CodStsReservaIni"))
                sFlagDesayuno = dr.GetValue(dr.GetOrdinal("FlagDesayuno"))
                sFlagAlmuerzo = dr.GetValue(dr.GetOrdinal("FlagAlmuerzo"))
                sFlagCena = dr.GetValue(dr.GetOrdinal("FlagCena"))


                If IsDBNull(dr.GetValue(dr.GetOrdinal("FlagBoxLunch"))) Then

                    sFlagBoxLunch = "N"

                Else
                    sFlagBoxLunch = dr.GetValue(dr.GetOrdinal("FlagBoxLunch"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("FlagBoxBreakfast"))) Then

                    sFlagBoxBreakfast = "N"

                Else
                    sFlagBoxBreakfast = dr.GetValue(dr.GetOrdinal("FlagBoxBreakfast"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("FlagPicnic"))) Then

                    sFlagPicnic = "N"

                Else
                    sFlagPicnic = dr.GetValue(dr.GetOrdinal("FlagPicnic"))
                End If

                sCaraEspeServicio = dr.GetValue(dr.GetOrdinal("CaraEspeServicio"))
                sCaraEspeServicio2 = dr.GetValue(dr.GetOrdinal("CaraEspeServicio2"))
                sCaraEspeServicio3 = dr.GetValue(dr.GetOrdinal("CaraEspeServicio3"))
                sHoraInicioServicio = dr.GetValue(dr.GetOrdinal("HoraInicioServicio"))
                sFlagServicioAge = dr.GetValue(dr.GetOrdinal("FlagServicioAge"))

                sNomProveedor = dr.GetValue(dr.GetOrdinal("NomProveedor"))
                sNomCiudad = dr.GetValue(dr.GetOrdinal("NomCiudad"))
                sTipoServicio = dr.GetValue(dr.GetOrdinal("TipoServicio"))


                If IsDBNull(dr.GetValue(dr.GetOrdinal("DireccionHTL"))) Then

                    sDireccion = ""

                Else
                    sDireccion = dr.GetValue(dr.GetOrdinal("DireccionHTL"))
                End If

                If IsDBNull(dr.GetValue(dr.GetOrdinal("Telefono"))) Then

                    sTelefono = ""

                Else
                    sTelefono = dr.GetValue(dr.GetOrdinal("Telefono"))
                End If

                If IsDBNull(dr.GetValue(dr.GetOrdinal("Valoracion"))) Then

                    sValoracionHTL = ""

                Else
                    sValoracionHTL = dr.GetValue(dr.GetOrdinal("Valoracion"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("NombreHTL"))) Then

                    sNombreHTL = ""

                Else
                    sNombreHTL = dr.GetValue(dr.GetOrdinal("NombreHTL"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("Imagen1"))) Then

                    Imagen = Nothing

                Else
                    Imagen = dr.GetValue(dr.GetOrdinal("Imagen1"))
                End If

                If IsDBNull(dr.GetValue(dr.GetOrdinal("Imagen2"))) Then

                    Imagen2 = Nothing

                Else
                    Imagen2 = dr.GetValue(dr.GetOrdinal("Imagen2"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("Imagen3"))) Then

                    Imagen3 = Nothing

                Else
                    Imagen3 = dr.GetValue(dr.GetOrdinal("Imagen3"))
                End If


                If IsDBNull(dr.GetValue(dr.GetOrdinal("DesHTL"))) Then

                    sDesHTL = ""

                Else
                    sDesHTL = dr.GetValue(dr.GetOrdinal("DesHTL"))
                End If

                If IsDBNull(dr.GetValue(dr.GetOrdinal("DesHTLI"))) Then

                    sDesHTLI = ""

                Else
                    sDesHTLI = dr.GetValue(dr.GetOrdinal("DesHTLI"))
                End If

                If IsDBNull(dr.GetValue(dr.GetOrdinal("DesHTLP"))) Then

                    sDesHTLP = ""

                Else
                    sDesHTLP = dr.GetValue(dr.GetOrdinal("DesHTLP"))
                End If



                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

    Function Borrar(ByVal pNroServicio As Integer) As String
        Dim objRutina As New clsRutinas
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Servicio_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroServicio", SqlDbType.Char, 10).Value = pNroServicio
        Try
            cn.Open()
            cd.CommandTimeout = 180
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = objRutina.fncErroresSQL(ex1.Errors)
            If sMsg.Trim = "547" Then
                sMsg = "Si desea eliminar Servicio, primero debe eliminar tarifas, links, propuestas y versiones"
            End If
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function

    Function Copiar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_ServicioCopia_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroServicioOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = iNroServicio
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = iCodProveedor
        cd.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = sCodCiudad
        cd.Parameters.Add("@CodTipoServicio", SqlDbType.Int).Value = iCodTipoServicio
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value + CStr(cd.Parameters("@NroServicioOut").Value)
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function

    Function CargaImg2(ByVal pNroServicio As String) As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroServicio", SqlDbType.Int)
        arParms(0).Value = pNroServicio
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "peru4me_new.VTA_ListaIMG_S", arParms)

        Return (ds)

        'Dim ds As New DataSet
        'ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioDesServicio_S", New SqlParameter("@DesServicio", pDesServicio))
        'Return (ds)
    End Function


    Public Shared Function ConvertirImagen(ByVal Imagen As Byte()) As Image


        Dim Picture As Image

        Dim ms As MemoryStream = New MemoryStream(Imagen)
        Picture = Image.FromStream(ms)



        Return Picture
    End Function

    Public Shared Function ConvertirImagen3(ByVal Imagen3 As Byte()) As String

        Dim ms As String = Convert.ToBase64String(Imagen3, 0, Imagen3.Length)

        Return ms
    End Function

    Public Shared Function ConvertirImagen2(ByVal Imagen2 As Byte()) As String

        Dim ms As String = Convert.ToBase64String(Imagen2, 0, Imagen2.Length)

        Return ms
    End Function



    Public Shared Function CargaImg(ByVal pNroServicio As String) As List(Of clsServicio)

        Dim servicio As New List(Of clsServicio)()
        Dim Fila As New clsServicio()

        Using conn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

            conn.Open()

           
            Dim query As String = "select Imagen1,Imagen2,Imagen3 from MSERVICIO where NroServicio = '" & pNroServicio & "'"

            Dim cmd As New SqlCommand(query, conn)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            
            While reader.Read()
                Fila = New clsServicio()

                If reader("Imagen1") Is DBNull.Value Then

                Else

                    Fila.Imagen = CType(reader("Imagen1"), Byte())


                End If

                If reader("Imagen2") Is DBNull.Value Then

                Else

                    Fila.Imagen2 = CType(reader("Imagen2"), Byte())


                End If

                If reader("Imagen3") Is DBNull.Value Then

                Else

                    Fila.Imagen3 = CType(reader("Imagen3"), Byte())


                End If


                servicio.Add(Fila)

            End While
        End Using

        Return servicio


    End Function


End Class
