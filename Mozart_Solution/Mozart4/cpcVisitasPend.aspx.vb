Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cpcVisitasPend
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "Reprograma" Then
                txtFchInicial.Text = Request.Params("FchIni")
                txtFchFinal.Text = Request.Params("FchFin")
                If Request.Params("TipoVisita") = "E" Then
                    rbLlegada.Checked = True
                    rbSalida.Checked = False
                Else
                    rbLlegada.Checked = False
                    rbSalida.Checked = True
                End If
                If Request.Params("CodVendedor") = "Todos" Then
                    CargaVendedor("", False)
                Else
                    CargaVendedor(Request.Params("CodVendedor"), True)
                End If

            Else
                txtFchInicial.Text = ObjRutina.fechaddmmyyyy(0)
                txtFchFinal.Text = ObjRutina.fechaddmmyyyy(15)
                CargaVendedor(" ", False)
            End If
            If ddlVendedor.SelectedItem.Value = "Todos" Then
                CargaVisitasTodos()
            Else
                CargaVisitasResponsable()
            End If
        End If
    End Sub

    Private Sub CargaVendedor(ByVal pCodVendedor As String, ByVal pFind As Boolean)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_VendedorActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Vendedor")
        ddlVendedor.DataSource = ds.Tables("Vendedor")
        ddlVendedor.DataBind()
        ddlVendedor.Items.Insert(0, New ListItem("Todos"))
        If pFind Then
            ddlVendedor.Items.FindByValue(pCodVendedor).Selected = True
        Else
            ddlVendedor.Items.FindByValue("Todos").Selected = True
        End If
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        If ddlVendedor.SelectedItem.Value = "Todos" Then
            CargaVisitasTodos()
        Else
            CargaVisitasResponsable()
        End If
    End Sub
    Private Sub CargaVisitasTodos()
        Dim wTipoVisita As String

        If rbLlegada.Checked Then
            wTipoVisita = "E"
        Else
            If rbSalida.Checked Then
                wTipoVisita = "S"
            End If
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_VisitaPendientes_S"
        da.SelectCommand.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        da.SelectCommand.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = wTipoVisita
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgLista.DataKeyField = "NroPedido"
        dgLista.DataSource = ds.Tables("Documentos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()

        If wTipoVisita = "E" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Entrada"
        ElseIf wTipoVisita = "S" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Salida"
        End If
    End Sub
    Private Sub CargaVisitasResponsable()
        Dim wTipoVisita As String

        If rbLlegada.Checked Then
            wTipoVisita = "E"
        ElseIf rbSalida.Checked Then
            wTipoVisita = "S"
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPC_VisitaPendxResponsable_S"
        da.SelectCommand.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = objRutina.fechayyyymmdd(txtFchFinal.Text)
        da.SelectCommand.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = wTipoVisita
        da.SelectCommand.Parameters.Add("@CodResponsable", SqlDbType.Char, 15).Value = ddlVendedor.SelectedItem.Value
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgLista.DataKeyField = "NroPedido"
        dgLista.DataSource = ds.Tables("Documentos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        If wTipoVisita = "E" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Entrada"
        ElseIf wTipoVisita = "S" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Salida"
        End If
    End Sub
    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Response.Redirect("cpcVisitasPendCompleta.aspx" & _
        "?NroPedido=" & dgLista.Items(dgLista.SelectedIndex).Cells(9).Text & _
        "&CodResponsable=" & dgLista.Items(dgLista.SelectedIndex).Cells(5).Text & _
        "&CodVendedor=" & ddlVendedor.SelectedItem.Value & _
        "&TipoVisita=" & dgLista.Items(dgLista.SelectedIndex).Cells(6).Text & _
        "&FchIni=" & txtFchInicial.Text & _
        "&FchFin=" & txtFchFinal.Text & _
        "&Opcion=" & "Reprograma")
    End Sub
    Private Sub dgLista_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        Dim wTipoVisita As String

        If rbLlegada.Checked Then
            wTipoVisita = "E"
        ElseIf rbSalida.Checked Then
            wTipoVisita = "S"
        End If
        If lblCodResponsable.Text.Trim.Length = 0 Then
            lblCodResponsable.Text = "Todos"
        End If
        Response.Redirect("cpcVisitasPendReprograma.aspx" & _
               "?NroPedido=" & CInt(dgLista.DataKeys(e.Item.ItemIndex)) & _
               "&CodVendedor=" & lblCodResponsable.Text & _
               "&TipoVisita=" & wTipoVisita & _
               "&FchIni=" & txtFchInicial.Text & _
               "&FchFin=" & txtFchFinal.Text & _
               "&Opcion=" & "Reprograma")
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        If ddlVendedor.SelectedItem.Value = "Todos" Then
            CargaVisitasTodos()
        Else
            CargaVisitasResponsable()
        End If
    End Sub

    Private Sub ddlVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlVendedor.SelectedIndexChanged
        If ddlVendedor.Items.Count > 0 Then
            lblCodResponsable.Text = ddlVendedor.SelectedItem.Value
        End If
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If e.Item.Cells(4).Text.Trim.Length > 0 Then
                e.Item.Cells(4).ForeColor = Color.Blue
            End If
            If e.Item.Cells(4).Text.Trim.Length = 0 Then
                e.Item.Cells(0).Text = ""
            End If
        End If
    End Sub


End Class
