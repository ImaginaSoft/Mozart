Imports cmpTabla
Imports System.Data
Partial Class blogTipoExperiencia
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTipoExperiencia As New clsTipoExperiencia

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaTipoExperiencia()
        End If
    End Sub


    Private Sub lblNuevoGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("BlogTipoExperienciaNuevo.aspx" & _
                         "?Opcion=" & "Nuevo")
    End Sub

    Private Sub CargaTipoExperiencia()
        Dim sFlagIdioma As String
        If rbtIngles.Checked Then
            sFlagIdioma = "I"
        Else
            sFlagIdioma = "E"
        End If

        Dim ds As New DataSet
        ds = objTipoExperiencia.CargaxIdioma(sFlagIdioma)
        dgTipoExp.DataKeyField = "CodTipoExp"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTipoExp.DataSource = dv
        dgTipoExp.DataBind()
        lblMsg.CssClass = "msg"
        lblMsg.Text = CStr(dgTipoExp.Items.Count) + " Tipos de experiencia"
    End Sub

    Private Sub rbtIngles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtIngles.CheckedChanged
        CargaTipoExperiencia()
    End Sub
    Private Sub InitializeComponent()

    End Sub

    Private Sub dgTipoExp_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoExp.DeleteCommand
        objTipoExperiencia.CodTipoExp = dgTipoExp.DataKeys(e.Item.ItemIndex)
        lblMsg.Text = objTipoExperiencia.Borrar
        If lblMsg.Text.Trim = "OK" Then
            CargaTipoExperiencia()
        End If
    End Sub

    Private Sub dgTipoExp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTipoExp.SelectedIndexChanged
        txtCodTipoExp.Text = dgTipoExp.Items(dgTipoExp.SelectedIndex).Cells(1).Text
        txtNomTipoExp.Text = dgTipoExp.Items(dgTipoExp.SelectedIndex).Cells(2).Text

        If dgTipoExp.Items(dgTipoExp.SelectedIndex).Cells(5).Text.Trim = "I" Then
            rbtInglesEdit.Checked = True
            rbtEspanolEdita.Checked = False

        Else
            rbtInglesEdit.Checked = False
            rbtEspanolEdita.Checked = True
        End If
    End Sub

    Private Sub dgTipoExp_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTipoExp.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaTipoExperiencia()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        lblerror.Text = ""
        If txtNomTipoExp.Text.Trim = "" Then
            lblerror.Text = "Nombre es obligatorio"
            Return
        End If

        If txtCodTipoExp.Text.Trim = "" Then
            objTipoExperiencia.CodTipoExp = 0
        Else
            objTipoExperiencia.CodTipoExp = txtCodTipoExp.Text
        End If
        objTipoExperiencia.NomTipoExp = txtNomTipoExp.Text
        If rbtInglesEdit.Checked Then
            objTipoExperiencia.FlagIdioma = "I"
            rbtIngles.Checked = True
            rbtEspanol.Checked = False
        Else
            objTipoExperiencia.FlagIdioma = "E"
            rbtIngles.Checked = False
            rbtEspanol.Checked = True
        End If
        objTipoExperiencia.StsTipoExp = "A"
        objTipoExperiencia.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoExperiencia.Grabar()
        If lblMsg.Text.Trim = "OK" Then
            CargaTipoExperiencia()
        Else
            lblMsg.CssClass = "Error"
        End If

    End Sub

    Private Sub rbtEspanol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEspanol.CheckedChanged
        CargaTipoExperiencia()
    End Sub


End Class
