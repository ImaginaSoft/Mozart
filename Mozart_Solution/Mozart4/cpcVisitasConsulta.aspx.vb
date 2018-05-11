Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cpcVisitasConsulta
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

            If Viewstate("Opcion") = "Consulta" Then
                txtFchInicial.Text = Request.Params("FchIni")
                txtFchFinal.Text = Request.Params("FchFin")
                If Request.Params("TipoVisita") = "E" Then
                    rbEntrada.Checked = True
                    rbSalida.Checked = False
                Else
                    rbEntrada.Checked = False
                    rbSalida.Checked = True
                End If
            Else
                txtFchInicial.Text = ObjRutina.fechaddmmyyyy(-31)
                txtFchFinal.Text = ObjRutina.fechaddmmyyyy(15)
            End If
            cargadatos()
        End If
    End Sub

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        CargaDatos()
    End Sub
    Private Sub cargadatos()
        Dim wTipoVisita As String

        If rbEntrada.Checked Then
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
        da.SelectCommand.CommandText = "CPC_VisitaConsulta_S"
        da.SelectCommand.Parameters.Add("@FchIni", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        da.SelectCommand.Parameters.Add("@TipoVisita", SqlDbType.Char, 1).Value = wTipoVisita
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Documentos")
        dgLista.DataSource = ds.Tables("Documentos")
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()
        If wTipoVisita = "E" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Entrada"
        End If
        If wTipoVisita = "S" Then
            lblmsg.Text = CStr(nReg) + " Visitas(s) de Salida"
        End If


    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then
            If Trim(e.Item.Cells(7).Text) = "N" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub dgLista_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        cargadatos()
    End Sub

    Private Sub txtFchInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFchInicial.TextChanged

    End Sub



End Class
