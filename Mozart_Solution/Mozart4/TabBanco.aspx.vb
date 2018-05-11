Imports cmpTabla
Imports System.Data

Partial Class TabBanco
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objBanco As New clsBanco

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            rbActivo.Checked = True
            CargaDatos()
        End If

    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objBanco.Cargar
        dgBanco.DataKeyField = "keyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgBanco.DataSource = dv
        dgBanco.DataBind()
        lblMsg.Text = CStr(dgBanco.Items.Count) + " Banco(s)"
    End Sub

    Private Sub dgBanco_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objBanco.StsBanco = "A"
        Else
            objBanco.StsBanco = "I"
        End If

        objBanco.CodBanco = txtCodigo.Text
        objBanco.NomBanco = txtNombre.Text
        objBanco.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objBanco.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgBanco.SelectedIndexChanged
        Dim wEstado As String

        txtCodigo.Text = dgBanco.Items(dgBanco.SelectedIndex).Cells(1).Text.Trim
        txtNombre.Text = dgBanco.Items(dgBanco.SelectedIndex).Cells(2).Text.Trim
        wEstado = Trim(dgBanco.Items(dgBanco.SelectedIndex).Cells(3).Text).Trim

        If wEstado = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
    End Sub

    Private Sub dgBanco_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBanco.DeleteCommand
        objBanco.CodBanco = Mid(dgBanco.DataKeys(e.Item.ItemIndex).ToString, 1, 3)
        lblMsg.Text = objBanco.Borrar
        If lblMsg.Text = "OK" Then
            Me.CargaDatos()
        End If
    End Sub

    Private Sub dgBanco_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBanco.EditCommand
        Response.Redirect("TabBancoCuenta.aspx" & _
        "?CodBanco=" & Mid(dgBanco.DataKeys(e.Item.ItemIndex).ToString, 1, 3) & _
        "&NomBanco=" & Mid(dgBanco.DataKeys(e.Item.ItemIndex).ToString, 4, 50))
    End Sub

End Class
