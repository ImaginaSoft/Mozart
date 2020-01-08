Imports cmpNegocio
Imports cmpTabla
Imports cmpRutinas

Partial Class VtaFacturadasCierre
    Inherits System.Web.UI.Page
    Dim objRutina As New clsRutinas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            EditaPeriodoAbierto()
        End If
    End Sub

    Private Sub EditaPeriodoAbierto()
        Dim objPeriodoVta As New clsPeriodoVta
        lblMsg.Text = objPeriodoVta.EditarPeriodoAbierto
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = ""
            ' Configurado Español
            System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("es-PE")

            lblfchini.Text = String.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchIniPeriodo)
            lblfchfin.Text = String.Format("{0:dd-MM-yyyy}", objPeriodoVta.FchFinPeriodo)
        End If
    End Sub

    Private Sub cmdCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCierre.Click
        If lblfchini.Text.Trim.Length = 0 Then
            lblMsg.Text = "No existe periodo de ventas abierto para hacer cierre."
            lblMsg.CssClass = "error"
            Return
        End If

        Dim objVersion As New clsVersion
        lblMsg.Text = objVersion.CierrePeriodoVentas(Session("CodUsuario"), objRutina.fechayyyymmdd(lblfchini.Text), objRutina.fechayyyymmdd(lblfchfin.Text))
        If lblMsg.Text.Trim = "OK" Then
            lblMsg.Text = "Proceso de cierre termino correctamente."
            lblMsg.CssClass = "msg"
        Else
            lblMsg.CssClass = "error"
        End If
    End Sub


End Class
