Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsZonaVta
    Dim sMsg As String

    Private sCodZonaVta As String
    Private sNomZonaVta As String
    Private sStsZonaVta As String
    Private sNroOrden As String
    Private sCodCuenta As String
    Private sCodUsuario As String
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Property CodZonaVta() As String
        Get
            Return sCodZonaVta
        End Get
        Set(ByVal Value As String)
            sCodZonaVta = CStr(Value)
        End Set
    End Property

    Property NomZonaVta() As String
        Get
            Return sNomZonaVta
        End Get
        Set(ByVal Value As String)
            sNomZonaVta = CStr(Value)
        End Set
    End Property

    Property StsZonaVta() As String
        Get
            Return sStsZonaVta
        End Get
        Set(ByVal Value As String)
            sStsZonaVta = CStr(Value)
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

    Property CodCuenta() As String
        Get
            Return sCodCuenta
        End Get
        Set(ByVal Value As String)
            sCodCuenta = CStr(Value)
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

    Function Cargar() As DataSet

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_ZonaVta_S")
        Return (ds)
    End Function

    Function Cargar(ByVal pCodUsuario As String) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_ZonaVtaxUsuario_S", New SqlParameter("@CodUsuario", pCodUsuario))
        Return (ds)
    End Function

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_ZonaVtaActivo_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If Not IsNumeric(sNroOrden) Then
            sNroOrden = 0
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_ZonaVta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = sCodZonaVta
        cd.Parameters.Add("@NomZonaVta", SqlDbType.VarChar, 50).Value = sNomZonaVta
        cd.Parameters.Add("@StsZonaVta", SqlDbType.Char, 1).Value = sStsZonaVta
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = sNroOrden
        cd.Parameters.Add("@CodCuenta", SqlDbType.Char, 4).Value = sCodCuenta
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = sCodUsuario
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        Finally
            cn.Close()
        End Try
        Return (sMsg)

    End Function

    Function Borrar() As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_ZonaVta_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = sCodZonaVta
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            sMsg = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function

    Function Editar(ByVal pCodZonaVta As String) As String
        sMsg = "No existe registro " & sCodUsuario

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        Dim pa As New SqlParameter
        Dim dr As SqlDataReader

        cd.Connection = cn
        cd.CommandText = "TAB_ZonaVtaLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodZonaVta", SqlDbType.Char, 3).Value = sCodZonaVta

        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sNomZonaVta = dr.GetValue(dr.GetOrdinal("NomZonaVta"))
                sMsg = "OK"
            End While
            dr.Close()
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = sMsg + " " & ex1.Message
        Catch ex2 As System.Exception
            sMsg = sMsg + " " & ex2.Message
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function

End Class