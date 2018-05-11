Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cppDocumento
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            txtNomCliente.Text = Request.Params("NroPedido")
            txtFchEmision.Text = ObjRutina.fechaddmmyyyy(-180)
            'CargaDocumentos()
        End If
    End Sub
    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If Trim(e.Item.Cells(8).Text) = "Anul" Then
            e.Item.ForeColor = Color.DarkGray
        ElseIf IsNumeric(e.Item.Cells(6).Text) Then
            If e.Item.Cells(6).Text > 0 Then
                e.Item.Cells(6).ForeColor = Color.Red
            Else
                e.Item.Cells(6).ForeColor = Color.Blue
            End If

            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Red
            ElseIf e.Item.Cells(7).Text < 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            End If
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDocumentos()
    End Sub
    Private Sub CargaDocumentos()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If IsNumeric(txtNomCliente.Text.Trim) Then
            If rbTodos.Checked Then
                da.SelectCommand.CommandText = "CPP_MovtosxProveedorNroPedido_S"
            Else
                da.SelectCommand.CommandText = "CPP_MovtosxProveedorPendNroPedido_S"
            End If
            da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
            da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
            da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = txtNomCliente.Text.Trim
        Else
            If rbTodos.Checked Then
                da.SelectCommand.CommandText = "CPP_MovtosxProveedor_S"
            Else
                da.SelectCommand.CommandText = "CPP_MovtosxProveedorPend_S"
            End If
            da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))
            da.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchEmision.Text)
            da.SelectCommand.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50).Value = Trim(txtNomCliente.Text) + "%"
        End If

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgCtaCte.DataSource = dv
        dgCtaCte.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub
    Private Sub dgCtaCte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCtaCte.SelectedIndexChanged
        Response.Redirect("cppDocumentoDet.aspx" & _
        "?CodProveedor=" & Viewstate("CodProveedor") & _
        "&Nombre=" & UcProveedor1.Nombre & _
        "&TipoDocumento=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(2).Text & _
        "&NroDocumento=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(3).Text & _
        "&Tabla=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(11).Text & _
        "&TipoOperacion=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(12).Text & _
        "&estado=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(8).Text & _
        "&NroPedido=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(4).Text & _
        "&NroPropuesta=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(14).Text & _
        "&NroVersion=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(15).Text & _
        "&Correlativo=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(16).Text & _
        "&CodCuenta=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(17).Text & _
        "&NroComprobante=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(18).Text & _
        "&Origen=" & dgCtaCte.Items(dgCtaCte.SelectedIndex).Cells(19).Text)
    End Sub

    Private Sub dgCtaCte_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCtaCte.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

End Class
