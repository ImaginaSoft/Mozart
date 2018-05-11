Imports cmpTabla
Imports System.Data

Partial Class TabBancoCuenta
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objBancoCta As New clsBancoCta
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodBanco") = Request.Params("CodBanco")
            Viewstate("NomBanco") = Request.Params("NomBanco")
            CargaDatos()
            lblBanco.Text = Viewstate("NomBanco")
        End If

    End Sub
    Private Sub CargaDatos()
        objBancoCta.CodBanco = Viewstate("CodBanco")
        Dim ds As New DataSet
        ds = objBancoCta.Cargar
        dgBancoCuenta.DataKeyField = "SecBanco"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBancoCuenta.DataSource = dv
        dgBancoCuenta.DataBind()
        lblMsg.Text = CStr(dgBancoCuenta.Items.Count) + " Cuenta(s)"
    End Sub

    Private Sub dgBancoCuenta_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgBancoCuenta.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbtSI.Checked Then
            objBancoCta.FlagCtaDeposito = "S"
        Else
            objBancoCta.FlagCtaDeposito = "N"
        End If

        If rbSoles.Checked Then
            objBancoCta.CodMoneda = "S"
        Else
            objBancoCta.CodMoneda = "D"
        End If
        If rbActivo.Checked Then
            objBancoCta.StsCuenta = "A"
        Else
            objBancoCta.StsCuenta = "I"
        End If

        objBancoCta.CodBanco = Viewstate("CodBanco")
        objBancoCta.SecBanco = txtCodigo.Text
        objBancoCta.TipoCuenta = txtTipoCuenta.Text
        objBancoCta.NroCuenta = txtNombre.Text
        objBancoCta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objBancoCta.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub dgBancoCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgBancoCuenta.SelectedIndexChanged
        txtCodigo.Text = dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(2).Text.Trim
        txtTipoCuenta.Text = dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(3).Text.Trim

        If dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(6).Text.Trim = "S" Then
            rbtSI.Checked = True
            rbtNO.Checked = False
        Else
            rbtSI.Checked = False
            rbtNO.Checked = True
        End If

        If dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(4).Text.Trim = "Soles" Then
            rbSoles.Checked = True
            rbDolares.Checked = False
        Else
            rbDolares.Checked = True
            rbSoles.Checked = False
        End If

        If dgBancoCuenta.Items(dgBancoCuenta.SelectedIndex).Cells(5).Text.Trim = "Activo" Then
            rbActivo.Checked = True
            rbInactivo.Checked = False
        Else
            rbInactivo.Checked = True
            rbActivo.Checked = False
        End If
    End Sub

    Private Sub dgBancoCuenta_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBancoCuenta.DeleteCommand
        objBancoCta.CodBanco = Viewstate("CodBanco")
        objBancoCta.SecBanco = dgBancoCuenta.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objBancoCta.Borrar
        If lblMsg.Text.Trim = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInactivo.CheckedChanged
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub rbDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDolares.CheckedChanged
        rbDolares.Checked = True
        rbSoles.Checked = False
    End Sub

    Private Sub rbSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged
        rbDolares.Checked = False
        rbSoles.Checked = True
    End Sub

    Private Sub rbtSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSI.CheckedChanged
        rbtSI.Checked = True
        rbtNO.Checked = False
    End Sub

    Private Sub rbtNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNO.CheckedChanged
        rbtSI.Checked = False
        rbtNO.Checked = True
    End Sub

End Class
