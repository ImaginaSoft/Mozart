
Imports cmpTabla
Imports cmpNegocio
Partial Class cpcEnvioKitObs
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objPedido As New clsPedido

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("Opc") = Request.Params("Opc") 'E=Envio Kit C=Confirma envio kit
            lblNroPedido.Text = Request.Params("NroPedido")
            lblnomcliente.Text = Request.Params("NomCliente")
            lblDireccion.Text = Request.Params("Direccion")
            lblCiudad.Text = Request.Params("Ciudad")
            txtObsEnvioKit.Text = Request.Params("ObsEnvioKit")
            CargaStsEnvio()

        End If
    End Sub
    Private Sub CargaStsEnvio()
        Dim objTablaElemento As New clsTablaElemento
        ddlStsEnvio.DataSource = objTablaElemento.CargaTablaElexCodEle(15, "E")
        ddlStsEnvio.DataBind()
        Try
            ddlStsEnvio.Items.FindByValue(Request.Params("StsEnvioKit")).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblmsg.Text = objPedido.ActualizaObsEnvioKit(lblNroPedido.Text, txtObsEnvioKit.Text, ddlStsEnvio.SelectedValue, Session("CodUsuario"))
        If lblmsg.Text.Trim = "OK" Then
            If Viewstate("Opc") = "E" Then
                Response.Redirect("cpcEnvioKit.aspx")
            Else
                Response.Redirect("cpcEnvioKitConfirma.aspx")
            End If
        End If
    End Sub

End Class
