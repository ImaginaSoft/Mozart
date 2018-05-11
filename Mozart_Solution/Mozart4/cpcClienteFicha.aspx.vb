Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports cmpSeguridad
Imports System.Drawing
Partial Class cpcClienteFicha
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objCliente As New cmpNegocio.clsCliente
    Dim objPedido As New cmpNegocio.clsPedido
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Autorizado()
            If Len(Trim(Request.Params("CodCliente"))) > 0 Then
                ViewState("CodCliente") = Request.Params("CodCliente")
            Else
                ViewState("CodCliente") = Session("CodCliente")
            End If
            ViewState("TipoCliente") = objCliente.TipoCliente(ViewState("CodCliente"))
            'If ViewState("TipoCliente") = "A" Then  'Agencia
            'txtFchInicial.Text = objRutina.fechaddmmyyyy(-30)
            'txtFchFinal.Text = objRutina.fechaddmmyyyy(0)
            'End If
            CargaPedidos()
        End If
    End Sub

    Private Sub Autorizado()
        Dim objAutoriza As New clsAutoriza
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021005") = "OK" Then
            lbtRegistraPago.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021010") = "OK" Then
            lbtRegistraAbono.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021015") = "OK" Then
            lbtRegistraCargo.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021020") = "OK" Then
            lbtReembolso.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021025") = "OK" Then
            lbtDocumentos.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021030") = "OK" Then
            lbtNuevoCliente.Enabled = True
        End If
        If objAutoriza.AutorizaOpcion(Session("CodUsuario"), "GPT021035") = "OK" Then
            lbtContacto.Enabled = True
        End If
    End Sub

    Private Sub CargaPedidos()
        Dim ds As New DataSet
        'If ViewState("TipoCliente") = "P" Then  'Persona
        'cmdBuscar.Visible = False
        dgPedido.Columns(3).Visible = False
        dgPedido.Columns(4).Visible = False
        dgPedido.Columns(8).Visible = False
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PedidoCodCliente_S", New SqlParameter("@CodCliente", ViewState("CodCliente")))
        'Else
        'cmdBuscar.Visible = True
        'dgPedido.Columns(2).Visible = False
        'dgPedido.Columns(10).Visible = False
        'ds = objPedido.CargaxFchSolicita(ViewState("CodCliente"), objRutina.fechayyyymmdd(txtFchInicial.Text), objRutina.fechayyyymmdd(txtFchFinal.Text))
        'End If

        dgPedido.DataKeyField = "NroPedido"
        dgPedido.DataSource = ds.Tables(0)
        dgPedido.DataBind()
        lblMsg.Text = CStr(dgPedido.Items.Count) + " Pedido(s)"
    End Sub

    Private Sub lbtNuevoPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoPedido.Click
        If ucCliente1.CodCliente = 0 Then
            Response.Redirect("VtaPedidoRapido.aspx")
        Else
            Response.Redirect("VtaPedido.aspx" & _
                            "?CodCliente=" & ViewState("CodCliente"))
        End If
    End Sub

    Private Sub lbtActualizaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtActualizaCliente.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para actualizar sus datos"
            Return
        End If
        'http://localhost/Mozart4/comComprobanteCompras.aspx
        Response.Redirect("cpcClienteNuevoP.aspx" & _
                        "?Opcion=" & "A" & _
                        "&CodCliente=" & ViewState("CodCliente"))
    End Sub

    ' Editar Pedido
    Private Sub dgPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPedido.SelectedIndexChanged
        Response.Redirect("VtaPedidoFicha.aspx" & _
                          "?NroPedido=" & CInt(dgPedido.Items(dgPedido.SelectedIndex).Cells(1).Text) & _
                         "&CodCliente=" & ViewState("CodCliente"))
    End Sub

    Private Sub lbtVersiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtVersiones.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para ver Versiones"
            Return
        End If

        Response.Redirect("VtaClienteVersion.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente") & _
                        "&EmailCliente=" & ucCliente1.Email)
    End Sub

    Private Sub lblEliminarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEliminarCliente.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para eliminar"
            Return
        End If
        Response.Redirect("cpcClienteNuevoP.aspx" & _
                        "?Opcion=" & "E" & _
                        "&CodCliente=" & ViewState("CodCliente"))
    End Sub

    Private Sub lbtRegistraAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraAbono.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para registrar Nota Abono"
            Return
        End If

        Response.Redirect("cpcRegistraAbono.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente") & _
                        "&NroDocumento=0")
    End Sub

    Private Sub lbtRegistraPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraPago.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para registrar Pagos"
            Return
        End If

        Response.Redirect("cpcRegistraPago.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente") & _
                        "&NroDocumento=0")
    End Sub

    Private Sub lbtRegistraCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraCargo.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para registrar Nota Cargo"
            Return
        End If

        Response.Redirect("cpcRegistraCargo.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente"))

    End Sub

    Private Sub lbtCtacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCtacte.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para ver Ctacte"
            Return
        End If

        Response.Redirect("cpcCtacte.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente"))

    End Sub

    Private Sub lbtDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDocumentos.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para ver Documentosregistrar Nota Abono"
            Return
        End If

        Response.Redirect("cpcDocumento.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente"))

    End Sub

    Private Sub lbtNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoCliente.Click
        Response.Redirect("cpcClienteNuevoP.aspx" & _
                             "?Opcion=" & "N")
    End Sub

    Private Sub dgPedido_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedido.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(11).Text.Trim = "A" Then
                e.Item.Cells(7).ForeColor = Color.Gray
            Else
                e.Item.Cells(7).ForeColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub lbtReembolso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtReembolso.Click
        If ucCliente1.CodCliente = 0 Then
            lblMsg.Text = "Por favor elegir Cliente para registrar Reembolso"
            Return
        End If
        Response.Redirect("cpcRegistraReembolso.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente") & _
                        "&NroDocumento=0")
    End Sub

    'Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
    '    CargaPedidos()
    'End Sub

    Private Sub lbtContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtContacto.Click
        Response.Redirect("cpcClienteContacto.aspx" & _
                        "?CodCliente=" & ViewState("CodCliente") & _
                        "&NomCliente=" & ucCliente1.Nombre)
    End Sub


End Class
