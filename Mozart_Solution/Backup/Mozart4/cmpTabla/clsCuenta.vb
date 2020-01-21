Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsCuenta
    Private sCodCuenta As String
    Private sNomCuenta As String
    Private sTipoCuenta As String
    Private iGrupoCuenta As String
    Private sCodNivel As String
    Private sCodUsuario As String

    Private sNomTipoCuenta As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Dim sMsg As String

    Property CodCuenta() As String
        Get
            Return sCodCuenta
        End Get
        Set(ByVal Value As String)
            sCodCuenta = CStr(Value)
        End Set
    End Property

    Property NomCuenta() As String
        Get
            Return sNomCuenta
        End Get
        Set(ByVal Value As String)
            sNomCuenta = CStr(Value)
        End Set
    End Property

    Property TipoCuenta() As String
        Get
            Return sTipoCuenta
        End Get
        Set(ByVal Value As String)
            sTipoCuenta = CStr(Value)
        End Set
    End Property

    Property GrupoCuenta() As Integer
        Get
            Return iGrupoCuenta
        End Get
        Set(ByVal Value As Integer)
            iGrupoCuenta = Value
        End Set
    End Property

    Property CodNivel() As String
        Get
            Return sCodNivel
        End Get
        Set(ByVal Value As String)
            sCodNivel = CStr(Value)
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

    'Solo para editar
    Property NomTipoCuenta() As String
        Get
            Return sNomTipoCuenta
        End Get
        Set(ByVal Value As String)
            sNomTipoCuenta = CStr(Value)
        End Set
    End Property

    Function CuentaSaldoMes(ByVal pAnoProceso As Integer, ByVal pMesProceso As Integer, ByVal pCodCuenta As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@AnoProceso", SqlDbType.Int)
        arParms(0).Value = pAnoProceso
        arParms(1) = New SqlParameter("@MesProceso", SqlDbType.Int)
        arParms(1).Value = pMesProceso
        arParms(2) = New SqlParameter("@CodCuenta", SqlDbType.Char, 4)
        arParms(2).Value = pCodCuenta
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPP_CuentaSaldoMes_S", arParms)
        Return (ds)
    End Function

    Function CargarCuentaNivel1() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_CuentaNivel1_S")
        Return (ds)
    End Function

    Function CargarCuenta2(ByVal pTipoCuenta As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Cuenta2_S", New SqlParameter("@TipoCuenta", pTipoCuenta))
        Return (ds)
    End Function

    Function CargarCuenta4(ByVal pCodCuenta As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Cuenta4_S", New SqlParameter("@CodCuenta", pCodCuenta))
        Return (ds)
    End Function

    Function CargarCuentaDet(ByVal pFchIni As String, ByVal pFchFin As String, ByVal pCodGasto As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@FchIni", SqlDbType.Char, 8)
        arParms(0).Value = pFchIni
        arParms(1) = New SqlParameter("@FchFin", SqlDbType.Char, 8)
        arParms(1).Value = pFchFin
        arParms(2) = New SqlParameter("@CodCuenta", SqlDbType.Char, 4)
        arParms(2).Value = pCodGasto

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPP_CuentaDet_S", arParms)
        Return (ds)
    End Function

    Function Cargar() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_Cuenta_S")
        Return (ds)
    End Function

    Function CargarCuenta(ByVal pCodGasto As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TipoGastoCodGasto2_S", New SqlParameter("@CodGasto", pCodGasto))
        Return (ds)
    End Function

    Function Grabar() As String
        If sCodCuenta.Trim.Length = 0 Then
            Return ("Error: Código de gasto es obligatorio")
        End If
        If Not IsNumeric(sCodCuenta) Then
            Return ("Error: Còdigo del gasto, es de tipo numérico.")
        End If
        If sNomCuenta.Trim.Length = 0 Then
            Return ("Error: Nombre de gasto es obligatorio")
        End If

        If sCodCuenta.Trim.Length = 1 Then
            sCodNivel = "0"
        ElseIf sCodCuenta.Trim.Length = 2 Then
            sCodNivel = "1"
        ElseIf sCodCuenta.Trim.Length = 4 Then
            sCodNivel = "2"
        Else
            Return ("Error: Código gasto válido es de 2 o 4 digitos")
        End If
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Cuenta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = sCodCuenta
        cd.Parameters.Add("@NomCuenta", SqlDbType.Char, 50).Value = sNomCuenta
        cd.Parameters.Add("@TipoCuenta", SqlDbType.Char, 1).Value = sTipoCuenta
        cd.Parameters.Add("@GrupoCuenta", SqlDbType.Int).Value = iGrupoCuenta
        cd.Parameters.Add("@CodNivel", SqlDbType.Char, 1).Value = sCodNivel
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
        cd.CommandText = "TAB_Cuenta_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = sCodCuenta
        cd.Parameters.Add("@Nivel", SqlDbType.Char, 1).Value = sCodNivel
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
        sMsg = "No existe " & sCodCuenta
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "TAB_CuentaEdita_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = sCodCuenta
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                sCodCuenta = dr.GetValue(dr.GetOrdinal("CodCuenta"))
                sNomCuenta = RTrim(dr.GetValue(dr.GetOrdinal("NomCuenta")))
                sTipoCuenta = Trim(dr.GetValue(dr.GetOrdinal("TipoCuenta")))
                iGrupoCuenta = Trim(dr.GetValue(dr.GetOrdinal("GrupoCuenta")))
                sNomTipoCuenta = Trim(dr.GetValue(dr.GetOrdinal("NomTipoCuenta")))
                sMsg = "OK"
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function
End Class