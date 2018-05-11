Imports cmpNegocio
Imports cmpTabla
Imports System.Drawing
Imports System.Data

Partial Class VtaVersionHotelReserva
    Inherits System.Web.UI.Page

    Dim objVersionDet As New clsVersionDet
    Dim objStsReserva As New clsStsReserva
    Dim objProveedor As New clsProveedor
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("FlagPublica") = Request.Params("FlagPublica")
            Viewstate("StsVersion") = Request.Params("StsVersion")
            Viewstate("DesVersion") = Request.Params("DesVersion")
            Viewstate("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Estado Reserva de Hoteles - Versión N° " & Viewstate("NroVersion")
            CargaVersionLink()

            If Viewstate("FlagEdita") = "N" Then
                cmdGrabar.Visible = False
                dgLink.Columns(0).Visible = False
                lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar"
                lblMsg.CssClass = "msg"
                Return
            End If
        End If
    End Sub

    Private Sub CargaVersionLink()
        Dim ds As New DataSet
        ds = objVersionDet.CargarHotel(Viewstate("NroPedido"), Viewstate("NroPropuesta"), Viewstate("NroVersion"))
        dgLink.DataKeyField = "CodLink"
        dgLink.DataSource = ds
        dgLink.DataBind()
        dgLink.SelectedItemStyle.Reset()

        lblNroServicio.Text = ""
        lblMsg.Text = CStr(dgLink.Items.Count) + " Link(s)"
    End Sub

    Private Sub CargaStsReserva(ByVal pCodStsReserva As String)
        Dim ds As New DataSet
        ds = objStsReserva.Cargar
        ddlStsReserva.DataSource = ds
        ddlStsReserva.DataBind()
        If pCodStsReserva.Trim.Length > 0 Then
            ddlStsReserva.Items.FindByValue(pCodStsReserva).Selected = True
        End If
    End Sub

    Private Sub CargaProveedor(ByVal pCodProveedor As Integer)
        ddlProveedor.DataSource = objProveedor.CargarProveedor(pCodProveedor)
        ddlProveedor.DataBind()
    End Sub

    Private Sub CargaHotelAlternativo(ByVal pCodProveedor As Integer, ByVal pCodCiudad As String, ByVal pNroAlternativo As Integer)
        Dim ds As New DataSet
        ds = objVersionDet.CargaHotelAlternativo(pCodProveedor, pCodCiudad)
        ddlHotelAlternativo.DataSource = ds
        ddlHotelAlternativo.DataBind()
        ddlHotelAlternativo.Items.Insert(0, New ListItem(" "))
        If pNroAlternativo > 0 Then
            Try
                ddlHotelAlternativo.Items.FindByValue(pNroAlternativo).Selected = True
            Catch ex As Exception
                ddlHotelAlternativo.Items.FindByValue(" ").Selected = True
            End Try
        Else
            ddlHotelAlternativo.Items.FindByValue(" ").Selected = True
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If lblNroServicio.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar hotel"
            Return
        End If
        If ddlStsReserva.Items.Count() = 0 Then
            lblMsg.Text = "No existe estados de la reserva"
            Return
        End If

        If ddlHotelAlternativo.SelectedValue <> " " Then
            objVersionDet.NroAlternativo = ddlHotelAlternativo.SelectedItem.Value()
        Else
            objVersionDet.NroAlternativo = 0
        End If

        objVersionDet.NroPedido = Viewstate("NroPedido")
        objVersionDet.NroPropuesta = Viewstate("NroPropuesta")
        objVersionDet.NroVersion = Viewstate("NroVersion")
        objVersionDet.NroServicio = lblNroServicio.Text
        objVersionDet.CodStsReserva = ddlStsReserva.SelectedItem.Value
        objVersionDet.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objVersionDet.GrabarHotelReserva
        If lblMsg.Text.Trim = "OK" Then
            CargaVersionLink()
            ddlStsReserva.Items.Clear()
            ddlProveedor.Items.Clear()
            ddlHotelAlternativo.Items.Clear()
        End If
    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
            "?NroPedido=" & Viewstate("NroPedido") & _
            "&NroPropuesta=" & Viewstate("NroPropuesta") & _
            "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub dgLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLink.SelectedIndexChanged
        lblNroServicio.Text = dgLink.Items(dgLink.SelectedIndex).Cells(1).Text
        lblCodCiudad.Text = dgLink.Items(dgLink.SelectedIndex).Cells(9).Text
        lblCiudad.Text = dgLink.Items(dgLink.SelectedIndex).Cells(3).Text

        CargaStsReserva(dgLink.Items(dgLink.SelectedIndex).Cells(6).Text)

        If dgLink.Items(dgLink.SelectedIndex).Cells(14).Text.Trim = "&nbsp;" Then
            CargaProveedor(dgLink.Items(dgLink.SelectedIndex).Cells(13).Text)
            CargaHotelAlternativo(dgLink.Items(dgLink.SelectedIndex).Cells(13).Text, dgLink.Items(dgLink.SelectedIndex).Cells(9).Text, dgLink.Items(dgLink.SelectedIndex).Cells(10).Text)
        Else
            CargaProveedor(dgLink.Items(dgLink.SelectedIndex).Cells(14).Text)
            CargaHotelAlternativo(dgLink.Items(dgLink.SelectedIndex).Cells(14).Text, dgLink.Items(dgLink.SelectedIndex).Cells(9).Text, dgLink.Items(dgLink.SelectedIndex).Cells(10).Text)
        End If

    End Sub

    Private Sub dgLink_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLink.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(6).Text.Trim = "OK" Or e.Item.Cells(6).Text.Trim = "OF" Then
                e.Item.Cells(6).ForeColor = Color.Blue
            Else
                e.Item.Cells(3).ForeColor = Color.Red
                e.Item.Cells(4).ForeColor = Color.Red
                e.Item.Cells(6).ForeColor = Color.Red
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub LinkButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonTodos.Click
        ddlProveedor.DataSource = objProveedor.CargaProveedoresActivosxCiudad(lblCodCiudad.Text, 2)
        ddlProveedor.DataBind()
        If ddlProveedor.Items.Count > 0 Then
            CargaHotelAlternativo(ddlProveedor.SelectedValue, lblCodCiudad.Text, 0)
        Else
            CargaHotelAlternativo(0, "", 0)
        End If
    End Sub

    Private Sub ddlProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProveedor.SelectedIndexChanged
        CargaHotelAlternativo(ddlProveedor.SelectedValue, lblCodCiudad.Text, 0)
    End Sub
End Class
