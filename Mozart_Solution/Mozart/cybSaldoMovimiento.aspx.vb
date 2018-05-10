Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cybSaldoMovimiento
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodBanco") = Request.Params("CodBanco")
            ViewState("SecBanco") = Request.Params("SecBanco")
            lblTitulo.Text = Request.Params("NomBanco") & Request.Params("NroCuenta")
            txtFchEmision.Text = objRutina.fechaddmmyyyy(-30)
            CargaSaldos()
        End If
    End Sub
    Private Sub CargaSaldos()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CYB_SaldoMovimiento_S"
        da.SelectCommand.Parameters.Add("@CodBanco", SqlDbType.Char, 3).Value = Viewstate("CodBanco")
        da.SelectCommand.Parameters.Add("@SecBanco", SqlDbType.Char, 2).Value = Viewstate("SecBanco")
        da.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchEmision.Text)
        Dim nReg As Integer = da.Fill(ds, "Mvtos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgMvto.DataSource = dv
        dgMvto.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s)"
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaSaldos()
    End Sub

    Private Sub dgMvto_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgMvto.ItemDataBound
        If IsNumeric(e.Item.Cells(4).Text) Then
            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            Else
                e.Item.Cells(4).ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgMvto_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgMvto.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaSaldos()
    End Sub

End Class
