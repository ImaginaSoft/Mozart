Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports cmpRutinas
Imports System.Drawing

Partial Class VtaVersionHistorial
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            lblTitulo.Text = "Historial del Pedido"

            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_PedidoHistorial_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Viewstate("NroPedido"))

        Dim nReg As Integer = da.Fill(ds, "Log")
        dgHistorial.DataSource = ds.Tables("Log")
        dgHistorial.DataBind()
        lblMsg.Text = CStr(nReg) + " Registros(s) encontrado(s)"
    End Sub
    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblMsg.Text = ""
        Dim wTipoMsg As String = "L"
        If rbtEntrada.Checked Then
            wTipoMsg = "E"
        ElseIf rbtSalida.Checked Then
            wTipoMsg = "S"
        End If

        Dim objRutina As New clsRutinas

        lblMsg.Text = objRutina.GrabaHistorial(Trim(txtDesLog.Text), _
               Viewstate("CodCliente"), Viewstate("NroPedido"), _
               Viewstate("NroPropuesta"), Viewstate("NroVersion"), "1", wTipoMsg, Session("CodUsuario"))
        If lblMsg.Text = "OK" Then
            Response.Redirect("VtaVersionHistorial.aspx" & _
                     "?CodCliente=" & Viewstate("CodCliente") & _
                     "&NroPedido=" & Viewstate("NroPedido") & _
                     "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                     "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub


    Private Sub dgHistorial_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgHistorial.ItemDataBound
        If e.Item.Cells(2).Text = "1" Then '1 = Registro manual interno (color negro)
            '            e.Item.ForeColor = Color.DarkGray
        ElseIf e.Item.Cells(2).Text = "2" Then             '2 = Registro manual externo  con E-mail  (color negro)
            e.Item.BackColor = Color.LightYellow
            e.Item.ForeColor = Color.Blue
        ElseIf e.Item.Cells(2).Text = "3" Or _
               e.Item.Cells(2).Text = "7" Then             '3 = Registro automático externo Web Cliente (color azul)
            e.Item.BackColor = Color.LightCyan             '7 = Registro automático externo Web Cliente leido por el vendedor
            e.Item.ForeColor = Color.Blue
        ElseIf e.Item.Cells(2).Text = "4" Then             '4 = Registro automático del sistema (negro bajo)
            '                        e.Item.ForeColor = Color.Gray
        End If
    End Sub


End Class
