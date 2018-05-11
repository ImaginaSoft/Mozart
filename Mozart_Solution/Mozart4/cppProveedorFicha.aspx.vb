Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class cppProveedorFicha
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("cnMozart"))
    Dim objRutina As New cmpRutinas.clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Viewstate("CodProveedor") = Request.Params("CodProveedor")
        End If
    End Sub

    Private Sub lbtRegistraPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraPago.Click
        Response.Redirect("cppRegistraPago.aspx" & _
                        "?CodProveedor=" & UcProveedor1.Codigo())

    End Sub


    Private Sub lbtCtacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtCtacte.Click
        Response.Redirect("cppCtaCte.aspx" & _
                        "?CodProveedor=" & UcProveedor1.Codigo())


    End Sub

    Private Sub lbtDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtDocumentos.Click
        Response.Redirect("cppDocumento.aspx" & _
                        "?CodProveedor=" & UcProveedor1.Codigo())


    End Sub


    Private Sub lbtRegistraCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraCredito.Click
        Response.Redirect("cppRegistraCredito.aspx" & _
                        "?CodProveedor=" & UcProveedor1.Codigo())
    End Sub

    Private Sub lbtRegistraDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("cppRegistraGasto.aspx" & _
                            "?CodProveedor=" & UcProveedor1.Codigo())
    End Sub

    Private Sub lbtActualizaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtActualizaCliente.Click
        Response.Redirect("cppProveedorNuevo.aspx" & _
                          "?Opcion=" & "A" & _
                          "&CodProveedor=" & UcProveedor1.Codigo())

    End Sub

    Private Sub lbtNuevoProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtNuevoProveedor.Click
        Response.Redirect("cppProveedorNuevo.aspx" & _
                           "?Opcion=" & "N")
    End Sub


    Private Sub lbtEliminarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtEliminarCliente.Click
        If Len(Trim(UcProveedor1.Nombre())) > 0 Then
            Response.Redirect("cppProveedorNuevo.aspx" & _
                            "?Opcion=" & "E" & _
                            "&CodProveedor=" & UcProveedor1.Codigo())
        End If
    End Sub

    Private Sub lbtPendientesCuadre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtPendientesCuadre.Click
        If Len(Trim(UcProveedor1.Nombre())) > 0 Then
            Response.Redirect("cppCuadreObligaciones.aspx" & _
                            "?Opcion=" & "P" & _
                            "&CodProveedor=" & UcProveedor1.Codigo())
        End If
    End Sub

    Private Sub lbtRegistraGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraGastos.Click
        Response.Redirect("cppRegistraGasto.aspx" & _
                          "?CodProveedor=" & UcProveedor1.Codigo())
    End Sub

    Private Sub LbtRegistroHonorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LbtRegistroHonorarios.Click
        Response.Redirect("cppRegistraRH.aspx" & _
                          "?CodProveedor=" & UcProveedor1.Codigo())
    End Sub

    Private Sub lkbRegistraDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbRegistraDebito.Click
        Response.Redirect("cppRegistraDebito.aspx" & _
                  "?CodProveedor=" & UcProveedor1.Codigo())

    End Sub

    Private Sub lbtContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtContacto.Click
        Response.Redirect("cppProveedorContacto.aspx" & _
                  "?CodProveedor=" & UcProveedor1.Codigo() & _
                  "&NomProveedor=" & UcProveedor1.Nombre())
    End Sub

    Private Sub lbtRegistraPrePago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtRegistraPrePago.Click
        Response.Redirect("cppRegistraPrePago.aspx" & _
                "?CodProveedor=" & UcProveedor1.Codigo())
    End Sub

End Class
