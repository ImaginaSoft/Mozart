Imports System
Imports System.Data
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Data.SqlClient

Partial Class tabParametroDetalle
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public dsEdit As New DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        ' Take what is in the Database and post it in the label 
        ' and the Rich Text box for editing

        ' If IsPostBack=False then page is loading for first time,
        ' and we need to bind the controls
        Try
            If Not IsPostBack Then
                Viewstate("NomCampo") = Request.Params("NomCampo")
                lblDescCampo.Text = Request.Params("DescCampo")
                txtValor.Text = Request.Params("ValorCampo")

                'Fill the DataSet with the Data in the adapters
                'search for related fields
                Dim da As New SqlDataAdapter
                da.SelectCommand = New SqlCommand
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "TAB_Control_S"
                da.SelectCommand.Parameters.Add("@NomCampo", SqlDbType.VarChar, 50).Value = Request.Params("NomCampo")
                dsEdit.Clear()
                da.Fill(dsEdit, "tblRTB")
                FreeTextBox1.DataBind()

            End If
        Catch eLoad As System.Exception
            lblmsg.Text = eLoad.Message()
        End Try
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Update the dataset and the database
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "TAB_Control_U"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NomCampo", SqlDbType.Char, 50).Value = Viewstate("NomCampo")
        cd.Parameters.Add("@ValorCampo", SqlDbType.Money).Value = txtValor.Text
        cd.Parameters.Add("@TextoCampo", SqlDbType.Text).Value = FreeTextBox1.Text
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblmsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblmsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblmsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblmsg.Text) = "OK" Then
            Response.Redirect("tabParametro.aspx")
        End If
    End Sub

End Class
