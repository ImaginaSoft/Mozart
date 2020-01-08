Imports cmpTabla
Imports cmpNegocio
Imports System.Data

Partial Class VtaVersionReservaConfirma
    Inherits System.Web.UI.Page
    Dim objSolicita As New clsSolicita
    Dim objVersionDet As New clsVersionDet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not IsPostBack Then
            lblTitulo.Text = "Confirmación al Proveedor " & Request.Params("NomProveedor")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodContacto") = Request.Params("CodContacto")
            CargaSolicita()
        End If
    End Sub

    Private Sub CargaSolicita()
        Dim ds As New DataSet
        ds = objSolicita.Cargar
        ddlSolicita.DataSource = ds
        ddlSolicita.DataBind()
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.CodProveedor = Viewstate("CodProveedor")
        objVersionDet.CodSolicita = ddlSolicita.SelectedItem.Value
        objVersionDet.CodUsuario = Session("CodUsuario")
        lblmsg.Text = objVersionDet.GrabarCambioStsReserva
        If lblmsg.Text.Trim = "OK" Then
            Response.Redirect("VtaVersionReserva.aspx" & _
                       "?NroPedido=" & Viewstate("NroPedido") & _
                       "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                       "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

End Class
