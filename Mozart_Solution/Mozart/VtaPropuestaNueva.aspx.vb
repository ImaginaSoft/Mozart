Imports System
Imports System.Data
Imports cmpRutinas
Imports cmpNegocio
Imports cmpTabla

Partial Class VtaPropuestaNueva
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas
    Dim objPropuesta As New clsPropuesta
    Dim objIdioma As New clsIdioma

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("CodCliente") = Request.Params("CodCliente")
            If Len(Trim(Request.Params("NroPropuesta"))) = 0 Then
                lblTitulo.Text = "Nueva Propuesta"
                CargaIdioma("")
            Else
                EditaPropuesta()
                lblTitulo.Text = "Modificar Propuesta N° " & Viewstate("NroPropuesta")
            End If
        End If

    End Sub
    Private Sub CargaIdioma(ByVal pIdioma As String)
        Dim ds As New DataSet
        ds = objIdioma.Cargar()
        ddlIdioma.DataSource = ds
        ddlIdioma.DataBind()
        If pIdioma.Trim.Length > 0 Then
            Try
                ddlIdioma.Items.FindByValue(pIdioma).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If txtPorUtilidad.Text.Trim.Length = 0 Then
            objPropuesta.PorUtilidad = 0
        ElseIf IsNumeric(txtPorUtilidad.Text) Then
            objPropuesta.PorUtilidad = txtPorUtilidad.Text
        Else
            lblMsg.Text = "Error : % Utilidad es dato númerico"
            Return
        End If

        objPropuesta.CantAduSGL = objRutina.ConvierteEntero(txtAS.Text)
        objPropuesta.CantAduDBL = objRutina.ConvierteEntero(txtAD.Text)
        objPropuesta.CantAduTPL = objRutina.ConvierteEntero(txtAT.Text)
        objPropuesta.CantAduCDL = objRutina.ConvierteEntero(txtAC.Text)
        objPropuesta.CantNinSGL = objRutina.ConvierteEntero(txtNS.Text)
        objPropuesta.CantNinDBL = objRutina.ConvierteEntero(txtND.Text)
        objPropuesta.CantNinTPL = objRutina.ConvierteEntero(txtNT.Text)
        objPropuesta.CantNinCDL = objRutina.ConvierteEntero(txtNC.Text)

        If objPropuesta.CantAduSGL + objPropuesta.CantAduDBL + objPropuesta.CantAduTPL + objPropuesta.CantAduCDL + objPropuesta.CantNinSGL + objPropuesta.CantNinDBL + objPropuesta.CantNinTPL + objPropuesta.CantNinCDL = 0 Then
            lblMsg.Text = "Error : Ingrese por lo menos un pasajero"
            Return
        End If

        objPropuesta.FlagIdioma = ddlIdioma.SelectedValue

        If lblNroPropuesta.Text.Trim.Length = 0 Then
            objPropuesta.NroPropuesta = 0
        Else
            objPropuesta.NroPropuesta = lblNroPropuesta.Text
        End If

        objPropuesta.NroPedido = Viewstate("NroPedido")
        objPropuesta.DesPropuesta = txtDesPropuesta.Text.Trim
        objPropuesta.CodCliente = Viewstate("CodCliente")
        objPropuesta.FchInicio = objRutina.fechayyyymmdd(txtFchInicio.Text)
        objPropuesta.CodUsuario = Session("CodUsuario")
        lblMsg.Text = objPropuesta.GrabaPropuesta
        If lblMsg.Text.Trim = "OK" Then
            Response.Redirect("VtaPropuestaFicha.aspx" & _
                    "?NroPedido=" & Viewstate("NroPedido") & _
                    "&NroPropuesta=" & objPropuesta.NroPropuesta)
        End If
    End Sub


    Private Sub EditaPropuesta()
        lblNroPropuesta.Text = CStr(Viewstate("NroPropuesta"))
        objPropuesta.NroPedido = Viewstate("NroPedido")
        objPropuesta.NroPropuesta = Viewstate("NroPropuesta")
        lblMsg.Text = objPropuesta.Editar()
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            txtDesPropuesta.Text = objPropuesta.DesPropuesta
            lblFchPropuesta.Text = String.Format("{0:dd-MM-yyyy}", objPropuesta.FchPropuesta)
            lblStsPropuesta.Text = objPropuesta.StsPropuesta
            txtPorUtilidad.Text = String.Format("{0:##0.00}", objPropuesta.PorUtilidad)
            If objPropuesta.CantAduSGL > 0 Then txtAS.Text = objPropuesta.CantAduSGL
            If objPropuesta.CantAduDBL > 0 Then txtAD.Text = objPropuesta.CantAduDBL
            If objPropuesta.CantAduTPL > 0 Then txtAT.Text = objPropuesta.CantAduTPL
            If objPropuesta.CantAduCDL > 0 Then txtAC.Text = objPropuesta.CantAduCDL
            If objPropuesta.CantNinSGL > 0 Then txtNS.Text = objPropuesta.CantNinSGL
            If objPropuesta.CantNinDBL > 0 Then txtND.Text = objPropuesta.CantNinDBL
            If objPropuesta.CantNinTPL > 0 Then txtNT.Text = objPropuesta.CantNinTPL
            If objPropuesta.CantNinCDL > 0 Then txtNC.Text = objPropuesta.CantNinCDL

            txtFchInicio.Text = String.Format("{0:dd-MM-yyyy}", objPropuesta.FchInicio)
            If objPropuesta.FlagPublica = "S" Then
                lblPublica.Text = "Si"
            Else
                lblPublica.Text = "No"
            End If

            CargaIdioma(objPropuesta.FlagIdioma)

            If objPropuesta.FlagEdita = "N" Or objPropuesta.FlagEdita = "E" Then
                cmdGrabar.Visible = False
                If Viewstate("FlagEdita") = "N" Then
                    lblMsg.Text = "La Propuesta es modelo antiguo, no se puede modificar los Servicios"
                Else
                    lblMsg.Text = "La Propuesta es de otra empresa, no se puede modificar los Servicios"
                End If
                lblMsg.CssClass = "Msg"
            ElseIf objPropuesta.StsPropuesta = "V" Then
                cmdGrabar.Visible = False
                lblMsg.Text = "La propuesta ya tiene versión, no se puede modificar"
                lblMsg.CssClass = "Msg"
            ElseIf objPropuesta.FlagPublica = "S" Then
                cmdGrabar.Visible = False
                lblMsg.Text = "La propuesta esta publicada, no se puede modificar"
                lblMsg.CssClass = "Msg"
            End If
        End If
    End Sub

End Class
