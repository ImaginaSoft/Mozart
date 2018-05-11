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

Partial Class vtaTareaResumen
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Session("CodUsuario") = "" Then
        'Response.Redirect("segSesion.aspx")
        'End If

        'If Session("CodUsuario") = "" Then
        'Response.Redirect("segSesion.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtFchInicial.Text = ObjRutina.fechaddmmyyyy(0)
            txtFchFinal.Text = ObjRutina.fechaddmmyyyy(30)
            EditaNumTareas()
        End If
    End Sub
    Private Sub EditaNumTareas()
        Dim cd As New SqlCommand
        Dim dr As SqlDataReader
        cd.Connection = cn
        cd.CommandText = "VTA_TareaResumenNum_S"
        cd.CommandType = CommandType.StoredProcedure
        cd.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        cd.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        Try
            cn.Open()
            dr = cd.ExecuteReader
            Do While dr.Read()
                lblColumnas.Text = dr.GetValue(dr.GetOrdinal("Cantidad"))
            Loop
            dr.Close()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        EditaNumTareas()

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_TareaResumen_S"
        da.SelectCommand.Parameters.Add("@FchInicio", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchInicial.Text)
        da.SelectCommand.Parameters.Add("@FchFin", SqlDbType.Char, 8).Value = ObjRutina.fechayyyymmdd(txtFchFinal.Text)
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "Tareas")
        dgLista.DataSource = ds.Tables("Tareas")
        dgLista.DataBind()

        lblmsg.Text = "Del " & txtFchInicial.Text & " al " & txtFchFinal.Text
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        Dim wcol, i As Integer

        'Obtenemos el Nº de columnas
        i = 1
        wcol = lblColumnas.Text
        'If IsDBNull(e.Item.Cells(0).Text) Then
        If e.Item.Cells(0).Text.Trim = "01-01-1900" Then
            e.Item.Cells(0).Text = "Total"
            e.Item.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(0).Font.Bold = True
            e.Item.BackColor = Color.LightBlue
        End If
        If e.Item.Cells(0).Text.Trim = "02-01-1900" Then
            e.Item.Cells(0).Text = "Vencidos"
            e.Item.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Item.Cells(0).Font.Bold = True
            e.Item.ForeColor = Color.Red
        End If
        If e.Item.ItemType = ListItemType.Item Or _
                 e.Item.ItemType = ListItemType.AlternatingItem Then


            Do While i <= wcol

                'If e.Item.Cells(0).Text.Trim = "Total" Then
                'e.Item.Cells(0).BackColor = Color.LightBlue
                'e.Item.Cells(i).BackColor = Color.LightBlue
                'End If
                'If e.Item.Cells(0).Text.Trim = "Vencidos" Then
                'e.Item.Cells(0).BackColor = Color.LightBlue
                'e.Item.Cells(i).BackColor = Color.LightBlue
                'End If
                If e.Item.Cells(i).Text.Trim.Length > 0 Then
                    If IsNumeric(e.Item.Cells(i).Text) Then
                        If Trim(e.Item.Cells(i).Text) = 0 Then
                            e.Item.Cells(i).Text = ""
                        Else
                            If e.Item.Cells(i).Text > 25 And e.Item.Cells(0).Text.Trim <> "Total" Then
                                e.Item.Cells(i).ForeColor = Color.Red
                            End If
                            e.Item.Cells(i).Text = String.Format("{0:###,###,###,##0.00}", e.Item.Cells(i).Text)
                            e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Center
                        End If
                    End If
                End If
                i = i + 1
            Loop

        End If

        'If e.Item.Cells(0).Text = 1 Then
        'e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Right
        'e.Item.Cells(1).Text = "Total"
        'End If
        'e.Item.Cells(0).Visible = False

    End Sub

End Class
