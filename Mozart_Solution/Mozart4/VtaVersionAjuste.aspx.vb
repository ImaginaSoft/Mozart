Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionAjuste
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodCliente") = Request.Params("CodCliente")
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("Opcion") = Request.Params("Opcion")
            If Viewstate("Opcion") = "Cargo" Then
                lbltitulo.Text = "Menor pago al Proveedor"
            Else
                lbltitulo.Text = "Mayor pago al Proveedor"
            End If
            SetDefaultButton(txtNomProveedor, cmdBuscar)

        End If
    End Sub
    Private Sub CargaProveedor()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_ProveedorCodProveedor_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = CInt(Viewstate("CodProveedor"))

        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "MProveedor")
        dgProveedor.DataKeyField = "CodProveedor"
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataBind()

        lblMsg.Text = CStr(nReg) + " Proveedores(s) encontrado(s)"
    End Sub
    Private Sub dgProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgProveedor.SelectedIndexChanged
        Session("CodProveedor") = CInt(dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text())
        If Viewstate("Opcion") = "Cargo" Then
            Response.Redirect("cppRegistraCredito.aspx" & _
                         "?NroPedido=" & Viewstate("NroPedido") & _
                         "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                         "&NroVersion=" & Viewstate("NroVersion") & _
                         "&NroDocumento=" & 0 & _
                         "&CodProveedor=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text)
        Else
            Response.Redirect("cppRegistraDebito.aspx" & _
                    "?NroPedido=" & Viewstate("NroPedido") & _
                    "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                    "&NroVersion=" & Viewstate("NroVersion") & _
                    "&NroDocumento=" & 0 & _
                    "&CodProveedor=" & dgProveedor.Items(dgProveedor.SelectedIndex).Cells(1).Text)
        End If
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("cppProveedorNuevo.aspx")

    End Sub

    Private Overloads Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_ProveedorNomProveedor_S"
        da.SelectCommand.Parameters.Add("@NomProveedor", SqlDbType.VarChar, 50).Value = Trim(txtNomProveedor.Text) + "%"

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "MProveedor")
        dgProveedor.DataKeyField = "CodProveedor"
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataBind()

        lblMsg.Text = CStr(nReg) + " Proveedores(s) encontrado(s)"
    End Sub

    Private Overloads Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_ProveedorNomProveedor_S"
        da.SelectCommand.Parameters.Add("@NomProveedor", SqlDbType.VarChar, 50).Value = Trim(txtNomProveedor.Text) + "%"

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "MProveedor")
        dgProveedor.DataKeyField = "CodProveedor"
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataSource = ds.Tables("MProveedor")
        dgProveedor.DataBind()

        lblMsg.Text = CStr(nReg) + " Proveedores(s) encontrado(s)"
    End Sub

    Private Sub SetDefaultButton(ByVal txt As TextBox, ByVal defaultButton As Button)
        txt.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)")
    End Sub



End Class
