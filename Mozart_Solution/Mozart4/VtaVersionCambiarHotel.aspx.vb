Imports cmpNegocio
Imports cmpRutinas
Imports System.Drawing
Imports System.Data

Partial Class VtaVersionCambiarHotel
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim objVersionDet As New clsVersionDet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Cambiar Nombre del Servicio - Versión N° " & ViewState("NroVersion")
            Dim wCodProveedor As Integer = objRutina.LeeParametroNumero("DefaultCodProveedor")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim ds As New DataSet
        ds = objVersionDet.CargaServiciosHotel(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        'dgServicio.DataKeyField = "KeyReg"
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
        If ddlServicio.Items.Count() = 0 Then
            lblMsg.Text = "Seleccione Servicio"
            Return
        End If

        If ddlTipoAcomodacion.Items.Count() = 0 Then
            objVersionDet.CodTipoAcomodacion = 0
        Else
            objVersionDet.CodTipoAcomodacion = ddlTipoAcomodacion.SelectedItem.Value
        End If
        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.NroDia = lblNroDia.Text
        objVersionDet.NroOrden = lblNroOrden.Text
        objVersionDet.NroSerAnt = lblNroServicioAnt.Text
        objVersionDet.CodTipoAcomAnt = lblCodTipoAcomodacionAnt.Text
        objVersionDet.NroServicio = ddlServicio.SelectedItem.Value
        objVersionDet.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objVersionDet.GrabarCambioHotel
        If lblMsg.Text.Trim = "OK" Then
            lblNroDia.Text = ""
            lblNroOrden.Text = ""
            lblNroServicioAnt.Text = ""
            lblCodProveedor.Text = ""
            lblCodCiudad.Text = ""
            lblCodTipoAcomodacionAnt.Text = ""

            lblNomProveedor.Text = ""
            lblNomCiudad.Text = ""
            ddlServicio.Items.Clear()
            ddlTipoAcomodacion.Items.Clear()

            CargaData()
        End If
    End Sub

    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged
        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        lblNroServicioAnt.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text
        lblCodProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(10).Text
        lblCodCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(11).Text
        lblCodTipoAcomodacionAnt.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(12).Text

        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(7).Text
        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(5).Text
        lblCodTipoServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(14).Text

        CargaServicio()
        CargaTipoAcomodacion()
    End Sub

    Private Sub CargaServicio()
        Dim objProveedor As New clsProveedor
        Dim ds As New DataSet
        ds = objProveedor.CargaServicio(lblCodProveedor.Text, lblCodCiudad.Text, lblCodTipoServicio.Text)
        ddlServicio.DataSource = ds
        ddlServicio.DataBind()
        Try
            ddlServicio.Items.FindByValue(lblNroServicioAnt.Text).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub CargaTipoAcomodacion()
        Dim objServicio As New clsServicio
        Dim ds As New DataSet
        ds = objServicio.CargaTipoAcomodacion(ddlServicio.SelectedValue)
        ddlTipoAcomodacion.DataSource = ds
        ddlTipoAcomodacion.DataBind()
        Try
            ddlTipoAcomodacion.Items.FindByValue(lblCodTipoAcomodacionAnt.Text).Selected = True
        Catch ex2 As System.Exception
            'No existe ...continuar
        End Try
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        CargaTipoAcomodacion()
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
            If e.Item.Cells(13).Text.Trim = "Falta" Then
                e.Item.Cells(5).ForeColor = Color.Red
                e.Item.Cells(13).ForeColor = Color.Red
            End If

            If e.Item.Cells(8).Text.Trim = "OK" Then
                e.Item.Cells(8).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
                e.Item.Cells(8).ForeColor = Color.Red
                e.Item.Cells(9).ForeColor = Color.Red
            End If
        End If
    End Sub

End Class
