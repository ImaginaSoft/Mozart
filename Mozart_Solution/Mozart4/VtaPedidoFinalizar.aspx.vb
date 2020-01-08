Imports cmpNegocio
Imports cmpTabla
Imports System.Data

Partial Class VtaPedidoFinalizar
    Inherits System.Web.UI.Page
    Dim objPedido As New clsPedido
    Dim objIdioma As New clsIdioma

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            EditaPedido()
        End If
    End Sub

    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
        If pIdioma.Trim.Length > 0 Then
            Try
                ddlIdioma.Items.FindByValue(pIdioma).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub EditaPedido()
        objPedido.NroPedido = Viewstate("NroPedido")
        lblMsg.Text = objPedido.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblNroPedido.Text = objPedido.NroPedido
            lblDesPedido.Text = objPedido.DesPedido
            lblfchPedido.Text = ToString.Format("{0:dd-MM-yyyy}", objPedido.FchPedido)
            lblVendedor.Text = objPedido.NomVendedor
            lblCodStsPedido.Text = objPedido.StsPedido
            If IsDate(objPedido.FechaUltEnvio) And Year(objPedido.FechaUltEnvio) > 1900 Then
                txtFchUltEnvio.Text = ToString.Format("{0:dd-MM-yyyy}", CDate(objPedido.FechaUltEnvio))
            Else
                txtFchUltEnvio.Text = ""
            End If

            If objPedido.StsPedido = "S" Then
                rbtSolicitado.Checked = True
            ElseIf objPedido.StsPedido = "N" Then
                rbtNegociacion.Checked = True
            ElseIf objPedido.StsPedido = "V" Then
                rbtVendido.Checked = True
                ' Vendido ya no se puede modificar
                cmdGrabar.Enabled = False
            ElseIf objPedido.StsPedido = "C" Then
                rbtCerrado.Checked = True
                ' Cerrado ya no se puede modificar
                cmdGrabar.Enabled = False
            ElseIf objPedido.StsPedido = "A" Then
                rbtAnulado.Checked = True
                lblmotivo.Visible = True
                ddlMotivo.Visible = True
            End If

            'Idioma del recordatorio}
            CargaIdioma(objPedido.Idioma)

            If objPedido.NroRecordatorio = 0 Then
                txtNroRecordatorio.Text = ""
            Else
                txtNroRecordatorio.Text = objPedido.NroRecordatorio
            End If
            CargaMotivo(objPedido.CodMotivo)
        End If
    End Sub

    Private Sub CargaMotivo(ByVal pCodMotivo As Integer)
        Dim objMotivo As New clsMotivo
        Dim ds As New DataSet
        ds = objMotivo.Cargar
        ddlMotivo.DataSource = ds
        ddlMotivo.DataBind()
        If pCodMotivo > 0 Then
            ddlMotivo.Items.FindByValue(pCodMotivo).Selected = True
        End If
    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objPedido.Idioma = ddlIdioma.SelectedValue

        objPedido.CodMotivo = 0
        If rbtSolicitado.Checked Then
            objPedido.StsPedido = "S"
        ElseIf rbtNegociacion.Checked Then
            objPedido.StsPedido = "N"
        ElseIf rbtAnulado.Checked Then
            objPedido.StsPedido = "A"
            If ddlMotivo.Items.Count > 0 Then
                objPedido.CodMotivo = ddlMotivo.SelectedItem.Value
            End If
        Else
            lblMsg.Text = "Error: No esta permitido cambiar a VENDIDO o CERRADO"
            Return
        End If

        objPedido.CodCliente = ViewState("CodCliente")
        objPedido.NroPedido = ViewState("NroPedido")
        objPedido.NroRecordatorio = txtNroRecordatorio.Text
        objPedido.FchUltEnvio = txtFchUltEnvio.Text
        objPedido.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPedido.GrabarStsPedido
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("cpcClienteFicha.aspx" & _
                              "?CodCliente=" & ViewState("CodCliente"))
        End If
    End Sub

    Private Sub rbtAnulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAnulado.CheckedChanged
        lblmotivo.Visible = True
        ddlMotivo.Visible = True
    End Sub

    Private Sub rbtNegociacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNegociacion.CheckedChanged
        lblmotivo.Visible = False
        ddlMotivo.Visible = False
    End Sub

    Private Sub rbtSolicitado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSolicitado.CheckedChanged
        lblmotivo.Visible = False
        ddlMotivo.Visible = False
    End Sub

End Class
