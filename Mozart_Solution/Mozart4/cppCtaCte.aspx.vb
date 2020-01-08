Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cppCtaCte
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            txtFchEmision.Text = objRutina.fechaddmmyyyy(-30)
        End If
    End Sub
    Private Sub CargaCtaCte()
        Dim wMoneda, wFecha As String
        If rbDolar.Checked Then
            wMoneda = "D"
        Else
            wMoneda = "S"
        End If
        wFecha = ObjRutina.fechayyyymmdd(txtFchEmision.Text)

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_CtaCte_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        da.SelectCommand.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = wMoneda
        da.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Char, 8).Value = wFecha
        Dim nReg As Integer = da.Fill(ds, "CtaCte")
        dgCtaCte.DataSource = ds.Tables("CtaCte")
        dgCtaCte.DataBind()
        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CargaCtaCte()
    End Sub


    Private Sub dgCtaCte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCtaCte.ItemDataBound
        If IsNumeric(e.Item.Cells(4).Text) Then
            If e.Item.Cells(4).Text > 0 Then
                e.Item.Cells(4).ForeColor = Color.Red
            ElseIf e.Item.Cells(4).Text < 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            End If
        End If
        If IsNumeric(e.Item.Cells(5).Text) Then
            If e.Item.Cells(5).Text > 0 Then
                e.Item.Cells(5).ForeColor = Color.Red
            ElseIf e.Item.Cells(5).Text < 0 Then
                e.Item.Cells(5).ForeColor = Color.Blue
            End If
        End If
    End Sub

End Class
