Imports cmpTabla
Imports System.Data
Imports System.Drawing

Partial Class TabTipoAcomodacion
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTipoacomodacion As New clsTipoAcomodacion
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodTipoServicio") = Request.Params("CodTipoServicio")
            lblTitulo.Text = "Tipos de Acomodación de Tipo Servicio N° " & ViewState("CodTipoServicio")

            rbActivo.Checked = True
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        objTipoacomodacion.CodTipoServicio = Viewstate("CodTipoServicio")
        Dim ds As New DataSet
        ds = objTipoacomodacion.Cargar()
        dglista.DataKeyField = "CodTipoAcomodacion"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dglista.DataSource = dv
        dglista.DataBind()
        lblMsg.Text = CStr(dglista.Items.Count) + " Tipo Acomodacion"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wEstado As String
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If

        objTipoacomodacion.CodTipoServicio = Viewstate("CodTipoServicio")
        objTipoacomodacion.CodTipoAcomodacion = txtCodigo.Text
        objTipoacomodacion.TipoAcomodacion = txtNombre.Text
        objTipoacomodacion.AbrTipoAcomodacion = txtAbr.Text
        objTipoacomodacion.StsTipoAcomodacion = wEstado
        objTipoacomodacion.NroOrden = txtNroOrden.Text
        objTipoacomodacion.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoacomodacion.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
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
        objTipoacomodacion.CodTipoServicio = Viewstate("CodTipoServicio")
        objTipoacomodacion.CodTipoAcomodacion = dglista.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objTipoacomodacion.Borrar()
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        Else
            lblMsg.CssClass = "Error"
        End If
    End Sub

    Private Sub dgLista_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dglista.SelectedIndexChanged
        txtCodigo.Text = dglista.Items(dglista.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dglista.Items(dglista.SelectedIndex).Cells(2).Text.Trim
        txtAbr.Text = dglista.Items(dglista.SelectedIndex).Cells(3).Text.Trim
        txtNroOrden.Text = dglista.Items(dglista.SelectedIndex).Cells(4).Text.Trim

        If dglista.Items(dglista.SelectedIndex).Cells(5).Text.Trim = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dglista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dglista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub dglista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dglista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(5).Text.Trim = "Inactivo" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub
End Class
