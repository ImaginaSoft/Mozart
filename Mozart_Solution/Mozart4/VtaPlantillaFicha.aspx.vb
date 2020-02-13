Imports cmpNegocio
Imports System.Drawing

Partial Class VtaPlantillaFicha
    Inherits System.Web.UI.Page
    Dim objRutina As New cmpRutinas.clsRutinas
    Dim objPlantilla As New clsPlantilla

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            If Len(Trim(Request.Params("NroPlantilla"))) > 0 Then
                Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            Else
                Viewstate("NroPlantilla") = Session("NroPlantilla")
            End If

            If Viewstate("NroPlantilla") = 0 Then
                Response.Redirect("VtaPlantillaBusca.aspx")
            End If

            CargaData()
        End If
    End Sub
    Private Sub CargaData()
        dgServicio.DataSource = objPlantilla.CargaServicios(Viewstate("NroPlantilla"))
        dgServicio.DataBind()
    End Sub

    Private Sub lbtServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtServicio.Click
        Response.Redirect("VtaPlantillaServicio.aspx" & _
        "?NroPlantilla=" & ucPlantilla1.NroPlantilla & _
        "&DesPlantilla=" & ucPlantilla1.DesPlantilla)
    End Sub

    Private Sub lbtLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtLink.Click
        Response.Redirect("VtaPlantillaLink.aspx" & _
        "?NroPlantilla=" & ucPlantilla1.NroPlantilla & _
        "&DesPlantilla=" & ucPlantilla1.DesPlantilla)
    End Sub

    Private Sub lbtNuevaPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevaPlantilla.Click
        Response.Redirect("VtaPlantillaNueva.aspx" & _
        "?NroPlantilla=0")
    End Sub

    Private Sub lbtEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminar.Click
        lblMsg.Text = objPlantilla.Borrar(ucPlantilla1.NroPlantilla)
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaPlantillaBusca.aspx")
        End If
    End Sub

    Private Sub lbtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtModificar.Click
        Response.Redirect("VtaPlantillaNueva.aspx" & _
        "?NroPlantilla=" & ucPlantilla1.NroPlantilla & _
        "&DesPlantilla=" & ucPlantilla1.DesPlantilla & _
        "&CodZonaVta=" & ucPlantilla1.CodZonaVta & _
        "&StsPlantilla=" & ucPlantilla1.StsPlantilla)
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If Trim(e.Item.Cells(8).Text) = "Inactivo" Then
            e.Item.ForeColor = Color.Red
        End If
    End Sub

    Private Sub lbtDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDias.Click
        Response.Redirect("VtaPlantillaDias.aspx" & _
        "?NroPlantilla=" & ucPlantilla1.NroPlantilla)
    End Sub


    Private Sub lbtImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtImg.Click
        Response.Redirect("VtaPlantillaImg.aspx" & "?NroPlantilla=" & ucPlantilla1.NroPlantilla & "&DesPlantilla=" & ucPlantilla1.DesPlantilla)
    End Sub
End Class
