Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsCliente
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function CargarCtacte(ByVal pCodCliente As Integer, ByVal pCodMoneda As String, ByVal pFecha As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodCliente", SqlDbType.Int)
        arParms(0).Value = pCodCliente
        arParms(1) = New SqlParameter("@CodMoneda", SqlDbType.Char, 1)
        arParms(1).Value = pCodMoneda
        arParms(2) = New SqlParameter("@Fecha", SqlDbType.Char, 8)
        arParms(2).Value = pFecha
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_CtaCte_S", arParms)
        Return (ds)
    End Function

    Function CargarCliente(ByVal pOpcion As String, ByVal pTrama As String) As DataSet
        Dim ds As New DataSet
        If pOpcion = "A" Then ' Apellidos y Nombres del Cliente
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClienteNomCliente_S", New SqlParameter("@NomCliente", pTrama))
        ElseIf pOpcion = "E" Then ' Email del Cliente
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClientexEmail_S", New SqlParameter("@Email", pTrama))
        ElseIf pOpcion = "P" Then ' Nombre del Pasajero
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClientexNomPajero_S", New SqlParameter("@NomPasajero", pTrama))
        ElseIf pOpcion = "T" Then ' Telefono
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClientexTelefono_S", New SqlParameter("@Telefono", pTrama))
        Else ' CodCliente
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ClientexCodCliente_S", New SqlParameter("@CodCliente", pTrama))
        End If
        Return (ds)
    End Function

    Function TipoCliente(ByVal pCodCliente As Integer) As String
        Dim sTipoCliente As String = ""

        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand()
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "cpc_ClienteCodCliente_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = pCodCliente
        Try
            cn.Open()
            dr = cd.ExecuteReader()
            While dr.Read()
                sTipoCliente = dr.GetValue(dr.GetOrdinal("TipoCliente"))
            End While
            dr.Close()
        Finally
            cn.Close()
        End Try

        Return (sTipoCliente)
    End Function
End Class
