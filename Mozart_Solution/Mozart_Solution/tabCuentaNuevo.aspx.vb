Imports cmpTabla

Partial Class tabCuentaNuevo
    Inherits System.Web.UI.Page
    Dim ObjRutina As New cmpRutinas.clsRutinas
    Dim objCuenta As New clsCuenta
    Dim objTablaElemento As New clsTablaElemento

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim wpcodBanco, wMoneda As String

        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("Opcion") = Request.Params("Opcion")

            If Viewstate("Opcion") = "Nuevo" Then
                lbltitulo.Text = "Nueva Cuenta"
                CargaTipoCuenta("")
                CargaGrupoCuenta(0)
            Else
                lbltitulo.Text = "Modificar Cuenta"
                Viewstate("CodCuenta") = Request.Params("CodCuenta")
                EditaGasto()
            End If
        End If
    End Sub

    Private Sub CargaTipoCuenta(ByVal pTipoCuenta As String)
        ddlTipoCuenta.DataSource = objTablaElemento.CargaTablaElexCodEle(13, "E")
        ddlTipoCuenta.DataBind()
        Try
            ddlTipoCuenta.Items.FindByValue(pTipoCuenta).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargaGrupoCuenta(ByVal pGrupoCuenta As Integer)
        ddlGrupoCuenta.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(12, "E")
        ddlGrupoCuenta.DataBind()
        Try
            ddlGrupoCuenta.Items.FindByValue(pGrupoCuenta).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim wcodnivel As String
        If txtCodCuenta.Text.Trim.Length = 1 Then
            wcodnivel = "0"
        ElseIf txtCodCuenta.Text.Trim.Length = 2 Then
            wcodnivel = "1"
        Else
            wcodnivel = "2"
        End If


        objCuenta.CodCuenta = txtCodCuenta.Text
        objCuenta.NomCuenta = txtNomCuenta.Text
        objCuenta.TipoCuenta = ddlTipoCuenta.SelectedItem.Value
        objCuenta.GrupoCuenta = ddlGrupoCuenta.SelectedItem.Value
        objCuenta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objCuenta.Grabar
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("tabCuenta.aspx" & _
            "?CodCuenta=" & ObjRutina.setTamano(txtCodCuenta.Text, 4) & _
            "&CodNivel=" & wcodnivel & _
            "&Opcion=" & "Nuevo")
        Else
            lblMsg.Visible = True
        End If
    End Sub
    Private Sub EditaGasto()
        objCuenta.CodCuenta = Request.Params("CodCuenta")
        lblMsg.Text = objCuenta.Editar()
        If lblMsg.Text.Trim = "OK" Then
            txtCodCuenta.Text = objCuenta.CodCuenta
            txtNomCuenta.Text = objCuenta.NomCuenta
            CargaTipoCuenta(objCuenta.TipoCuenta)
            CargaGrupoCuenta(objCuenta.GrupoCuenta)
        End If
    End Sub

End Class
