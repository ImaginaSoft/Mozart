Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Drawing

Partial Class vtaPedidoAnulaFactVersion
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView
    Dim dTotalCliente As Double
    Dim dTotalProveedor As Double
    Dim sTotal, sCodProveedor, sIdReg As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("Cliente") = Request.Params("Cliente")
            Viewstate("StsPedido") = Request.Params("StsPedido")
            Viewstate("Opcion") = Request.Params("Opcion")

            CargaDocCliente()
            CargaDocProveedor()
            CargaBoleto()
            CargaProveedorPenalidad()
            Titulo()

            If Viewstate("StsPedido") = "C" Then
                lblMsg.Text = "Pedido ya esta cerrado , no se pude modificar"
                lblMsg.CssClass = "msg"
                cmdAnulaFact.Enabled = False
            ElseIf dgProveedor.Items.Count = 0 Then
                cmdAnulaFact.Visible = False
            End If
        End If
    End Sub

    Private Sub Titulo()
        If Viewstate("Opcion") = "M" Then
            lblTitulo.Text = "Anula Facturación Mes actual de Ventas"
            lblAcciones1.Text = "1. Anula deuda del cliente <br>" & _
                                "2. Anula deuda con los proveedores <br>" & _
                                "3. Estado del pedido pasa Anulado <br>" & _
                                "4. Se elimina las visitas de entrada y salida <br>" & _
                                "5. Los Boletos pasan al Stock de Comprados <br>"
            lblAcciones2.Text = "6. En la Versión <br>" & _
                               "&nbsp;&nbsp;&nbsp;-&nbsp;Las penalidades se asocia a la versión <br>" & _
                               "&nbsp;&nbsp;&nbsp;-&nbsp;Estado de la versión pasa con Penalidad <br>" & _
                               "&nbsp;&nbsp;&nbsp;-&nbsp;Anula la tareas pendientes <br>"
        Else
            lblTitulo.Text = "Anula Facturación Meses Anteriores de Ventas"
            lblAcciones1.Text = "1. Anula deuda del cliente <br>" & _
                                "2. Anula deuda con los proveedores <br>" & _
                                "3. Estado del pedido pasa Anulado <br>" & _
                                "4. Se elimina las visitas de entrada y salida <br>" & _
                                "5. Los Boletos pasan al Stock de Comprados <br>"
            lblAcciones2.Text = "6. En la Versión <br>" & _
                                "&nbsp;&nbsp;&nbsp;-&nbsp;La utilidad se convertira en negativo <br>" & _
                                "&nbsp;&nbsp;&nbsp;-&nbsp;Las penalidades se asocia a la versión <br>" & _
                                "&nbsp;&nbsp;&nbsp;-&nbsp;Estado de la versión pasa Anulado <br>" & _
                                "&nbsp;&nbsp;&nbsp;-&nbsp;Anula la tareas pendientes <br>"
        End If

    End Sub
    Private Sub CargaDocCliente()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_AnulaFactPedidDocCli_S", New SqlParameter("@NroPedido", Viewstate("NroPedido")))
        dgDCLIENTE.DataSource = ds
        dgDCLIENTE.DataBind()
        lblSubtitCli.Text = CStr(dgDCLIENTE.Items.Count) & " Documentos en el Cliente para anular"
    End Sub

    Private Sub CargaDocProveedor()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_AnulaFactPedidoDocPro_S", New SqlParameter("@NroPedido", Viewstate("NroPedido")))
        dgDPROVEEDOR.DataSource = ds
        dgDPROVEEDOR.DataBind()
        lblSubTitPro.Text = CStr(dgDPROVEEDOR.Items.Count) & " Documentos en el Proveedor para Anular"
    End Sub

    Private Sub CargaBoleto()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_AnulaFactPedidoBoleto_S", New SqlParameter("@NroPedido", Viewstate("NroPedido")))
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBoleto.DataSource = dv
        dgBoleto.DataBind()
        lblSubTitBoletos.Text = CStr(dgBoleto.Items.Count) & "  Boletos que pasaran al stock de comprados"
    End Sub

    Private Sub CargaProveedorPenalidad()
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "CPC_AnulaFactPedidoProveedor_S", New SqlParameter("@NroPedido", Viewstate("NroPedido")))
        dgProveedor.DataSource = ds
        dgProveedor.DataBind()
    End Sub

    Private Sub cmdAnulaFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnulaFact.Click
        If txtTotal.Text.Trim.Length = 0 Then
            dTotalCliente = 0
        ElseIf IsNumeric(txtTotal.Text) Then
            dTotalCliente = CDbl(txtTotal.Text)
        Else
            lblMsg.Text = "Error, total penalidad cliente es dato númerico"
            Return
        End If

        Dim RegError As Integer = 0
        Dim objItem As DataGridItem

        Dim wFchSys As Date = objRutina.FchSys
        sIdReg = ToString.Format("{0:yyyyMMdd}", wFchSys) + " " + ToString.Format("{0:hh:mm:ss}", wFchSys) + Mid(Session("CodUsuario"), 1, 8)

        dTotalProveedor = 0
        lblMsg.Text = ""
        For Each objItem In dgProveedor.Items
            If objItem.ItemType <> ListItemType.Header And objItem.ItemType <> ListItemType.Footer And objItem.ItemType <> ListItemType.Pager Then
                sTotal = CType(objItem.Cells(2).FindControl("txtTotal"), TextBox).Text.Trim
                sCodProveedor = dgProveedor.DataKeys(objItem.ItemIndex).ToString()
                If sTotal.Trim.Length = 0 Then
                    'OK
                ElseIf IsNumeric(sTotal) Then
                    If CDbl(sTotal) >= 0 Then
                        'OK
                        dTotalProveedor = dTotalProveedor + CDbl(sTotal)
                    Else
                        lblMsg.Text = lblMsg.Text & "Error en Proveedor " & sCodProveedor & " Total debe ser positivo <br>"
                    End If
                Else
                    lblMsg.Text = lblMsg.Text & "Error en Proveedor " & sCodProveedor & " Total debe ser númerico <br>"
                End If
            End If
        Next

        If lblMsg.Text.Trim.Length > 0 Then
            Return
        End If

        'Redondeo a 2 decimales para comparar
        dTotalProveedor = Math.Round(dTotalProveedor, 2)

        If dTotalProveedor <> dTotalCliente Then
            lblMsg.Text = "Error, total penalidad proveedor debe ser igual al Total penalidad cliente "
            Return
        End If

        For Each objItem In dgProveedor.Items
            If objItem.ItemType <> ListItemType.Header And objItem.ItemType <> ListItemType.Footer And objItem.ItemType <> ListItemType.Pager Then
                sTotal = CType(objItem.Cells(2).FindControl("txtTotal"), TextBox).Text.Trim
                sCodProveedor = dgProveedor.DataKeys(objItem.ItemIndex).ToString()
                If sTotal.Trim.Length > 0 Then ' no blanco
                    If sTotal > 0 Then ' monto > 0
                        Dim cd As New SqlCommand
                        cd.Connection = cn
                        cd.CommandText = "CPC_AnulaFactPedidoVersion1_I"
                        cd.CommandType = CommandType.StoredProcedure

                        Dim pa As New SqlParameter
                        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
                        pa.Direction = ParameterDirection.Output
                        pa.Value = ""
                        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
                        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
                        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = dgProveedor.DataKeys(objItem.ItemIndex).ToString()
                        cd.Parameters.Add("@Total", SqlDbType.Money).Value = sTotal
                        Try
                            cn.Open()
                            cd.ExecuteNonQuery()
                            lblMsg.Text = cd.Parameters("@MsgTrans").Value
                        Catch ex1 As System.Data.SqlClient.SqlException
                            lblMsg.Text = "Error:" & ex1.Message
                        Catch ex2 As System.Exception
                            lblMsg.Text = "Error:" & ex2.Message
                        End Try
                        cn.Close()
                        If lblMsg.Text.Trim <> "OK" Then
                            Return
                        End If
                    End If
                End If
            End If
        Next

        'Inicia Anulacion de la Facturacion del Pedido
        AnulaFactPedido()
    End Sub

    Private Sub AnulaFactPedido()
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandType = CommandType.StoredProcedure
        If viewstate("Opcion") = "V" Then ' Anula fact. version meses anteriores
            cd.CommandText = "CPC_AnulaFactPedidoVersion2_U"
        Else                              ' Anula fact.version mes actual ventas  
            cd.CommandText = "CPC_AnulaFactPedidoVersion3_U"
        End If

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@IdReg", SqlDbType.Char, 25).Value = sIdReg
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = txtReferencia.Text
        cd.Parameters.Add("@TotalCliente", SqlDbType.Money).Value = dTotalCliente
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
            Response.Redirect("cpcClienteFicha.aspx" & _
                              "?CodCliente=" & Viewstate("CodCliente"))
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
