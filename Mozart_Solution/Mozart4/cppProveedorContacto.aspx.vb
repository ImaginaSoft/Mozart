Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class cppProveedorContacto
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Private dv As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ViewState("CodProveedor") = Request.Params("CodProveedor")
            ViewState("NomProveedor") = Request.Params("NomProveedor")

            lblTitulo.Text = "Contactos de " & ViewState("NomProveedor")
            rbActivo.Checked = True
            CargaDatos()
        End If

    End Sub

    Private Sub CargaDatos()
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "CPP_Contacto_S"
        da.SelectCommand.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        Dim ds As New DataSet
        Dim nReg As Integer = da.Fill(ds, "TCONTACTO")
        dgLista.DataKeyField = "KeyReg"

        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgLista.DataSource = dv
        dgLista.DataBind()

        lblMsg.Text = CStr(nReg) + " Contacto(s)"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim wEstado As String
        Dim wTipoContacto As String
        If rbActivo.Checked Then
            wEstado = "A"
        Else
            wEstado = "I"
        End If
        If rbActualiza.Checked Then
            wTipoContacto = "T" 'Actualiza las reservas
        Else
            wTipoContacto = "C" 'Solo Consulta
        End If

        Dim wNroOrden As Integer = 0
        If IsNumeric(txtNroOrden.Text) Then
            wNroOrden = txtNroOrden.Text
        End If

        Dim cd As New SqlCommand

        cd.Connection = cn
        cd.CommandText = "CPP_Contacto_I"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = txtCodigo.Text
        cd.Parameters.Add("@NomContacto", SqlDbType.VarChar, 50).Value = txtNombre.Text
        cd.Parameters.Add("@EmailContacto", SqlDbType.VarChar, 50).Value = txtEmail.Text
        cd.Parameters.Add("@Telefono1", SqlDbType.VarChar, 25).Value = txtTelefono.Text
        cd.Parameters.Add("@StsContacto", SqlDbType.Char, 1).Value = wEstado
        cd.Parameters.Add("@NroOrden", SqlDbType.TinyInt).Value = wNroOrden
        cd.Parameters.Add("@TipoContacto", SqlDbType.Char, 1).Value = wTipoContacto
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
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub


    Private Sub dgLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged
        Dim wEstado As String
        Dim wTipoContacto As String

        txtCodigo.Text = dgLista.Items(dgLista.SelectedIndex).Cells(1).Text
        txtNombre.Text = dgLista.Items(dgLista.SelectedIndex).Cells(2).Text
        txtEmail.Text = dgLista.Items(dgLista.SelectedIndex).Cells(4).Text
        txtTelefono.Text = dgLista.Items(dgLista.SelectedIndex).Cells(5).Text
        txtNroOrden.Text = dgLista.Items(dgLista.SelectedIndex).Cells(7).Text
        wEstado = dgLista.Items(dgLista.SelectedIndex).Cells(6).Text
        wTipoContacto = dgLista.Items(dgLista.SelectedIndex).Cells(8).Text
        If wEstado = "Inactivo" Then
            rbInactivo.Checked = True
            rbActivo.Checked = False
        Else
            rbActivo.Checked = True
            rbInactivo.Checked = False
        End If
        If wTipoContacto = "Actualiza" Then
            rbActualiza.Checked = True
            rbConsulta.Checked = False
        Else
            rbActualiza.Checked = False
            rbConsulta.Checked = True
        End If
    End Sub

    Private Sub dgLista_DeleteCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        Dim cd As New SqlCommand
        cd.Connection = cn
        cd.CommandText = "CPP_Contacto_D"
        cd.CommandType = CommandType.StoredProcedure

        Dim pa As New SqlParameter
        pa = cd.Parameters.Add("@MsgTrans", SqlDbType.VarChar, 150)
        pa.Direction = ParameterDirection.Output
        pa.Value = ""
        cd.Parameters.Add("@CodProveedor", SqlDbType.Int).Value = Viewstate("CodProveedor")
        cd.Parameters.Add("@CodContacto", SqlDbType.Char, 15).Value = Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 15)
        Try
            cn.Open()
            cd.ExecuteNonQuery()
            lblMsg.Text = cd.Parameters("@MsgTrans").Value
        Catch ex1 As System.Data.SqlClient.SqlException
            lblMsg.Text = ObjRutina.fncErroresSQL(ex1.Errors)
            If lblMsg.Text = "547" Then
                lblMsg.Text = "Mensaje: Si desea eliminar al contacto, primero debe eliminar todos las reservas asociados"
            End If
        Catch ex2 As System.Exception
            lblMsg.Text = "Error:" & ex2.Message
        End Try
        cn.Close()
        If Trim(lblMsg.Text) = "OK" Then
            Me.CargaDatos()
        End If

    End Sub

    Private Sub dgLista_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.CancelCommand
        Response.Redirect("cppProveedorContactoClave.aspx" & _
                  "?CodProveedor=" & Viewstate("CodProveedor") & _
                  "&NomProveedor=" & Viewstate("NomProveedor") & _
                  "&CodContacto=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 1, 15) & _
                  "&NomContacto=" & Mid(dgLista.DataKeys(e.Item.ItemIndex), 16, 50))
    End Sub

    Private Sub dgLista_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgLista.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub rbActualiza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActualiza.CheckedChanged
        rbActualiza.Checked = True
        rbConsulta.Checked = False
    End Sub

    Private Sub rbConsulta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConsulta.CheckedChanged
        rbActualiza.Checked = False
        rbConsulta.Checked = True
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(6).Text.Trim = "Inactivo" Then
                e.Item.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

End Class
