Imports cmpTabla
Imports System.Data

Partial Class tabCuenta
    Inherits System.Web.UI.Page
    Private dv As DataView
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim objCuenta As New clsCuenta

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")
            If Viewstate("Opcion") = "Nuevo" Then
                Viewstate("CodCuenta") = Request.Params("CodCuenta")
                If Request.Params("CodNivel") = "1" Then
                    CargaCuenta2(Viewstate("CodCuenta"))
                Else
                    CargaCuenta2(ObjRutina.setTamano(Mid(Viewstate("CodCuenta"), 1, 2), 4))
                End If
                CargaDatos()
            Else
                CargaCuenta2("")
                If ddlCuenta2.Items.Count > 0 Then
                    If ddlCuenta2.SelectedItem.Value = "Todos" Then
                        CargaTotal()
                    Else
                        CargaDatos()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If ddlCuenta2.Items.Count > 0 Then
            If ddlCuenta2.SelectedItem.Value = "Todos" Then
                CargaTotal()
            Else
                CargaDatos()
            End If

        End If
    End Sub
    Private Sub CargaCuenta2(ByVal pCodCuenta As String)
        Dim ds As New DataSet
        ds = objCuenta.CargarCuentaNivel1()
        ddlCuenta2.DataSource = ds
        ddlCuenta2.DataBind()
        ddlCuenta2.Items.Insert(0, New ListItem("Todos"))
        If pCodCuenta.Trim.Length > 0 Then
            ddlCuenta2.Items.FindByValue(pCodCuenta).Selected = True
        Else
            ddlCuenta2.Items.FindByValue("Todos").Selected = True
        End If
    End Sub
    Private Sub CargaTotal()
        Dim ds As New DataSet
        ds = objCuenta.Cargar()
        dgGastos.DataKeyField = "keyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgGastos.DataSource = dv
        dgGastos.DataBind()
        lblMsg.CssClass = "msg"
        lblMsg.Text = CStr(dgGastos.Items.Count) + " Cuenta(s)"

    End Sub
    Private Sub CargaDatos()
        Dim ds As New DataSet
        ds = objCuenta.CargarCuenta4(ddlCuenta2.SelectedItem.Value)
        dgGastos.DataKeyField = "keyReg"
        dv = New DataView(ds.Tables(0))
        dv.Sort = viewstate("Campo")
        dgGastos.DataSource = dv
        dgGastos.DataBind()
        lblMsg.CssClass = "msg"
        lblMsg.Text = CStr(dgGastos.Items.Count) + " Cuenta(s)"
    End Sub
    Private Sub dgGastos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgGastos.SelectedIndexChanged
        Response.Redirect("tabCuentaNuevo.aspx" & _
                             "?CodCuenta=" & dgGastos.Items(dgGastos.SelectedIndex).Cells(1).Text & _
                             "&Opcion=" & "Modifica")
    End Sub
    Private Sub dgGastos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGastos.DeleteCommand
        objCuenta.CodCuenta = Mid(dgGastos.DataKeys(e.Item.ItemIndex), 1, 4)
        objCuenta.CodNivel = Mid(dgGastos.DataKeys(e.Item.ItemIndex), 5, 1)
        lblMsg.Text = objCuenta.Borrar
        If lblMsg.Text.Trim = "OK" Then
            If ddlCuenta2.Items.Count > 0 Then
                CargaCuenta2("")
                CargaDatos()
            End If
        Else
            lblMsg.CssClass = "error"
        End If
    End Sub

    Private Sub lblNuevoGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNuevoGasto.Click
        Response.Redirect("tabCuentaNuevo.aspx" & _
                         "?Opcion=" & "Nuevo")
    End Sub

    Private Sub dgGastos_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgGastos.SortCommand
        ViewState("Campo") = e.SortExpression()
        CargaDatos()
    End Sub
End Class
