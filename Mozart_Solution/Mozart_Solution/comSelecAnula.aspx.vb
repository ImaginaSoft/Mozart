Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Mail

Imports cmpTabla
Imports cmpRutinas
Imports cmpNegocio



Partial Class comSelecAnula
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))

    Private dv As DataView
    Dim objRutina As New clsRutinas
    Dim objComprobante As New clsComprobante

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            ViewState("TipoSistema") = Request.Params("TipoSistema")
            ViewState("NroLiqCom") = Request.Params("NroLiqCom")
            CargaDocumentos()
        End If
    End Sub


    'Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
    '    CargaDocumentos()
    'End Sub

    Private Sub CargaDocumentos()
        Dim ds As New DataSet
        ds = objComprobante.CompxNroLiqCom(ViewState("TipoSistema"), ViewState("NroLiqCom"))
        'dgDocumento.DataKeyField = "Correlativo"
        dv = New DataView(ds.Tables(0))
        dv.Sort = ViewState("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub dgDocumento_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDocumento.DeleteCommand
        lblmsg.Text = objComprobante.Borrar(dgDocumento.DataKeys(e.Item.ItemIndex), "", "", Session("CodUsuario"))
        If lblmsg.Text.Trim = "OK" Then
            lblmsg.CssClass = "msg"
            CargaDocumentos()
        Else
            lblmsg.CssClass = "error"
        End If
    End Sub

    Private Sub dgDocumento_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgDocumento.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDocumentos()
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "COM_ComprobanteElimina_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 500)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = ViewState("TipoSistema")
        cd.Parameters.Add("@NroLiqCom", SqlDbType.Int).Value = ViewState("NroLiqCom")
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

        If Trim(lblmsg.Text.Trim) = "OK" Then
            Response.Redirect("comSelecComprobantes.aspx")
        End If
    End Sub
End Class
