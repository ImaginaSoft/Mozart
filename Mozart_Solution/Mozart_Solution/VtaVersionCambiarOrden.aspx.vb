Imports cmpNegocio
Imports cmpRutinas
Imports System.Data


Partial Class VtaVersionCambiarOrden
    Inherits System.Web.UI.Page

    Dim objRutina As New clsRutinas
    Dim objVersionDet As New clsVersionDet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")
            lblTitulo.Text = "Cambiar Orden de Servicios - Versión N° " & Viewstate("NroVersion")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet
        ds = objVersionDet.CargaServicios(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        dgServicio.DataSource = ds
        dgServicio.DataBind()
        lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        If lblNroDia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar el hotel que desea cambiar"
            Return
        End If
        If Textdia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Dia es dato obligatorio"
            Return
        Else
            If Not IsNumeric(Textdia.Text) Then
                lblMsg.Text = "Error: Dia es dato númerico"
                Return
            End If
        End If

        If Textorden.Text.Trim.Length = 0 Then
            lblMsg.Text = "Error: Orden es dato obligatorio"
            Return
        Else
            If Not IsNumeric(Textorden.Text) Then
                lblMsg.Text = "Error: Orden es dato númerico"
                Return
            End If
        End If

        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.NroDiaAnt = lblNroDia.Text
        objVersionDet.NroOrdAnt = lblNroOrden.Text
        objVersionDet.HoraServicio = txtHoraServicio.Text
        objVersionDet.NroServicio = lblNroServicio.Text
        objVersionDet.NroDia = Textdia.Text
        objVersionDet.NroOrden = Textorden.Text
        objVersionDet.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objVersionDet.GrabarCambioOrden
        If lblMsg.Text.Trim = "OK" Then
            Textdia.Text = ""
            Textorden.Text = ""
            txtHoraServicio.Text = ""

            lblNroDia.Text = ""
            lblNroOrden.Text = ""
            lblNroServicio.Text = ""
            lblNomProveedor.Text = ""
            lblNomCiudad.Text = ""
            lblDesProveedor.Text = ""
            CargaData()
        End If
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        lblNroServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text
        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(7).Text
        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(5).Text
        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        txtHoraServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text.Trim
    End Sub


    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub


End Class
