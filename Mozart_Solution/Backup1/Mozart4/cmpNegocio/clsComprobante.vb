
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpRutinas

Public Class clsComprobante

    Dim cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")
    Dim sMsg As String

    Function MesDeclarado(ByVal pTipoSistema As String, ByVal pAno As String, ByVal pMes As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@TipoSistema", SqlDbType.Char, 1)
        arParms(0).Value = pTipoSistema
        arParms(1) = New SqlParameter("@AnoDeclara", SqlDbType.Char, 4)
        arParms(1).Value = pAno
        arParms(2) = New SqlParameter("@MesDeclara", SqlDbType.Char, 2)
        arParms(2).Value = pMes
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "COM_ComprobanteMes_S", arParms)
        Return (ds)
    End Function


    Function Borrar(ByVal pCorrelativo As Integer, ByVal pAno As String, ByVal pMes As String, ByVal pCodUsuario As String) As String
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_Comprobante_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = pCorrelativo
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = pAno
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = pMes
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


    Function CierreMes(ByVal pAno As String, ByVal pMes As String) As Boolean
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_CierreMesProcesado_S"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@AnoDeclara", SqlDbType.Char, 4).Value = pAno
        cd.Parameters.Add("@MesDeclara", SqlDbType.Char, 2).Value = pMes
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            If cd.Parameters("@NroDocs").Value > 0 Then
                Return (True)
            End If
        Catch ex1 As System.Data.SqlClient.SqlException
            sMsg = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            sMsg = "Error:" & ex2.Message
        End Try
        Return (False)
    End Function

    Function CompxNroLiqCom(ByVal pTipoSistema As String, ByVal pNroLiqCom As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@TipoSistema", SqlDbType.Char, 1)
        arParms(0).Value = pTipoSistema
        arParms(1) = New SqlParameter("@NroLiqCom", SqlDbType.Int)
        arParms(1).Value = pNroLiqCom
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "COM_ComprobanteNroLiqCom_S", arParms)
        Return (ds)
    End Function

End Class