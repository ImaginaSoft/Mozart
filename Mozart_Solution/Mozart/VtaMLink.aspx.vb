Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class VtaMLink
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            CargaCiudadS("")
            CargaLinkS("")
        End If
    End Sub

    Private Sub CargaCiudadS(ByVal pCodCiudad As String)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_CiudadLink_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet
        da.Fill(ds, "Ciudad")
        ddlCiudad.DataSource = ds.Tables("Ciudad")
        ddlCiudad.DataBind()
        If pCodCiudad.Trim.Length > 0 Then
            ddlCiudad.Items.FindByValue(pCodCiudad).Selected = True
        End If

    End Sub

    Private Sub CargaLinkS(ByVal pCodLink As String)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "TAB_LinkActivo_S"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet
        da.Fill(ds, "Links")
        ddlTipoLink.DataSource = ds.Tables("Links")
        ddlTipoLink.DataBind()
        If pCodLink.Trim.Length > 0 Then
            ddlTipoLink.Items.FindByValue(pCodLink).Selected = True
        End If

    End Sub

    Private Sub dgMLink_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgMLink.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "VTA_MLink_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 200)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodLink", SqlDbType.SmallInt).Value = dgMLink.DataKeys(e.Item.ItemIndex)
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If lblMsg.Text = "547" Then
                lblMsg.Text = "Si desea eliminar Link, primero debe eliminar todos en Servicios, Propuesta y Versión"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Me.CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()

        Dim wciudad, wEstado As String
        Dim wlink As Double

        If ddlCiudad.Items.Count = 0 Then
            wciudad = ""
        Else
            wciudad = ddlCiudad.SelectedItem.Value
        End If
        If ddlTipoLink.Items.Count = 0 Then
            wlink = 0
        Else
            wlink = ddlTipoLink.SelectedItem.Value
        End If

        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "VTA_MlinkCodLink_S"
        da.SelectCommand.Parameters.Add("@CodTipoLink", SqlDbType.SmallInt).Value = wlink
        da.SelectCommand.Parameters.Add("@CodCiudad", SqlDbType.Char, 10).Value = wciudad

        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "TLink")
        dgMLink.DataKeyField = "CodLink"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgMLink.DataSource = dv
        dgMLink.DataBind()

        lblMsg.Text = CStr(nReg) + " Link(s) encontrada(s)"
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Me.CargaDatos()
    End Sub

    Private Sub dgMLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgMLink.SelectedIndexChanged
        Response.Redirect("VtaMLinkNuevo.aspx" & _
        "?Opcion=" & "Modificar" & _
        "&CodLink=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(1).Text)
        ' & _
        '       "&TiTulo=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(3).Text & _
        '      "&Estado=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(4).Text & _
        '     "&Telefono1=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(5).Text & _
        '    "&NomPagina=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(6).Text & _
        '   "&CodCiudad=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(8).Text & _
        '  "&CodTipoLink=" & dgMLink.Items(dgMLink.SelectedIndex).Cells(9).Text)
    End Sub


    Private Sub lbtNuevoLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoLink.Click
        Response.Redirect("VtaMLinkNuevo.aspx" & _
                        "?Opcion=" & "Nuevo")
    End Sub

    Private Sub dgMLink_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgMLink.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

End Class
