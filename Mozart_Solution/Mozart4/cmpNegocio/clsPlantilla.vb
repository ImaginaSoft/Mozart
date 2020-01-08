
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsPlantilla
    Private iNroPlantilla As Integer
    Private sDesPlantilla As String
    Private sStsPlantilla As String
    Private sCodZonaVta As String
    Private iCodTipoPlantilla As Integer
    Private iCodCateTour As Integer
    Private sFlagUsoAge As String
    Private sCodUsuario As String

    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Property NroPlantilla() As Integer
        Get
            Return iNroPlantilla
        End Get
        Set(ByVal Value As Integer)
            iNroPlantilla = (Value)
        End Set
    End Property

    Property DesPlantilla() As String
        Get
            Return sDesPlantilla
        End Get
        Set(ByVal Value As String)
            sDesPlantilla = CStr(Value)
        End Set
    End Property

    Property StsPlantilla() As String
        Get
            Return sStsPlantilla
        End Get
        Set(ByVal Value As String)
            sStsPlantilla = CStr(Value)
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

    Property CodTipoPlantilla() As Integer
        Get
            Return iCodTipoPlantilla
        End Get
        Set(ByVal Value As Integer)
            iCodTipoPlantilla = (Value)
        End Set
    End Property

    Property CodCateTour() As Integer
        Get
            Return iCodCateTour
        End Get
        Set(ByVal Value As Integer)
            iCodCateTour = (Value)
        End Set
    End Property

    Property FlagUsoAge() As String
        Get
            Return sFlagUsoAge
        End Get
        Set(ByVal Value As String)
            sFlagUsoAge = CStr(Value)
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

    Function CargaNroPlantilla(ByVal pNroPlantilla As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaNroPlantilla_S", New SqlParameter("@NroPlantilla", pNroPlantilla))
        Return (ds)
    End Function

    Function CargaxTitulo(ByVal pCodZonaVta As String, ByVal pTitulo As String, ByVal pNroPedido As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(2).Value = pNroPedido
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTituloActiva_S", arParms)
        Return (ds)
    End Function

    Function CargaxTitulo(ByVal pCodZonaVta As String, ByVal pTitulo As String, ByVal pNroPedido As Integer, ByVal pCodTipoPlantilla As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(2).Value = pNroPedido
        arParms(3) = New SqlParameter("@CodTipoPlantilla", SqlDbType.Int)
        arParms(3).Value = pCodTipoPlantilla
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTituloActivaTipPla_S", arParms)
        Return (ds)
    End Function

    Function CargaxTituloDias(ByVal pCodZonaVta As String, ByVal pTitulo As String, ByVal pCantDias As Integer, ByVal pNroPedido As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@CantDias", SqlDbType.Int)
        arParms(2).Value = pCantDias
        arParms(3) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(3).Value = pNroPedido
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaDiasActiva_S", arParms)
        Return (ds)
    End Function

    Function CargaxTituloDias(ByVal pCodZonaVta As String, ByVal pTitulo As String, ByVal pCantDias As Integer, ByVal pNroPedido As Integer, ByVal pCodTipoPlantilla As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@CantDias", SqlDbType.Int)
        arParms(2).Value = pCantDias
        arParms(3) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(3).Value = pNroPedido
        arParms(4) = New SqlParameter("@CodTipoPlantilla", SqlDbType.Int)
        arParms(4).Value = pCodTipoPlantilla
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaDiasActivaTipPla_S", arParms)
        Return (ds)
    End Function

    Function FiltroTituloDias(ByVal pTitulo As String, ByVal pcantdias As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(0).Value = pTitulo
        arParms(1) = New SqlParameter("@CantDias", SqlDbType.Int)
        arParms(1).Value = pcantdias

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTituloDias_S", arParms)
        Return (ds)
    End Function

    Function CargaxDias(ByVal pTitulo As String, ByVal pCantDias As Integer, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(0).Value = pTitulo
        arParms(1) = New SqlParameter("@CantDias", SqlDbType.Int)
        arParms(1).Value = pCantDias
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaDias_S", arParms)
        Return (ds)
    End Function

    Function CargaxDiasSts(ByVal pStsPlantilla As String, ByVal pTitulo As String, ByVal pCantDias As Integer, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@StsPlantilla", SqlDbType.Char, 1)
        arParms(0).Value = pStsPlantilla
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@CantDias", SqlDbType.Int)
        arParms(2).Value = pCantDias
        arParms(3) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(3).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaDiasSts_S", arParms)
        Return (ds)
    End Function

    Function CargaxTituloZonaVta(ByVal pTitulo As String, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(0).Value = pTitulo
        arParms(1) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(1).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTitulo_S", arParms)
        Return (ds)
    End Function

    Function CargaxStsTituloZonaVta(ByVal pStsPlantilla As String, ByVal pTitulo As String, ByVal pCodZonaVta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@StsPlantilla", SqlDbType.Char, 1)
        arParms(0).Value = pStsPlantilla
        arParms(1) = New SqlParameter("@Titulo", SqlDbType.VarChar, 80)
        arParms(1).Value = pTitulo
        arParms(2) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(2).Value = pCodZonaVta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTituloSts_S", arParms)
        Return (ds)
    End Function

    Function CargaxTipoPlantilla(ByVal pCodZonaVta As String, ByVal pCodTipoPlantilla As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@CodTipoPlantilla", SqlDbType.Int)
        arParms(1).Value = pCodTipoPlantilla

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTipoPlantilla", arParms)
        Return (ds)
    End Function

    Function CargaxTipoPlantilla(ByVal pCodZonaVta As String, ByVal pStsPlantilla As String, ByVal pCodTipoPlantilla As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodZonaVta", SqlDbType.Char, 3)
        arParms(0).Value = pCodZonaVta
        arParms(1) = New SqlParameter("@StsPlantilla", SqlDbType.Char, 1)
        arParms(1).Value = pStsPlantilla
        arParms(2) = New SqlParameter("@CodTipoPlantilla", SqlDbType.Int)
        arParms(2).Value = pCodTipoPlantilla
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaTipoPlanillaSts", arParms)
        Return (ds)
    End Function

    Function CargaxFlagDias(ByVal pCantDias As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaFlagDias", New SqlParameter("@CantDias", pCantDias))
        Return (ds)
    End Function

    Function CargaServicios(ByVal pNroPlantilla As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PlantillaServicio_S", New SqlParameter("@NroPlantilla", pNroPlantilla))
        Return (ds)
    End Function


    Function Editar(ByVal pNroPlantilla As Integer) As String
        sMsg = "No existe Plantilla " & CStr(iNroPlantilla)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_PlantillaNroPlantilla_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = pNroPlantilla
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sDesPlantilla = dr.GetValue(dr.GetOrdinal("DesPlantilla"))
                sStsPlantilla = dr.GetValue(dr.GetOrdinal("StsPlantilla"))
                sCodZonaVta = dr.GetValue(dr.GetOrdinal("CodZonaVta"))
                iCodTipoPlantilla = dr.GetValue(dr.GetOrdinal("CodTipoPlantilla"))
                iCodCateTour = dr.GetValue(dr.GetOrdinal("CodCateTour"))
                sFlagUsoAge = dr.GetValue(dr.GetOrdinal("FlagUsoAge"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

    Function Borrar(ByVal pNroPlantilla As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_Plantilla_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.SmallInt).Value = pNroPlantilla
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


    Function InsertaDias(ByVal pNroPlantilla As Integer, ByVal pDiaIni As String, ByVal pCantDias As String, ByVal pCodUsuario As String) As String
        If Not IsNumeric(pDiaIni) Then
            Return ("Dia de inicio es obligatorio")
        End If
        If Not IsNumeric(pCantDias) Then
            Return ("Cantidad días es obligatorio")
        End If


        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_PlantillaDias_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = pNroPlantilla
        cd.Parameters.Add("@DiaIni", SqlDbType.Int).Value = pDiaIni
        cd.Parameters.Add("@CantDias", SqlDbType.Int).Value = pCantDias
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
        Return (sMsg)
    End Function

    Function BorraDias(ByVal pNroPlantilla As Integer, ByVal pDiaIni As String, ByVal pDiaFin As String, ByVal pCodUsuario As String) As String
        If Not IsNumeric(pDiaIni) Then
            Return ("Dia de inicio es obligatorio")
        End If
        If Not IsNumeric(pDiaFin) Then
            Return ("Dia final es obligatorio")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_PlantillaDias_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPlantilla", SqlDbType.Int).Value = pNroPlantilla
        cd.Parameters.Add("@DiaIni", SqlDbType.Int).Value = pDiaIni
        cd.Parameters.Add("@DiaFin", SqlDbType.Int).Value = pDiaFin
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
        Return (sMsg)
    End Function

End Class