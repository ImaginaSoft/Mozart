Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class bolStockBoletos
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("Forma") = Request.Params("Forma")
            Viewstate("SecIni") = Request.Params("SecIni")
            Viewstate("SecFinal") = Request.Params("SecFinal")
            CargaStockBoletos()
        End If
    End Sub

    Private Sub CargaStockBoletos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_StockBoletos_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        da.SelectCommand.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = Viewstate("Forma")
        da.SelectCommand.Parameters.Add("@SerInicial", SqlDbType.Int).Value = Viewstate("SecIni")
        da.SelectCommand.Parameters.Add("@SerFinal", SqlDbType.Int).Value = Viewstate("SecFinal")

        Dim nReg As Integer = da.Fill(ds, "StockBoletos")
        dgStock.DataSource = ds.Tables("StockBoletos")
        dgStock.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"

    End Sub
    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_StockBoletos_D"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        da.SelectCommand.Parameters.Add("@Forma", SqlDbType.Char, 4).Value = Viewstate("Forma")
        da.SelectCommand.Parameters.Add("@SerInicial", SqlDbType.Int).Value = Viewstate("SecIni")
        da.SelectCommand.Parameters.Add("@SerFinal", SqlDbType.Int).Value = Viewstate("SecFinal")

        Dim nReg As Integer = da.Fill(ds, "StockBoletos")
        dgStock.DataSource = ds.Tables("StockBoletos")
        dgStock.DataBind()

        Response.Redirect("bolStock.aspx" & _
        "?FchIngreso=" & 0)

    End Sub

End Class
