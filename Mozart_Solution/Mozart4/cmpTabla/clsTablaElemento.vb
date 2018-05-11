Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsTablaElemento
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private sCodTabla As String
    Private sCodElemento As String
    Private sNomEleEsp As String
    Private sNomEleIng As String
    Private sStsElemento As String
    Private sNroOrden As String
    Private sCodUsuario As String

    Property CodTabla() As String
        Get
            Return sCodTabla
        End Get
        Set(ByVal Value As String)
            sCodTabla = CStr(Value)
        End Set
    End Property

    Property CodElemento() As String
        Get
            Return sCodElemento
        End Get
        Set(ByVal Value As String)
            sCodElemento = CStr(Value)
        End Set
    End Property

    Property NomEleEsp() As String
        Get
            Return sNomEleEsp
        End Get
        Set(ByVal Value As String)
            sNomEleEsp = CStr(Value)
        End Set
    End Property

    Property NomEleIng() As String
        Get
            Return sNomEleIng
        End Get
        Set(ByVal Value As String)
            sNomEleIng = CStr(Value)
        End Set
    End Property

    Property StsElemento() As String
        Get
            Return sStsElemento
        End Get
        Set(ByVal Value As String)
            sStsElemento = CStr(Value)
        End Set
    End Property


    Property NroOrden() As String
        Get
            Return sNroOrden
        End Get
        Set(ByVal Value As String)
            sNroOrden = CStr(Value)
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

    Function Cargar(ByVal pCodTabla As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TablaElemento_S", New SqlParameter("@CodTabla", pCodTabla))
        Return (ds)
    End Function

    Function CargaTablaEleNumxNroOrden(ByVal pCodTabla As Integer, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodTabla", SqlDbType.Int)
        arParms(0).Value = pCodTabla
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TablaEleNumxNroOrden_S", arParms)
        Return (ds)
    End Function

    Function CargaTablaElexCodEle(ByVal pCodTabla As Integer, ByVal pIdioma As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodTabla", SqlDbType.Int)
        arParms(0).Value = pCodTabla
        arParms(1) = New SqlParameter("@Idioma", SqlDbType.Char, 1)
        arParms(1).Value = pIdioma
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_TablaElementoxCodEle_S", arParms)
        Return (ds)
    End Function


    Function Grabar() As String
        If sCodElemento.Trim.Length = 0 Then
            Return ("Código es obligatorio")
        End If
        If Not IsNumeric(sCodTabla) Then
            Return ("Código de númerico")
        End If
        If sNomEleEsp.Trim.Length = 0 Then
            Return ("Nombre en español es obligatorio")
        End If
        'If sNomEleIng.Trim.Length = 0 Then
        'Return ("Nombre en ingles es obligatorio")
        'End If
        If sNroOrden.Trim.Length = 0 Then
            Return ("Número de orden es obligatorio")
        End If
        If Not IsNumeric(sCodTabla) Then
            Return ("Número de orden es númerico")
        End If


        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TablaElemento_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTabla", SqlDbType.SmallInt).Value = sCodTabla
        cd.Parameters.Add("@CodElemento", SqlDbType.Char, 10).Value = sCodElemento
        cd.Parameters.Add("@NomEleEsp", SqlDbType.VarChar, 100).Value = sNomEleEsp
        cd.Parameters.Add("@NomEleIng", SqlDbType.VarChar, 100).Value = sNomEleIng
        cd.Parameters.Add("@StsElemento", SqlDbType.Char, 1).Value = sStsElemento
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = sNroOrden
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

    Function Borrar(ByVal pCodTabla As Integer, ByVal pCodElemento As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_TablaElemento_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTabla", SqlDbType.SmallInt).Value = pCodTabla
        cd.Parameters.Add("@CodElemento", SqlDbType.SmallInt).Value = pCodElemento
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