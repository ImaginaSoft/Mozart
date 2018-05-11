Imports cmpNegocio
Imports cmpRutinas
Imports System.Data
Imports System.Drawing

Partial Class cpcCtaCte
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodCliente") = Request.Params("CodCliente")
            txtFchEmision.Text = objRutina.fechaddmmyyyy(-366)
            CargaCtaCte()
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaCtaCte()
    End Sub

    Private Sub CargaCtaCte()
        Dim wCodMoneda As String
        If rbDolar.Checked Then
            wCodMoneda = "D"
        Else
            wCodMoneda = "S"
        End If

        Dim objCliente As New clsCliente
        Dim ds As New DataSet
        'ds = objCliente.CargarCtacte(Viewstate("CodCliente"), wCodMoneda, objRutina.fechayyyymmdd(txtFchEmision.Text))
        dgCtaCte.DataSource = objCliente.CargarCtacte(Viewstate("CodCliente"), wCodMoneda, objRutina.fechayyyymmdd(txtFchEmision.Text))
        dgCtaCte.DataBind()
        lblmsg.Text = CStr(dgCtaCte.Items.Count) + " Registro(s)"
    End Sub


    Private Sub rbDolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDolar.CheckedChanged
        CargaCtaCte()
    End Sub

    Private Sub rbSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged
        CargaCtaCte()
    End Sub

    Private Sub txtFchEmision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaCtaCte()
    End Sub

    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text >= 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If
            If e.Item.Cells(5).Text >= 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            Else
                e.Item.Cells(5).ForeColor = Color.Red
            End If
        End If
    End Sub

End Class
