Imports cmpNegocio
Imports System.Data

Partial Class cpcClienteBusca
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            txtNomCliente.Style.Add("width", "244px")
            txtEmail.Style.Add("width", "244px")
            txtNomPasajero.Style.Add("width", "244px")
            txtTelefono.Style.Add("width", "244px")

            SetDefaultButton(txtNomCliente, cmdBusca)
        End If
    End Sub
    Private Sub dgCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCliente.SelectedIndexChanged
        Session("CodCliente") = CInt(dgCliente.Items(dgCliente.SelectedIndex).Cells(1).Text())
        Response.Redirect("CpcClienteFicha.aspx" & _
                                    "?CodCliente=" & dgCliente.Items(dgCliente.SelectedIndex).Cells(1).Text)
    End Sub


    Private Sub cmdBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBusca.Click
        Dim sOpcion, pTrama As String
        If rbtApellidos.Checked Then
            sOpcion = "A"
            If valida(txtNomCliente.Text) <> "" Then
                Return
            End If
            dgCliente.Columns(6).Visible = False
            pTrama = txtNomCliente.Text.Trim & "%"
        ElseIf rbtEmail.Checked Then
            sOpcion = "E"
            If valida(txtEmail.Text) <> "" Then
                Return
            End If
            dgCliente.Columns(6).Visible = False
            pTrama = txtEmail.Text.Trim & "%"
        ElseIf rbtPasajero.Checked Then
            sOpcion = "P"
            If valida(txtNomPasajero.Text) <> "" Then
                Return
            End If
            dgCliente.Columns(6).Visible = True
            dgCliente.Columns(6).HeaderText = "Pasajero"
            pTrama = "%" & txtNomPasajero.Text.Trim & "%"
        ElseIf rbtTelefono.Checked Then
            sOpcion = "T"
            If valida(txtTelefono.Text) <> "" Then
                Return
            End If
            dgCliente.Columns(6).Visible = True
            dgCliente.Columns(6).HeaderText = "Teléfono"
            pTrama = "%" & txtTelefono.Text.Trim & "%"
        ElseIf rbtCodCliente.Checked Then
            sOpcion = "C"
            If IsNumeric(txtCodCliente.Text.Trim) Then
                'dgCliente.Columns(6).Visible = False
                pTrama = txtCodCliente.Text.Trim

            Else
                lblMsg.Text = "Por favor ingrese código cliente númerico."
                Return
            End If
        End If

        Dim objCliente As New clsCliente
        Dim ds As New DataSet
        dgCliente.DataSource = objCliente.CargarCliente(sOpcion, pTrama)
        dgCliente.DataBind()
        lblMsg.Text = CStr(dgCliente.Items.Count) + " Cliente(s)"
    End Sub

    Function valida(ByVal pcampo As String) As String
        lblMsg.Text = ""
        If pcampo.Trim.Length < 2 Then
            lblMsg.Text = "Por favor ingrese por lo menos 2 caracteres."
        End If
        Return (lblMsg.Text)
    End Function

    Private Sub SetDefaultButton(ByVal txt As TextBox, ByVal defaultButton As Button)
        txt.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)")
    End Sub

End Class
