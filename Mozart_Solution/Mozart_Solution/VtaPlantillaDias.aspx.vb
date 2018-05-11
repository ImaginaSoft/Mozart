Imports cmpNegocio
Partial Class VtaPlantillaDias
    Inherits System.Web.UI.Page
    Dim objPlantilla As New clsPlantilla

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPlantilla") = Request.Params("NroPlantilla")
            lbltitulo.Text = "Modificar dias Plantilla N° " & Viewstate("NroPlantilla")
            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        dgServicio.DataSource = objPlantilla.CargaServicios(Viewstate("NroPlantilla"))
        dgServicio.DataBind()
    End Sub

    Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
        lblMsg.Text = objPlantilla.BorraDias(Viewstate("NroPlantilla"), txtDiaIni.Text, txtDiaFin.Text, Session("CodUsuario"))
        If lblMsg.Text.Trim = "OK" Then
            CargaData()
        End If
    End Sub

    Private Sub cmdInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInserta.Click
        lblMsg.Text = objPlantilla.InsertaDias(Viewstate("NroPlantilla"), txtDiaInicio.Text, txtCantDias.Text, Session("CodUsuario"))
        If lblMsg.Text.Trim = "OK" Then
            CargaData()
        End If
    End Sub

    Private Sub lbtFichaPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPlantilla.Click
        Response.Redirect("VtaPlantillaFicha.aspx" & _
                  "?NroPlantilla=" & Viewstate("NroPlantilla"))
    End Sub

End Class
