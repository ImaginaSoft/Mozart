Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Class cpcMovtosTipoDoc
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ddlTipoSistema.Items.Insert(0, New ListItem("Banco"))
            ddlTipoSistema.Items.Insert(1, New ListItem("Cliente"))
            ddlTipoSistema.Items.Insert(2, New ListItem("Proveedor"))
            ddlTipoSistema.Items.FindByValue("Banco").Selected = True
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-29)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(0)
            CargaTipoDocumento("B")
        End If
    End Sub


    Private Sub CargaTipoDocumento(ByVal wTipoSistema As String)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "TAB_TipoDocumentoTipoSistema_S"
        da.SelectCommand.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = Trim(wTipoSistema)
        da.Fill(ds, "TipoDocumento")
        ddlTipoDocumento.DataSource = ds.Tables("TipoDocumento")
        ddlTipoDocumento.DataBind()
    End Sub

    Private Sub ddlTipoSistema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoSistema.SelectedIndexChanged
        Dim wTipoSistema, wDesSistema As String

        wDesSistema = CStr(ddlTipoSistema.SelectedItem.Value)

        If (wDesSistema.Equals("Banco")) Then
            wTipoSistema = "B"
        End If

        If (wDesSistema.Equals("Cliente")) Then
            wTipoSistema = "C"
        End If
        If (wDesSistema.Equals("Proveedor")) Then
            wTipoSistema = "P"
        End If

        CargaTipoDocumento(wTipoSistema)
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        If ddlTipoDocumento.Items.Count = 0 Then
            lblmsg.Text = "Elija un TipoDocumento"
            Return
        End If

        Dim da As New SqlDataAdapter
        Dim wtipodoc As String
        Dim wTipoSistema, wDesSistema As String

        wDesSistema = CStr(ddlTipoSistema.SelectedItem.Value)

        If (wDesSistema.Equals("Banco")) Then
            wTipoSistema = "B"
        End If

        If (wDesSistema.Equals("Cliente")) Then
            wTipoSistema = "C"
        End If
        If (wDesSistema.Equals("Proveedor")) Then
            wTipoSistema = "P"
        End If

        Dim ds As New DataSet
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        'escogemos el store procedure
        If (wDesSistema.Equals("Banco")) Then
            da.SelectCommand.CommandText = "CPC_MovtosxTipoDocumentoBanco_S"
        End If

        If (wDesSistema.Equals("Cliente")) Then
            da.SelectCommand.CommandText = "CPC_MovtosxTipoDocumentoCliente_S"
        End If
        If (wDesSistema.Equals("Proveedor")) Then
            da.SelectCommand.CommandText = "CPC_MovtosxTipoDocumentoProveedor_S"
        End If


        da.SelectCommand.Parameters.Add("@TipoDocumento", SqlDbType.Char, 2).Value = CStr(ddlTipoDocumento.SelectedItem.Value)
        da.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)

        Dim nReg As Integer = da.Fill(ds, "Movtos")
        dgMovimientos.DataSource = ds.Tables("Movtos")
        dgMovimientos.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub dgMovimientos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgMovimientos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text.Trim = "Anulado" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

End Class
