Imports System
Imports System.Data
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Imports System.Data.SqlClient
Partial Class VtaVersionResumen
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Public ds As New DataSet()

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
                lblTitulo.Text = "Resumen de la Version N° " & Request.Params("NroVersion")

                Viewstate("NroPedido") = Request.Params("NroPedido")
                Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
                Viewstate("NroVersion") = Request.Params("NroVersion")
                Viewstate("FlagEdita") = Request.Params("FlagEdita")
                Viewstate("FlagPublica") = Request.Params("FlagPublica")
                Viewstate("StsVersion") = Request.Params("StsVersion")

                'Fill the DataSet with the Data in the adapters
                'search for related fields
                Dim da As New SqlDataAdapter
                da.SelectCommand = New SqlCommand
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "VTA_VersionResumen_S"
                da.SelectCommand.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
                da.SelectCommand.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
                da.SelectCommand.Parameters.Add("@NroVersion", SqlDbType.Int).Value = Viewstate("NroVersion")
                ds.Clear()
                da.Fill(ds, "tblRTB")
                txtRTB.DataBind()

            End If
        Catch eLoad As System.Exception
            lblmsg.Text = eLoad.Message()
        End Try

        ' set the string to the label
        'lblMessage.Text = txtRTB.Text

        ' enable JavaScript with this button
        ' runs the getHTML() function to set the RTB to the textbox
        ' so you can save the data to the database
        With btnSave
            .Attributes.Add("onClick", "getHTML()")
        End With
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' This will save what is in the Rich Text Box to the database

        ' set ID for save to database
        ' Replace single quotes with double quotes to format copied 
        ' text from Microsoft Word or if you put quotes in the field
        Dim strRTB As String
        Dim strRTB2 As String
        Dim strQ1 As String = """"
        Dim strQ2 As String = """"""
        strRTB = txtRTB.Text
        'Replace all commas with a space
        'strRTB2 = strRTB.Replace(strQ1, strQ2)
        strRTB2 = strRTB.Replace(strQ1, strQ2)

        ' Update the dataset and the database

        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "VTA_VersionResumen_U"
        cd.CommandType = CommandType.StoredProcedure
        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroVersion", SqlDbType.TinyInt).Value = Viewstate("NroVersion")
        cd.Parameters.Add("@Resumen", SqlDbType.Text).Value = strRTB2
        cd.Parameters.Add("@CodUsuario", SqlDbType.Text, 15).Value = Session("CodUsuario")
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
            Response.Redirect("VtaVersionFicha.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta") & _
                "&NroVersion=" & Viewstate("NroVersion"))
        End If
    End Sub

End Class
