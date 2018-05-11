Imports cmpTabla

Imports System.Data
Partial Class TabTipoDocumento
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim objTipoDocumento As New clsTipoDocumento

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            ddlTipoSistema.Items.Insert(0, New ListItem("Banco"))
            ddlTipoSistema.Items.Insert(1, New ListItem("Cliente"))
            ddlTipoSistema.Items.Insert(2, New ListItem("Proveedor"))
            ddlTipoSistema.Items.Insert(3, New ListItem("HPersonal"))
            CargaSistema("Banco")
            CargaDatos()
        End If
    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objTipoDocumento.Cargar()
        dgTipoDocumento.DataKeyField = "keyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgTipoDocumento.DataSource = dv
        dgTipoDocumento.DataBind()

        lblMsg.Text = CStr(dgTipoDocumento.Items.Count) + " Tipos de Documento"
    End Sub

    Private Sub dgTipoDocumento_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgTipoDocumento.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If rbActivo.Checked Then
            objTipoDocumento.StsTipoDocumento = "A"
        Else
            objTipoDocumento.StsTipoDocumento = "I"
        End If

        If rbAbono.Checked Then
            objTipoDocumento.TipoOperacion = "A"
        Else
            objTipoDocumento.TipoOperacion = "C"
        End If

        If rbsi.Checked Then
            objTipoDocumento.AfectaCaja = "Si"
        Else
            objTipoDocumento.AfectaCaja = "No"
        End If

        If TipoDocSunatSI.Checked Then
            objTipoDocumento.TipoDocSunat = "S"
        Else
            objTipoDocumento.TipoDocSunat = "N"
        End If

        If rbtComiSI.Checked Then
            objTipoDocumento.FlagComisionTC = "S"
        Else
            objTipoDocumento.FlagComisionTC = "N"
        End If

        objTipoDocumento.TipoSistema = ddlTipoSistema.SelectedItem.Value.Substring(0, 1)
        objTipoDocumento.TipoDocumento = txtTipoDocuemnto.Text
        objTipoDocumento.NomDocumento = txtNomDocumento.Text
        objTipoDocumento.DocSunat = txtDocSunat.Text
        objTipoDocumento.CodProveedorTC = txtCodProveedorTC.Text
        objTipoDocumento.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objTipoDocumento.Grabar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInactivo.CheckedChanged
        rbActivo.Checked = False
        rbInactivo.Checked = True
    End Sub

    Private Sub rbActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rbInactivo.Checked = False
        rbActivo.Checked = True
    End Sub

    Private Sub dgTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTipoDocumento.SelectedIndexChanged
        Dim westado, woperacion, wbancos, wtiposistema, wtipodocsunat As String

        wtiposistema = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(1).Text
        woperacion = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(4).Text
        wbancos = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(5).Text
        westado = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(6).Text
        wtipodocsunat = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(7).Text

        'Tipo de Sistema
        If Mid(wtiposistema, 1, 1) = "P" Then
            CargaSistema("Proveedor")
        ElseIf Mid(wtiposistema, 1, 1) = "B" Then
            CargaSistema("Banco")
        ElseIf Mid(wtiposistema, 1, 1) = "C" Then
            CargaSistema("Cliente")
        ElseIf Mid(wtiposistema, 1, 1) = "H" Then
            CargaSistema("HPersonal")
        End If

        'Estado
        If westado = "Inactivo" Then
            rbActivo.Checked = False
            rbInactivo.Checked = True
        Else
            rbInactivo.Checked = False
            rbActivo.Checked = True
        End If

        'Tipo Operación
        If woperacion = "Cargo" Then
            rbAbono.Checked = False
            rbCargo.Checked = True
        Else
            rbCargo.Checked = False
            rbAbono.Checked = True
        End If

        'Afecta Bancos
        If wbancos = "Si" Then
            rbno.Checked = False
            rbsi.Checked = True
        Else
            rbsi.Checked = False
            rbno.Checked = True
        End If

        'Tipo documento sunat
        If wtipodocsunat = "S" Then
            TipoDocSunatNO.Checked = False
            TipoDocSunatSI.Checked = True
        Else
            TipoDocSunatNO.Checked = True
            TipoDocSunatSI.Checked = False
        End If

        If dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(9).Text.Trim = "S" Then
            rbtComiSI.Checked = True
            rbtComiNO.Checked = False
        Else
            rbtComiSI.Checked = False
            rbtComiNO.Checked = True
        End If

        txtTipoDocuemnto.Text = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(2).Text.Trim
        txtNomDocumento.Text = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(3).Text.Trim
        txtDocSunat.Text = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(8).Text.Trim
        txtCodProveedorTC.Text = dgTipoDocumento.Items(dgTipoDocumento.SelectedIndex).Cells(10).Text.Trim
    End Sub

    Private Sub CargaSistema(ByVal psistema As String)
        ddlTipoSistema.Items.FindByValue("Banco").Selected = False
        ddlTipoSistema.Items.FindByValue("Cliente").Selected = False
        ddlTipoSistema.Items.FindByValue("Proveedor").Selected = False
        ddlTipoSistema.Items.FindByValue("HPersonal").Selected = False
        ddlTipoSistema.Items.FindByValue(psistema).Selected = True
    End Sub

    Private Sub dgTipoDocumento_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipoDocumento.DeleteCommand
        objTipoDocumento.TipoSistema = Mid(dgTipoDocumento.DataKeys(e.Item.ItemIndex).ToString, 1, 1)
        objTipoDocumento.TipoDocumento = Mid(dgTipoDocumento.DataKeys(e.Item.ItemIndex).ToString, 2, 2)
        lblMsg.Text = objTipoDocumento.Borrar
        If lblMsg.Text.Trim = "OK" Then
            CargaDatos()
        End If
    End Sub

    Private Sub rbCargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCargo.CheckedChanged
        rbAbono.Checked = False
        rbCargo.Checked = True
    End Sub

    Private Sub rbAbono_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAbono.CheckedChanged
        rbAbono.Checked = True
        rbCargo.Checked = False
    End Sub

    Private Sub rbsi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsi.CheckedChanged
        rbsi.Checked = True
        rbno.Checked = False
    End Sub

    Private Sub rbno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbno.CheckedChanged
        rbsi.Checked = False
        rbno.Checked = True
    End Sub

    Private Sub TipoDocSunatSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDocSunatSI.CheckedChanged
        TipoDocSunatNO.Checked = False
        TipoDocSunatSI.Checked = True
    End Sub

    Private Sub TipoDocSunatNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDocSunatNO.CheckedChanged
        TipoDocSunatNO.Checked = True
        TipoDocSunatSI.Checked = False
    End Sub

End Class
