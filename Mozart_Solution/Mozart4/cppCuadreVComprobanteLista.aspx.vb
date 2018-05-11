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

Partial Class cppCuadreVComprobanteLista
    Inherits System.Web.UI.Page

    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Private dv As DataView
    Dim wTotalSum As Double = 0
    Dim wUtilidadSum As Double = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion1") = Request.Params("Opcion1")
            Viewstate("Origen") = Request.Params("Origen")

            If Viewstate("Opcion1") = "Cuadre" Then
                Viewstate("NroPedido") = Request.Params("NroPedido")
            End If
            Viewstate("IdRegPend") = Request.Params("IdRegPend")
            Viewstate("IdRegComp") = Request.Params("IdRegComp")
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
            Viewstate("CodMonedaPedidos") = Request.Params("CodMonedaPedidos")
            CargaDocumentos()
            'Viewstate("CodMoneda") = Request.Params("CodMoneda")
        End If
    End Sub
    Private Sub CargaDocumentos()
        Dim da As New SqlDataAdapter()
        da.SelectCommand = New SqlCommand()
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_ComprobantesAuxiliares_S"
        da.SelectCommand.Parameters.Add("@IdReg", SqlDbType.Char, 26).Value = Viewstate("IdRegComp")

        Dim ds As New DataSet()
        Dim nReg As Integer = da.Fill(ds, "Documentos")

        'se instancia un DataView para que se puedan ordenar los datos
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgDocumento.DataSource = dv
        dgDocumento.DataBind()

        'lblmsg.Text = CStr(nReg) + " Pendiente(s) de cuadre"
    End Sub
    Private Sub dgDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDocumento.SelectedIndexChanged
        If Viewstate("Opcion1") = "Cuadre" Then
            Response.Redirect("cppCuadreUnComprobante.aspx" & _
                                "?IdRegPend=" & Viewstate("IdRegPend") & _
                                "&IdRegComp=" & Viewstate("IdRegComp") & _
                                "&NroDoc=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(5).Text & _
                                "&CodProveedor=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(6).Text & _
                                "&NroMonto=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(12).Text & _
                                "&CodMoneda=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text & _
                                "&NroPedido=" & Viewstate("NroPedido") & _
                                "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos") & _
                                "&Origen=" & Viewstate("Origen") & _
                                "&Opcion1=" & Viewstate("Opcion1") & _
                                "&Opcion=" & "Modificar")
        Else
            Response.Redirect("cppCuadreUnComprobante.aspx" & _
                                "?IdRegPend=" & Viewstate("IdRegPend") & _
                                "&IdRegComp=" & Viewstate("IdRegComp") & _
                                "&NroDoc=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(5).Text & _
                                "&CodProveedor=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(6).Text & _
                                "&NroMonto=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(12).Text & _
                                "&CodMoneda=" & dgDocumento.Items(dgDocumento.SelectedIndex).Cells(13).Text & _
                                "&CodMonedaPedidos=" & Viewstate("CodMonedaPedidos") & _
                                "&Origen=" & Viewstate("Origen") & _
                                "&Opcion=" & "Modificar")
        End If

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim RegError As Integer = 0
        Dim objItem As DataGridItem

        For Each objItem In dgDocumento.Items
            If objItem.ItemType <> ListItemType.Header And objItem.ItemType <> ListItemType.Footer And objItem.ItemType <> ListItemType.Pager Then
                If objItem.Cells(5).Text().Trim.Length = 0 Then
                    lblmsg.Visible = True
                    lblmsg.Text = "Error: Completar datos de los Pre-Comprobantes."
                    Return
                Else
                    lblmsg.Visible = False
                End If
            End If
        Next
        'Grabamos en Grupo
        Dim cd As New SqlCommand()
        cd.Connection = cn
        cd.CommandText = "CPP_CuadreComprobantesVarios_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter()
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@IdRegPend", SqlDbType.Char, 25).Value = Viewstate("IdRegPend")
        cd.Parameters.Add("@IdRegComp", SqlDbType.Char, 25).Value = Viewstate("IdRegComp")
        cd.Parameters.Add("@TipoSistema", SqlDbType.Char, 1).Value = CStr(objItem.Cells(1).Text())
        cd.Parameters.Add("@CodMoneda", SqlDbType.Char, 1).Value = Viewstate("CodMonedaPedidos")
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@Origen", SqlDbType.Char, 1).Value = Viewstate("Origen")
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
        If lblmsg.Text = "OK" Then
            If Viewstate("Opcion1") = "Cuadre" Then
                Response.Redirect("cpcPedidoLiquidacion.aspx" & _
                                  "?NroPedido=" & Viewstate("NroPedido") & _
                                  "&CodMoneda=" & Viewstate("CodMonedaPedidos"))

            Else
                Response.Redirect("cppCuadreObligaciones.aspx" & _
                        "?CodProveedor=" & Viewstate("CodProveedor"))
            End If
        Else
            lblmsg.Visible = True
        End If
    End Sub

End Class
