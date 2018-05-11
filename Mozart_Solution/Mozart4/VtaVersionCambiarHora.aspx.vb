Imports cmpNegocio
Imports cmpRutinas
Imports System.Drawing
Imports System.Data

Partial Class VtaVersionCambiarHora
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

            lblTitulo.Text = "Cambiar Hora del Servicio - Versión N° " & Viewstate("NroVersion")
            Dim wCodProveedor As Integer = objRutina.LeeParametroNumero("DefaultCodProveedor")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet
        ds = objVersionDet.CargaServiciosHotel(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        dgServicio.DataSource = ds
        dgServicio.DataBind()
        lblMsg.Text = CStr(dgServicio.Items.Count) + " Servicio(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        If lblNroDia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar el servicio que desea cambiar"
            Return
        End If

        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.NroDia = lblNroDia.Text
        objVersionDet.NroOrden = lblNroOrden.Text
        objVersionDet.NroServicio = lblNroServicioAnt.Text
        objVersionDet.HoraServicio = txtHoraServicio.Text
        objVersionDet.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objVersionDet.GrabarCambioHora
        If lblMsg.Text.Trim = "OK" Then
            lblNroDia.Text = ""
            lblNroOrden.Text = ""
            lblNroServicioAnt.Text = ""

            lblNomProveedor.Text = ""
            lblNomCiudad.Text = ""
            txtHoraServicio.Text = ""

            CargaData()
        End If
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        lblNroServicioAnt.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text
        lblCodProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text
        lblCodCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text
        'lblCodTipoAcomodacionAnt.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(13).Text

        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text

        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        txtHoraServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(5).Text.Trim

        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text
        '        lblCodTipoServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(15).Text

    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(14).Text.Trim = "Falta" Then
                e.Item.Cells(6).ForeColor = Color.Red
                e.Item.Cells(14).ForeColor = Color.Red
            End If

            If e.Item.Cells(9).Text.Trim = "OK" Then
                e.Item.Cells(9).ForeColor = Color.Blue
            Else
                e.Item.Cells(6).ForeColor = Color.Red
                e.Item.Cells(9).ForeColor = Color.Red
                e.Item.Cells(10).ForeColor = Color.Red
            End If
        End If
    End Sub


End Class
