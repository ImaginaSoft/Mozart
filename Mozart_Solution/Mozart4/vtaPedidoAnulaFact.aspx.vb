Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class vtaPedidoAnulaFact
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("Cliente") = Request.Params("Cliente")
            Viewstate("StsPedido") = Request.Params("StsPedido")
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "A" Then
                'Opcion=A : Anula facturacion dl pedido    
                lblTitulo.Text = "Anula Facturación del Pedido"
            Else
                'Opcion=C : Consulta penalidad por version Anulada
                lblTitulo.Text = "Consulta Penalidades por Version Anulada"
            End If

            CargaDocCliente()
            CargaDocProveedor()

            If Viewstate("StsPedido") = "C" Then
                lblMsg.Text = "Pedido ya esta cerrado , no se pude modificar"
                lblMsg.CssClass = "msg"
                cmdAnulaFact.Visible = False
            ElseIf (dgDCLIENTE.Items.Count = 0 And dgDPROVEEDOR.Items.Count = 0) Or Viewstate("Opcion") = "C" Then
                cmdAnulaFact.Visible = False
            End If
        End If
    End Sub

    Private Sub CargaDocCliente()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Viewstate("Opcion") = "A" Then
            lblSubtitCli.Text = " Documentos en el Cliente para Anular"
            da.SelectCommand.CommandText = "CPC_AnulaFactPedidDocCli_S"
        Else
            lblSubtitCli.Text = " Penalidad aplicadas al Cliente"
            da.SelectCommand.CommandText = "CPC_AnulaFactPedidoPenaCli_S" 'Consulta Penalidad
        End If
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "DCLIENTE")
        dgDCLIENTE.DataSource = ds
        dgDCLIENTE.DataBind()

        lblSubtitCli.Text = CStr(nReg) & lblSubtitCli.Text
    End Sub

    Private Sub CargaDocProveedor()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Viewstate("Opcion") = "A" Then
            lblSubTitPro.Text = " Documentos en el Proveedor para Anular"
            da.SelectCommand.CommandText = "CPC_AnulaFactPedidoDocPro_S"
        Else
            lblSubTitPro.Text = " Penalidad(es) aplicados por Proveedor"
            da.SelectCommand.CommandText = "CPC_AnulaFactPedidoPenaPro_S"
        End If

        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "DPROVEEDOR")
        dgDPROVEEDOR.DataSource = ds
        dgDPROVEEDOR.DataBind()

        lblSubTitPro.Text = CStr(nReg) & lblSubTitPro.Text
    End Sub


    Private Sub cmdAnulaFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnulaFact.Click
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPC_AnulaFactPedido_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPedidoFicha.aspx" & _
                              "?NroPedido=" & Viewstate("NroPedido") & _
                              "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Private Sub dgDCLIENTE_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDCLIENTE.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text >= 0 Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgDPROVEEDOR_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDPROVEEDOR.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text >= 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            Else
                e.Item.Cells(6).ForeColor = Color.Blue
            End If
        End If
    End Sub
End Class
