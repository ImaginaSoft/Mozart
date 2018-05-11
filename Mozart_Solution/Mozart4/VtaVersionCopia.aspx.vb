Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaVersionCopia
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            txtNroDiaInicio.Text = "1"
            CargaPropuestas()
        End If

    End Sub

    Private Sub CargaPropuestas()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "VTA_PropuestaTitulo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = New SqlParameter("@NroPedido", System.Data.SqlDbType.Int)
        pa.Value = Viewstate("NroPedido")
        da.SelectCommand.Parameters.Add(pa)
        da.Fill(ds, "Propuesta")
        ddlPropuesta.DataSource = ds.Tables("Propuesta")
        ddlPropuesta.DataBind()
        If ddlPropuesta.Items.Count() > 0 Then
            txtNroPropuesta.Text = Mid(ddlPropuesta.SelectedItem.Value, 11, 2)
        End If

    End Sub

    Private Sub ddlPropuesta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPropuesta.SelectedIndexChanged
        txtNroPropuesta.Text = Mid(ddlPropuesta.SelectedItem.Value, 11, 2)
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        lblerror1.Text = ""
        lblerror2.Text = ""
        lblMsg.Text = ""
        If Len(Trim(txtNroPropuesta.Text)) = 0 Then
            lblerror1.Text = "Dato obligatorio"
            Return
        End If
        If Not IsNumeric(txtNroPropuesta.Text) Then
            lblerror1.Text = "Nro. Propuesta es dato númerico"
            Return
        End If

        If Len(Trim(txtNroDiaInicio.Text)) = 0 Then
            txtNroDiaInicio.Text = "1"
        End If
        If Not IsNumeric(txtNroDiaInicio.Text) Then
            lblerror2.Text = "Día es dato númerico"
            Return
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPropuesta_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter

        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        pa = cd.Parameters.Add("@NroPropuestaOut", SqlDbType.Int)
        pa.Direction = ParameterDirection.Output
        pa.Value = 0

        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = Viewstate("CodCliente")
        cd.Parameters.Add("@NroPedidoOrigen", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuestaOrigen", SqlDbType.Int).Value = txtNroPropuesta.Text
        cd.Parameters.Add("@NroDiaInicio", SqlDbType.Int).Value = CInt(txtNroDiaInicio.Text)
        cd.Parameters.Add("@CodUsuario", SqlDbType.Char, 15).Value = Session("CodUsuario")
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = "Error:" & ex1.Message
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()

        If Trim(lblMsg.Text) = "OK" Then
            Response.Redirect("VtaPedidoFicha.aspx" & _
                              "?NroPedido=" & Viewstate("NroPedido") & _
                             "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub


End Class
