Imports cmpTabla
Imports cmpRutinas
Imports cmpNegocio
Imports System.Data

Partial Class VtaPropuestaPlantilla
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim objPedido As New clsPedido
    Dim objPropuesta As New clsPropuesta
    Dim objPlantilla As New clsPlantilla
    Dim objTablaElemento As New clsTablaElemento
    Dim objZonaVta As New clsZonaVta
    Dim objIdioma As New clsIdioma

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            txtNroDiaInicio.Text = "1"
            CargaIdioma()
            LeePedido()
            CargaPropuestas()
            CargaTipoPlantilla()
        End If
    End Sub

    Private Sub CargaIdioma()
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
    End Sub

    Private Sub CargaTipoPlantilla()
        ddlTipoPlantilla.DataSource = objTablaElemento.CargaTablaEleNumxNroOrden(7, "E")
        ddlTipoPlantilla.DataBind()
        ddlTipoPlantilla.Items.Insert(0, New ListItem("Todos"))
    End Sub

    Private Sub LeePedido()
        objPedido.NroPedido = Viewstate("NroPedido")
        lblMsg.Text = objPedido.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            txtAD.Text = objPedido.Adultos
            txtND.Text = objPedido.Ninos
            txtFchInicio.Text = objPedido.FchAtencion

            ddlZonaVta.DataSource = objZonaVta.Cargar(Session("CodUsuario"))
            ddlZonaVta.DataBind()
            'Zona Vta
            Try
                ddlZonaVta.Items.FindByValue(objPedido.CodZonaVta).Selected = True
            Catch ex As Exception

            End Try

            'Idioma
            Try
                ddlIdioma.Items.FindByValue(objPedido.Idioma).Selected = True
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub CargaPropuestas()
        Dim ds As New DataSet
        ds = objPropuesta.CargaPropuestas(Viewstate("NroPedido"))
        ddlPropuesta.DataSource = ds.Tables(0)
        ddlPropuesta.DataBind()
        ddlPropuesta.Items.Insert(0, New ListItem("Nueva Propuesta"))
    End Sub

    Private Sub txtNroPlantilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroPlantilla.TextChanged
        If Not IsNumeric(txtNroPlantilla.Text) Then
            lblMsg.Text = "Error : Nro. Plantilla es dato númerico"
            Return
        End If

        lblMsg.Text = objPlantilla.Editar(txtNroPlantilla.Text)
        If lblMsg.Text.Trim = "OK" Then
            txtTitulo.Text = objPlantilla.DesPlantilla
        End If

        Dim ds As New DataSet
        ds = objPlantilla.CargaNroPlantilla(txtNroPlantilla.Text)
        ddlPlantilla.DataSource = ds.Tables(0)
        ddlPlantilla.DataBind()
    End Sub

    Private Sub CargaPlantilla()
        Dim ds As New DataSet
        If ddlTipoPlantilla.SelectedItem.Text = "Todos" Then
            If txtCantDias.Text.Trim.Length = 0 Then
                If chbTitulo.Checked Then
                    ds = objPlantilla.CargaxTitulo(ddlZonaVta.SelectedValue, txtTitulo.Text.Trim & "%", Viewstate("NroPedido"))
                Else
                    ds = objPlantilla.CargaxTitulo(ddlZonaVta.SelectedValue, "%" & txtTitulo.Text.Trim & "%", Viewstate("NroPedido"))
                End If
            ElseIf chbTitulo.Checked Then
                ds = objPlantilla.CargaxTituloDias(ddlZonaVta.SelectedValue, txtTitulo.Text.Trim & "%", txtCantDias.Text, Viewstate("NroPedido"))
            Else
                ds = objPlantilla.CargaxTituloDias(ddlZonaVta.SelectedValue, "%" & txtTitulo.Text.Trim & "%", txtCantDias.Text, Viewstate("NroPedido"))
            End If
        Else
            If txtCantDias.Text.Trim.Length = 0 Then
                If chbTitulo.Checked Then
                    ds = objPlantilla.CargaxTitulo(ddlZonaVta.SelectedValue, txtTitulo.Text.Trim & "%", Viewstate("NroPedido"), ddlTipoPlantilla.SelectedValue)
                Else
                    ds = objPlantilla.CargaxTitulo(ddlZonaVta.SelectedValue, "%" & txtTitulo.Text.Trim & "%", Viewstate("NroPedido"), ddlTipoPlantilla.SelectedValue)
                End If
            ElseIf chbTitulo.Checked Then
                ds = objPlantilla.CargaxTituloDias(ddlZonaVta.SelectedValue, txtTitulo.Text.Trim & "%", txtCantDias.Text, Viewstate("NroPedido"), ddlTipoPlantilla.SelectedValue)
            Else
                ds = objPlantilla.CargaxTituloDias(ddlZonaVta.SelectedValue, "%" & txtTitulo.Text.Trim & "%", txtCantDias.Text, Viewstate("NroPedido"), ddlTipoPlantilla.SelectedValue)
            End If

        End If

        ddlPlantilla.DataSource = ds.Tables(0)
        ddlPlantilla.DataBind()
        If ddlPlantilla.Items.Count() > 0 Then
            txtNroPlantilla.Text = ddlPlantilla.SelectedItem.Value
        End If
    End Sub

    Private Sub ddlPlantilla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlantilla.SelectedIndexChanged
        txtNroPlantilla.Text = ddlPlantilla.SelectedItem.Value
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        objPropuesta.NroPlantilla = txtNroPlantilla.Text
        objPropuesta.NroDiaInicio = txtNroDiaInicio.Text

        objPropuesta.CantAduSGL = ConvierteEntero(txtAS.Text)
        objPropuesta.CantAduDBL = ConvierteEntero(txtAD.Text)
        objPropuesta.CantAduTPL = ConvierteEntero(txtAT.Text)
        objPropuesta.CantAduCDL = ConvierteEntero(txtAC.Text)

        objPropuesta.CantNinSGL = ConvierteEntero(txtNS.Text)
        objPropuesta.CantNinDBL = ConvierteEntero(txtND.Text)
        objPropuesta.CantNinTPL = ConvierteEntero(txtNT.Text)
        objPropuesta.CantNinCDL = ConvierteEntero(txtNC.Text)

        objPropuesta.FlagIdioma = ddlIdioma.SelectedValue

        If ddlPropuesta.SelectedItem.Value = "Nueva Propuesta" Then
            objPropuesta.NroPropuesta = 0
        Else
            objPropuesta.NroPropuesta = ddlPropuesta.SelectedItem.Value
        End If

        objPropuesta.NroPedido = Viewstate("NroPedido")
        objPropuesta.CodCliente = Viewstate("CodCliente")
        objPropuesta.FchInicio = objRutina.fechayyyymmdd(txtFchInicio.Text)
        objPropuesta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPropuesta.GrabaPropuestaDePlantilla
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            Response.Redirect("VtaPedidoFicha.aspx" & _
                              "?NroPedido=" & Viewstate("NroPedido") & _
                             "&CodCliente=" & Viewstate("CodCliente"))
        End If
    End Sub

    Function ConvierteEntero(ByVal pdato As String) As Integer
        Dim wValor As Integer
        If pdato.Trim.Length = 0 Then
            wValor = 0
        Else
            If IsNumeric(pdato) Then
                wValor = CInt(pdato)
            Else
                wValor = 0
            End If
        End If
        Return (wValor)
    End Function

    Private Sub txtTitulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitulo.TextChanged
        CargaPlantilla()
    End Sub

    Private Sub chbTitulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTitulo.CheckedChanged
        CargaPlantilla()
    End Sub

    Private Sub txtCantDias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantDias.TextChanged
        CargaPlantilla()
    End Sub

    Private Sub ddlTipoPlantilla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoPlantilla.SelectedIndexChanged
        If ddlTipoPlantilla.SelectedItem.Text = "Todos" Then
            ddlPlantilla.Items.Clear()
        Else
            CargaPlantilla()
        End If
    End Sub

    Private Sub ddlZonaVta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlZonaVta.SelectedIndexChanged
        ddlPlantilla.Items.Clear()
    End Sub

End Class
