Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class bolStock
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            If Request.Params("FchIngreso").Trim.Length = 8 Then
                txtFchIngreso.Text = Mid(Request.Params("FchIngreso"), 7, 2) & "-" & _
                                     Mid(Request.Params("FchIngreso"), 5, 2) & "-" & _
                                     Mid(Request.Params("FchIngreso"), 1, 4)
                CargaStock(Request.Params("FchIngreso"))
            Else
                txtFchIngreso.Text = ObjRutina.fechaddmmyyyy(0)
            End If

        End If
    End Sub


    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaStock(txtFchIngreso.Text.Substring(6, 4) + txtFchIngreso.Text.Substring(3, 2) + txtFchIngreso.Text.Substring(0, 2))
    End Sub

    Private Sub CargaStock(ByVal pFchIngreso As String)
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        Dim ds As New DataSet()
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "BOL_Stock_S"
        da.SelectCommand.Parameters.Add("@FchIngreso", SqlDbType.Char, 8).Value = pFchIngreso
        Dim nReg As Integer = da.Fill(ds, "Stock")
        dgStock.DataSource = ds.Tables("Stock")
        dgStock.DataBind()

        lblmsg.Text = CStr(nReg) + " Registro(s) encontrado(s)"

    End Sub

    Private Sub dgStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgStock.SelectedIndexChanged
        Response.Redirect("bolStockBoletos.aspx" & _
        "?CodProveedor=" & dgStock.Items(dgStock.SelectedIndex).Cells(8).Text & _
        "&Forma=" & dgStock.Items(dgStock.SelectedIndex).Cells(3).Text & _
        "&SecIni=" & dgStock.Items(dgStock.SelectedIndex).Cells(4).Text & _
        "&SecFinal=" & dgStock.Items(dgStock.SelectedIndex).Cells(5).Text)
    End Sub

End Class
