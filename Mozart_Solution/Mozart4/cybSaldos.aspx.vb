Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybSaldos
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim da As New SqlDataAdapter
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = cn
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "CYB_Saldo_S"

            Dim ds As New DataSet
            Dim nReg As Integer = da.Fill(ds, "CtaCte")
            dgSaldos.DataSource = ds.Tables("CtaCte")
            dgSaldos.DataBind()
            '            lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
        End If

    End Sub

    Private Sub dgSaldos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSaldos.SelectedIndexChanged
        Response.Redirect("cybSaldoMovimiento.aspx" & _
        "?CodBanco=" & dgSaldos.Items(dgSaldos.SelectedIndex).Cells(5).Text & _
        "&SecBanco=" & dgSaldos.Items(dgSaldos.SelectedIndex).Cells(6).Text & _
        "&NomBanco=" & dgSaldos.Items(dgSaldos.SelectedIndex).Cells(1).Text & _
        "&NroCuenta=" & dgSaldos.Items(dgSaldos.SelectedIndex).Cells(2).Text)
    End Sub

    Private Sub dgSaldos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgSaldos.ItemDataBound
        If IsNumeric(e.Item.Cells(3).Text) Then
            If e.Item.Cells(3).Text < 0 Then
                e.Item.Cells(3).ForeColor = Color.Red
            Else
                e.Item.Cells(3).ForeColor = Color.Blue
            End If

        End If
    End Sub

End Class
