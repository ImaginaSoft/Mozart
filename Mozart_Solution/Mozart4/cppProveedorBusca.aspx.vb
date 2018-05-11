Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cppProveedorBusca
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            SetDefaultButton(txtNomProveedor, cmdBuscar)
        End If
    End Sub
    Private Sub CargaProveedores()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_ProveedorNomProveedor_S"
        da.SelectCommand.Parameters.Add("@NomProveedor", SqlDbType.VarChar, 50).Value = Trim(txtNomProveedor.Text) + "%"
        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "MProveedor")
        dgProveedor.DataKeyField = "CodProveedor"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgProveedor.DataSource = dv
        dgProveedor.DataBind()

        lblMsg.Text = CStr(nReg) + " Proveedores(s) encontrado(s)"
    End Sub
    Private Sub dgProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgProveedor.SelectedIndexChanged
        Session("CodProveedor") = CInt(dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text())
        Response.Redirect("cppProveedorFicha.aspx" & _
                                           "?CodProveedor=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text)
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("cppProveedorNuevo.aspx")

    End Sub

    Private Overloads Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        CargaProveedores()
    End Sub
    Private Sub SetDefaultButton(ByVal txt As TextBox, ByVal defaultButton As Button)
        txt.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)")
    End Sub

    Private Sub dgProveedor_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgProveedor.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaProveedores()
    End Sub

End Class
