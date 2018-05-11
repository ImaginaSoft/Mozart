Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Partial Class VtaPropuestaPrecioManual
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim wTotalSum As Double = 0
    Dim wTotalPrecio As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("DesPropuesta") = Request.Params("DesPropuesta")
            lblTitulo.Text = "Presentación de Precios Propuesta N° " & Viewstate("NroPropuesta")
            lblPropuesta.Text = Viewstate("DesPropuesta")
            CargaResumen()
            CargaPrecio()
        End If

    End Sub

    Private Sub CargaResumen()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaPrecioResumen_S", arParms)
        dgResumen.DataSource = ds
        dgResumen.DataBind()
    End Sub


    Private Sub CargaPrecio()
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@NroPedido", SqlDbType.Int)
        arParms(0).Value = Viewstate("NroPedido")
        arParms(1) = New SqlParameter("@NroPropuesta", SqlDbType.Int)
        arParms(1).Value = Viewstate("NroPropuesta")

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "VTA_PropuestaPrecioxTipo_S", arParms)
        dgPrecio.DataKeyField = "NroOrden"
        dgPrecio.DataSource = ds
        dgPrecio.DataBind()
        dgPrecio.SelectedItemStyle.Reset()
    End Sub


    Private Sub dgResumen_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgResumen.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(5).Text = "O" Then
                e.Item.Cells(1).Text = ""
            End If
        End If
    End Sub

    Sub ComputeSum(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalSum += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(5).Text = String.Format("{0:###,###,###.00}", wTotalSum)
            e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center
        End If
    End Sub

    Sub ComputeSumP(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim wTotal As Double = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "PrecioTotal"))
            wTotalPrecio += wTotal
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(4).Text = String.Format("{0:###,###,###.00}", wTotalPrecio)
            e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wPrecioxPersona As Double = 0
        Dim wCantPersonas As Integer = 0
        Dim wNroOrden As Integer = 0

        If lblNroOrden.Text.Trim.Length > 0 Then
            wNroOrden = lblNroOrden.Text
        End If

        If IsNumeric(txtPrecioxPersona.Text) Then
            wPrecioxPersona = txtPrecioxPersona.Text
        End If
        If IsNumeric(txtCantPersonas.Text) Then
            wCantPersonas = txtCantPersonas.Text
        End If

        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPrecioManual_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroOrden", SqlDbType.Int).Value = wNroOrden
        cd.Parameters.Add("@DesOrden", SqlDbType.VarChar, 100).Value = txtDesOrden.Text
        cd.Parameters.Add("@PrecioxPersona", SqlDbType.Money).Value = wPrecioxPersona
        cd.Parameters.Add("@CantPersonas", SqlDbType.Int).Value = wCantPersonas
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
            lblMsg.Text = ""
            lblNroOrden.Text = ""
            CargaPrecio()
        End If
    End Sub

    Private Sub lbtFichaPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtFichaPropuesta.Click
        Response.Redirect("VtaPropuestaFicha.aspx" & _
                "?NroPedido=" & Viewstate("NroPedido") & _
                "&NroPropuesta=" & Viewstate("NroPropuesta"))
    End Sub

    Private Sub dgPrecio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPrecio.SelectedIndexChanged
        lblNroOrden.Text = dgPrecio.Items(dgPrecio.SelectedIndex).Cells(6).Text
        txtDesOrden.Text = dgPrecio.Items(dgPrecio.SelectedIndex).Cells(1).Text
        txtPrecioxPersona.Text = dgPrecio.Items(dgPrecio.SelectedIndex).Cells(2).Text
        txtCantPersonas.Text = dgPrecio.Items(dgPrecio.SelectedIndex).Cells(3).Text
    End Sub

    Private Sub dgPrecio_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPrecio.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_PropuestaPrecioManual_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Viewstate("NroPedido")
        cd.Parameters.Add("@NroPropuesta", SqlDbType.TinyInt).Value = Viewstate("NroPropuesta")
        cd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = dgPrecio.DataKeys(e.Item.ItemIndex)
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
            lblMsg.Text = ""
            lblNroOrden.Text = ""
            CargaPrecio()
        End If
    End Sub

End Class
