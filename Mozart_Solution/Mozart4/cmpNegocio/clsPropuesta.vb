Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsPropuesta
    Private iNroPedido As Integer
    Private iNroPropuesta As Integer
    Private sDesPropuesta As String
    Private sFchPropuesta As String
    Private sStsPropuesta As String
    Private iCodCliente As Integer
    Private dPorUtilidad As Double
    Private iCantDias As Integer

    Private iCantAduSGL As Integer
    Private iCantAduDBL As Integer
    Private iCantAduTPL As Integer
    Private iCantAduCDL As Integer

    Private iCantNinSGL As Integer
    Private iCantNinDBL As Integer
    Private iCantNinTPL As Integer
    Private iCantNinCDL As Integer

    Private sFlagPublica As String
    Private sFlagPublicaEuro As String
    Private sFlagAtencion As String
    Private sFlagIdioma As String
    Private sFlagVenta As String
    Private sFlagEdita As String
    Private sFchInicio As String
    Private sStsCaptacion As String
    Private dTipoCambioEuro As Double

    Private iNroPlantilla As String
    Private iNroDiaInicio As String

    Private sCodUsuario As String

    ' solo para leer
    Private sFchSys As Date

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

    Property DesPropuesta() As String
        Get
            Return sDesPropuesta
        End Get
        Set(ByVal Value As String)
            sDesPropuesta = CStr(Value)
        End Set
    End Property

    Property FchPropuesta() As String
        Get
            Return sFchPropuesta
        End Get
        Set(ByVal Value As String)
            sFchPropuesta = CStr(Value)
        End Set
    End Property

    Property StsPropuesta() As String
        Get
            Return sStsPropuesta
        End Get
        Set(ByVal Value As String)
            sStsPropuesta = CStr(Value)
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

    Property PorUtilidad() As Double
        Get
            Return dPorUtilidad
        End Get
        Set(ByVal Value As Double)
            dPorUtilidad = Value
        End Set
    End Property

    Property CantDias() As Integer
        Get
            Return iCantDias
        End Get
        Set(ByVal Value As Integer)
            iCantDias = (Value)
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


    Property FlagPublica() As String
        Get
            Return sFlagPublica
        End Get
        Set(ByVal Value As String)
            sFlagPublica = CStr(Value)
        End Set
    End Property

    Property FlagPublicaEuro() As String
        Get
            Return sFlagPublicaEuro
        End Get
        Set(ByVal Value As String)
            sFlagPublicaEuro = CStr(Value)
        End Set
    End Property

    Property FlagAtencion() As String
        Get
            Return sFlagAtencion
        End Get
        Set(ByVal Value As String)
            sFlagAtencion = CStr(Value)
        End Set
    End Property

    Property FlagIdioma() As String
        Get
            Return sFlagIdioma
        End Get
        Set(ByVal Value As String)
            sFlagIdioma = CStr(Value)
        End Set
    End Property

    Property FlagVenta() As String
        Get
            Return sFlagVenta
        End Get
        Set(ByVal Value As String)
            sFlagVenta = CStr(Value)
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

    Property FchInicio() As String
        Get
            Return sFchInicio
        End Get
        Set(ByVal Value As String)
            sFchInicio = CStr(Value)
        End Set
    End Property

    Property StsCaptacion() As String
        Get
            Return sStsCaptacion
        End Get
        Set(ByVal Value As String)
            sStsCaptacion = CStr(Value)
        End Set
    End Property

    Property TipoCambioEuro() As Double
        Get
            Return dTipoCambioEuro
        End Get
        Set(ByVal Value As Double)
            dTipoCambioEuro = Value
        End Set
    End Property


    Property NroPlantilla() As String
        Get
            Return iNroPlantilla
        End Get
        Set(ByVal Value As String)
            iNroPlantilla = CStr(Value)
        End Set
    End Property

    Property NroDiaInicio() As String
        Get
            Return iNroDiaInicio
        End Get
        Set(ByVal Value As String)
            iNroDiaInicio = CStr(Value)
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


    Function CargaPropuestas(ByVal pNroPedido As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaTitulo_S", New SqlParameter("@NroPedido", pNroPedido))
        Return (ds)
    End Function


    Function Publica() As String
        Dim objRutina As New clsRutinas

        ' Muestra itinerario en número de dias o fechas    
        If sFlagAtencion = "F" Then ' Fechas
            If sFchInicio.Trim.Length = 0 Then
                Return ("Fecha inicio es obligatorio, para mostrar itinerario con fechas")
            End If
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPublica_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@FlagPublica", SqlDbType.Char, 1).Value = sFlagPublica
        cd.Parameters.Add("@FlagPublicaEuro", SqlDbType.Char, 1).Value = sFlagPublicaEuro
        cd.Parameters.Add("@TipoCambioEuro", SqlDbType.SmallMoney).Value = dTipoCambioEuro
        cd.Parameters.Add("@FlagAtencion", SqlDbType.Char, 1).Value = sFlagAtencion
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(sFchInicio)
        cd.Parameters.Add("@StsCaptacion", SqlDbType.Char, 1).Value = sStsCaptacion
        cd.Parameters.Add("@FlagVenta", SqlDbType.Char, 1).Value = sFlagVenta
        cd.Parameters.Add("@Sistema", SqlDbType.Char, 1).Value = "M" 'Mozart
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

    '1re Caso
    Function GrabaPropuestaDePlantilla() As String
        If iNroPlantilla.Trim.Length = 0 Then
            Return ("Dato obligatorio")
        ElseIf Not IsNumeric(iNroPlantilla) Then
            Return ("Error : Nro. Plantilla es dato númerico")
        End If

        If iNroDiaInicio.Trim.Length = 0 Then
            Return ("Dato obligatorio")
        ElseIf Not IsNumeric(iNroDiaInicio) Then
            Return ("Error : Nro. Plantilla es dato númerico")
        End If

        If iCantAduSGL + iCantAduDBL + iCantAduTPL + iCantAduCDL + iCantNinSGL + iCantNinDBL + iCantNinTPL + iCantNinCDL = 0 Then
            Return ("Error : Ingrese por lo menos un pasajero")
        End If

        If iCantAduSGL + iCantAduDBL + iCantAduTPL + iCantAduCDL + iCantNinSGL + iCantNinDBL + iCantNinTPL + iCantNinCDL = 0 Then
            Return ("Error : Ingrese por lo menos un pasajero")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPlantilla_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPropuestaOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = iNroPlantilla
        cd.Parameters.Add("@NroDiaInicio", SqlDbType.Int).Value = iNroDiaInicio
        cd.Parameters.Add("@FlagIdioma", SqlDbType.Char, 1).Value = sFlagIdioma
        cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = iCantAduSGL
        cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = iCantAduDBL
        cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = iCantAduTPL
        cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = iCantAduCDL
        cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = iCantNinSGL
        cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = iCantNinDBL
        cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = iCantNinTPL
        cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = iCantNinCDL
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = sFchInicio
        cd.Parameters.Add("@Sistema", SqlDbType.Char, 1).Value = "M" 'Mozart
        cd.Parameters.Add("@CodAgencia", SqlDbType.Int).Value = 0
        cd.Parameters.Add("@CodTour", SqlDbType.SmallInt).Value = 0
        cd.Parameters.Add("@FlagComiAge", SqlDbType.Char, 1).Value = "" 'solo agencias
        cd.Parameters.Add("@MonComiAge", SqlDbType.Money).Value = 0 ' solo agencias
        cd.Parameters.Add("@FlagAtencion", SqlDbType.Char, 1).Value = "D"   ' D=dias F=Fecha
        cd.Parameters.Add("@FlagPublica", SqlDbType.Char, 1).Value = "N"    ' S=Publica  N=No publicado
        cd.Parameters.Add("@FlagPublicaEuro", SqlDbType.Char, 1).Value = "N" ' S=Precio en Euro  N=USD
        cd.Parameters.Add("@DesPropuesta", SqlDbType.VarChar, 100).Value = ""
        cd.Parameters.Add("@NomComprador", SqlDbType.VarChar, 150).Value = ""
        cd.Parameters.Add("@OrigenComprador", SqlDbType.Char, 1).Value = "E" ' E=Extranjero P=Peruano (calculo IGV)
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


    '2do Caso
    Function GrabaPropuesta() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Propuesta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPropuestaOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        cd.Parameters.Add("@DesPropuesta", SqlDbType.VarChar, 100).Value = sDesPropuesta
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = iCodCliente
        cd.Parameters.Add("@PorUtilidad", SqlDbType.Money).Value = dPorUtilidad
        cd.Parameters.Add("@FlagIdioma", SqlDbType.Char, 1).Value = sFlagIdioma
        cd.Parameters.Add("@CantAduSGL", SqlDbType.TinyInt).Value = iCantAduSGL
        cd.Parameters.Add("@CantAduDBL", SqlDbType.TinyInt).Value = iCantAduDBL
        cd.Parameters.Add("@CantAduTPL", SqlDbType.TinyInt).Value = iCantAduTPL
        cd.Parameters.Add("@CantAduCDL", SqlDbType.TinyInt).Value = iCantAduCDL
        cd.Parameters.Add("@CantNinSGL", SqlDbType.TinyInt).Value = iCantNinSGL
        cd.Parameters.Add("@CantNinDBL", SqlDbType.TinyInt).Value = iCantNinDBL
        cd.Parameters.Add("@CantNinTPL", SqlDbType.TinyInt).Value = iCantNinTPL
        cd.Parameters.Add("@CantNinCDL", SqlDbType.TinyInt).Value = iCantNinCDL
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = sFchInicio

        cd.Parameters.Add("@Sistema", SqlDbType.Char, 1).Value = "M" 'Mozart
        cd.Parameters.Add("@FlagComiAge", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@MonComiAge", SqlDbType.Money).Value = 0
        cd.Parameters.Add("@FlagAtencion", SqlDbType.Char, 1).Value = ""
        cd.Parameters.Add("@NomComprador", SqlDbType.VarChar, 50).Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
            iNroPropuesta = cd.Parameters("@NroPropuestaOut").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error: " & ex2.Message
        End Try
        Return (sMsg)


    End Function

    Function Editar() As String
        sMsg = "No existe Propuesta " & CStr(iNroPropuesta)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaNroPropuesta_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = iNroPedido
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = iNroPropuesta
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                iCodCliente = dr.GetValue(dr.GetOrdinal("CodCliente"))

                sDesPropuesta = dr.GetValue(dr.GetOrdinal("DesPropuesta"))
                iCantDias = dr.GetValue(dr.GetOrdinal("CantDias"))
                sFchPropuesta = dr.GetValue(dr.GetOrdinal("FchPropuesta"))
                sStsPropuesta = dr.GetValue(dr.GetOrdinal("StsPropuesta"))
                dPorUtilidad = dr.GetValue(dr.GetOrdinal("PorUtilidad"))
                dTipoCambioEuro = dr.GetValue(dr.GetOrdinal("TipoCambioEuro"))

                iCantAduSGL = dr.GetValue(dr.GetOrdinal("CantAduSGL"))
                iCantAduDBL = dr.GetValue(dr.GetOrdinal("CantAduDBL"))
                iCantAduTPL = dr.GetValue(dr.GetOrdinal("CantAduTPL"))
                iCantAduCDL = dr.GetValue(dr.GetOrdinal("CantAduCDL"))

                iCantNinSGL = dr.GetValue(dr.GetOrdinal("CantNinSGL"))
                iCantNinDBL = dr.GetValue(dr.GetOrdinal("CantNinDBL"))
                iCantNinTPL = dr.GetValue(dr.GetOrdinal("CantNinTPL"))
                iCantNinCDL = dr.GetValue(dr.GetOrdinal("CantNinCDL"))

                sFlagPublica = dr.GetValue(dr.GetOrdinal("FlagPublica"))
                sFlagPublicaEuro = dr.GetValue(dr.GetOrdinal("FlagPublicaEuro"))
                sFlagAtencion = dr.GetValue(dr.GetOrdinal("FlagAtencion"))
                sFlagVenta = dr.GetValue(dr.GetOrdinal("FlagVenta"))
                sFlagEdita = dr.GetValue(dr.GetOrdinal("FlagEdita"))
                sFlagIdioma = dr.GetValue(dr.GetOrdinal("FlagIdioma"))
                sStsCaptacion = dr.GetValue(dr.GetOrdinal("StsCaptacion"))

                If Not IsDBNull(dr.GetValue(dr.GetOrdinal("FchInicio"))) Then
                    sFchInicio = dr.GetValue(dr.GetOrdinal("fchInicio"))
                End If

                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

End Class