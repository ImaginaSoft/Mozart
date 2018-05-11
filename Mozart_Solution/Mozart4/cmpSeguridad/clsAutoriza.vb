Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsAutoriza
    Structure AutorizaInfo
        Dim strName As String
        Dim strPage As String
    End Structure

    Public Function GetAutorizaList(ByVal pCodUsuario As String) As AutorizaInfo()
        ' Cambiar el tamaño del arreglo cada ves que adiciona
        ' una nueva opcion
        Dim arAutoriza(120) As AutorizaInfo

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim ds As System.Data.DataSet = New System.Data.DataSet

        Dim da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        da.SelectCommand = New System.Data.SqlClient.SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure
        da.SelectCommand.CommandText = "SEG_LeeUsuario_S"

        Dim pa As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter
        pa = New System.Data.SqlClient.SqlParameter("@CodUsuario", System.Data.SqlDbType.Char)
        pa.Direction = System.Data.ParameterDirection.Input
        pa.Value = pCodUsuario
        da.SelectCommand.Parameters.Add(pa)
        Dim nReg As Integer = da.Fill(ds, "Usuario")

        If nReg = 0 Then
            ' no existe usuario
        Else

            da.SelectCommand = New System.Data.SqlClient.SqlCommand
            da.SelectCommand.Connection = cn
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            da.SelectCommand.CommandText = "SEG_PerfilLink_S"
            pa = New System.Data.SqlClient.SqlParameter("@CodPerfil", System.Data.SqlDbType.Char)
            pa.Direction = System.Data.ParameterDirection.Input
            pa.Value = ds.Tables(0).Rows(0)("CodPerfil")
            da.SelectCommand.Parameters.Add(pa)

            pa = New System.Data.SqlClient.SqlParameter("@CodSistema", System.Data.SqlDbType.Char)
            pa.Direction = System.Data.ParameterDirection.Input
            pa.Value = "GPT" 'Gestión programas de turismo
            da.SelectCommand.Parameters.Add(pa)
            nReg = da.Fill(ds, "Opciones")

            ' Carga las opciones en arreglo
            Dim I As Integer = 0
            Dim oDataRow As DataRow
            For Each oDataRow In ds.Tables(1).Rows
                I = I + 1
                arAutoriza(I).strName = oDataRow.Item(1)
                arAutoriza(I).strPage = oDataRow.Item(2)
            Next
        End If
        Return arAutoriza
    End Function

    Public Function AccesoOk(ByVal pCodPerfil As String, ByVal pCodFuncion As String) As String
        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

        Dim da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "SEG_ValidaPermiso_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@CodPerfil", System.Data.SqlDbType.Char).Value = pCodPerfil
        da.SelectCommand.Parameters.Add("@CodFuncion", System.Data.SqlDbType.Char).Value = pCodFuncion

        Dim ds As System.Data.DataSet = New System.Data.DataSet
        Dim nReg As Integer = da.Fill(ds, "Derechos")
        If nReg = 0 Then
            Return (" ")
        Else
            Return ("X")
        End If
    End Function

    Function AutorizaOpcion(ByVal pCodUsuario, ByVal pCodFuncion) As String
        Dim sMsg As String = ""

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "SEG_AutorizaOpcion_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = pCodUsuario
        cd.Parameters.Add("@CodFuncion", SqlDbType.Char, 15).Value = pCodFuncion
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            'Dim dr As SqlDataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "SEG_AutorizaOpcion_S", arParms)
            While dr.Read()
                sMsg = "OK"
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try
        Return (sMsg)
    End Function
End Class
