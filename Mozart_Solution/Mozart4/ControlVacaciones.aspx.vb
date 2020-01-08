Imports cmpNegocio
'Imports cmpTabla
Imports cmpRutinas

Partial Class ControlVacaciones
    Inherits System.Web.UI.Page
    Dim objAsistencia As New clsAsistencia
    Dim objRutina As New clsRutinas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CodUsuario") = "" Then
            Response.Redirect("segSesion.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim dateTimeInfo As DateTime = DateTime.Now
            txtFchIni.Text = dateTimeInfo.AddDays(0).ToString("d")

            GridView1.Attributes.Add("bordercolor", "#5F9EA0")
            Carga()
        End If
    End Sub

    Private Sub Carga()
        GridView1.DataSource = objAsistencia.ControlVacaciones(objRutina.fechayyyymmdd(txtFchIni.Text))
        GridView1.DataBind()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Carga()
    End Sub
End Class
