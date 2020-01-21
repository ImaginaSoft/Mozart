Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsTour
    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Private sIdioma As String
    Private sCodTour As String
    Private sNomTour As String
    Private sClasificaTour As String
    Private sCantDias As String
    Private sStsTour As String
    Private sNroPlantilla As String
    Private sCodUsuario As String

    Property Idioma() As String
        Get
            Return sIdioma
        End Get
        Set(ByVal Value As String)
            sIdioma = CStr(Value)
        End Set
    End Property

    Property CodTour() As String
        Get
            Return sCodTour
        End Get
        Set(ByVal Value As String)
            sCodTour = CStr(Value)
        End Set
    End Property

    Property NomTour() As String
        Get
            Return sNomTour
        End Get
        Set(ByVal Value As String)
            sNomTour = CStr(Value)
        End Set
    End Property

    Property ClasificaTour() As String
        Get
            Return sClasificaTour
        End Get
        Set(ByVal Value As String)
            sClasificaTour = CStr(Value)
        End Set
    End Property

    Property CantDias() As String
        Get
            Return sCantDias
        End Get
        Set(ByVal Value As String)
            sCantDias = CStr(Value)
        End Set
    End Property

    Property StsTour() As String
        Get
            Return sStsTour
        End Get
        Set(ByVal Value As String)
            sStsTour = CStr(Value)
        End Set
    End Property

    Property NroPlantilla() As String
        Get
            Return sNroPlantilla
        End Get
        Set(ByVal Value As String)
            sNroPlantilla = CStr(Value)
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
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "PLA_Tour_S")
        Return (ds)
    End Function

    Function Grabar() As String
        If sCodTour.Trim.Length = 0 Then
            Return ("Código de Tour es obligatorio")
        End If
        If Not IsNumeric(sCodTour.Trim) Then
            Return ("Código de Tour es númerico")
        End If
        If sNomTour.Trim.Length = 0 Then
            Return ("Nombre de Tour es obligatorio")
        End If
        If sCantDias.Trim.Length = 0 Then
            Return ("Cantidad de dias es obligatorio")
        End If
        If Not IsNumeric(sCantDias.Trim) Then
            Return ("Cantidad de dias es númerico")
        End If

        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_Tour_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Idioma", SqlDbType.Char, 1).Value = sIdioma
        cd.Parameters.Add("@CodTour", SqlDbType.SmallInt).Value = sCodTour
        cd.Parameters.Add("@NomTour", SqlDbType.VarChar, 100).Value = sNomTour
        cd.Parameters.Add("@ClasificaTour", SqlDbType.VarChar, 100).Value = sClasificaTour
        cd.Parameters.Add("@CantDias", SqlDbType.TinyInt).Value = sCantDias
        cd.Parameters.Add("@StsTour", SqlDbType.Char, 1).Value = sStsTour
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

    Function Borrar(ByVal pCodTour As Integer) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "PLA_Tour_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodTour", SqlDbType.SmallInt).Value = pCodTour
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

    Function Editar(ByVal pCodTour As Integer) As String
        sMsg = "No existe Tour " & CStr(pCodTour)

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "PLA_TourLee_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodTour", SqlDbType.Int).Value = pCodTour
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sNomTour = dr.GetValue(dr.GetOrdinal("NomTour"))
                sCantDias = dr.GetValue(dr.GetOrdinal("CantDias"))
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sMsg)
    End Function

End Class