Imports cmpNegocio
Imports cmpTabla
Imports cmpRutinas
Imports System.Data

Partial Class VtaPropuestaPublica
    Inherits System.Web.UI.Page
    Dim objPropuesta As New clsPropuesta
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")

            lblTitulo.Text = "Publicar Propuesta N° " & Viewstate("NroPropuesta")
            Viewstate("TipoCambio") = objRutina.LeeParametroNumero("TipoCambioEuro")
            EditaPropuesta()
        End If
    End Sub

    Private Sub EditaPropuesta()
        lblNroPropuesta.Text = Viewstate("NroPropuesta")
        objPropuesta.NroPedido = Viewstate("NroPedido")
        objPropuesta.NroPropuesta = Viewstate("NroPropuesta")
        lblMsg.Text = objPropuesta.Editar
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            Viewstate("CodCliente") = objPropuesta.CodCliente
            lblDesPropuesta.Text = objPropuesta.DesPropuesta
            lblCantDias.Text = objPropuesta.CantDias
            lblFchPropuesta.Text = String.Format("{0:dd-MM-yyyy}", CDate(objPropuesta.FchPropuesta))
            lblStsPropuesta.Text = objPropuesta.StsPropuesta
            lblPorUtilidad.Text = String.Format("{0:##0.00}", CDbl(objPropuesta.PorUtilidad))
            lblTipoCambioEuro.Text = String.Format("{0:##,##0.0000}", CDbl(objPropuesta.TipoCambioEuro))
            '
            '           If objPropuesta.CantAdultos > 0 Then
            'lblPasajeros.Text = "Adultos " & CStr(objPropuesta.CantAdultos)
            '        End If

            '       If objPropuesta.CantNinos > 0 Then
            '         lblPasajeros.Text = lblPasajeros.Text & " Niños " & CStr(objPropuesta.CantNinos)
            '      End If

            If objPropuesta.FlagPublica = "S" Then
                rbtSi.Checked = True
            Else
                rbtNo.Checked = True
            End If

            If objPropuesta.FlagPublicaEuro = "S" Then
                rbtEuroSI.Checked = True
            Else
                rbtEuroNO.Checked = True
            End If

            If objPropuesta.FlagAtencion = "D" Then
                rbtNroDia.Checked = True
            Else
                rbtFecha.Checked = True
            End If

            If objPropuesta.FlagVenta = "S" Then
                rbtSIVta.Checked = True
            Else
                rbtNOVta.Checked = True
            End If

            If IsDate(objPropuesta.FchInicio) Then
                txtFchInicio.Text = ToString.Format("{0:dd-MM-yyyy}", CDate(objPropuesta.FchInicio))
            End If

            CargaStsCaptacion(objPropuesta.StsCaptacion)

            If objPropuesta.FlagEdita = "E" Then
                cmbGrabar.Visible = False
                lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar los Servicios"
                lblMsg.CssClass = "msg"
            End If
        End If
    End Sub

    Private Sub CargaStsCaptacion(ByVal pStsCaptacion As String)
        Dim objStsCaptacion As New clsStsCaptacion
        Dim ds As New DataSet
        ds = objStsCaptacion.Cargar
        ddlStsCaptacion.DataSource = ds
        ddlStsCaptacion.DataBind()
        If pStsCaptacion.Trim.Length > 0 Then
            ddlStsCaptacion.Items.FindByValue(pStsCaptacion).Selected = True
        End If
    End Sub

    Private Sub cmbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrabar.Click
        If rbtSi.Checked = True Then
            objPropuesta.FlagPublica = "S" 'SI
        Else
            objPropuesta.FlagPublica = "N" 'NO
        End If

        If rbtEuroSI.Checked = True Then
            objPropuesta.FlagPublicaEuro = "S" 'SI
        Else
            objPropuesta.FlagPublicaEuro = "N" 'NO
        End If

        If rbtSIVta.Checked Then
            objPropuesta.FlagVenta = "S" 'Se muestra en proyeccion de ventas
        Else
            objPropuesta.FlagVenta = "N" ' no se muestra
        End If

        If rbtNroDia.Checked = True Then
            objPropuesta.FlagAtencion = "D" ' Dias
        Else
            objPropuesta.FlagAtencion = "F" ' Fechas
        End If

        objPropuesta.NroPedido = Viewstate("NroPedido")
        objPropuesta.NroPropuesta = Viewstate("NroPropuesta")
        objPropuesta.TipoCambioEuro = lblTipoCambioEuro.Text
        objPropuesta.FchInicio = txtFchInicio.Text
        objPropuesta.StsCaptacion = ddlStsCaptacion.SelectedItem.Value
        objPropuesta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPropuesta.Publica
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaPropuestaFicha.aspx" & _
                    "?NroPedido=" & Viewstate("NroPedido") & _
                    "&NroPropuesta=" & Viewstate("NroPropuesta"))
        End If
    End Sub

    Private Sub rbtEuroSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEuroSI.CheckedChanged
        lblTipoCambioEuro.Text = Viewstate("TipoCambio")
    End Sub

    Private Sub rbtEuroNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEuroNO.CheckedChanged
        lblTipoCambioEuro.Text = "0.0"
    End Sub

End Class
