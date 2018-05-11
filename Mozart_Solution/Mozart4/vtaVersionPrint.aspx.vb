Imports System.Data

Partial Class vtaVersionPrint
    Inherits System.Web.UI.Page
    Private dv As DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If
        If Not Page.IsPostBack Then
            Viewstate("NroPedido") = Request.Params("NroPedido")
            Viewstate("NroPropuesta") = Request.Params("NroPropuesta")
            Viewstate("NroVersion") = Request.Params("NroVersion")
            Viewstate("FlagIdioma") = Request.Params("FlagIdioma")
            txtCliente.Text = Request.Params("Cliente")
        End If
    End Sub

    Private Sub cmdImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprime.Click
        If Viewstate("FlagIdioma") = "I" Then
            Response.Redirect("vtaVersionPrintIn.aspx" & _
            "?&I1=" & Viewstate("NroPedido") & _
            "&I2=" & Viewstate("NroPropuesta") & _
            "&I3=" & Viewstate("NroVersion") & _
            "&I4=" & txtCliente.Text)
        ElseIf ViewState("FlagIdioma") = "E" Then
            Response.Redirect("vtaVersionPrintEs.aspx" & _
            "?&I1=" & ViewState("NroPedido") & _
            "&I2=" & ViewState("NroPropuesta") & _
            "&I3=" & ViewState("NroVersion") & _
            "&I4=" & txtCliente.Text)
        Else
            Response.Redirect("vtaVersionPrintPo.aspx" & _
            "?&I1=" & ViewState("NroPedido") & _
            "&I2=" & ViewState("NroPropuesta") & _
            "&I3=" & ViewState("NroVersion") & _
            "&I4=" & txtCliente.Text)
        End If
    End Sub


End Class
