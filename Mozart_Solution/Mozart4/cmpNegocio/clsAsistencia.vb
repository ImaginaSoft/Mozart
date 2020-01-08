Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsAsistencia
    Private cn As String = System.Configuration.ConfigurationSettings.AppSettings("cnMozart")
    Private sMsg As String

    Private iCodPersonal As Integer
    Private sFchMarca As String
    Private sHoraIngreso As String
    Private sJustifica As String
    Private sAnoVacacion As String
    Private sTipoVacacion As String
    Private dCantDiasReal As Double
    Private sStsAsistencia As String
    Private sCodUsuario As String

    Private sOpcion As String
    Private sFchIni As String
    Private sFchFin As String

    Property CodPersonal() As Integer
        Get
            Return iCodPersonal
        End Get
        Set(ByVal Value As Integer)
            iCodPersonal = (Value)
        End Set
    End Property

    Property FchMarca() As String
        Get
            Return sFchMarca
        End Get
        Set(ByVal Value As String)
            sFchMarca = CStr(Value)
        End Set
    End Property

    Property HoraIngreso() As String
        Get
            Return sHoraIngreso
        End Get
        Set(ByVal Value As String)
            sHoraIngreso = CStr(Value)
        End Set
    End Property

    Property AnoVacacion() As String
        Get
            Return sAnoVacacion
        End Get
        Set(ByVal Value As String)
            sAnoVacacion = CStr(Value)
        End Set
    End Property

    Property TipoVacacion() As String
        Get
            Return sTipoVacacion
        End Get
        Set(ByVal Value As String)
            sTipoVacacion = CStr(Value)
        End Set
    End Property

    Property Justifica() As String
        Get
            Return sJustifica
        End Get
        Set(ByVal Value As String)
            sJustifica = CStr(Value)
        End Set
    End Property

    Property CantDiasReal() As Double
        Get
            Return dCantDiasReal
        End Get
        Set(ByVal Value As Double)
            dCantDiasReal = (Value)
        End Set
    End Property

    Property StsAsistencia() As String
        Get
            Return sStsAsistencia
        End Get
        Set(ByVal Value As String)
            sStsAsistencia = CStr(Value)
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

    Property CodUsuario() As String
        Get
            Return sCodUsuario
        End Get
        Set(ByVal Value As String)
            sCodUsuario = CStr(Value)
        End Set
    End Property

    Property FchIni() As String
        Get
            Return sFchIni
        End Get
        Set(ByVal Value As String)
            sFchIni = CStr(Value)
        End Set
    End Property

    Property FchFin() As String
        Get
            Return sFchFin
        End Get
        Set(ByVal Value As String)
            sFchFin = CStr(Value)
        End Set
    End Property


    Function AsistenciaTrabajadorxFecha(ByVal pCodPersonal As Integer, ByVal pFchIni As String, ByVal pFchFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodPersonal", SqlDbType.Int)
        arParms(0).Value = pCodPersonal
        arParms(1) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(1).Value = pFchIni
        arParms(2) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(2).Value = pFchFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PER_AsistenciaTrabajadorxFechas_S", arParms)
        Return (ds)
    End Function

    Function VacaDiaLibreProgramado(ByVal pCodPersonal As Integer, ByVal pAnoVacacion As String, ByVal pTipoVacacion As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodPersonal", SqlDbType.Int)
        arParms(0).Value = pCodPersonal
        arParms(1) = New SqlParameter("@AnoVacacion", SqlDbType.Char, 4)
        arParms(1).Value = pAnoVacacion
        arParms(2) = New SqlParameter("@TipoVacacion", SqlDbType.Char, 1)
        arParms(2).Value = pTipoVacacion
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PER_AsistenciaVacaProgramado_S", arParms)
        Return (ds)
    End Function

    Function ControlAsistencia(ByVal pFchIni As String, ByVal pFchFin As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFchIni
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PER_ControlAsistencia_S", arParms)
        Return (ds)
    End Function


    Function ControlVacaciones(ByVal pFchIni As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFchIni
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PER_ControlVacaciones_S", arParms)
        Return (ds)
    End Function

    Function Actualiza() As String
        Dim wMsg As String

        Dim cn1 As New SqlConnection(cn)
        Dim cd As New SqlCommand
        cd.Connection = cn1
        cd.CommandText = "PER_Asistencia_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPersonal", SqlDbType.Int).Value = iCodPersonal
        cd.Parameters.Add("@FchMarca", SqlDbType.Char, 8).Value = sFchMarca
        cd.Parameters.Add("@Justifica", SqlDbType.VarChar, 100).Value = sJustifica
        cd.Parameters.Add("@AnoVacacion", SqlDbType.Char, 4).Value = sAnoVacacion
        cd.Parameters.Add("@TipoVacacion", SqlDbType.Char, 1).Value = sTipoVacacion
        cd.Parameters.Add("@CantDiasReal", SqlDbType.SmallMoney).Value = dCantDiasReal
        cd.Parameters.Add("@Opcion", SqlDbType.Char, 1).Value = sOpcion
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn1.Open()
            cd.ExecuteNonQuery()
            wMsg = Trim(cd.Parameters("@MsgTrans").Value)
        Catch ex1 As System.Data.SqlClient.SqlException
            wMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            wMsg = "Error:" & ex2.Message
        End Try
        cn1.Close()
        Return (wMsg)
    End Function

    Function ProgramaVacaDiaLibre() As String
        Dim wMsg As String

        Dim cn1 As New SqlConnection(cn)
        Dim cd As New SqlCommand
        cd.Connection = cn1
        cd.CommandText = "PER_AsistenciaVacaProgramado_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 8000)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPersonal", SqlDbType.Int).Value = iCodPersonal
        cd.Parameters.Add("@AnoVacacion", SqlDbType.Char, 4).Value = sAnoVacacion
        cd.Parameters.Add("@TipoVacacion", SqlDbType.Char, 1).Value = sTipoVacacion
        cd.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = sFchIni
        cd.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = sFchFin
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn1.Open()
            cd.ExecuteNonQuery()
            wMsg = Trim(cd.Parameters("@MsgTrans").Value)
        Catch ex1 As System.Data.SqlClient.SqlException
            wMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            wMsg = "Error:" & ex2.Message
        End Try
        cn1.Close()
        Return (wMsg)
    End Function

    Function Borrar(ByVal pCodPersonal As Integer, ByVal pFchMarca As String) As String
        Dim cn1 As New SqlConnection(cn)
        Dim cd As New SqlCommand
        cd.Connection = cn1
        cd.CommandText = "PER_Asistencia_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodPersonal", SqlDbType.Int).Value = pCodPersonal
        cd.Parameters.Add("@FchMarca", SqlDbType.Char, 8).Value = pFchMarca
        Try
            cn1.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        Return (sMsg)
    End Function

End Class
