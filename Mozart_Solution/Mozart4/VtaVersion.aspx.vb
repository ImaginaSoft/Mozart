Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersion
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
            Viewstate("EmailCliente") = Request.Params("EmailCliente")
            CargaDatos()
        End If


    End Sub

    Private Sub CargaDatos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionNroPropuesta_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = CInt(Viewstate("NroPedido"))
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = CInt(Viewstate("NroPropuesta"))

        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "CVERSION")
        'dgVersion.DataKeyField = "NroVersion"
        dgVersion.DataSource = ds.Tables("CVERSION")
        dgVersion.DataBind()

        lblMsg.Text = CStr(nReg) + " Version(es) encontrada(s)"

    End Sub

    Private Sub dgVersion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgVersion.SelectedIndexChanged
        Response.Redirect("VtaVersionFicha.aspx" & _
                "?CodCliente=" & Viewstate("CodCliente") & _
                "&NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                "&EmailCliente=" & Viewstate("EmailCliente") & _
                "&NroVersion=" & dgVersion.Items(dgVersion.SelectedIndex).Cells(1).Text & _
                "&CantAdultos=" & dgVersion.Items(dgVersion.SelectedIndex).Cells(6).Text & _
                "&CantNinos=" & dgVersion.Items(dgVersion.SelectedIndex).Cells(7).Text)
    End Sub

End Class
