Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaPropuestaReserva
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
            lbltitulo.Text = "Reserva de Servicios Propuesta N° " & Viewstate("NroPropuesta")
            CargaProveedor()
        End If

    End Sub

    Private Sub CargaProveedor()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PropuestaProveedor_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")

        Dim nReg As Integer = da.Fill(ds, "Proveedor")
        dgProveedor.DataSource = ds.Tables("Proveedor")
        dgProveedor.DataBind()
        dgProveedor.Columns(0).Visible = False
        dgProveedor.Columns(5).Visible = False
    End Sub


    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub dgProveedor_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProveedor.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(8).Text.Trim = "OK" Then
                e.Item.Cells(8).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
                e.Item.Cells(7).ForeColor = Color.Red
                e.Item.Cells(8).ForeColor = Color.Red
            End If

            If e.Item.Cells(1).Text.Trim <> "92" Then
                e.Item.Cells(0).Text = ""
                e.Item.Cells(5).Text = ""
            End If
        End If
    End Sub


End Class
