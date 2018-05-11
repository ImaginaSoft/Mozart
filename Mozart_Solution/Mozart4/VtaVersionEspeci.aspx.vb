Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class VtaVersionEspeci
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("NroPedido") = Request.Params("NroPedido")
            ViewState("NroPropuesta") = Request.Params("NroPropuesta")
            ViewState("NroVersion") = Request.Params("NroVersion")
            ViewState("FlagEdita") = Request.Params("FlagEdita")

            lblTitulo.Text = "Actualizar Especificación Versión N° " & ViewState("NroVersion")

            CargaData()
        End If
    End Sub

    Private Sub CargaData()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_VersionServicioEspeci_S"
        da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")

        Dim nReg As Integer = da.Fill(ds, "Servicio")
        dgServicio.DataSource = ds.Tables("Servicio")
        dgServicio.DataBind()


        '        If Viewstate("FlagEdita") = "N" Then
        '       cmdGrabar.Visible = False
        '      dgServicio.Columns(0).Visible = False
        '     lblMsg.Text = "La Versión es modelo antiguo, no se puede modificar los Servicios"
        '    lblMsg.CssClass = "msg"
        '   Return
        '  Else
        lblMsg.Text = CStr(nReg) + " Servicio(s)"
        ' End If

    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        lblMsg.Text = ""
        If lblNroDia.Text.Trim.Length = 0 Then
            lblMsg.Text = "Falta editar el hotel que desea cambiar"
            Return
        End If

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_VersionEspeci_U"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@NroDia", SqlDbType.SmallInt).Value = lblNroDia.Text
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = lblNroOrden.Text
        cd.Parameters.Add("@HoraServicio", SqlDbType.Char, 8).Value = txtHoraServicio.Text
        cd.Parameters.Add("@NroServicio", SqlDbType.Int).Value = lblNroServicio.Text
        cd.Parameters.Add("@Especificacion", SqlDbType.VarChar, 100).Value = txtEspeci.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error: " & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error: " & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            lblNroDia.Text = ""
            lblNroOrden.Text = ""
            txtHoraServicio.Text = ""
            lblNroServicio.Text = ""
            lblCodProveedor.Text = ""
            lblCodCiudad.Text = ""

            lblNomProveedor.Text = ""
            lblNomCiudad.Text = ""
            lblDesProveedor.Text = ""
            txtEspeci.Text = ""

            CargaData()
        End If
    End Sub


    Private Sub dgServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgServicio.SelectedIndexChanged

        lblNroDia.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(1).Text
        lblNroOrden.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(2).Text
        txtHoraServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(5).Text.Trim
        lblNroServicio.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(3).Text
        If dgServicio.Items(dgServicio.SelectedIndex).Cells(10).Text.Trim = "&nbsp;" Then
            txtEspeci.Text = ""
        Else
            txtEspeci.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(10).Text.Trim
        End If

        lblNomProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(8).Text
        lblNomCiudad.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(4).Text
        lblDesProveedor.Text = dgServicio.Items(dgServicio.SelectedIndex).Cells(6).Text

    End Sub

    Private Sub lbtFichaVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaVersion.Click
        Response.Redirect("VtaVersionFicha.aspx" & _
        "?NroPedido=" & Viewstate("NroPedido") & _
        "&NroPropuesta=" & Viewstate("NroPropuesta") & _
        "&NroVersion=" & Viewstate("NroVersion"))
    End Sub

    Private Sub dgServicio_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgServicio.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(9).Text.Trim = "OK" Or e.Item.Cells(9).Text.Trim = "CO" Then
                e.Item.Cells(9).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
                'e.Item.Cells(5).ForeColor = Color.Red
                e.Item.Cells(8).ForeColor = Color.Red
                e.Item.Cells(9).ForeColor = Color.Red
            End If
        End If

    End Sub

End Class
