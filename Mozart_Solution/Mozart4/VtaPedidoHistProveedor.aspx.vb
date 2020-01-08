Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports System.Drawing

Partial Class VtaPedidoHistProveedor
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("opcion") = Request.Params("opcion")

            If Viewstate("opcion") = 1 Then
                lblTitulo.Text = "Historial de todos los Proveedores"
                Viewstate("CodProveedor") = 0
            Else
                lblTitulo.Text = "Historial con " & Request.Params("NomProveedor")
                Viewstate("CodProveedor") = Request.Params("CodProveedor")
            End If

            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Viewstate("opcion") = 1 Then
            da.SelectCommand.CommandText = "VTA_PedidoHistProveedor_S"
            da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        Else
            da.SelectCommand.CommandText = "VTA_PedidoHistCodProveedor_S"
            da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
            da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        End If

        Dim nReg As Integer = da.Fill(ds, "Log")
        dgHistorial.DataSource = ds.Tables("Log")
        dgHistorial.DataBind()
        lblMsg.Text = CStr(nReg) + " Registro(s)"
    End Sub


    Private Sub dgHistorial_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgHistorial.ItemDataBound
        If e.Item.Cells(2).Text = "1" Then '1 = Registro manual interno (color negro)
            '            e.Item.ForeColor = Color.DarkGray
        ElseIf e.Item.Cells(2).Text = "2" Then   '2 = Registro manual externo  con E-mail  (color negro)
            e.Item.BackColor = Color.LightYellow
            e.Item.ForeColor = Color.Blue
        ElseIf e.Item.Cells(2).Text = "3" Then   '3 = Registro automático externo Web Cliente (color azul)
            e.Item.BackColor = Color.LightCyan
            e.Item.ForeColor = Color.Blue
        ElseIf e.Item.Cells(2).Text = "4" Then   '4 = Registro automático del sistema (negro bajo)
            '                        e.Item.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        Dim objRutina As New clsRutinas

        lblMsg.Text = objRutina.GrabaLogProveedor(Trim(FreeTextBox1.Text), _
               ViewState("CodProveedor"), ViewState("NroPedido"), _
               0, 0, "1", Session("CodUsuario"))
        '        If lblMsg.Text = "OK" Then
        Response.Redirect("VtaPedidoHistProveedor.aspx" & _
                 "?CodCliente=" & Viewstate("CodCliente") & _
                 "&NroPedido=" & Viewstate("NroPedido") & _
                 "&CodProveedor=" & Viewstate("CodProveedor") & _
                 "&opcion=" & Viewstate("opcion"))

        '       End If

    End Sub

End Class
