Imports cmpTabla
Imports cmpRutinas
Imports System.Drawing

Partial Class cppGastosIngresos
    Inherits System.Web.UI.Page
    Dim objrutina As New clsRutinas
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            CargaAno()
            CargaInforme()
            CargaPeriodoVtaAbierto()
        End If
    End Sub

    Private Sub CargaAno()
        Dim objAnoProceso As New clsAnoProceso
        ddlAno.DataSource = objAnoProceso.Cargar
        ddlAno.DataBind()
        Dim iAno As Integer = Year(Now)
        ddlAno.Items.FindByValue(iAno).Selected = True
    End Sub

    Private Sub CargaInforme()
        Dim objTablaElemento As New clsTablaElemento
        ddlInforme.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(14, "E")
        ddlInforme.DataBind()
    End Sub

    Private Sub CargaPeriodoVtaAbierto()
        Dim objPeriodoVta As New clsPeriodoVta
        lblMsg.Text = objPeriodoVta.EditarPeriodoAbierto
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            lblFechaInicio.Text = ToString.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchIniPeriodo)
            lblFechaFin.Text = ToString.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchFinPeriodo)
            lbtActualizar.Text = "Actualiza del " & lblFechaInicio.Text & " al " & lblFechaFin.Text
        End If
    End Sub


    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        lblMsg.Text = ""
        CargaLista()
    End Sub
    Private Sub CargaLista()
        Dim objInforme As New clsInforme
        dgLista.DataSource = objInforme.PYG(ddlInforme.SelectedValue, ddlAno.SelectedItem.Value)
        dgLista.DataBind()
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(15).Text.Trim = "S" Then 'Subtotal
                e.Item.BackColor = Color.LightSkyBlue
            ElseIf e.Item.Cells(15).Text.Trim = "T" Then 'Total
                e.Item.BackColor = Color.Gold
            End If
        End If
    End Sub

    Private Sub lbtActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtActualizar.Click
        Dim objInforme As New clsInforme
        lblMsg.Text = objInforme.Actualiza(objrutina.fechayyyymmdd(lblFechaInicio.Text), objrutina.fechayyyymmdd(lblFechaFin.Text))
    End Sub

End Class
