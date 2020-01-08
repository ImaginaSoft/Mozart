Imports cmpTabla
Imports System.Data

Partial Class TabZonaVta
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objZonaVta As New clsZonaVta
    Dim objCuenta As New clsCuenta

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            lblTitulo.Text = "Zonas de Venta "
            rbActivo.Checked = True
            CargaDatos()
            CargaTipoCuenta("")
        End If

    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objZonaVta.Cargar
        dglista.DataKeyField = "CodZonaVta"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Zonas de Venta"
    End Sub

    Private Sub CargaTipoCuenta(ByVal pcuenta2 As String)
        ddlTipoCuenta.DataSource = objCuenta.CargarCuenta2("I")
        ddlTipoCuenta.DataBind()
        Try
            ddlTipoCuenta.Items.FindByValue(pcuenta2).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objZonaVta.StsZonaVta = "A"
        Else
            objZonaVta.StsZonaVta = "I"
        End If
        objZonaVta.CodZonaVta = txtCodigo.Text
        objZonaVta.NomZonaVta = txtNombre.Text
        objZonaVta.NroOrden = txtNroOrden.Text
        objZonaVta.CodCuenta = ddlTipoCuenta.SelectedValue
        objZonaVta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objZonaVta.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.DeleteCommand
        objZonaVta.CodZonaVta = dglista.DataKeys(e.Item.ItemIndex).ToString
        lblMsg.Text = objZonaVta.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        Dim wEstado As String
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text
        txtNombre.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text
        wEstado = Trim(dglista.Items(dglista.SelectedIndex).Cells(3).Text)
        txtNroOrden.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text
        CargaTipoCuenta(dglista.Items(dglista.SelectedIndex).Cells(7).Text)

        If wEstado = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dglista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista.EditCommand
        Response.Redirect("tabZonaVtaInf.aspx" & _
                    "?CodZonaVta=" & dglista.DataKeys(e.Item.ItemIndex))
    End Sub

End Class
