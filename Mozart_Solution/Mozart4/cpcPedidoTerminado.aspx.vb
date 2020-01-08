Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cpcPedidoTerminado
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(0)
            CargaDocumentos()
        End If
    End Sub
    Private Sub CargaDocumentos()
        Dim wCodMoneda As String

        'Moneda
        If rbsoles.Checked Then
            wCodMoneda = "S"
        Else
            If rbdolar.Checked Then
                wCodMoneda = "D"
            End If
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_PedidoTerminado_S"
        da.SelectCommand.Parameters.Add("@FechFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wCodMoneda
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgCtaCte.DataKeyField = "KeyReg"
        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgCtaCte.DataSource = dv
        dgCtaCte.DataBind()

        lblmsg.Text = CStr(nReg) + " Pedidos(s) Finalizado(s) al " & txtFchEmision.Text
    End Sub
    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If IsNumeric(e.Item.Cells(4).Text) Then
            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                If e.Item.Cells(4).Text < 0 Then
                    e.Item.Cells(4).ForeColor = Color.Red
                End If
            End If
        End If
        If IsNumeric(e.Item.Cells(5).Text) Then
            If e.Item.Cells(5).Text > 0 Then
                e.Item.Cells(5).ForeColor = Color.Red
            Else
                If e.Item.Cells(5).Text < 0 Then
                    e.Item.Cells(5).ForeColor = Color.Blue
                End If
            End If
        End If
        If IsNumeric(e.Item.Cells(6).Text) Then
            If e.Item.Cells(6).Text > 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            Else
                If e.Item.Cells(6).Text < 0 Then
                    e.Item.Cells(6).ForeColor = Color.Blue
                End If
            End If
        End If
        If IsNumeric(e.Item.Cells(7).Text) Then
            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Red
            Else
                If e.Item.Cells(7).Text < 0 Then
                    e.Item.Cells(7).ForeColor = Color.Blue
                End If
            End If
        End If
        If IsNumeric(e.Item.Cells(8).Text) Then
            If e.Item.Cells(8).Text > 0 Then
                e.Item.Cells(8).ForeColor = Color.Red
            Else
                If e.Item.Cells(8).Text < 0 Then
                    e.Item.Cells(8).ForeColor = Color.Blue
                End If
            End If
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub
    Private Sub dgCtaCte_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCtaCte.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub
    Private Sub dgCtaCte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCtaCte.SelectedIndexChanged
        Session("CodCliente") = dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(11).Text
        Response.Redirect("cpcPedidoLiquidacion.aspx" & _
                "?NroPedido=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(1).Text & _
                "&CodMoneda=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(10).Text)
    End Sub

End Class
