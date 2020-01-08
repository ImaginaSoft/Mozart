Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionAjusteDoc
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            CargaDocumentos()
        End If
    End Sub

    Private Sub CargaDocumentos()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "Vta_VersionAjusteDoc_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgDocumento.DataSource = ds.Tables("Documentos")
        dgDocumento.DataBind()
        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub


    Private Sub dgDocumento_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento.ItemDataBound
        '        If Trim(e.Item.Cells(9).Text) = "Anulado" Then
        '       e.Item.ForeColor = Color.DarkGray
        '      Else
        If IsNumeric(e.Item.Cells(7).Text) Then
            If e.Item.Cells(7).Text > 0 Then
                e.Item.Cells(7).ForeColor = Color.Blue
            Else
                e.Item.Cells(7).ForeColor = Color.Red
            End If
        End If
        ' End If

    End Sub

    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        If dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text = "C" Then
            Response.Redirect("cpcDocumentoDet.aspx" & _
                    "?CodCliente=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(18).Text & _
                    "&Nombre=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(6).Text & _
                    "&TipoDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(2).Text & _
                    "&NroDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(3).Text & _
                    "&Tabla=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text & _
                    "&TipoOperacion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(14).Text & _
                    "&NroPedido=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(4).Text & _
                    "&NroPropuesta=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(15).Text & _
                    "&NroVersion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(16).Text & _
                    "&Origen=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(17).Text)
        Else
            Response.Redirect("cppDocumentoDet.aspx" & _
                    "?CodProveedor=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(18).Text & _
                    "&Nombre=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(6).Text & _
                    "&TipoDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(2).Text & _
                    "&NroDocumento=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(3).Text & _
                    "&Tabla=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text & _
                    "&TipoOperacion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(14).Text & _
                    "&NroPedido=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(4).Text & _
                    "&NroPropuesta=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(15).Text & _
                    "&NroVersion=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(16).Text & _
                    "&Origen=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(17).Text)
        End If
    End Sub


End Class
