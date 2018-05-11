Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas
Public Class clsPasajeroHabitacion
    Dim sMsg As String

    Private sCantAdultos As String
    Private sCantNinos As String
    Private sCantSimple As String
    Private sCantDoble As String
    Private sCantTriple As String
    Private sCantCuadruple As String
    Private sAduSGL As String
    Private sAduDBL As String
    Private sAduTPL As String
    Private sAduCDL As String
    Private sNinSGL As String
    Private sNinDBL As String
    Private sNinTPL As String
    Private sNinCDL As String
    Private sCodUsuario As String
    Dim objRutina As New clsRutinas
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Property CantAdultos() As String
        Get
            Return sCantAdultos
        End Get
        Set(ByVal Value As String)
            sCantAdultos = CStr(Value)
        End Set
    End Property

    Property CantNinos() As String
        Get
            Return sCantNinos
        End Get
        Set(ByVal Value As String)
            sCantNinos = CStr(Value)
        End Set
    End Property
    Property CantSimple() As String
        Get
            Return sCantSimple
        End Get
        Set(ByVal Value As String)
            sCantSimple = CStr(Value)
        End Set
    End Property

    Property CantDoble() As String
        Get
            Return sCantDoble
        End Get
        Set(ByVal Value As String)
            sCantDoble = CStr(Value)
        End Set
    End Property
    Property CantTriple() As String
        Get
            Return sCantTriple
        End Get
        Set(ByVal Value As String)
            sCantTriple = CStr(Value)
        End Set
    End Property
    Property CantCuadruple() As String
        Get
            Return sCantCuadruple
        End Get
        Set(ByVal Value As String)
            sCantCuadruple = CStr(Value)
        End Set
    End Property
    Property AduSGL() As String
        Get
            Return sAduSGL
        End Get
        Set(ByVal Value As String)
            sAduSGL = CStr(Value)
        End Set
    End Property
    Property AduDBL() As String
        Get
            Return sAduDBL
        End Get
        Set(ByVal Value As String)
            sAduDBL = CStr(Value)
        End Set
    End Property
    Property AduTPL() As String
        Get
            Return sAduTPL
        End Get
        Set(ByVal Value As String)
            sAduTPL = CStr(Value)
        End Set
    End Property
    Property AduCDL() As String
        Get
            Return sAduCDL
        End Get
        Set(ByVal Value As String)
            sAduCDL = CStr(Value)
        End Set
    End Property

    Property NinSGL() As String
        Get
            Return sNinSGL
        End Get
        Set(ByVal Value As String)
            sNinSGL = CStr(Value)
        End Set
    End Property
    Property NinDBL() As String
        Get
            Return sNinDBL
        End Get
        Set(ByVal Value As String)
            sNinDBL = CStr(Value)
        End Set
    End Property
    Property NinTPL() As String
        Get
            Return sNinTPL
        End Get
        Set(ByVal Value As String)
            sNinTPL = CStr(Value)
        End Set
    End Property
    Property NinCDL() As String
        Get
            Return sNinCDL
        End Get
        Set(ByVal Value As String)
            sNinCDL = CStr(Value)
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

    Function CargaxCant(ByVal pCantAdultos As Integer, ByVal pCantNinos As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CantAdultos", SqlDbType.Int)
        arParms(0).Value = pCantAdultos
        arParms(1) = New SqlParameter("@CantNinos", SqlDbType.Int)
        arParms(1).Value = pCantNinos

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_PasajeroHabitacionxCant_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        sCantAdultos = objRutina.ConvierteEntero(sCantAdultos)
        sCantNinos = objRutina.ConvierteEntero(sCantNinos)
        sCantSimple = objRutina.ConvierteEntero(sCantSimple)
        sCantDoble = objRutina.ConvierteEntero(sCantDoble)
        sCantTriple = objRutina.ConvierteEntero(sCantTriple)
        sCantCuadruple = objRutina.ConvierteEntero(sCantCuadruple)

        sAduSGL = objRutina.ConvierteEntero(sAduSGL)
        sAduDBL = objRutina.ConvierteEntero(sAduDBL)
        sAduTPL = objRutina.ConvierteEntero(sAduTPL)
        sAduCDL = objRutina.ConvierteEntero(sAduCDL)

        sNinSGL = objRutina.ConvierteEntero(sNinSGL)
        sNinDBL = objRutina.ConvierteEntero(sNinDBL)
        sNinTPL = objRutina.ConvierteEntero(sNinTPL)
        sNinCDL = objRutina.ConvierteEntero(sNinCDL)
        'Validación
        If CInt(sCantAdultos) <> CInt(sAduSGL) + CInt(sAduDBL) + CInt(sAduTPL) + CInt(sAduCDL) Then
            Return ("Error, Total adultos no cuadra con la cantidad de adultos por habitación")
        End If
        If CInt(sCantNinos) <> CInt(sNinSGL) + CInt(sNinDBL) + CInt(sNinTPL) + CInt(sNinCDL) Then
            Return ("Error, Total niños no cuadra con la cantidad de niños por habitación")
        End If

        If CInt(sCantSimple) <> CInt(sAduSGL) + CInt(sNinSGL) Then
            Return ("Error, Total habitación simple, no cuadra con la suma adultos + niños")
        End If
        If CInt(sCantDoble * 2) <> CInt(sAduDBL) + CInt(sNinDBL) Then
            Return ("Error, Total habitación doble, no cuadra con la suma adultos + niños")
        End If
        If CInt(sCantTriple * 3) <> CInt(sAduTPL) + CInt(sNinTPL) Then
            Return ("Error, Total habitación triple, no cuadra con la suma adultos + niños")
        End If
        If CInt(sCantCuadruple * 4) <> CInt(sAduCDL) + CInt(sNinCDL) Then
            Return ("Error, Total habitación cuadruple, no cuadra con la suma adultos + niños")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_PasajeroHabitacion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CantAdultos", SqlDbType.Int).Value = sCantAdultos
        cd.Parameters.Add("@CantNinos", SqlDbType.Int).Value = sCantNinos
        cd.Parameters.Add("@CantSimple", SqlDbType.Int).Value = sCantSimple
        cd.Parameters.Add("@CantDoble", SqlDbType.Int).Value = sCantDoble
        cd.Parameters.Add("@CantTriple", SqlDbType.Int).Value = sCantTriple
        cd.Parameters.Add("@CantCuadruple", SqlDbType.Int).Value = sCantCuadruple
        cd.Parameters.Add("@CantAduSGL", SqlDbType.Int).Value = sAduSGL
        cd.Parameters.Add("@CantAduDBL", SqlDbType.Int).Value = sAduDBL
        cd.Parameters.Add("@CantAduTPL", SqlDbType.Int).Value = sAduTPL
        cd.Parameters.Add("@CantAduCDL", SqlDbType.Int).Value = sAduCDL
        cd.Parameters.Add("@CantNinSGL", SqlDbType.Int).Value = sNinSGL
        cd.Parameters.Add("@CantNinDBL", SqlDbType.Int).Value = sNinDBL
        cd.Parameters.Add("@CantNinTPL", SqlDbType.Int).Value = sNinTPL
        cd.Parameters.Add("@CantNinCDL", SqlDbType.Int).Value = sNinCDL
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
        cd.CommandText = "TAB_PasajeroHabitacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CantAdultos", SqlDbType.Int).Value = sCantAdultos
        cd.Parameters.Add("@CantNinos", SqlDbType.Int).Value = sCantNinos
        cd.Parameters.Add("@CantSimple", SqlDbType.Int).Value = sCantSimple
        cd.Parameters.Add("@CantDoble", SqlDbType.Int).Value = sCantDoble
        cd.Parameters.Add("@CantTriple", SqlDbType.Int).Value = sCantTriple
        cd.Parameters.Add("@CantCuadruple", SqlDbType.Int).Value = sCantCuadruple
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