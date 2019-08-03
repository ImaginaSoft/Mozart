Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsProveedor
    Private cn As String = System.Configuration.ConfigurationManager.AppSettings("cnMozart")

    Function CargarActivo() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "TAB_ProveedorActivo_S")
        Return (ds)
    End Function

    Function CargarActivoDDL() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedorActivo_S")
        Return (ds)
    End Function

    Function CargarProveedor(ByVal pCodProveedor As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedorCodProveedor_S", New SqlParameter("@CodProveedor", pCodProveedor))
        Return (ds)
    End Function


    Function CargaProveedores() As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedorServicio_S")
        Return (ds)
    End Function

    Function CargaProveedoresActivosxCiudad(ByVal pCodCiudad As String, ByVal pTipoServicio As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(0).Value = pCodCiudad
        arParms(1) = New SqlParameter("@TipoServicio", SqlDbType.Int)
        arParms(1).Value = pTipoServicio
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ProveedoresActivosxCiudad_S", arParms)
        Return (ds)
    End Function


    Function CargaCiudad(ByVal pCodProveedor As Integer) As DataSet
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_CiudadxProveedor_S", New SqlParameter("@CodProveedor", pCodProveedor))
        Return (ds)
    End Function

    Function CargaTipoServicio(ByVal pCodProveedor As Integer, ByVal pCodCiudad As String) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_TipoServicioxCiudad_S", arParms)
        Return (ds)
    End Function

    Function CargaServicio(ByVal pCodProveedor As Integer, ByVal pCodCiudad As String, ByVal pCodTipoServicio As Integer) As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@CodProveedor", SqlDbType.Int)
        arParms(0).Value = pCodProveedor
        arParms(1) = New SqlParameter("@CodCiudad", SqlDbType.Char, 10)
        arParms(1).Value = pCodCiudad
        arParms(2) = New SqlParameter("@CodTipoServicio", SqlDbType.Int)
        arParms(2).Value = pCodTipoServicio
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_ServicioActivoxCodTipoServicio_S", arParms)
        Return (ds)
    End Function

End Class
