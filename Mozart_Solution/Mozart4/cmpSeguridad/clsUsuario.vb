Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsUsuario
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Private sMsg As String

    Private sCodUsuario As String
    Private sNomUsuario As String
    Private sCodPerfil As String
    Private sClave As String
    Private sStsUsuario As String
    Private sTipoIdioma As String
    Private sFlagLogAcceso As String
    Private sFlagVtaAcceso As String
    Private sFlagModoTrabajo As String
    Private sCodUsuarioSys As String
    Private sFlagEmailAcceso As String

    Private sIPAddress As String
    Private sFchIniTarifa As String

    ' solo para leer
    Private sFchSys As Date
    Private sNomStsUsuario As String
    Private sNomTipoIdioma As String
    Private dFchIniPeriodo As Date

    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    Property NomUsuario() As String
        Get
            Return sNomUsuario
        End Get
        Set(ByVal Value As String)
            sNomUsuario = CStr(Value)
        End Set
    End Property

    Property CodPerfil() As String
        Get
            Return sCodPerfil
        End Get
        Set(ByVal Value As String)
            sCodPerfil = CStr(Value)
        End Set
    End Property

    Property Clave() As String
        Get
            Return sClave
        End Get
        Set(ByVal Value As String)
            sClave = CStr(Value)
        End Set
    End Property

    Property StsUsuario() As String
        Get
            Return sStsUsuario
        End Get
        Set(ByVal Value As String)
            sStsUsuario = CStr(Value)
        End Set
    End Property

    Property TipoIdioma() As String
        Get
            Return sTipoIdioma
        End Get
        Set(ByVal Value As String)
            sTipoIdioma = CStr(Value)
        End Set
    End Property

    Property FlagLogAcceso() As String
        Get
            Return sFlagLogAcceso
        End Get
        Set(ByVal Value As String)
            sFlagLogAcceso = CStr(Value)
        End Set
    End Property

    Property FlagVtaAcceso() As String
        Get
            Return sFlagVtaAcceso
        End Get
        Set(ByVal Value As String)
            sFlagVtaAcceso = CStr(Value)
        End Set
    End Property

    Property FlagModoTrabajo() As String
        Get
            Return sFlagModoTrabajo
        End Get
        Set(ByVal Value As String)
            sFlagModoTrabajo = CStr(Value)
        End Set
    End Property

    Property CodUsuarioSys() As String
        Get
            Return sCodUsuarioSys
        End Get
        Set(ByVal Value As String)
            sCodUsuarioSys = CStr(Value)
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

    Property FlagEmailAcceso() As String
        Get
            Return sFlagEmailAcceso
        End Get
        Set(ByVal Value As String)
            sFlagEmailAcceso = CStr(Value)
        End Set
    End Property


    Property NomStsUsuario() As String
        Get
            Return sNomStsUsuario
        End Get
        Set(ByVal Value As String)
            sNomStsUsuario = CStr(Value)
        End Set
    End Property

    Property NomTipoIdioma() As String
        Get
            Return sNomTipoIdioma
        End Get
        Set(ByVal Value As String)
            sNomTipoIdioma = CStr(Value)
        End Set
    End Property

    Property IPAddress() As String
        Get
            Return sIPAddress
        End Get
        Set(ByVal Value As String)
            sIPAddress = CStr(Value)
        End Set
    End Property

    Property FchIniTarifa() As String
        Get
            Return sFchIniTarifa
        End Get
        Set(ByVal Value As String)
            sFchIniTarifa = CStr(Value)
        End Set
    End Property

    Property FchIniPeriodo() As Date
        Get
            Return dFchIniPeriodo
        End Get
        Set(ByVal Value As Date)
            dFchIniPeriodo = Value
        End Set
    End Property

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_Usuario_S")
        Return (ds)
    End Function

    Function CargarLog(ByVal pFchInicial As String, ByVal pFchFinal As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartFecha_S", arParms)
        Return (ds)
    End Function

    Function CargarLog(ByVal pFchInicial As String, ByVal pFchFinal As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        arParms(2) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(2).Value = pCodUsuario

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartUsuario_S", arParms)
        Return (ds)
    End Function

    Function CargarLogLocal(ByVal pFchInicial As String, ByVal pFchFinal As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        arParms(2) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(2).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartUsuarioLocal_S", arParms)
        Return (ds)
    End Function

    Function CargarLogLocal(ByVal pFchInicial As String, ByVal pFchFinal As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartFechaLocal_S", arParms)
        Return (ds)
    End Function

    Function CargarLogExterno(ByVal pFchInicial As String, ByVal pFchFinal As String, ByVal pCodUsuario As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        arParms(2) = New SqlParameter("@CodUsuario", SqlDbType.Char, 15)
        arParms(2).Value = pCodUsuario
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartUsuarioExterno_S", arParms)
        Return (ds)
    End Function

    Function CargarLogExterno(ByVal pFchInicial As String, ByVal pFchFinal As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchInicial", SqlDbType.Char, 8)
        arParms(0).Value = pFchInicial
        arParms(1) = New SqlParameter("@FchFinal", SqlDbType.Char, 8)
        arParms(1).Value = pFchFinal
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SEG_LogMozartFechaExterno_S", arParms)
        Return (ds)
    End Function

    Function Grabar() As String
        If sCodUsuario.Trim.Length = 0 Then
            Return ("Código usuario es obligatorio")
        End If
        If sNomUsuario.Trim.Length = 0 Then
            Return ("Nombre usuario es obligatorio")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "SEG_Usuario_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        cd.Parameters.Add("@NomUsuario", SqlDbType.VarChar, 50).Value = sNomUsuario
        cd.Parameters.Add("@StsUsuario", SqlDbType.Char, 1).Value = sStsUsuario
        cd.Parameters.Add("@CodPerfil", SqlDbType.Char).Value = sCodPerfil
        cd.Parameters.Add("@TipoIdioma", SqlDbType.Char, 1).Value = sTipoIdioma
        cd.Parameters.Add("@FlagLogAcceso", SqlDbType.Char, 1).Value = sFlagLogAcceso
        cd.Parameters.Add("@FlagVtaAcceso", SqlDbType.Char, 1).Value = sFlagVtaAcceso
        cd.Parameters.Add("@FlagModoTrabajo", SqlDbType.Char, 1).Value = sFlagModoTrabajo
        cd.Parameters.Add("@FchIniTarifa", SqlDbType.Char, 8).Value = sFchIniTarifa
        cd.Parameters.Add("@CodUsuarioSys", SqlDbType.VarChar, 15).Value = sCodUsuarioSys
        cd.Parameters.Add("@FlagEmailAcceso", SqlDbType.Char, 1).Value = sFlagEmailAcceso
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
        cd.CommandText = "SEG_Usuario_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char).Value = sCodUsuario
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

    Function Editar() As String
        sMsg = "No existe registro " & sCodUsuario

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_LeeUsuario_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sCodUsuario = dr.GetValue(dr.GetOrdinal("CodUsuario"))
                sNomUsuario = dr.GetValue(dr.GetOrdinal("NomUsuario"))
                sCodPerfil = dr.GetValue(dr.GetOrdinal("CodPerfil"))
                sStsUsuario = dr.GetValue(dr.GetOrdinal("StsUsuario"))
                sNomStsUsuario = dr.GetValue(dr.GetOrdinal("NomStsUsuario"))
                sTipoIdioma = dr.GetValue(dr.GetOrdinal("TipoIdioma"))
                sNomTipoIdioma = dr.GetValue(dr.GetOrdinal("NomTipoIdioma"))
                sFlagLogAcceso = dr.GetValue(dr.GetOrdinal("FlagLogAcceso"))
                sFlagVtaAcceso = dr.GetValue(dr.GetOrdinal("FlagVtaAcceso"))
                sFlagEmailAcceso = dr.GetValue(dr.GetOrdinal("FlagEmailAcceso"))
                sFlagModoTrabajo = dr.GetValue(dr.GetOrdinal("FlagModoTrabajo"))
                sFchSys = dr.GetValue(dr.GetOrdinal("FchSys"))
                If IsDBNull(dr.GetValue(dr.GetOrdinal("FchIniTarifa"))) Then
                    sFchIniTarifa = ""
                Else
                    sFchIniTarifa = String.Format("{0:dd-MM-yyyy}", dr.GetValue(dr.GetOrdinal("FchIniTarifa")))
                End If
                sCodUsuarioSys = dr.GetValue(dr.GetOrdinal("CodUsuarioSys"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

    Function CambiarClave() As String
        If sClave.Trim.Length = 0 Then
            Return ("Clave es dato obligatorio")
        End If

        Dim objcifrado As New clsCifrado
        Dim wClave As String

        wClave = objcifrado.EncryptString128Bit(sClave, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "SEG_UsuarioClave_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        cd.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = wClave
        cd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 25).Value = sIPAddress
        cd.Parameters.Add("@CodUsuarioSys", SqlDbType.Char, 15).Value = sCodUsuarioSys
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

    Function CambiarClave(ByVal pClaveActual As String, ByVal pNuevaClave As String, ByVal pNuevaClaveRepite As String) As String
        If pClaveActual.Trim.Length = 0 Then
            Return ("Clave actual es obligatorio")
        End If
        If pNuevaClave.Trim.Length = 0 Then
            Return ("Nueva clave es obligatorio")
        End If

        Dim objcifrado As New clsCifrado

        Dim wClaveOk As Boolean = False
        Dim wClave As String
        Dim wClave1 As String
        Dim wClave2 As String
        wClave1 = ""
        sMsg = "No existe registro " & sCodUsuario


        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_LeeUsuario_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                wClave = objcifrado.EncryptString128Bit(pClaveActual, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))
                wClave1 = objcifrado.EncryptString128Bit(pNuevaClave, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))
                wClave2 = objcifrado.EncryptString128Bit(pNuevaClaveRepite, System.Configuration.ConfigurationManager.AppSettings("KeyEncrypt"))

                If wClave = dr.GetValue(dr.GetOrdinal("Clave")) Then
                    If wClave1 = wClave2 Then
                        wClaveOk = True
                    Else
                        sMsg = "Error: Nueva clave son diferentes, ingrese otra vez"
                    End If
                Else
                    sMsg = "Error: Clave actual incorrecta"
                End If
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        If wClaveOk Then
            Dim cn1 As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
            Dim cd1 As New SqlCommand
            cd1.Connection = cn1
            cd1.CommandText = "SEG_Usuario_U"
            cd1.CommandType = CommandType.StoredProcedure

            Dim pa1 As New SqlParameter
            pa1 = cd1.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
            pa1.Direction = ParameterDirection.Output
            pa1.Value = ""
            cd1.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
            cd1.Parameters.Add("@Clave", SqlDbType.VarChar, 150).Value = wClave1
            cd1.Parameters.Add("@CodUsuarioSys", SqlDbType.VarChar, 15).Value = sCodUsuario
            Try
                cn1.Open()
                cd1.ExecuteNonQuery()
                sMsg = cd1.Parameters("@MsgTrans").Value
            Catch ex1 As System.Data.SqlClient.SqlException
                sMsg = "Error:" & ex1.Message
            Catch ex2 As System.Exception
                sMsg = "Error:" & ex2.Message
            Finally
                cn1.Close()
            End Try
        End If
        Return (sMsg)
    End Function
End Class