Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionReserva
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim sSistema As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodCliente") = Request.Params("CodCliente")

            lbltitulo.Text = "Reserva Servicios Versión N° " & Viewstate("NroVersion")
            CargaProveedor()
        End If
    End Sub


    Private Sub CargaProveedor()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionProveedor_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Proveedor")
        dgProveedor.DataSource = ds.Tables("Proveedor")
        dgProveedor.DataBind()
        '       lblMsg.Text = CStr(nReg) + " Registros(s) encontrado(s)"
    End Sub

    Private Sub dgProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgProveedor.SelectedIndexChanged
        Response.Redirect("VtaVersionReservaEmail.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                "&NroVersion=" & Viewstate("NroVersion") & _
                "&CodProveedor=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text & _
                "&NomProveedor=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(2).Text & _
                "&CodContacto=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(14).Text)
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))

    End Sub

    Private Sub dgProveedor_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProveedor.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(9).Text.Trim = "OK" Then
                e.Item.Cells(9).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
                e.Item.Cells(8).ForeColor = Color.Red
                e.Item.Cells(9).ForeColor = Color.Red
            End If
        End If
    End Sub


End Class
