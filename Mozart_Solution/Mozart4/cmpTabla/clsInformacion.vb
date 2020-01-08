Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsInformacion
    Private iNroInformacion As String
    Private sNomInfEsp As String
    Private sNomInfIng As String
    Private sNomInfPor As String
    Private sNivelInf As String
    Private sStsInf As String
    Private iNroOrden As String
    Private iNroTipoInf As String 
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property NroInformacion() As String
        Get
            Return iNroInformacion
        End Get
        Set(ByVal Value As String)
            iNroInformacion = CStr(Value)
        End Set
    End Property

    Property NomInfEsp() As String
        Get
            Return sNomInfEsp
        End Get
        Set(ByVal Value As String)
            sNomInfEsp = CStr(Value)
        End Set
    End Property

    Property NomInfIng() As String
        Get
            Return sNomInfIng
        End Get
        Set(ByVal Value As String)
            sNomInfIng = CStr(Value)
        End Set
    End Property

    Property NomInfPor() As String
        Get
            Return sNomInfPor
        End Get
        Set(ByVal Value As String)
            sNomInfPor = CStr(Value)
        End Set
    End Property

    Property NivelInf() As String
        Get
            Return sNivelInf
        End Get
        Set(ByVal Value As String)
            sNivelInf = CStr(Value)
        End Set
    End Property

    Property StsInf() As String
        Get
            Return sStsInf
        End Get
        Set(ByVal Value As String)
            sStsInf = CStr(Value)
        End Set
    End Property

    Property NroOrden() As String
        Get
            Return iNroOrden
        End Get
        Set(ByVal Value As String)
            iNroOrden = CStr(Value)
        End Set
    End Property

    Property NroTipoInf() As String
        Get
            Return iNroTipoInf
        End Get
        Set(ByVal Value As String)
            iNroTipoInf = CStr(Value)
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

    Function Cargar(ByVal pNroTipoInf As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Informacion_S", New SqlParameter("@NroTipoinf", pNroTipoInf))
        Return (ds)
    End Function

    'demo solo demo
    'BORRAR
    Function CargarTSOLICITUDDET(ByVal pNroTipoInf As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TSolicitudDet_S", New SqlParameter("@NroTipoinf", pNroTipoInf))
        Return (ds)
    End Function


    Function CargarxNivelInf(ByVal pNroTipoInf As Integer, ByVal pNivelInf As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroTipoInf", SqlDbType.SmallInt)
        arParms(0).Value = pNroTipoInf
        arParms(1) = New SqlParameter("@NivelInf", SqlDbType.Char, 1)
        arParms(1).Value = pNivelInf

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_InformacionxNivelInf_S", arParms)
        Return (ds)
    End Function

    Function CargarxZonaVta(ByVal pCodZonaVta As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_InformacionxZonaVta_S", New SqlParameter("@CodZonaVta", pCodZonaVta))
        Return (ds)
    End Function

    Function CargarxCiudad(ByVal pCodCiudad As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_InformacionxCiudad_S", New SqlParameter("@CodCiudad", pCodCiudad))
        Return (ds)
    End Function

    Function CargarxServicio(ByVal pNroServicio As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_InformacionxServicio_S", New SqlParameter("@NroServicio", pNroServicio))
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(iNroOrden) Then
            Return ("Número Orden es numerico")
        End If
        If iNroOrden <= 0 Then
            Return ("Número Orden es mayor a cero")
        End If

        If Not IsNumeric(iNroInformacion) Or iNroInformacion.Trim.Length = 0 Then
            iNroInformacion = "0"
        End If


        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Informacion_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroInformacion", SqlDbType.SmallInt).Value = iNroInformacion
        cd.Parameters.Add("@NomInfEsp", SqlDbType.VarChar, 2000).Value = sNomInfEsp
        cd.Parameters.Add("@NomInfIng", SqlDbType.VarChar, 2000).Value = sNomInfIng
        cd.Parameters.Add("@NomInfPor", SqlDbType.VarChar, 2000).Value = sNomInfPor
        cd.Parameters.Add("@NivelInf", SqlDbType.Char, 1).Value = sNivelInf
        cd.Parameters.Add("@StsInf", SqlDbType.Char, 1).Value = sStsInf
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = iNroOrden
        cd.Parameters.Add("@NroTipoInf", SqlDbType.SmallInt).Value = iNroTipoInf
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error1:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error2:" & ex2.Message
        End Try
        cn.Close()
        Return (sMsg)
    End Function

    Function Borrar(ByVal pNroInformacion As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Informacion_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroInformacion", SqlDbType.SmallInt).Value = pNroInformacion
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error1:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error2:" & ex2.Message
        End Try
        Return (sMsg)
    End Function
End Class